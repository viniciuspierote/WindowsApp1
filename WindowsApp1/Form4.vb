Imports MySql.Data.MySqlClient

Public Class Form4
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String
    Private loteglobal As String

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdados.CellContentClick

    End Sub

    Private Sub btnexibir_Click(sender As Object, e As EventArgs) Handles btnexibir.Click
        Dim work As String
        work = txtworkorder.Text
        Try
            conexaoo = conexao.NovaConexao()
            strSQL = "Select * FROM itu_cad_certif_prod_f where work_order = " + work
            Dim dt As New DataTable
            da = New MySqlDataAdapter(strSQL, conexaoo)
            da.Fill(dt)
            dgvdados.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btnatualizar.Click
        Try
            conexaoo = conexao.NovaConexao()
            strSQL = "update itu_cad_certif_prod_f set VALOR = @valor Where Work_order = work_order and TIPO = @tipo"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order", txtworkorder.Text)
            comando.Parameters.AddWithValue("@sequencia", txtsequencia.Text)
            comando.Parameters.AddWithValue("@tipo", txttipo.Text)
            comando.Parameters.AddWithValue("@valor", txtvalor.Text)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            conexaoo = conexao.NovaConexao()
            strSQL = "INSERT INTO itu_cad_certif_prod_f (WORK_ORDER, SEQUENCIA, TIPO, VALOR) VALUES (@work_order, @sequencia, @tipo, @valor)"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order", txtworkorder.Text)
            comando.Parameters.AddWithValue("@sequencia", txtsequencia.Text)
            comando.Parameters.AddWithValue("@tipo", txttipo.Text)
            comando.Parameters.AddWithValue("@valor", txtvalor.Text)


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

    Private Sub btnexcluir_Click(sender As Object, e As EventArgs) Handles btnexcluir.Click

        Try
            conexaoo = conexao.NovaConexao()
            strSQL = "Delete from itu_cad_certif_prod_f where WORK_ORDER = @work_order and SEQUENCIA = @sequencia and TIPO = @tipo"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order", txtworkorder.Text)
            comando.Parameters.AddWithValue("@sequencia", txtsequencia.Text)
            comando.Parameters.AddWithValue("@tipo", txttipo.Text)
            comando.Parameters.AddWithValue("@valor", txtvalor.Text)


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

    Private Sub txtworkorder_TextChanged(sender As Object, e As EventArgs) Handles txtworkorder.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim work As String
        work = txtworkorder.Text
        MsgBox("O valor da variável work é: " + work)

    End Sub
End Class
