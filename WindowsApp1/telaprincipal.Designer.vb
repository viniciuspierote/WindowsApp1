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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_principal))
        Me.btnUsuariosSistema = New System.Windows.Forms.Button()
        Me.btnMinhaSenha = New System.Windows.Forms.Button()
        Me.btnSairSessao = New System.Windows.Forms.Button()
        Me.lblUsuarioSistema = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnespeci = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnConfiguracoes = New System.Windows.Forms.Button()
        Me.btnHistoricoBackups = New System.Windows.Forms.Button()
        Me.btnBackupAdicional = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarCertificadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmissãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmitirCertificadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUsuariosSistema
        '
        Me.btnUsuariosSistema.Location = New System.Drawing.Point(12, 242)
        Me.btnUsuariosSistema.Name = "btnUsuariosSistema"
        Me.btnUsuariosSistema.Size = New System.Drawing.Size(150, 42)
        Me.btnUsuariosSistema.TabIndex = 19
        Me.btnUsuariosSistema.Text = "Usuários"
        '
        'btnMinhaSenha
        '
        Me.btnMinhaSenha.Location = New System.Drawing.Point(174, 242)
        Me.btnMinhaSenha.Name = "btnMinhaSenha"
        Me.btnMinhaSenha.Size = New System.Drawing.Size(160, 42)
        Me.btnMinhaSenha.TabIndex = 20
        Me.btnMinhaSenha.Text = "Alterar minha senha"
        '
        'btnSairSessao
        '
        Me.btnSairSessao.Location = New System.Drawing.Point(346, 242)
        Me.btnSairSessao.Name = "btnSairSessao"
        Me.btnSairSessao.Size = New System.Drawing.Size(150, 42)
        Me.btnSairSessao.TabIndex = 21
        Me.btnSairSessao.Text = "Sair da sessão"
        '
        'lblUsuarioSistema
        '
        Me.lblUsuarioSistema.Location = New System.Drawing.Point(12, 300)
        Me.lblUsuarioSistema.Name = "lblUsuarioSistema"
        Me.lblUsuarioSistema.Size = New System.Drawing.Size(490, 34)
        Me.lblUsuarioSistema.TabIndex = 22
        Me.lblUsuarioSistema.Text = "Usuário autenticado"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(265, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 54)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Emitir Certificado"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.AutoSize = True
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(247, 54)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cadastrar Lote"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(265, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(231, 52)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Certificados Emitidos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 358)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(533, 22)
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
        Me.btnespeci.Location = New System.Drawing.Point(12, 72)
        Me.btnespeci.Name = "btnespeci"
        Me.btnespeci.Size = New System.Drawing.Size(247, 52)
        Me.btnespeci.TabIndex = 10
        Me.btnespeci.Text = "Cadastrar Especificação do cliente"
        Me.btnespeci.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(265, 130)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(231, 47)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Cadastrar Cliente"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnConfiguracoes
        '
        Me.btnConfiguracoes.Location = New System.Drawing.Point(12, 130)
        Me.btnConfiguracoes.Name = "btnConfiguracoes"
        Me.btnConfiguracoes.Size = New System.Drawing.Size(247, 47)
        Me.btnConfiguracoes.TabIndex = 14
        Me.btnConfiguracoes.Text = "Configurações"
        Me.btnConfiguracoes.UseVisualStyleBackColor = True
        '
        'btnHistoricoBackups
        '
        Me.btnHistoricoBackups.Location = New System.Drawing.Point(12, 183)
        Me.btnHistoricoBackups.Name = "btnHistoricoBackups"
        Me.btnHistoricoBackups.Size = New System.Drawing.Size(247, 44)
        Me.btnHistoricoBackups.TabIndex = 16
        Me.btnHistoricoBackups.Text = "Histórico dos backups"
        Me.btnHistoricoBackups.UseVisualStyleBackColor = True
        '
        'btnBackupAdicional
        '
        Me.btnBackupAdicional.Location = New System.Drawing.Point(265, 183)
        Me.btnBackupAdicional.Name = "btnBackupAdicional"
        Me.btnBackupAdicional.Size = New System.Drawing.Size(231, 44)
        Me.btnBackupAdicional.TabIndex = 17
        Me.btnBackupAdicional.Text = "Backup adicional"
        Me.btnBackupAdicional.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem, Me.CadastrosToolStripMenuItem, Me.EmissãoToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(533, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ArquivoToolStripMenuItem.Text = "Arquivo"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'CadastrosToolStripMenuItem
        '
        Me.CadastrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarCertificadoToolStripMenuItem, Me.NormaToolStripMenuItem})
        Me.CadastrosToolStripMenuItem.Name = "CadastrosToolStripMenuItem"
        Me.CadastrosToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.CadastrosToolStripMenuItem.Text = "Cadastros"
        '
        'CadastrarCertificadoToolStripMenuItem
        '
        Me.CadastrarCertificadoToolStripMenuItem.Name = "CadastrarCertificadoToolStripMenuItem"
        Me.CadastrarCertificadoToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.CadastrarCertificadoToolStripMenuItem.Text = "Certificado"
        '
        'NormaToolStripMenuItem
        '
        Me.NormaToolStripMenuItem.Name = "NormaToolStripMenuItem"
        Me.NormaToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NormaToolStripMenuItem.Text = "Norma"
        '
        'EmissãoToolStripMenuItem
        '
        Me.EmissãoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmitirCertificadoToolStripMenuItem})
        Me.EmissãoToolStripMenuItem.Name = "EmissãoToolStripMenuItem"
        Me.EmissãoToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.EmissãoToolStripMenuItem.Text = "Emissão"
        '
        'EmitirCertificadoToolStripMenuItem
        '
        Me.EmitirCertificadoToolStripMenuItem.Name = "EmitirCertificadoToolStripMenuItem"
        Me.EmitirCertificadoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EmitirCertificadoToolStripMenuItem.Text = "Emitir Certificado"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjudaToolStripMenuItem1})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem.Text = "Ajuda"
        '
        'AjudaToolStripMenuItem1
        '
        Me.AjudaToolStripMenuItem1.Name = "AjudaToolStripMenuItem1"
        Me.AjudaToolStripMenuItem1.Size = New System.Drawing.Size(105, 22)
        Me.AjudaToolStripMenuItem1.Text = "Ajuda"
        '
        'frm_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 380)
        Me.Controls.Add(Me.btnBackupAdicional)
        Me.Controls.Add(Me.btnHistoricoBackups)
        Me.Controls.Add(Me.btnConfiguracoes)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnespeci)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnUsuariosSistema)
        Me.Controls.Add(Me.btnMinhaSenha)
        Me.Controls.Add(Me.btnSairSessao)
        Me.Controls.Add(Me.lblUsuarioSistema)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Certificado Sandinox - Tela Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
    Friend WithEvents btnConfiguracoes As Button
    Friend WithEvents btnHistoricoBackups As Button
    Friend WithEvents btnBackupAdicional As Button
    Friend WithEvents btnUsuariosSistema As System.Windows.Forms.Button
    Friend WithEvents btnMinhaSenha As System.Windows.Forms.Button
    Friend WithEvents btnSairSessao As System.Windows.Forms.Button
    Friend WithEvents lblUsuarioSistema As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastrarCertificadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmissãoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmitirCertificadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem1 As ToolStripMenuItem
End Class

