Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Module ConferenciaNormas

    ' Leitura e pre-conferencia apenas. Nao grava resultados nem libera perfis.
    Public Sub AdicionarBotao(formulario As Form, referencia As Control,
                             lerCadastro As Func(Of Dictionary(Of String, String)))
        If referencia.Parent.Controls.ContainsKey("btnConferenciaNormas") Then Return
        Dim botao As New Button With {
            .Name = "btnConferenciaNormas", .Text = "Verificar norma",
            .Location = New Point(referencia.Right + 8, referencia.Top),
            .Size = New Size(115, referencia.Height), .UseVisualStyleBackColor = True
        }
        AddHandler botao.Click,
            Sub(sender As Object, e As EventArgs)
                Try
                    Dim dados As Dictionary(Of String, String) = lerCadastro()
                    Dim id As Integer
                    If Not Integer.TryParse(dados("ID"), id) OrElse id <= 0 Then
                        MessageBox.Show("Salve ou procure um lote antes de verificar a norma.", "Conferencia")
                        Return
                    End If
                    Using janela As New frmConferenciaNormas(id, dados)
                        janela.ShowDialog(formulario)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Nao foi possivel abrir a conferencia." & vbCrLf & ex.Message,
                                    "Conferencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub
        referencia.Parent.Controls.Add(botao)
        botao.BringToFront()
    End Sub

    Friend Function Consultar(sql As String, Optional id As Integer = 0) As DataTable
        Dim tabela As New DataTable()
        Using cn As MySqlConnection = conexao.NovaConexao()
            Using cmd As New MySqlCommand(sql, cn)
                If sql.Contains("@id") Then cmd.Parameters.AddWithValue("@id", id)
                cn.Open()
                Using leitor As MySqlDataReader = cmd.ExecuteReader()
                    tabela.Load(leitor)
                End Using
            End Using
        End Using
        Return tabela
    End Function

    Friend Function Texto(linha As DataRow, coluna As String) As String
        Return If(linha.IsNull(coluna), String.Empty, Convert.ToString(linha(coluna), CultureInfo.InvariantCulture))
    End Function

    Friend Function Normalizar(texto As String) As String
        Dim sb As New StringBuilder()
        For Each caractere As Char In texto.Normalize(NormalizationForm.FormD)
            If CharUnicodeInfo.GetUnicodeCategory(caractere) <> UnicodeCategory.NonSpacingMark AndAlso
                Char.IsLetterOrDigit(caractere) Then sb.Append(Char.ToUpperInvariant(caractere))
        Next
        Return sb.ToString()
    End Function



    Friend Function DescreverFaixa(perfil As DataRow) As String
        If perfil.IsNull("dimensao_min") AndAlso perfil.IsNull("dimensao_max") Then Return "Nao definida; confirmar enquadramento."
        Dim cultura As CultureInfo = CultureInfo.GetCultureInfo("pt-BR")
        Dim minimo As String = If(perfil.IsNull("dimensao_min"), "sem minimo",
            Convert.ToDecimal(perfil("dimensao_min")).ToString("0.##########", cultura))
        Dim maximo As String = If(perfil.IsNull("dimensao_max"), "sem maximo",
            Convert.ToDecimal(perfil("dimensao_max")).ToString("0.##########", cultura))
        Return minimo & " a " & maximo & " " & Texto(perfil, "unidade_dimensao")
    End Function

    Friend Function DescreverLimite(regra As DataRow) As String
        If Texto(regra, "tipo_regra") = "DECLARACAO" Then Return Texto(regra, "declaracao_esperada")
        Dim partes As New List(Of String)()
        If Not regra.IsNull("minimo") Then
            Dim limite As String = Texto(regra, "limite_min_original")
            If limite = "" Then limite = Texto(regra, "minimo")
            partes.Add(If(Convert.ToBoolean(regra("minimo_inclusivo")), ">= ", "> ") & limite.Replace(".", ","))
        End If
        If Not regra.IsNull("maximo") Then
            Dim limite As String = Texto(regra, "limite_max_original")
            If limite = "" Then limite = Texto(regra, "maximo")
            partes.Add(If(Convert.ToBoolean(regra("maximo_inclusivo")), "<= ", "< ") & limite.Replace(".", ","))
        End If
        Return String.Join(" e ", partes.ToArray()) & " " & Texto(regra, "unidade")
    End Function

    ' Retorna somente uma comparacao numerica/declarativa; nao valida contexto.
    Public Function AvaliarResultado(informado As String, regra As DataRow) As String
        If String.IsNullOrWhiteSpace(informado) Then
            Return If(Convert.ToBoolean(regra("obrigatorio_informar")), "Informacao ausente", "Opcional nao informado")
        End If
        Dim tipo As String = Texto(regra, "tipo_regra")
        If tipo = "INFORMATIVO" Then Return "Informativo"
        If tipo = "DECLARACAO" Then
            Dim declaracao As String = Normalizar(informado)
            If Texto(regra, "declaracao_esperada") = "BALANCO" AndAlso
                (declaracao = "BAL" OrElse declaracao = "BALANCO" OrElse declaracao = "BALANCE" OrElse declaracao = "SALDO") Then Return "Informativo"
            Return "Declaracao a conferir"
        End If
        If tipo <> "INTERVALO" Then Return "Regra nao integrada"

        Dim correspondencia As Match = Regex.Match(informado.Trim(),
            "^(?<op><=|>=|<|>|=|≤|≥)?\s*(?<valor>[+-]?(?:\d+(?:[.,]\d*)?|[.,]\d+))$")
        If Not correspondencia.Success Then Return "Formato invalido / ND"
        Dim valor As Decimal
        If Not Decimal.TryParse(correspondencia.Groups("valor").Value.Replace(",", "."),
                                NumberStyles.AllowLeadingSign Or NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, valor) Then Return "Numero invalido"
        Dim inclusao As Boolean = regra.Table.Columns.Contains("propriedade_codigo") AndAlso Texto(regra, "propriedade_codigo").StartsWith("INCLUSAO_")
        Dim naoNegativo As Boolean = Texto(regra, "grupo") = "QUIMICA" OrElse Texto(regra, "grupo") = "MECANICA" OrElse inclusao
        If valor < 0D AndAlso naoNegativo Then Return "Valor negativo a conferir"
        Dim operador As String = correspondencia.Groups("op").Value.Replace("≤", "<=").Replace("≥", ">=")
        If operador = "" Then operador = "="
        Dim inferior As Nullable(Of Decimal) = valor
        Dim superior As Nullable(Of Decimal) = valor
        Dim incluiInferior As Boolean = True, incluiSuperior As Boolean = True
        Select Case operador
            Case "<", "<="
                If naoNegativo Then
                    inferior = 0D
                Else
                    inferior = Nothing
                End If
                incluiSuperior = operador = "<="
                If naoNegativo AndAlso valor = 0D AndAlso operador = "<" Then Return "Resultado inconsistente"
            Case ">", ">="
                superior = Nothing
                incluiInferior = operador = ">="
        End Select
        If regra.IsNull("minimo") AndAlso regra.IsNull("maximo") Then Return "Limites ausentes"
        Dim arredondamento As String = Texto(regra, "modo_arredondamento")
        If arredondamento <> "E29" AndAlso arredondamento <> "SEM_ARREDONDAMENTO" Then Return "Arredondamento pendente"
        Dim resultadoMin As Integer = 1, resultadoMax As Integer = 1
        If Not regra.IsNull("minimo") Then
            resultadoMin = ConferirLimite(inferior, superior, incluiInferior, incluiSuperior,
                Convert.ToDecimal(regra("minimo")), Convert.ToBoolean(regra("minimo_inclusivo")),
                True, arredondamento, regra("casas_decimais_min"))
        End If
        If Not regra.IsNull("maximo") Then
            resultadoMax = ConferirLimite(inferior, superior, incluiInferior, incluiSuperior,
                Convert.ToDecimal(regra("maximo")), Convert.ToBoolean(regra("maximo_inclusivo")),
                False, arredondamento, regra("casas_decimais_max"))
        End If
        If resultadoMin = -1 OrElse resultadoMax = -1 Then Return "Fora do limite"
        If resultadoMin = 1 AndAlso resultadoMax = 1 Then Return "Dentro (numerico)"
        Return "Indeterminado / conferir"
    End Function

    ' 1: todo o intervalo atende; -1: todo ele falha; 0: nao e conclusivo.
    Private Function ConferirLimite(inferior As Nullable(Of Decimal), superior As Nullable(Of Decimal),
                                    incluiInferior As Boolean, incluiSuperior As Boolean,
                                    limite As Decimal, inclusivo As Boolean, ehMinimo As Boolean,
                                    arredondamento As String, casasValor As Object) As Integer
        If arredondamento = "E29" Then
            If Convert.IsDBNull(casasValor) Then Return 0
            Dim casas As Integer = Convert.ToInt32(casasValor)
            If casas < 0 OrElse casas > 10 Then Return 0
            If inferior.HasValue Then inferior = Decimal.Round(inferior.Value, casas, MidpointRounding.ToEven)
            If superior.HasValue Then superior = Decimal.Round(superior.Value, casas, MidpointRounding.ToEven)
            ' Para resultados censurados, o arredondamento pode tornar o extremo
            ' atingivel. Usa envoltoria inclusiva: prefere pendencia a falsa aprovacao.
            incluiInferior = True
            incluiSuperior = True
        End If
        If ehMinimo Then
            If inferior.HasValue AndAlso (inferior.Value > limite OrElse
                (inferior.Value = limite AndAlso (inclusivo OrElse Not incluiInferior))) Then Return 1
            If superior.HasValue AndAlso (superior.Value < limite OrElse
                (superior.Value = limite AndAlso (Not inclusivo OrElse Not incluiSuperior))) Then Return -1
        Else
            If superior.HasValue AndAlso (superior.Value < limite OrElse
                (superior.Value = limite AndAlso (inclusivo OrElse Not incluiSuperior))) Then Return 1
            If inferior.HasValue AndAlso (inferior.Value > limite OrElse
                (inferior.Value = limite AndAlso (Not inclusivo OrElse Not incluiInferior))) Then Return -1
        End If
        Return 0
    End Function

End Module
