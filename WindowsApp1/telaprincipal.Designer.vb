<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_principal
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnespeci = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(283, 81)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 139)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Emitir Certificado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.AutoSize = True
        Me.Button2.Location = New System.Drawing.Point(83, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(194, 139)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cadastrar Lote"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(283, 226)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(194, 117)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Certificados Emitidos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 444)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(644, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(170, 17)
        Me.ToolStripStatusLabel1.Text = "Desenvolvido - Vinicius Pierote"
        '
        'btnespeci
        '
        Me.btnespeci.Location = New System.Drawing.Point(83, 226)
        Me.btnespeci.Name = "btnespeci"
        Me.btnespeci.Size = New System.Drawing.Size(194, 117)
        Me.btnespeci.TabIndex = 10
        Me.btnespeci.Text = "Cadastrar Especificação do cliente"
        Me.btnespeci.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(483, 81)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 139)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Cadastrar Cliente"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'frm_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 466)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnespeci)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.Name = "frm_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Certificado Sandinox - Tela Principal"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents btnespeci As Button
    Friend WithEvents Button4 As Button
End Class
