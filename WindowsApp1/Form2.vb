Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Data
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

Public Class frm_emitircertificado

    Private _campos As Dictionary(Of String, Control)
    Private _registroCarregado As DataRow
    Private _idAtual As Integer = 0
    Private _emEdicao As Boolean = False
    Private _dataChegada As Object = DBNull.Value

    Private Sub frm_emitircertificado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Try
            SessaoAtual.ExigirAutenticado()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Acesso")
            Close()
            Return
        End Try
        _campos = New Dictionary(Of String, Control) From {
            {"WORK_ORDER", txtwo}, {"HEAT_NUMBER", txtcorrida},
            {"QTDE", txtquantidade}, {"ESPECIFICACAO", txtespecificacao},
            {"SIZE_A", txtdimensao}, {"TOLERANCIA", txttolerancia},
            {"OBS", txtobservacao}, {"AGN_IN_CODIGO", txtcodfornecedor},
            {"WORK_ORDER_1", txtlote}, {"COD_CLI", txtcodigocliente},
            {"PED_CLI", txtnumerodopedido}, {"NF", txtnotafiscal},
            {"LIGA_MATERIAL", txtliga}, {"TRAT_TERMICO", txttratamentotermico},
            {"ACABAMENTO", txtacabamento}, {"COMPRIMENTO", txtcomprimento},
            {"PESO", txtpeso}, {"ALONG", txtalongamento},
            {"ESCOAMENTO", txtescoamento}, {"RES_ATRACAO", txtracao},
            {"MICROESTRUTURA", txtmicroestrutura}, {"PRODUTO", txttipo},
            {"ESP_GRAO", txtnormagrao}, {"OBT_GRAO", txtgrao},
            {"DUREZA", txtdureza}, {"A_FINA", txtafina},
            {"B_FINA", txtbfina}, {"C_FINA", txtcfina},
            {"D_FINA", txtdfina}, {"A_GROSSA", txtagrossa},
            {"B_GROSSA", txtbgrossa}, {"C_GROSSA", txtcgrossa},
            {"D_GROSSA", txtdgrossa}, {"NOME_ABRV", txtfornecedor},
            {"ANO_CERT", txtano}, {"TIPO_PESO", txtunidadedepeso},
            {"REDUCAODEAREA", txtreducaoarea}
        }
        txtnumerocertificado.ReadOnly = True
        txtwo.ReadOnly = True
        txtnomecliente.ReadOnly = True
        LimparCampos()
        DefinirEdicao(False)
    End Sub

    Private Sub DefinirEdicao(editar As Boolean)
        _emEdicao = editar
        For Each campo As Control In _campos.Values
            campo.Enabled = editar
        Next
        txtwo.Enabled = False
        txtnumerocertificado.Enabled = True
        txtnomecliente.Enabled = True
        btnincluir.Text = "Incluir"
        btneditar.Text = "Editar"
        btnincluir.Enabled = Not editar
        btnbuscar.Enabled = Not editar
        txtprocurar.Enabled = Not editar
        btneditar.Enabled = Not editar AndAlso _idAtual > 0
        btnsalvar.Enabled = editar AndAlso _idAtual = 0
        btnatualizar.Enabled = editar AndAlso _idAtual > 0
        btncancelar.Enabled = editar
        btnprocurar.Enabled = editar
        btnprocurarcliente.Enabled = editar
        btnprocurarofornecedor.Enabled = editar
        ' Estes dois botoes nao tinham uma operacao implementada no codigo original.
        btnexcluir.Enabled = False
        btnincluirlote.Enabled = False
    End Sub

    Private Sub ColocarTexto(controle As Control, texto As String)
        Dim lista As ComboBox = TryCast(controle, ComboBox)
        If lista IsNot Nothing Then
            lista.SelectedIndex = -1
            If texto <> "" AndAlso lista.DropDownStyle = ComboBoxStyle.DropDownList AndAlso
                Not lista.Items.Contains(texto) Then
                lista.Items.Add(texto)
            End If
        End If
        controle.Text = texto
    End Sub

    Private Sub LimparCampos()
        _dataChegada = DBNull.Value
        For Each campo As Control In _campos.Values
            ColocarTexto(campo, String.Empty)
        Next
        txtnumerocertificado.Clear()
        txtnomecliente.Clear()
    End Sub

    Private Function TextoRegistro(registro As DataRow, coluna As String) As String
        If registro.IsNull(coluna) Then Return String.Empty
        Return Convert.ToString(registro(coluna), CultureInfo.CurrentCulture)
    End Function

    Private Sub MostrarRegistro(registro As DataRow)
        _dataChegada = registro("SHIPMENT_DATE")
        For Each campo As KeyValuePair(Of String, Control) In _campos
            ColocarTexto(campo.Value, TextoRegistro(registro, campo.Key))
        Next
        _idAtual = Convert.ToInt32(registro("ID"))
        txtnumerocertificado.Text = _idAtual.ToString()
        txtprocurar.Text = _idAtual.ToString()
        txtnomecliente.Clear()
    End Sub

    Private Function Consultar(sql As String, parametro As String, valor As Object) As DataTable
        Dim tabela As New DataTable()
        Using cn As MySqlConnection = conexao.NovaConexao()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue(parametro, valor)
                cn.Open()
                Using leitor As MySqlDataReader = cmd.ExecuteReader()
                    tabela.Load(leitor)
                End Using
            End Using
        End Using
        Return tabela
    End Function

    Private Sub BuscarCertificado_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        If _emEdicao Then Return
        Dim numero As Integer
        If Not Integer.TryParse(txtprocurar.Text.Trim(), numero) OrElse numero <= 0 Then
            MessageBox.Show("Informe um numero de certificado valido.", "Consulta")
            Return
        End If
        Try
            Dim tabela As DataTable = Consultar(
                "SELECT * FROM emissaodecertificado WHERE ID = @id", "@id", numero)
            If tabela.Rows.Count = 0 Then
                MessageBox.Show("Certificado nao encontrado. Os dados exibidos foram mantidos.", "Consulta")
                Return
            End If
            _registroCarregado = tabela.Rows(0)
            MostrarRegistro(_registroCarregado)
            DefinirEdicao(False)
            CarregarCliente(False)
        Catch ex As Exception
            MessageBox.Show("Nao foi possivel consultar o certificado." & vbCrLf & ex.Message, "Consulta")
        End Try
    End Sub

    Private Sub IncluirCertificado_Click(sender As Object, e As EventArgs) Handles btnincluir.Click
        If _emEdicao Then Return
        _idAtual = 0
        _registroCarregado = Nothing
        LimparCampos()
        txtprocurar.Clear()
        txtano.Text = Date.Today.Year.ToString()
        ColocarTexto(txttipo, "Barra Redonda")
        ColocarTexto(txtacabamento, "Retificado")
        DefinirEdicao(True)
        txtlote.Focus()
    End Sub

    Private Sub EditarCertificado_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        If _emEdicao OrElse _idAtual <= 0 Then Return
        DefinirEdicao(True)
        txtobservacao.Focus()
    End Sub

    Private Sub CancelarCertificado_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        If Not _emEdicao Then Return
        If MessageBox.Show("Descartar as alteracoes que ainda nao foram salvas?", "Cancelar",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        If _registroCarregado IsNot Nothing Then
            MostrarRegistro(_registroCarregado)
            CarregarCliente(False)
        Else
            _idAtual = 0
            LimparCampos()
        End If
        DefinirEdicao(False)
    End Sub

    Private Function ValorParaBanco(coluna As String, controle As Control) As Object
        Dim texto As String = controle.Text.Trim()
        If texto = "" Then Return DBNull.Value
        Select Case coluna
            Case "WORK_ORDER", "AGN_IN_CODIGO", "COD_CLI", "NF",
                 "ESCOAMENTO", "RES_ATRACAO", "REDUCAODEAREA"
                Dim inteiro As Integer
                If Not Integer.TryParse(texto, NumberStyles.Integer, CultureInfo.CurrentCulture, inteiro) Then
                    controle.Focus()
                    Throw New ArgumentException("O campo " & coluna & " aceita somente um numero inteiro. Valor informado: " & texto)
                End If
                Return inteiro
            Case "ALONG"
                Dim alongamento As Decimal
                If Not Decimal.TryParse(texto.Replace(",", "."),
                                        NumberStyles.AllowLeadingSign Or NumberStyles.AllowDecimalPoint,
                                        CultureInfo.InvariantCulture, alongamento) Then
                    controle.Focus()
                    Throw New ArgumentException("O alongamento deve ser um numero, como 15,7 ou 15.7, sem separador de milhar.")
                End If
                If Decimal.Round(alongamento, 4) <> alongamento Then
                    controle.Focus()
                    Throw New ArgumentException("O alongamento pode ter no maximo quatro casas decimais.")
                End If
                Return alongamento
            Case "A_FINA", "B_FINA", "C_FINA", "D_FINA",
                 "A_GROSSA", "B_GROSSA", "C_GROSSA", "D_GROSSA"
                Dim numero As Double
                If Not Double.TryParse(texto.Replace(",", "."), NumberStyles.AllowLeadingSign Or NumberStyles.AllowDecimalPoint,
                                       CultureInfo.InvariantCulture, numero) OrElse
                    Double.IsNaN(numero) OrElse Double.IsInfinity(numero) Then
                    controle.Focus()
                    Throw New ArgumentException("O campo " & coluna & " aceita um numero com virgula ou ponto, sem separador de milhar.")
                End If
                Return numero
        End Select
        If coluna = "WORK_ORDER_1" Then Return texto
        Return controle.Text
    End Function

    Private Sub SalvarCertificado_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click
        If Not _emEdicao OrElse _idAtual <> 0 Then Return
        GravarCertificado(False)
    End Sub

    Private Sub AtualizarCertificado_Click(sender As Object, e As EventArgs) Handles btnatualizar.Click
        If Not _emEdicao OrElse _idAtual <= 0 Then Return
        GravarCertificado(True)
    End Sub

    Private Sub GravarCertificado(atualizar As Boolean)
        Try
            SessaoAtual.ExigirAutenticado()
            If String.IsNullOrWhiteSpace(txtlote.Text) Then
                txtlote.Focus()
                Throw New ArgumentException("Informe o lote do certificado.")
            End If
            If txtlote.Text.Trim().Length > 255 Then
                Throw New ArgumentException("O lote pode ter no maximo 255 caracteres.")
            End If
            If String.IsNullOrWhiteSpace(txtano.Text) Then
                txtano.Focus()
                Throw New ArgumentException("Informe o ano do certificado.")
            End If

            Dim colunas As New List(Of String)()
            Dim parametros As New List(Of String)()
            Dim atribuicoes As New List(Of String)()
            Dim valores As New Dictionary(Of String, Object)()
            For Each campo As KeyValuePair(Of String, Control) In _campos
                colunas.Add("`" & campo.Key & "`")
                parametros.Add("@" & campo.Key)
                atribuicoes.Add("`" & campo.Key & "` = @" & campo.Key)
                valores.Add(campo.Key, ValorParaBanco(campo.Key, campo.Value))
            Next

            ' A data de chegada acompanha a emissao mesmo sem um controle visual.
            valores.Add("SHIPMENT_DATE", _dataChegada)
            valores.Add("USUARIO_ATUALIZACAO", SessaoAtual.Login)
            valores.Add("DATA_ATUALIZACAO", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            For Each coluna As String In New String() {"SHIPMENT_DATE", "USUARIO_ATUALIZACAO", "DATA_ATUALIZACAO"}
                colunas.Add("`" & coluna & "`")
                parametros.Add("@" & coluna)
                atribuicoes.Add("`" & coluna & "` = @" & coluna)
            Next

            Dim sql As String
            If atualizar Then
                sql = "UPDATE emissaodecertificado SET " & String.Join(", ", atribuicoes.ToArray()) & " WHERE ID = @id"
            Else
                sql = "INSERT INTO emissaodecertificado (" & String.Join(", ", colunas.ToArray()) &
                      ") VALUES (" & String.Join(", ", parametros.ToArray()) & ")"
            End If

            Dim idSalvo As Integer = _idAtual
            Using cn As MySqlConnection = conexao.NovaConexao()
                cn.Open()
                Using transacao As MySqlTransaction = cn.BeginTransaction()
                    If atualizar Then
                        Using verificar As New MySqlCommand("SELECT ID FROM emissaodecertificado WHERE ID = @id FOR UPDATE", cn, transacao)
                            verificar.Parameters.AddWithValue("@id", _idAtual)
                            If verificar.ExecuteScalar() Is Nothing Then
                                Throw New InvalidOperationException("Este certificado nao existe mais no banco. Consulte novamente.")
                            End If
                        End Using
                    End If
                    Using cmd As New MySqlCommand(sql, cn, transacao)
                        For Each valor As KeyValuePair(Of String, Object) In valores
                            cmd.Parameters.AddWithValue("@" & valor.Key, valor.Value)
                        Next
                        If atualizar Then cmd.Parameters.AddWithValue("@id", _idAtual)
                        cmd.ExecuteNonQuery()
                        If Not atualizar Then idSalvo = Convert.ToInt32(cmd.LastInsertedId)
                    End Using
                    transacao.Commit()
                End Using
            End Using

            _idAtual = idSalvo
            txtnumerocertificado.Text = idSalvo.ToString()
            txtprocurar.Text = idSalvo.ToString()
            ' Guarda uma copia dos dados salvos para o botao Cancelar.
            Dim copia As New DataTable()
            copia.Columns.Add("ID", GetType(Integer))
            For Each coluna As String In valores.Keys
                copia.Columns.Add(coluna, GetType(Object))
            Next
            Dim registro As DataRow = copia.NewRow()
            registro("ID") = idSalvo
            For Each valor As KeyValuePair(Of String, Object) In valores
                registro(valor.Key) = valor.Value
            Next
            copia.Rows.Add(registro)
            _registroCarregado = registro
            DefinirEdicao(False)
            Dim mensagem As String = If(atualizar, "Certificado atualizado com sucesso!", "Certificado salvo com sucesso!")
            MessageBox.Show(mensagem & vbCrLf & "Numero: " & idSalvo.ToString(), "Emissao de certificado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Nao foi possivel concluir a gravacao." & vbCrLf & ex.Message & vbCrLf &
                            "Os campos foram mantidos para correcao.", "Emissao de certificado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProcurarLote_Click(sender As Object, e As EventArgs) Handles btnprocurar.Click
        If Not _emEdicao Then Return
        Dim lote As String = txtlote.Text.Trim()
        If lote = "" Then
            MessageBox.Show("Informe o lote para procurar.", "Lote")
            Return
        End If
        Try
            Dim tabela As DataTable = Consultar(
                "SELECT * FROM cadastrocertificados WHERE TRIM(WORK_ORDER_1) = @lote ORDER BY WORK_ORDER", "@lote", lote)
            If tabela.Rows.Count = 0 Then
                MessageBox.Show("Lote nao encontrado. Os demais campos foram mantidos.", "Lote")
                Return
            End If
            Dim escolhido As DataRow = tabela.Rows(0)
            If tabela.Rows.Count > 1 Then
                Dim aviso As New StringBuilder("Este lote possui mais de um cadastro antigo. Informe o ID desejado:" & vbCrLf)
                For Each registro As DataRow In tabela.Rows
                    aviso.AppendLine("ID " & TextoRegistro(registro, "WORK_ORDER") & " | Ano " &
                                     TextoRegistro(registro, "ANO_CERT") & " | Corrida " &
                                     TextoRegistro(registro, "HEAT_NUMBER") & " | Dimensao " & TextoRegistro(registro, "SIZE_A"))
                Next
                Dim resposta As String = Microsoft.VisualBasic.Interaction.InputBox(aviso.ToString(), "Selecionar cadastro do lote")
                If resposta.Trim() = "" Then Return
                Dim idEscolhido As Integer
                If Not Integer.TryParse(resposta.Trim(), idEscolhido) Then
                    MessageBox.Show("Informe um dos IDs apresentados.", "Lote")
                    Return
                End If
                escolhido = Nothing
                For Each registro As DataRow In tabela.Rows
                    If Convert.ToInt32(registro("WORK_ORDER")) = idEscolhido Then
                        escolhido = registro
                        Exit For
                    End If
                Next
                If escolhido Is Nothing Then
                    MessageBox.Show("O ID informado nao pertence a este lote.", "Lote")
                    Return
                End If
            End If

            Dim camposOrigem As String() = {"WORK_ORDER", "HEAT_NUMBER", "AGN_IN_CODIGO", "WORK_ORDER_1",
                "ESPECIFICACAO", "SIZE_A", "TOLERANCIA", "OBS", "TRAT_TERMICO", "ACABAMENTO", "PRODUTO",
                "ESP_GRAO", "OBT_GRAO", "COMPRIMENTO", "ALONG", "ESCOAMENTO", "RES_ATRACAO",
                "DUREZA", "MICROESTRUTURA", "A_FINA", "B_FINA", "C_FINA", "D_FINA",
                "A_GROSSA", "B_GROSSA", "C_GROSSA", "D_GROSSA"}
            For Each coluna As String In camposOrigem
                ColocarTexto(_campos(coluna), TextoRegistro(escolhido, coluna))
            Next
            _dataChegada = escolhido("SHIPMENT_DATE")
            txtreducaoarea.Text = TextoRegistro(escolhido, "REDUCAOAREA")
            txtfornecedor.Clear()
            ColocarTexto(txtliga, String.Empty)
            Select Case txtespecificacao.Text.Trim()
                Case "ASTM F1537 / NBR ISO 5832-12"
                    ColocarTexto(txtliga, "Cobalto - Cromo")
                Case "ASTM F899 303", "ASTM F899 S42010", "ASTM F899 440C", "ASTM F899 455 XM-16"
                    ColocarTexto(txtliga, "Aço Inoxidável")
                Case "ASTM F67-Gr1 e ISO 5832-2", "ASTM F67-Gr2 e ISO 5832-2", "ASTM F67-Gr4 e ISO 5832-2"
                    ColocarTexto(txtliga, "Titânio Puro")
                Case "ASTM F136 e ISO 5832-3"
                    ColocarTexto(txtliga, "Titânio 6Al 4V ELI")
                Case "ASTM F2063"
                    ColocarTexto(txtliga, "Níquel - Titânio")
            End Select
            ' Ano, cliente, NF, pedido, quantidade e peso da emissao sao preservados.
            ' O tratamento termico vem do cadastro; nao se presume "Recozido".
        Catch ex As Exception
            MessageBox.Show("Nao foi possivel consultar o lote." & vbCrLf & ex.Message, "Lote")
        End Try
    End Sub

    Private Sub ProcurarCliente_Click(sender As Object, e As EventArgs) Handles btnprocurarcliente.Click
        If Not _emEdicao Then Return
        CarregarCliente(True)
    End Sub

    Private Sub CarregarCliente(avisar As Boolean)
        txtnomecliente.Clear()
        Dim codigo As Integer
        If Not Integer.TryParse(txtcodigocliente.Text.Trim(), codigo) OrElse codigo <= 0 Then
            If avisar Then MessageBox.Show("Informe um codigo de cliente valido.", "Cliente")
            Return
        End If
        Try
            Dim tabela As DataTable = Consultar("SELECT nome FROM clientes WHERE codigo = @codigo", "@codigo", codigo)
            If tabela.Rows.Count > 0 Then
                txtnomecliente.Text = TextoRegistro(tabela.Rows(0), "nome")
            ElseIf avisar Then
                MessageBox.Show("Cliente nao encontrado.", "Cliente")
            End If
        Catch ex As Exception
            If avisar Then MessageBox.Show("Nao foi possivel consultar o cliente." & vbCrLf & ex.Message, "Cliente")
        End Try
    End Sub

    Private Sub CodigoClienteAlterado(sender As Object, e As EventArgs) Handles txtcodigocliente.TextChanged
        txtnomecliente.Clear()
    End Sub

    Private Sub ProcurarFornecedor_Click(sender As Object, e As EventArgs) Handles btnprocurarofornecedor.Click
        If _emEdicao Then frmprocurarlote.Show()
    End Sub

End Class

