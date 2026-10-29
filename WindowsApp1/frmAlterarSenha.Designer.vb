<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlterarSenha
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
        Me.components = New System.ComponentModel.Container()
        Me.lblOrientacao = New System.Windows.Forms.Label()
        Me.lbl_txtSenhaAtual = New System.Windows.Forms.Label()
        Me.txtSenhaAtual = New System.Windows.Forms.TextBox()
        Me.lbl_txtNovaSenha = New System.Windows.Forms.Label()
        Me.txtNovaSenha = New System.Windows.Forms.TextBox()
        Me.lbl_txtConfirmacao = New System.Windows.Forms.Label()
        Me.txtConfirmacao = New System.Windows.Forms.TextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        Me.lblOrientacao.Name = "lblOrientacao"
        Me.lblOrientacao.Text = "Use de 15 a 128 caracteres. Confirme a senha atual."
        Me.lblOrientacao.Location = New System.Drawing.Point(22, 18)
        Me.lblOrientacao.Size = New System.Drawing.Size(470, 48)
        Me.lbl_txtSenhaAtual.Name = "lbl_txtSenhaAtual"
        Me.lbl_txtSenhaAtual.Text = "Senha atual"
        Me.lbl_txtSenhaAtual.Location = New System.Drawing.Point(22, 80)
        Me.lbl_txtSenhaAtual.Size = New System.Drawing.Size(470, 20)
        Me.txtSenhaAtual.Name = "txtSenhaAtual"
        Me.txtSenhaAtual.Location = New System.Drawing.Point(22, 102)
        Me.txtSenhaAtual.Size = New System.Drawing.Size(470, 25)
        Me.txtSenhaAtual.TabIndex = 0
        Me.txtSenhaAtual.MaxLength = 128
        Me.txtSenhaAtual.UseSystemPasswordChar = True
        Me.lbl_txtNovaSenha.Name = "lbl_txtNovaSenha"
        Me.lbl_txtNovaSenha.Text = "Nova senha"
        Me.lbl_txtNovaSenha.Location = New System.Drawing.Point(22, 142)
        Me.lbl_txtNovaSenha.Size = New System.Drawing.Size(470, 20)
        Me.txtNovaSenha.Name = "txtNovaSenha"
        Me.txtNovaSenha.Location = New System.Drawing.Point(22, 164)
        Me.txtNovaSenha.Size = New System.Drawing.Size(470, 25)
        Me.txtNovaSenha.TabIndex = 1
        Me.txtNovaSenha.MaxLength = 128
        Me.txtNovaSenha.UseSystemPasswordChar = True
        Me.lbl_txtConfirmacao.Name = "lbl_txtConfirmacao"
        Me.lbl_txtConfirmacao.Text = "Confirme a nova senha"
        Me.lbl_txtConfirmacao.Location = New System.Drawing.Point(22, 204)
        Me.lbl_txtConfirmacao.Size = New System.Drawing.Size(470, 20)
        Me.txtConfirmacao.Name = "txtConfirmacao"
        Me.txtConfirmacao.Location = New System.Drawing.Point(22, 226)
        Me.txtConfirmacao.Size = New System.Drawing.Size(470, 25)
        Me.txtConfirmacao.TabIndex = 2
        Me.txtConfirmacao.MaxLength = 128
        Me.txtConfirmacao.UseSystemPasswordChar = True
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Text = "Salvar nova senha"
        Me.btnSalvar.Location = New System.Drawing.Point(22, 280)
        Me.btnSalvar.Size = New System.Drawing.Size(172, 34)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.Location = New System.Drawing.Point(320, 280)
        Me.btnCancelar.Size = New System.Drawing.Size(172, 34)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AcceptButton = Me.btnSalvar
        Me.CancelButton = Me.btnCancelar
        Me.Controls.Add(Me.lblOrientacao)
        Me.Controls.Add(Me.lbl_txtSenhaAtual)
        Me.Controls.Add(Me.txtSenhaAtual)
        Me.Controls.Add(Me.lbl_txtNovaSenha)
        Me.Controls.Add(Me.txtNovaSenha)
        Me.Controls.Add(Me.lbl_txtConfirmacao)
        Me.Controls.Add(Me.txtConfirmacao)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ClientSize = New System.Drawing.Size(520, 335)
        Me.Name = "frmAlterarSenha"
        Me.Text = "Sandinox — Alterar minha senha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents lblOrientacao As System.Windows.Forms.Label
    Friend WithEvents lbl_txtSenhaAtual As System.Windows.Forms.Label
    Friend WithEvents txtSenhaAtual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtNovaSenha As System.Windows.Forms.Label
    Friend WithEvents txtNovaSenha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtConfirmacao As System.Windows.Forms.Label
    Friend WithEvents txtConfirmacao As System.Windows.Forms.TextBox
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
