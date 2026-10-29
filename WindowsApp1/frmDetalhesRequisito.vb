Imports System.Collections.Generic
Imports System.Windows.Forms
Public Class frmDetalhesRequisito
    Public ReadOnly campos As New Dictionary(Of String, Control)()
    Public Sub New()
        InitializeComponent()
        campos.Add("tipo_analise", campo_tipo_analise)
        campos.Add("etapa_amostra", campo_etapa_amostra)
        campos.Add("direcao_ensaio", campo_direcao_ensaio)
        campos.Add("condicao_ensaio", campo_condicao_ensaio)
        campos.Add("base_alongamento", campo_base_alongamento)
        campos.Add("modo_arredondamento", campo_modo_arredondamento)
        campos.Add("declaracao_esperada", campo_declaracao_esperada)
        campos.Add("formula_codigo", campo_formula_codigo)
        campos.Add("observacoes", campo_observacoes)
    End Sub
    Public Function LerValores() As Dictionary(Of String, String)
        Dim valores As New Dictionary(Of String, String)()
        For Each par As KeyValuePair(Of String, Control) In campos
            valores.Add(par.Key, par.Value.Text)
        Next
        Return valores
    End Function
End Class
