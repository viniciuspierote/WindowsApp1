Option Strict On
Option Explicit On
Imports System
Imports System.Data
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public NotInheritable Class UsuarioAutenticado
    Public ReadOnly Property Id As Integer
    Public ReadOnly Property Login As String
    Public ReadOnly Property Nome As String
    Public ReadOnly Property Perfil As String
    Public ReadOnly Property Versao As Integer
    Public ReadOnly Property TrocarSenha As Boolean
    Public Sub New(row As DataRow)
        Id = Convert.ToInt32(row("id"))
        Login = Convert.ToString(row("login"), CultureInfo.InvariantCulture)
        Nome = Convert.ToString(row("nome"), CultureInfo.InvariantCulture)
        Perfil = Convert.ToString(row("perfil"), CultureInfo.InvariantCulture)
        Versao = Convert.ToInt32(row("versao_acesso"))
        TrocarSenha = Convert.ToBoolean(row("trocar_senha"))
    End Sub
End Class

Public Module SessaoAtual
    Private ReadOnly Trava As New Object()
    Private _usuario As UsuarioAutenticado
    Public ReadOnly Property Usuario As UsuarioAutenticado
        Get
            SyncLock Trava
                Return _usuario
            End SyncLock
        End Get
    End Property
    Public ReadOnly Property Login As String
        Get
            Dim atual As UsuarioAutenticado = Usuario
            If atual Is Nothing Then Throw New InvalidOperationException("Entre no sistema antes de continuar.")
            Return atual.Login
        End Get
    End Property
    Public ReadOnly Property Administrador As Boolean
        Get
            Dim atual As UsuarioAutenticado = Usuario
            Return atual IsNot Nothing AndAlso atual.Perfil = "ADMINISTRADOR" AndAlso Not atual.TrocarSenha
        End Get
    End Property
    Public Sub Iniciar(atual As UsuarioAutenticado)
        If atual Is Nothing Then Throw New ArgumentNullException(NameOf(atual))
        SyncLock Trava
            _usuario = atual
        End SyncLock
    End Sub
    Public Sub Encerrar()
        SyncLock Trava
            _usuario = Nothing
        End SyncLock
    End Sub
    Public Sub ExigirAutenticado()
        Autenticacao.ValidarSessao(False)
    End Sub
    Public Sub ExigirAdministrador()
        Autenticacao.ValidarSessao(True)
    End Sub
End Module

