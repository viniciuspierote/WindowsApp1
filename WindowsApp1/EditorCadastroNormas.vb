Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class EditorCadastroNormas
    Private ReadOnly _form As frmcadastro
    Private ReadOnly _normas As DataTable
    Private ReadOnly _perfis As DataTable
    Private ReadOnly _propriedades As DataTable
    Private ReadOnly _norma As ComboBox
    Private ReadOnly _liga As ComboBox
    Private ReadOnly _condicao As ComboBox
    Private ReadOnly _quimica As DataGridView
    Private ReadOnly _mecanica As DataGridView
    Private ReadOnly _metalurgia As DataGridView
    Private ReadOnly _aviso As Label
    Private ReadOnly _espelho As New Dictionary(Of String, TextBox)()
    Private ReadOnly _espelhoMetal As New Dictionary(Of String, TextBox)()
    Private _perfil As DataRow
    Private _regras As New DataTable()
    Private _ocupado As Boolean
    Private _quimicaAntiga As New DataTable()

    Private Class LinhaResultado
        Public PropriedadeId As Integer
        Public Codigo As String
        Public Nome As String
        Public Grupo As String
        Public Valor As String = ""
        Public Unidade As String = ""
        Public Regra As DataRow
        Public SequenciaAntiga As String
        Public TipoAntigo As String
    End Class

    Public Sub New(formulario As frmcadastro)
        _form = formulario
        _norma = formulario.cboNormaCadastro
        _liga = formulario.cboLigaCadastro
        _condicao = formulario.cboCondicaoCadastro
        _aviso = formulario.lblAvisoNorma
        _quimica = formulario.gradeQuimicaNormas
        _mecanica = formulario.gradeMecanicaNormas
        _metalurgia = formulario.gradeMetalurgiaNormas
        _normas = Ler("SELECT id, CONCAT(entidade, ' ', codigo, '-', edicao) AS rotulo FROM cert_normas ORDER BY codigo")
        _perfis = Ler("SELECT * FROM cert_perfis_norma WHERE sistema_unidades='SI' ORDER BY material_grau_tipo, condicao_fornecimento, revisao DESC")
        _propriedades = Ler("SELECT * FROM cert_propriedades ORDER BY grupo, id")
        _espelho.Add("TRACAO", _form.txttracao)
        _espelho.Add("ESCOAMENTO_02", _form.txtescoamento)
        _espelho.Add("ALONGAMENTO", _form.txtalongamento)
        _espelho.Add("REDUCAO_AREA", _form.txtreducaoarea)
        _espelhoMetal.Add("GRAO_ASTM", _form.txttamanhograo)
        _espelhoMetal.Add("INCLUSAO_A_FINA", _form.txtafina)
        _espelhoMetal.Add("INCLUSAO_A_GROSSA", _form.txtagrossa)
        _espelhoMetal.Add("INCLUSAO_B_FINA", _form.txtbfina)
        _espelhoMetal.Add("INCLUSAO_B_GROSSA", _form.txtbgrossa)
        _espelhoMetal.Add("INCLUSAO_C_FINA", _form.txtcfina)
        _espelhoMetal.Add("INCLUSAO_C_GROSSA", _form.txtcgrossa)
        _espelhoMetal.Add("INCLUSAO_D_FINA", _form.txtdfina)
        _espelhoMetal.Add("INCLUSAO_D_GROSSA", _form.txtdgrossa)
        _espelhoMetal.Add("MICROESTRUTURA", _form.txtmicroestrutura)
        For Each codigo As String In _espelhoMetal.Keys
            If AcharPropriedade(codigo) Is Nothing Then Throw New InvalidOperationException("Execute o SQL 005 antes de abrir esta tela: falta " & codigo)
        Next
        _norma.DisplayMember = "rotulo"
        _norma.ValueMember = "id"
        _norma.DataSource = _normas
        _norma.SelectedIndex = -1
        _condicao.DropDownWidth = 850
        ConfigurarGrade(_quimica)
        ConfigurarGrade(_mecanica)
        ConfigurarGrade(_metalurgia)
        AddHandler _norma.SelectedIndexChanged, AddressOf NormaAlterada
        AddHandler _liga.SelectedIndexChanged, AddressOf LigaAlterada
        AddHandler _condicao.SelectedIndexChanged, AddressOf CondicaoAlterada
        Novo()
        InstalarBotaoConfiguracao()
    End Sub

    Private Sub InstalarBotaoConfiguracao()
        Dim botao As Button = _form.btnEditarNormas
        AddHandler botao.Click,
            Sub(sender As Object, e As EventArgs)
                Dim valores As List(Of LinhaResultado) = Capturar()
                Dim normaId As Integer = If(_norma.SelectedIndex < 0, 0, Convert.ToInt32(_norma.SelectedValue))
                Dim perfilId As Integer = If(_perfil Is Nothing, 0, Convert.ToInt32(_perfil("id")))
                Dim liga As String = _liga.Text
                Try
                    Using janela As New frmNormasConfig()
                        janela.ShowDialog(_form)
                    End Using
                    Dim normas As DataTable = Ler("SELECT id, CONCAT(entidade,' ',codigo,'-',edicao) AS rotulo FROM cert_normas ORDER BY codigo")
                    Dim perfis As DataTable = Ler("SELECT * FROM cert_perfis_norma WHERE sistema_unidades='SI' ORDER BY material_grau_tipo,condicao_fornecimento,revisao DESC")
                    Dim propriedades As DataTable = Ler("SELECT * FROM cert_propriedades ORDER BY grupo,id")
                    _ocupado = True
                    _normas.Clear() : _normas.Merge(normas)
                    _perfis.Clear() : _perfis.Merge(perfis)
                    _propriedades.Clear() : _propriedades.Merge(propriedades)
                    _perfil = Nothing
                    For Each p As DataRow In _perfis.Rows
                        If Convert.ToInt32(p("id")) = perfilId Then _perfil = p : Exit For
                    Next
                    If normaId > 0 Then _norma.SelectedValue = normaId Else _norma.SelectedIndex = -1
                    PreencherLigas()
                    _liga.SelectedItem = liga
                    PreencherCondicoes()
                    For Each opcao As OpcaoCondicao In _condicao.Items
                        If opcao.Id = perfilId Then _condicao.SelectedItem = opcao : Exit For
                    Next
                    _ocupado = False
                    LerRegras()
                    MontarLinhas(valores)
                    AtualizarAviso()
                Catch ex As Exception
                    _ocupado = False
                    _perfil = Nothing
                    _regras = New DataTable()
                    MontarLinhas(valores)
                    _form.btnsalvar.Enabled = False
                    _form.btnatualizar.Enabled = False
                    MessageBox.Show("Não foi possível atualizar a configuração. Reabra o cadastro antes de salvar." & vbCrLf & ex.Message, "Normas")
                Finally
                    _ocupado = False
                End Try
            End Sub
    End Sub

    Private Function Ler(sql As String, Optional id As Integer = 0) As DataTable
        Dim dados As New DataTable()
        Using cn As MySqlConnection = conexao.NovaConexao()
            Using cmd As New MySqlCommand(sql, cn)
                If sql.Contains("@id") Then cmd.Parameters.AddWithValue("@id", id)
                cn.Open()
                Using leitor As MySqlDataReader = cmd.ExecuteReader()
                    dados.Load(leitor)
                End Using
            End Using
        End Using
        Return dados
    End Function

    Private Function Texto(row As DataRow, coluna As String) As String
        Return If(row.IsNull(coluna), "", Convert.ToString(row(coluna), CultureInfo.InvariantCulture))
    End Function

    Private Function Normalizar(valor As String) As String
        Dim sb As New StringBuilder()
        For Each c As Char In valor.Normalize(NormalizationForm.FormD)
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark AndAlso Char.IsLetterOrDigit(c) Then
                sb.Append(Char.ToUpperInvariant(c))
            End If
        Next
        Return sb.ToString()
    End Function

    Private Sub ConfigurarGrade(grade As DataGridView)
        ' As colunas também existem no Designer. Completa versões salvas sem elas.
        Dim chaves As String() = {"nome", "valor", "unidade", "minimo", "maximo", "tolerancia", "situacao"}
        Dim titulos As String() = {"Propriedade", "Resultado", "Unidade / escala", "Mín. norma", "Máx. norma", "Tolerância", "Situação"}
        Dim colunas As New List(Of DataGridViewColumn)()
        For i As Integer = 0 To chaves.Length - 1
            Dim encontrada As DataGridViewColumn = Nothing
            For Each coluna As DataGridViewColumn In grade.Columns
                If String.Equals(coluna.DataPropertyName, chaves(i), StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(coluna.Name, chaves(i), StringComparison.OrdinalIgnoreCase) OrElse
                   coluna.Name.EndsWith("_" & chaves(i), StringComparison.OrdinalIgnoreCase) Then
                    encontrada = coluna
                    Exit For
                End If
            Next
            If encontrada Is Nothing Then
                encontrada = New DataGridViewTextBoxColumn With {
                    .Name = grade.Name & "_" & chaves(i), .HeaderText = titulos(i), .DataPropertyName = chaves(i)}
                grade.Columns.Add(encontrada)
            End If
            encontrada.DataPropertyName = chaves(i)
            colunas.Add(encontrada)
        Next
        For i As Integer = 0 To colunas.Count - 1
            colunas(i).Name = chaves(i)
            colunas(i).DisplayIndex = i
            colunas(i).ReadOnly = chaves(i) <> "valor"
            colunas(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        If grade Is _quimica Then
            grade.Columns("nome").HeaderText = "Elemento químico"
            grade.Columns("valor").HeaderText = "Resultado (% m/m)"
            grade.Columns("unidade").Visible = False
        ElseIf grade Is _metalurgia Then
            grade.Columns("nome").HeaderText = "Dado metalúrgico"
        Else
            grade.Columns("nome").HeaderText = "Propriedade mecânica"
        End If
        grade.AllowUserToAddRows = False
        grade.AllowUserToDeleteRows = False
        grade.AutoGenerateColumns = False
        grade.Columns("situacao").FillWeight = 175
        grade.Columns("tolerancia").FillWeight = 110
        grade.Columns("valor").DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 225)
        AddHandler grade.CellEndEdit,
            Sub(sender As Object, e As DataGridViewCellEventArgs)
                If e.RowIndex < 0 Then Return
                Dim row As DataGridViewRow = grade.Rows(e.RowIndex)
                Dim item As LinhaResultado = DirectCast(row.Tag, LinhaResultado)
                item.Valor = Convert.ToString(row.Cells("valor").Value).Trim()
                AvaliarLinha(row)
                SincronizarMecanica()
            End Sub
    End Sub

    Public Sub Novo()
        _ocupado = True
        _perfil = Nothing
        _regras = New DataTable()
        _quimicaAntiga = New DataTable()
        _norma.SelectedIndex = -1
        _liga.Items.Clear()
        _condicao.Items.Clear()
        _quimica.Rows.Clear()
        _mecanica.Rows.Clear()
        _metalurgia.Rows.Clear()
        _form.TabPage3.Enabled = True
        _form.btncadastrarcomposicao.Enabled = False
        _ocupado = False
        MontarLinhas(New List(Of LinhaResultado)())
        _aviso.Text = "Selecione norma, liga e condição. Resultados podem ser salvos incompletos; isso não significa aprovação."
    End Sub

    Public Sub Carregar(id As Integer)
        Try
            CarregarInterno(id)
        Catch ex As Exception
            _perfil = Nothing
            _regras = New DataTable()
            _aviso.Text = "Falha ao recuperar os resultados. Corrija a conexão antes de salvar."
            Throw New InvalidOperationException("Carregamento incompleto. Feche e reabra o cadastro antes de gravar." & vbCrLf & ex.Message, ex)
        Finally
            _ocupado = False
        End Try
    End Sub

    Private Sub CarregarInterno(id As Integer)
        _ocupado = True
        _perfil = Nothing
        _regras = New DataTable()
        _norma.SelectedIndex = -1
        _liga.Items.Clear()
        _condicao.Items.Clear()
        _quimica.Rows.Clear()
        _mecanica.Rows.Clear()
        _metalurgia.Rows.Clear()
        Dim escolhidos As DataTable = Ler("SELECT norma_id, perfil_id, liga_informada, condicao_informada FROM cert_selecao_lote WHERE cadastro_id = @id", id)
        If escolhidos.Rows.Count = 1 Then
            _norma.SelectedValue = escolhidos.Rows(0)("norma_id")
            PreencherLigas()
            _liga.SelectedItem = Texto(escolhidos.Rows(0), "liga_informada")
            PreencherCondicoes()
            Dim perfilId As Integer = If(escolhidos.Rows(0).IsNull("perfil_id"), 0, Convert.ToInt32(escolhidos.Rows(0)("perfil_id")))
            For Each p As DataRow In _perfis.Rows
                If Convert.ToInt32(p("id")) = perfilId Then
                    _perfil = p
                    _norma.SelectedValue = p("norma_id")
                    PreencherLigas()
                    _liga.SelectedItem = Texto(p, "material_grau_tipo")
                    PreencherCondicoes()
                    For Each item As OpcaoCondicao In _condicao.Items
                        If item.Id = perfilId Then _condicao.SelectedItem = item : Exit For
                    Next
                    _perfil = p
                    Exit For
                End If
            Next
        End If
        _quimicaAntiga = Ler("SELECT * FROM cadastrocompquimica WHERE WORK_ORDER = @id ORDER BY SEQUENCIA", id)
        Dim linhas As New List(Of LinhaResultado)()
        For Each antiga As DataRow In _quimicaAntiga.Rows
            If antiga.IsNull("TIPO") OrElse antiga.IsNull("SEQUENCIA") Then
                Throw New InvalidOperationException("Há uma linha química antiga sem tipo ou sequência. Corrija essa identificação antes de usar a nova gravação.")
            End If
            Dim codigo As String = Texto(antiga, "TIPO")
            Dim propriedade As DataRow = AcharPropriedade(codigo)
            linhas.Add(New LinhaResultado With {
                .PropriedadeId = If(propriedade Is Nothing, 0, Convert.ToInt32(propriedade("id"))),
                .Codigo = If(propriedade Is Nothing, codigo, Texto(propriedade, "codigo")),
                .Nome = If(propriedade Is Nothing, codigo, Texto(propriedade, "descricao")),
                .Grupo = "QUIMICA", .Valor = Texto(antiga, "VALOR"), .Unidade = "% m/m",
                .SequenciaAntiga = Texto(antiga, "SEQUENCIA"), .TipoAntigo = codigo
            })
        Next
        Dim mecanicos As DataTable = Ler("SELECT r.resultado_original, r.unidade, d.codigo " &
            "FROM cert_resultados r JOIN cert_amostras a ON a.id=r.amostra_id " &
            "JOIN cert_propriedades d ON d.id=r.propriedade_id " &
            "WHERE a.cadastro_id=@id AND a.identificacao IN ('CADASTRO_MECANICA','CADASTRO_METALURGIA') ORDER BY r.id", id)
        For Each salvo As DataRow In mecanicos.Rows
            Dim item As LinhaResultado = CriarLinha(Texto(salvo, "codigo"), Texto(salvo, "resultado_original"))
            item.Unidade = Texto(salvo, "unidade")
            linhas.Add(item)
        Next
        For Each par As KeyValuePair(Of String, TextBox) In _espelho
            If Not linhas.Exists(Function(x) x.Codigo = par.Key) Then linhas.Add(CriarLinha(par.Key, par.Value.Text))
        Next
        If Not String.IsNullOrWhiteSpace(_form.txtdureza.Text) AndAlso
            Not linhas.Exists(Function(x) x.Codigo.StartsWith("DUREZA_")) Then
            linhas.Add(CriarLinha("DUREZA_INFORMADA", _form.txtdureza.Text))
        End If
        For Each par As KeyValuePair(Of String, TextBox) In _espelhoMetal
            If Not linhas.Exists(Function(x) x.Codigo = par.Key) Then linhas.Add(CriarLinha(par.Key, par.Value.Text))
        Next
        _ocupado = False
        LerRegras()
        MontarLinhas(linhas)
        _form.TabPage3.Enabled = True
        AtualizarAviso()
    End Sub

    Private Class OpcaoCondicao
        Public Id As Integer
        Public Nome As String
        Public Overrides Function ToString() As String
            Return Nome
        End Function
    End Class

    Private Function NomeCondicao(codigo As String) As String
        Select Case codigo
            Case "RECOZIDO" : Return "Recozido"
            Case "TRABALHADO_A_MORNO" : Return "Trabalhado a morno"
            Case "TRABALHADO_A_QUENTE" : Return "Trabalhado a quente"
            Case "A_CONFIRMAR" : Return "A confirmar"
            Case Else : Return codigo
        End Select
    End Function

    Private Sub NormaAlterada(sender As Object, e As EventArgs)
        If _ocupado Then Return
        Dim anteriores As List(Of LinhaResultado) = Capturar()
        _ocupado = True
        PreencherLigas()
        _condicao.Items.Clear()
        _perfil = Nothing
        _regras = New DataTable()
        _ocupado = False
        _form.txttratamentotermico.Text = ""
        MontarLinhas(anteriores)
        AtualizarAviso()
    End Sub

    Private Sub PreencherLigas()
        _liga.Items.Clear()
        If _norma.SelectedIndex < 0 Then Return
        Dim nomes As New HashSet(Of String)()
        For Each p As DataRow In _perfis.Rows
            If Convert.ToInt32(p("norma_id")) = Convert.ToInt32(_norma.SelectedValue) AndAlso
                (Texto(p, "status") <> "INATIVO" OrElse (_perfil IsNot Nothing AndAlso Convert.ToInt32(_perfil("id")) = Convert.ToInt32(p("id")))) Then
                Dim nome As String = Texto(p, "material_grau_tipo")
                If nomes.Add(nome) Then _liga.Items.Add(nome)
            End If
        Next
    End Sub

    Private Sub LigaAlterada(sender As Object, e As EventArgs)
        If _ocupado Then Return
        Dim anteriores As List(Of LinhaResultado) = Capturar()
        _ocupado = True
        PreencherCondicoes()
        _perfil = Nothing
        _regras = New DataTable()
        _ocupado = False
        _form.txttratamentotermico.Text = ""
        MontarLinhas(anteriores)
        AtualizarAviso()
    End Sub

    Private Sub PreencherCondicoes()
        _condicao.Items.Clear()
        If _norma.SelectedIndex < 0 OrElse _liga.SelectedIndex < 0 Then Return
        Dim vistos As New HashSet(Of String)()
        For Each p As DataRow In _perfis.Rows
            If Convert.ToInt32(p("norma_id")) = Convert.ToInt32(_norma.SelectedValue) AndAlso
                Texto(p, "material_grau_tipo") = Convert.ToString(_liga.SelectedItem) Then
                If Texto(p, "status") = "INATIVO" AndAlso
                    (_perfil Is Nothing OrElse Convert.ToInt32(_perfil("id")) <> Convert.ToInt32(p("id"))) Then Continue For
                Dim condicao As String = Texto(p, "condicao_fornecimento")
                Dim nome As String = NomeCondicao(condicao) & " — rev. " & Texto(p, "revisao") & " — " & Texto(p, "forma_produto") & " — " & Texto(p, "codigo")
                If Texto(p, "status") = "INATIVO" Then nome &= " (histórico)"
                If vistos.Add(Texto(p, "id")) Then _condicao.Items.Add(New OpcaoCondicao With {
                    .Id = Convert.ToInt32(p("id")), .Nome = nome})
            End If
        Next
    End Sub

    Private Sub CondicaoAlterada(sender As Object, e As EventArgs)
        If _ocupado OrElse _condicao.SelectedIndex < 0 Then Return
        Dim anteriores As List(Of LinhaResultado) = Capturar()
        Dim opcao As OpcaoCondicao = DirectCast(_condicao.SelectedItem, OpcaoCondicao)
        For Each p As DataRow In _perfis.Rows
            If Convert.ToInt32(p("id")) = opcao.Id Then _perfil = p : Exit For
        Next
        Try
            LerRegras()
            MontarLinhas(anteriores)
            AtualizarAviso()
        Catch ex As Exception
            _perfil = Nothing
            _regras = New DataTable()
            MontarLinhas(anteriores)
            _aviso.Text = "Requisitos indisponíveis; nenhuma aprovação. Selecione novamente após corrigir a conexão."
            MessageBox.Show(ex.Message, "Requisitos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LerRegras()
        _regras = New DataTable()
        If _perfil Is Nothing Then Return
        _regras = Ler("SELECT r.*, d.codigo AS propriedade_codigo, d.descricao AS propriedade_nome, d.grupo " &
            "FROM cert_requisitos r JOIN cert_propriedades d ON d.id = r.propriedade_id " &
            "WHERE r.perfil_id = @id ORDER BY r.ordem_exibicao, r.id", Convert.ToInt32(_perfil("id")))
    End Sub

    Private Function Capturar() As List(Of LinhaResultado)
        _quimica.EndEdit()
        _mecanica.EndEdit()
        Dim itens As New List(Of LinhaResultado)()
        For Each grade As DataGridView In New DataGridView() {_quimica, _mecanica, _metalurgia}
            For Each row As DataGridViewRow In grade.Rows
                Dim item As LinhaResultado = DirectCast(row.Tag, LinhaResultado)
                item.Valor = Convert.ToString(row.Cells("valor").Value).Trim()
                itens.Add(item)
            Next
        Next
        Return itens
    End Function

    Private Function AcharPropriedade(nome As String) As DataRow
        Dim n As String = Normalizar(nome)
        For Each p As DataRow In _propriedades.Rows
            Dim c As String = Normalizar(Texto(p, "codigo")), d As String = Normalizar(Texto(p, "descricao"))
            If n = c OrElse n = d OrElse n = c & d OrElse n = d & c Then Return p
        Next
        Return Nothing
    End Function

    Private Function CriarLinha(codigo As String, Optional valor As String = "") As LinhaResultado
        Dim p As DataRow = AcharPropriedade(codigo)
        If p Is Nothing Then Throw New InvalidOperationException("Propriedade não cadastrada: " & codigo & ". Execute o SQL desta etapa.")
        Return New LinhaResultado With {.PropriedadeId = Convert.ToInt32(p("id")), .Codigo = Texto(p, "codigo"),
            .Nome = Texto(p, "descricao"), .Grupo = Texto(p, "grupo"), .Valor = valor, .Unidade = Texto(p, "unidade_sugerida")}
    End Function

    Private Sub MontarLinhas(anteriores As List(Of LinhaResultado))
        _ocupado = True
        _quimica.Rows.Clear()
        _mecanica.Rows.Clear()
        _metalurgia.Rows.Clear()
        Dim usados As New HashSet(Of LinhaResultado)()
        For Each regra As DataRow In _regras.Rows
            Dim codigo As String = Texto(regra, "propriedade_codigo")
            Dim encontrados As List(Of LinhaResultado) = anteriores.FindAll(Function(x) x.Codigo = codigo)
            If encontrados.Count = 0 Then encontrados.Add(CriarLinha(codigo))
            For Each item As LinhaResultado In encontrados
                item.Regra = regra
                item.Unidade = Texto(regra, "unidade")
                MostrarLinha(item)
                usados.Add(item)
            Next
        Next
        For Each item As LinhaResultado In anteriores
            If Not usados.Contains(item) AndAlso
                (item.Valor <> "" OrElse item.SequenciaAntiga IsNot Nothing OrElse _espelho.ContainsKey(item.Codigo) OrElse _espelhoMetal.ContainsKey(item.Codigo)) Then
                item.Regra = Nothing
                MostrarLinha(item)
                usados.Add(item)
            End If
        Next
        For Each codigo As String In New String() {"TRACAO", "ESCOAMENTO_02", "ALONGAMENTO", "REDUCAO_AREA"}
            If Not anteriores.Exists(Function(x) x.Codigo = codigo) AndAlso Not TemCodigo(codigo) Then MostrarLinha(CriarLinha(codigo))
        Next
        For Each codigo As String In _espelhoMetal.Keys
            If Not anteriores.Exists(Function(x) x.Codigo = codigo) AndAlso Not TemCodigo(codigo) Then MostrarLinha(CriarLinha(codigo))
        Next
        _ocupado = False
    End Sub

    Private Function TemCodigo(codigo As String) As Boolean
        For Each grade As DataGridView In New DataGridView() {_quimica, _mecanica, _metalurgia}
            For Each row As DataGridViewRow In grade.Rows
                If DirectCast(row.Tag, LinhaResultado).Codigo = codigo Then Return True
            Next
        Next
        Return False
    End Function

    Private Function Limite(regra As DataRow, minimo As Boolean) As String
        If regra Is Nothing Then Return "—"
        Dim coluna As String = If(minimo, "minimo", "maximo")
        If regra.IsNull(coluna) Then Return "—"
        Dim original As String = Texto(regra, If(minimo, "limite_min_original", "limite_max_original"))
        If original = "" Then original = Convert.ToDecimal(regra(coluna)).ToString("0.##########", CultureInfo.GetCultureInfo("pt-BR"))
        Return If(Convert.ToBoolean(regra(If(minimo, "minimo_inclusivo", "maximo_inclusivo"))), "", If(minimo, "> ", "< ")) & original.Replace(".", ",")
    End Function

    Private Sub MostrarLinha(item As LinhaResultado)
        Dim grade As DataGridView = If(item.Grupo = "QUIMICA", _quimica, If(item.Grupo = "METALURGIA", _metalurgia, _mecanica))
        Dim idx As Integer = grade.Rows.Add()
        Dim row As DataGridViewRow = grade.Rows(idx)
        row.Cells("nome").Value = item.Codigo & " — " & item.Nome
        row.Cells("valor").Value = item.Valor
        row.Cells("unidade").Value = If(item.Unidade = "", "Não informada", item.Unidade)
        row.Cells("minimo").Value = Limite(item.Regra, True)
        row.Cells("maximo").Value = Limite(item.Regra, False)
        row.Cells("tolerancia").Value = If(item.Regra Is Nothing, "—", "Não aplicada")
        row.Cells("situacao").Value = ""
        row.Tag = item
        If item.Regra IsNot Nothing Then
            row.Cells("nome").ToolTipText = Texto(item.Regra, "referencia_normativa") & vbCrLf & Texto(item.Regra, "observacoes")
        End If
        AvaliarLinha(row)
    End Sub

    Private Sub AvaliarLinha(row As DataGridViewRow)
        Dim item As LinhaResultado = DirectCast(row.Tag, LinhaResultado)
        Dim situacao As String = If(item.Regra Is Nothing, "Sem regra neste perfil", ConferenciaNormas.AvaliarResultado(item.Valor, item.Regra))
        If item.Regra IsNot Nothing AndAlso Texto(item.Regra, "tipo_regra") = "INFORMATIVO" AndAlso
            item.Grupo = "MECANICA" AndAlso item.Valor <> "" AndAlso
            Not Regex.IsMatch(item.Valor, "^[+-]?(?:\d+(?:[.,]\d*)?|[.,]\d+)$") Then
            situacao = "Formato inválido / ND"
        End If
        row.Cells("situacao").Value = situacao
        row.Cells("situacao").Style.ForeColor = If(situacao = "Fora do limite", Color.DarkRed,
            If(situacao = "Dentro (numerico)", Color.DarkGreen, Color.DarkOrange))
    End Sub

    Private Sub AtualizarAviso()
        If _norma.SelectedIndex >= 0 Then _form.txtespecificacao.Text = _norma.Text
        If _perfil Is Nothing Then
            _aviso.Text = "Seleção incompleta ou norma sem perfil cadastrado. Nenhuma aprovação disponível; os resultados existentes foram mantidos."
        Else
            _aviso.Text = "Perfil: " & Texto(_perfil, "descricao") & " | " & Texto(_perfil, "status") &
                ". Comparação numérica; conferir amostra, unidade, dimensão e condições do ensaio. Sem separador de milhar."
            _form.txtespecificacao.Text = _norma.Text
            If Texto(_perfil, "condicao_fornecimento") <> "A_CONFIRMAR" Then
                _form.txttratamentotermico.Text = NomeCondicao(Texto(_perfil, "condicao_fornecimento"))
            End If
        End If
    End Sub

    Private Sub SincronizarMecanica()
        If _ocupado Then Return
        Dim vistos As New HashSet(Of String)()
        For Each row As DataGridViewRow In _mecanica.Rows
            Dim item As LinhaResultado = DirectCast(row.Tag, LinhaResultado)
            If _espelho.ContainsKey(item.Codigo) AndAlso vistos.Add(item.Codigo) Then _espelho(item.Codigo).Text = item.Valor
        Next
        Dim durezaLegada As String = "", durezaComEscala As String = ""
        Dim temDureza As Boolean = False
        For Each row As DataGridViewRow In _mecanica.Rows
            Dim item As LinhaResultado = DirectCast(row.Tag, LinhaResultado)
            If Not item.Codigo.StartsWith("DUREZA_") Then Continue For
            temDureza = True
            If item.Codigo = "DUREZA_INFORMADA" Then
                durezaLegada = item.Valor
            ElseIf item.Valor <> "" Then
                durezaComEscala = item.Valor & " " & item.Unidade
            End If
        Next
        If temDureza Then _form.txtdureza.Text = If(durezaComEscala <> "", durezaComEscala, durezaLegada)
        For Each row As DataGridViewRow In _metalurgia.Rows
            Dim item As LinhaResultado = DirectCast(row.Tag, LinhaResultado)
            If _espelhoMetal.ContainsKey(item.Codigo) Then _espelhoMetal(item.Codigo).Text = item.Valor
        Next
    End Sub

    Public Sub PrepararGravacao()
        SessaoAtual.ExigirAutenticado()
        Dim engines As DataTable = Ler("SELECT TABLE_NAME, ENGINE FROM information_schema.TABLES " &
            "WHERE TABLE_SCHEMA=DATABASE() AND TABLE_NAME IN ('cadastrocertificados','cadastrocompquimica')")
        If engines.Rows.Count <> 2 Then Throw New InvalidOperationException("Não foi possível conferir as tabelas do cadastro.")
        For Each row As DataRow In engines.Rows
            If Not String.Equals(Texto(row, "ENGINE"), "InnoDB", StringComparison.OrdinalIgnoreCase) Then
                Throw New InvalidOperationException("A tabela " & Texto(row, "TABLE_NAME") & " precisa usar InnoDB antes desta gravação integrada. Nenhuma alteração foi iniciada.")
            End If
        Next
        Capturar()
        SincronizarMecanica()
        AtualizarAviso()
    End Sub

    Private Function Executar(cn As MySqlConnection, tx As MySqlTransaction, sql As String,
                              valores As Dictionary(Of String, Object), Optional escalar As Boolean = False) As Object
        Using cmd As New MySqlCommand(sql, cn, tx)
            For Each par As KeyValuePair(Of String, Object) In valores
                cmd.Parameters.AddWithValue(par.Key, par.Value)
            Next
            If escalar Then Return cmd.ExecuteScalar()
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Public Sub Gravar(cn As MySqlConnection, tx As MySqlTransaction, cadastroId As Integer)
        Dim itens As List(Of LinhaResultado) = Capturar()
        If _norma.SelectedIndex >= 0 Then
            Executar(cn, tx, "INSERT INTO cert_selecao_lote(cadastro_id,norma_id,perfil_id,liga_informada,condicao_informada) VALUES(@id,@norma,@perfil,@liga,@condicao) " &
                "ON DUPLICATE KEY UPDATE norma_id=VALUES(norma_id),perfil_id=VALUES(perfil_id),liga_informada=VALUES(liga_informada),condicao_informada=VALUES(condicao_informada)",
                New Dictionary(Of String, Object) From {{"@id", cadastroId}, {"@norma", Convert.ToInt32(_norma.SelectedValue)},
                    {"@perfil", If(_perfil Is Nothing, CType(DBNull.Value, Object), CType(Convert.ToInt32(_perfil("id")), Object))},
                    {"@liga", _liga.Text}, {"@condicao", _condicao.Text}})
        End If
        If _perfil IsNot Nothing Then
            Dim perfilId As Integer = Convert.ToInt32(_perfil("id"))
            Executar(cn, tx, "INSERT INTO cert_lote_perfis(cadastro_id,perfil_id) VALUES(@id,@perfil) ON DUPLICATE KEY UPDATE id=cert_lote_perfis.id",
                New Dictionary(Of String, Object) From {{"@id", cadastroId}, {"@perfil", perfilId}})
        End If
        Dim proximaSequencia As Integer = Convert.ToInt32(Executar(cn, tx,
            "SELECT COALESCE(MAX(CAST(SEQUENCIA AS UNSIGNED)),0) FROM cadastrocompquimica WHERE WORK_ORDER=@id",
            New Dictionary(Of String, Object) From {{"@id", cadastroId}}, True))
        Dim repeticoes As New Dictionary(Of String, Integer)()
        For Each item As LinhaResultado In itens
            If item.Grupo = "QUIMICA" Then
                GravarQuimicaAntiga(cn, tx, cadastroId, item, proximaSequencia)
            End If
            If item.PropriedadeId = 0 Then Continue For
            Dim amostra As String = If(item.Grupo = "QUIMICA", "CADASTRO_QUIMICA", If(item.Grupo = "METALURGIA", "CADASTRO_METALURGIA", "CADASTRO_MECANICA"))
            Dim chave As String = amostra & ":" & item.PropriedadeId.ToString()
            If Not repeticoes.ContainsKey(chave) Then repeticoes.Add(chave, 0)
            repeticoes(chave) += 1
            Dim numero As Integer = repeticoes(chave)
            Dim parametros As New Dictionary(Of String, Object) From {{"@id", cadastroId}, {"@nome", amostra}}
            Executar(cn, tx, "INSERT INTO cert_amostras(cadastro_id,identificacao) VALUES(@id,@nome) ON DUPLICATE KEY UPDATE id=cert_amostras.id", parametros)
            Dim amostraId As Integer = Convert.ToInt32(Executar(cn, tx,
                "SELECT id FROM cert_amostras WHERE cadastro_id=@id AND identificacao=@nome", parametros, True))
            Dim valores As New Dictionary(Of String, Object) From {
                {"@amostra", amostraId}, {"@propriedade", item.PropriedadeId}, {"@repeticao", numero}}
            If item.Valor = "" Then
                Executar(cn, tx, "DELETE FROM cert_resultados WHERE amostra_id=@amostra AND propriedade_id=@propriedade AND repeticao=@repeticao", valores)
                Continue For
            End If
            PrepararValor(item, valores)
            valores.Add("@original", item.Valor)
            valores.Add("@usuario", SessaoAtual.Login)
            Executar(cn, tx, "INSERT INTO cert_resultados(amostra_id,propriedade_id,repeticao,tipo_resultado,operador,valor,unidade,resultado_texto,resultado_original,registrado_por) " &
                "VALUES(@amostra,@propriedade,@repeticao,@tipo,@operador,@valor,@unidade,@texto,@original,@usuario) " &
                "ON DUPLICATE KEY UPDATE tipo_resultado=VALUES(tipo_resultado),operador=VALUES(operador),valor=VALUES(valor)," &
                "unidade=VALUES(unidade),resultado_texto=VALUES(resultado_texto),resultado_original=VALUES(resultado_original),registrado_por=VALUES(registrado_por)", valores)
        Next
    End Sub

    Private Sub PrepararValor(item As LinhaResultado, valores As Dictionary(Of String, Object))
        Dim match As Match = Regex.Match(item.Valor.Trim(), "^(?<op><=|>=|<|>|=|≤|≥)?\s*(?<valor>[+-]?(?:\d+(?:[.,]\d*)?|[.,]\d+))$")
        Dim n As Decimal
        Dim possuiUnidade As Boolean = item.Unidade <> ""
        If match.Success AndAlso possuiUnidade AndAlso Decimal.TryParse(match.Groups("valor").Value.Replace(",", "."),
            NumberStyles.AllowLeadingSign Or NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, n) Then
            If Decimal.Round(n, 10) <> n OrElse Math.Abs(n) >= 100000000000000D Then
                Throw New ArgumentException("Resultado de " & item.Codigo & " excede a precisão de 14 inteiros e 10 casas decimais.")
            End If
            Dim op As String = match.Groups("op").Value.Replace("≤", "<=").Replace("≥", ">=")
            valores.Add("@tipo", "NUMERICO")
            valores.Add("@operador", If(op = "", "=", op))
            valores.Add("@valor", n)
            valores.Add("@texto", DBNull.Value)
        Else
            Dim texto As String = Normalizar(item.Valor)
            Dim balanco As Boolean = texto = "BAL" OrElse texto = "BALANCE" OrElse texto = "BALANCO" OrElse texto = "SALDO"
            Dim nd As Boolean = texto = "ND" OrElse texto = "NAODETERMINADO"
            valores.Add("@tipo", If(balanco, "BALANCO", If(nd, "NAO_DETERMINADO", "TEXTO")))
            valores.Add("@operador", DBNull.Value)
            valores.Add("@valor", DBNull.Value)
            valores.Add("@texto", If(balanco OrElse nd, CType(DBNull.Value, Object), CType(item.Valor, Object)))
        End If
        valores.Add("@unidade", If(possuiUnidade, CType(item.Unidade, Object), CType(DBNull.Value, Object)))
    End Sub

    Private Sub GravarQuimicaAntiga(cn As MySqlConnection, tx As MySqlTransaction, id As Integer,
                                  item As LinhaResultado, ByRef proximaSequencia As Integer)
        Dim encontrada As Integer = 0
        Dim parametros As New Dictionary(Of String, Object) From {{"@id", id}}
        If item.SequenciaAntiga IsNot Nothing Then
            parametros.Add("@seq", item.SequenciaAntiga)
            parametros.Add("@tipo", item.TipoAntigo)
            encontrada = Convert.ToInt32(Executar(cn, tx, "SELECT COUNT(*) FROM cadastrocompquimica " &
                "WHERE WORK_ORDER=@id AND SEQUENCIA=@seq AND TIPO=@tipo", parametros, True))
            If encontrada > 1 Then Throw New InvalidOperationException("Há composição antiga duplicada na sequência " & item.SequenciaAntiga & ". Nenhum dado foi gravado.")
        End If
        If encontrada = 1 Then
            If item.Valor = "" Then
                Executar(cn, tx, "DELETE FROM cadastrocompquimica WHERE WORK_ORDER=@id AND SEQUENCIA=@seq AND TIPO=@tipo", parametros)
            Else
                parametros.Add("@valor", item.Valor)
                Executar(cn, tx, "UPDATE cadastrocompquimica SET VALOR=@valor WHERE WORK_ORDER=@id AND SEQUENCIA=@seq AND TIPO=@tipo", parametros)
            End If
        ElseIf item.Valor <> "" Then
            proximaSequencia += 1
            parametros = New Dictionary(Of String, Object) From {
                {"@id", id}, {"@seq", proximaSequencia}, {"@tipo", item.Codigo}, {"@valor", item.Valor}}
            Executar(cn, tx, "INSERT INTO cadastrocompquimica(WORK_ORDER,SEQUENCIA,TIPO,VALOR) VALUES(@id,@seq,@tipo,@valor)", parametros)
            item.SequenciaAntiga = proximaSequencia.ToString()
            item.TipoAntigo = item.Codigo
        End If
    End Sub
End Class
