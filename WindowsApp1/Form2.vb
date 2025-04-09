Imports MySql.Data.MySqlClient
Public Class frm_emitircertificado
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub frm_emitircertificado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "SELECT * from emissaodecertificado WHERE ID = @ID"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@ID", txtprocurar.Text)

            conexaoo.Open()
            dr = comando.ExecuteReader()
            Do While dr.Read
                txtquantidade.Text = dr("QTDE")
                txtlote.Text = dr("work_order_1")
                txtobservacao.Text = dr("OBS")
                txtnotafiscal.Text = dr("NF")
                txtliga.Text = dr("liga_material")
                txttratamentotermico.Text = dr("trat_termico")
                txtacabamento.Text = dr("acabamento")
                txtcomprimento.Text = dr("comprimento")
                txtalongamento.Text = dr("along")
                txtescoamento.Text = dr("escoamento")
                txtracao.Text = dr("res_atracao")
                txtnormagrao.Text = dr("esp_grao")
                txtgrao.Text = dr("obt_grao")
                txtunidadedepeso.Text = dr("tipo_peso")
                txttipo.Text = dr("produto")
                txtdimensao.Text = dr("size_a")
                txttolerancia.Text = dr("tolerancia")
                txtcodigocliente.Text = dr("cod_cli")
                txtnumerodopedido.Text = dr("ped_cli")
                txtano.Text = dr("ano_cert")
                txtpeso.Text = dr("peso")
                txtdureza.Text = dr("dureza")
                txtnumerocertificado.Text = dr("id")
                txtcodfornecedor.Text = dr("agn_in_codigo")
                txtano.Text = dr("ano_cert")
                txtcorrida.Text = dr("heat_number")
                txtwo.Text = dr("work_order")
                txtespecificacao.Text = dr("especificacao")
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "SELECT * from emissaodecertificado WHERE work_order_1 = @work_order_1"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order_1", txtlote.Text)
            conexaoo.Open()
            dr = comando.ExecuteReader()
            Do While dr.Read
                txtespecificacao.Text = dr("especificacao")
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
        If txtnumerocertificado.Text <> "" Then
            btnincluir.Text = "Editar"
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnincluir.Click
        If btnincluir.Text = "Incluir" Then
            Dim numero
            Try
                conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
                strSQL = ("SELECT ID FROM emissaodecertificado ORDER BY id DESC LIMIT 1")
                comando = New MySqlCommand(strSQL, conexaoo)

                conexaoo.Open()
                dr = comando.ExecuteReader()
                Do While dr.Read
                    numero = dr("ID")
                Loop
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conexaoo.Close()
                conexaoo = Nothing
                comando = Nothing
            End Try
            txtnumerocertificado.Text = numero + 1
            txtquantidade.Enabled = True
            txtlote.Enabled = True
            txtobservacao.Enabled = True
            txtnotafiscal.Enabled = True
            txtliga.Enabled = True
            txttratamentotermico.Enabled = True
            txtacabamento.Enabled = True
            txtcomprimento.Enabled = True
            txtalongamento.Enabled = True
            txtescoamento.Enabled = True
            txtracao.Enabled = True
            txtnormagrao.Enabled = True
            txtgrao.Enabled = True
            txtunidadedepeso.Enabled = True
            txttipo.Enabled = True
            txtdimensao.Enabled = True
            txttolerancia.Enabled = True
            txtcodigocliente.Enabled = True
            txtnumerodopedido.Enabled = True
            txtano.Enabled = True
            txtpeso.Enabled = True
            txtdureza.Enabled = True
            txtnumerocertificado.Enabled = True
            txtcodfornecedor.Enabled = True
            txtano.Enabled = True
            txtreducaoarea.Enabled = True
            txtcorrida.Enabled = True
            btnincluirlote.Enabled = True
            btnprocurar.Enabled = True
            btncancelar.Enabled = True
            btnsalvar.Enabled = True
            btnprocurarcliente.Enabled = True
            btneditar.Enabled = False
            btnincluir.Enabled = False
            btnbuscar.Enabled = False
            txtquantidade.Text = " metros"
        End If
        If btnincluir.Text = "Editar" Then
            txtquantidade.Enabled = True
            txtlote.Enabled = True
            txtobservacao.Enabled = True
            txtnotafiscal.Enabled = True
            txtliga.Enabled = True
            txttratamentotermico.Enabled = True
            txtacabamento.Enabled = True
            txtcomprimento.Enabled = True
            txtalongamento.Enabled = True
            txtescoamento.Enabled = True
            txtracao.Enabled = True
            txtnormagrao.Enabled = True
            txtgrao.Enabled = True
            txtunidadedepeso.Enabled = True
            txttipo.Enabled = True
            txtdimensao.Enabled = True
            txttolerancia.Enabled = True
            txtcodigocliente.Enabled = True
            txtnumerodopedido.Enabled = True
            txtano.Enabled = True
            txtpeso.Enabled = True
            txtdureza.Enabled = True
            txtnumerocertificado.Enabled = True
            txtcodfornecedor.Enabled = True
            txtano.Enabled = True
            txtreducaoarea.Enabled = True
            txtcorrida.Enabled = True
            btnsalvar.Enabled = True
            btnprocurar.Enabled = True
            btnprocurarcliente.Enabled = True
            btncancelar.Enabled = True
            txtespecificacao.Enabled = True
        End If
        txtano.Text = "2023"
        txttipo.Text = "Barra Redonda"
        txtacabamento.Text = "Retificado"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        If btneditar.Enabled Then
            btneditar.Text = "Cancelar"
            txtquantidade.Enabled = True
            txtlote.Enabled = True
            txtobservacao.Enabled = True
            txtnotafiscal.Enabled = True
            txtliga.Enabled = True
            txttratamentotermico.Enabled = True
            txtacabamento.Enabled = True
            txtcomprimento.Enabled = True
            txtalongamento.Enabled = True
            txtescoamento.Enabled = True
            txtracao.Enabled = True
            txtnormagrao.Enabled = True
            txtgrao.Enabled = True
            txtunidadedepeso.Enabled = True
            txttipo.Enabled = True
            txtdimensao.Enabled = True
            txttolerancia.Enabled = True
            txtcodigocliente.Enabled = True
            txtnumerodopedido.Enabled = True
            txtano.Enabled = True
            txtpeso.Enabled = True
            txtdureza.Enabled = True
            txtnumerocertificado.Enabled = True
            txtcodfornecedor.Enabled = True
            txtano.Enabled = True
            txtreducaoarea.Enabled = True
            txtcorrida.Enabled = True
            btnsalvar.Enabled = True
        End If
        If btneditar.Text = "Cancelar" Then
            txtquantidade.Text = ""
            txtlote.Text = ""
            txtobservacao.Text = ""
            txtnotafiscal.Text = ""
            txtliga.Text = ""
            txttratamentotermico.Text = ""
            txtacabamento.Text = ""
            txtcomprimento.Text = ""
            txtalongamento.Text = ""
            txtescoamento.Text = ""
            txtracao.Text = ""
            txtnormagrao.Text = ""
            txtgrao.Text = ""
            txtunidadedepeso.Text = ""
            txttipo.Text = ""
            txtdimensao.Text = ""
            txttolerancia.Text = ""
            txtcodigocliente.Text = ""
            txtnumerodopedido.Text = ""
            txtano.Text = ""
            txtpeso.Text = ""
            txtdureza.Text = ""
            txtnumerocertificado.Text = ""
            txtcodfornecedor.Text = ""
            txtano.Text = ""
            txtreducaoarea.Text = ""
            txtcorrida.Text = ""
            txtespecificacao.Text = ""
            txtobservacao.Text = ""
            txtmicroestrutura.Text = ""
            txtafina.Text = ""
            txtbfina.Text = ""
            txtcfina.Text = ""
            txtdfina.Text = ""
            txtagrossa.Text = ""
            txtbgrossa.Text = ""
            txtcgrossa.Text = ""
            txtdgrossa.Text = ""
        End If


    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click

        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "INSERT INTO emissaodecertificado (WORK_ORDER, HEAT_NUMBER, QTDE, ESPECIFICACAO, SIZE_A, TOLERANCIA, OBS, AGN_IN_CODIGO, WORK_ORDER_1, ID, COD_CLI, PED_CLI, NF, LIGA_MATERIAL, TRAT_TERMICO, ACABAMENTO, COMPRIMENTO, PESO, ALONG, ESCOAMENTO, RES_ATRACAO, MICROESTRUTURA, PRODUTO, ESP_GRAO, OBT_GRAO, DUREZA, A_FINA, B_FINA, C_FINA, D_FINA, A_GROSSA, B_GROSSA, C_GROSSA, D_GROSSA, NOME_ABRV, ANO_CERT, TIPO_PESO, REDUCAODEAREA) VALUES (@workorder, @corrida, @quantidade, @especificacao, @dimensao, @tolerancia, @observacao, @codigofornecedor, @lote, @certificado, @codigocliente, @numerodopedido, @notafiscal, @liga, @tratamentotermico, @acabamento, @comprimento, @peso, @alongamento, @escoamento, @tracao, @microestrutura, @tipo, @normagrao, @grao, @dureza, @afina, @bfina, @cfina, @dfina, @agrossa, @bgrossa, @cgrossa, @dgrossa, @fornecedor, @certificadoano, @unidadepeso, @REDUCAODEAREA)"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@certificado", txtnumerocertificado.Text)
            comando.Parameters.AddWithValue("@especificacao", txtespecificacao.Text)
            comando.Parameters.AddWithValue("@certificadoano", txtano.Text)
            comando.Parameters.AddWithValue("@lote", txtlote.Text)
            comando.Parameters.AddWithValue("@codigofornecedor", txtcodfornecedor.Text)
            comando.Parameters.AddWithValue("@codigocliente", txtcodigocliente.Text)
            comando.Parameters.AddWithValue("@fornecedor", txtfornecedor.Text)
            comando.Parameters.AddWithValue("@notafiscal", txtnotafiscal.Text)
            comando.Parameters.AddWithValue("@numerodopedido", txtnumerodopedido.Text)
            comando.Parameters.AddWithValue("@peso", txtpeso.Text)
            comando.Parameters.AddWithValue("@unidadepeso", txtunidadedepeso.Text)
            comando.Parameters.AddWithValue("@quantidade", txtquantidade.Text)
            comando.Parameters.AddWithValue("@corrida", txtcorrida.Text)
            comando.Parameters.AddWithValue("@liga", txtliga.Text)
            comando.Parameters.AddWithValue("@tipo", txttipo.Text)
            comando.Parameters.AddWithValue("@dimensao", txtdimensao.Text)
            comando.Parameters.AddWithValue("@tolerancia", txttolerancia.Text)
            comando.Parameters.AddWithValue("@comprimento", txtcomprimento.Text)
            comando.Parameters.AddWithValue("@tratamentotermico", txttratamentotermico.Text)
            comando.Parameters.AddWithValue("@acabamento", txtacabamento.Text)
            comando.Parameters.AddWithValue("@alongamento", txtalongamento.Text)
            comando.Parameters.AddWithValue("@reducaodearea", txtreducaoarea.Text)
            comando.Parameters.AddWithValue("@escoamento", txtescoamento.Text)
            comando.Parameters.AddWithValue("@tracao", txtracao.Text)
            comando.Parameters.AddWithValue("@dureza", txtdureza.Text)
            comando.Parameters.AddWithValue("@grao", txtgrao.Text)
            comando.Parameters.AddWithValue("@normagrao", txtnormagrao.Text)
            comando.Parameters.AddWithValue("@observacao", txtobservacao.Text)
            comando.Parameters.AddWithValue("@microestrutura", txtmicroestrutura.Text)
            comando.Parameters.AddWithValue("@afina", txtafina.Text)
            comando.Parameters.AddWithValue("@bfina", txtbfina.Text)
            comando.Parameters.AddWithValue("@cfina", txtcfina.Text)
            comando.Parameters.AddWithValue("@dfina", txtdfina.Text)
            comando.Parameters.AddWithValue("@agrossa", txtagrossa.Text)
            comando.Parameters.AddWithValue("@bgrossa", txtbgrossa.Text)
            comando.Parameters.AddWithValue("@cgrossa", txtcgrossa.Text)
            comando.Parameters.AddWithValue("@dgrossa", txtdgrossa.Text)
            comando.Parameters.AddWithValue("@workorder", txtwo.Text)
            conexaoo.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try

        txtquantidade.Enabled = False
        txtlote.Enabled = False
        txtobservacao.Enabled = False
        txtnotafiscal.Enabled = False
        txtliga.Enabled = False
        txttratamentotermico.Enabled = False
        txtacabamento.Enabled = False
        txtcomprimento.Enabled = False
        txtalongamento.Enabled = False
        txtescoamento.Enabled = False
        txtracao.Enabled = False
        txtnormagrao.Enabled = False
        txtgrao.Enabled = False
        txtunidadedepeso.Enabled = False
        txttipo.Enabled = False
        txtdimensao.Enabled = False
        txttolerancia.Enabled = False
        txtcodigocliente.Enabled = False
        txtnumerodopedido.Enabled = False
        txtano.Enabled = False
        txtpeso.Enabled = False
        txtdureza.Enabled = False
        txtnumerocertificado.Enabled = False
        txtcodfornecedor.Enabled = False
        txtano.Enabled = False
        txtreducaoarea.Enabled = False
        txtcorrida.Enabled = False
        txtespecificacao.Enabled = False
        btnincluir.Enabled = True

        txtquantidade.Text = ""
        txtlote.Text = ""
        txtobservacao.Text = ""
        txtnotafiscal.Text = ""
        txtliga.Text = ""
        txttratamentotermico.Text = ""
        txtacabamento.Text = ""
        txtcomprimento.Text = ""
        txtalongamento.Text = ""
        txtescoamento.Text = ""
        txtracao.Text = ""
        txtnormagrao.Text = ""
        txtgrao.Text = ""
        txtunidadedepeso.Text = ""
        txttipo.Text = ""
        txtdimensao.Text = ""
        txttolerancia.Text = ""
        txtcodigocliente.Text = ""
        txtnumerodopedido.Text = ""
        txtano.Text = ""
        txtpeso.Text = ""
        txtdureza.Text = ""
        txtnumerocertificado.Text = ""
        txtcodfornecedor.Text = ""
        txtano.Text = ""
        txtreducaoarea.Text = ""
        txtcorrida.Text = ""
        txtespecificacao.Text = ""
        txtobservacao.Text = ""
        txtmicroestrutura.Text = ""
        txtafina.Text = ""
        txtbfina.Text = ""
        txtcfina.Text = ""
        txtdfina.Text = ""
        txtagrossa.Text = ""
        txtbgrossa.Text = ""
        txtcgrossa.Text = ""
        txtdgrossa.Text = ""

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btnprocurar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "SELECT * from cadastrocertificados WHERE work_order_1 = @work_order_1"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@work_order_1", txtlote.Text)

            conexaoo.Open()
            dr = comando.ExecuteReader()
            If dr.Read() Then ' Verificar se há registros antes de ler os campos
                txtcorrida.Text = If(Not IsDBNull(dr("Heat_Number")), dr("Heat_Number").ToString(), String.Empty)
                txtcodfornecedor.Text = If(Not IsDBNull(dr("AGN_IN_CODIGO")), dr("AGN_IN_CODIGO").ToString(), String.Empty)
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
                txtalongamento.Text = If(Not IsDBNull(dr("along")), dr("along").ToString(), String.Empty)
                txtreducaoarea.Text = If(Not IsDBNull(dr("reducaoarea")), dr("reducaoarea").ToString(), String.Empty)
                txtescoamento.Text = If(Not IsDBNull(dr("escoamento")), dr("escoamento").ToString(), String.Empty)
                txtracao.Text = If(Not IsDBNull(dr("res_atracao")), dr("res_atracao").ToString(), String.Empty)
                txtdureza.Text = If(Not IsDBNull(dr("dureza")), dr("dureza").ToString(), String.Empty)
                txtwo.Text = If(Not IsDBNull(dr("work_order")), dr("work_order").ToString(), String.Empty)
            Else
                ' Caso não haja registros, você pode limpar os campos de texto
                txtcorrida.Text = String.Empty
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



                txtescoamento.Text = String.Empty


                txtalongamento.Text = String.Empty
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try

        If txtespecificacao.Text = ("ASTM F1537 / NBR ISO 5832-12") Then
            txtliga.Text = ("Cobalto - Cromo")
        ElseIf txtespecificacao.Text = ("ASTM F899 303") Then
            txtliga.Text = ("Aço Inoxidável")
            txttratamentotermico.Text = ("Recozido")
        ElseIf txtespecificacao.Text = ("ASTM F67-Gr1 e ISO 5832-2") Then
            txtliga.Text = ("Titânio Puro")
            txttratamentotermico.Text = ("Recozido")
        ElseIf txtespecificacao.Text = ("ASTM F67-Gr2 e ISO 5832-2") Then
            txtliga.Text = ("Titânio Puro")
            txttratamentotermico.Text = ("Recozido")
        ElseIf txtespecificacao.Text = ("ASTM F67-Gr4 e ISO 5832-2") Then
            txttratamentotermico.Text = ("Recozido")
            txtliga.Text = ("Titânio Puro")
            txttratamentotermico.Text = ("Recozido")
        ElseIf txtespecificacao.Text = ("ASTM F899 S42010") Then
            txttratamentotermico.Text = ("Recozido")
            txtliga.Text = ("Aço Inoxidável")
        ElseIf txtespecificacao.Text = ("ASTM F899 440C") Then
            txttratamentotermico.Text = ("Recozido")
            txtliga.Text = ("Aço Inoxidável")
        ElseIf txtespecificacao.Text = ("ASTM F136 e ISO 5832-3") Then
            txttratamentotermico.Text = ("Recozido")
            txtliga.Text = ("Titânio 6Al 4V ELI")
        ElseIf txtespecificacao.Text = ("ASTM F899 455 XM-16") Then
            txttratamentotermico.Text = ("Recozido")
            txtliga.Text = ("Aço Inoxidável")
        ElseIf txtespecificacao.Text = ("ASTM F2063") Then
            txtliga.Text = ("Níquel - Titânio")
            txttratamentotermico.Text = ("Recozido")
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtdgrossa.TextChanged

    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtcgrossa.TextChanged

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles txtbgrossa.TextChanged

    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles txtagrossa.TextChanged

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click

    End Sub

    Private Sub btnteste_Click(sender As Object, e As EventArgs)
        MsgBox("(WORK_ORDER, HEAT_NUMBER, QTDE, ESPECIFICACAO, SIZE_A, TOLERANCIA, OBS, AGN_IN_CODIGO, WORK_ORDER_1, ID, COD_CLI, PED_CLI, NF, LIGA_MATERIAL, TRAT_TERMICO, ACABAMENTO, COMPRIMENTO, PESO, ALONG, ESCOAMENTO, RES_ATRACAO, MICROESTRUTURA, PRODUTO, ESP_GRAO, OBT_GRAO, DUREZA, A_FINA, B_FINA, C_FINA, C_FINA, A_GROSSA, B_GROSSA, C_GROSSA, D_GROSSA, NOME_ABRV, ANO_CERT, TIPO_PESO) VALUES (@work_order, @corrida, @quantidade, @dimensao, @tolerancia, @observacao, @codigofornecedor, @lote, @certificado, @codigocliente, @numerodopedido, @notafiscal, @liga, @tratamentotermico, @acabamento, @comprimento, @peso, @alongamento,@escoamento, @tracao @microestrutura, @tipo, @normagrao, @grao, @dureza, @afina, @bfina, @cfina, @dfina, @agrossa, @bgrossa, @cgrossa, @dgrossa, @fornecedor, @certificadoano, @unidadepeso)")

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnprocurarcliente.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "SELECT * from clientes WHERE codigo = @codigo"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@codigo", txtcodigocliente.Text)

            conexaoo.Open()
            dr = comando.ExecuteReader()
            Do While dr.Read
                txtnomecliente.Text = dr("nome")

            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        txtquantidade.Enabled = False
        txtlote.Enabled = False
        txtobservacao.Enabled = False
        txtnotafiscal.Enabled = False
        txtliga.Enabled = False
        txttratamentotermico.Enabled = False
        txtacabamento.Enabled = False
        txtcomprimento.Enabled = False
        txtalongamento.Enabled = False
        txtescoamento.Enabled = False
        txtracao.Enabled = False
        txtnormagrao.Enabled = False
        txtgrao.Enabled = False
        txtunidadedepeso.Enabled = False
        txttipo.Enabled = False
        txtdimensao.Enabled = False
        txttolerancia.Enabled = False
        txtcodigocliente.Enabled = False
        txtnumerodopedido.Enabled = False
        txtano.Enabled = False
        txtpeso.Enabled = False
        txtdureza.Enabled = False
        txtnumerocertificado.Enabled = False
        txtcodfornecedor.Enabled = False
        txtano.Enabled = False
        txtreducaoarea.Enabled = False
        txtcorrida.Enabled = False
        txtespecificacao.Enabled = False

        txtquantidade.Text = ""
        txtlote.Text = ""
        txtobservacao.Text = ""
        txtnotafiscal.Text = ""
        txtliga.Text = ""
        txttratamentotermico.Text = ""
        txtacabamento.Text = ""
        txtcomprimento.Text = ""
        txtalongamento.Text = ""
        txtescoamento.Text = ""
        txtracao.Text = ""
        txtnormagrao.Text = ""
        txtgrao.Text = ""
        txtunidadedepeso.Text = ""
        txttipo.Text = ""
        txtdimensao.Text = ""
        txttolerancia.Text = ""
        txtcodigocliente.Text = ""
        txtnumerodopedido.Text = ""
        txtano.Text = ""
        txtpeso.Text = ""
        txtdureza.Text = ""
        txtnumerocertificado.Text = ""
        txtcodfornecedor.Text = ""
        txtano.Text = ""
        txtreducaoarea.Text = ""
        txtcorrida.Text = ""
        txtespecificacao.Text = ""
        btnincluir.Enabled = True
        btnbuscar.Enabled = True


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnexcluir.Click
        btnexcluir.Enabled = False
    End Sub

    Private Sub btnprocurarofornecedor_Click(sender As Object, e As EventArgs) Handles btnprocurarofornecedor.Click
        frmprocurarlote.Show()
    End Sub

    Private Sub txtliga_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtliga.SelectedIndexChanged

    End Sub

    Private Sub txtlote_TextChanged(sender As Object, e As EventArgs) Handles txtlote.TextChanged

    End Sub

    Private Sub btnatualizar_Click(sender As Object, e As EventArgs) Handles btnatualizar.Click
        Try
            conexaoo = New MySqlConnection("Server=localhost;Database=novo_bd;Uid=root;Pwd=;")
            strSQL = "UPDATE emissaodecertificado Set WORK_ORDER = @workorder, HEAT_NUMBER = @corrida, WORK_ORDER_1 = @lote, QTDE = @quantidade, ESPECIFICACAO = @especificacao, SIZE_A = @dimensao, TOLERANCIA = @tolerancia, OBS = @observacao, AGN_IN_CODIGO = @codigofornecedor, COD_CLI = @codigocliente, PED_CLI = @numerodopedido, NF = @notafiscal, LIGA_MATERIAL = @liga , TRAT_TERMICO = @tratamentotermico, ACABAMENTO = @acabamento, COMPRIMENTO = @comprimento, PESO = @peso, ALONG = @alongamento, ESCOAMENTO = @escoamento, RES_ATRACAO = @tracao, MICROESTRUTURA = @microestrutura, PRODUTO = @tipo, ESP_GRAO = @normagrao, OBT_GRAO = @grao, DUREZA = @dureza, ANO_CERT = @certificadoano, REDUCAODEAREA = @reducaodearea, TIPO_PESO = @unidadepeso WHERE ID = @certificado"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@certificado", txtnumerocertificado.Text)
            comando.Parameters.AddWithValue("@especificacao", txtespecificacao.Text)
            comando.Parameters.AddWithValue("@certificadoano", txtano.Text)
            comando.Parameters.AddWithValue("@lote", txtlote.Text)
            comando.Parameters.AddWithValue("@codigofornecedor", txtcodfornecedor.Text)
            comando.Parameters.AddWithValue("@codigocliente", txtcodigocliente.Text)
            comando.Parameters.AddWithValue("@fornecedor", txtfornecedor.Text)
            comando.Parameters.AddWithValue("@notafiscal", txtnotafiscal.Text)
            comando.Parameters.AddWithValue("@numerodopedido", txtnumerodopedido.Text)
            comando.Parameters.AddWithValue("@peso", txtpeso.Text)
            comando.Parameters.AddWithValue("@unidadepeso", txtunidadedepeso.Text)
            comando.Parameters.AddWithValue("@quantidade", txtquantidade.Text)
            comando.Parameters.AddWithValue("@corrida", txtcorrida.Text)
            comando.Parameters.AddWithValue("@liga", txtliga.Text)
            comando.Parameters.AddWithValue("@tipo", txttipo.Text)
            comando.Parameters.AddWithValue("@dimensao", txtdimensao.Text)
            comando.Parameters.AddWithValue("@tolerancia", txttolerancia.Text)
            comando.Parameters.AddWithValue("@comprimento", txtcomprimento.Text)
            comando.Parameters.AddWithValue("@tratamentotermico", txttratamentotermico.Text)
            comando.Parameters.AddWithValue("@acabamento", txtacabamento.Text)
            comando.Parameters.AddWithValue("@alongamento", txtalongamento.Text)
            comando.Parameters.AddWithValue("@reducaodearea", txtreducaoarea.Text)
            comando.Parameters.AddWithValue("@escoamento", txtescoamento.Text)
            comando.Parameters.AddWithValue("@tracao", txtracao.Text)
            comando.Parameters.AddWithValue("@dureza", txtdureza.Text)
            comando.Parameters.AddWithValue("@grao", txtgrao.Text)
            comando.Parameters.AddWithValue("@normagrao", txtnormagrao.Text)
            comando.Parameters.AddWithValue("@observacao", txtobservacao.Text)
            comando.Parameters.AddWithValue("@microestrutura", txtmicroestrutura.Text)
            comando.Parameters.AddWithValue("@afina", txtafina.Text)
            comando.Parameters.AddWithValue("@bfina", txtbfina.Text)
            comando.Parameters.AddWithValue("@cfina", txtcfina.Text)
            comando.Parameters.AddWithValue("@dfina", txtdfina.Text)
            comando.Parameters.AddWithValue("@agrossa", txtagrossa.Text)
            comando.Parameters.AddWithValue("@bgrossa", txtbgrossa.Text)
            comando.Parameters.AddWithValue("@cgrossa", txtcgrossa.Text)
            comando.Parameters.AddWithValue("@dgrossa", txtdgrossa.Text)
            comando.Parameters.AddWithValue("@workorder", txtwo.Text)
            conexaoo.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
        MsgBox("Certificado Atualizado")
    End Sub

    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs) Handles BindingSource1.CurrentChanged

    End Sub

    Private Sub txtnumerocertificado_TextChanged(sender As Object, e As EventArgs) Handles txtnumerocertificado.TextChanged

    End Sub

    Private Sub txtespecificacao_TextChanged(sender As Object, e As EventArgs) Handles txtespecificacao.TextChanged

    End Sub

    Private Sub txtano_TextChanged(sender As Object, e As EventArgs) Handles txtano.TextChanged

    End Sub

    Private Sub txtalongamento_TextChanged(sender As Object, e As EventArgs) Handles txtalongamento.TextChanged

    End Sub

    Private Sub btnincluirlote_Click(sender As Object, e As EventArgs) Handles btnincluirlote.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub txttipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txttipo.SelectedIndexChanged

    End Sub
End Class