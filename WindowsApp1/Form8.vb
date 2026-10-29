Imports MySql.Data.MySqlClient
Public Class frmcadastrarcliente
    Private Sub AcessoCliente(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Try
            SessaoAtual.ExigirAutenticado()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acesso")
            Close()
            Return
        End Try
    End Sub
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btncadastrar.Click
        Try
            SessaoAtual.ExigirAutenticado()
            conexaoo = conexao.NovaConexao()
            strSQL = "INSERT INTO clientes (codigo, nome) VALUES (@codigo, @nome)"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@codigo", txtcodigo.Text)
            comando.Parameters.AddWithValue("@nome", txtnome.Text)
            conexaoo.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show("Cliente cadastrado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If conexaoo IsNot Nothing Then conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
            txtcodigo.Text = ""
            txtnome.Text = ""
        End Try
    End Sub

    Private Sub btncadastrar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btncadastrar.KeyPress

    End Sub
End Class
