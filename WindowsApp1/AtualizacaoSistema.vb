Option Strict On
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Module AtualizacaoSistema

    Private Const PastaAtualizacoes As String =
        "\\titanio\Sandinox\Atualizacoes\Certificados"

    Private Const NomeInstalador As String =
        "Setup_Certificado_Sandinox.exe"

    Public Async Function VerificarAsync(
        janela As IWin32Window
    ) As Task(Of Boolean)

        Try
            Dim caminhoVersao As String =
                Path.Combine(PastaAtualizacoes, "versao.txt")

            Dim consulta As Task(Of String()) =
                Task.Run(
                    Function() As String()
                        If Not File.Exists(caminhoVersao) Then Return Nothing

                        If New FileInfo(caminhoVersao).Length > 2048 Then
                            Throw New IOException(
                                "O arquivo de versão está inválido.")
                        End If

                        Return File.ReadAllLines(caminhoVersao)
                    End Function)

            ' Não mantém o login esperando pela rede indefinidamente.
            Dim concluida As Task =
                Await Task.WhenAny(consulta, Task.Delay(8000))

            If concluida IsNot consulta Then
                Trace.TraceWarning(
                    "A consulta de atualização excedeu o tempo limite.")
                Return False
            End If

            Dim linhas As String() = Await consulta

            ' Nenhuma atualização foi publicada ainda.
            If linhas Is Nothing Then Return False

            If linhas.Length <> 2 Then
                Throw New IOException(
                    "O arquivo versao.txt deve conter duas linhas.")
            End If

            Dim novaVersao As Version = Nothing

            If Not Version.TryParse(linhas(0).Trim(), novaVersao) Then
                Throw New IOException("O número da versão está inválido.")
            End If

            Dim hashEsperado As String = linhas(1).Trim()

            If hashEsperado.Length <> 64 OrElse
                Not System.Text.RegularExpressions.Regex.IsMatch(
                    hashEsperado, "\A[0-9a-fA-F]{64}\z") Then

                Throw New IOException(
                    "O código de integridade do instalador está inválido.")
            End If

            Dim versaoAtual As Version =
                Assembly.GetExecutingAssembly().GetName().Version

            If novaVersao.CompareTo(versaoAtual) <= 0 Then Return False

            Dim resposta As DialogResult =
                MessageBox.Show(
                    janela,
                    "Existe uma atualização disponível." & vbCrLf &
                    "Versão instalada: " & versaoAtual.ToString() & vbCrLf &
                    "Nova versão: " & novaVersao.ToString() & vbCrLf &
                    vbCrLf &
                    "Deseja instalar agora?" & vbCrLf &
                    "O programa será fechado para a instalação.",
                    "Atualização do sistema",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information)

            If resposta <> DialogResult.Yes Then Return False

            Dim instaladorLocal As String =
                Await Task.Run(
                    Function() As String
                        Return PrepararInstalador(hashEsperado)
                    End Function)

            Dim inicio As New ProcessStartInfo With {
                .FileName = instaladorLocal,
                .WorkingDirectory = Path.GetDirectoryName(instaladorLocal),
                .UseShellExecute = True
            }

            Using processo As Process = Process.Start(inicio)
                If processo Is Nothing Then
                    Throw New IOException(
                        "Não foi possível iniciar o instalador.")
                End If
            End Using

            Return True

        Catch ex As Exception
            MessageBox.Show(
                janela,
                "Não foi possível iniciar a atualização." & vbCrLf &
                ex.Message & vbCrLf & vbCrLf &
                "O sistema continuará com a versão instalada.",
                "Atualização do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return False
        End Try
    End Function

    Private Function PrepararInstalador(
        hashEsperado As String
    ) As String

        Dim origem As String =
            Path.Combine(PastaAtualizacoes, NomeInstalador)

        Dim pastaLocal As String =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "Sandinox",
                "Certificados",
                "Atualizacoes",
                Guid.NewGuid().ToString("N"))

        Directory.CreateDirectory(pastaLocal)

        Dim destino As String =
            Path.Combine(pastaLocal, NomeInstalador)

        Try
            File.Copy(origem, destino, False)

            Dim hashCalculado As String

            Using arquivo As FileStream = File.OpenRead(destino)
                Using algoritmo As SHA256 = SHA256.Create()
                    hashCalculado =
                        BitConverter.ToString(
                            algoritmo.ComputeHash(arquivo)).Replace("-", "")
                End Using
            End Using

            If Not String.Equals(
                hashCalculado,
                hashEsperado,
                StringComparison.OrdinalIgnoreCase) Then

                Throw New IOException(
                    "O instalador não passou na verificação de integridade.")
            End If

            Return destino

        Catch
            Try
                If File.Exists(destino) Then File.Delete(destino)
            Catch
                ' Preserva o erro original.
            End Try

            Throw
        End Try
    End Function

End Module