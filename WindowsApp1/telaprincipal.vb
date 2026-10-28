Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks

Public Class frm_principal
    Private tarefaBackup As Task(Of String)

    Public Sub New()

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_emitircertificado.Show()
    End Sub

    Private Sub frm_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub btnformularioteste_Click(sender As Object, e As EventArgs)
        Form7.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmcadastro.Show()


    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked


    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub btnteste_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnespeci_Click(sender As Object, e As EventArgs) Handles btnespeci.Click
        frmespecificacaodocliente.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmcadastrarcliente.Show()
    End Sub

    Private Sub btnConfiguracoes_Click(sender As Object, e As EventArgs) Handles btnConfiguracoes.Click
        Using tela As New frmConfiguracoes()
            tela.ShowDialog(Me)
        End Using
    End Sub
    Private Async Sub frm_principal_Shown(
    sender As Object,
    e As EventArgs) Handles MyBase.Shown

        Await RodarBackupAsync(False)

    End Sub

    Private Async Function RodarBackupAsync(adicional As Boolean) As Task

        If tarefaBackup IsNot Nothing AndAlso Not tarefaBackup.IsCompleted Then
            If adicional Then
                MessageBox.Show(
                "Já existe um backup em andamento. Aguarde a conclusão.",
                "Backups",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            End If
            Return
        End If

        btnBackupAdicional.Enabled = False

        Try
            tarefaBackup = Task.Run(Function() BackupBanco.ExecutarBackup(adicional))
            Dim mensagem As String = Await tarefaBackup

            ' A execução automática bem-sucedida não abre mensagem.
            If adicional Then
                MessageBox.Show(
                mensagem,
                "Backups",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(
            "O backup não foi confirmado." & vbCrLf & ex.Message,
            "Backups",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
        Finally
            btnBackupAdicional.Enabled = True
        End Try

    End Function

    Private Async Sub btnBackupAdicional_Click(
    sender As Object,
    e As EventArgs) Handles btnBackupAdicional.Click

        Await RodarBackupAsync(True)

    End Sub

    Private Sub btnHistoricoBackups_Click(
    sender As Object,
    e As EventArgs) Handles btnHistoricoBackups.Click

        BackupBanco.MostrarHistorico(Me)

    End Sub

    Private Sub frm_principal_FormClosing(
    sender As Object,
    e As FormClosingEventArgs) Handles MyBase.FormClosing

        If tarefaBackup IsNot Nothing AndAlso Not tarefaBackup.IsCompleted Then
            e.Cancel = True

            MessageBox.Show(
            "O backup está em andamento. Aguarde a conclusão para fechar o sistema.",
            "Backups",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
        End If

    End Sub

End Class
