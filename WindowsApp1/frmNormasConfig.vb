Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class frmNormasConfig

    Private ReadOnly _normaCampos As New Dictionary(Of String, Control)()
    Private ReadOnly _perfilCampos As New Dictionary(Of String, Control)()
    Private ReadOnly _grades As New Dictionary(Of String, DataGridView)()
    Private _propriedades As DataTable
    Private _regras As DataTable
    Private _extrasPerfil As New Dictionary(Of String, Object)()
    Private _normaId As Integer
    Private _perfilId As Integer
    Private _revisao As Integer = 1
    Private _ocupado As Boolean
    Private _sujo As Boolean
    Private _novaRevisao As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub IniciarTela(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime OrElse DesignMode Then Return
        _ocupado = True
        Try
            SessaoAtual.ExigirAutenticado()
            _propriedades = Consultar("SELECT * FROM cert_propriedades ORDER BY grupo,descricao")
            _regras = TabelaRegras(Consultar("SELECT r.*,d.grupo FROM cert_requisitos r JOIN cert_propriedades d ON d.id=r.propriedade_id WHERE 1=0"))
            ConfigurarComportamento()
            AtualizarNormas(0)
            LimparNorma()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Configuração de normas", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        Finally
            _ocupado = False
            _sujo = False
        End Try
    End Sub

    Private Function Consultar(sql As String, Optional id As Integer = 0) As DataTable
        Dim tabela As New DataTable()
        Using cn As MySqlConnection = conexao.NovaConexao()
            Using cmd As New MySqlCommand(sql, cn)
                If sql.Contains("@id") Then cmd.Parameters.AddWithValue("@id", id)
                cn.Open()
                Using leitor As MySqlDataReader = cmd.ExecuteReader()
                    tabela.Load(leitor)
                End Using
            End Using
        End Using
        Return tabela
    End Function

    Private Function Texto(row As DataRow, coluna As String) As String
        Return If(row.IsNull(coluna), "", Convert.ToString(row(coluna), CultureInfo.InvariantCulture))
    End Function


    Private Sub ConfigurarComportamento()
        LigarBotao(btnNovaNorma, Sub() NovaNorma(False))
        LigarBotao(btnNovaEdicao, Sub() NovaNorma(True))
        LigarBotao(btnSalvarNorma, AddressOf SalvarNorma)
        LigarBotao(btnNovoPerfil, AddressOf NovoPerfil)
        LigarBotao(btnNovaRevisao, AddressOf NovaRevisao)
        LigarBotao(btnSalvarPerfil, AddressOf SalvarPerfil)
        LigarBotao(btnNovaPropriedade, AddressOf NovaPropriedade)
        LigarBotao(btnFechar, Sub() Close())
        _normaCampos.Add("entidade", txtNorma_entidade)
        _normaCampos.Add("codigo", txtNorma_codigo)
        _normaCampos.Add("edicao", txtNorma_edicao)
        _normaCampos.Add("descricao", txtNorma_descricao)
        _normaCampos.Add("referencia_documento", txtNorma_referencia_documento)
        _perfilCampos.Add("codigo", txtPerfil_codigo)
        _perfilCampos.Add("descricao", txtPerfil_descricao)
        _perfilCampos.Add("material_grau_tipo", txtPerfil_material_grau_tipo)
        _perfilCampos.Add("designacao_uns", txtPerfil_designacao_uns)
        _perfilCampos.Add("forma_produto", cboPerfil_forma_produto)
        _perfilCampos.Add("condicao_fornecimento", cboPerfil_condicao_fornecimento)
        _perfilCampos.Add("sistema_unidades", cboPerfil_sistema_unidades)
        _perfilCampos.Add("status", cboPerfil_status)
        LigarBotao(btnDimensoes, AddressOf DetalhesPerfil)
        LigarBotao(btnQUIMICAAdicionar, Sub() AdicionarRegra("QUIMICA"))
        LigarBotao(btnQUIMICARemover, Sub() RemoverRegra(gradeQUIMICA))
        LigarBotao(btnQUIMICADetalhes, Sub() DetalhesRegra(gradeQUIMICA))
        _grades.Add("QUIMICA", gradeQUIMICA)
        ConfigurarGrade("QUIMICA", gradeQUIMICA)
        LigarBotao(btnMECANICAAdicionar, Sub() AdicionarRegra("MECANICA"))
        LigarBotao(btnMECANICARemover, Sub() RemoverRegra(gradeMECANICA))
        LigarBotao(btnMECANICADetalhes, Sub() DetalhesRegra(gradeMECANICA))
        _grades.Add("MECANICA", gradeMECANICA)
        ConfigurarGrade("MECANICA", gradeMECANICA)
        LigarBotao(btnMETALURGIAAdicionar, Sub() AdicionarRegra("METALURGIA"))
        LigarBotao(btnMETALURGIARemover, Sub() RemoverRegra(gradeMETALURGIA))
        LigarBotao(btnMETALURGIADetalhes, Sub() DetalhesRegra(gradeMETALURGIA))
        _grades.Add("METALURGIA", gradeMETALURGIA)
        ConfigurarGrade("METALURGIA", gradeMETALURGIA)
        LigarBotao(btnOUTROSAdicionar, Sub() AdicionarRegra("OUTROS"))
        LigarBotao(btnOUTROSRemover, Sub() RemoverRegra(gradeOUTROS))
        LigarBotao(btnOUTROSDetalhes, Sub() DetalhesRegra(gradeOUTROS))
        _grades.Add("OUTROS", gradeOUTROS)
        ConfigurarGrade("OUTROS", gradeOUTROS)
        For Each c As Control In _normaCampos.Values
            AddHandler c.TextChanged, AddressOf CampoAlterado
        Next
        For Each c As Control In _perfilCampos.Values
            AddHandler c.TextChanged, AddressOf CampoAlterado
        Next
        AddHandler _normas.SelectedIndexChanged, AddressOf NormaSelecionada
        AddHandler _perfis.SelectedIndexChanged, AddressOf PerfilSelecionado
        AddHandler FormClosing, AddressOf AoFechar
    End Sub

    Private Sub CampoAlterado(sender As Object, e As EventArgs)
        If Not _ocupado Then _sujo = True
    End Sub

    Private Sub LigarBotao(b As Button, acao As Action)
        AddHandler b.Click, Sub(sender As Object, e As EventArgs)
                                Try
                                    acao()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Configuração de normas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End Sub
    End Sub

    Private Function TabelaRegras(origem As DataTable) As DataTable
        Dim nova As New DataTable()
        Dim flags As New HashSet(Of String) From {"obrigatorio_informar", "minimo_inclusivo", "maximo_inclusivo"}
        For Each col As DataColumn In origem.Columns
            nova.Columns.Add(col.ColumnName, If(flags.Contains(col.ColumnName), GetType(Boolean), col.DataType))
        Next
        nova.Columns.Add("ui_minimo", GetType(String))
        nova.Columns.Add("ui_maximo", GetType(String))
        For Each antiga As DataRow In origem.Rows
            Dim row As DataRow = nova.NewRow()
            For Each col As DataColumn In origem.Columns
                row(col.ColumnName) = If(flags.Contains(col.ColumnName), CType(Convert.ToBoolean(antiga(col)), Object), antiga(col))
            Next
            row("ui_minimo") = LimiteOriginal(antiga, "minimo", "limite_min_original")
            row("ui_maximo") = LimiteOriginal(antiga, "maximo", "limite_max_original")
            nova.Rows.Add(row)
        Next
        Return nova
    End Function

    Private Function LimiteOriginal(row As DataRow, numero As String, original As String) As String
        Dim valor As String = Texto(row, original)
        If valor <> "" Then Return valor.Replace(".", ",")
        If row.IsNull(numero) Then Return ""
        Return Convert.ToDecimal(row(numero)).ToString("0.##########", CultureInfo.GetCultureInfo("pt-BR"))
    End Function

    Private Function PropriedadesDoGrupo(grupo As String) As DataTable
        Dim tabela As DataTable = _propriedades.Clone()
        For Each p As DataRow In _propriedades.Rows
            If (grupo = "OUTROS" AndAlso Texto(p, "grupo") <> "QUIMICA" AndAlso Texto(p, "grupo") <> "MECANICA" AndAlso Texto(p, "grupo") <> "METALURGIA") OrElse
                Texto(p, "grupo") = grupo Then tabela.ImportRow(p)
        Next
        Return tabela
    End Function

    Private Sub GarantirColunasDaGrade(grade As DataGridView)
        ' O layout permanece no Designer. Completa colunas ausentes antes de vincular dados.
        Dim nomes As String() = {"propriedade", "regra", "ui_minimo", "ui_maximo", "minimo_inclusivo", "maximo_inclusivo", "unidade", "obrigatorio_informar", "referencia_normativa"}
        Dim campos As String() = {"propriedade_id", "tipo_regra", "ui_minimo", "ui_maximo", "minimo_inclusivo", "maximo_inclusivo", "unidade", "obrigatorio_informar", "referencia_normativa"}
        Dim titulos As String() = {"Elemento / propriedade", "Regra", "Mínimo", "Máximo", "Inclui mín.", "Inclui máx.", "Unidade / escala", "Obrigatório", "Tabela / item da norma"}
        Dim colunas As New List(Of DataGridViewColumn)()
        grade.AutoGenerateColumns = False
        grade.AllowUserToAddRows = False
        grade.AllowUserToDeleteRows = False
        For i As Integer = 0 To nomes.Length - 1
            Dim encontrada As DataGridViewColumn = Nothing
            For Each coluna As DataGridViewColumn In grade.Columns
                If String.Equals(coluna.DataPropertyName, campos(i), StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(coluna.Name, nomes(i), StringComparison.OrdinalIgnoreCase) OrElse
                   coluna.Name.EndsWith("_" & nomes(i), StringComparison.OrdinalIgnoreCase) Then
                    encontrada = coluna
                    Exit For
                End If
            Next
            Dim tipo As Type = GetType(DataGridViewTextBoxColumn)
            Select Case nomes(i)
                Case "propriedade", "regra"
                    tipo = GetType(DataGridViewComboBoxColumn)
                Case "minimo_inclusivo", "maximo_inclusivo", "obrigatorio_informar"
                    tipo = GetType(DataGridViewCheckBoxColumn)
            End Select
            If encontrada IsNot Nothing AndAlso Not tipo.IsInstanceOfType(encontrada) Then
                grade.Columns.Remove(encontrada)
                encontrada = Nothing
            End If
            If encontrada Is Nothing Then
                Select Case nomes(i)
                    Case "propriedade", "regra"
                        encontrada = New DataGridViewComboBoxColumn()
                    Case "minimo_inclusivo", "maximo_inclusivo", "obrigatorio_informar"
                        encontrada = New DataGridViewCheckBoxColumn()
                    Case Else
                        encontrada = New DataGridViewTextBoxColumn()
                End Select
                encontrada.Name = grade.Name & "_" & nomes(i)
                encontrada.HeaderText = titulos(i)
                grade.Columns.Add(encontrada)
            End If
            encontrada.DataPropertyName = campos(i)
            colunas.Add(encontrada)
        Next
        For i As Integer = 0 To colunas.Count - 1
            colunas(i).Name = nomes(i)
            colunas(i).DisplayIndex = i
            colunas(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Dim regra As DataGridViewComboBoxColumn = DirectCast(grade.Columns("regra"), DataGridViewComboBoxColumn)
        If regra.Items.Count = 0 Then regra.Items.AddRange("INTERVALO", "INFORMATIVO", "DECLARACAO", "FORMULA", "DOCUMENTAL")
        Dim propriedade As DataGridViewComboBoxColumn = DirectCast(grade.Columns("propriedade"), DataGridViewComboBoxColumn)
        propriedade.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        propriedade.FillWeight = 170
        For Each nome As String In New String() {"ui_minimo", "ui_maximo", "unidade", "referencia_normativa"}
            DirectCast(grade.Columns(nome), DataGridViewTextBoxColumn).MaxInputLength = If(nome = "referencia_normativa", 255, If(nome = "unidade", 30, 50))
        Next
    End Sub

    Private Sub ConfigurarGrade(grupo As String, grade As DataGridView)
        GarantirColunasDaGrade(grade)
        Dim propriedade As DataGridViewComboBoxColumn = DirectCast(grade.Columns("propriedade"), DataGridViewComboBoxColumn)
        propriedade.ValueMember = "id"
        propriedade.DisplayMember = "descricao"
        propriedade.DataSource = PropriedadesDoGrupo(grupo)
        AddHandler grade.CellValueChanged, Sub(sender As Object, e As DataGridViewCellEventArgs)
                                              If _ocupado OrElse e.RowIndex < 0 OrElse e.RowIndex >= grade.Rows.Count OrElse e.ColumnIndex < 0 Then Return
                                              _sujo = True
                                              If grade.Columns(e.ColumnIndex).Name = "propriedade" Then
                                                  Dim registro As DataRowView = TryCast(grade.Rows(e.RowIndex).DataBoundItem, DataRowView)
                                                  If registro Is Nothing OrElse registro.Row.IsNull("propriedade_id") Then Return
                                                  Dim row As DataRow = registro.Row
                                                  Dim p As DataRow = AcharPropriedade(Convert.ToInt32(row("propriedade_id")))
                                                  If p Is Nothing Then Return
                                                  row("codigo") = "REQ_" & Texto(p, "codigo")
                                                  If Texto(row, "unidade") = "" Then row("unidade") = p("unidade_sugerida")
                                              End If
                                          End Sub
        AddHandler grade.DataError, Sub(sender As Object, e As DataGridViewDataErrorEventArgs)
                                       e.ThrowException = False
                                       _resumo.Text = "Confira o valor digitado ou a propriedade selecionada antes de salvar."
                                   End Sub
    End Sub

    Private Sub VincularRegras()
        For Each par As KeyValuePair(Of String, DataGridView) In _grades
            Dim filtro As String = If(par.Key = "OUTROS", "grupo<>'QUIMICA' AND grupo<>'MECANICA' AND grupo<>'METALURGIA'", "grupo='" & par.Key & "'")
            par.Value.DataSource = New DataView(_regras, filtro, "ordem_exibicao", DataViewRowState.CurrentRows)
        Next
    End Sub

    Private Function PodeDescartar() As Boolean
        If Not _sujo Then Return True
        Return MessageBox.Show("Descartar as alterações que ainda não foram salvas?", "Configuração de normas",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    Private Sub AtualizarNormas(id As Integer)
        Dim tabela As DataTable = Consultar("SELECT *, CONCAT(entidade,' ',codigo,'-',edicao) AS rotulo FROM cert_normas ORDER BY codigo,edicao")
        _normas.DisplayMember = "rotulo"
        _normas.ValueMember = "id"
        _normas.DataSource = tabela
        If id > 0 Then _normas.SelectedValue = id Else _normas.SelectedIndex = -1
    End Sub

    Private Sub LimparNorma()
        _normaId = 0
        For Each c As Control In _normaCampos.Values
            c.Text = ""
            DirectCast(c, TextBox).ReadOnly = False
        Next
        _normaCampos("entidade").Text = "ASTM"
        _perfis.DataSource = Nothing
        LimparPerfil()
    End Sub

    Private Sub LimparPerfil()
        _perfilId = 0
        _revisao = 1
        _novaRevisao = False
        For Each c As Control In _perfilCampos.Values
            c.Text = ""
        Next
        _perfilCampos("sistema_unidades").Text = "SI"
        _perfilCampos("status").Text = "RASCUNHO"
        _extrasPerfil = New Dictionary(Of String, Object) From {
            {"dimensao_referencia", "NAO_DEFINIDA"}, {"dimensao_min", DBNull.Value}, {"dimensao_max", DBNull.Value},
            {"dimensao_min_inclusiva", True}, {"dimensao_max_inclusiva", True}, {"unidade_dimensao", DBNull.Value}, {"condicoes_adicionais", DBNull.Value}}
        _regras.Clear()
        VincularRegras()
        _resumo.Text = "Novo perfil. Limite vazio significa sem limite, não zero. Informe unidade, referência e condições aplicáveis."
    End Sub

    Private Sub NovaNorma(copiar As Boolean)
        If copiar AndAlso _normaId = 0 Then Throw New InvalidOperationException("Selecione uma norma existente para criar outra edição.")
        If Not copiar AndAlso Not PodeDescartar() Then Return
        FinalizarEdicao()
        Dim perfilCopiado As New Dictionary(Of String, String)()
        For Each par As KeyValuePair(Of String, Control) In _perfilCampos
            perfilCopiado.Add(par.Key, par.Value.Text)
        Next
        Dim extrasCopiados As New Dictionary(Of String, Object)(_extrasPerfil)
        Dim regrasCopiadas As DataTable = _regras.Copy()
        Dim copia As New Dictionary(Of String, String)()
        For Each par As KeyValuePair(Of String, Control) In _normaCampos
            copia.Add(par.Key, par.Value.Text)
        Next
        _ocupado = True
        _normas.SelectedIndex = -1
        LimparNorma()
        If copiar Then
            For Each par As KeyValuePair(Of String, String) In copia
                _normaCampos(par.Key).Text = If(par.Key = "edicao", "", par.Value)
            Next
            For Each par As KeyValuePair(Of String, String) In perfilCopiado
                _perfilCampos(par.Key).Text = If(par.Key = "status", "RASCUNHO", par.Value)
            Next
            _extrasPerfil = extrasCopiados
            _regras = regrasCopiadas
            VincularRegras()
            _resumo.Text = "Perfil copiado como rascunho. Confira documento, referências e limites contra a nova edição; salve a norma e depois o perfil."
        End If
        _ocupado = False
        _sujo = True
        _normaCampos(If(copiar, "edicao", "codigo")).Focus()
    End Sub

    Private Sub NormaSelecionada(sender As Object, e As EventArgs)
        If _ocupado OrElse _normas.SelectedIndex < 0 Then Return
        If Not PodeDescartar() Then
            _ocupado = True
            If _normaId > 0 Then _normas.SelectedValue = _normaId Else _normas.SelectedIndex = -1
            _ocupado = False
            Return
        End If
        Try
            CarregarNorma(Convert.ToInt32(_normas.SelectedValue))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Normas")
        End Try
    End Sub

    Private Sub CarregarNorma(id As Integer)
        _ocupado = True
        Try
            Dim dados As DataTable = Consultar("SELECT * FROM cert_normas WHERE id=@id", id)
            If dados.Rows.Count <> 1 Then Throw New InvalidOperationException("Norma não encontrada.")
            _normaId = id
            For Each par As KeyValuePair(Of String, Control) In _normaCampos
                par.Value.Text = Texto(dados.Rows(0), par.Key)
                DirectCast(par.Value, TextBox).ReadOnly = True
            Next
            AtualizarPerfis(0)
            LimparPerfil()
            _sujo = False
        Finally
            _ocupado = False
        End Try
    End Sub

    Private Sub AtualizarPerfis(id As Integer)
        Dim tabela As DataTable = Consultar("SELECT *, CONCAT(codigo,' | rev. ',revisao,' | ',condicao_fornecimento,' | ',status) AS rotulo " &
            "FROM cert_perfis_norma WHERE norma_id=@id ORDER BY codigo,revisao DESC", _normaId)
        _perfis.DisplayMember = "rotulo"
        _perfis.ValueMember = "id"
        _perfis.DataSource = tabela
        If id > 0 Then _perfis.SelectedValue = id Else _perfis.SelectedIndex = -1
    End Sub

    Private Sub PerfilSelecionado(sender As Object, e As EventArgs)
        If _ocupado OrElse _perfis.SelectedIndex < 0 Then Return
        If Not PodeDescartar() Then
            _ocupado = True
            If _perfilId > 0 Then _perfis.SelectedValue = _perfilId Else _perfis.SelectedIndex = -1
            _ocupado = False
            Return
        End If
        Try
            CarregarPerfil(Convert.ToInt32(_perfis.SelectedValue))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Perfil")
        End Try
    End Sub

    Private Sub CarregarPerfil(id As Integer)
        _ocupado = True
        Try
            Dim tabela As DataTable = Consultar("SELECT * FROM cert_perfis_norma WHERE id=@id", id)
            If tabela.Rows.Count <> 1 Then Throw New InvalidOperationException("Perfil não encontrado.")
            Dim perfil As DataRow = tabela.Rows(0)
            _perfilId = id
            _revisao = Convert.ToInt32(perfil("revisao"))
            _novaRevisao = False
            For Each par As KeyValuePair(Of String, Control) In _perfilCampos
                par.Value.Text = Texto(perfil, par.Key)
            Next
            For Each campo As String In New String() {"dimensao_referencia", "dimensao_min", "dimensao_max", "dimensao_min_inclusiva", "dimensao_max_inclusiva", "unidade_dimensao", "condicoes_adicionais"}
                _extrasPerfil(campo) = perfil(campo)
            Next
            _regras = TabelaRegras(Consultar("SELECT r.*,d.grupo FROM cert_requisitos r JOIN cert_propriedades d ON d.id=r.propriedade_id " &
                "WHERE r.perfil_id=@id ORDER BY ordem_exibicao,r.id", id))
            VincularRegras()
            _resumo.Text = "Revisão " & _revisao.ToString() & ". Se o perfil estiver vinculado a lotes ou não for rascunho, Salvar criará nova revisão em RASCUNHO."
            _sujo = False
        Finally
            _ocupado = False
        End Try
    End Sub

    Private Sub NovoPerfil()
        If _normaId = 0 Then Throw New InvalidOperationException("Selecione ou salve uma norma primeiro.")
        If Not PodeDescartar() Then Return
        _ocupado = True
        _perfis.SelectedIndex = -1
        LimparPerfil()
        _ocupado = False
        _sujo = True
    End Sub

    Private Sub NovaRevisao()
        If _perfilId = 0 Then Throw New InvalidOperationException("Carregue um perfil para copiar suas regras.")
        _novaRevisao = True
        _perfilCampos("status").Text = "RASCUNHO"
        _sujo = True
        _resumo.Text = "Nova revisão será criada ao salvar. A revisão anterior e seus vínculos serão preservados."
    End Sub

    Private Function AcharPropriedade(id As Integer) As DataRow
        For Each p As DataRow In _propriedades.Rows
            If Convert.ToInt32(p("id")) = id Then Return p
        Next
        Throw New InvalidOperationException("Propriedade não encontrada.")
    End Function

    Private Sub AdicionarRegra(grupo As String)
        If _normaId = 0 Then Throw New InvalidOperationException("Selecione ou salve a norma primeiro.")
        Dim propriedades As DataTable = PropriedadesDoGrupo(grupo)
        If propriedades.Rows.Count = 0 Then Throw New InvalidOperationException("Use Nova propriedade para cadastrar uma propriedade deste grupo.")
        Dim p As DataRow = propriedades.Rows(0)
        Dim row As DataRow = _regras.NewRow()
        row("id") = 0
        row("perfil_id") = _perfilId
        row("propriedade_id") = p("id")
        row("grupo") = p("grupo")
        row("codigo") = "REQ_" & Texto(p, "codigo")
        row("ordem_exibicao") = _regras.Rows.Count + 1
        row("tipo_regra") = "INTERVALO"
        row("obrigatorio_informar") = True
        row("minimo_inclusivo") = True
        row("maximo_inclusivo") = True
        row("unidade") = p("unidade_sugerida")
        row("ui_minimo") = ""
        row("ui_maximo") = ""
        row("tipo_analise") = "QUALQUER"
        row("etapa_amostra") = "QUALQUER"
        row("direcao_ensaio") = "QUALQUER"
        row("modo_arredondamento") = "E29"
        row("referencia_normativa") = ""
        _regras.Rows.Add(row)
        _sujo = True
    End Sub

    Private Sub RemoverRegra(grade As DataGridView)
        If grade.CurrentRow Is Nothing Then Return
        DirectCast(grade.CurrentRow.DataBoundItem, DataRowView).Row.Delete()
        _sujo = True
    End Sub

    Private Sub FinalizarEdicao()
        For Each grade As DataGridView In _grades.Values
            grade.EndEdit()
            If grade.DataSource IsNot Nothing Then DirectCast(BindingContext(grade.DataSource), CurrencyManager).EndCurrentEdit()
        Next
    End Sub

    Private Function Numero(texto As String) As Object
        If String.IsNullOrWhiteSpace(texto) Then Return DBNull.Value
        Dim n As Decimal
        If Not Regex.IsMatch(texto.Trim(), "^[+-]?(?:\d+(?:[.,]\d*)?|[.,]\d+)$") OrElse
            Not Decimal.TryParse(texto.Trim().Replace(",", "."), NumberStyles.AllowLeadingSign Or NumberStyles.AllowDecimalPoint,
                                 CultureInfo.InvariantCulture, n) Then
            Throw New ArgumentException("Número inválido: " & texto & ". Use vírgula ou ponto decimal, sem separador de milhar.")
        End If
        If Decimal.Round(n, 10) <> n OrElse Math.Abs(n) >= 100000000000000D Then Throw New ArgumentException("Número fora da precisão permitida: " & texto)
        Return n
    End Function

    Private Function Casas(texto As String) As Integer
        Dim normal As String = texto.Trim().Replace(",", ".")
        Dim ponto As Integer = normal.IndexOf("."c)
        If ponto < 0 Then Return 0
        Return normal.Length - ponto - 1
    End Function

    Private Sub ValidarRegras()
        FinalizarEdicao()
        Dim vistos As New HashSet(Of Integer)()
        For Each row As DataRow In _regras.Rows
            If row.RowState = DataRowState.Deleted Then Continue For
            Dim id As Integer = Convert.ToInt32(row("propriedade_id"))
            Dim p As DataRow = AcharPropriedade(id)
            If Not vistos.Add(id) Then Throw New ArgumentException("Propriedade repetida: " & Texto(p, "descricao") & ". Separe condições diferentes em outros perfis.")
            row("codigo") = "REQ_" & Texto(p, "codigo")
            Dim minimo As String = Texto(row, "ui_minimo").Trim(), maximo As String = Texto(row, "ui_maximo").Trim()
            row("minimo") = Numero(minimo)
            row("maximo") = Numero(maximo)
            row("limite_min_original") = If(minimo = "", CType(DBNull.Value, Object), CType(minimo.Replace(",", "."), Object))
            row("limite_max_original") = If(maximo = "", CType(DBNull.Value, Object), CType(maximo.Replace(",", "."), Object))
            row("casas_decimais_min") = If(minimo = "", CType(DBNull.Value, Object), CType(Casas(minimo), Object))
            row("casas_decimais_max") = If(maximo = "", CType(DBNull.Value, Object), CType(Casas(maximo), Object))
            If Casas(minimo) > 10 OrElse Casas(maximo) > 10 Then Throw New ArgumentException("O limite admite até dez casas decimais.")
            If Not row.IsNull("minimo") AndAlso Not row.IsNull("maximo") Then
                Dim a As Decimal = Convert.ToDecimal(row("minimo")), b As Decimal = Convert.ToDecimal(row("maximo"))
                If a > b OrElse (a = b AndAlso (Not Convert.ToBoolean(row("minimo_inclusivo")) OrElse Not Convert.ToBoolean(row("maximo_inclusivo")))) Then
                    Throw New ArgumentException("Intervalo vazio ou mínimo maior que máximo em " & Texto(p, "descricao"))
                End If
            End If
            Dim tipo As String = Texto(row, "tipo_regra")
            If tipo = "INTERVALO" AndAlso minimo = "" AndAlso maximo = "" Then Throw New ArgumentException("Informe mínimo ou máximo para " & Texto(p, "descricao"))
            If tipo = "INFORMATIVO" AndAlso (minimo <> "" OrElse maximo <> "") Then Throw New ArgumentException("Requisito informativo não deve ter limites de rejeição. Use as observações para valores típicos.")
            If (tipo = "INTERVALO" OrElse tipo = "FORMULA") AndAlso Texto(row, "unidade").Trim() = "" Then Throw New ArgumentException("Informe a unidade/escala de " & Texto(p, "descricao"))
            If tipo = "DECLARACAO" AndAlso Texto(row, "declaracao_esperada").Trim() = "" Then Throw New ArgumentException("Em Detalhes, informe a declaração esperada para " & Texto(p, "descricao"))
            If tipo = "FORMULA" AndAlso (Texto(row, "formula_codigo").Trim() = "" OrElse (minimo = "" AndAlso maximo = "")) Then Throw New ArgumentException("A fórmula precisa de código e limite. Configure em Detalhes.")
            If Texto(row, "referencia_normativa").Trim() = "" Then Throw New ArgumentException("Informe tabela/item da norma em " & Texto(p, "descricao"))
            If Texto(row, "tipo_regra") = "FORMULA" AndAlso _perfilCampos("status").Text = "LIBERADO" Then
                Throw New ArgumentException("O motor atual ainda não executa fórmulas. Mantenha esse perfil em RASCUNHO.")
            End If
        Next
    End Sub

    Private Function Executar(cn As MySqlConnection, tx As MySqlTransaction, sql As String,
                              valores As Dictionary(Of String, Object), Optional escalar As Boolean = False) As Object
        Using cmd As New MySqlCommand(sql, cn, tx)
            For Each par As KeyValuePair(Of String, Object) In valores
                cmd.Parameters.AddWithValue("@" & par.Key, par.Value)
            Next
            If escalar Then Return cmd.ExecuteScalar()
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Private Function ComGravacao(acao As Func(Of MySqlConnection, MySqlTransaction, Integer)) As Integer
        SessaoAtual.ExigirAutenticado()
        Using cn As MySqlConnection = conexao.NovaConexao()
            cn.Open()
            Using obterTrava As New MySqlCommand("SELECT GET_LOCK('sandinox_config_normas',5)", cn)
                Dim v As Object = obterTrava.ExecuteScalar()
                If v Is Nothing OrElse Convert.IsDBNull(v) OrElse Convert.ToInt32(v) <> 1 Then Throw New InvalidOperationException("Outra configuração está sendo gravada. Tente novamente.")
            End Using
            Try
                Using tx As MySqlTransaction = cn.BeginTransaction()
                    Try
                        Dim id As Integer = acao(cn, tx)
                        tx.Commit()
                        Return id
                    Catch
                        Try
                            tx.Rollback()
                        Catch
                        End Try
                        Throw
                    End Try
                End Using
            Finally
                Using liberar As New MySqlCommand("SELECT RELEASE_LOCK('sandinox_config_normas')", cn)
                    liberar.ExecuteScalar()
                End Using
            End Try
        End Using
    End Function

    Private Sub SalvarNorma()
        If _normaId > 0 Then Throw New InvalidOperationException("A identificação desta edição é preservada. Use Nova edição para registrar outro documento.")
        Dim valores As New Dictionary(Of String, Object)()
        For Each par As KeyValuePair(Of String, Control) In _normaCampos
            Dim valor As String = par.Value.Text.Trim()
            If par.Key <> "referencia_documento" AndAlso valor = "" Then Throw New ArgumentException("Preencha " & par.Key)
            valores.Add(par.Key, If(valor = "", CType(DBNull.Value, Object), CType(valor, Object)))
        Next
        Dim id As Integer = ComGravacao(Function(cn As MySqlConnection, tx As MySqlTransaction)
                                          Using cmd As New MySqlCommand("INSERT INTO cert_normas(entidade,codigo,edicao,descricao,referencia_documento) VALUES(@entidade,@codigo,@edicao,@descricao,@referencia_documento)", cn, tx)
                                              For Each par As KeyValuePair(Of String, Object) In valores
                                                  cmd.Parameters.AddWithValue("@" & par.Key, par.Value)
                                              Next
                                              cmd.ExecuteNonQuery()
                                              Return Convert.ToInt32(cmd.LastInsertedId)
                                          End Using
                                      End Function)
        _ocupado = True
        _normaId = id
        AtualizarNormas(id)
        AtualizarPerfis(0)
        For Each c As Control In _normaCampos.Values
            DirectCast(c, TextBox).ReadOnly = True
        Next
        _ocupado = False
        _sujo = _perfilCampos("descricao").Text.Trim() <> "" OrElse _perfilCampos("material_grau_tipo").Text.Trim() <> ""
        MessageBox.Show("Norma salva. Agora cadastre o perfil e seus requisitos.", "Normas")
    End Sub

    Private Function Vinculado(cn As MySqlConnection, tx As MySqlTransaction, id As Integer) As Boolean
        Dim p As New Dictionary(Of String, Object) From {{"id", id}}
        If Convert.ToInt32(Executar(cn, tx, "SELECT COUNT(*) FROM cert_lote_perfis WHERE perfil_id=@id", p, True)) > 0 Then Return True
        Dim existe As Integer = Convert.ToInt32(Executar(cn, tx, "SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA=DATABASE() AND TABLE_NAME='cert_selecao_lote'", New Dictionary(Of String, Object)(), True))
        Return existe > 0 AndAlso Convert.ToInt32(Executar(cn, tx, "SELECT COUNT(*) FROM cert_selecao_lote WHERE perfil_id=@id", p, True)) > 0
    End Function

    Private Sub SalvarPerfil()
        If _normaId = 0 Then Throw New InvalidOperationException("Salve ou selecione uma norma primeiro.")
        ValidarRegras()
        Dim campos As New Dictionary(Of String, Object)()
        For Each par As KeyValuePair(Of String, Control) In _perfilCampos
            Dim valor As String = par.Value.Text.Trim()
            If par.Key <> "designacao_uns" AndAlso valor = "" Then Throw New ArgumentException("Preencha " & par.Key)
            campos.Add(par.Key, If(valor = "", CType(DBNull.Value, Object), CType(valor, Object)))
        Next
        For Each par As KeyValuePair(Of String, Object) In _extrasPerfil
            campos.Add(par.Key, par.Value)
        Next
        If Not Convert.IsDBNull(campos("dimensao_min")) OrElse Not Convert.IsDBNull(campos("dimensao_max")) Then
            If Convert.IsDBNull(campos("unidade_dimensao")) OrElse Convert.ToString(campos("unidade_dimensao")).Trim() = "" Then Throw New ArgumentException("Informe unidade da dimensão em Dimensões e notas.")
            If Convert.ToString(campos("dimensao_referencia")) = "NAO_DEFINIDA" Then Throw New ArgumentException("Selecione a dimensão de referência em Dimensões e notas.")
            If Not Convert.IsDBNull(campos("dimensao_min")) AndAlso Not Convert.IsDBNull(campos("dimensao_max")) Then
                Dim a As Decimal = Convert.ToDecimal(campos("dimensao_min")), b As Decimal = Convert.ToDecimal(campos("dimensao_max"))
                If a > b OrElse (a = b AndAlso (Not Convert.ToBoolean(campos("dimensao_min_inclusiva")) OrElse Not Convert.ToBoolean(campos("dimensao_max_inclusiva")))) Then
                    Throw New ArgumentException("O intervalo de dimensões está vazio ou invertido.")
                End If
            End If
        End If
        campos.Add("norma_id", _normaId)
        Dim criouRevisao As Boolean = False
        Dim id As Integer = ComGravacao(Function(cn As MySqlConnection, tx As MySqlTransaction)
            Dim novo As Boolean = _perfilId = 0 OrElse _novaRevisao
            If _perfilId > 0 Then
                Dim estado As Object = Executar(cn, tx, "SELECT status FROM cert_perfis_norma WHERE id=@id FOR UPDATE",
                    New Dictionary(Of String, Object) From {{"id", _perfilId}}, True)
                If estado Is Nothing Then Throw New InvalidOperationException("Perfil removido por outra sessão. Reabra a tela.")
                If Convert.ToString(estado) <> "RASCUNHO" OrElse Vinculado(cn, tx, _perfilId) Then novo = True
            End If
            Dim alvo As Integer = _perfilId
            Dim revisao As Integer = _revisao
            If novo Then
                revisao = Convert.ToInt32(Executar(cn, tx, "SELECT COALESCE(MAX(revisao),0)+1 FROM cert_perfis_norma WHERE norma_id=@norma AND codigo=@codigo",
                    New Dictionary(Of String, Object) From {{"norma", _normaId}, {"codigo", campos("codigo")}}, True))
                If _perfilId > 0 Then
                    campos("status") = "RASCUNHO"
                    criouRevisao = True
                End If
            End If
            Dim qtd As Integer = 0
            For Each r As DataRow In _regras.Rows
                If r.RowState <> DataRowState.Deleted Then qtd += 1
            Next
            If Convert.ToString(campos("status")) = "LIBERADO" AndAlso qtd = 0 Then Throw New ArgumentException("Perfil sem requisitos não pode ser liberado.")
            campos.Add("revisao", revisao)
            campos.Add("revisado_por", If(Convert.ToString(campos("status")) = "LIBERADO", CType(SessaoAtual.Login, Object), CType(DBNull.Value, Object)))
            campos.Add("revisado_em", If(Convert.ToString(campos("status")) = "LIBERADO", CType(DateTime.Now, Object), CType(DBNull.Value, Object)))
            Dim colunas As New List(Of String)(), parametros As New List(Of String)(), sets As New List(Of String)()
            For Each chave As String In campos.Keys
                colunas.Add("`" & chave & "`")
                parametros.Add("@" & chave)
                sets.Add("`" & chave & "`=@" & chave)
            Next
            If novo Then
                Using cmd As New MySqlCommand("INSERT INTO cert_perfis_norma(" & String.Join(",", colunas.ToArray()) & ") VALUES(" & String.Join(",", parametros.ToArray()) & ")", cn, tx)
                    For Each par As KeyValuePair(Of String, Object) In campos
                        cmd.Parameters.AddWithValue("@" & par.Key, par.Value)
                    Next
                    cmd.ExecuteNonQuery()
                    alvo = Convert.ToInt32(cmd.LastInsertedId)
                End Using
            Else
                Dim valores As New Dictionary(Of String, Object)(campos)
                valores.Add("id", alvo)
                Executar(cn, tx, "UPDATE cert_perfis_norma SET " & String.Join(",", sets.ToArray()) & " WHERE id=@id", valores)
                Executar(cn, tx, "DELETE FROM cert_requisitos WHERE perfil_id=@id", New Dictionary(Of String, Object) From {{"id", alvo}})
            End If
            Dim ordem As Integer = 0
            For Each row As DataRow In _regras.Rows
                If row.RowState = DataRowState.Deleted Then Continue For
                ordem += 1
                Dim valores As New Dictionary(Of String, Object)()
                For Each col As DataColumn In _regras.Columns
                    If col.ColumnName = "id" OrElse col.ColumnName = "grupo" OrElse col.ColumnName.StartsWith("ui_") Then Continue For
                    valores.Add(col.ColumnName, row(col))
                Next
                valores("perfil_id") = alvo
                valores("ordem_exibicao") = ordem
                Dim rc As New List(Of String)(), rp As New List(Of String)()
                For Each chave As String In valores.Keys
                    rc.Add("`" & chave & "`")
                    rp.Add("@" & chave)
                Next
                Executar(cn, tx, "INSERT INTO cert_requisitos(" & String.Join(",", rc.ToArray()) & ") VALUES(" & String.Join(",", rp.ToArray()) & ")", valores)
            Next
            Return alvo
        End Function)
        _ocupado = True
        AtualizarPerfis(id)
        _ocupado = False
        CarregarPerfil(id)
        MessageBox.Show(If(criouRevisao, "Nova revisão salva em RASCUNHO. Os lotes anteriores mantêm a revisão original.", "Perfil e requisitos salvos."), "Normas")
    End Sub

    Private Sub DetalhesRegra(grade As DataGridView)
        FinalizarEdicao()
        If grade.CurrentRow Is Nothing Then Return
        Dim row As DataRow = DirectCast(grade.CurrentRow.DataBoundItem, DataRowView).Row
        Using janela As New frmDetalhesRequisito()
            Dim campos As Dictionary(Of String, Control) = janela.campos
            For Each par As KeyValuePair(Of String, Control) In campos
                par.Value.Text = Texto(row, par.Key)
            Next
            Dim novos As Dictionary(Of String, String) = If(janela.ShowDialog(Me) = DialogResult.OK, janela.LerValores(), Nothing)
            If novos IsNot Nothing Then
                For Each par As KeyValuePair(Of String, String) In novos
                    row(par.Key) = If(par.Value.Trim() = "", CType(DBNull.Value, Object), CType(par.Value.Trim(), Object))
                Next
                _sujo = True
            End If
        End Using
    End Sub

    Private Sub DetalhesPerfil()
        Using janela As New frmAplicacaoPerfil()
            Dim campos As Dictionary(Of String, Control) = janela.campos
            For Each par As KeyValuePair(Of String, Control) In campos
                If par.Key.EndsWith("_inclusiva") Then
                    par.Value.Text = If(Convert.ToBoolean(_extrasPerfil(par.Key)), "SIM", "NAO")
                Else
                    par.Value.Text = If(Convert.IsDBNull(_extrasPerfil(par.Key)), "", Convert.ToString(_extrasPerfil(par.Key), CultureInfo.InvariantCulture))
                End If
            Next
            Dim novos As Dictionary(Of String, String) = If(janela.ShowDialog(Me) = DialogResult.OK, janela.LerValores(), Nothing)
            If novos IsNot Nothing Then
                Dim minimo As Object = Numero(novos("dimensao_min")), maximo As Object = Numero(novos("dimensao_max"))
                If Not Convert.IsDBNull(minimo) AndAlso Not Convert.IsDBNull(maximo) AndAlso Convert.ToDecimal(minimo) > Convert.ToDecimal(maximo) Then Throw New ArgumentException("Dimensão mínima maior que máxima.")
                For Each par As KeyValuePair(Of String, String) In novos
                    _extrasPerfil(par.Key) = If(par.Value.Trim() = "", CType(DBNull.Value, Object), CType(par.Value.Trim(), Object))
                Next
                _extrasPerfil("dimensao_min") = minimo
                _extrasPerfil("dimensao_max") = maximo
                _extrasPerfil("dimensao_min_inclusiva") = novos("dimensao_min_inclusiva") = "SIM"
                _extrasPerfil("dimensao_max_inclusiva") = novos("dimensao_max_inclusiva") = "SIM"
                _sujo = True
            End If
        End Using
    End Sub



    Private Sub NovaPropriedade()
        Using janela As New frmPropriedadeNorma()
            Dim campos As Dictionary(Of String, Control) = janela.campos
            campos("grupo").Text = "QUIMICA"
            Dim novos As Dictionary(Of String, String) = If(janela.ShowDialog(Me) = DialogResult.OK, janela.LerValores(), Nothing)
            If novos Is Nothing Then Return
            For Each chave As String In New String() {"codigo", "descricao", "grupo"}
                If novos(chave).Trim() = "" Then Throw New ArgumentException("Preencha " & chave)
            Next
            Dim valores As New Dictionary(Of String, Object)()
            For Each par As KeyValuePair(Of String, String) In novos
                valores.Add(par.Key, If(par.Value.Trim() = "", CType(DBNull.Value, Object), CType(par.Value.Trim(), Object)))
            Next
            ComGravacao(Function(cn As MySqlConnection, tx As MySqlTransaction)
                            Executar(cn, tx, "INSERT INTO cert_propriedades(codigo,descricao,grupo,unidade_sugerida) VALUES(@codigo,@descricao,@grupo,@unidade_sugerida)", valores)
                            Return 0
                        End Function)
            _propriedades = Consultar("SELECT * FROM cert_propriedades ORDER BY grupo,descricao")
            _ocupado = True
            For Each par As KeyValuePair(Of String, DataGridView) In _grades
                DirectCast(par.Value.Columns("propriedade"), DataGridViewComboBoxColumn).DataSource = PropriedadesDoGrupo(par.Key)
            Next
            _ocupado = False
            MessageBox.Show("Propriedade cadastrada. Use Adicionar requisito na aba correspondente.", "Normas")
        End Using
    End Sub

    Private Sub AoFechar(sender As Object, e As FormClosingEventArgs)
        Try
            FinalizarEdicao()
        Catch ex As Exception
            e.Cancel = True
            MessageBox.Show(ex.Message, "Configuração de normas")
            Return
        End Try
        If Not PodeDescartar() Then e.Cancel = True
    End Sub
End Class
