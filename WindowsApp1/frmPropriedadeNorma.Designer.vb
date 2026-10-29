<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropriedadeNorma
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
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.campo_codigo = New System.Windows.Forms.TextBox()
        Me.lbl_descricao = New System.Windows.Forms.Label()
        Me.campo_descricao = New System.Windows.Forms.TextBox()
        Me.lbl_grupo = New System.Windows.Forms.Label()
        Me.campo_grupo = New System.Windows.Forms.ComboBox()
        Me.lbl_unidade_sugerida = New System.Windows.Forms.Label()
        Me.campo_unidade_sugerida = New System.Windows.Forms.TextBox()
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
        Me.layoutCampos.Controls.Add(Me.lbl_codigo, 0, 0)
        Me.layoutCampos.Controls.Add(Me.campo_codigo, 1, 0)
        Me.layoutCampos.Controls.Add(Me.lbl_descricao, 0, 1)
        Me.layoutCampos.Controls.Add(Me.campo_descricao, 1, 1)
        Me.layoutCampos.Controls.Add(Me.lbl_grupo, 0, 2)
        Me.layoutCampos.Controls.Add(Me.campo_grupo, 1, 2)
        Me.layoutCampos.Controls.Add(Me.lbl_unidade_sugerida, 0, 3)
        Me.layoutCampos.Controls.Add(Me.campo_unidade_sugerida, 1, 3)
        Me.layoutCampos.Controls.Add(Me.btnAplicar, 1, 4)
        Me.layoutCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutCampos.Location = New System.Drawing.Point(0, 0)
        Me.layoutCampos.Name = "layoutCampos"
        Me.layoutCampos.Padding = New System.Windows.Forms.Padding(12)
        Me.layoutCampos.RowCount = 5
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.layoutCampos.Size = New System.Drawing.Size(720, 250)
        Me.layoutCampos.TabIndex = 0
        '
        'lbl_codigo
        '
        Me.lbl_codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_codigo.Location = New System.Drawing.Point(15, 12)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(342, 38)
        Me.lbl_codigo.TabIndex = 0
        Me.lbl_codigo.Text = "Codigo"
        '
        'campo_codigo
        '
        Me.campo_codigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_codigo.Location = New System.Drawing.Point(363, 15)
        Me.campo_codigo.Name = "campo_codigo"
        Me.campo_codigo.Size = New System.Drawing.Size(342, 23)
        Me.campo_codigo.TabIndex = 1
        '
        'lbl_descricao
        '
        Me.lbl_descricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_descricao.Location = New System.Drawing.Point(15, 50)
        Me.lbl_descricao.Name = "lbl_descricao"
        Me.lbl_descricao.Size = New System.Drawing.Size(342, 38)
        Me.lbl_descricao.TabIndex = 2
        Me.lbl_descricao.Text = "Descricao"
        '
        'campo_descricao
        '
        Me.campo_descricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_descricao.Location = New System.Drawing.Point(363, 53)
        Me.campo_descricao.Name = "campo_descricao"
        Me.campo_descricao.Size = New System.Drawing.Size(342, 23)
        Me.campo_descricao.TabIndex = 3
        '
        'lbl_grupo
        '
        Me.lbl_grupo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_grupo.Location = New System.Drawing.Point(15, 88)
        Me.lbl_grupo.Name = "lbl_grupo"
        Me.lbl_grupo.Size = New System.Drawing.Size(342, 38)
        Me.lbl_grupo.TabIndex = 4
        Me.lbl_grupo.Text = "Grupo"
        '
        'campo_grupo
        '
        Me.campo_grupo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_grupo.Items.AddRange(New Object() {"QUIMICA", "MECANICA", "METALURGIA", "TERMICA", "DOCUMENTAL"})
        Me.campo_grupo.Location = New System.Drawing.Point(363, 91)
        Me.campo_grupo.Name = "campo_grupo"
        Me.campo_grupo.Size = New System.Drawing.Size(342, 23)
        Me.campo_grupo.TabIndex = 5
        '
        'lbl_unidade_sugerida
        '
        Me.lbl_unidade_sugerida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_unidade_sugerida.Location = New System.Drawing.Point(15, 126)
        Me.lbl_unidade_sugerida.Name = "lbl_unidade_sugerida"
        Me.lbl_unidade_sugerida.Size = New System.Drawing.Size(342, 38)
        Me.lbl_unidade_sugerida.TabIndex = 6
        Me.lbl_unidade_sugerida.Text = "Unidade sugerida"
        '
        'campo_unidade_sugerida
        '
        Me.campo_unidade_sugerida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_unidade_sugerida.Location = New System.Drawing.Point(363, 129)
        Me.campo_unidade_sugerida.Name = "campo_unidade_sugerida"
        Me.campo_unidade_sugerida.Size = New System.Drawing.Size(342, 23)
        Me.campo_unidade_sugerida.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAplicar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAplicar.Location = New System.Drawing.Point(363, 167)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(342, 68)
        Me.btnAplicar.TabIndex = 4
        Me.btnAplicar.Text = "Aplicar"
        '
        'frmPropriedadeNorma
        '
        Me.AcceptButton = Me.btnAplicar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 250)
        Me.Controls.Add(Me.layoutCampos)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "frmPropriedadeNorma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nova propriedade / elemento"
        Me.layoutCampos.ResumeLayout(False)
        Me.layoutCampos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutCampos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents campo_codigo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_descricao As System.Windows.Forms.Label
    Friend WithEvents campo_descricao As System.Windows.Forms.TextBox
    Friend WithEvents lbl_grupo As System.Windows.Forms.Label
    Friend WithEvents campo_grupo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_unidade_sugerida As System.Windows.Forms.Label
    Friend WithEvents campo_unidade_sugerida As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
End Class
