Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports MySql.Data.MySqlClient

Public Module BackupBanco

    Public Const PastaBackups As String = "C:\Backups\Certificados"
    Private Const ExecutavelDump As String = "C:\xampp\mysql\bin\mysqldump.exe"
    Private Const NomeBanco As String = "novo_bd"
    Private Const LimiteMinutos As Integer = 30

    Public ReadOnly Property PastaHistorico As String
        Get
            Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                "Sandinox", "Certificados", "HistoricoBackups")
        End Get
    End Property

    ' Executar em Task.Run. Não acessa controles de formulário.
    Public Function ExecutarBackup(Optional adicional As Boolean = False) As String
        Using trava As New Mutex(False, "Local\SandinoxBackupNovoBd")
            Dim obtida As Boolean = False
            Try
                Try
                    obtida = trava.WaitOne(0)
                Catch ex As AbandonedMutexException
                    obtida = True
                End Try
                If Not obtida Then Return "Já existe um backup em execução nesta sessão do Windows."
                Return ExecutarComTrava(adicional)
            Finally
                If obtida Then trava.ReleaseMutex()
            End Try
        End Using
    End Function

    Private Function ExecutarComTrava(adicional As Boolean) As String
        Directory.CreateDirectory(PastaHistorico)
        Dim inicio As DateTime = DateTime.Now
        Dim identificador As String = Guid.NewGuid().ToString("N")
        Dim caminhoRegistro As String = Path.Combine(PastaHistorico, inicio.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) & "_" & identificador & ".xml")
        Dim parcial As String = String.Empty
        Dim arquivo As String = String.Empty
        Dim credencial As String = String.Empty
        Dim senha As String = String.Empty
        Dim arquivoFinalizado As Boolean = False
        Dim registro As New XDocument(New XElement("Backup",
            New XElement("Inicio", inicio.ToString("o", CultureInfo.InvariantCulture)),
            New XElement("Fim", String.Empty),
            New XElement("Dia", inicio.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
            New XElement("Tipo", If(adicional, "Adicional", "Automático")),
            New XElement("Banco", NomeBanco),
            New XElement("Fonte", String.Empty),
            New XElement("Status", "Iniciado / sem conclusão"),
            New XElement("Arquivo", String.Empty),
            New XElement("Tamanho", 0),
            New XElement("SHA256", String.Empty),
            New XElement("Mensagem", String.Empty)))
        Dim raiz As XElement = registro.Root
        If raiz Is Nothing Then Throw New InvalidDataException("Não foi possível criar o registro do backup.")
        SalvarRegistro(caminhoRegistro, registro)

        Try
            Dim dados As MySqlConnectionStringBuilder
            Using cn As MySqlConnection = conexao.NovaConexao()
                dados = New MySqlConnectionStringBuilder(cn.ConnectionString)
            End Using
            ' O escopo deste backup é sempre novo_bd.
            dados.Database = NomeBanco
            senha = dados.Password
            Dim fonte As String = dados.Server.Trim().ToLowerInvariant() & ":" & dados.Port.ToString(CultureInfo.InvariantCulture) & "/" & NomeBanco
            raiz.Element("Fonte").Value = fonte

            If Not adicional AndAlso ExisteBackupHoje(fonte, inicio.Date) Then
                ' Nenhuma exportação foi iniciada: não cria outra linha no histórico.
                File.Delete(caminhoRegistro)
                Return "O backup diário já está concluído e o arquivo foi conferido."
            End If
            SalvarRegistro(caminhoRegistro, registro)
            If Not File.Exists(ExecutavelDump) Then Throw New FileNotFoundException("Ferramenta de backup não encontrada.", ExecutavelDump)
            Directory.CreateDirectory(PastaBackups)

            Dim nome As String = NomeBanco & "_" & inicio.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) &
                "_" & If(adicional, "adicional", "automatico") & "_" & identificador.Substring(0, 8) & ".sql"
            arquivo = Path.Combine(PastaBackups, nome)
            parcial = arquivo & ".parcial"
            raiz.Element("Arquivo").Value = arquivo
            SalvarRegistro(caminhoRegistro, registro)

            credencial = Path.Combine(PastaHistorico, identificador & ".cnf")
            CriarCredencialPrivada(credencial, dados)
            Dim argumentos As String = "--defaults-file=" & EntreAspas(credencial) &
                " --protocol=tcp --default-character-set=utf8mb4 --quick --lock-tables" &
                " --routines --events --triggers --hex-blob --comments --dump-date" &
                " --databases " & NomeBanco & " --result-file=" & EntreAspas(parcial)

            Dim info As New ProcessStartInfo(ExecutavelDump, argumentos)
            info.UseShellExecute = False
            info.CreateNoWindow = True
            info.RedirectStandardError = True
            info.WorkingDirectory = Path.GetDirectoryName(ExecutavelDump)

            Using processo As New Process()
                processo.StartInfo = info
                If Not processo.Start() Then Throw New IOException("Não foi possível iniciar a exportação.")
                Dim leituraErro = processo.StandardError.ReadToEndAsync()
                If Not processo.WaitForExit(LimiteMinutos * 60 * 1000) Then
                    processo.Kill()
                    processo.WaitForExit()
                    Throw New TimeoutException("O backup ultrapassou " & LimiteMinutos.ToString(CultureInfo.InvariantCulture) & " minutos e foi interrompido.")
                End If
                Dim erro As String = leituraErro.GetAwaiter().GetResult()
                If processo.ExitCode <> 0 Then
                    Throw New IOException("A ferramenta terminou com código " & processo.ExitCode.ToString(CultureInfo.InvariantCulture) & ". " & erro)
                End If
                If Not String.IsNullOrWhiteSpace(erro) Then raiz.Element("Mensagem").Value = "Avisos da ferramenta: " & SemSenha(erro, senha)
            End Using

            ValidarArquivoGerado(parcial)
            File.Move(parcial, arquivo)
            arquivoFinalizado = True
            raiz.Element("Tamanho").Value = New FileInfo(arquivo).Length.ToString(CultureInfo.InvariantCulture)
            raiz.Element("SHA256").Value = CalcularHash(arquivo)
            raiz.Element("Status").Value = "Concluído"
            raiz.Element("Fim").Value = DateTime.Now.ToString("o", CultureInfo.InvariantCulture)
            SalvarRegistro(caminhoRegistro, registro)
            Return "Backup concluído: " & arquivo

        Catch ex As Exception
            raiz.Element("Status").Value = If(arquivoFinalizado, "Arquivo gerado / validação pendente", "Falhou")
            raiz.Element("Fim").Value = DateTime.Now.ToString("o", CultureInfo.InvariantCulture)
            raiz.Element("Mensagem").Value = SemSenha(ex.Message, senha)
            Try
                SalvarRegistro(caminhoRegistro, registro)
            Catch exRegistro As Exception
                Throw New IOException("O backup não foi confirmado e também houve falha ao registrar o resultado. " & exRegistro.Message,
                                      New Exception(SemSenha(ex.Message, senha)))
            End Try
            Throw New IOException("O backup não foi confirmado. Consulte o histórico. " & SemSenha(ex.Message, senha))
        Finally
            ' Arquivos .parcial nunca são considerados backups concluídos.
            ApagarTemporario(credencial, raiz, caminhoRegistro, registro)
            ApagarTemporario(parcial, raiz, caminhoRegistro, registro)
        End Try
    End Function

    Private Sub CriarCredencialPrivada(caminho As String, dados As MySqlConnectionStringBuilder)
        Dim seguranca As New FileSecurity()
        seguranca.SetAccessRuleProtection(True, False)
        Using identidade As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim usuario As SecurityIdentifier = identidade.User
            If usuario Is Nothing Then Throw New IOException("Não foi possível identificar o usuário do Windows.")
            seguranca.SetOwner(usuario)
            seguranca.AddAccessRule(New FileSystemAccessRule(usuario, FileSystemRights.FullControl, AccessControlType.Allow))
        End Using
        Using fluxo As New FileStream(caminho, FileMode.CreateNew, FileSystemRights.Write,
                                       FileShare.None, 4096, FileOptions.None, seguranca)
            Using escritor As New StreamWriter(fluxo, New UTF8Encoding(False))
                escritor.WriteLine("[client]")
                escritor.WriteLine("host=" & ValorOpcao(dados.Server))
                escritor.WriteLine("port=" & dados.Port.ToString(CultureInfo.InvariantCulture))
                escritor.WriteLine("user=" & ValorOpcao(dados.UserID))
                escritor.WriteLine("password=" & ValorOpcao(dados.Password))
            End Using
        End Using
    End Sub

    Private Function ValorOpcao(valor As String) As String
        Dim aspas As String = ChrW(34).ToString()
        Dim barra As String = ChrW(92).ToString()
        Return aspas & valor.Replace(barra, barra & barra).Replace(aspas, barra & aspas).
            Replace(vbCr, barra & "r").Replace(vbLf, barra & "n").Replace(vbTab, barra & "t") & aspas
    End Function

    Private Function EntreAspas(valor As String) As String
        Return ChrW(34).ToString() & valor & ChrW(34).ToString()
    End Function

    Private Function SemSenha(texto As String, senha As String) As String
        If String.IsNullOrEmpty(senha) Then Return texto
        Return texto.Replace(senha, "[senha ocultada]")
    End Function

    Private Sub ValidarArquivoGerado(caminho As String)
        If Not File.Exists(caminho) OrElse New FileInfo(caminho).Length = 0 Then
            Throw New InvalidDataException("A ferramenta não gerou um arquivo SQL com conteúdo.")
        End If
        Using fluxo As New FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.Read)
            fluxo.Seek(Math.Max(0L, fluxo.Length - 8192L), SeekOrigin.Begin)
            Using leitor As New StreamReader(fluxo, Encoding.UTF8)
                If Not leitor.ReadToEnd().Contains("-- Dump completed on") Then
                    Throw New InvalidDataException("O arquivo não contém a indicação final de conclusão da exportação.")
                End If
            End Using
        End Using
    End Sub

    Private Function CalcularHash(caminho As String) As String
        Using fluxo As FileStream = File.OpenRead(caminho)
            Using hash As SHA256 = SHA256.Create()
                Return BitConverter.ToString(hash.ComputeHash(fluxo)).Replace("-", String.Empty)
            End Using
        End Using
    End Function

    Private Function ExisteBackupHoje(fonte As String, dia As DateTime) As Boolean
        For Each caminho As String In Directory.GetFiles(PastaHistorico, "*.xml")
            Dim registro As XDocument
            Try
                registro = XDocument.Load(caminho)
                Dim raiz As XElement = registro.Root
                If raiz Is Nothing Then Continue For
                If raiz.Element("Status").Value <> "Concluído" OrElse
                    raiz.Element("Fonte").Value <> fonte OrElse
                    raiz.Element("Dia").Value <> dia.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) Then Continue For
                Dim arquivo As String = raiz.Element("Arquivo").Value
                Dim tamanho As Long = Long.Parse(raiz.Element("Tamanho").Value, CultureInfo.InvariantCulture)
                If File.Exists(arquivo) AndAlso tamanho > 0 AndAlso New FileInfo(arquivo).Length = tamanho AndAlso
                    CalcularHash(arquivo) = raiz.Element("SHA256").Value Then Return True
            Catch ex As Exception
                ' Registro ilegível/arquivo indisponível não comprova um backup diário.
                Continue For
            End Try
        Next
        Return False
    End Function

    Private Sub SalvarRegistro(caminho As String, documento As XDocument)
        Dim temporario As String = caminho & "." & Guid.NewGuid().ToString("N") & ".tmp"
        Try
            documento.Save(temporario)
            If File.Exists(caminho) Then
                File.Replace(temporario, caminho, Nothing)
            Else
                File.Move(temporario, caminho)
            End If
        Finally
            If File.Exists(temporario) Then File.Delete(temporario)
        End Try
    End Sub

    Private Sub ApagarTemporario(caminho As String, raiz As XElement, caminhoRegistro As String, registro As XDocument)
        If String.IsNullOrEmpty(caminho) Then Return
        Try
            If File.Exists(caminho) Then File.Delete(caminho)
        Catch ex As Exception
            raiz.Element("Mensagem").Value &= " | Não foi possível remover o temporário: " & caminho
            ' Tenta preservar o aviso; uma falha aqui não apaga o resultado anterior.
            Try
                SalvarRegistro(caminhoRegistro, registro)
            Catch exRegistro As Exception
                Trace.TraceError("Não foi possível registrar a limpeza pendente do backup.")
            End Try
        End Try
    End Sub

    Public Function LerHistorico() As DataTable
        Dim tabela As New DataTable()
        tabela.Columns.Add("Início", GetType(DateTime))
        tabela.Columns.Add("Fim", GetType(String))
        tabela.Columns.Add("Tipo", GetType(String))
        tabela.Columns.Add("Servidor", GetType(String))
        tabela.Columns.Add("Banco", GetType(String))
        tabela.Columns.Add("Status", GetType(String))
        tabela.Columns.Add("Tamanho (bytes)", GetType(Long))
        tabela.Columns.Add("Arquivo", GetType(String))
        tabela.Columns.Add("Mensagem", GetType(String))
        If Not Directory.Exists(PastaHistorico) Then Return tabela
        For Each caminho As String In Directory.GetFiles(PastaHistorico, "*.xml")
            Try
                Dim raiz As XElement = XDocument.Load(caminho).Root
                If raiz Is Nothing Then Throw New InvalidDataException("Registro sem conteúdo.")
                tabela.Rows.Add(DateTime.Parse(raiz.Element("Inicio").Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    raiz.Element("Fim").Value, raiz.Element("Tipo").Value, raiz.Element("Fonte").Value,
                    raiz.Element("Banco").Value, raiz.Element("Status").Value,
                    Long.Parse(raiz.Element("Tamanho").Value, CultureInfo.InvariantCulture),
                    raiz.Element("Arquivo").Value, raiz.Element("Mensagem").Value)
            Catch ex As Exception
                tabela.Rows.Add(File.GetLastWriteTime(caminho), String.Empty, String.Empty, String.Empty, NomeBanco,
                    "Registro ilegível", 0L, caminho, ex.Message)
            End Try
        Next
        tabela.DefaultView.Sort = "Início DESC"
        Return tabela.DefaultView.ToTable()
    End Function

    Public Sub MostrarHistorico(dono As IWin32Window)
        Using janela As New frmHistoricoBackups()
            janela.ShowDialog(dono)
        End Using
    End Sub
End Module
