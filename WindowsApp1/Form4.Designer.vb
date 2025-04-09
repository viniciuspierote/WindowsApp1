<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvdados = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txttipo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtvalor = New System.Windows.Forms.TextBox()
        Me.btnatualizar = New System.Windows.Forms.Button()
        Me.btnexcluir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtworkorder = New System.Windows.Forms.TextBox()
        Me.btnexibir = New System.Windows.Forms.Button()
        Me.txtsequencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnprocurar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgvdados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Composição Quimíca:"
        '
        'dgvdados
        '
        Me.dgvdados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdados.Location = New System.Drawing.Point(12, 90)
        Me.dgvdados.Name = "dgvdados"
        Me.dgvdados.Size = New System.Drawing.Size(776, 150)
        Me.dgvdados.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(373, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "incluir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txttipo
        '
        Me.txttipo.Location = New System.Drawing.Point(161, 62)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(100, 20)
        Me.txttipo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Elemento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(274, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Valor:"
        '
        'txtvalor
        '
        Me.txtvalor.Location = New System.Drawing.Point(267, 62)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(100, 20)
        Me.txtvalor.TabIndex = 5
        '
        'btnatualizar
        '
        Me.btnatualizar.Location = New System.Drawing.Point(454, 59)
        Me.btnatualizar.Name = "btnatualizar"
        Me.btnatualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnatualizar.TabIndex = 7
        Me.btnatualizar.Text = "Editar"
        Me.btnatualizar.UseVisualStyleBackColor = True
        '
        'btnexcluir
        '
        Me.btnexcluir.Location = New System.Drawing.Point(535, 59)
        Me.btnexcluir.Name = "btnexcluir"
        Me.btnexcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnexcluir.TabIndex = 8
        Me.btnexcluir.Text = "Excluir"
        Me.btnexcluir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Work Order:"
        '
        'txtworkorder
        '
        Me.txtworkorder.Location = New System.Drawing.Point(14, 62)
        Me.txtworkorder.Name = "txtworkorder"
        Me.txtworkorder.Size = New System.Drawing.Size(100, 20)
        Me.txtworkorder.TabIndex = 12
        '
        'btnexibir
        '
        Me.btnexibir.Location = New System.Drawing.Point(616, 59)
        Me.btnexibir.Name = "btnexibir"
        Me.btnexibir.Size = New System.Drawing.Size(90, 23)
        Me.btnexibir.TabIndex = 13
        Me.btnexibir.Text = "Exibir"
        Me.btnexibir.UseVisualStyleBackColor = True
        '
        'txtsequencia
        '
        Me.txtsequencia.Location = New System.Drawing.Point(120, 62)
        Me.txtsequencia.Name = "txtsequencia"
        Me.txtsequencia.Size = New System.Drawing.Size(35, 20)
        Me.txtsequencia.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(123, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Item:"
        '
        'btnprocurar
        '
        Me.btnprocurar.Location = New System.Drawing.Point(713, -1)
        Me.btnprocurar.Name = "btnprocurar"
        Me.btnprocurar.Size = New System.Drawing.Size(75, 23)
        Me.btnprocurar.TabIndex = 16
        Me.btnprocurar.Text = "Procurar"
        Me.btnprocurar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(511, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 290)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnprocurar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsequencia)
        Me.Controls.Add(Me.btnexibir)
        Me.Controls.Add(Me.txtworkorder)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnexcluir)
        Me.Controls.Add(Me.btnatualizar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtvalor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txttipo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvdados)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Certificado Sandinox - Cadastro da Composição Quimica"
        CType(Me.dgvdados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvdados As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents txttipo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtvalor As TextBox
    Friend WithEvents btnatualizar As Button
    Friend WithEvents btnexcluir As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtworkorder As TextBox
    Friend WithEvents btnexibir As Button
    Friend WithEvents txtsequencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnprocurar As Button
    Friend WithEvents Button2 As Button
End Class
