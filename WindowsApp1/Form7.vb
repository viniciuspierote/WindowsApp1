Public Class Form7
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txt1.Text = "ASTM F136" Then
            txt2.Text = "Titânio 6Al 4V Eli"
        ElseIf txt1.Text = "F138" Then
            txt2.Text = "Aço"
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txt2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt1.TextChanged

    End Sub
End Class