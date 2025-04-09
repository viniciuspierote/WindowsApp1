Imports MySql.Data.MySqlClient

Module conexao
    Public con As New MySqlConnection("server=localhost;userid=root;password=;database=certificado;")
    Sub abrir()
        If con.State = 0 Then
            con.Open()
            MsgBox("Conectado com sucesso")
        End If
    End Sub

    Sub fechar()
        If con.State = 1 Then
            con.Close()
            MsgBox("Conexão Fechada!")
        End If
    End Sub

End Module
