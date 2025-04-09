Imports MySql.Data.MySqlClient
Public Class frmteste
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String

    Private Sub frmteste_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnnovo_Click(sender As Object, e As EventArgs) Handles btnnovo.Click
        Try

            conexaoo = New MySqlConnection("Server=localhost;Database=cliente;Uid=root;Pwd=;")
            strSQL = "INSERT INTO CAD_CLIENTE (NOME, NUMERO) VALUES (@NOME, @NUMERO)"

            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@nome", txtnome.Text)
            comando.Parameters.AddWithValue("@numero", txtnumero.Text)
            conexaoo.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try

    End Sub

    Private Sub btnexibir_Click(sender As Object, e As EventArgs) Handles btnexibir.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=cliente;Uid=root;Pwd=;")
            strSQL = "UPDATE CAD_CLIENTE SET NOME =@nome, NUMERO = @NUMERO WHERE ID = @ID"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@ID", txtid.Text)
            comando.Parameters.AddWithValue("@NOME", txtnome.Text)
            comando.Parameters.AddWithValue("@NUMERO", txtnumero.Text)
            conexaoo.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnconsultar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=cliente;Uid=root;Pwd=;")
            strSQL = "SELECT * from CAD_CLIENTE WHERE ID = @ID"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@ID", txtid.Text)

            conexaoo.Open()
            dr = comando.ExecuteReader()
            Do While dr.Read
                txtnome.Text = dr("nome")
                txtnome.Text = dr("numero")
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnexcluir.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=cliente;Uid=root;Pwd=;")
            strSQL = "Delete from CAD_CLIENTE WHERE ID = @ID"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@ID", txtid.Text)

            conexaoo.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim texto = txtteste.Text
        MsgBox(texto)

    End Sub

    Private Sub dgvdados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdados.CellContentClick

    End Sub
End Class