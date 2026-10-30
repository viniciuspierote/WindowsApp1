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
        Me.mnuSessao = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMinhaSenha = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCadastros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLotes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCertificados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmitirCertificado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfiguracoes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBancoDados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImpressao = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImprimirCertificado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImprimirLote = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalvarPdf = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAjuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEspecificacoes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNormas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConsultarCertificados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBackupAdicional = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHistoricoBackups = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSairSessao = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSobre = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 508)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(716, 22)
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSessao, Me.mnuCadastros, Me.mnuCertificados, Me.mnuImpressao, Me.mnuConfiguracoes, Me.mnuAjuda})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(716, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuSessao
        '
        Me.mnuSessao.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMinhaSenha, Me.mnuSairSessao})
        Me.mnuSessao.Name = "mnuSessao"
        Me.mnuSessao.Size = New System.Drawing.Size(54, 20)
        Me.mnuSessao.Text = "Sessão"
        '
        'mnuMinhaSenha
        '
        Me.mnuMinhaSenha.Name = "mnuMinhaSenha"
        Me.mnuMinhaSenha.Size = New System.Drawing.Size(180, 22)
        Me.mnuMinhaSenha.Text = "Alterar minha senha"
        '
        'mnuCadastros
        '
        Me.mnuCadastros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLotes, Me.mnuClientes, Me.mnuEspecificacoes, Me.mnuNormas})
        Me.mnuCadastros.Name = "mnuCadastros"
        Me.mnuCadastros.Size = New System.Drawing.Size(71, 20)
        Me.mnuCadastros.Text = "Cadastros"
        '
        'mnuLotes
        '
        Me.mnuLotes.Name = "mnuLotes"
        Me.mnuLotes.Size = New System.Drawing.Size(205, 22)
        Me.mnuLotes.Text = "Lotes"
        '
        'mnuClientes
        '
        Me.mnuClientes.Name = "mnuClientes"
        Me.mnuClientes.Size = New System.Drawing.Size(205, 22)
        Me.mnuClientes.Text = "Clientes"
        '
        'mnuCertificados
        '
        Me.mnuCertificados.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEmitirCertificado, Me.mnuConsultarCertificados})
        Me.mnuCertificados.Name = "mnuCertificados"
        Me.mnuCertificados.Size = New System.Drawing.Size(82, 20)
        Me.mnuCertificados.Text = "Certificados"
        '
        'mnuEmitirCertificado
        '
        Me.mnuEmitirCertificado.Name = "mnuEmitirCertificado"
        Me.mnuEmitirCertificado.Size = New System.Drawing.Size(238, 22)
        Me.mnuEmitirCertificado.Text = "Emitir certificado"
        '
        'mnuConfiguracoes
        '
        Me.mnuConfiguracoes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBancoDados, Me.mnuUsuarios, Me.mnuBackupAdicional, Me.mnuHistoricoBackups})
        Me.mnuConfiguracoes.Name = "mnuConfiguracoes"
        Me.mnuConfiguracoes.Size = New System.Drawing.Size(96, 20)
        Me.mnuConfiguracoes.Text = "Configurações"
        '
        'mnuBancoDados
        '
        Me.mnuBancoDados.Name = "mnuBancoDados"
        Me.mnuBancoDados.Size = New System.Drawing.Size(191, 22)
        Me.mnuBancoDados.Text = "Banco de dados"
        '
        'mnuImpressao
        '
        Me.mnuImpressao.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImprimirCertificado, Me.mnuImprimirLote, Me.mnuSalvarPdf})
        Me.mnuImpressao.Name = "mnuImpressao"
        Me.mnuImpressao.Size = New System.Drawing.Size(73, 20)
        Me.mnuImpressao.Text = "Impressão"
        '
        'mnuImprimirCertificado
        '
        Me.mnuImprimirCertificado.Name = "mnuImprimirCertificado"
        Me.mnuImprimirCertificado.Size = New System.Drawing.Size(180, 22)
        Me.mnuImprimirCertificado.Text = "Imprimir certificado"
        '
        'mnuImprimirLote
        '
        Me.mnuImprimirLote.Name = "mnuImprimirLote"
        Me.mnuImprimirLote.Size = New System.Drawing.Size(180, 22)
        Me.mnuImprimirLote.Text = "Imprimir em lote"
        '
        'mnuSalvarPdf
        '
        Me.mnuSalvarPdf.Name = "mnuSalvarPdf"
        Me.mnuSalvarPdf.Size = New System.Drawing.Size(180, 22)
        Me.mnuSalvarPdf.Text = "Salvar em PDF"
        '
        'mnuAjuda
        '
        Me.mnuAjuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSobre})
        Me.mnuAjuda.Name = "mnuAjuda"
        Me.mnuAjuda.Size = New System.Drawing.Size(50, 20)
        Me.mnuAjuda.Text = "Ajuda"
        '
        'mnuEspecificacoes
        '
        Me.mnuEspecificacoes.Name = "mnuEspecificacoes"
        Me.mnuEspecificacoes.Size = New System.Drawing.Size(205, 22)
        Me.mnuEspecificacoes.Text = "Especificações do cliente"
        '
        'mnuNormas
        '
        Me.mnuNormas.Name = "mnuNormas"
        Me.mnuNormas.Size = New System.Drawing.Size(205, 22)
        Me.mnuNormas.Text = "Normas"
        '
        'mnuConsultarCertificados
        '
        Me.mnuConsultarCertificados.Name = "mnuConsultarCertificados"
        Me.mnuConsultarCertificados.Size = New System.Drawing.Size(238, 22)
        Me.mnuConsultarCertificados.Text = "Consultar certificados emitidos"
        '
        'mnuUsuarios
        '
        Me.mnuUsuarios.Name = "mnuUsuarios"
        Me.mnuUsuarios.Size = New System.Drawing.Size(191, 22)
        Me.mnuUsuarios.Text = "Usuários"
        '
        'mnuBackupAdicional
        '
        Me.mnuBackupAdicional.Name = "mnuBackupAdicional"
        Me.mnuBackupAdicional.Size = New System.Drawing.Size(191, 22)
        Me.mnuBackupAdicional.Text = "Backup adicional"
        '
        'mnuHistoricoBackups
        '
        Me.mnuHistoricoBackups.Name = "mnuHistoricoBackups"
        Me.mnuHistoricoBackups.Size = New System.Drawing.Size(191, 22)
        Me.mnuHistoricoBackups.Text = "Histórico dos backups"
        '
        'mnuSairSessao
        '
        Me.mnuSairSessao.Name = "mnuSairSessao"
        Me.mnuSairSessao.Size = New System.Drawing.Size(180, 22)
        Me.mnuSairSessao.Text = "Sair da sessão"
        '
        'mnuSobre
        '
        Me.mnuSobre.Name = "mnuSobre"
        Me.mnuSobre.Size = New System.Drawing.Size(180, 22)
        Me.mnuSobre.Text = "Sobre o sistema"
        '
        'frm_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 530)
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
    Friend WithEvents mnuSessao As ToolStripMenuItem
    Friend WithEvents mnuMinhaSenha As ToolStripMenuItem
    Friend WithEvents mnuCadastros As ToolStripMenuItem
    Friend WithEvents mnuLotes As ToolStripMenuItem
    Friend WithEvents mnuClientes As ToolStripMenuItem
    Friend WithEvents mnuCertificados As ToolStripMenuItem
    Friend WithEvents mnuEmitirCertificado As ToolStripMenuItem
    Friend WithEvents mnuConfiguracoes As ToolStripMenuItem
    Friend WithEvents mnuBancoDados As ToolStripMenuItem
    Friend WithEvents mnuImpressao As ToolStripMenuItem
    Friend WithEvents mnuImprimirCertificado As ToolStripMenuItem
    Friend WithEvents mnuImprimirLote As ToolStripMenuItem
    Friend WithEvents mnuSalvarPdf As ToolStripMenuItem
    Friend WithEvents mnuAjuda As ToolStripMenuItem
    Friend WithEvents mnuSairSessao As ToolStripMenuItem
    Friend WithEvents mnuEspecificacoes As ToolStripMenuItem
    Friend WithEvents mnuNormas As ToolStripMenuItem
    Friend WithEvents mnuConsultarCertificados As ToolStripMenuItem
    Friend WithEvents mnuUsuarios As ToolStripMenuItem
    Friend WithEvents mnuBackupAdicional As ToolStripMenuItem
    Friend WithEvents mnuHistoricoBackups As ToolStripMenuItem
    Friend WithEvents mnuSobre As ToolStripMenuItem
End Class

