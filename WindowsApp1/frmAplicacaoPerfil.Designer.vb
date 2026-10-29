<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAplicacaoPerfil
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
        Me.lbl_dimensao_referencia = New System.Windows.Forms.Label()
        Me.campo_dimensao_referencia = New System.Windows.Forms.ComboBox()
        Me.lbl_dimensao_min = New System.Windows.Forms.Label()
        Me.campo_dimensao_min = New System.Windows.Forms.TextBox()
        Me.lbl_dimensao_max = New System.Windows.Forms.Label()
        Me.campo_dimensao_max = New System.Windows.Forms.TextBox()
        Me.lbl_dimensao_min_inclusiva = New System.Windows.Forms.Label()
        Me.campo_dimensao_min_inclusiva = New System.Windows.Forms.ComboBox()
        Me.lbl_dimensao_max_inclusiva = New System.Windows.Forms.Label()
        Me.campo_dimensao_max_inclusiva = New System.Windows.Forms.ComboBox()
        Me.lbl_unidade_dimensao = New System.Windows.Forms.Label()
        Me.campo_unidade_dimensao = New System.Windows.Forms.TextBox()
        Me.lbl_condicoes_adicionais = New System.Windows.Forms.Label()
        Me.campo_condicoes_adicionais = New System.Windows.Forms.TextBox()
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
        Me.layoutCampos.Controls.Add(Me.lbl_dimensao_referencia, 0, 0)
        Me.layoutCampos.Controls.Add(Me.campo_dimensao_referencia, 1, 0)
        Me.layoutCampos.Controls.Add(Me.lbl_dimensao_min, 0, 1)
        Me.layoutCampos.Controls.Add(Me.campo_dimensao_min, 1, 1)
        Me.layoutCampos.Controls.Add(Me.lbl_dimensao_max, 0, 2)
        Me.layoutCampos.Controls.Add(Me.campo_dimensao_max, 1, 2)
        Me.layoutCampos.Controls.Add(Me.lbl_dimensao_min_inclusiva, 0, 3)
        Me.layoutCampos.Controls.Add(Me.campo_dimensao_min_inclusiva, 1, 3)
        Me.layoutCampos.Controls.Add(Me.lbl_dimensao_max_inclusiva, 0, 4)
        Me.layoutCampos.Controls.Add(Me.campo_dimensao_max_inclusiva, 1, 4)
        Me.layoutCampos.Controls.Add(Me.lbl_unidade_dimensao, 0, 5)
        Me.layoutCampos.Controls.Add(Me.campo_unidade_dimensao, 1, 5)
        Me.layoutCampos.Controls.Add(Me.lbl_condicoes_adicionais, 0, 6)
        Me.layoutCampos.Controls.Add(Me.campo_condicoes_adicionais, 1, 6)
        Me.layoutCampos.Controls.Add(Me.btnAplicar, 1, 7)
        Me.layoutCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutCampos.Location = New System.Drawing.Point(0, 0)
        Me.layoutCampos.Name = "layoutCampos"
        Me.layoutCampos.Padding = New System.Windows.Forms.Padding(12)
        Me.layoutCampos.RowCount = 8
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.layoutCampos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.layoutCampos.Size = New System.Drawing.Size(720, 403)
        Me.layoutCampos.TabIndex = 0
        '
        'lbl_dimensao_referencia
        '
        Me.lbl_dimensao_referencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_dimensao_referencia.Location = New System.Drawing.Point(15, 12)
        Me.lbl_dimensao_referencia.Name = "lbl_dimensao_referencia"
        Me.lbl_dimensao_referencia.Size = New System.Drawing.Size(342, 38)
        Me.lbl_dimensao_referencia.TabIndex = 0
        Me.lbl_dimensao_referencia.Text = "Dimensao referencia"
        '
        'campo_dimensao_referencia
        '
        Me.campo_dimensao_referencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_dimensao_referencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_dimensao_referencia.Items.AddRange(New Object() {"DIAMETRO", "ESPESSURA", "DISTANCIA_FACES", "NAO_DEFINIDA"})
        Me.campo_dimensao_referencia.Location = New System.Drawing.Point(363, 15)
        Me.campo_dimensao_referencia.Name = "campo_dimensao_referencia"
        Me.campo_dimensao_referencia.Size = New System.Drawing.Size(342, 23)
        Me.campo_dimensao_referencia.TabIndex = 1
        '
        'lbl_dimensao_min
        '
        Me.lbl_dimensao_min.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_dimensao_min.Location = New System.Drawing.Point(15, 50)
        Me.lbl_dimensao_min.Name = "lbl_dimensao_min"
        Me.lbl_dimensao_min.Size = New System.Drawing.Size(342, 38)
        Me.lbl_dimensao_min.TabIndex = 2
        Me.lbl_dimensao_min.Text = "Dimensao min"
        '
        'campo_dimensao_min
        '
        Me.campo_dimensao_min.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_dimensao_min.Location = New System.Drawing.Point(363, 53)
        Me.campo_dimensao_min.Name = "campo_dimensao_min"
        Me.campo_dimensao_min.Size = New System.Drawing.Size(342, 23)
        Me.campo_dimensao_min.TabIndex = 3
        '
        'lbl_dimensao_max
        '
        Me.lbl_dimensao_max.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_dimensao_max.Location = New System.Drawing.Point(15, 88)
        Me.lbl_dimensao_max.Name = "lbl_dimensao_max"
        Me.lbl_dimensao_max.Size = New System.Drawing.Size(342, 38)
        Me.lbl_dimensao_max.TabIndex = 4
        Me.lbl_dimensao_max.Text = "Dimensao max"
        '
        'campo_dimensao_max
        '
        Me.campo_dimensao_max.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_dimensao_max.Location = New System.Drawing.Point(363, 91)
        Me.campo_dimensao_max.Name = "campo_dimensao_max"
        Me.campo_dimensao_max.Size = New System.Drawing.Size(342, 23)
        Me.campo_dimensao_max.TabIndex = 5
        '
        'lbl_dimensao_min_inclusiva
        '
        Me.lbl_dimensao_min_inclusiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_dimensao_min_inclusiva.Location = New System.Drawing.Point(15, 126)
        Me.lbl_dimensao_min_inclusiva.Name = "lbl_dimensao_min_inclusiva"
        Me.lbl_dimensao_min_inclusiva.Size = New System.Drawing.Size(342, 38)
        Me.lbl_dimensao_min_inclusiva.TabIndex = 6
        Me.lbl_dimensao_min_inclusiva.Text = "Dimensao min inclusiva"
        '
        'campo_dimensao_min_inclusiva
        '
        Me.campo_dimensao_min_inclusiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_dimensao_min_inclusiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_dimensao_min_inclusiva.Items.AddRange(New Object() {"SIM", "NAO"})
        Me.campo_dimensao_min_inclusiva.Location = New System.Drawing.Point(363, 129)
        Me.campo_dimensao_min_inclusiva.Name = "campo_dimensao_min_inclusiva"
        Me.campo_dimensao_min_inclusiva.Size = New System.Drawing.Size(342, 23)
        Me.campo_dimensao_min_inclusiva.TabIndex = 7
        '
        'lbl_dimensao_max_inclusiva
        '
        Me.lbl_dimensao_max_inclusiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_dimensao_max_inclusiva.Location = New System.Drawing.Point(15, 164)
        Me.lbl_dimensao_max_inclusiva.Name = "lbl_dimensao_max_inclusiva"
        Me.lbl_dimensao_max_inclusiva.Size = New System.Drawing.Size(342, 38)
        Me.lbl_dimensao_max_inclusiva.TabIndex = 8
        Me.lbl_dimensao_max_inclusiva.Text = "Dimensao max inclusiva"
        '
        'campo_dimensao_max_inclusiva
        '
        Me.campo_dimensao_max_inclusiva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_dimensao_max_inclusiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.campo_dimensao_max_inclusiva.Items.AddRange(New Object() {"SIM", "NAO"})
        Me.campo_dimensao_max_inclusiva.Location = New System.Drawing.Point(363, 167)
        Me.campo_dimensao_max_inclusiva.Name = "campo_dimensao_max_inclusiva"
        Me.campo_dimensao_max_inclusiva.Size = New System.Drawing.Size(342, 23)
        Me.campo_dimensao_max_inclusiva.TabIndex = 9
        '
        'lbl_unidade_dimensao
        '
        Me.lbl_unidade_dimensao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_unidade_dimensao.Location = New System.Drawing.Point(15, 202)
        Me.lbl_unidade_dimensao.Name = "lbl_unidade_dimensao"
        Me.lbl_unidade_dimensao.Size = New System.Drawing.Size(342, 38)
        Me.lbl_unidade_dimensao.TabIndex = 10
        Me.lbl_unidade_dimensao.Text = "Unidade dimensao"
        '
        'campo_unidade_dimensao
        '
        Me.campo_unidade_dimensao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_unidade_dimensao.Location = New System.Drawing.Point(363, 205)
        Me.campo_unidade_dimensao.Name = "campo_unidade_dimensao"
        Me.campo_unidade_dimensao.Size = New System.Drawing.Size(342, 23)
        Me.campo_unidade_dimensao.TabIndex = 11
        '
        'lbl_condicoes_adicionais
        '
        Me.lbl_condicoes_adicionais.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_condicoes_adicionais.Location = New System.Drawing.Point(15, 240)
        Me.lbl_condicoes_adicionais.Name = "lbl_condicoes_adicionais"
        Me.lbl_condicoes_adicionais.Size = New System.Drawing.Size(342, 100)
        Me.lbl_condicoes_adicionais.TabIndex = 12
        Me.lbl_condicoes_adicionais.Text = "Condicoes adicionais"
        '
        'campo_condicoes_adicionais
        '
        Me.campo_condicoes_adicionais.AcceptsReturn = True
        Me.campo_condicoes_adicionais.Dock = System.Windows.Forms.DockStyle.Fill
        Me.campo_condicoes_adicionais.Location = New System.Drawing.Point(363, 243)
        Me.campo_condicoes_adicionais.Multiline = True
        Me.campo_condicoes_adicionais.Name = "campo_condicoes_adicionais"
        Me.campo_condicoes_adicionais.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.campo_condicoes_adicionais.Size = New System.Drawing.Size(342, 94)
        Me.campo_condicoes_adicionais.TabIndex = 13
        '
        'btnAplicar
        '
        Me.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAplicar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAplicar.Location = New System.Drawing.Point(363, 343)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(342, 45)
        Me.btnAplicar.TabIndex = 7
        Me.btnAplicar.Text = "Aplicar"
        '
        'frmAplicacaoPerfil
        '
        Me.AcceptButton = Me.btnAplicar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 403)
        Me.Controls.Add(Me.layoutCampos)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "frmAplicacaoPerfil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aplicação do perfil"
        Me.layoutCampos.ResumeLayout(False)
        Me.layoutCampos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutCampos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_dimensao_referencia As System.Windows.Forms.Label
    Friend WithEvents campo_dimensao_referencia As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_dimensao_min As System.Windows.Forms.Label
    Friend WithEvents campo_dimensao_min As System.Windows.Forms.TextBox
    Friend WithEvents lbl_dimensao_max As System.Windows.Forms.Label
    Friend WithEvents campo_dimensao_max As System.Windows.Forms.TextBox
    Friend WithEvents lbl_dimensao_min_inclusiva As System.Windows.Forms.Label
    Friend WithEvents campo_dimensao_min_inclusiva As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_dimensao_max_inclusiva As System.Windows.Forms.Label
    Friend WithEvents campo_dimensao_max_inclusiva As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_unidade_dimensao As System.Windows.Forms.Label
    Friend WithEvents campo_unidade_dimensao As System.Windows.Forms.TextBox
    Friend WithEvents lbl_condicoes_adicionais As System.Windows.Forms.Label
    Friend WithEvents campo_condicoes_adicionais As System.Windows.Forms.TextBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
End Class
