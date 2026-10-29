Option Strict On
Option Explicit On
Imports System
Imports System.Data
Imports System.Globalization
Imports System.Threading.Tasks
Imports System.Windows.Forms
Public Class frmUsuarios
    Private _id As Integer
    Private _ocupado As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Carregar(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Try
            SessaoAtual.ExigirAdministrador()
            AtualizarLista()
            Novo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuários")
            Close()
        End Try
    End Sub
    Private Sub AtualizarLista()
        If gradeUsuarios.Columns.Count = 0 Then gradeUsuarios.AutoGenerateColumns = True
        gradeUsuarios.DataSource = Autenticacao.ListarUsuarios()
        gradeUsuarios.ClearSelection()
    End Sub
    Private Sub Novo()
        _id = 0
        txtLogin.ReadOnly = False
        txtLogin.Clear()
        txtNome.Clear()
        txtSenha.Clear()
        txtConfirmacao.Clear()
        cboPerfil.SelectedItem = "OPERADOR"
        chkAtivo.Checked = True
        lblOrientacao.Text = "Novo usuário. Senha inicial de 15 a 128 caracteres; troca obrigatória ao entrar."
        txtLogin.Focus()
    End Sub
    Private Sub NovoClick(sender As Object, e As EventArgs) Handles btnNovo.Click
        If Not _ocupado Then Novo()
    End Sub
    Private Sub Atualizar(sender As Object, e As EventArgs) Handles btnAtualizar.Click
        If _ocupado Then Return
        Try
            AtualizarLista()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuários")
        End Try
    End Sub
    Private Sub Escolher(sender As Object, e As EventArgs) Handles btnSelecionar.Click
        If _ocupado OrElse gradeUsuarios.CurrentRow Is Nothing Then Return
        Dim registro As DataRowView = TryCast(gradeUsuarios.CurrentRow.DataBoundItem, DataRowView)
        If registro Is Nothing Then Return
        _id = Convert.ToInt32(registro.Row("id"))
        txtLogin.Text = Convert.ToString(registro.Row("login"), CultureInfo.InvariantCulture)
        txtLogin.ReadOnly = True
        txtNome.Text = Convert.ToString(registro.Row("nome"), CultureInfo.InvariantCulture)
        cboPerfil.SelectedItem = Convert.ToString(registro.Row("perfil"), CultureInfo.InvariantCulture)
        chkAtivo.Checked = Convert.ToBoolean(registro.Row("ativo"))
        txtSenha.Clear()
        txtConfirmacao.Clear()
        lblOrientacao.Text = "Usuário selecionado. Senha vazia mantém a atual. Nova senha exige troca no próximo acesso. Datas da lista em UTC."
    End Sub
    Private Sub Ocupado(valor As Boolean)
        _ocupado = valor
        painelEdicao.Enabled = Not valor
        barraAcoes.Enabled = Not valor
        gradeUsuarios.Enabled = Not valor
        UseWaitCursor = valor
    End Sub
    Private Async Sub Salvar(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If _ocupado Then Return
        If txtSenha.Text <> txtConfirmacao.Text Then
            MessageBox.Show("A confirmação da senha não confere.", "Usuários")
            Return
        End If
        Dim id As Integer = _id, nome As String = txtNome.Text, login As String = txtLogin.Text
        Dim perfil As String = cboPerfil.Text, ativo As Boolean = chkAtivo.Checked, senha As String = txtSenha.Text
        Ocupado(True)
        Try
            Await Task.Run(Sub() Autenticacao.SalvarUsuario(id, nome, login, perfil, ativo, senha))
            txtSenha.Clear()
            txtConfirmacao.Clear()
            AtualizarLista()
            Novo()
            MessageBox.Show("Usuário salvo. Entregue a senha inicial de forma reservada; a troca será exigida no acesso.", "Usuários")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuários", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            senha = Nothing
            If Not IsDisposed Then Ocupado(False)
        End Try
    End Sub
    Private Async Sub Desbloquear(sender As Object, e As EventArgs) Handles btnDesbloquear.Click
        If _ocupado OrElse _id <= 0 Then
            MessageBox.Show("Selecione um usuário com o botão Carregar selecionado.", "Usuários")
            Return
        End If
        Dim id As Integer = _id
        Ocupado(True)
        Try
            Await Task.Run(Sub() Autenticacao.DesbloquearUsuario(id))
            AtualizarLista()
            MessageBox.Show("Bloqueio por tentativas removido. A situação Ativo não foi alterada.", "Usuários")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Usuários")
        Finally
            If Not IsDisposed Then Ocupado(False)
        End Try
    End Sub
    Private Sub Fechando(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _ocupado Then e.Cancel = True
    End Sub
End Class
