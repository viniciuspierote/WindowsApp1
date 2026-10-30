Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class frmcadastro
    Private conexaoo As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSQL As String
    Private _editorNormas As EditorCadastroNormas
    Public loteglobal As String
    Private _dataChegadaLegada As Object = DBNull.Value
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtcorrida.TextChanged, txtsalesorder.TextChanged

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        '
    End Sub

    Private Sub btnprocurar_Click(sender As Object, e As EventArgs) Handles btnprocurar.Click
        Dim cq = txtworkorder1.Text
        If Not ConfirmarDescarteAnexos() Then Return
        LimparAnexosPdf(False)
        Dim encontrou As Boolean = False

        Try
            conexaoo = conexao.NovaConexao()
            strSQL = "SELECT * from cadastrocertificados WHERE Work_Order_1 = @Work_Order_1"
            comando = New MySqlCommand(strSQL, conexaoo)
            comando.Parameters.AddWithValue("@Work_Order_1", txtworkorder1.Text)
            conexaoo.Open()
            dr = comando.ExecuteReader()

            If dr.Read() Then ' Verificar se há registros antes de ler os campos
                encontrou = True
                txtcorrida.Text = If(Not IsDBNull(dr("Heat_Number")), dr("Heat_Number").ToString(), String.Empty)
                txtid.Text = If(Not IsDBNull(dr("work_order")), dr("work_order").ToString(), String.Empty)
                txtworkorder1.Text = Convert.ToString(dr("WORK_ORDER_1"))
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
                txtdureza.Text = If(Not IsDBNull(dr("dureza")), dr("dureza").ToString(), String.Empty)
                txtreducaoarea.Text = If(Not IsDBNull(dr("reducaoarea")), dr("reducaoarea").ToString(), String.Empty)
                txttratamentotermico.Text = Convert.ToString(dr("TRAT_TERMICO"))
                txtacabamento.Text = Convert.ToString(dr("ACABAMENTO"))
                ComboBox1.Text = Convert.ToString(dr("PRODUTO"))
                txtArquivoAnalise.Text = Convert.ToString(dr("USUARIO_ATUALIZACAO"))
                _dataChegadaLegada = DBNull.Value
                If Not PreencherDataCadastro(DateTimePicker1, dr("SHIPMENT_DATE")) Then
                    _dataChegadaLegada = dr("SHIPMENT_DATE")
                End If
                PreencherDataCadastro(dttime, dr("DATA_ATUALIZACAO"))
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
                txtdureza.Text = String.Empty
                txtreducaoarea.Text = String.Empty
                txttratamentotermico.Text = String.Empty
                txtacabamento.Text = String.Empty
                ComboBox1.Text = String.Empty
                txtArquivoAnalise.Clear()
                DateTimePicker1.Checked = False
                dttime.Checked = False
                _dataChegadaLegada = DBNull.Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexaoo.Close()
            conexaoo = Nothing
            comando = Nothing
        End Try
        If encontrou Then

            Try
                CarregarAnexosPdf(Integer.Parse(txtid.Text))

            Catch ex As Exception
                LimparAnexosPdf(False)
                btnsalvar.Enabled = False
                btnatualizar.Enabled = False

                MessageBox.Show(
            "Não foi possível carregar os anexos." &
            vbCrLf & ex.Message,
            "Anexos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

                Return
            End Try

            btnsalvar.Enabled = False
            btnatualizar.Enabled = True

            TabPage3.Enabled = True

            CarregarComposicaoQuimica()

            If _editorNormas IsNot Nothing Then
                Try
                    _editorNormas.Carregar(Integer.Parse(txtid.Text))

                Catch ex As Exception
                    btnsalvar.Enabled = False
                    btnatualizar.Enabled = False
                    MessageBox.Show(ex.Message, "Cadastro")
                End Try
            End If

        Else
            btnsalvar.Enabled = False
            btnatualizar.Enabled = False

            If _editorNormas IsNot Nothing Then _editorNormas.Novo()

            TabPage3.Enabled = False
            dgvdados.DataSource = Nothing

            MessageBox.Show(
        "Lote não encontrado. Para cadastrar um novo, clique em Inserir.")
        End If
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
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Try
            SessaoAtual.ExigirAutenticado()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acesso")
            Close()
            Return
        End Try

        DateTimePicker1.ShowCheckBox = True
        dttime.ShowCheckBox = True
        dttime.Format = DateTimePickerFormat.Custom
        dttime.CustomFormat = "dd/MM/yyyy HH:mm"
        dttime.Enabled = False
        txtArquivoAnalise.ReadOnly = True
        Label24.Text = "Atualizado em:"
        PrepararNovoCadastro()
        Try
            _editorNormas = New EditorCadastroNormas(Me)
        Catch ex As Exception
            btnsalvar.Enabled = False
            btnatualizar.Enabled = False
            MessageBox.Show("Nao foi possivel carregar a tela de normas. Detalhe do erro:" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub btnatualizar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btninserir_Click(sender As Object, e As EventArgs) Handles btninserir.Click

        Dim resposta = MessageBox.Show(
        "Iniciar um novo cadastro? " &
        "Os dados ainda não salvos na tela serão descartados.",
        "Novo cadastro",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        If resposta = DialogResult.Yes Then
            PrepararNovoCadastro()
        End If

    End Sub

    Private Sub btnsalvar_Click(
    sender As Object,
    e As EventArgs) Handles btnsalvar.Click

        If Not String.IsNullOrWhiteSpace(txtid.Text) Then
            MessageBox.Show(
            "Este cadastro já possui um ID. Use Atualizar ou clique em Inserir.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtworkorder1.Text) Then
            MessageBox.Show("Informe o lote / Work Order.")
            txtworkorder1.Focus()
            Return
        End If

        Dim codigoFornecedor As Integer

        If Not String.IsNullOrWhiteSpace(txtcodfornecedor.Text) AndAlso
        Not Integer.TryParse(txtcodfornecedor.Text.Trim(), codigoFornecedor) Then

            MessageBox.Show("O código do fornecedor deve ser um número inteiro.")
            Return
        End If

        Try
            SessaoAtual.ExigirAutenticado()
            If _editorNormas IsNot Nothing Then _editorNormas.PrepararGravacao()
            Using cn As MySqlConnection = conexao.NovaConexao()

                Dim sql As String =
                "INSERT INTO cadastrocertificados (" &
                "HEAT_NUMBER, SALES_ORDER, CUSTOMER_PO, QTDE, " &
                "ESPECIFICACAO, SIZE_A, TOLERANCIA, OBS, " &
                "AGN_IN_CODIGO, WORK_ORDER_1, ESP_GRAO, OBT_GRAO, " &
                "DUREZA, ALONG, ESCOAMENTO, RES_ATRACAO, " &
                "A_FINA, B_FINA, C_FINA, D_FINA, " &
                "A_GROSSA, B_GROSSA, C_GROSSA, D_GROSSA, " &
                "MICROESTRUTURA, COMPRIMENTO, ANO_CERT, REDUCAOAREA, " &
                "SHIPMENT_DATE, TRAT_TERMICO, ACABAMENTO, PRODUTO, " &
                "USUARIO_ATUALIZACAO, DATA_ATUALIZACAO" &
                ") VALUES (" &
                "@corrida, @salesorder, @customer, @quantidade, " &
                "@especificacao, @dimensao, @tolerancia, @observacao, " &
                "@codfornecedor, @lote, @especificacaograo, @tamanhograo, " &
                "@dureza, @alongamento, @escoamento, @tracao, " &
                "@afina, @bfina, @cfina, @dfina, " &
                "@agrossa, @bgrossa, @cgrossa, @dgrossa, " &
                "@microestrutura, @comprimento, @ano, @reducaoarea, " &
                "@dataChegada, @tratamento, @acabamento, @produto, " &
                "@usuarioAtualizacao, @dataAtualizacao)"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue("@corrida", txtcorrida.Text)
                    cmd.Parameters.AddWithValue("@salesorder", txtsalesorder.Text)
                    cmd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                    cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text)
                    cmd.Parameters.AddWithValue("@especificacao", txtespecificacao.Text)
                    cmd.Parameters.AddWithValue("@dimensao", txtdimensao.Text)
                    cmd.Parameters.AddWithValue("@tolerancia", txttolerancia.Text)
                    cmd.Parameters.AddWithValue("@observacao", txtobservacao.Text)

                    cmd.Parameters.AddWithValue(
                    "@codfornecedor",
                    If(String.IsNullOrWhiteSpace(txtcodfornecedor.Text),
                       CType(DBNull.Value, Object),
                       CType(codigoFornecedor, Object)))

                    cmd.Parameters.AddWithValue("@lote", txtworkorder1.Text.Trim())
                    cmd.Parameters.AddWithValue("@especificacaograo", txtespecificacaograo.Text)
                    cmd.Parameters.AddWithValue("@tamanhograo", txttamanhograo.Text)
                    cmd.Parameters.AddWithValue("@dureza", txtdureza.Text)
                    cmd.Parameters.AddWithValue("@alongamento", txtalongamento.Text)
                    cmd.Parameters.AddWithValue("@escoamento", txtescoamento.Text)
                    cmd.Parameters.AddWithValue("@tracao", txttracao.Text)
                    cmd.Parameters.AddWithValue("@afina", txtafina.Text)
                    cmd.Parameters.AddWithValue("@bfina", txtbfina.Text)
                    cmd.Parameters.AddWithValue("@cfina", txtcfina.Text)
                    cmd.Parameters.AddWithValue("@dfina", txtdfina.Text)
                    cmd.Parameters.AddWithValue("@agrossa", txtagrossa.Text)
                    cmd.Parameters.AddWithValue("@bgrossa", txtbgrossa.Text)
                    cmd.Parameters.AddWithValue("@cgrossa", txtcgrossa.Text)
                    cmd.Parameters.AddWithValue("@dgrossa", txtdgrossa.Text)
                    cmd.Parameters.AddWithValue("@microestrutura", txtmicroestrutura.Text)
                    cmd.Parameters.AddWithValue("@comprimento", txtcomprimento.Text)
                    cmd.Parameters.AddWithValue("@ano", txtanocertificado.Text)
                    cmd.Parameters.AddWithValue("@reducaoarea", txtreducaoarea.Text)
                    Dim instanteGravacao As DateTime = DateTime.Now
                    cmd.Parameters.AddWithValue("@dataChegada", ObterDataChegadaCadastro())
                    cmd.Parameters.AddWithValue("@tratamento", txttratamentotermico.Text)
                    cmd.Parameters.AddWithValue("@acabamento", txtacabamento.Text)
                    cmd.Parameters.AddWithValue("@produto", ComboBox1.Text)
                    cmd.Parameters.AddWithValue("@usuarioAtualizacao", SessaoAtual.Login)
                    cmd.Parameters.AddWithValue("@dataAtualizacao",
                        instanteGravacao.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))

                    cn.Open()
                    GravarSemRepetirLote(cmd, txtworkorder1.Text)

                    ' Número gerado pelo AUTO_INCREMENT do MySQL.
                    txtid.Text = cmd.LastInsertedId.ToString()
                    MostrarAuditoriaCadastro(instanteGravacao)

                    btnsalvar.Enabled = False
                    btnatualizar.Enabled = True

                    TabPage3.Enabled = True
                    btncadastrarcomposicao.Enabled = True

                End Using
            End Using

            MessageBox.Show(
            "Cadastro salvo com sucesso! ID: " & txtid.Text,
            "Cadastro",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(
            "Não foi possível salvar o cadastro." &
            vbCrLf & ex.Message,
            "Cadastro",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnatualizar_Click_1(
    sender As Object,
    e As EventArgs) Handles btnatualizar.Click

        Dim idCadastro As Integer

        If Not Integer.TryParse(txtid.Text, idCadastro) OrElse idCadastro <= 0 Then
            MessageBox.Show(
            "Consulte um cadastro existente ou salve o novo cadastro primeiro.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtworkorder1.Text) Then
            MessageBox.Show("Informe o lote / Work Order.")
            txtworkorder1.Focus()
            Return
        End If

        Dim codigoFornecedor As Integer

        If Not String.IsNullOrWhiteSpace(txtcodfornecedor.Text) AndAlso
        Not Integer.TryParse(txtcodfornecedor.Text.Trim(), codigoFornecedor) Then

            MessageBox.Show("O código do fornecedor deve ser um número inteiro.")
            Return
        End If

        Try
            SessaoAtual.ExigirAutenticado()
            If _editorNormas IsNot Nothing Then _editorNormas.PrepararGravacao()
            Using cn As MySqlConnection = conexao.NovaConexao()

                Dim sql As String =
                "UPDATE cadastrocertificados SET " &
                "HEAT_NUMBER = @corrida, SALES_ORDER = @salesorder, " &
                "CUSTOMER_PO = @customer, QTDE = @quantidade, " &
                "ESPECIFICACAO = @especificacao, SIZE_A = @dimensao, " &
                "TOLERANCIA = @tolerancia, OBS = @observacao, " &
                "AGN_IN_CODIGO = @codfornecedor, WORK_ORDER_1 = @lote, " &
                "ESP_GRAO = @especificacaograo, OBT_GRAO = @tamanhograo, " &
                "DUREZA = @dureza, ALONG = @alongamento, " &
                "ESCOAMENTO = @escoamento, RES_ATRACAO = @tracao, " &
                "A_FINA = @afina, B_FINA = @bfina, " &
                "C_FINA = @cfina, D_FINA = @dfina, " &
                "A_GROSSA = @agrossa, B_GROSSA = @bgrossa, " &
                "C_GROSSA = @cgrossa, D_GROSSA = @dgrossa, " &
                "MICROESTRUTURA = @microestrutura, COMPRIMENTO = @comprimento, " &
                "ANO_CERT = @ano, REDUCAOAREA = @reducaoarea, " &
                "SHIPMENT_DATE = @dataChegada, TRAT_TERMICO = @tratamento, " &
                "ACABAMENTO = @acabamento, PRODUTO = @produto, " &
                "USUARIO_ATUALIZACAO = @usuarioAtualizacao, " &
                "DATA_ATUALIZACAO = @dataAtualizacao " &
                "WHERE WORK_ORDER = @id"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue("@id", idCadastro)
                    cmd.Parameters.AddWithValue("@corrida", txtcorrida.Text)
                    cmd.Parameters.AddWithValue("@salesorder", txtsalesorder.Text)
                    cmd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                    cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text)
                    cmd.Parameters.AddWithValue("@especificacao", txtespecificacao.Text)
                    cmd.Parameters.AddWithValue("@dimensao", txtdimensao.Text)
                    cmd.Parameters.AddWithValue("@tolerancia", txttolerancia.Text)
                    cmd.Parameters.AddWithValue("@observacao", txtobservacao.Text)

                    cmd.Parameters.AddWithValue(
                    "@codfornecedor",
                    If(String.IsNullOrWhiteSpace(txtcodfornecedor.Text),
                       CType(DBNull.Value, Object),
                       CType(codigoFornecedor, Object)))

                    cmd.Parameters.AddWithValue("@lote", txtworkorder1.Text.Trim())
                    cmd.Parameters.AddWithValue("@especificacaograo", txtespecificacaograo.Text)
                    cmd.Parameters.AddWithValue("@tamanhograo", txttamanhograo.Text)
                    cmd.Parameters.AddWithValue("@dureza", txtdureza.Text)
                    cmd.Parameters.AddWithValue("@alongamento", txtalongamento.Text)
                    cmd.Parameters.AddWithValue("@escoamento", txtescoamento.Text)
                    cmd.Parameters.AddWithValue("@tracao", txttracao.Text)
                    cmd.Parameters.AddWithValue("@afina", txtafina.Text)
                    cmd.Parameters.AddWithValue("@bfina", txtbfina.Text)
                    cmd.Parameters.AddWithValue("@cfina", txtcfina.Text)
                    cmd.Parameters.AddWithValue("@dfina", txtdfina.Text)
                    cmd.Parameters.AddWithValue("@agrossa", txtagrossa.Text)
                    cmd.Parameters.AddWithValue("@bgrossa", txtbgrossa.Text)
                    cmd.Parameters.AddWithValue("@cgrossa", txtcgrossa.Text)
                    cmd.Parameters.AddWithValue("@dgrossa", txtdgrossa.Text)
                    cmd.Parameters.AddWithValue("@microestrutura", txtmicroestrutura.Text)
                    cmd.Parameters.AddWithValue("@comprimento", txtcomprimento.Text)
                    cmd.Parameters.AddWithValue("@ano", txtanocertificado.Text)
                    cmd.Parameters.AddWithValue("@reducaoarea", txtreducaoarea.Text)
                    Dim instanteGravacao As DateTime = DateTime.Now
                    cmd.Parameters.AddWithValue("@dataChegada", ObterDataChegadaCadastro())
                    cmd.Parameters.AddWithValue("@tratamento", txttratamentotermico.Text)
                    cmd.Parameters.AddWithValue("@acabamento", txtacabamento.Text)
                    cmd.Parameters.AddWithValue("@produto", ComboBox1.Text)
                    cmd.Parameters.AddWithValue("@usuarioAtualizacao", SessaoAtual.Login)
                    cmd.Parameters.AddWithValue("@dataAtualizacao",
                        instanteGravacao.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))

                    cn.Open()

                    Dim quantidade As Integer =
                        GravarSemRepetirLote(cmd, txtworkorder1.Text, idCadastro)

                    If quantidade = 1 Then
                        MostrarAuditoriaCadastro(instanteGravacao)
                        MessageBox.Show(
                        "Cadastro atualizado com sucesso!",
                        "Cadastro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(
                        "O banco não informou uma alteração. " &
                        "Consulte o cadastro novamente para conferir os dados.",
                        "Cadastro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
            "Não foi possível atualizar o cadastro." &
            vbCrLf & ex.Message,
            "Cadastro",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnincluir.Click
        Try
            conexaoo = conexao.NovaConexao()
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
        txtworkorder.Text = txtid.Text

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            conexaoo = conexao.NovaConexao()
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
            conexaoo = conexao.NovaConexao()
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
            conexaoo = conexao.NovaConexao()
            strSQL = "UPDATE cadastrocompquimica SET VALOR = @valor WHERE WORK_ORDER = @work_order AND SEQUENCIA = @sequencia AND TIPO = @tipo"
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

    Private Sub txtworkorder1_Leave(sender As Object, e As EventArgs) Handles txtworkorder1.Leave
        If String.IsNullOrWhiteSpace(txtworkorder1.Text) Then Return

        Try
            Using cn As MySqlConnection = conexao.NovaConexao()

                Dim sql As String =
                "SELECT COUNT(*) FROM cadastrocertificados " &
                "WHERE WORK_ORDER_1 = @lote"

                If Not String.IsNullOrWhiteSpace(txtid.Text) Then
                    sql &= " AND WORK_ORDER <> @id"
                End If

                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@lote", txtworkorder1.Text.Trim())

                    If Not String.IsNullOrWhiteSpace(txtid.Text) Then
                        cmd.Parameters.AddWithValue("@id", txtid.Text.Trim())
                    End If

                    cn.Open()

                    Dim quantidade As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If quantidade > 0 Then
                        MessageBox.Show(
                            "O lote " & txtworkorder1.Text.Trim() &
                            " já está cadastrado no sistema.",
                            "Lote já cadastrado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                                        )
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao verificar o lote:" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub txtworkorder1_TextChanged(sender As Object, e As EventArgs) Handles txtworkorder1.TextChanged

    End Sub
    Private Sub CarregarComposicaoQuimica()

        If String.IsNullOrWhiteSpace(txtid.Text) Then
            dgvdados.DataSource = Nothing
            Exit Sub
        End If

        Try

            Using conexaoComp As MySqlConnection = conexao.NovaConexao()

                Dim sql As String =
                    "SELECT * FROM cadastrocompquimica " &
                    "WHERE WORK_ORDER = @work_order " &
                    "ORDER BY SEQUENCIA"

                Using cmd As New MySqlCommand(sql, conexaoComp)

                    cmd.Parameters.AddWithValue("@work_order", txtid.Text)

                    Dim dt As New DataTable
                    Dim adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(dt)

                    dgvdados.DataSource = dt

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Erro ao carregar composição química:" &
                vbCrLf & ex.Message
            )

        End Try

    End Sub

    Private Sub PrepararNovoCadastro()

        LimparAnexosPdf()

        Dim campos As Control() = {
            txtid, txtworkorder, txtworkorder1,
            txtcorrida, txtsalesorder, txtcustomer,
            txtcodfornecedor, txtnomefornecedor,
            txtquantidade, txtespecificacao,
            txtdimensao, txttolerancia,
            txtobservacao, txtmicroestrutura,
            txtcomprimento, txtanocertificado,
            txttamanhograo, txtespecificacaograo,
            txtalongamento, txtescoamento,
            txttracao, txtdureza, txtreducaoarea,
            txtafina, txtbfina, txtcfina, txtdfina,
            txtagrossa, txtbgrossa, txtcgrossa, txtdgrossa,
            txttratamentotermico, txtacabamento, ComboBox1,
            txtsequencia, txttipo, txtvalor
        }

        For Each campo As Control In campos
            campo.Text = String.Empty
        Next

        txtanocertificado.Text = Date.Today.Year.ToString()
        _dataChegadaLegada = DBNull.Value
        DateTimePicker1.Value = Date.Today
        DateTimePicker1.Checked = True
        MostrarAuditoriaCadastro(DateTime.Now)

        loteglobal = String.Empty
        dgvdados.DataSource = Nothing

        txtworkorder.ReadOnly = True

        btnsalvar.Enabled = True
        btnatualizar.Enabled = False

        ' A composição só poderá ser cadastrada após salvar o registro.
        TabPage3.Enabled = False
        btncadastrarcomposicao.Enabled = False

        TabControl1.SelectedTab = TabPage1
        txtworkorder1.Focus()
        If _editorNormas IsNot Nothing Then _editorNormas.Novo()

    End Sub

    Private Function PreencherDataCadastro(controle As DateTimePicker, valor As Object) As Boolean
        controle.Checked = False
        If valor Is Nothing OrElse Convert.IsDBNull(valor) OrElse
            String.IsNullOrWhiteSpace(Convert.ToString(valor)) Then Return True

        Dim data As DateTime
        Dim texto As String = Convert.ToString(valor)
        Dim formatos As String() = {"yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-ddTHH:mm:ss"}
        Dim conseguiu As Boolean = DateTime.TryParseExact(texto, formatos,
            CultureInfo.InvariantCulture, DateTimeStyles.None, data)
        If Not conseguiu Then
            conseguiu = DateTime.TryParse(texto, CultureInfo.GetCultureInfo("pt-BR"),
                                          DateTimeStyles.AllowWhiteSpaces, data)
        End If
        If Not conseguiu OrElse data < controle.MinDate OrElse data > controle.MaxDate Then Return False
        controle.Value = data
        controle.Checked = True
        Return True
    End Function

    Private Function ObterDataChegadaCadastro() As Object
        If DateTimePicker1.Checked Then
            Return DateTimePicker1.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        End If
        ' Conserva textos de datas antigas que nao puderam ser interpretados.
        Return _dataChegadaLegada
    End Function

    Private Sub MostrarAuditoriaCadastro(instante As DateTime)
        txtArquivoAnalise.Text = SessaoAtual.Login
        dttime.Value = instante
        dttime.Checked = True
    End Sub

    Private Function GravarSemRepetirLote(
    comandoGravacao As MySqlCommand,
    loteInformado As String,
    Optional idAtual As Integer = 0) As Integer

        Dim cn As MySqlConnection = comandoGravacao.Connection
        Dim lote As String = loteInformado.Trim()

        If String.IsNullOrWhiteSpace(lote) Then
            Throw New ArgumentException("Informe o lote / Work Order.")
        End If

        ' Usa uma trava compartilhada pelas gravações desta versão.
        Using obterTrava As New MySqlCommand(
            "SELECT GET_LOCK('sandinox_cadastro_lote', 5)", cn)

            Dim resultado As Object = obterTrava.ExecuteScalar()

            If resultado Is Nothing OrElse
                resultado Is DBNull.Value OrElse
                Convert.ToInt32(resultado) <> 1 Then

                Throw New InvalidOperationException(
                    "Outro cadastro está sendo gravado. Tente novamente.")
            End If

        End Using

        Try
            Dim manterLoteAtual As Boolean = False

            If idAtual > 0 Then
                ' Permite editar registros antigos mantendo o mesmo lote.
                Using consultarAtual As New MySqlCommand(
                    "SELECT 1 FROM cadastrocertificados " &
                    "WHERE WORK_ORDER = @id " &
                    "AND TRIM(WORK_ORDER_1) = @lote", cn)

                    consultarAtual.Parameters.AddWithValue("@id", idAtual)
                    consultarAtual.Parameters.AddWithValue("@lote", lote)

                    manterLoteAtual =
                        consultarAtual.ExecuteScalar() IsNot Nothing

                End Using
            End If

            If Not manterLoteAtual Then

                Using verificar As New MySqlCommand(
                    "SELECT COUNT(*) FROM cadastrocertificados " &
                    "WHERE TRIM(WORK_ORDER_1) = @lote " &
                    "AND WORK_ORDER <> @id", cn)

                    verificar.Parameters.AddWithValue("@lote", lote)
                    verificar.Parameters.AddWithValue("@id", idAtual)

                    Dim quantidade As Integer =
                        Convert.ToInt32(verificar.ExecuteScalar())

                    If quantidade > 0 Then
                        Throw New InvalidOperationException(
                            "O lote " & lote & " já está cadastrado. " &
                            "Consulte o cadastro existente para editar.")
                    End If

                End Using
            End If

            comandoGravacao.Parameters("@lote").Value = lote

            Dim afetados As Integer
            Using transacao As MySqlTransaction = cn.BeginTransaction()
                comandoGravacao.Transaction = transacao
                Try
                    afetados = comandoGravacao.ExecuteNonQuery()
                    Dim idGravado As Integer = If(idAtual > 0, idAtual, Convert.ToInt32(comandoGravacao.LastInsertedId))
                    If _editorNormas IsNot Nothing Then
                        _editorNormas.Gravar(cn, transacao, idGravado)
                        If idAtual > 0 Then afetados = 1
                    End If

                    GravarAnexosPdf(cn, transacao, idGravado)

                    transacao.Commit()

                    ConfirmarAnexosSalvos(idGravado)
                Catch
                    Try
                        transacao.Rollback()
                    Catch
                        ' A conexao pode ter sido interrompida; o erro original sera exibido.
                    End Try
                    Throw
                Finally
                    comandoGravacao.Transaction = Nothing
                End Try
            End Using
            Return afetados

        Finally
            Using liberarTrava As New MySqlCommand(
                "SELECT RELEASE_LOCK('sandinox_cadastro_lote')", cn)

                liberarTrava.ExecuteScalar()

            End Using
        End Try

    End Function

    Private Sub btncadastrarcomposicao_Click(sender As Object, e As EventArgs) Handles btncadastrarcomposicao.Click

    End Sub
End Class



