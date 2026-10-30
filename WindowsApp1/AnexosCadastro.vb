Option Explicit On
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports MySql.Data.MySqlClient

Partial Public Class frmcadastro

    Private Const LimitePdf As Integer = 10 * 1024 * 1024

    Private Class DocumentoPdf
        Public Tipo As String
        Public Nome As String = ""
        Public Conteudo As Byte()
        Public Hash As String = ""

        Public NomeSalvo As String = ""
        Public ConteudoSalvo As Byte()
        Public HashSalvo As String = ""

        Public Alterado As Boolean
        Public VersaoVisual As Integer
    End Class

    Private ReadOnly _pdfOrigem As New DocumentoPdf With {
        .Tipo = "ORIGEM"
    }

    Private ReadOnly _pdfAnalise As New DocumentoPdf With {
        .Tipo = "ANALISE"
    }

    Private _cadastroDosAnexos As Integer
    Private _anexosDisponiveis As Boolean
    Private _pdfFechado As Boolean
    Private _ambientePdf As Task(Of CoreWebView2Environment)

    Private ReadOnly _pastaTemporariaPdf As String =
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "Sandinox", "Certificados", "PdfTemporarios",
            Guid.NewGuid().ToString("N"))

    Private Function DocumentosPdf() As DocumentoPdf()
        Return New DocumentoPdf() {_pdfOrigem, _pdfAnalise}
    End Function

    Private Function VisualizadorPdf(
        documento As DocumentoPdf
    ) As WebView2

        If documento Is _pdfOrigem Then Return webPdfOrigem
        Return webPdfAnalise
    End Function

    Private Function NomeArquivoPdf(
        documento As DocumentoPdf
    ) As TextBox

        If documento Is _pdfOrigem Then Return txtArquivoOrigem
        Return txtArquivoAnalise
    End Function

    Private Function HashPdf(conteudo As Byte()) As String
        Using algoritmo As SHA256 = SHA256.Create()
            Return BitConverter.ToString(
                algoritmo.ComputeHash(conteudo)).Replace("-", "")
        End Using
    End Function

    Private Sub ValidarConteudoPdf(conteudo As Byte())
        If conteudo Is Nothing OrElse conteudo.Length < 5 Then
            Throw New InvalidDataException("O arquivo PDF está vazio ou inválido.")
        End If

        If conteudo.Length > LimitePdf Then
            Throw New InvalidDataException(
                "O PDF deve ter no máximo 10 MB.")
        End If

        If Encoding.ASCII.GetString(conteudo, 0, 5) <> "%PDF-" Then
            Throw New InvalidDataException(
                "O arquivo selecionado não possui um cabeçalho PDF válido.")
        End If
    End Sub

    Private Function CriarCopiaTemporaria(
        documento As DocumentoPdf
    ) As String

        ValidarConteudoPdf(documento.Conteudo)
        Directory.CreateDirectory(_pastaTemporariaPdf)

        Dim caminho As String = Path.Combine(
            _pastaTemporariaPdf,
            Guid.NewGuid().ToString("N") & ".pdf")

        File.WriteAllBytes(caminho, documento.Conteudo)
        Return caminho
    End Function

    Private Sub AtualizarTelaPdf(documento As DocumentoPdf)
        documento.VersaoVisual += 1

        NomeArquivoPdf(documento).ReadOnly = True
        NomeArquivoPdf(documento).Text = documento.Nome

        Dim visualizador As WebView2 = VisualizadorPdf(documento)
        visualizador.Visible = False

        If documento.Conteudo Is Nothing Then
            If visualizador.CoreWebView2 IsNot Nothing Then
                visualizador.CoreWebView2.Navigate("about:blank")
            End If
            Return
        End If

        Dim tarefa As Task = MostrarPdfAsync(
            documento, documento.VersaoVisual)
    End Sub

    Private Async Function MostrarPdfAsync(
        documento As DocumentoPdf,
        versao As Integer
    ) As Task

        Try
            Dim visualizador As WebView2 = VisualizadorPdf(documento)
            Dim caminho As String = CriarCopiaTemporaria(documento)

            If _ambientePdf Is Nothing Then
                Dim pastaPerfil As String = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "Sandinox", "Certificados", "WebView2")

                _ambientePdf = CoreWebView2Environment.CreateAsync(
                    userDataFolder:=pastaPerfil)
            End If

            Dim ambiente As CoreWebView2Environment = Await _ambientePdf

            If _pdfFechado OrElse IsDisposed OrElse
                documento.VersaoVisual <> versao Then Return

            ' Garante que o controle tenha uma janela nativa.
            Dim janela As IntPtr = visualizador.Handle

            Await visualizador.EnsureCoreWebView2Async(ambiente)

            If _pdfFechado OrElse IsDisposed OrElse
                documento.VersaoVisual <> versao Then Return

            visualizador.CoreWebView2.Navigate(
                New Uri(caminho).AbsoluteUri)

            visualizador.Visible = True

        Catch ex As Exception
            If Not _pdfFechado AndAlso Not IsDisposed AndAlso
                documento.VersaoVisual = versao Then

                MessageBox.Show(
                    "O anexo foi mantido, mas não foi possível " &
                    "exibir a prévia." & vbCrLf &
                    "Você ainda pode usar Abrir PDF." & vbCrLf &
                    ex.Message,
                    "Visualização do PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
            End If
        End Try
    End Function

    Private Function PodeAlterarPdf() As Boolean
        If Not _anexosDisponiveis Then
            MessageBox.Show(
                "Consulte o lote novamente ou clique em Inserir.",
                "Anexos")
            Return False
        End If

        If Not btnsalvar.Enabled AndAlso Not btnatualizar.Enabled Then
            MessageBox.Show(
                "Inicie um cadastro ou consulte um lote para alterar os anexos.",
                "Anexos")
            Return False
        End If

        Return True
    End Function

    Private Sub SelecionarPdf(documento As DocumentoPdf)
        If Not PodeAlterarPdf() Then Return

        Try
            SessaoAtual.ExigirAutenticado()

            Using seletor As New OpenFileDialog()
                seletor.Title = "Selecionar certificado PDF"
                seletor.Filter = "Documentos PDF (*.pdf)|*.pdf"
                seletor.Multiselect = False
                seletor.CheckFileExists = True

                If seletor.ShowDialog(Me) <> DialogResult.OK Then Return

                Dim nome As String = Path.GetFileName(seletor.FileName)

                If nome.Length > 255 Then
                    Throw New InvalidDataException(
                        "O nome do arquivo deve ter até 255 caracteres.")
                End If

                Dim conteudo As Byte()

                Using fluxo As New FileStream(
                    seletor.FileName, FileMode.Open,
                    FileAccess.Read, FileShare.Read)

                    If fluxo.Length > LimitePdf Then
                        Throw New InvalidDataException(
                            "O PDF deve ter no máximo 10 MB.")
                    End If

                    Using leitor As New BinaryReader(fluxo)
                        conteudo = leitor.ReadBytes(CInt(fluxo.Length))
                    End Using
                End Using

                ValidarConteudoPdf(conteudo)

                documento.Nome = nome
                documento.Conteudo = conteudo
                documento.Hash = HashPdf(conteudo)
                documento.Alterado = True

                AtualizarTelaPdf(documento)
            End Using

        Catch ex As Exception
            MessageBox.Show(
                ex.Message, "Anexar PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub AbrirDocumentoPdf(documento As DocumentoPdf)
        Try
            SessaoAtual.ExigirAutenticado()

            If documento.Conteudo Is Nothing Then
                MessageBox.Show("Nenhum PDF anexado.", "Anexos")
                Return
            End If

            Dim caminho As String = CriarCopiaTemporaria(documento)

            Process.Start(New ProcessStartInfo(caminho) With {
                .UseShellExecute = True
            })

        Catch ex As Exception
            MessageBox.Show(
                ex.Message, "Abrir PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub RemoverDocumentoPdf(documento As DocumentoPdf)
        If Not PodeAlterarPdf() Then Return
        If documento.Conteudo Is Nothing Then Return

        If MessageBox.Show(
            "Remover este anexo?" & vbCrLf &
            "A remoção será gravada ao clicar em Salvar ou Atualizar.",
            "Remover PDF",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        documento.Nome = ""
        documento.Conteudo = Nothing
        documento.Hash = ""
        documento.Alterado = True

        AtualizarTelaPdf(documento)
    End Sub

    Private Function ConfirmarDescarteAnexos() As Boolean
        If Not _pdfOrigem.Alterado AndAlso
            Not _pdfAnalise.Alterado Then Return True

        Return MessageBox.Show(
            "Descartar as alterações dos PDFs que ainda não foram salvas?",
            "Anexos pendentes",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    Private Sub LimparAnexosPdf(
        Optional disponiveis As Boolean = True)

        _cadastroDosAnexos = 0
        _anexosDisponiveis = disponiveis

        For Each documento As DocumentoPdf In DocumentosPdf()
            documento.Nome = ""
            documento.Conteudo = Nothing
            documento.Hash = ""
            documento.NomeSalvo = ""
            documento.ConteudoSalvo = Nothing
            documento.HashSalvo = ""
            documento.Alterado = False
            AtualizarTelaPdf(documento)
        Next
    End Sub

    Private Sub CarregarAnexosPdf(cadastroId As Integer)
        LimparAnexosPdf(False)

        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()

            Using cmd As New MySqlCommand(
                "SELECT tipo, nome_arquivo, conteudo, tamanho_bytes, sha256 " &
                "FROM cert_anexos_lote WHERE cadastro_id=@id", cn)

                cmd.Parameters.AddWithValue("@id", cadastroId)

                Using leitor As MySqlDataReader = cmd.ExecuteReader()
                    While leitor.Read()
                        Dim documento As DocumentoPdf =
                            If(leitor.GetString("tipo") = "ORIGEM",
                               _pdfOrigem, _pdfAnalise)

                        Dim conteudo As Byte() =
                            DirectCast(leitor("conteudo"), Byte())

                        ValidarConteudoPdf(conteudo)

                        Dim hash As String = HashPdf(conteudo)

                        If conteudo.LongLength <>
                            Convert.ToInt64(leitor("tamanho_bytes")) OrElse
                            Not String.Equals(
                                hash, Convert.ToString(leitor("sha256")),
                                StringComparison.OrdinalIgnoreCase) Then

                            Throw New InvalidDataException(
                                "Falha na conferência do PDF de " &
                                documento.Tipo & ".")
                        End If

                        documento.Nome = Convert.ToString(
                            leitor("nome_arquivo"))
                        documento.Conteudo = conteudo
                        documento.Hash = hash
                    End While
                End Using
            End Using
        End Using

        ConfirmarAnexosSalvos(cadastroId)

        For Each documento As DocumentoPdf In DocumentosPdf()
            AtualizarTelaPdf(documento)
        Next
    End Sub

    Private Sub GravarAnexosPdf(
        cn As MySqlConnection,
        transacao As MySqlTransaction,
        cadastroId As Integer)

        If Not _anexosDisponiveis Then
            Throw New InvalidOperationException(
                "Os anexos não foram carregados corretamente. " &
                "Consulte o lote novamente antes de salvar.")
        End If

        If _cadastroDosAnexos > 0 AndAlso
            _cadastroDosAnexos <> cadastroId Then

            Throw New InvalidOperationException(
                "Os anexos pertencem a outro cadastro. Consulte o lote novamente.")
        End If

        For Each documento As DocumentoPdf In DocumentosPdf()
            If Not documento.Alterado Then Continue For

            ' Evita sobrescrever uma alteração feita por outra pessoa.
            Using conferir As New MySqlCommand(
                "SELECT sha256 FROM cert_anexos_lote " &
                "WHERE cadastro_id=@id AND tipo=@tipo FOR UPDATE",
                cn, transacao)

                conferir.Parameters.AddWithValue("@id", cadastroId)
                conferir.Parameters.AddWithValue("@tipo", documento.Tipo)

                Dim valor As Object = conferir.ExecuteScalar()
                Dim hashBanco As String =
                    If(valor Is Nothing OrElse Convert.IsDBNull(valor),
                       "", Convert.ToString(valor))

                If Not String.Equals(
                    hashBanco, documento.HashSalvo,
                    StringComparison.OrdinalIgnoreCase) Then

                    Throw New InvalidOperationException(
                        "O PDF de " & documento.Tipo &
                        " foi alterado por outra pessoa. " &
                        "Consulte o lote novamente antes de substituí-lo.")
                End If
            End Using

            If documento.Conteudo Is Nothing Then
                Using cmd As New MySqlCommand(
                    "DELETE FROM cert_anexos_lote " &
                    "WHERE cadastro_id=@id AND tipo=@tipo",
                    cn, transacao)

                    cmd.Parameters.AddWithValue("@id", cadastroId)
                    cmd.Parameters.AddWithValue("@tipo", documento.Tipo)
                    cmd.ExecuteNonQuery()
                End Using
            Else
                ValidarConteudoPdf(documento.Conteudo)

                Using cmd As New MySqlCommand(
                    "INSERT INTO cert_anexos_lote " &
                    "(cadastro_id,tipo,nome_arquivo,conteudo,tamanho_bytes," &
                    "sha256,atualizado_por,atualizado_em) " &
                    "VALUES(@id,@tipo,@nome,@pdf,@tamanho,@hash,@usuario," &
                    "UTC_TIMESTAMP()) " &
                    "ON DUPLICATE KEY UPDATE " &
                    "nome_arquivo=VALUES(nome_arquivo), " &
                    "conteudo=VALUES(conteudo), " &
                    "tamanho_bytes=VALUES(tamanho_bytes), " &
                    "sha256=VALUES(sha256), " &
                    "atualizado_por=VALUES(atualizado_por), " &
                    "atualizado_em=VALUES(atualizado_em)",
                    cn, transacao)

                    cmd.Parameters.AddWithValue("@id", cadastroId)
                    cmd.Parameters.AddWithValue("@tipo", documento.Tipo)
                    cmd.Parameters.AddWithValue("@nome", documento.Nome)

                    cmd.Parameters.Add(
                        "@pdf", MySqlDbType.LongBlob).Value =
                        documento.Conteudo

                    cmd.Parameters.AddWithValue(
                        "@tamanho", documento.Conteudo.LongLength)
                    cmd.Parameters.AddWithValue("@hash", documento.Hash)
                    cmd.Parameters.AddWithValue("@usuario", SessaoAtual.Login)

                    cmd.ExecuteNonQuery()
                End Using
            End If
        Next
    End Sub

    Private Sub ConfirmarAnexosSalvos(cadastroId As Integer)
        _cadastroDosAnexos = cadastroId
        _anexosDisponiveis = True

        For Each documento As DocumentoPdf In DocumentosPdf()
            documento.NomeSalvo = documento.Nome
            documento.ConteudoSalvo = documento.Conteudo
            documento.HashSalvo = documento.Hash
            documento.Alterado = False
        Next
    End Sub

    Private Sub AnexarOrigemPdf(
        sender As Object, e As EventArgs
    ) Handles btnAnexarOrigem.Click

        SelecionarPdf(_pdfOrigem)
    End Sub

    Private Sub AnexarAnalisePdf(
        sender As Object, e As EventArgs
    ) Handles btnAnexarAnalise.Click

        SelecionarPdf(_pdfAnalise)
    End Sub

    Private Sub AbrirOrigemPdf(
        sender As Object, e As EventArgs
    ) Handles btnAbrirOrigem.Click

        AbrirDocumentoPdf(_pdfOrigem)
    End Sub

    Private Sub AbrirAnalisePdf(
        sender As Object, e As EventArgs
    ) Handles btnAbrirAnalise.Click

        AbrirDocumentoPdf(_pdfAnalise)
    End Sub

    Private Sub RemoverOrigemPdf(
        sender As Object, e As EventArgs
    ) Handles btnRemoverOrigem.Click

        RemoverDocumentoPdf(_pdfOrigem)
    End Sub

    Private Sub RemoverAnalisePdf(
        sender As Object, e As EventArgs
    ) Handles btnRemoverAnalise.Click

        RemoverDocumentoPdf(_pdfAnalise)
    End Sub

    Private Sub CancelarAlteracoesPdf(
        sender As Object, e As EventArgs
    ) Handles btncancelar.Click

        If Not ConfirmarDescarteAnexos() Then Return

        For Each documento As DocumentoPdf In DocumentosPdf()
            documento.Nome = documento.NomeSalvo
            documento.Conteudo = documento.ConteudoSalvo
            documento.Hash = documento.HashSalvo
            documento.Alterado = False
            AtualizarTelaPdf(documento)
        Next
    End Sub

    Private Sub ConferirPdfAoFechar(
        sender As Object, e As FormClosingEventArgs
    ) Handles MyBase.FormClosing

        If e.Cancel Then Return
        If Not ConfirmarDescarteAnexos() Then e.Cancel = True
    End Sub

    Private Sub EncerrarVisualizadoresPdf(
        sender As Object, e As FormClosedEventArgs
    ) Handles MyBase.FormClosed

        _pdfFechado = True
        webPdfOrigem.Dispose()
        webPdfAnalise.Dispose()

        Try
            If Directory.Exists(_pastaTemporariaPdf) Then
                Directory.Delete(_pastaTemporariaPdf, True)
            End If
        Catch ex As IOException
            Trace.TraceWarning(
                "Uma cópia temporária de PDF permanece em uso.")
        Catch ex As UnauthorizedAccessException
            Trace.TraceWarning(
                "Não foi possível limpar a pasta temporária de PDFs.")
        End Try
    End Sub

End Class