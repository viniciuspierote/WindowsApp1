Imports System.Collections.Generic
Imports System.Windows.Forms
Public Class frmPropriedadeNorma
    Public ReadOnly campos As New Dictionary(Of String, Control)()
    Public Sub New()
        InitializeComponent()
        campos.Add("codigo", campo_codigo)
        campos.Add("descricao", campo_descricao)
        campos.Add("grupo", campo_grupo)
        campos.Add("unidade_sugerida", campo_unidade_sugerida)
    End Sub
    Public Function LerValores() As Dictionary(Of String, String)
        Dim valores As New Dictionary(Of String, String)()
        For Each par As KeyValuePair(Of String, Control) In campos
            valores.Add(par.Key, par.Value.Text)
        Next
        Return valores
    End Function
End Class
