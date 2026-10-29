Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Windows.Forms
Public Class frmHistoricoBackups
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Carregar(sender As Object, e As EventArgs) Handles MyBase.Load, btnAtualizar.Click
        If DesignMode OrElse System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return
        Try
            gradeHistorico.DataSource = BackupBanco.LerHistorico()
            gradeHistorico.Columns("Início").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Histórico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AbrirPasta(sender As Object, e As EventArgs) Handles btnPasta.Click
        Try
            Directory.CreateDirectory(BackupBanco.PastaBackups)
            Process.Start("explorer.exe", """" & BackupBanco.PastaBackups & """")
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Backups", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
