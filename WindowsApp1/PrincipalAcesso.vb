Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms

Partial Public Class frm_principal

    Private _acessoNegado As Boolean
    Private _fechandoSessao As Boolean

    Private Function PrincipalEmDesigner() As Boolean
        Return DesignMode OrElse
               LicenseManager.UsageMode = LicenseUsageMode.Designtime
    End Function

    Private Sub PrepararAcessoPrincipal(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If PrincipalEmDesigner() Then Return

        Try
            SessaoAtual.ExigirAutenticado()

            Dim usuario As UsuarioAutenticado = SessaoAtual.Usuario

            ToolStripStatusLabel1.Text =
                "Usuário: " & usuario.Login &
                " | " & usuario.Nome &
                " | Perfil: " & usuario.Perfil &
                " | Versão: " & Application.ProductVersion

            mnuUsuarios.Enabled = SessaoAtual.Administrador

        Catch ex As Exception
            _acessoNegado = True
            Enabled = False

            MessageBox.Show(
                ex.GetBaseException().Message,
                "Acesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            BeginInvoke(New Action(AddressOf Close))
        End Try
    End Sub

    Private Sub AbrirUsuarios(
        sender As Object,
        e As EventArgs
    ) Handles mnuUsuarios.Click

        Try
            SessaoAtual.ExigirAdministrador()

            Using janela As New frmUsuarios()
                janela.ShowDialog(Me)
            End Using

        Catch ex As Exception
            MessageBox.Show(
                ex.GetBaseException().Message,
                "Usuários",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub AlterarMinhaSenha(
        sender As Object,
        e As EventArgs
    ) Handles mnuMinhaSenha.Click

        Try
            SessaoAtual.ExigirAutenticado()

            Using janela As New frmAlterarSenha()
                janela.ShowDialog(Me)
            End Using

        Catch ex As Exception
            MessageBox.Show(
                ex.GetBaseException().Message,
                "Senha",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SairDaSessao(
        sender As Object,
        e As EventArgs
    ) Handles mnuSairSessao.Click

        Close()
    End Sub

    Private Sub ConfirmarEncerramento(
        sender As Object,
        e As FormClosingEventArgs
    ) Handles MyBase.FormClosing

        If PrincipalEmDesigner() OrElse
           _acessoNegado OrElse
           _fechandoSessao OrElse
           e.Cancel Then
            Return
        End If

        ' Mantém o bloqueio de fechamento durante o backup.
        ' A mensagem correspondente fica em telaprincipal.vb.
        If tarefaBackup IsNot Nothing AndAlso
           Not tarefaBackup.IsCompleted Then

            e.Cancel = True
            Return
        End If

        Dim resposta As DialogResult = MessageBox.Show(
            "Encerrar a sessão e fechar as telas abertas?" &
            vbCrLf &
            "Alterações ainda não salvas serão descartadas.",
            "Sair da sessão",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If resposta <> DialogResult.Yes Then
            e.Cancel = True
            Return
        End If

        _fechandoSessao = True

        Try
            Dim abertas As New List(Of Form)()

            For Each janela As Form In Application.OpenForms
                If janela IsNot Me AndAlso
                   Not TypeOf janela Is frmlogin Then

                    abertas.Add(janela)
                End If
            Next

            For Each janela As Form In abertas
                If janela.IsDisposed Then Continue For

                janela.Close()

                ' Respeita uma tela que tenha cancelado o fechamento.
                If Not janela.IsDisposed Then
                    e.Cancel = True
                    Return
                End If
            Next

        Catch ex As Exception
            e.Cancel = True

            MessageBox.Show(
                "Não foi possível encerrar a sessão." &
                vbCrLf &
                ex.GetBaseException().Message,
                "Sair da sessão",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        Finally
            _fechandoSessao = False
        End Try
    End Sub

End Class