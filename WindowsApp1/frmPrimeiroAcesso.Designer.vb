<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrimeiroAcesso
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
        Me.lbl_txtNome = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.lbl_txtLogin = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lbl_txtSenha = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.lbl_txtConfirmacao = New System.Windows.Forms.Label()
        Me.txtConfirmacao = New System.Windows.Forms.TextBox()
        Me.btnCriar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        Me.lblOrientacao.Name = "lblOrientacao"
        Me.lblOrientacao.Text = "Crie o primeiro administrador da Sandinox. Não existe senha padrão."
        Me.lblOrientacao.Location = New System.Drawing.Point(22, 18)
        Me.lblOrientacao.Size = New System.Drawing.Size(470, 48)
        Me.lbl_txtNome.Name = "lbl_txtNome"
        Me.lbl_txtNome.Text = "Nome completo"
        Me.lbl_txtNome.Location = New System.Drawing.Point(22, 80)
        Me.lbl_txtNome.Size = New System.Drawing.Size(470, 20)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Location = New System.Drawing.Point(22, 102)
        Me.txtNome.Size = New System.Drawing.Size(470, 25)
        Me.txtNome.TabIndex = 0
        Me.txtNome.MaxLength = 120
        Me.lbl_txtLogin.Name = "lbl_txtLogin"
        Me.lbl_txtLogin.Text = "Usuário sem acentos"
        Me.lbl_txtLogin.Location = New System.Drawing.Point(22, 142)
        Me.lbl_txtLogin.Size = New System.Drawing.Size(470, 20)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Location = New System.Drawing.Point(22, 164)
        Me.txtLogin.Size = New System.Drawing.Size(470, 25)
        Me.txtLogin.TabIndex = 1
        Me.txtLogin.MaxLength = 60
        Me.lbl_txtSenha.Name = "lbl_txtSenha"
        Me.lbl_txtSenha.Text = "Senha ou frase de 15 a 128 caracteres"
        Me.lbl_txtSenha.Location = New System.Drawing.Point(22, 204)
        Me.lbl_txtSenha.Size = New System.Drawing.Size(470, 20)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Location = New System.Drawing.Point(22, 226)
        Me.txtSenha.Size = New System.Drawing.Size(470, 25)
        Me.txtSenha.TabIndex = 2
        Me.txtSenha.MaxLength = 128
        Me.txtSenha.UseSystemPasswordChar = True
        Me.lbl_txtConfirmacao.Name = "lbl_txtConfirmacao"
        Me.lbl_txtConfirmacao.Text = "Confirme a senha"
        Me.lbl_txtConfirmacao.Location = New System.Drawing.Point(22, 266)
        Me.lbl_txtConfirmacao.Size = New System.Drawing.Size(470, 20)
        Me.txtConfirmacao.Name = "txtConfirmacao"
        Me.txtConfirmacao.Location = New System.Drawing.Point(22, 288)
        Me.txtConfirmacao.Size = New System.Drawing.Size(470, 25)
        Me.txtConfirmacao.TabIndex = 3
        Me.txtConfirmacao.MaxLength = 128
        Me.txtConfirmacao.UseSystemPasswordChar = True
        Me.btnCriar.Name = "btnCriar"
        Me.btnCriar.Text = "Criar administrador"
        Me.btnCriar.Location = New System.Drawing.Point(22, 342)
        Me.btnCriar.Size = New System.Drawing.Size(172, 34)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.Location = New System.Drawing.Point(320, 342)
        Me.btnCancelar.Size = New System.Drawing.Size(172, 34)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AcceptButton = Me.btnCriar
        Me.CancelButton = Me.btnCancelar
        Me.Controls.Add(Me.lblOrientacao)
        Me.Controls.Add(Me.lbl_txtNome)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.lbl_txtLogin)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.lbl_txtSenha)
        Me.Controls.Add(Me.txtSenha)
        Me.Controls.Add(Me.lbl_txtConfirmacao)
        Me.Controls.Add(Me.txtConfirmacao)
        Me.Controls.Add(Me.btnCriar)
        Me.Controls.Add(Me.btnCancelar)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ClientSize = New System.Drawing.Size(520, 398)
        Me.Name = "frmPrimeiroAcesso"
        Me.Text = "Sandinox — Primeiro acesso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents lblOrientacao As System.Windows.Forms.Label
    Friend WithEvents lbl_txtNome As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtLogin As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtSenha As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtConfirmacao As System.Windows.Forms.Label
    Friend WithEvents txtConfirmacao As System.Windows.Forms.TextBox
    Friend WithEvents btnCriar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
