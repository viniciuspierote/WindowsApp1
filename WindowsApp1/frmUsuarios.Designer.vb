<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Me.barraAcoes = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnAtualizar = New System.Windows.Forms.Button()
        Me.btnSelecionar = New System.Windows.Forms.Button()
        Me.btnDesbloquear = New System.Windows.Forms.Button()
        Me.gradeUsuarios = New System.Windows.Forms.DataGridView()
        Me.colUsuario_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_perfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_ativo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_trocar_senha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_bloqueado_ate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario_ultimo_login = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.painelEdicao = New System.Windows.Forms.Panel()
        Me.lbl_txtLogin = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lbl_txtNome = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.lbl_txtSenha = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.lbl_txtConfirmacao = New System.Windows.Forms.Label()
        Me.txtConfirmacao = New System.Windows.Forms.TextBox()
        Me.lblPerfil = New System.Windows.Forms.Label()
        Me.cboPerfil = New System.Windows.Forms.ComboBox()
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.lblOrientacao = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        Me.barraAcoes.Name = "barraAcoes"
        Me.barraAcoes.Location = New System.Drawing.Point(14, 12)
        Me.barraAcoes.Size = New System.Drawing.Size(1000, 38)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Text = "Novo usuário"
        Me.btnNovo.AutoSize = True
        Me.btnNovo.Height = 30
        Me.btnAtualizar.Name = "btnAtualizar"
        Me.btnAtualizar.Text = "Atualizar lista"
        Me.btnAtualizar.AutoSize = True
        Me.btnAtualizar.Height = 30
        Me.btnSelecionar.Name = "btnSelecionar"
        Me.btnSelecionar.Text = "Carregar selecionado"
        Me.btnSelecionar.AutoSize = True
        Me.btnSelecionar.Height = 30
        Me.btnDesbloquear.Name = "btnDesbloquear"
        Me.btnDesbloquear.Text = "Desbloquear tentativas"
        Me.btnDesbloquear.AutoSize = True
        Me.btnDesbloquear.Height = 30
        Me.gradeUsuarios.Name = "gradeUsuarios"
        Me.gradeUsuarios.Location = New System.Drawing.Point(14, 58)
        Me.gradeUsuarios.Size = New System.Drawing.Size(1000, 250)
        Me.gradeUsuarios.ReadOnly = True
        Me.gradeUsuarios.AllowUserToAddRows = False
        Me.gradeUsuarios.AllowUserToDeleteRows = False
        Me.gradeUsuarios.AutoGenerateColumns = False
        Me.gradeUsuarios.RowHeadersVisible = False
        Me.gradeUsuarios.MultiSelect = False
        Me.gradeUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gradeUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.colUsuario_id.Name = "colUsuario_id"
        Me.colUsuario_id.HeaderText = "ID"
        Me.colUsuario_id.DataPropertyName = "id"
        Me.colUsuario_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_login.Name = "colUsuario_login"
        Me.colUsuario_login.HeaderText = "Usuário"
        Me.colUsuario_login.DataPropertyName = "login"
        Me.colUsuario_login.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_nome.Name = "colUsuario_nome"
        Me.colUsuario_nome.HeaderText = "Nome"
        Me.colUsuario_nome.DataPropertyName = "nome"
        Me.colUsuario_nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_perfil.Name = "colUsuario_perfil"
        Me.colUsuario_perfil.HeaderText = "Perfil"
        Me.colUsuario_perfil.DataPropertyName = "perfil"
        Me.colUsuario_perfil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_ativo.Name = "colUsuario_ativo"
        Me.colUsuario_ativo.HeaderText = "Ativo"
        Me.colUsuario_ativo.DataPropertyName = "ativo"
        Me.colUsuario_ativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_trocar_senha.Name = "colUsuario_trocar_senha"
        Me.colUsuario_trocar_senha.HeaderText = "Trocar senha"
        Me.colUsuario_trocar_senha.DataPropertyName = "trocar_senha"
        Me.colUsuario_trocar_senha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_bloqueado_ate.Name = "colUsuario_bloqueado_ate"
        Me.colUsuario_bloqueado_ate.HeaderText = "Bloqueado até UTC"
        Me.colUsuario_bloqueado_ate.DataPropertyName = "bloqueado_ate"
        Me.colUsuario_bloqueado_ate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_bloqueado_ate.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        Me.colUsuario_ultimo_login.Name = "colUsuario_ultimo_login"
        Me.colUsuario_ultimo_login.HeaderText = "Último acesso UTC"
        Me.colUsuario_ultimo_login.DataPropertyName = "ultimo_login"
        Me.colUsuario_ultimo_login.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colUsuario_ultimo_login.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        Me.painelEdicao.Name = "painelEdicao"
        Me.painelEdicao.Location = New System.Drawing.Point(14, 320)
        Me.painelEdicao.Size = New System.Drawing.Size(1000, 210)
        Me.lbl_txtLogin.Name = "lbl_txtLogin"
        Me.lbl_txtLogin.Text = "Usuário"
        Me.lbl_txtLogin.Location = New System.Drawing.Point(0, 0)
        Me.lbl_txtLogin.Size = New System.Drawing.Size(230, 20)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Location = New System.Drawing.Point(0, 23)
        Me.txtLogin.Size = New System.Drawing.Size(230, 25)
        Me.txtLogin.MaxLength = 60
        Me.lbl_txtNome.Name = "lbl_txtNome"
        Me.lbl_txtNome.Text = "Nome completo"
        Me.lbl_txtNome.Location = New System.Drawing.Point(250, 0)
        Me.lbl_txtNome.Size = New System.Drawing.Size(450, 20)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Location = New System.Drawing.Point(250, 23)
        Me.txtNome.Size = New System.Drawing.Size(450, 25)
        Me.txtNome.MaxLength = 120
        Me.lbl_txtSenha.Name = "lbl_txtSenha"
        Me.lbl_txtSenha.Text = "Senha inicial ou nova senha"
        Me.lbl_txtSenha.Location = New System.Drawing.Point(0, 70)
        Me.lbl_txtSenha.Size = New System.Drawing.Size(340, 20)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.Location = New System.Drawing.Point(0, 93)
        Me.txtSenha.Size = New System.Drawing.Size(340, 25)
        Me.txtSenha.MaxLength = 128
        Me.txtSenha.UseSystemPasswordChar = True
        Me.lbl_txtConfirmacao.Name = "lbl_txtConfirmacao"
        Me.lbl_txtConfirmacao.Text = "Confirme a senha"
        Me.lbl_txtConfirmacao.Location = New System.Drawing.Point(360, 70)
        Me.lbl_txtConfirmacao.Size = New System.Drawing.Size(340, 20)
        Me.txtConfirmacao.Name = "txtConfirmacao"
        Me.txtConfirmacao.Location = New System.Drawing.Point(360, 93)
        Me.txtConfirmacao.Size = New System.Drawing.Size(340, 25)
        Me.txtConfirmacao.MaxLength = 128
        Me.txtConfirmacao.UseSystemPasswordChar = True
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Text = "Perfil"
        Me.lblPerfil.Location = New System.Drawing.Point(720, 0)
        Me.lblPerfil.Size = New System.Drawing.Size(260, 20)
        Me.cboPerfil.Name = "cboPerfil"
        Me.cboPerfil.Location = New System.Drawing.Point(720, 23)
        Me.cboPerfil.Size = New System.Drawing.Size(260, 25)
        Me.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerfil.Items.AddRange(New Object() {"ADMINISTRADOR", "OPERADOR"})
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.Text = "Usuário ativo"
        Me.chkAtivo.Location = New System.Drawing.Point(720, 92)
        Me.chkAtivo.Size = New System.Drawing.Size(250, 25)
        Me.chkAtivo.Checked = True
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Text = "Salvar usuário"
        Me.btnSalvar.Location = New System.Drawing.Point(0, 142)
        Me.btnSalvar.Size = New System.Drawing.Size(180, 35)
        Me.lblOrientacao.Name = "lblOrientacao"
        Me.lblOrientacao.Text = "Novo usuário. A senha deverá ser alterada ao entrar."
        Me.lblOrientacao.Location = New System.Drawing.Point(14, 540)
        Me.lblOrientacao.Size = New System.Drawing.Size(1000, 45)
        Me.barraAcoes.Controls.Add(Me.btnNovo)
        Me.barraAcoes.Controls.Add(Me.btnAtualizar)
        Me.barraAcoes.Controls.Add(Me.btnSelecionar)
        Me.barraAcoes.Controls.Add(Me.btnDesbloquear)
        Me.gradeUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUsuario_id, Me.colUsuario_login, Me.colUsuario_nome, Me.colUsuario_perfil, Me.colUsuario_ativo, Me.colUsuario_trocar_senha, Me.colUsuario_bloqueado_ate, Me.colUsuario_ultimo_login})
        Me.painelEdicao.Controls.Add(Me.lbl_txtLogin)
        Me.painelEdicao.Controls.Add(Me.txtLogin)
        Me.painelEdicao.Controls.Add(Me.lbl_txtNome)
        Me.painelEdicao.Controls.Add(Me.txtNome)
        Me.painelEdicao.Controls.Add(Me.lbl_txtSenha)
        Me.painelEdicao.Controls.Add(Me.txtSenha)
        Me.painelEdicao.Controls.Add(Me.lbl_txtConfirmacao)
        Me.painelEdicao.Controls.Add(Me.txtConfirmacao)
        Me.painelEdicao.Controls.Add(Me.lblPerfil)
        Me.painelEdicao.Controls.Add(Me.cboPerfil)
        Me.painelEdicao.Controls.Add(Me.chkAtivo)
        Me.painelEdicao.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.barraAcoes)
        Me.Controls.Add(Me.gradeUsuarios)
        Me.Controls.Add(Me.painelEdicao)
        Me.Controls.Add(Me.lblOrientacao)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ClientSize = New System.Drawing.Size(1030, 600)
        Me.Name = "frmUsuarios"
        Me.Text = "Sandinox — Usuários do sistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents barraAcoes As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents btnAtualizar As System.Windows.Forms.Button
    Friend WithEvents btnSelecionar As System.Windows.Forms.Button
    Friend WithEvents btnDesbloquear As System.Windows.Forms.Button
    Friend WithEvents gradeUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents colUsuario_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_perfil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_ativo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_trocar_senha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_bloqueado_ate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario_ultimo_login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents painelEdicao As System.Windows.Forms.Panel
    Friend WithEvents lbl_txtLogin As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtNome As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtSenha As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents lbl_txtConfirmacao As System.Windows.Forms.Label
    Friend WithEvents txtConfirmacao As System.Windows.Forms.TextBox
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents cboPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents lblOrientacao As System.Windows.Forms.Label
End Class
