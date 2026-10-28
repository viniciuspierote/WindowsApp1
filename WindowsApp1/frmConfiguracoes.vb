Imports MySql.Data.MySqlClient

Public Class frmConfiguracoes

    Private Sub frmConfiguracoes_Load(
        sender As Object,
        e As EventArgs) Handles MyBase.Load

        txtServidor.Text = My.Settings.MysqlServidor
        nudPorta.Value = My.Settings.MysqlPorta
        txtBanco.Text = My.Settings.MysqlBanco
        txtUsuario.Text = My.Settings.MysqlUsuario

        Try
            txtSenha.Text = conexao.RecuperarSenha()

        Catch ex As Exception
            txtSenha.Clear()

            MessageBox.Show(
                "Não foi possível recuperar a senha salva." &
                vbCrLf & "Digite a senha novamente.",
                "Configurações",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub TestarConexaoDaTela()

        Dim stringConexao = conexao.MontarStringConexao(
            txtServidor.Text,
            CUInt(nudPorta.Value),
            txtBanco.Text,
            txtUsuario.Text,
            txtSenha.Text)

        Using cn As New MySqlConnection(stringConexao)
            cn.Open()
        End Using

    End Sub

    Private Sub btnTestar_Click(
        sender As Object,
        e As EventArgs) Handles btnTestar.Click

        Try
            TestarConexaoDaTela()

            MessageBox.Show(
                "Conexão realizada com sucesso!",
                "Teste de conexão",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(
                "Não foi possível conectar ao MySQL." &
                vbCrLf & ex.Message,
                "Teste de conexão",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSalvar_Click(
        sender As Object,
        e As EventArgs) Handles btnSalvar.Click

        Try
            ' Confere a conexão antes de salvar.
            TestarConexaoDaTela()

            Dim senhaProtegida =
                conexao.ProtegerSenha(txtSenha.Text)

            My.Settings.MysqlServidor = txtServidor.Text.Trim()
            My.Settings.MysqlPorta = CInt(nudPorta.Value)
            My.Settings.MysqlBanco = txtBanco.Text.Trim()
            My.Settings.MysqlUsuario = txtUsuario.Text.Trim()
            My.Settings.MysqlSenhaProtegida = senhaProtegida

            My.Settings.Save()

            MessageBox.Show(
                "Configurações salvas com sucesso!",
                "Configurações",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(
                "Não foi possível concluir o salvamento." &
                vbCrLf & vbCrLf & ex.ToString(),
                "Detalhes do erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs) Handles btnCancelar.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

End Class