Imports MySql.Data.MySqlClient

Public Class frmcadastro
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String
    Public loteglobal As String
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtcorrida.TextChanged, txtsalesorder.TextChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        '
    End Sub

    Private Sub btnprocurar_Click(sender As Object, e As EventArgs) Handles btnprocurar.Click
        Dim cq = txtworkorder1.Text

        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "SELECT * from cadastrocertificados WHERE Work_Order_1 = @Work_Order_1"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@Work_Order_1", txtworkorder1.Text)
            conexaoo.Open()
            dr = comando.ExecuteReader()

            If dr.Read() Then ' Verificar se há registros antes de ler os campos
                txtcorrida.Text = If(Not IsDBNull(dr("Heat_Number")), dr("Heat_Number").ToString(), String.Empty)
                txtid.Text = If(Not IsDBNull(dr("work_order")), dr("work_order").ToString(), String.Empty)
                txtsalesorder.Text = If(Not IsDBNull(dr("Sales_Order")), dr("Sales_Order").ToString(), String.Empty)
                txtcodfornecedor.Text = If(Not IsDBNull(dr("AGN_IN_CODIGO")), dr("AGN_IN_CODIGO").ToString(), String.Empty)
                txtquantidade.Text = If(Not IsDBNull(dr("qtde")), dr("qtde").ToString(), String.Empty)
                txtsalesorder.Text = If(Not IsDBNull(dr("sales_order")), dr("sales_order").ToString(), String.Empty)
                txtespecificacao.Text = If(Not IsDBNull(dr("especificacao")), dr("especificacao").ToString(), String.Empty)
                txtdimensao.Text = If(Not IsDBNull(dr("size_a")), dr("size_a").ToString(), String.Empty)
                txttolerancia.Text = If(Not IsDBNull(dr("tolerancia")), dr("tolerancia").ToString(), String.Empty)
                txtobservacao.Text = If(Not IsDBNull(dr("obs")), dr("obs").ToString(), String.Empty)
                txtafina.Text = If(Not IsDBNull(dr("a_fina")), dr("a_fina").ToString(), String.Empty)
                txtbfina.Text = If(Not IsDBNull(dr("b_fina")), dr("b_fina").ToString(), String.Empty)
                txtcfina.Text = If(Not IsDBNull(dr("c_fina")), dr("c_fina").ToString(), String.Empty)
                txtdfina.Text = If(Not IsDBNull(dr("d_fina")), dr("d_fina").ToString(), String.Empty)
                txtagrossa.Text = If(Not IsDBNull(dr("a_grossa")), dr("a_grossa").ToString(), String.Empty)
                txtbgrossa.Text = If(Not IsDBNull(dr("b_grossa")), dr("b_grossa").ToString(), String.Empty)
                txtcgrossa.Text = If(Not IsDBNull(dr("c_grossa")), dr("c_grossa").ToString(), String.Empty)
                txtdgrossa.Text = If(Not IsDBNull(dr("d_grossa")), dr("d_grossa").ToString(), String.Empty)
                txtmicroestrutura.Text = If(Not IsDBNull(dr("microestrutura")), dr("microestrutura").ToString(), String.Empty)
                txtcomprimento.Text = If(Not IsDBNull(dr("comprimento")), dr("comprimento").ToString(), String.Empty)
                txtanocertificado.Text = If(Not IsDBNull(dr("ano_cert")), dr("ano_cert").ToString(), String.Empty)
                txttamanhograo.Text = If(Not IsDBNull(dr("obt_grao")), dr("obt_grao").ToString(), String.Empty)
                txtespecificacaograo.Text = If(Not IsDBNull(dr("esp_grao")), dr("esp_grao").ToString(), String.Empty)
                txtescoamento.Text = If(Not IsDBNull(dr("escoamento")), dr("escoamento").ToString(), String.Empty)
                txttracao.Text = If(Not IsDBNull(dr("res_atracao")), dr("res_atracao").ToString(), String.Empty)
                txtcustomer.Text = If(Not IsDBNull(dr("customer_po")), dr("customer_po").ToString(), String.Empty)
                txtalongamento.Text = If(Not IsDBNull(dr("along")), dr("along").ToString(), String.Empty)
            Else
                ' Caso não haja registros, você pode limpar os campos de texto
                txtcorrida.Text = String.Empty
                txtid.Text = String.Empty
                txtsalesorder.Text = String.Empty
                txtcodfornecedor.Text = String.Empty
                txtquantidade.Text = String.Empty
                txtespecificacao.Text = String.Empty
                txtdimensao.Text = String.Empty
                txttolerancia.Text = String.Empty
                txtobservacao.Text = String.Empty
                txtafina.Text = String.Empty
                txtbfina.Text = String.Empty
                txtcfina.Text = String.Empty
                txtdfina.Text = String.Empty
                txtagrossa.Text = String.Empty
                txtbgrossa.Text = String.Empty
                txtcgrossa.Text = String.Empty
                txtdgrossa.Text = String.Empty
                txtmicroestrutura.Text = String.Empty
                txtcomprimento.Text = String.Empty
                txtanocertificado.Text = String.Empty
                txttamanhograo.Text = String.Empty
                txtespecificacaograo.Text = String.Empty
                txtescoamento.Text = String.Empty
                txttracao.Text = String.Empty
                txtcustomer.Text = String.Empty
                txtalongamento.Text = String.Empty
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
    End Sub



    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub txtdureza_TextChanged(sender As Object, e As EventArgs) Handles txtdureza.TextChanged

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmcadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtworkorder.Text = txtid.Text
        Dim numero
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = ("SELECT WORK_ORDER FROM cadastrocertificados ORDER BY WORK_ORDER DESC LIMIT 1")
            comando = New MySqlCommand(strSQL, conexaoo)

            conexaoo.Open()
            dr = comando.ExecuteReader()
            Do While dr.Read
                numero = dr("work_order")
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
        txtid.Text = numero + 1
    End Sub

    Private Sub btnatualizar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btncadastrarcomposicao_Click(sender As Object, e As EventArgs) Handles btncadastrarcomposicao.Click
        Form4.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btninserir_Click(sender As Object, e As EventArgs) Handles btninserir.Click

    End Sub

    Private Sub btnsalvar_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "INSERT INTO cadastrocertificados (WORK_ORDER, HEAT_NUMBER, SALES_ORDER, CUSTOMER_PO, QTDE, ESPECIFICACAO, SIZE_A, TOLERANCIA, OBS, AGN_IN_CODIGO, WORK_ORDER_1, ESP_GRAO, OBT_GRAO, DUREZA, ALONG, ESCOAMENTO, RES_ATRACAO, A_FINA, B_FINA, C_FINA, D_FINA, A_GROSSA, B_GROSSA, C_GROSSA, D_GROSSA, MICROESTRUTURA, COMPRIMENTO, ANO_CERT, REDUCAOAREA) Values (@work_order, @corrida, @salesorder, @customer, @quantidade, @especificacao, @dimensao, @tolerancia, @observacao, @codfornecedor, @work_order_1, @espeficacaograo, @tamanhograo, @dureza, @alongamento, @escoamento, @tracao, @afina, @bfina, @cfina, @dfina, @agrossa, @bgrossa, @cgrossa, @dgrossa, @microestrutura, @comprimento, @anocertificado, @reducaodearea)"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order", txtid.Text)
            comando.Parameters.AddWithValue("@corrida", txtcorrida.Text)
            comando.Parameters.AddWithValue("@work_order_1", txtworkorder1.Text)
            comando.Parameters.AddWithValue("@salesorder", txtsalesorder.Text)
            comando.Parameters.AddWithValue("@codfornecedor", txtcodfornecedor.Text)
            comando.Parameters.AddWithValue("@customer", txtcustomer.Text)
            comando.Parameters.AddWithValue("@quantidade", txtquantidade.Text)
            comando.Parameters.AddWithValue("@especificacao", txtespecificacao.Text)
            comando.Parameters.AddWithValue("@dimensao", txtdimensao.Text)
            comando.Parameters.AddWithValue("@tolerancia", txttolerancia.Text)
            comando.Parameters.AddWithValue("@comprimento", txtcomprimento.Text)
            comando.Parameters.AddWithValue("@microestrutura", txtmicroestrutura.Text)
            comando.Parameters.AddWithValue("@observacao", txtobservacao.Text)
            comando.Parameters.AddWithValue("@afina", txtafina.Text)
            comando.Parameters.AddWithValue("@bfina", txtbfina.Text)
            comando.Parameters.AddWithValue("@cfina", txtcfina.Text)
            comando.Parameters.AddWithValue("@dfina", txtdfina.Text)
            comando.Parameters.AddWithValue("@agrossa", txtagrossa.Text)
            comando.Parameters.AddWithValue("@bgrossa", txtbgrossa.Text)
            comando.Parameters.AddWithValue("@cgrossa", txtcgrossa.Text)
            comando.Parameters.AddWithValue("@dgrossa", txtdgrossa.Text)
            comando.Parameters.AddWithValue("@tamanhograo", txttamanhograo.Text)
            comando.Parameters.AddWithValue("@espeficacaograo", txtespecificacaograo.Text)
            comando.Parameters.AddWithValue("@alongamento", txtalongamento.Text)
            comando.Parameters.AddWithValue("@escoamento", txtescoamento.Text)
            comando.Parameters.AddWithValue("@tracao", txttracao.Text)
            comando.Parameters.AddWithValue("@reducaoarea", txtreducaoarea.Text)
            comando.Parameters.AddWithValue("@dureza", txtdureza.Text)
            comando.Parameters.AddWithValue("@anocertificado", txtanocertificado.Text)
            comando.Parameters.AddWithValue("@reducaodearea", txtreducaoarea.Text)
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

    Private Sub btnatualizar_Click_1(sender As Object, e As EventArgs) Handles btnatualizar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "UPDATE cadastrocertificados set HEAT_NUMBER = @corrida, SALES_ORDER = @salesorder, CUSTOMER_PO = @customer, QTDE = @quantidade, ESPECIFICACAO = @especificacao, SIZE_A = @dimensao, TOLERANCIA = @tolerancia, OBS = @observacao, AGN_IN_CODIGO = @codfornecedor, WORK_ORDER_1 = @work_order_1, ESP_GRAO = @espeficacaograo, OBT_GRAO = @tamanhograo, DUREZA = @dureza, ALONG = @alongamento, ESCOAMENTO = @escoamento, RES_ATRACAO = @tracao, A_FINA = @afina, B_FINA = @bfina, C_FINA = @cfina, D_FINA = @dfina, A_GROSSA = @agrossa, B_GROSSA = @bgrossa, C_GROSSA = @cgrossa, D_GROSSA = @dgrossa, MICROESTRUTURA = @microestrutura, COMPRIMENTO = @comprimento, , ANO_CERT = @anocertificado WHERE work_order = @work_order"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order", txtid.Text)
            comando.Parameters.AddWithValue("@corrida", txtcorrida.Text)
            comando.Parameters.AddWithValue("@work_order_1", txtworkorder1.Text)
            comando.Parameters.AddWithValue("@salesorder", txtsalesorder.Text)
            comando.Parameters.AddWithValue("@codfornecedor", txtcodfornecedor.Text)
            comando.Parameters.AddWithValue("@customer", txtcustomer.Text)
            comando.Parameters.AddWithValue("@quantidade", txtquantidade.Text)
            comando.Parameters.AddWithValue("@especificacao", txtespecificacao.Text)
            comando.Parameters.AddWithValue("@dimensao", txtdimensao.Text)
            comando.Parameters.AddWithValue("@tolerancia", txttolerancia.Text)
            comando.Parameters.AddWithValue("@comprimento", txtcomprimento.Text)
            comando.Parameters.AddWithValue("@microestrutura", txtmicroestrutura.Text)
            comando.Parameters.AddWithValue("@observacao", txtobservacao.Text)
            comando.Parameters.AddWithValue("@afina", txtafina.Text)
            comando.Parameters.AddWithValue("@bfina", txtbfina.Text)
            comando.Parameters.AddWithValue("@cfina", txtcfina.Text)
            comando.Parameters.AddWithValue("@dfina", txtdfina.Text)
            comando.Parameters.AddWithValue("@agrossa", txtagrossa.Text)
            comando.Parameters.AddWithValue("@bgrossa", txtbgrossa.Text)
            comando.Parameters.AddWithValue("@cgrossa", txtcgrossa.Text)
            comando.Parameters.AddWithValue("@dgrossa", txtcorrida.Text)
            comando.Parameters.AddWithValue("@tamanhograo", txttamanhograo.Text)
            comando.Parameters.AddWithValue("@espeficacaograo", txtespecificacaograo.Text)
            comando.Parameters.AddWithValue("@alongamento", txtalongamento.Text)
            comando.Parameters.AddWithValue("@escoamento", txtescoamento.Text)
            comando.Parameters.AddWithValue("@tracao", txttracao.Text)
            comando.Parameters.AddWithValue("@reducaoarea", txtreducaoarea.Text)
            comando.Parameters.AddWithValue("@dureza", txtdureza.Text)
            comando.Parameters.AddWithValue("@anocertificado", txtanocertificado.Text)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnincluir.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "INSERT INTO cadastrocompquimica (WORK_ORDER, SEQUENCIA, TIPO, VALOR) VALUES (@work_order, @sequencia, @tipo, @valor)"
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
        txtsequencia.Text = ""
        txttipo.Text = ""
        txtvalor.Text = ""
        txtsequencia.Select()

    End Sub

    Private Sub txtworkorder_TextChanged(sender As Object, e As EventArgs) Handles txtworkorder.TextChanged
        txtworkorder.Text = txtid.Text
    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub txtid_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "Delete from cadastrocompquimica where WORK_ORDER = @work_order and SEQUENCIA = @sequencia and TIPO = @tipo"
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

    Private Sub btnexibir_Click(sender As Object, e As EventArgs) Handles btnexibir.Click
        Dim work As String
        work = txtworkorder.Text
        Try
            conexaoo = New MySqlConnection("server=localhost;database=novo_bd;uid=root;pwd=")
            strSQL = "Select * FROM cadastrocompquimica where work_order = " + work
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btneditarcompquimica.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "update cadastrocompquimica set VALOR = @valor Where Work_order = work_order and TIPO = @tipo"
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

    Private Sub txtworkorder_Click(sender As Object, e As EventArgs) Handles txtworkorder.Click
        txtworkorder.Text = txtid.Text
    End Sub
End Class

