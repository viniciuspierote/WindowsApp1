Public Class frmlogin
    Public nomeusuario As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_principal.Show()
        nomeusuario = txtusuario.Text

    End Sub

    Private Sub btnsair_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        Application.Exit()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class