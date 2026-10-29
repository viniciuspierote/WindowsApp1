Option Strict On
Option Explicit On
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Partial Public Class frm_principal
    Private _acessoNegado As Boolean
    Private _fechandoSessao As Boolean

    Private Sub PrepararAcessoPrincipal(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Try
            SessaoAtual.ExigirAutenticado()
            Dim usuario As UsuarioAutenticado = SessaoAtual.Usuario
            lblUsuarioSistema.Text = "Usuário: " & usuario.Login & " | " & usuario.Nome & " | " & usuario.Perfil
            btnUsuariosSistema.Enabled = SessaoAtual.Administrador
        Catch ex As Exception
            _acessoNegado = True
            Enabled = False
            MessageBox.Show(ex.Message, "Acesso")
            BeginInvoke(New Action(AddressOf Close))
        End Try
    End Sub
    Private Sub AbrirUsuarios(sender As Object, e As EventArgs) Handles btnUsuariosSistema.Click
        Try
            SessaoAtual.ExigirAdministrador()
            Using janela As New frmUsuarios()
                janela.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuários", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub AlterarMinhaSenha(sender As Object, e As EventArgs) Handles btnMinhaSenha.Click
        Try
            SessaoAtual.ExigirAutenticado()
            Using janela As New frmAlterarSenha()
                janela.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Senha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub SairDaSessao(sender As Object, e As EventArgs) Handles btnSairSessao.Click
        Close()
    End Sub
    Private Sub ConfirmarEncerramento(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DesignMode OrElse _acessoNegado OrElse _fechandoSessao OrElse e.Cancel Then Return
        ' Preserva o bloqueio de fechamento enquanto o backup esta em andamento.
        If tarefaBackup IsNot Nothing AndAlso Not tarefaBackup.IsCompleted Then
            e.Cancel = True
            Return
        End If
        If MessageBox.Show("Encerrar a sessão e fechar as telas abertas?" & vbCrLf &
                           "Alterações ainda não salvas serão descartadas.", "Sair da sessão",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            e.Cancel = True
            Return
        End If
        _fechandoSessao = True
        Try
            Dim abertas As New List(Of Form)()
            For Each janela As Form In Application.OpenForms
                If janela IsNot Me AndAlso Not TypeOf janela Is frmlogin Then abertas.Add(janela)
            Next
            For Each janela As Form In abertas
                janela.Close()
                If Not janela.IsDisposed Then
                    e.Cancel = True
                    Return
                End If
            Next
        Finally
            _fechandoSessao = False
        End Try
    End Sub
End Class
