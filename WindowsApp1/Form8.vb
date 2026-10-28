Imports MySql.Data.MySqlClient
Public Class frmcadastrarcliente
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btncadastrar.Click
        Try
            conexaoo = conexao.NovaConexao()
            strSQL = "INSERT INTO clientes (codigo, nome) VALUES (@codigo, @nome)"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@codigo", txtcodigo.Text)
            comando.Parameters.AddWithValue("@nome", txtnome.Text)
            conexaoo.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
            MsgBox("Cliente cadastrado")
            txtcodigo.Text = ""
            txtnome.Text = ""
        End Try
    End Sub

    Private Sub btncadastrar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btncadastrar.KeyPress

    End Sub
End Class