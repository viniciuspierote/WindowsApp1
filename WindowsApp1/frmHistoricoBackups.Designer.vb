<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoricoBackups
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
        Me.gradeHistorico = New System.Windows.Forms.DataGridView()
        Me.barra = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAtualizar = New System.Windows.Forms.Button()
        Me.btnPasta = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        Me.gradeHistorico.Name = "gradeHistorico"
        Me.gradeHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gradeHistorico.AllowUserToAddRows = False
        Me.gradeHistorico.AllowUserToDeleteRows = False
        Me.gradeHistorico.ReadOnly = True
        Me.gradeHistorico.RowHeadersVisible = False
        Me.gradeHistorico.AutoGenerateColumns = False
        Me.gradeHistorico.BackgroundColor = System.Drawing.Color.White
        Me.gradeHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gradeHistorico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gradeHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gradeHistorico.AutoGenerateColumns = True
        Me.gradeHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.barra.Name = "barra"
        Me.barra.Dock = System.Windows.Forms.DockStyle.Top
        Me.barra.Height = 42
        Me.btnAtualizar.Name = "btnAtualizar"
        Me.btnAtualizar.Text = "Atualizar"
        Me.btnAtualizar.Width = 110
        Me.btnPasta.Name = "btnPasta"
        Me.btnPasta.Text = "Abrir pasta dos backups"
        Me.btnPasta.Width = 190
        Me.Controls.Add(Me.gradeHistorico)
        Me.Controls.Add(Me.barra)
        Me.barra.Controls.Add(Me.btnAtualizar)
        Me.barra.Controls.Add(Me.btnPasta)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ClientSize = New System.Drawing.Size(1100, 520)
        Me.Name = "frmHistoricoBackups"
        Me.Text = "Sandinox — Histórico dos backups"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents gradeHistorico As System.Windows.Forms.DataGridView
    Friend WithEvents barra As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnAtualizar As System.Windows.Forms.Button
    Friend WithEvents btnPasta As System.Windows.Forms.Button
End Class
