<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalhesRequisito
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
        Me.layoutCampos = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_tipo_analise = New System.Windows.Forms.Label()
        Me.campo_tipo_analise = New System.Windows.Forms.ComboBox()
        Me.lbl_etapa_amostra = New System.Windows.Forms.Label()
        Me.campo_etapa_amostra = New System.Windows.Forms.ComboBox()
        Me.lbl_direcao_ensaio = New System.Windows.Forms.Label()
        Me.campo_direcao_ensaio = New System.Windows.Forms.ComboBox()
        Me.lbl_condicao_ensaio = New System.Windows.Forms.Label()
        Me.campo_condicao_ensaio = New System.Windows.Forms.TextBox()
        Me.lbl_base_alongamento = New System.Windows.Forms.Label()
        Me.campo_base_alongamento = New System.Windows.Forms.TextBox()
        Me.lbl_modo_arredondamento = New System.Windows.Forms.Label()
        Me.campo_modo_arredondamento = New System.Windows.Forms.ComboBox()
        Me.lbl_declaracao_esperada = New System.Windows.Forms.Label()
        Me.campo_declaracao_esperada = New System.Windows.Forms.TextBox()
        Me.lbl_formula_codigo = New System.Windows.Forms.Label()
        Me.campo_formula_codigo = New System.Windows.Forms.TextBox()
        Me.lbl_observacoes = New System.Windows.Forms.Label()
        Me.campo_observacoes = New System.Windows.Forms.TextBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.layoutCampos.SuspendLayout()
        Me.SuspendLayout()
        '
        'layoutCampos
        '
        Me.layoutCampos.AutoScroll = True
        Me.layoutCampos.ColumnCount = 2
        Me.layoutCampos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutCampos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutCampos.Controls.Add(Me.lbl_tipo_analise, 0, 0)
        Me.layoutCampos.Controls.Add(Me.campo_tipo_analise, 1, 0)
        Me.layoutCampos.Controls.Add(Me.lbl_etapa_amostra, 0, 1)
        Me.layoutCampos.Controls.Add(Me.campo_etapa_amostra, 1, 1)
        Me.layoutCampos.Controls.Add(Me.lbl_direcao_ensaio, 0, 2)
        Me.layoutCampos.Controls.Add(Me.campo_direcao_ensaio, 1, 2)
        Me.layoutCampos.Controls.Add(Me.lbl_condicao_ensaio, 0, 3)
        Me.layoutCampos.Controls.Add(Me.campo_condicao_ensaio, 1, 3)
        Me.layoutCampos.Controls.Add(Me.lbl_base_alongamento, 0, 4)
        Me.layoutCampos.Controls.Add(Me.campo_base_alongamento, 1, 4)
        Me.layoutCampos.Controls.Add(Me.lbl_modo_arredondamento, 0, 5)
        Me.layoutCampos.Controls.Add(Me.campo_modo_arredondamento, 1, 5)
        Me.layoutCampos.Controls.Add(Me.lbl_declaracao_esperada, 0, 6)
        Me.layoutCampos.Controls.Add(Me.campo_declaracao_esperada, 1, 6)
        Me.layoutCampos.Controls.Add(Me.lbl_formula_codigo, 0, 7)
        Me.layoutCampos.Controls.Add(Me.campo_formula_codigo, 1, 7)
        Me.layoutCampos.Controls.Add(Me.lbl_observacoes, 0, 8)
        Me.layoutCampos.Controls.Add(Me.campo_observacoes, 1, 8)
        Me.layoutCampos.Controls.Add(Me.btnAplicar, 1, 9)
        Me.layoutCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutCampos.Location = New System.Drawing.Point(0, 0)
        Me.layoutCampos.Name = "layoutCampos"
        Me.layoutCampos.Padding = New System.Windows.Forms.Padding(12)
        Me.layoutCampos.RowCount = 10
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.layoutCampos.Size = New System.Drawing.Size(720, 479)
        Me.layoutCampos.TabIndex = 0
        '
        'lbl_tipo_analise
        '
        Me.lbl_tipo_analise.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_tipo_analise.Location = New System.Drawing.Point(15, 12)
        Me.lbl_tipo_analise.Name = "lbl_tipo_analise"
        Me.lbl_tipo_analise.Size = New System.Drawing.Size(342, 38)
        Me.lbl_tipo_analise.TabIndex = 0
        Me.lbl_tipo_analise.Text = "Tipo analise"
        '
        'campo_tipo_analise
        '
        Me.campo_tipo_analise.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_tipo_analise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_tipo_analise.Items.AddRange(New Object() {"CORRIDA_LINGOTE", "PRODUTO", "QUALQUER", "NAO_APLICAVEL"})
        Me.campo_tipo_analise.Location = New System.Drawing.Point(363, 15)
        Me.campo_tipo_analise.Name = "campo_tipo_analise"
        Me.campo_tipo_analise.Size = New System.Drawing.Size(342, 23)
        Me.campo_tipo_analise.TabIndex = 1
        '
        'lbl_etapa_amostra
        '
        Me.lbl_etapa_amostra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_etapa_amostra.Location = New System.Drawing.Point(15, 50)
        Me.lbl_etapa_amostra.Name = "lbl_etapa_amostra"
        Me.lbl_etapa_amostra.Size = New System.Drawing.Size(342, 38)
        Me.lbl_etapa_amostra.TabIndex = 2
        Me.lbl_etapa_amostra.Text = "Etapa amostra"
        '
        'campo_etapa_amostra
        '
        Me.campo_etapa_amostra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_etapa_amostra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_etapa_amostra.Items.AddRange(New Object() {"LINGOTE", "INTERMEDIARIO", "PRODUTO_FINAL", "QUALQUER"})
        Me.campo_etapa_amostra.Location = New System.Drawing.Point(363, 53)
        Me.campo_etapa_amostra.Name = "campo_etapa_amostra"
        Me.campo_etapa_amostra.Size = New System.Drawing.Size(342, 23)
        Me.campo_etapa_amostra.TabIndex = 3
        '
        'lbl_direcao_ensaio
        '
        Me.lbl_direcao_ensaio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_direcao_ensaio.Location = New System.Drawing.Point(15, 88)
        Me.lbl_direcao_ensaio.Name = "lbl_direcao_ensaio"
        Me.lbl_direcao_ensaio.Size = New System.Drawing.Size(342, 38)
        Me.lbl_direcao_ensaio.TabIndex = 4
        Me.lbl_direcao_ensaio.Text = "Direcao ensaio"
        '
        'campo_direcao_ensaio
        '
        Me.campo_direcao_ensaio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_direcao_ensaio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_direcao_ensaio.Items.AddRange(New Object() {"L", "LT", "ST", "T", "QUALQUER", "NAO_APLICAVEL"})
        Me.campo_direcao_ensaio.Location = New System.Drawing.Point(363, 91)
        Me.campo_direcao_ensaio.Name = "campo_direcao_ensaio"
        Me.campo_direcao_ensaio.Size = New System.Drawing.Size(342, 23)
        Me.campo_direcao_ensaio.TabIndex = 5
        '
        'lbl_condicao_ensaio
        '
        Me.lbl_condicao_ensaio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_condicao_ensaio.Location = New System.Drawing.Point(15, 126)
        Me.lbl_condicao_ensaio.Name = "lbl_condicao_ensaio"
        Me.lbl_condicao_ensaio.Size = New System.Drawing.Size(342, 38)
        Me.lbl_condicao_ensaio.TabIndex = 6
        Me.lbl_condicao_ensaio.Text = "Condicao ensaio"
        '
        'campo_condicao_ensaio
        '
        Me.campo_condicao_ensaio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_condicao_ensaio.Location = New System.Drawing.Point(363, 129)
        Me.campo_condicao_ensaio.Name = "campo_condicao_ensaio"
        Me.campo_condicao_ensaio.Size = New System.Drawing.Size(342, 23)
        Me.campo_condicao_ensaio.TabIndex = 7
        '
        'lbl_base_alongamento
        '
        Me.lbl_base_alongamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_base_alongamento.Location = New System.Drawing.Point(15, 164)
        Me.lbl_base_alongamento.Name = "lbl_base_alongamento"
        Me.lbl_base_alongamento.Size = New System.Drawing.Size(342, 38)
        Me.lbl_base_alongamento.TabIndex = 8
        Me.lbl_base_alongamento.Text = "Base alongamento"
        '
        'campo_base_alongamento
        '
        Me.campo_base_alongamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_base_alongamento.Location = New System.Drawing.Point(363, 167)
        Me.campo_base_alongamento.Name = "campo_base_alongamento"
        Me.campo_base_alongamento.Size = New System.Drawing.Size(342, 23)
        Me.campo_base_alongamento.TabIndex = 9
        '
        'lbl_modo_arredondamento
        '
        Me.lbl_modo_arredondamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_modo_arredondamento.Location = New System.Drawing.Point(15, 202)
        Me.lbl_modo_arredondamento.Name = "lbl_modo_arredondamento"
        Me.lbl_modo_arredondamento.Size = New System.Drawing.Size(342, 38)
        Me.lbl_modo_arredondamento.TabIndex = 10
        Me.lbl_modo_arredondamento.Text = "Modo arredondamento"
        '
        'campo_modo_arredondamento
        '
        Me.campo_modo_arredondamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_modo_arredondamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_modo_arredondamento.Items.AddRange(New Object() {"PENDENTE", "E29", "SEM_ARREDONDAMENTO"})
        Me.campo_modo_arredondamento.Location = New System.Drawing.Point(363, 205)
        Me.campo_modo_arredondamento.Name = "campo_modo_arredondamento"
        Me.campo_modo_arredondamento.Size = New System.Drawing.Size(342, 23)
        Me.campo_modo_arredondamento.TabIndex = 11
        '
        'lbl_declaracao_esperada
        '
        Me.lbl_declaracao_esperada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_declaracao_esperada.Location = New System.Drawing.Point(15, 240)
        Me.lbl_declaracao_esperada.Name = "lbl_declaracao_esperada"
        Me.lbl_declaracao_esperada.Size = New System.Drawing.Size(342, 38)
        Me.lbl_declaracao_esperada.TabIndex = 12
        Me.lbl_declaracao_esperada.Text = "Declaracao esperada"
        '
        'campo_declaracao_esperada
        '
        Me.campo_declaracao_esperada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_declaracao_esperada.Location = New System.Drawing.Point(363, 243)
        Me.campo_declaracao_esperada.Name = "campo_declaracao_esperada"
        Me.campo_declaracao_esperada.Size = New System.Drawing.Size(342, 23)
        Me.campo_declaracao_esperada.TabIndex = 13
        '
        'lbl_formula_codigo
        '
        Me.lbl_formula_codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_formula_codigo.Location = New System.Drawing.Point(15, 278)
        Me.lbl_formula_codigo.Name = "lbl_formula_codigo"
        Me.lbl_formula_codigo.Size = New System.Drawing.Size(342, 38)
        Me.lbl_formula_codigo.TabIndex = 14
        Me.lbl_formula_codigo.Text = "Formula codigo"
        '
        'campo_formula_codigo
        '
        Me.campo_formula_codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_formula_codigo.Location = New System.Drawing.Point(363, 281)
        Me.campo_formula_codigo.Name = "campo_formula_codigo"
        Me.campo_formula_codigo.Size = New System.Drawing.Size(342, 23)
        Me.campo_formula_codigo.TabIndex = 15
        '
        'lbl_observacoes
        '
        Me.lbl_observacoes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_observacoes.Location = New System.Drawing.Point(15, 316)
        Me.lbl_observacoes.Name = "lbl_observacoes"
        Me.lbl_observacoes.Size = New System.Drawing.Size(342, 100)
        Me.lbl_observacoes.TabIndex = 16
        Me.lbl_observacoes.Text = "Observacoes"
        '
        'campo_observacoes
        '
        Me.campo_observacoes.AcceptsReturn = True
        Me.campo_observacoes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_observacoes.Location = New System.Drawing.Point(363, 319)
        Me.campo_observacoes.Multiline = True
        Me.campo_observacoes.Name = "campo_observacoes"
        Me.campo_observacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.campo_observacoes.Size = New System.Drawing.Size(342, 94)
        Me.campo_observacoes.TabIndex = 17
        '
        'btnAplicar
        '
        Me.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAplicar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAplicar.Location = New System.Drawing.Point(363, 419)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(342, 45)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.Text = "Aplicar"
        '
        'frmDetalhesRequisito
        '
        Me.AcceptButton = Me.btnAplicar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 479)
        Me.Controls.Add(Me.layoutCampos)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "frmDetalhesRequisito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalhes do requisito"
        Me.layoutCampos.ResumeLayout(False)
        Me.layoutCampos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutCampos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_tipo_analise As System.Windows.Forms.Label
    Friend WithEvents campo_tipo_analise As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_etapa_amostra As System.Windows.Forms.Label
    Friend WithEvents campo_etapa_amostra As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_direcao_ensaio As System.Windows.Forms.Label
    Friend WithEvents campo_direcao_ensaio As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_condicao_ensaio As System.Windows.Forms.Label
    Friend WithEvents campo_condicao_ensaio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_base_alongamento As System.Windows.Forms.Label
    Friend WithEvents campo_base_alongamento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_modo_arredondamento As System.Windows.Forms.Label
    Friend WithEvents campo_modo_arredondamento As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_declaracao_esperada As System.Windows.Forms.Label
    Friend WithEvents campo_declaracao_esperada As System.Windows.Forms.TextBox
    Friend WithEvents lbl_formula_codigo As System.Windows.Forms.Label
    Friend WithEvents campo_formula_codigo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_observacoes As System.Windows.Forms.Label
    Friend WithEvents campo_observacoes As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
End Class
