Option Strict On
Option Explicit On
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms
Public Class frmAlterarSenha
    Private _ocupado As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Carregar(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        If SessaoAtual.Usuario Is Nothing Then
            MessageBox.Show("Entre no sistema para alterar a senha.", "Senha")
            Close()
            Return
        End If
        lblOrientacao.Text = If(SessaoAtual.Usuario.TrocarSenha, "Troca obrigatória antes de abrir o sistema. Use de 15 a 128 caracteres.", "Use de 15 a 128 caracteres. A senha atual é necessária para confirmar a troca.")
    End Sub
    Private Async Sub Salvar(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If _ocupado Then Return
        If txtNovaSenha.Text <> txtConfirmacao.Text Then
            MessageBox.Show("A confirmação da nova senha não confere.", "Senha")
            Return
        End If
        Dim atual As String = txtSenhaAtual.Text, nova As String = txtNovaSenha.Text
        _ocupado = True
        btnSalvar.Enabled = False
        btnCancelar.Enabled = False
        UseWaitCursor = True
        Try
            Dim usuario As UsuarioAutenticado = Await Task.Run(Function() Autenticacao.AlterarSenha(atual, nova))
            SessaoAtual.Iniciar(usuario)
            txtSenhaAtual.Clear()
            txtNovaSenha.Clear()
            txtConfirmacao.Clear()
            MessageBox.Show("Senha alterada com sucesso.", "Senha")
            _ocupado = False
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            txtSenhaAtual.Clear()
            MessageBox.Show(ex.Message, "Senha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            atual = Nothing
            nova = Nothing
            _ocupado = False
            If Not IsDisposed Then
                btnSalvar.Enabled = True
                btnCancelar.Enabled = True
                UseWaitCursor = False
            End If
        End Try
    End Sub
    Private Sub Fechando(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _ocupado Then e.Cancel = True
    End Sub
End Class
