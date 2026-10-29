<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConferenciaNormas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.layoutPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAviso = New System.Windows.Forms.Label()
        Me._seletor = New System.Windows.Forms.ComboBox()
        Me._detalhes = New System.Windows.Forms.TextBox()
        Me._resumo = New System.Windows.Forms.Label()
        Me.abas = New System.Windows.Forms.TabControl()
        Me.abaQuimica = New System.Windows.Forms.TabPage()
        Me._quimicaGrid = New System.Windows.Forms.DataGridView()
        Me.abaMecanica = New System.Windows.Forms.TabPage()
        Me._mecanicaGrid = New System.Windows.Forms.DataGridView()
        Me.rodape = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.layoutPrincipal.SuspendLayout()
        Me.abas.SuspendLayout()
        Me.abaQuimica.SuspendLayout()
        CType(Me._quimicaGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.abaMecanica.SuspendLayout()
        CType(Me._mecanicaGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rodape.SuspendLayout()
        Me.SuspendLayout()
        '
        'layoutPrincipal
        '
        Me.layoutPrincipal.ColumnCount = 1
        Me.layoutPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutPrincipal.Controls.Add(Me.lblAviso, 0, 0)
        Me.layoutPrincipal.Controls.Add(Me._seletor, 0, 1)
        Me.layoutPrincipal.Controls.Add(Me._detalhes, 0, 2)
        Me.layoutPrincipal.Controls.Add(Me._resumo, 0, 4)
        Me.layoutPrincipal.Controls.Add(Me.abas, 0, 3)
        Me.layoutPrincipal.Controls.Add(Me.rodape, 0, 5)
        Me.layoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.layoutPrincipal.Name = "layoutPrincipal"
        Me.layoutPrincipal.Padding = New System.Windows.Forms.Padding(12)
        Me.layoutPrincipal.RowCount = 6
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.layoutPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.layoutPrincipal.Size = New System.Drawing.Size(1180, 790)
        Me.layoutPrincipal.TabIndex = 0
        '
        'lblAviso
        '
        Me.lblAviso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAviso.ForeColor = System.Drawing.Color.DarkRed
        Me.lblAviso.Location = New System.Drawing.Point(15, 12)
        Me.lblAviso.Name = "lblAviso"
        Me.lblAviso.Size = New System.Drawing.Size(1150, 42)
        Me.lblAviso.TabIndex = 0
        Me.lblAviso.Text = "PRÉ-CONFERÊNCIA: compara os números com os requisitos cadastrados. Não declara co" &
    "nformidade integral. Perfis em RASCUNHO servem para teste; documentos e condiçõe" &
    "s de ensaio continuam pendentes."
        '
        '_seletor
        '
        Me._seletor.Dock = System.Windows.Forms.DockStyle.Fill
        Me._seletor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._seletor.Location = New System.Drawing.Point(15, 57)
        Me._seletor.Name = "_seletor"
        Me._seletor.Size = New System.Drawing.Size(1150, 23)
        Me._seletor.TabIndex = 1
        '
        '_detalhes
        '
        Me._detalhes.Dock = System.Windows.Forms.DockStyle.Fill
        Me._detalhes.Location = New System.Drawing.Point(15, 91)
        Me._detalhes.Multiline = True
        Me._detalhes.Name = "_detalhes"
        Me._detalhes.ReadOnly = True
        Me._detalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me._detalhes.Size = New System.Drawing.Size(1150, 129)
        Me._detalhes.TabIndex = 2
        Me._detalhes.Text = "Selecione o perfil correspondente ao material, forma e condição do lote."
        '
        '_resumo
        '
        Me._resumo.Dock = System.Windows.Forms.DockStyle.Fill
        Me._resumo.Location = New System.Drawing.Point(15, 678)
        Me._resumo.Name = "_resumo"
        Me._resumo.Size = New System.Drawing.Size(1150, 60)
        Me._resumo.TabIndex = 3
        Me._resumo.Text = "Química: valores gravados. Mecânica: valores atuais da tela, inclusive alterações" &
    " ainda não salvas."
        '
        'abas
        '
        Me.abas.Controls.Add(Me.abaQuimica)
        Me.abas.Controls.Add(Me.abaMecanica)
        Me.abas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.abas.Location = New System.Drawing.Point(15, 226)
        Me.abas.Name = "abas"
        Me.abas.SelectedIndex = 0
        Me.abas.Size = New System.Drawing.Size(1150, 449)
        Me.abas.TabIndex = 4
        '
        'abaQuimica
        '
        Me.abaQuimica.Controls.Add(Me._quimicaGrid)
        Me.abaQuimica.Location = New System.Drawing.Point(4, 24)
        Me.abaQuimica.Name = "abaQuimica"
        Me.abaQuimica.Size = New System.Drawing.Size(1142, 421)
        Me.abaQuimica.TabIndex = 0
        Me.abaQuimica.Text = "Composição química"
        '
        '_quimicaGrid
        '
        Me._quimicaGrid.AllowUserToAddRows = False
        Me._quimicaGrid.AllowUserToDeleteRows = False
        Me._quimicaGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._quimicaGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me._quimicaGrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me._quimicaGrid.DefaultCellStyle = DataGridViewCellStyle1
        Me._quimicaGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me._quimicaGrid.Location = New System.Drawing.Point(0, 0)
        Me._quimicaGrid.Name = "_quimicaGrid"
        Me._quimicaGrid.ReadOnly = True
        Me._quimicaGrid.RowHeadersVisible = False
        Me._quimicaGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me._quimicaGrid.Size = New System.Drawing.Size(1142, 421)
        Me._quimicaGrid.TabIndex = 0
        '
        'abaMecanica
        '
        Me.abaMecanica.Controls.Add(Me._mecanicaGrid)
        Me.abaMecanica.Location = New System.Drawing.Point(4, 24)
        Me.abaMecanica.Name = "abaMecanica"
        Me.abaMecanica.Size = New System.Drawing.Size(162, 0)
        Me.abaMecanica.TabIndex = 1
        Me.abaMecanica.Text = "Propriedades mecânicas"
        '
        '_mecanicaGrid
        '
        Me._mecanicaGrid.AllowUserToAddRows = False
        Me._mecanicaGrid.AllowUserToDeleteRows = False
        Me._mecanicaGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._mecanicaGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me._mecanicaGrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me._mecanicaGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me._mecanicaGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me._mecanicaGrid.Location = New System.Drawing.Point(0, 0)
        Me._mecanicaGrid.Name = "_mecanicaGrid"
        Me._mecanicaGrid.ReadOnly = True
        Me._mecanicaGrid.RowHeadersVisible = False
        Me._mecanicaGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me._mecanicaGrid.Size = New System.Drawing.Size(162, 0)
        Me._mecanicaGrid.TabIndex = 0
        '
        'rodape
        '
        Me.rodape.Controls.Add(Me.btnFechar)
        Me.rodape.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rodape.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.rodape.Location = New System.Drawing.Point(15, 741)
        Me.rodape.Name = "rodape"
        Me.rodape.Size = New System.Drawing.Size(1150, 34)
        Me.rodape.TabIndex = 5
        '
        'btnFechar
        '
        Me.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFechar.Location = New System.Drawing.Point(1072, 3)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(75, 23)
        Me.btnFechar.TabIndex = 0
        Me.btnFechar.Text = "Fechar"
        '
        'frmConferenciaNormas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnFechar
        Me.ClientSize = New System.Drawing.Size(1180, 790)
        Me.Controls.Add(Me.layoutPrincipal)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "frmConferenciaNormas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sandinox — Conferência de norma"
        Me.layoutPrincipal.ResumeLayout(False)
        Me.layoutPrincipal.PerformLayout()
        Me.abas.ResumeLayout(False)
        Me.abaQuimica.ResumeLayout(False)
        CType(Me._quimicaGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.abaMecanica.ResumeLayout(False)
        CType(Me._mecanicaGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rodape.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblAviso As System.Windows.Forms.Label
    Friend WithEvents _seletor As System.Windows.Forms.ComboBox
    Friend WithEvents _detalhes As System.Windows.Forms.TextBox
    Friend WithEvents _resumo As System.Windows.Forms.Label
    Friend WithEvents abas As System.Windows.Forms.TabControl
    Friend WithEvents abaQuimica As System.Windows.Forms.TabPage
    Friend WithEvents _quimicaGrid As System.Windows.Forms.DataGridView
    Friend WithEvents _quimicaGrid_propriedade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _quimicaGrid_origem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _quimicaGrid_resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _quimicaGrid_limite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _quimicaGrid_situacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _quimicaGrid_referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents abaMecanica As System.Windows.Forms.TabPage
    Friend WithEvents _mecanicaGrid As System.Windows.Forms.DataGridView
    Friend WithEvents _mecanicaGrid_propriedade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _mecanicaGrid_origem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _mecanicaGrid_resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _mecanicaGrid_limite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _mecanicaGrid_situacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents _mecanicaGrid_referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rodape As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFechar As System.Windows.Forms.Button
End Class
