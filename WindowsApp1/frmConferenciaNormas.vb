Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Public Class frmConferenciaNormas

    Private ReadOnly _dados As Dictionary(Of String, String)
    Private ReadOnly _quimica As DataTable
    Private ReadOnly _perfis As DataTable
    Private _pronto As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(id As Integer, dados As Dictionary(Of String, String))
        Me.New()
        _dados = dados
        Dim cadastro As DataTable = ConferenciaNormas.Consultar(
            "SELECT WORK_ORDER_1 FROM cadastrocertificados WHERE WORK_ORDER = @id", id)
        If cadastro.Rows.Count <> 1 Then Throw New InvalidOperationException("Cadastro nao encontrado.")
        If Not String.Equals(ConferenciaNormas.Texto(cadastro.Rows(0), "WORK_ORDER_1").Trim(),
                             dados("LOTE").Trim(), StringComparison.OrdinalIgnoreCase) Then
            Throw New InvalidOperationException("O lote foi alterado na tela. Salve a alteracao antes de conferir a quimica gravada.")
        End If
        _quimica = ConferenciaNormas.Consultar("SELECT SEQUENCIA, TIPO, VALOR FROM cadastrocompquimica WHERE WORK_ORDER = @id ORDER BY SEQUENCIA", id)
        _perfis = ConferenciaNormas.Consultar(
            "SELECT p.*, CONCAT(n.entidade, ' ', n.codigo, '-', n.edicao, ' | ', p.descricao, ' | ', p.status) AS rotulo " &
            "FROM cert_perfis_norma p JOIN cert_normas n ON n.id = p.norma_id " &
            "WHERE p.status <> 'INATIVO' ORDER BY n.codigo, p.codigo, p.revisao")

        For Each grade As DataGridView In New DataGridView() {_quimicaGrid, _mecanicaGrid}
            For Each coluna As DataGridViewColumn In grade.Columns
                coluna.Name = coluna.DataPropertyName
            Next
        Next
        Text = "Sandinox - Conferencia de norma - lote " & dados("LOTE")
        _seletor.DisplayMember = "rotulo"
        _seletor.ValueMember = "id"
        _seletor.DataSource = _perfis
        _seletor.SelectedIndex = -1
        AddHandler _seletor.SelectedIndexChanged, AddressOf PerfilAlterado
        _pronto = True
        If _perfis.Rows.Count = 0 Then _resumo.Text = "Nenhum perfil encontrado. Execute a etapa 2 no mesmo banco configurado no sistema."
    End Sub



    Private Sub PerfilAlterado(sender As Object, e As EventArgs)
        If Not _pronto OrElse _seletor.SelectedIndex < 0 Then Return
        Try
            Dim perfil As DataRow = DirectCast(_seletor.SelectedItem, DataRowView).Row
            Dim regras As DataTable = ConferenciaNormas.Consultar(
                "SELECT r.*, d.codigo AS propriedade_codigo, d.descricao AS propriedade_nome, d.grupo " &
                "FROM cert_requisitos r JOIN cert_propriedades d ON d.id = r.propriedade_id " &
                "WHERE r.perfil_id = @id ORDER BY d.grupo, r.ordem_exibicao, r.id", Convert.ToInt32(perfil("id")))
            _quimicaGrid.Rows.Clear()
            _mecanicaGrid.Rows.Clear()
            _detalhes.Text = "Cadastro: " & _dados("ESPECIFICACAO") & " | Dimensao: " & _dados("DIMENSAO") &
                " | Condicao informada: " & _dados("CONDICAO") & vbCrLf &
                "Perfil: " & ConferenciaNormas.Texto(perfil, "material_grau_tipo") & " | Forma: " & ConferenciaNormas.Texto(perfil, "forma_produto") &
                " | Condicao: " & ConferenciaNormas.Texto(perfil, "condicao_fornecimento") & " | Unidades: " & ConferenciaNormas.Texto(perfil, "sistema_unidades") & vbCrLf &
                "Faixa dimensional do perfil: " & ConferenciaNormas.DescreverFaixa(perfil) & vbCrLf & ConferenciaNormas.Texto(perfil, "condicoes_adicionais") & vbCrLf &
                "Enquadramento documental e dimensional NAO confirmado automaticamente nesta etapa."

            Dim utilizados As New HashSet(Of DataRow)()
            Dim dentro As Integer = 0, fora As Integer = 0, pendentes As Integer = 0
            For Each regra As DataRow In regras.Rows
                Dim codigo As String = ConferenciaNormas.Texto(regra, "propriedade_codigo")
                If ConferenciaNormas.Texto(regra, "grupo") = "QUIMICA" Then
                    Dim encontrados As New List(Of DataRow)()
                    For Each origem As DataRow In _quimica.Rows
                        If CorrespondeElemento(ConferenciaNormas.Texto(origem, "TIPO"), regra) Then encontrados.Add(origem)
                    Next
                    If encontrados.Count = 0 Then
                        IncluirLinha(_quimicaGrid, regra, "Sem registro", "", dentro, fora, pendentes)
                    Else
                        For Each origem As DataRow In encontrados
                            utilizados.Add(origem)
                            IncluirLinha(_quimicaGrid, regra, "Seq. " & ConferenciaNormas.Texto(origem, "SEQUENCIA"),
                                         ConferenciaNormas.Texto(origem, "VALOR"), dentro, fora, pendentes)
                        Next
                    End If
                ElseIf ConferenciaNormas.Texto(regra, "grupo") = "MECANICA" Then
                    Dim valor As String = If(_dados.ContainsKey(codigo), _dados(codigo), "")
                    IncluirLinha(_mecanicaGrid, regra, "Tela atual", valor, dentro, fora, pendentes)
                Else
                    IncluirLinha(_mecanicaGrid, regra, "Nao integrado", "", dentro, fora, pendentes)
                End If
            Next
            Dim extras As Integer = _quimica.Rows.Count - utilizados.Count
            _resumo.Text = "Comparacoes: " & dentro.ToString() & " dentro; " & fora.ToString() & " fora; " &
                pendentes.ToString() & " pendentes/invalidas. Quimica adicional sem regra neste perfil: " & extras.ToString() & "." & vbCrLf &
                "Leitura apenas. Para corrigir, feche esta janela e altere o cadastro. As etapas/origens das amostras antigas nao foram presumidas."
            If regras.Rows.Count = 0 Then _resumo.Text = "Perfil sem requisitos cadastrados: nenhuma conclusao disponivel."
        Catch ex As Exception
            _quimicaGrid.Rows.Clear()
            _mecanicaGrid.Rows.Clear()
            _resumo.Text = "Erro ao carregar requisitos. Nenhuma conclusao disponivel."
            MessageBox.Show(ex.Message, "Conferencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CorrespondeElemento(nome As String, regra As DataRow) As Boolean
        Dim informado As String = ConferenciaNormas.Normalizar(nome)
        Dim codigo As String = ConferenciaNormas.Normalizar(ConferenciaNormas.Texto(regra, "propriedade_codigo"))
        Dim descricao As String = ConferenciaNormas.Normalizar(ConferenciaNormas.Texto(regra, "propriedade_nome"))
        Return informado = codigo OrElse informado = descricao OrElse
               informado = codigo & descricao OrElse informado = descricao & codigo
    End Function

    Private Sub IncluirLinha(grade As DataGridView, regra As DataRow, origem As String, valor As String,
                             ByRef dentro As Integer, ByRef fora As Integer, ByRef pendentes As Integer)
        Dim situacao As String = ConferenciaNormas.AvaliarResultado(valor, regra)
        Dim notas As String = ConferenciaNormas.Texto(regra, "referencia_normativa") & vbCrLf & ConferenciaNormas.Texto(regra, "observacoes")
        If ConferenciaNormas.Texto(regra, "etapa_amostra") <> "QUALQUER" Then
            notas &= vbCrLf & "Confirmar etapa: " & ConferenciaNormas.Texto(regra, "etapa_amostra") & "."
        End If
        If ConferenciaNormas.Texto(regra, "base_alongamento") <> "" Then notas &= vbCrLf & ConferenciaNormas.Texto(regra, "base_alongamento")
        Dim indice As Integer = grade.Rows.Add(ConferenciaNormas.Texto(regra, "propriedade_nome"), origem, valor,
                                               ConferenciaNormas.DescreverLimite(regra), situacao, notas)
        Dim cor As Color = Color.DimGray
        If situacao = "Dentro (numerico)" Then
            dentro += 1
            cor = Color.DarkGreen
        ElseIf situacao = "Fora do limite" Then
            fora += 1
            cor = Color.DarkRed
        ElseIf situacao <> "Informativo" AndAlso situacao <> "Opcional nao informado" Then
            pendentes += 1
            cor = Color.DarkOrange
        End If
        grade.Rows(indice).Cells("situacao").Style.ForeColor = cor
    End Sub
End Class
