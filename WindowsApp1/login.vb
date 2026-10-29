Option Strict On
Option Explicit On
Imports System
Imports System.ComponentModel
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class frmlogin
    Public nomeusuario As String
    Private _ocupado As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Function EmDesigner() As Boolean
        Return DesignMode OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime
    End Function
    Private Sub LoginCarregado(sender As Object, e As EventArgs) Handles MyBase.Load
        If EmDesigner() Then Return
        SessaoAtual.Encerrar()
        AcceptButton = Button1
        txtusuario.MaxLength = 60
        txtsenha.MaxLength = 128
        txtsenha.UseSystemPasswordChar = True
        txtusuario.TabIndex = 0
        txtsenha.TabIndex = 1
        Button1.TabIndex = 2
        lblStatusLogin.Text = "Informe seu usuário e senha. No primeiro acesso, configure o administrador."
    End Sub
    Private Sub Ocupado(valor As Boolean)
        _ocupado = valor
        Button1.Enabled = Not valor
        btnPrimeiroAdministrador.Enabled = Not valor
        btnBancoLogin.Enabled = Not valor
        txtusuario.Enabled = Not valor
        txtsenha.Enabled = Not valor
        btnsair.Enabled = Not valor
        UseWaitCursor = valor
    End Sub
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _ocupado Then Return
        Dim loginInformado As String = txtusuario.Text.Trim()
        Dim senha As String = txtsenha.Text
        If loginInformado = "" OrElse senha = "" Then
            MessageBox.Show("Preencha usuário e senha.", "Entrar")
            Return
        End If
        Ocupado(True)
        Try
            If Await Task.Run(Function() Autenticacao.PrecisaPrimeiroAdministrador()) Then
                MessageBox.Show("Clique em Primeiro acesso para criar o administrador. Não existe senha padrão.", "Primeiro acesso")
                Return
            End If
            Dim usuario As UsuarioAutenticado = Await Task.Run(Function() Autenticacao.Entrar(loginInformado, senha))
            SessaoAtual.Iniciar(usuario)
            txtsenha.Clear()
            nomeusuario = usuario.Login
            If usuario.TrocarSenha Then
                Using troca As New frmAlterarSenha()
                    If troca.ShowDialog(Me) <> DialogResult.OK Then
                        SessaoAtual.Encerrar()
                        nomeusuario = ""
                        Return
                    End If
                End Using
            End If
            Ocupado(False)
            Hide()
            Try
                Using principal As New frm_principal()
                    principal.ShowDialog()
                End Using
            Finally
                SessaoAtual.Encerrar()
                nomeusuario = ""
                If Not IsDisposed Then
                    Show()
                    Activate()
                    txtsenha.Clear()
                    txtsenha.Focus()
                    lblStatusLogin.Text = "Sessão encerrada. Informe seu usuário e senha para entrar novamente."
                End If
            End Try
        Catch ex As Exception
            SessaoAtual.Encerrar()
            nomeusuario = ""
            txtsenha.Clear()
            MessageBox.Show("Não foi possível entrar." & vbCrLf & ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            senha = Nothing
            If Not IsDisposed Then Ocupado(False)
        End Try
    End Sub
    Private Sub btnsair_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        If Not _ocupado Then Close()
    End Sub
    Private Sub ConfigurarBanco(sender As Object, e As EventArgs) Handles btnBancoLogin.Click
        If _ocupado Then Return
        Try
            Using janela As New frmConfiguracoes()
                janela.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Configuração do banco")
        End Try
    End Sub
    Private Async Sub PrimeiroAdministrador(sender As Object, e As EventArgs) Handles btnPrimeiroAdministrador.Click
        If _ocupado Then Return
        Ocupado(True)
        Try
            Dim primeiro As Boolean = Await Task.Run(Function() Autenticacao.PrecisaPrimeiroAdministrador())
            If Not primeiro Then
                MessageBox.Show("O administrador já foi configurado. Entre com o usuário e senha. Se esqueceu a senha, procure outro administrador ou a TI.", "Primeiro acesso")
                Return
            End If
            Ocupado(False)
            Using janela As New frmPrimeiroAcesso()
                If janela.ShowDialog(Me) = DialogResult.OK Then
                    txtusuario.Text = janela.LoginCriado
                    txtsenha.Clear()
                    txtsenha.Focus()
                    lblStatusLogin.Text = "Administrador criado. Entre com a senha que você definiu."
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Não foi possível configurar o primeiro acesso. Confira a conexão e o SQL 007." & vbCrLf & ex.Message, "Primeiro acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If Not IsDisposed Then Ocupado(False)
        End Try
    End Sub
    Private Sub AoFecharLogin(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _ocupado Then
            e.Cancel = True
            MessageBox.Show("Aguarde a operação de acesso terminar.", "Login")
        End If
    End Sub
End Class
