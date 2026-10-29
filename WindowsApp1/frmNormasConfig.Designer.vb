<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNormasConfig
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.layoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.barraAcoes = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNovaNorma = New System.Windows.Forms.Button()
        Me.btnNovaEdicao = New System.Windows.Forms.Button()
        Me.btnSalvarNorma = New System.Windows.Forms.Button()
        Me.btnNovoPerfil = New System.Windows.Forms.Button()
        Me.btnNovaRevisao = New System.Windows.Forms.Button()
        Me.btnSalvarPerfil = New System.Windows.Forms.Button()
        Me.btnNovaPropriedade = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.layoutSeletores = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSeletor0 = New System.Windows.Forms.Label()
        Me._normas = New System.Windows.Forms.ComboBox()
        Me.lblSeletor1 = New System.Windows.Forms.Label()
        Me._perfis = New System.Windows.Forms.ComboBox()
        Me.grpNorma = New System.Windows.Forms.GroupBox()
        Me.layoutNorma = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNorma0 = New System.Windows.Forms.Label()
        Me.txtNorma_entidade = New System.Windows.Forms.TextBox()
        Me.lblNorma1 = New System.Windows.Forms.Label()
        Me.txtNorma_codigo = New System.Windows.Forms.TextBox()
        Me.lblNorma2 = New System.Windows.Forms.Label()
        Me.txtNorma_edicao = New System.Windows.Forms.TextBox()
        Me.lblNorma3 = New System.Windows.Forms.Label()
        Me.txtNorma_descricao = New System.Windows.Forms.TextBox()
        Me.lblNorma4 = New System.Windows.Forms.Label()
        Me.txtNorma_referencia_documento = New System.Windows.Forms.TextBox()
        Me.grpPerfil = New System.Windows.Forms.GroupBox()
        Me.layoutPerfil = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPerfil0 = New System.Windows.Forms.Label()
        Me.txtPerfil_codigo = New System.Windows.Forms.TextBox()
        Me.lblPerfil1 = New System.Windows.Forms.Label()
        Me.txtPerfil_descricao = New System.Windows.Forms.TextBox()
        Me.lblPerfil2 = New System.Windows.Forms.Label()
        Me.txtPerfil_material_grau_tipo = New System.Windows.Forms.TextBox()
        Me.lblPerfil3 = New System.Windows.Forms.Label()
        Me.txtPerfil_designacao_uns = New System.Windows.Forms.TextBox()
        Me.lblPerfil4 = New System.Windows.Forms.Label()
        Me.cboPerfil_forma_produto = New System.Windows.Forms.ComboBox()
        Me.lblPerfil5 = New System.Windows.Forms.Label()
        Me.cboPerfil_condicao_fornecimento = New System.Windows.Forms.ComboBox()
        Me.lblPerfil6 = New System.Windows.Forms.Label()
        Me.cboPerfil_sistema_unidades = New System.Windows.Forms.ComboBox()
        Me.lblPerfil7 = New System.Windows.Forms.Label()
        Me.cboPerfil_status = New System.Windows.Forms.ComboBox()
        Me.btnDimensoes = New System.Windows.Forms.Button()
        Me.abasRequisitos = New System.Windows.Forms.TabControl()
        Me.abaQUIMICA = New System.Windows.Forms.TabPage()
        Me.painelQUIMICA = New System.Windows.Forms.Panel()
        Me.gradeQUIMICA = New System.Windows.Forms.DataGridView()
        Me.botoesQUIMICA = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnQUIMICAAdicionar = New System.Windows.Forms.Button()
        Me.btnQUIMICARemover = New System.Windows.Forms.Button()
        Me.btnQUIMICADetalhes = New System.Windows.Forms.Button()
        Me.abaMECANICA = New System.Windows.Forms.TabPage()
        Me.painelMECANICA = New System.Windows.Forms.Panel()
        Me.gradeMECANICA = New System.Windows.Forms.DataGridView()
        Me.botoesMECANICA = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnMECANICAAdicionar = New System.Windows.Forms.Button()
        Me.btnMECANICARemover = New System.Windows.Forms.Button()
        Me.btnMECANICADetalhes = New System.Windows.Forms.Button()
        Me.abaMETALURGIA = New System.Windows.Forms.TabPage()
        Me.painelMETALURGIA = New System.Windows.Forms.Panel()
        Me.gradeMETALURGIA = New System.Windows.Forms.DataGridView()
        Me.botoesMETALURGIA = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnMETALURGIAAdicionar = New System.Windows.Forms.Button()
        Me.btnMETALURGIARemover = New System.Windows.Forms.Button()
        Me.btnMETALURGIADetalhes = New System.Windows.Forms.Button()
        Me.abaOUTROS = New System.Windows.Forms.TabPage()
        Me.painelOUTROS = New System.Windows.Forms.Panel()
        Me.gradeOUTROS = New System.Windows.Forms.DataGridView()
        Me.botoesOUTROS = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnOUTROSAdicionar = New System.Windows.Forms.Button()
        Me.btnOUTROSRemover = New System.Windows.Forms.Button()
        Me.btnOUTROSDetalhes = New System.Windows.Forms.Button()
        Me._resumo = New System.Windows.Forms.Label()
        Me.layoutPrincipal.SuspendLayout()
        Me.barraAcoes.SuspendLayout()
        Me.layoutSeletores.SuspendLayout()
        Me.grpNorma.SuspendLayout()
        Me.layoutNorma.SuspendLayout()
        Me.grpPerfil.SuspendLayout()
        Me.layoutPerfil.SuspendLayout()
        Me.abasRequisitos.SuspendLayout()
        Me.abaQUIMICA.SuspendLayout()
        Me.painelQUIMICA.SuspendLayout()
        CType(Me.gradeQUIMICA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.botoesQUIMICA.SuspendLayout()
        Me.abaMECANICA.SuspendLayout()
        Me.painelMECANICA.SuspendLayout()
        CType(Me.gradeMECANICA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.botoesMECANICA.SuspendLayout()
        Me.abaMETALURGIA.SuspendLayout()
        Me.painelMETALURGIA.SuspendLayout()
        CType(Me.gradeMETALURGIA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.botoesMETALURGIA.SuspendLayout()
        Me.abaOUTROS.SuspendLayout()
        Me.painelOUTROS.SuspendLayout()
        CType(Me.gradeOUTROS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.botoesOUTROS.SuspendLayout()
        Me.SuspendLayout()
        '
        'layoutPrincipal
        '
        Me.layoutPrincipal.ColumnCount = 1
        Me.layoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutPrincipal.Controls.Add(Me.barraAcoes, 0, 0)
        Me.layoutPrincipal.Controls.Add(Me.layoutSeletores, 0, 1)
        Me.layoutPrincipal.Controls.Add(Me.grpNorma, 0, 2)
        Me.layoutPrincipal.Controls.Add(Me.grpPerfil, 0, 3)
        Me.layoutPrincipal.Controls.Add(Me.abasRequisitos, 0, 4)
        Me.layoutPrincipal.Controls.Add(Me._resumo, 0, 5)
        Me.layoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.layoutPrincipal.Name = "layoutPrincipal"
        Me.layoutPrincipal.Padding = New System.Windows.Forms.Padding(10)
        Me.layoutPrincipal.RowCount = 6
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.layoutPrincipal.Size = New System.Drawing.Size(1224, 821)
        Me.layoutPrincipal.TabIndex = 0
        '
        'barraAcoes
        '
        Me.barraAcoes.AutoScroll = True
        Me.barraAcoes.Controls.Add(Me.btnNovaNorma)
        Me.barraAcoes.Controls.Add(Me.btnNovaEdicao)
        Me.barraAcoes.Controls.Add(Me.btnSalvarNorma)
        Me.barraAcoes.Controls.Add(Me.btnNovoPerfil)
        Me.barraAcoes.Controls.Add(Me.btnNovaRevisao)
        Me.barraAcoes.Controls.Add(Me.btnSalvarPerfil)
        Me.barraAcoes.Controls.Add(Me.btnNovaPropriedade)
        Me.barraAcoes.Controls.Add(Me.btnFechar)
        Me.barraAcoes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barraAcoes.Location = New System.Drawing.Point(13, 13)
        Me.barraAcoes.Name = "barraAcoes"
        Me.barraAcoes.Size = New System.Drawing.Size(1198, 32)
        Me.barraAcoes.TabIndex = 0
        Me.barraAcoes.WrapContents = False
        '
        'btnNovaNorma
        '
        Me.btnNovaNorma.AutoSize = True
        Me.btnNovaNorma.Location = New System.Drawing.Point(3, 3)
        Me.btnNovaNorma.Name = "btnNovaNorma"
        Me.btnNovaNorma.Size = New System.Drawing.Size(83, 28)
        Me.btnNovaNorma.TabIndex = 0
        Me.btnNovaNorma.Text = "Nova norma"
        '
        'btnNovaEdicao
        '
        Me.btnNovaEdicao.AutoSize = True
        Me.btnNovaEdicao.Location = New System.Drawing.Point(92, 3)
        Me.btnNovaEdicao.Name = "btnNovaEdicao"
        Me.btnNovaEdicao.Size = New System.Drawing.Size(83, 28)
        Me.btnNovaEdicao.TabIndex = 1
        Me.btnNovaEdicao.Text = "Nova edição"
        '
        'btnSalvarNorma
        '
        Me.btnSalvarNorma.AutoSize = True
        Me.btnSalvarNorma.Location = New System.Drawing.Point(181, 3)
        Me.btnSalvarNorma.Name = "btnSalvarNorma"
        Me.btnSalvarNorma.Size = New System.Drawing.Size(86, 28)
        Me.btnSalvarNorma.TabIndex = 2
        Me.btnSalvarNorma.Text = "Salvar norma"
        '
        'btnNovoPerfil
        '
        Me.btnNovoPerfil.AutoSize = True
        Me.btnNovoPerfil.Location = New System.Drawing.Point(273, 3)
        Me.btnNovoPerfil.Name = "btnNovoPerfil"
        Me.btnNovoPerfil.Size = New System.Drawing.Size(76, 28)
        Me.btnNovoPerfil.TabIndex = 3
        Me.btnNovoPerfil.Text = "Novo perfil"
        '
        'btnNovaRevisao
        '
        Me.btnNovaRevisao.AutoSize = True
        Me.btnNovaRevisao.Location = New System.Drawing.Point(355, 3)
        Me.btnNovaRevisao.Name = "btnNovaRevisao"
        Me.btnNovaRevisao.Size = New System.Drawing.Size(85, 28)
        Me.btnNovaRevisao.TabIndex = 4
        Me.btnNovaRevisao.Text = "Nova revisão"
        '
        'btnSalvarPerfil
        '
        Me.btnSalvarPerfil.AutoSize = True
        Me.btnSalvarPerfil.Location = New System.Drawing.Point(446, 3)
        Me.btnSalvarPerfil.Name = "btnSalvarPerfil"
        Me.btnSalvarPerfil.Size = New System.Drawing.Size(122, 28)
        Me.btnSalvarPerfil.TabIndex = 5
        Me.btnSalvarPerfil.Text = "Salvar perfil e regras"
        '
        'btnNovaPropriedade
        '
        Me.btnNovaPropriedade.AutoSize = True
        Me.btnNovaPropriedade.Location = New System.Drawing.Point(574, 3)
        Me.btnNovaPropriedade.Name = "btnNovaPropriedade"
        Me.btnNovaPropriedade.Size = New System.Drawing.Size(112, 28)
        Me.btnNovaPropriedade.TabIndex = 6
        Me.btnNovaPropriedade.Text = "Nova propriedade"
        '
        'btnFechar
        '
        Me.btnFechar.AutoSize = True
        Me.btnFechar.Location = New System.Drawing.Point(692, 3)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(75, 28)
        Me.btnFechar.TabIndex = 7
        Me.btnFechar.Text = "Fechar"
        '
        'layoutSeletores
        '
        Me.layoutSeletores.ColumnCount = 2
        Me.layoutSeletores.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutSeletores.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutSeletores.Controls.Add(Me.lblSeletor0, 0, 0)
        Me.layoutSeletores.Controls.Add(Me._normas, 0, 1)
        Me.layoutSeletores.Controls.Add(Me.lblSeletor1, 1, 0)
        Me.layoutSeletores.Controls.Add(Me._perfis, 1, 1)
        Me.layoutSeletores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutSeletores.Location = New System.Drawing.Point(13, 51)
        Me.layoutSeletores.Name = "layoutSeletores"
        Me.layoutSeletores.RowCount = 2
        Me.layoutSeletores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutSeletores.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.layoutSeletores.Size = New System.Drawing.Size(1198, 48)
        Me.layoutSeletores.TabIndex = 1
        '
        'lblSeletor0
        '
        Me.lblSeletor0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSeletor0.Location = New System.Drawing.Point(3, 0)
        Me.lblSeletor0.Name = "lblSeletor0"
        Me.lblSeletor0.Size = New System.Drawing.Size(593, 20)
        Me.lblSeletor0.TabIndex = 0
        Me.lblSeletor0.Text = "Norma e edição cadastradas"
        '
        '_normas
        '
        Me._normas.Dock = System.Windows.Forms.DockStyle.Fill
        Me._normas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._normas.Location = New System.Drawing.Point(3, 23)
        Me._normas.Name = "_normas"
        Me._normas.Size = New System.Drawing.Size(593, 23)
        Me._normas.TabIndex = 1
        '
        'lblSeletor1
        '
        Me.lblSeletor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSeletor1.Location = New System.Drawing.Point(602, 0)
        Me.lblSeletor1.Name = "lblSeletor1"
        Me.lblSeletor1.Size = New System.Drawing.Size(593, 20)
        Me.lblSeletor1.TabIndex = 2
        Me.lblSeletor1.Text = "Perfil: liga/grau, forma, condição e revisão"
        '
        '_perfis
        '
        Me._perfis.Dock = System.Windows.Forms.DockStyle.Fill
        Me._perfis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._perfis.Location = New System.Drawing.Point(602, 23)
        Me._perfis.Name = "_perfis"
        Me._perfis.Size = New System.Drawing.Size(593, 23)
        Me._perfis.TabIndex = 3
        '
        'grpNorma
        '
        Me.grpNorma.Controls.Add(Me.layoutNorma)
        Me.grpNorma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNorma.Location = New System.Drawing.Point(13, 105)
        Me.grpNorma.Name = "grpNorma"
        Me.grpNorma.Size = New System.Drawing.Size(1198, 104)
        Me.grpNorma.TabIndex = 2
        Me.grpNorma.TabStop = False
        Me.grpNorma.Text = "Identificação da norma — edição oficial do documento"
        '
        'layoutNorma
        '
        Me.layoutNorma.ColumnCount = 3
        Me.layoutNorma.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutNorma.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutNorma.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutNorma.Controls.Add(Me.lblNorma0, 0, 0)
        Me.layoutNorma.Controls.Add(Me.txtNorma_entidade, 0, 1)
        Me.layoutNorma.Controls.Add(Me.lblNorma1, 1, 0)
        Me.layoutNorma.Controls.Add(Me.txtNorma_codigo, 1, 1)
        Me.layoutNorma.Controls.Add(Me.lblNorma2, 2, 0)
        Me.layoutNorma.Controls.Add(Me.txtNorma_edicao, 2, 1)
        Me.layoutNorma.Controls.Add(Me.lblNorma3, 0, 2)
        Me.layoutNorma.Controls.Add(Me.txtNorma_descricao, 0, 3)
        Me.layoutNorma.Controls.Add(Me.lblNorma4, 1, 2)
        Me.layoutNorma.Controls.Add(Me.txtNorma_referencia_documento, 1, 3)
        Me.layoutNorma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutNorma.Location = New System.Drawing.Point(3, 19)
        Me.layoutNorma.Name = "layoutNorma"
        Me.layoutNorma.RowCount = 6
        Me.layoutNorma.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layoutNorma.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.layoutNorma.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layoutNorma.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.layoutNorma.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layoutNorma.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.layoutNorma.Size = New System.Drawing.Size(1192, 82)
        Me.layoutNorma.TabIndex = 0
        '
        'lblNorma0
        '
        Me.lblNorma0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNorma0.Location = New System.Drawing.Point(3, 0)
        Me.lblNorma0.Name = "lblNorma0"
        Me.lblNorma0.Size = New System.Drawing.Size(391, 17)
        Me.lblNorma0.TabIndex = 0
        Me.lblNorma0.Text = "Entidade (ASTM, ISO, ABNT...)"
        '
        'txtNorma_entidade
        '
        Me.txtNorma_entidade.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNorma_entidade.Location = New System.Drawing.Point(3, 20)
        Me.txtNorma_entidade.Name = "txtNorma_entidade"
        Me.txtNorma_entidade.Size = New System.Drawing.Size(391, 23)
        Me.txtNorma_entidade.TabIndex = 1
        '
        'lblNorma1
        '
        Me.lblNorma1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNorma1.Location = New System.Drawing.Point(400, 0)
        Me.lblNorma1.Name = "lblNorma1"
        Me.lblNorma1.Size = New System.Drawing.Size(391, 17)
        Me.lblNorma1.TabIndex = 2
        Me.lblNorma1.Text = "Especificação (ex.: F1537)"
        '
        'txtNorma_codigo
        '
        Me.txtNorma_codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNorma_codigo.Location = New System.Drawing.Point(400, 20)
        Me.txtNorma_codigo.Name = "txtNorma_codigo"
        Me.txtNorma_codigo.Size = New System.Drawing.Size(391, 23)
        Me.txtNorma_codigo.TabIndex = 3
        '
        'lblNorma2
        '
        Me.lblNorma2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNorma2.Location = New System.Drawing.Point(797, 0)
        Me.lblNorma2.Name = "lblNorma2"
        Me.lblNorma2.Size = New System.Drawing.Size(392, 17)
        Me.lblNorma2.TabIndex = 4
        Me.lblNorma2.Text = "Edição / versão (ex.: 20)"
        '
        'txtNorma_edicao
        '
        Me.txtNorma_edicao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNorma_edicao.Location = New System.Drawing.Point(797, 20)
        Me.txtNorma_edicao.Name = "txtNorma_edicao"
        Me.txtNorma_edicao.Size = New System.Drawing.Size(392, 23)
        Me.txtNorma_edicao.TabIndex = 5
        '
        'lblNorma3
        '
        Me.lblNorma3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNorma3.Location = New System.Drawing.Point(3, 44)
        Me.lblNorma3.Name = "lblNorma3"
        Me.lblNorma3.Size = New System.Drawing.Size(391, 17)
        Me.lblNorma3.TabIndex = 6
        Me.lblNorma3.Text = "Descrição"
        '
        'txtNorma_descricao
        '
        Me.txtNorma_descricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNorma_descricao.Location = New System.Drawing.Point(3, 64)
        Me.txtNorma_descricao.Name = "txtNorma_descricao"
        Me.txtNorma_descricao.Size = New System.Drawing.Size(391, 23)
        Me.txtNorma_descricao.TabIndex = 7
        '
        'lblNorma4
        '
        Me.lblNorma4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNorma4.Location = New System.Drawing.Point(400, 44)
        Me.lblNorma4.Name = "lblNorma4"
        Me.lblNorma4.Size = New System.Drawing.Size(391, 17)
        Me.lblNorma4.TabIndex = 8
        Me.lblNorma4.Text = "Referência do documento / PDF"
        '
        'txtNorma_referencia_documento
        '
        Me.txtNorma_referencia_documento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNorma_referencia_documento.Location = New System.Drawing.Point(400, 64)
        Me.txtNorma_referencia_documento.Name = "txtNorma_referencia_documento"
        Me.txtNorma_referencia_documento.Size = New System.Drawing.Size(391, 23)
        Me.txtNorma_referencia_documento.TabIndex = 9
        '
        'grpPerfil
        '
        Me.grpPerfil.Controls.Add(Me.layoutPerfil)
        Me.grpPerfil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPerfil.Location = New System.Drawing.Point(13, 215)
        Me.grpPerfil.Name = "grpPerfil"
        Me.grpPerfil.Size = New System.Drawing.Size(1198, 146)
        Me.grpPerfil.TabIndex = 3
        Me.grpPerfil.TabStop = False
        Me.grpPerfil.Text = "Aplicação dos requisitos — revisão independente da edição"
        '
        'layoutPerfil
        '
        Me.layoutPerfil.ColumnCount = 3
        Me.layoutPerfil.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutPerfil.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutPerfil.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.layoutPerfil.Controls.Add(Me.lblPerfil0, 0, 0)
        Me.layoutPerfil.Controls.Add(Me.txtPerfil_codigo, 0, 1)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil1, 1, 0)
        Me.layoutPerfil.Controls.Add(Me.txtPerfil_descricao, 1, 1)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil2, 2, 0)
        Me.layoutPerfil.Controls.Add(Me.txtPerfil_material_grau_tipo, 2, 1)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil3, 0, 2)
        Me.layoutPerfil.Controls.Add(Me.txtPerfil_designacao_uns, 0, 3)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil4, 1, 2)
        Me.layoutPerfil.Controls.Add(Me.cboPerfil_forma_produto, 1, 3)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil5, 2, 2)
        Me.layoutPerfil.Controls.Add(Me.cboPerfil_condicao_fornecimento, 2, 3)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil6, 0, 4)
        Me.layoutPerfil.Controls.Add(Me.cboPerfil_sistema_unidades, 0, 5)
        Me.layoutPerfil.Controls.Add(Me.lblPerfil7, 1, 4)
        Me.layoutPerfil.Controls.Add(Me.cboPerfil_status, 1, 5)
        Me.layoutPerfil.Controls.Add(Me.btnDimensoes, 2, 4)
        Me.layoutPerfil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutPerfil.Location = New System.Drawing.Point(3, 19)
        Me.layoutPerfil.Name = "layoutPerfil"
        Me.layoutPerfil.RowCount = 6
        Me.layoutPerfil.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layoutPerfil.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.layoutPerfil.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layoutPerfil.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.layoutPerfil.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.layoutPerfil.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.layoutPerfil.Size = New System.Drawing.Size(1192, 124)
        Me.layoutPerfil.TabIndex = 0
        '
        'lblPerfil0
        '
        Me.lblPerfil0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil0.Location = New System.Drawing.Point(3, 0)
        Me.lblPerfil0.Name = "lblPerfil0"
        Me.lblPerfil0.Size = New System.Drawing.Size(391, 17)
        Me.lblPerfil0.TabIndex = 0
        Me.lblPerfil0.Text = "Código do perfil"
        '
        'txtPerfil_codigo
        '
        Me.txtPerfil_codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPerfil_codigo.Location = New System.Drawing.Point(3, 20)
        Me.txtPerfil_codigo.Name = "txtPerfil_codigo"
        Me.txtPerfil_codigo.Size = New System.Drawing.Size(391, 23)
        Me.txtPerfil_codigo.TabIndex = 1
        '
        'lblPerfil1
        '
        Me.lblPerfil1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil1.Location = New System.Drawing.Point(400, 0)
        Me.lblPerfil1.Name = "lblPerfil1"
        Me.lblPerfil1.Size = New System.Drawing.Size(391, 17)
        Me.lblPerfil1.TabIndex = 2
        Me.lblPerfil1.Text = "Descrição do perfil"
        '
        'txtPerfil_descricao
        '
        Me.txtPerfil_descricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPerfil_descricao.Location = New System.Drawing.Point(400, 20)
        Me.txtPerfil_descricao.Name = "txtPerfil_descricao"
        Me.txtPerfil_descricao.Size = New System.Drawing.Size(391, 23)
        Me.txtPerfil_descricao.TabIndex = 3
        '
        'lblPerfil2
        '
        Me.lblPerfil2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil2.Location = New System.Drawing.Point(797, 0)
        Me.lblPerfil2.Name = "lblPerfil2"
        Me.lblPerfil2.Size = New System.Drawing.Size(392, 17)
        Me.lblPerfil2.TabIndex = 4
        Me.lblPerfil2.Text = "Liga / grau / tipo"
        '
        'txtPerfil_material_grau_tipo
        '
        Me.txtPerfil_material_grau_tipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPerfil_material_grau_tipo.Location = New System.Drawing.Point(797, 20)
        Me.txtPerfil_material_grau_tipo.Name = "txtPerfil_material_grau_tipo"
        Me.txtPerfil_material_grau_tipo.Size = New System.Drawing.Size(392, 23)
        Me.txtPerfil_material_grau_tipo.TabIndex = 5
        '
        'lblPerfil3
        '
        Me.lblPerfil3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil3.Location = New System.Drawing.Point(3, 44)
        Me.lblPerfil3.Name = "lblPerfil3"
        Me.lblPerfil3.Size = New System.Drawing.Size(391, 17)
        Me.lblPerfil3.TabIndex = 6
        Me.lblPerfil3.Text = "Designação UNS"
        '
        'txtPerfil_designacao_uns
        '
        Me.txtPerfil_designacao_uns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPerfil_designacao_uns.Location = New System.Drawing.Point(3, 64)
        Me.txtPerfil_designacao_uns.Name = "txtPerfil_designacao_uns"
        Me.txtPerfil_designacao_uns.Size = New System.Drawing.Size(391, 23)
        Me.txtPerfil_designacao_uns.TabIndex = 7
        '
        'lblPerfil4
        '
        Me.lblPerfil4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil4.Location = New System.Drawing.Point(400, 44)
        Me.lblPerfil4.Name = "lblPerfil4"
        Me.lblPerfil4.Size = New System.Drawing.Size(391, 17)
        Me.lblPerfil4.TabIndex = 8
        Me.lblPerfil4.Text = "Forma do produto"
        '
        'cboPerfil_forma_produto
        '
        Me.cboPerfil_forma_produto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPerfil_forma_produto.Items.AddRange(New Object() {"BARRA", "FIO", "CHAPA", "TIRA", "PLACA", "FORJADO", "OUTRA"})
        Me.cboPerfil_forma_produto.Location = New System.Drawing.Point(400, 64)
        Me.cboPerfil_forma_produto.Name = "cboPerfil_forma_produto"
        Me.cboPerfil_forma_produto.Size = New System.Drawing.Size(391, 23)
        Me.cboPerfil_forma_produto.TabIndex = 9
        '
        'lblPerfil5
        '
        Me.lblPerfil5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil5.Location = New System.Drawing.Point(797, 44)
        Me.lblPerfil5.Name = "lblPerfil5"
        Me.lblPerfil5.Size = New System.Drawing.Size(392, 17)
        Me.lblPerfil5.TabIndex = 10
        Me.lblPerfil5.Text = "Condição de fornecimento"
        '
        'cboPerfil_condicao_fornecimento
        '
        Me.cboPerfil_condicao_fornecimento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPerfil_condicao_fornecimento.Items.AddRange(New Object() {"RECOZIDO", "TRABALHADO_A_MORNO", "TRABALHADO_A_QUENTE", "TRABALHADO_A_FRIO", "A_CONFIRMAR"})
        Me.cboPerfil_condicao_fornecimento.Location = New System.Drawing.Point(797, 64)
        Me.cboPerfil_condicao_fornecimento.Name = "cboPerfil_condicao_fornecimento"
        Me.cboPerfil_condicao_fornecimento.Size = New System.Drawing.Size(392, 23)
        Me.cboPerfil_condicao_fornecimento.TabIndex = 11
        '
        'lblPerfil6
        '
        Me.lblPerfil6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil6.Location = New System.Drawing.Point(3, 88)
        Me.lblPerfil6.Name = "lblPerfil6"
        Me.lblPerfil6.Size = New System.Drawing.Size(391, 17)
        Me.lblPerfil6.TabIndex = 12
        Me.lblPerfil6.Text = "Sistema de unidades"
        '
        'cboPerfil_sistema_unidades
        '
        Me.cboPerfil_sistema_unidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPerfil_sistema_unidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerfil_sistema_unidades.Items.AddRange(New Object() {"SI", "IMPERIAL"})
        Me.cboPerfil_sistema_unidades.Location = New System.Drawing.Point(3, 108)
        Me.cboPerfil_sistema_unidades.Name = "cboPerfil_sistema_unidades"
        Me.cboPerfil_sistema_unidades.Size = New System.Drawing.Size(391, 23)
        Me.cboPerfil_sistema_unidades.TabIndex = 13
        '
        'lblPerfil7
        '
        Me.lblPerfil7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPerfil7.Location = New System.Drawing.Point(400, 88)
        Me.lblPerfil7.Name = "lblPerfil7"
        Me.lblPerfil7.Size = New System.Drawing.Size(391, 17)
        Me.lblPerfil7.TabIndex = 14
        Me.lblPerfil7.Text = "Situação da configuração"
        '
        'cboPerfil_status
        '
        Me.cboPerfil_status.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPerfil_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerfil_status.Items.AddRange(New Object() {"RASCUNHO", "LIBERADO", "INATIVO"})
        Me.cboPerfil_status.Location = New System.Drawing.Point(400, 108)
        Me.cboPerfil_status.Name = "cboPerfil_status"
        Me.cboPerfil_status.Size = New System.Drawing.Size(391, 23)
        Me.cboPerfil_status.TabIndex = 15
        '
        'btnDimensoes
        '
        Me.btnDimensoes.AutoSize = True
        Me.btnDimensoes.Location = New System.Drawing.Point(797, 91)
        Me.btnDimensoes.Name = "btnDimensoes"
        Me.btnDimensoes.Size = New System.Drawing.Size(163, 11)
        Me.btnDimensoes.TabIndex = 16
        Me.btnDimensoes.Text = "Dimensões e notas do perfil"
        '
        'abasRequisitos
        '
        Me.abasRequisitos.Controls.Add(Me.abaQUIMICA)
        Me.abasRequisitos.Controls.Add(Me.abaMECANICA)
        Me.abasRequisitos.Controls.Add(Me.abaMETALURGIA)
        Me.abasRequisitos.Controls.Add(Me.abaOUTROS)
        Me.abasRequisitos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abasRequisitos.Location = New System.Drawing.Point(13, 367)
        Me.abasRequisitos.Name = "abasRequisitos"
        Me.abasRequisitos.SelectedIndex = 0
        Me.abasRequisitos.Size = New System.Drawing.Size(1198, 393)
        Me.abasRequisitos.TabIndex = 4
        '
        'abaQUIMICA
        '
        Me.abaQUIMICA.Controls.Add(Me.painelQUIMICA)
        Me.abaQUIMICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abaQUIMICA.Location = New System.Drawing.Point(4, 24)
        Me.abaQUIMICA.Name = "abaQUIMICA"
        Me.abaQUIMICA.Size = New System.Drawing.Size(1190, 365)
        Me.abaQUIMICA.TabIndex = 0
        Me.abaQUIMICA.Text = "Composição Química"
        '
        'painelQUIMICA
        '
        Me.painelQUIMICA.Controls.Add(Me.gradeQUIMICA)
        Me.painelQUIMICA.Controls.Add(Me.botoesQUIMICA)
        Me.painelQUIMICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.painelQUIMICA.Location = New System.Drawing.Point(0, 0)
        Me.painelQUIMICA.Name = "painelQUIMICA"
        Me.painelQUIMICA.Size = New System.Drawing.Size(1190, 365)
        Me.painelQUIMICA.TabIndex = 0
        '
        'gradeQUIMICA
        '
        Me.gradeQUIMICA.AllowUserToAddRows = False
        Me.gradeQUIMICA.AllowUserToDeleteRows = False
        Me.gradeQUIMICA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gradeQUIMICA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gradeQUIMICA.BackgroundColor = System.Drawing.Color.White
        Me.gradeQUIMICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gradeQUIMICA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gradeQUIMICA.Location = New System.Drawing.Point(0, 35)
        Me.gradeQUIMICA.Name = "gradeQUIMICA"
        Me.gradeQUIMICA.RowHeadersVisible = False
        Me.gradeQUIMICA.Size = New System.Drawing.Size(1190, 330)
        Me.gradeQUIMICA.TabIndex = 0
        '
        'botoesQUIMICA
        '
        Me.botoesQUIMICA.Controls.Add(Me.btnQUIMICAAdicionar)
        Me.botoesQUIMICA.Controls.Add(Me.btnQUIMICARemover)
        Me.botoesQUIMICA.Controls.Add(Me.btnQUIMICADetalhes)
        Me.botoesQUIMICA.Dock = System.Windows.Forms.DockStyle.Top
        Me.botoesQUIMICA.Location = New System.Drawing.Point(0, 0)
        Me.botoesQUIMICA.Name = "botoesQUIMICA"
        Me.botoesQUIMICA.Size = New System.Drawing.Size(1190, 35)
        Me.botoesQUIMICA.TabIndex = 1
        '
        'btnQUIMICAAdicionar
        '
        Me.btnQUIMICAAdicionar.AutoSize = True
        Me.btnQUIMICAAdicionar.Location = New System.Drawing.Point(3, 3)
        Me.btnQUIMICAAdicionar.Name = "btnQUIMICAAdicionar"
        Me.btnQUIMICAAdicionar.Size = New System.Drawing.Size(117, 28)
        Me.btnQUIMICAAdicionar.TabIndex = 0
        Me.btnQUIMICAAdicionar.Text = "Adicionar requisito"
        '
        'btnQUIMICARemover
        '
        Me.btnQUIMICARemover.AutoSize = True
        Me.btnQUIMICARemover.Location = New System.Drawing.Point(126, 3)
        Me.btnQUIMICARemover.Name = "btnQUIMICARemover"
        Me.btnQUIMICARemover.Size = New System.Drawing.Size(93, 28)
        Me.btnQUIMICARemover.TabIndex = 1
        Me.btnQUIMICARemover.Text = "Remover linha"
        '
        'btnQUIMICADetalhes
        '
        Me.btnQUIMICADetalhes.AutoSize = True
        Me.btnQUIMICADetalhes.Location = New System.Drawing.Point(225, 3)
        Me.btnQUIMICADetalhes.Name = "btnQUIMICADetalhes"
        Me.btnQUIMICADetalhes.Size = New System.Drawing.Size(167, 28)
        Me.btnQUIMICADetalhes.TabIndex = 2
        Me.btnQUIMICADetalhes.Text = "Detalhes / condições / notas"
        '
        'abaMECANICA
        '
        Me.abaMECANICA.Controls.Add(Me.painelMECANICA)
        Me.abaMECANICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abaMECANICA.Location = New System.Drawing.Point(4, 24)
        Me.abaMECANICA.Name = "abaMECANICA"
        Me.abaMECANICA.Size = New System.Drawing.Size(166, 0)
        Me.abaMECANICA.TabIndex = 1
        Me.abaMECANICA.Text = "Propriedades Mecânicas"
        '
        'painelMECANICA
        '
        Me.painelMECANICA.Controls.Add(Me.gradeMECANICA)
        Me.painelMECANICA.Controls.Add(Me.botoesMECANICA)
        Me.painelMECANICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.painelMECANICA.Location = New System.Drawing.Point(0, 0)
        Me.painelMECANICA.Name = "painelMECANICA"
        Me.painelMECANICA.Size = New System.Drawing.Size(166, 0)
        Me.painelMECANICA.TabIndex = 0
        '
        'gradeMECANICA
        '
        Me.gradeMECANICA.AllowUserToAddRows = False
        Me.gradeMECANICA.AllowUserToDeleteRows = False
        Me.gradeMECANICA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gradeMECANICA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gradeMECANICA.BackgroundColor = System.Drawing.Color.White
        Me.gradeMECANICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gradeMECANICA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gradeMECANICA.Location = New System.Drawing.Point(0, 35)
        Me.gradeMECANICA.Name = "gradeMECANICA"
        Me.gradeMECANICA.RowHeadersVisible = False
        Me.gradeMECANICA.Size = New System.Drawing.Size(166, 0)
        Me.gradeMECANICA.TabIndex = 0
        '
        'botoesMECANICA
        '
        Me.botoesMECANICA.Controls.Add(Me.btnMECANICAAdicionar)
        Me.botoesMECANICA.Controls.Add(Me.btnMECANICARemover)
        Me.botoesMECANICA.Controls.Add(Me.btnMECANICADetalhes)
        Me.botoesMECANICA.Dock = System.Windows.Forms.DockStyle.Top
        Me.botoesMECANICA.Location = New System.Drawing.Point(0, 0)
        Me.botoesMECANICA.Name = "botoesMECANICA"
        Me.botoesMECANICA.Size = New System.Drawing.Size(166, 35)
        Me.botoesMECANICA.TabIndex = 1
        '
        'btnMECANICAAdicionar
        '
        Me.btnMECANICAAdicionar.AutoSize = True
        Me.btnMECANICAAdicionar.Location = New System.Drawing.Point(3, 3)
        Me.btnMECANICAAdicionar.Name = "btnMECANICAAdicionar"
        Me.btnMECANICAAdicionar.Size = New System.Drawing.Size(117, 28)
        Me.btnMECANICAAdicionar.TabIndex = 0
        Me.btnMECANICAAdicionar.Text = "Adicionar requisito"
        '
        'btnMECANICARemover
        '
        Me.btnMECANICARemover.AutoSize = True
        Me.btnMECANICARemover.Location = New System.Drawing.Point(3, 37)
        Me.btnMECANICARemover.Name = "btnMECANICARemover"
        Me.btnMECANICARemover.Size = New System.Drawing.Size(93, 28)
        Me.btnMECANICARemover.TabIndex = 1
        Me.btnMECANICARemover.Text = "Remover linha"
        '
        'btnMECANICADetalhes
        '
        Me.btnMECANICADetalhes.AutoSize = True
        Me.btnMECANICADetalhes.Location = New System.Drawing.Point(3, 71)
        Me.btnMECANICADetalhes.Name = "btnMECANICADetalhes"
        Me.btnMECANICADetalhes.Size = New System.Drawing.Size(167, 28)
        Me.btnMECANICADetalhes.TabIndex = 2
        Me.btnMECANICADetalhes.Text = "Detalhes / condições / notas"
        '
        'abaMETALURGIA
        '
        Me.abaMETALURGIA.Controls.Add(Me.painelMETALURGIA)
        Me.abaMETALURGIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abaMETALURGIA.Location = New System.Drawing.Point(4, 24)
        Me.abaMETALURGIA.Name = "abaMETALURGIA"
        Me.abaMETALURGIA.Size = New System.Drawing.Size(166, 0)
        Me.abaMETALURGIA.TabIndex = 2
        Me.abaMETALURGIA.Text = "Dados Metalúrgicos"
        '
        'painelMETALURGIA
        '
        Me.painelMETALURGIA.Controls.Add(Me.gradeMETALURGIA)
        Me.painelMETALURGIA.Controls.Add(Me.botoesMETALURGIA)
        Me.painelMETALURGIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.painelMETALURGIA.Location = New System.Drawing.Point(0, 0)
        Me.painelMETALURGIA.Name = "painelMETALURGIA"
        Me.painelMETALURGIA.Size = New System.Drawing.Size(166, 0)
        Me.painelMETALURGIA.TabIndex = 0
        '
        'gradeMETALURGIA
        '
        Me.gradeMETALURGIA.AllowUserToAddRows = False
        Me.gradeMETALURGIA.AllowUserToDeleteRows = False
        Me.gradeMETALURGIA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gradeMETALURGIA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gradeMETALURGIA.BackgroundColor = System.Drawing.Color.White
        Me.gradeMETALURGIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gradeMETALURGIA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gradeMETALURGIA.Location = New System.Drawing.Point(0, 35)
        Me.gradeMETALURGIA.Name = "gradeMETALURGIA"
        Me.gradeMETALURGIA.RowHeadersVisible = False
        Me.gradeMETALURGIA.Size = New System.Drawing.Size(166, 0)
        Me.gradeMETALURGIA.TabIndex = 0
        '
        'botoesMETALURGIA
        '
        Me.botoesMETALURGIA.Controls.Add(Me.btnMETALURGIAAdicionar)
        Me.botoesMETALURGIA.Controls.Add(Me.btnMETALURGIARemover)
        Me.botoesMETALURGIA.Controls.Add(Me.btnMETALURGIADetalhes)
        Me.botoesMETALURGIA.Dock = System.Windows.Forms.DockStyle.Top
        Me.botoesMETALURGIA.Location = New System.Drawing.Point(0, 0)
        Me.botoesMETALURGIA.Name = "botoesMETALURGIA"
        Me.botoesMETALURGIA.Size = New System.Drawing.Size(166, 35)
        Me.botoesMETALURGIA.TabIndex = 1
        '
        'btnMETALURGIAAdicionar
        '
        Me.btnMETALURGIAAdicionar.AutoSize = True
        Me.btnMETALURGIAAdicionar.Location = New System.Drawing.Point(3, 3)
        Me.btnMETALURGIAAdicionar.Name = "btnMETALURGIAAdicionar"
        Me.btnMETALURGIAAdicionar.Size = New System.Drawing.Size(117, 28)
        Me.btnMETALURGIAAdicionar.TabIndex = 0
        Me.btnMETALURGIAAdicionar.Text = "Adicionar requisito"
        '
        'btnMETALURGIARemover
        '
        Me.btnMETALURGIARemover.AutoSize = True
        Me.btnMETALURGIARemover.Location = New System.Drawing.Point(3, 37)
        Me.btnMETALURGIARemover.Name = "btnMETALURGIARemover"
        Me.btnMETALURGIARemover.Size = New System.Drawing.Size(93, 28)
        Me.btnMETALURGIARemover.TabIndex = 1
        Me.btnMETALURGIARemover.Text = "Remover linha"
        '
        'btnMETALURGIADetalhes
        '
        Me.btnMETALURGIADetalhes.AutoSize = True
        Me.btnMETALURGIADetalhes.Location = New System.Drawing.Point(3, 71)
        Me.btnMETALURGIADetalhes.Name = "btnMETALURGIADetalhes"
        Me.btnMETALURGIADetalhes.Size = New System.Drawing.Size(167, 28)
        Me.btnMETALURGIADetalhes.TabIndex = 2
        Me.btnMETALURGIADetalhes.Text = "Detalhes / condições / notas"
        '
        'abaOUTROS
        '
        Me.abaOUTROS.Controls.Add(Me.painelOUTROS)
        Me.abaOUTROS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abaOUTROS.Location = New System.Drawing.Point(4, 24)
        Me.abaOUTROS.Name = "abaOUTROS"
        Me.abaOUTROS.Size = New System.Drawing.Size(166, 0)
        Me.abaOUTROS.TabIndex = 3
        Me.abaOUTROS.Text = "Outros requisitos"
        '
        'painelOUTROS
        '
        Me.painelOUTROS.Controls.Add(Me.gradeOUTROS)
        Me.painelOUTROS.Controls.Add(Me.botoesOUTROS)
        Me.painelOUTROS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.painelOUTROS.Location = New System.Drawing.Point(0, 0)
        Me.painelOUTROS.Name = "painelOUTROS"
        Me.painelOUTROS.Size = New System.Drawing.Size(166, 0)
        Me.painelOUTROS.TabIndex = 0
        '
        'gradeOUTROS
        '
        Me.gradeOUTROS.AllowUserToAddRows = False
        Me.gradeOUTROS.AllowUserToDeleteRows = False
        Me.gradeOUTROS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gradeOUTROS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gradeOUTROS.BackgroundColor = System.Drawing.Color.White
        Me.gradeOUTROS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gradeOUTROS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gradeOUTROS.Location = New System.Drawing.Point(0, 35)
        Me.gradeOUTROS.Name = "gradeOUTROS"
        Me.gradeOUTROS.RowHeadersVisible = False
        Me.gradeOUTROS.Size = New System.Drawing.Size(166, 0)
        Me.gradeOUTROS.TabIndex = 0
        '
        'botoesOUTROS
        '
        Me.botoesOUTROS.Controls.Add(Me.btnOUTROSAdicionar)
        Me.botoesOUTROS.Controls.Add(Me.btnOUTROSRemover)
        Me.botoesOUTROS.Controls.Add(Me.btnOUTROSDetalhes)
        Me.botoesOUTROS.Dock = System.Windows.Forms.DockStyle.Top
        Me.botoesOUTROS.Location = New System.Drawing.Point(0, 0)
        Me.botoesOUTROS.Name = "botoesOUTROS"
        Me.botoesOUTROS.Size = New System.Drawing.Size(166, 35)
        Me.botoesOUTROS.TabIndex = 1
        '
        'btnOUTROSAdicionar
        '
        Me.btnOUTROSAdicionar.AutoSize = True
        Me.btnOUTROSAdicionar.Location = New System.Drawing.Point(3, 3)
        Me.btnOUTROSAdicionar.Name = "btnOUTROSAdicionar"
        Me.btnOUTROSAdicionar.Size = New System.Drawing.Size(117, 28)
        Me.btnOUTROSAdicionar.TabIndex = 0
        Me.btnOUTROSAdicionar.Text = "Adicionar requisito"
        '
        'btnOUTROSRemover
        '
        Me.btnOUTROSRemover.AutoSize = True
        Me.btnOUTROSRemover.Location = New System.Drawing.Point(3, 37)
        Me.btnOUTROSRemover.Name = "btnOUTROSRemover"
        Me.btnOUTROSRemover.Size = New System.Drawing.Size(93, 28)
        Me.btnOUTROSRemover.TabIndex = 1
        Me.btnOUTROSRemover.Text = "Remover linha"
        '
        'btnOUTROSDetalhes
        '
        Me.btnOUTROSDetalhes.AutoSize = True
        Me.btnOUTROSDetalhes.Location = New System.Drawing.Point(3, 71)
        Me.btnOUTROSDetalhes.Name = "btnOUTROSDetalhes"
        Me.btnOUTROSDetalhes.Size = New System.Drawing.Size(167, 28)
        Me.btnOUTROSDetalhes.TabIndex = 2
        Me.btnOUTROSDetalhes.Text = "Detalhes / condições / notas"
        '
        '_resumo
        '
        Me._resumo.Dock = System.Windows.Forms.DockStyle.Fill
        Me._resumo.ForeColor = System.Drawing.Color.DarkOrange
        Me._resumo.Location = New System.Drawing.Point(13, 763)
        Me._resumo.Name = "_resumo"
        Me._resumo.Size = New System.Drawing.Size(1198, 48)
        Me._resumo.TabIndex = 5
        '
        'frmNormasConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1224, 821)
        Me.Controls.Add(Me.layoutPrincipal)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(1050, 740)
        Me.Name = "frmNormasConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sandinox — Configuração de normas"
        Me.layoutPrincipal.ResumeLayout(False)
        Me.barraAcoes.ResumeLayout(False)
        Me.barraAcoes.PerformLayout()
        Me.layoutSeletores.ResumeLayout(False)
        Me.grpNorma.ResumeLayout(False)
        Me.layoutNorma.ResumeLayout(False)
        Me.layoutNorma.PerformLayout()
        Me.grpPerfil.ResumeLayout(False)
        Me.layoutPerfil.ResumeLayout(False)
        Me.layoutPerfil.PerformLayout()
        Me.abasRequisitos.ResumeLayout(False)
        Me.abaQUIMICA.ResumeLayout(False)
        Me.painelQUIMICA.ResumeLayout(False)
        CType(Me.gradeQUIMICA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.botoesQUIMICA.ResumeLayout(False)
        Me.botoesQUIMICA.PerformLayout()
        Me.abaMECANICA.ResumeLayout(False)
        Me.painelMECANICA.ResumeLayout(False)
        CType(Me.gradeMECANICA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.botoesMECANICA.ResumeLayout(False)
        Me.botoesMECANICA.PerformLayout()
        Me.abaMETALURGIA.ResumeLayout(False)
        Me.painelMETALURGIA.ResumeLayout(False)
        CType(Me.gradeMETALURGIA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.botoesMETALURGIA.ResumeLayout(False)
        Me.botoesMETALURGIA.PerformLayout()
        Me.abaOUTROS.ResumeLayout(False)
        Me.painelOUTROS.ResumeLayout(False)
        CType(Me.gradeOUTROS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.botoesOUTROS.ResumeLayout(False)
        Me.botoesOUTROS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents layoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents barraAcoes As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNovaNorma As System.Windows.Forms.Button
    Friend WithEvents btnNovaEdicao As System.Windows.Forms.Button
    Friend WithEvents btnSalvarNorma As System.Windows.Forms.Button
    Friend WithEvents btnNovoPerfil As System.Windows.Forms.Button
    Friend WithEvents btnNovaRevisao As System.Windows.Forms.Button
    Friend WithEvents btnSalvarPerfil As System.Windows.Forms.Button
    Friend WithEvents btnNovaPropriedade As System.Windows.Forms.Button
    Friend WithEvents btnFechar As System.Windows.Forms.Button
    Friend WithEvents layoutSeletores As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSeletor0 As System.Windows.Forms.Label
    Friend WithEvents _normas As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeletor1 As System.Windows.Forms.Label
    Friend WithEvents _perfis As System.Windows.Forms.ComboBox
    Friend WithEvents grpNorma As System.Windows.Forms.GroupBox
    Friend WithEvents layoutNorma As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNorma0 As System.Windows.Forms.Label
    Friend WithEvents txtNorma_entidade As System.Windows.Forms.TextBox
    Friend WithEvents lblNorma1 As System.Windows.Forms.Label
    Friend WithEvents txtNorma_codigo As System.Windows.Forms.TextBox
    Friend WithEvents lblNorma2 As System.Windows.Forms.Label
    Friend WithEvents txtNorma_edicao As System.Windows.Forms.TextBox
    Friend WithEvents lblNorma3 As System.Windows.Forms.Label
    Friend WithEvents txtNorma_descricao As System.Windows.Forms.TextBox
    Friend WithEvents lblNorma4 As System.Windows.Forms.Label
    Friend WithEvents txtNorma_referencia_documento As System.Windows.Forms.TextBox
    Friend WithEvents grpPerfil As System.Windows.Forms.GroupBox
    Friend WithEvents layoutPerfil As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblPerfil0 As System.Windows.Forms.Label
    Friend WithEvents txtPerfil_codigo As System.Windows.Forms.TextBox
    Friend WithEvents lblPerfil1 As System.Windows.Forms.Label
    Friend WithEvents txtPerfil_descricao As System.Windows.Forms.TextBox
    Friend WithEvents lblPerfil2 As System.Windows.Forms.Label
    Friend WithEvents txtPerfil_material_grau_tipo As System.Windows.Forms.TextBox
    Friend WithEvents lblPerfil3 As System.Windows.Forms.Label
    Friend WithEvents txtPerfil_designacao_uns As System.Windows.Forms.TextBox
    Friend WithEvents lblPerfil4 As System.Windows.Forms.Label
    Friend WithEvents cboPerfil_forma_produto As System.Windows.Forms.ComboBox
    Friend WithEvents lblPerfil5 As System.Windows.Forms.Label
    Friend WithEvents cboPerfil_condicao_fornecimento As System.Windows.Forms.ComboBox
    Friend WithEvents lblPerfil6 As System.Windows.Forms.Label
    Friend WithEvents cboPerfil_sistema_unidades As System.Windows.Forms.ComboBox
    Friend WithEvents lblPerfil7 As System.Windows.Forms.Label
    Friend WithEvents cboPerfil_status As System.Windows.Forms.ComboBox
    Friend WithEvents btnDimensoes As System.Windows.Forms.Button
    Friend WithEvents abasRequisitos As System.Windows.Forms.TabControl
    Friend WithEvents abaQUIMICA As System.Windows.Forms.TabPage
    Friend WithEvents painelQUIMICA As System.Windows.Forms.Panel
    Friend WithEvents gradeQUIMICA As System.Windows.Forms.DataGridView
    Friend WithEvents botoesQUIMICA As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnQUIMICAAdicionar As System.Windows.Forms.Button
    Friend WithEvents btnQUIMICARemover As System.Windows.Forms.Button
    Friend WithEvents btnQUIMICADetalhes As System.Windows.Forms.Button
    Friend WithEvents colQUIMICA_propriedade As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colQUIMICA_regra As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colQUIMICA_ui_minimo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQUIMICA_ui_maximo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQUIMICA_minimo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colQUIMICA_maximo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colQUIMICA_unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQUIMICA_obrigatorio_informar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colQUIMICA_referencia_normativa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents abaMECANICA As System.Windows.Forms.TabPage
    Friend WithEvents painelMECANICA As System.Windows.Forms.Panel
    Friend WithEvents gradeMECANICA As System.Windows.Forms.DataGridView
    Friend WithEvents botoesMECANICA As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnMECANICAAdicionar As System.Windows.Forms.Button
    Friend WithEvents btnMECANICARemover As System.Windows.Forms.Button
    Friend WithEvents btnMECANICADetalhes As System.Windows.Forms.Button
    Friend WithEvents colMECANICA_propriedade As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMECANICA_regra As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMECANICA_ui_minimo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMECANICA_ui_maximo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMECANICA_minimo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMECANICA_maximo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMECANICA_unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMECANICA_obrigatorio_informar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMECANICA_referencia_normativa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents abaMETALURGIA As System.Windows.Forms.TabPage
    Friend WithEvents painelMETALURGIA As System.Windows.Forms.Panel
    Friend WithEvents gradeMETALURGIA As System.Windows.Forms.DataGridView
    Friend WithEvents botoesMETALURGIA As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnMETALURGIAAdicionar As System.Windows.Forms.Button
    Friend WithEvents btnMETALURGIARemover As System.Windows.Forms.Button
    Friend WithEvents btnMETALURGIADetalhes As System.Windows.Forms.Button
    Friend WithEvents colMETALURGIA_propriedade As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMETALURGIA_regra As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMETALURGIA_ui_minimo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMETALURGIA_ui_maximo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMETALURGIA_minimo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMETALURGIA_maximo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMETALURGIA_unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMETALURGIA_obrigatorio_informar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMETALURGIA_referencia_normativa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents abaOUTROS As System.Windows.Forms.TabPage
    Friend WithEvents painelOUTROS As System.Windows.Forms.Panel
    Friend WithEvents gradeOUTROS As System.Windows.Forms.DataGridView
    Friend WithEvents botoesOUTROS As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOUTROSAdicionar As System.Windows.Forms.Button
    Friend WithEvents btnOUTROSRemover As System.Windows.Forms.Button
    Friend WithEvents btnOUTROSDetalhes As System.Windows.Forms.Button
    Friend WithEvents colOUTROS_propriedade As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOUTROS_regra As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOUTROS_ui_minimo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOUTROS_ui_maximo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOUTROS_minimo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOUTROS_maximo_inclusivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOUTROS_unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOUTROS_obrigatorio_informar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOUTROS_referencia_normativa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _resumo As System.Windows.Forms.Label
End Class
