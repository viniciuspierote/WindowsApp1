Option Strict On
Option Explicit On
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms
Public Class frmPrimeiroAcesso
    Private _ocupado As Boolean
    Public Property LoginCriado As String
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Async Sub Criar(sender As Object, e As EventArgs) Handles btnCriar.Click
        If _ocupado Then Return
        If txtSenha.Text <> txtConfirmacao.Text Then
            MessageBox.Show("A confirmação de senha não confere.", "Primeiro acesso")
            Return
        End If
        Dim nome As String = txtNome.Text, login As String = txtLogin.Text, senha As String = txtSenha.Text
        _ocupado = True
        btnCriar.Enabled = False
        btnCancelar.Enabled = False
        UseWaitCursor = True
        Try
            Await Task.Run(Sub() Autenticacao.CriarPrimeiroAdministrador(nome, login, senha))
            LoginCriado = login.Trim().ToLowerInvariant()
            txtSenha.Clear()
            txtConfirmacao.Clear()
            MessageBox.Show("Administrador criado. Entre com a senha que você definiu.", "Primeiro acesso")
            _ocupado = False
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Primeiro acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            senha = Nothing
            _ocupado = False
            If Not IsDisposed Then
                btnCriar.Enabled = True
                btnCancelar.Enabled = True
                UseWaitCursor = False
            End If
        End Try
    End Sub
    Private Sub Fechando(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _ocupado Then e.Cancel = True
    End Sub
End Class
