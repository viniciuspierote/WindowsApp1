Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Module conexao

    Public Function MontarStringConexao(
        servidor As String,
        porta As UInteger,
        banco As String,
        usuario As String,
        senha As String) As String

        If String.IsNullOrWhiteSpace(servidor) Then
            Throw New ArgumentException("Informe o servidor.")
        End If

        If porta < 1 OrElse porta > 65535 Then
            Throw New ArgumentException("Informe uma porta entre 1 e 65535.")
        End If

        If String.IsNullOrWhiteSpace(banco) Then
            Throw New ArgumentException("Informe o banco de dados.")
        End If

        If String.IsNullOrWhiteSpace(usuario) Then
            Throw New ArgumentException("Informe o usuário.")
        End If

        Dim builder As New MySqlConnectionStringBuilder()

        builder.Server = servidor.Trim()
        builder.Port = porta
        builder.Database = banco.Trim()
        builder.UserID = usuario.Trim()
        builder.Password = senha
        builder.ConnectionTimeout = 5
        builder.PersistSecurityInfo = False

        Return builder.ConnectionString

    End Function

    Public Function ProtegerSenha(senha As String) As String

        If String.IsNullOrEmpty(senha) Then Return String.Empty

        Dim dados = Encoding.UTF8.GetBytes(senha)

        Dim protegidos = ProtectedData.Protect(
            dados,
            Nothing,
            DataProtectionScope.CurrentUser)

        Return Convert.ToBase64String(protegidos)

    End Function

    Public Function RecuperarSenha() As String

        Dim texto = My.Settings.MysqlSenhaProtegida

        If String.IsNullOrEmpty(texto) Then Return String.Empty

        Dim protegidos = Convert.FromBase64String(texto)

        Dim dados = ProtectedData.Unprotect(
            protegidos,
            Nothing,
            DataProtectionScope.CurrentUser)

        Return Encoding.UTF8.GetString(dados)

    End Function

    Public Function NovaConexao() As MySqlConnection

        Dim stringConexao = MontarStringConexao(
            My.Settings.MysqlServidor,
            CUInt(My.Settings.MysqlPorta),
            My.Settings.MysqlBanco,
            My.Settings.MysqlUsuario,
            RecuperarSenha())

        Return New MySqlConnection(stringConexao)

    End Function

End Module
