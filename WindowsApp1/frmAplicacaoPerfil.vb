Imports System.Collections.Generic
Imports System.Windows.Forms
Public Class frmAplicacaoPerfil
    Public ReadOnly campos As New Dictionary(Of String, Control)()
    Public Sub New()
        InitializeComponent()
        campos.Add("dimensao_referencia", campo_dimensao_referencia)
        campos.Add("dimensao_min", campo_dimensao_min)
        campos.Add("dimensao_max", campo_dimensao_max)
        campos.Add("dimensao_min_inclusiva", campo_dimensao_min_inclusiva)
        campos.Add("dimensao_max_inclusiva", campo_dimensao_max_inclusiva)
        campos.Add("unidade_dimensao", campo_unidade_dimensao)
        campos.Add("condicoes_adicionais", campo_condicoes_adicionais)
    End Sub
    Public Function LerValores() As Dictionary(Of String, String)
        Dim valores As New Dictionary(Of String, String)()
        For Each par As KeyValuePair(Of String, Control) In campos
            valores.Add(par.Key, par.Value.Text)
        Next
        Return valores
    End Function
End Class