Public Module Autenticacao
    Private Const Iteracoes As Integer = 600000
    Private Const MensagemLogin As String = "Não foi possível entrar. Confira usuário e senha. Se houver bloqueio temporário, aguarde 15 minutos ou procure o administrador."

    Private Function NormalizarLogin(valor As String) As String
        Return If(valor, "").Trim().ToLowerInvariant()
    End Function
    Private Sub ValidarLogin(valor As String)
        If Not Regex.IsMatch(valor, "^[a-z0-9._-]{3,60}$") Then
            Throw New ArgumentException("O usuário deve ter de 3 a 60 caracteres: letras sem acento, números, ponto, hífen ou sublinhado.")
        End If
    End Sub
    Private Sub ValidarSenha(senha As String)
        If senha Is Nothing OrElse senha.Length < 6 OrElse senha.Length > 128 Then
            Throw New ArgumentException(
            "A senha deve ter de 6 a 128 caracteres.")
        End If
    End Sub
    Private Function SaltAleatorio() As Byte()
        Dim valor(31) As Byte
        Using gerador As RandomNumberGenerator = RandomNumberGenerator.Create()
            gerador.GetBytes(valor)
        End Using
        Return valor
    End Function
    Private Function Derivar(senha As String, salt As Byte(), quantidade As Integer) As Byte()
        If salt.Length <> 32 OrElse quantidade < Iteracoes OrElse quantidade > 2000000 Then
            Throw New InvalidOperationException("Registro de senha inválido. Procure o administrador.")
        End If
        Using derivador As New Rfc2898DeriveBytes(senha, salt, quantidade, HashAlgorithmName.SHA256)
            Return derivador.GetBytes(32)
        End Using
    End Function
    Private Function Iguais(a As Byte(), b As Byte()) As Boolean
        If a Is Nothing OrElse b Is Nothing OrElse a.Length <> 32 OrElse b.Length <> 32 Then Return False
        Dim diferenca As Integer = 0
        For i As Integer = 0 To 31
            diferenca = diferenca Or (CInt(a(i)) Xor CInt(b(i)))
        Next
        Return diferenca = 0
    End Function
    Private Function Ler(cn As MySqlConnection, tx As MySqlTransaction, sql As String,
                         ParamArray pares As Object()) As DataTable
        Dim tabela As New DataTable()
        Using cmd As MySqlCommand = Comando(cn, tx, sql, pares)
            Using leitor As MySqlDataReader = cmd.ExecuteReader()
                tabela.Load(leitor)
            End Using
        End Using
        Return tabela
    End Function
    Private Function Comando(cn As MySqlConnection, tx As MySqlTransaction, sql As String,
                             ParamArray pares As Object()) As MySqlCommand
        Dim cmd As New MySqlCommand(sql, cn, tx)
        For i As Integer = 0 To pares.Length - 1 Step 2
            cmd.Parameters.AddWithValue(Convert.ToString(pares(i), CultureInfo.InvariantCulture), If(pares(i + 1), DBNull.Value))
        Next
        Return cmd
    End Function
    Private Function Executar(cn As MySqlConnection, tx As MySqlTransaction, sql As String,
                              ParamArray pares As Object()) As Long
        Using cmd As MySqlCommand = Comando(cn, tx, sql, pares)
            cmd.ExecuteNonQuery()
            Return cmd.LastInsertedId
        End Using
    End Function
    Private Sub Evento(cn As MySqlConnection, tx As MySqlTransaction, usuario As Integer,
                        ator As Integer, login As String, tipo As String)
        Executar(cn, tx, "INSERT INTO sis_acesso_eventos(usuario_id,ator_id,login_informado,evento,ocorrido_em,computador) " &
            "VALUES(@u,@a,@l,@e,UTC_TIMESTAMP(),@c)",
            "@u", If(usuario = 0, CType(DBNull.Value, Object), usuario),
            "@a", If(ator = 0, CType(DBNull.Value, Object), ator),
            "@l", login.Substring(0, Math.Min(60, login.Length)), "@e", tipo,
            "@c", Environment.MachineName.Substring(0, Math.Min(120, Environment.MachineName.Length)))
    End Sub
    Private Function Controle(cn As MySqlConnection, tx As MySqlTransaction) As Boolean
        Dim tabela As DataTable = Ler(cn, tx, "SELECT administrador_configurado FROM sis_autenticacao_controle WHERE id=1 FOR UPDATE")
        If tabela.Rows.Count <> 1 Then Throw New InvalidOperationException("Execute o SQL 007 completo antes de usar o login.")
        Return Convert.ToBoolean(tabela.Rows(0)(0))
    End Function
    Public Function PrecisaPrimeiroAdministrador() As Boolean
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Dim t As DataTable = Ler(cn, Nothing, "SELECT administrador_configurado,(SELECT COUNT(*) FROM sis_usuarios) AS quantidade " &
                "FROM sis_autenticacao_controle WHERE id=1")
            If t.Rows.Count <> 1 Then Throw New InvalidOperationException("Execute o SQL 007 completo antes de usar o login.")
            Dim pronto As Boolean = Convert.ToBoolean(t.Rows(0)(0))
            Dim quantidade As Integer = Convert.ToInt32(t.Rows(0)(1))
            If Not pronto AndAlso quantidade <> 0 Then Throw New InvalidOperationException("Configuração inicial inconsistente. Procure a TI; nenhum usuário foi alterado.")
            If pronto AndAlso quantidade = 0 Then Throw New InvalidOperationException("O administrador já foi configurado, mas não existem usuários. Procure a TI para recuperar o acesso.")
            Return Not pronto
        End Using
    End Function
    Public Sub CriarPrimeiroAdministrador(nome As String, loginInformado As String, senha As String)
        Dim login As String = NormalizarLogin(loginInformado)
        ValidarLogin(login)
        ValidarSenha(senha)
        If String.IsNullOrWhiteSpace(nome) OrElse nome.Trim().Length > 120 Then Throw New ArgumentException("Informe o nome, com até 120 caracteres.")
        Dim salt As Byte() = SaltAleatorio()
        Dim hash As Byte() = Derivar(senha, salt, Iteracoes)
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Using tx As MySqlTransaction = cn.BeginTransaction()
                Try
                    If Controle(cn, tx) Then Throw New InvalidOperationException("O primeiro administrador já foi criado. Entre com seu usuário e senha.")
                    If Convert.ToInt32(Ler(cn, tx, "SELECT COUNT(*) FROM sis_usuarios").Rows(0)(0)) <> 0 Then Throw New InvalidOperationException("Já existem usuários. Procure a TI.")
                    Dim id As Integer = Convert.ToInt32(Executar(cn, tx,
                        "INSERT INTO sis_usuarios(login,nome,perfil,ativo,senha_hash,senha_salt,senha_iteracoes,trocar_senha) " &
                        "VALUES(@l,@n,'ADMINISTRADOR',1,@h,@s,@i,0)", "@l", login, "@n", nome.Trim(), "@h", hash, "@s", salt, "@i", Iteracoes))
                    Executar(cn, tx, "UPDATE sis_autenticacao_controle SET administrador_configurado=1 WHERE id=1")
                    Evento(cn, tx, id, id, login, "PRIMEIRO_ADMIN")
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub
    Public Function Entrar(loginInformado As String, senha As String) As UsuarioAutenticado
        Dim login As String = NormalizarLogin(loginInformado)
        If String.IsNullOrWhiteSpace(login) OrElse login.Length > 60 OrElse senha Is Nothing OrElse senha.Length > 128 Then Throw New ArgumentException(MensagemLogin)
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Dim tabela As DataTable = Ler(cn, Nothing, "SELECT * FROM sis_usuarios WHERE login=@l", "@l", login)
            If tabela.Rows.Count = 0 Then
                Dim saltFalso(31) As Byte
                Dim ignorado As Byte() = Derivar(senha, saltFalso, Iteracoes)
                Array.Clear(ignorado, 0, ignorado.Length)
                Evento(cn, Nothing, 0, 0, login, "LOGIN_FALHOU")
                Throw New ArgumentException(MensagemLogin)
            End If
            Dim original As DataRow = tabela.Rows(0)
            Dim calculado As Byte() = Derivar(senha, DirectCast(original("senha_salt"), Byte()), Convert.ToInt32(original("senha_iteracoes")))
            Using tx As MySqlTransaction = cn.BeginTransaction()
                Dim sucesso As Boolean = False
                Dim resultado As UsuarioAutenticado = Nothing
                Try
                    Dim atual As DataRow = Ler(cn, tx, "SELECT *,UTC_TIMESTAMP() AS agora_utc FROM sis_usuarios WHERE id=@id FOR UPDATE", "@id", original("id")).Rows(0)
                    Dim bloqueado As Boolean = Not atual.IsNull("bloqueado_ate") AndAlso Convert.ToDateTime(atual("bloqueado_ate")) > Convert.ToDateTime(atual("agora_utc"))
                    Dim naoMudou As Boolean = Iguais(DirectCast(original("senha_hash"), Byte()), DirectCast(atual("senha_hash"), Byte())) AndAlso
                        Iguais(DirectCast(original("senha_salt"), Byte()), DirectCast(atual("senha_salt"), Byte())) AndAlso
                        Convert.ToInt32(original("senha_iteracoes")) = Convert.ToInt32(atual("senha_iteracoes"))
                    sucesso = Convert.ToBoolean(atual("ativo")) AndAlso Not bloqueado AndAlso naoMudou AndAlso Iguais(calculado, DirectCast(atual("senha_hash"), Byte()))
                    If sucesso Then
                        Executar(cn, tx, "UPDATE sis_usuarios SET falhas=0,bloqueado_ate=NULL,ultimo_login=UTC_TIMESTAMP() WHERE id=@id", "@id", atual("id"))
                        resultado = New UsuarioAutenticado(atual)
                        Evento(cn, tx, resultado.Id, resultado.Id, login, "LOGIN_OK")
                    Else
                        If Convert.ToBoolean(atual("ativo")) AndAlso Not bloqueado AndAlso naoMudou Then
                            Dim falhas As Integer = Convert.ToInt32(atual("falhas")) + 1
                            If falhas >= 5 Then
                                Executar(cn, tx, "UPDATE sis_usuarios SET falhas=0,bloqueado_ate=DATE_ADD(UTC_TIMESTAMP(),INTERVAL 15 MINUTE) WHERE id=@id", "@id", atual("id"))
                            Else
                                Executar(cn, tx, "UPDATE sis_usuarios SET falhas=@f WHERE id=@id", "@f", falhas, "@id", atual("id"))
                            End If
                        End If
                        Evento(cn, tx, Convert.ToInt32(atual("id")), 0, login, "LOGIN_FALHOU")
                    End If
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                Finally
                    Array.Clear(calculado, 0, calculado.Length)
                End Try
                If Not sucesso Then Throw New ArgumentException(MensagemLogin)
                Return resultado
            End Using
        End Using
    End Function
    Private Function ValidarDentro(cn As MySqlConnection, tx As MySqlTransaction, administrador As Boolean,
                                    Optional permitirTroca As Boolean = False) As UsuarioAutenticado
        Dim sessao As UsuarioAutenticado = SessaoAtual.Usuario
        If sessao Is Nothing Then Throw New InvalidOperationException("Entre no sistema antes de continuar.")
        Dim t As DataTable = Ler(cn, tx, "SELECT * FROM sis_usuarios WHERE id=@id", "@id", sessao.Id)
        If t.Rows.Count <> 1 Then Throw New InvalidOperationException("Sessão inválida. Entre novamente.")
        Dim atual As New UsuarioAutenticado(t.Rows(0))
        If Not Convert.ToBoolean(t.Rows(0)("ativo")) OrElse atual.Versao <> sessao.Versao Then Throw New InvalidOperationException("Seu acesso foi alterado. Feche as telas e entre novamente.")
        If atual.TrocarSenha AndAlso Not permitirTroca Then Throw New InvalidOperationException("Altere sua senha para continuar.")
        If administrador AndAlso atual.Perfil <> "ADMINISTRADOR" Then Throw New UnauthorizedAccessException("Somente administradores podem gerenciar usuários.")
        Return atual
    End Function
    Public Sub ValidarSessao(administrador As Boolean)
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            ValidarDentro(cn, Nothing, administrador)
        End Using
    End Sub
    Public Function ListarUsuarios() As DataTable
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            ValidarDentro(cn, Nothing, True)
            Return Ler(cn, Nothing, "SELECT id,login,nome,perfil,ativo,trocar_senha,bloqueado_ate,ultimo_login FROM sis_usuarios ORDER BY nome,login")
        End Using
    End Function
    Public Sub SalvarUsuario(id As Integer, nome As String, loginInformado As String, perfil As String,
                              ativo As Boolean, novaSenha As String)
        Dim login As String = NormalizarLogin(loginInformado)
        ValidarLogin(login)
        If String.IsNullOrWhiteSpace(nome) OrElse nome.Trim().Length > 120 Then Throw New ArgumentException("Informe o nome, com até 120 caracteres.")
        If perfil <> "ADMINISTRADOR" AndAlso perfil <> "OPERADOR" Then Throw New ArgumentException("Selecione o perfil.")
        If id = 0 OrElse novaSenha <> "" Then ValidarSenha(novaSenha)
        Dim salt As Byte() = Nothing, hash As Byte() = Nothing
        If id = 0 OrElse novaSenha <> "" Then
            salt = SaltAleatorio()
            hash = Derivar(novaSenha, salt, Iteracoes)
        End If
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Using tx As MySqlTransaction = cn.BeginTransaction()
                Try
                    If Not Controle(cn, tx) Then Throw New InvalidOperationException("Configure o primeiro administrador.")
                    Dim ator As UsuarioAutenticado = ValidarDentro(cn, tx, True)
                    If id = ator.Id AndAlso (Not ativo OrElse perfil <> "ADMINISTRADOR") Then Throw New InvalidOperationException("Você não pode inativar nem retirar o próprio perfil de administrador.")
                    If id = ator.Id AndAlso novaSenha <> "" Then Throw New InvalidOperationException("Use Alterar minha senha para trocar sua própria senha.")
                    Dim alvo As Integer = id
                    If id = 0 Then
                        alvo = Convert.ToInt32(Executar(cn, tx, "INSERT INTO sis_usuarios(login,nome,perfil,ativo,senha_hash,senha_salt,senha_iteracoes,trocar_senha) " &
                            "VALUES(@l,@n,@p,@a,@h,@s,@i,1)", "@l", login, "@n", nome.Trim(), "@p", perfil, "@a", ativo, "@h", hash, "@s", salt, "@i", Iteracoes))
                    Else
                        Dim antigo As DataTable = Ler(cn, tx, "SELECT * FROM sis_usuarios WHERE id=@id FOR UPDATE", "@id", id)
                        If antigo.Rows.Count <> 1 Then Throw New InvalidOperationException("Usuário não encontrado. Atualize a lista.")
                        If Convert.ToString(antigo.Rows(0)("login"), CultureInfo.InvariantCulture) <> login Then Throw New InvalidOperationException("O login de um usuário existente não pode ser alterado.")
                        If Convert.ToString(antigo.Rows(0)("perfil"), CultureInfo.InvariantCulture) = "ADMINISTRADOR" AndAlso Convert.ToBoolean(antigo.Rows(0)("ativo")) AndAlso
                            (Not ativo OrElse perfil <> "ADMINISTRADOR") Then
                            Dim total As Integer = Convert.ToInt32(Ler(cn, tx, "SELECT COUNT(*) FROM sis_usuarios WHERE ativo=1 AND perfil='ADMINISTRADOR'").Rows(0)(0))
                            If total <= 1 Then Throw New InvalidOperationException("Mantenha pelo menos um administrador ativo.")
                        End If
                        Dim versaoMuda As Boolean = Convert.ToBoolean(antigo.Rows(0)("ativo")) <> ativo OrElse Convert.ToString(antigo.Rows(0)("perfil"), CultureInfo.InvariantCulture) <> perfil OrElse novaSenha <> ""
                        Executar(cn, tx, "UPDATE sis_usuarios SET nome=@n,perfil=@p,ativo=@a,versao_acesso=versao_acesso+@v WHERE id=@id", "@n", nome.Trim(), "@p", perfil, "@a", ativo, "@v", If(versaoMuda, 1, 0), "@id", id)
                        If novaSenha <> "" Then
                            Executar(cn, tx, "UPDATE sis_usuarios SET senha_hash=@h,senha_salt=@s,senha_iteracoes=@i,trocar_senha=1,falhas=0,bloqueado_ate=NULL WHERE id=@id", "@h", hash, "@s", salt, "@i", Iteracoes, "@id", id)
                        End If
                    End If
                    Evento(cn, tx, alvo, ator.Id, login, If(id = 0, "USUARIO_CRIADO", If(novaSenha <> "", "SENHA_REDEFINIDA", "USUARIO_ALTERADO")))
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub
    Public Sub DesbloquearUsuario(id As Integer)
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Using tx As MySqlTransaction = cn.BeginTransaction()
                Try
                    Controle(cn, tx)
                    Dim ator As UsuarioAutenticado = ValidarDentro(cn, tx, True)
                    Dim alvo As DataTable = Ler(cn, tx, "SELECT login FROM sis_usuarios WHERE id=@id FOR UPDATE", "@id", id)
                    If alvo.Rows.Count <> 1 Then Throw New InvalidOperationException("Selecione um usuário.")
                    Executar(cn, tx, "UPDATE sis_usuarios SET falhas=0,bloqueado_ate=NULL WHERE id=@id", "@id", id)
                    Evento(cn, tx, id, ator.Id, Convert.ToString(alvo.Rows(0)(0), CultureInfo.InvariantCulture), "USUARIO_DESBLOQUEADO")
                    tx.Commit()
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub
    Public Function AlterarSenha(atual As String, nova As String) As UsuarioAutenticado
        ValidarSenha(nova)
        If nova = atual Then Throw New ArgumentException("A nova senha deve ser diferente da atual.")
        If atual Is Nothing OrElse atual.Length > 128 Then Throw New ArgumentException("Confira a senha atual.")
        Dim salt As Byte() = SaltAleatorio(), hash As Byte() = Derivar(nova, salt, Iteracoes)
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Using tx As MySqlTransaction = cn.BeginTransaction()
                Try
                    Controle(cn, tx)
                    Dim usuario As UsuarioAutenticado = ValidarDentro(cn, tx, False, True)
                    Dim row As DataRow = Ler(cn, tx, "SELECT *,UTC_TIMESTAMP() AS agora_utc FROM sis_usuarios WHERE id=@id FOR UPDATE", "@id", usuario.Id).Rows(0)
                    If Not row.IsNull("bloqueado_ate") AndAlso Convert.ToDateTime(row("bloqueado_ate")) > Convert.ToDateTime(row("agora_utc")) Then Throw New ArgumentException(MensagemLogin)
                    Dim confere As Byte() = Derivar(atual, DirectCast(row("senha_salt"), Byte()), Convert.ToInt32(row("senha_iteracoes")))
                    Dim valida As Boolean = Iguais(confere, DirectCast(row("senha_hash"), Byte()))
                    Array.Clear(confere, 0, confere.Length)
                    If Not valida Then
                        Dim falhas As Integer = Convert.ToInt32(row("falhas")) + 1
                        If falhas >= 5 Then
                            Executar(cn, tx, "UPDATE sis_usuarios SET falhas=0,bloqueado_ate=DATE_ADD(UTC_TIMESTAMP(),INTERVAL 15 MINUTE) WHERE id=@id", "@id", usuario.Id)
                        Else
                            Executar(cn, tx, "UPDATE sis_usuarios SET falhas=@f WHERE id=@id", "@f", falhas, "@id", usuario.Id)
                        End If
                        Evento(cn, tx, usuario.Id, usuario.Id, usuario.Login, "TROCA_SENHA_FALHOU")
                        tx.Commit()
                        Throw New SenhaAtualIncorretaException("Senha atual incorreta. Após cinco falhas o acesso é bloqueado por 15 minutos.")
                    End If
                    Executar(cn, tx, "UPDATE sis_usuarios SET senha_hash=@h,senha_salt=@s,senha_iteracoes=@i,trocar_senha=0,falhas=0,bloqueado_ate=NULL,versao_acesso=versao_acesso+1 WHERE id=@id", "@h", hash, "@s", salt, "@i", Iteracoes, "@id", usuario.Id)
                    Dim novo As New UsuarioAutenticado(Ler(cn, tx, "SELECT * FROM sis_usuarios WHERE id=@id", "@id", usuario.Id).Rows(0))
                    Evento(cn, tx, usuario.Id, usuario.Id, usuario.Login, "SENHA_ALTERADA")
                    tx.Commit()
                    Return novo
                Catch ex As SenhaAtualIncorretaException
                    Throw
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function
    Private NotInheritable Class SenhaAtualIncorretaException
        Inherits ArgumentException
        Public Sub New(mensagem As String)
            MyBase.New(mensagem)
        End Sub
    End Class
End Module
