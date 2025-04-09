<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmteste
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnnovo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtnome = New System.Windows.Forms.TextBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.dgvdados = New System.Windows.Forms.DataGridView()
        Me.btnexibir = New System.Windows.Forms.Button()
        Me.btneditar = New System.Windows.Forms.Button()
        Me.btnexcluir = New System.Windows.Forms.Button()
        Me.btnconsultar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtteste = New System.Windows.Forms.TextBox()
        CType(Me.dgvdados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnnovo
        '
        Me.btnnovo.Location = New System.Drawing.Point(43, 121)
        Me.btnnovo.Name = "btnnovo"
        Me.btnnovo.Size = New System.Drawing.Size(75, 23)
        Me.btnnovo.TabIndex = 0
        Me.btnnovo.Text = "Novo"
        Me.btnnovo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(49, 54)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Nome:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Numero:"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(93, 28)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(100, 20)
        Me.txtid.TabIndex = 4
        '
        'txtnome
        '
        Me.txtnome.Location = New System.Drawing.Point(93, 54)
        Me.txtnome.Name = "txtnome"
        Me.txtnome.Size = New System.Drawing.Size(100, 20)
        Me.txtnome.TabIndex = 5
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(93, 80)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(100, 20)
        Me.txtnumero.TabIndex = 6
        '
        'dgvdados
        '
        Me.dgvdados.AllowUserToAddRows = False
        Me.dgvdados.AllowUserToDeleteRows = False
        Me.dgvdados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdados.Location = New System.Drawing.Point(43, 150)
        Me.dgvdados.Name = "dgvdados"
        Me.dgvdados.ReadOnly = True
        Me.dgvdados.Size = New System.Drawing.Size(713, 150)
        Me.dgvdados.TabIndex = 7
        '
        'btnexibir
        '
        Me.btnexibir.Location = New System.Drawing.Point(367, 121)
        Me.btnexibir.Name = "btnexibir"
        Me.btnexibir.Size = New System.Drawing.Size(75, 23)
        Me.btnexibir.TabIndex = 8
        Me.btnexibir.Text = "Exibir"
        Me.btnexibir.UseVisualStyleBackColor = True
        '
        'btneditar
        '
        Me.btneditar.Location = New System.Drawing.Point(124, 121)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Size = New System.Drawing.Size(75, 23)
        Me.btneditar.TabIndex = 9
        Me.btneditar.Text = "Editar"
        Me.btneditar.UseVisualStyleBackColor = True
        '
        'btnexcluir
        '
        Me.btnexcluir.Location = New System.Drawing.Point(205, 121)
        Me.btnexcluir.Name = "btnexcluir"
        Me.btnexcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnexcluir.TabIndex = 10
        Me.btnexcluir.Text = "Excluir"
        Me.btnexcluir.UseVisualStyleBackColor = True
        '
        'btnconsultar
        '
        Me.btnconsultar.Location = New System.Drawing.Point(286, 121)
        Me.btnconsultar.Name = "btnconsultar"
        Me.btnconsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnconsultar.TabIndex = 11
        Me.btnconsultar.Text = "Consultar"
        Me.btnconsultar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(285, 364)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtteste
        '
        Me.txtteste.Location = New System.Drawing.Point(179, 367)
        Me.txtteste.Name = "txtteste"
        Me.txtteste.Size = New System.Drawing.Size(100, 20)
        Me.txtteste.TabIndex = 13
        '
        'frmteste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtteste)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnconsultar)
        Me.Controls.Add(Me.btnexcluir)
        Me.Controls.Add(Me.btneditar)
        Me.Controls.Add(Me.btnexibir)
        Me.Controls.Add(Me.dgvdados)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.txtnome)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnnovo)
        Me.MaximizeBox = False
        Me.Name = "frmteste"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cadastrar composição quimíca"
        CType(Me.dgvdados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnnovo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtid As TextBox
    Friend WithEvents txtnome As TextBox
    Friend WithEvents txtnumero As TextBox
    Friend WithEvents dgvdados As DataGridView
    Friend WithEvents btnexibir As Button
    Friend WithEvents btneditar As Button
    Friend WithEvents btnexcluir As Button
    Friend WithEvents btnconsultar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtteste As TextBox
End Class
