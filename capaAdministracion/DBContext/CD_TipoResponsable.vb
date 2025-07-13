Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Runtime.InteropServices
Imports capaAdministracion.capaDatos

Public Class CD_TipoResponsable
    Public Function Listar() As List(Of tipoderesponsable)
        Dim lista As List(Of tipoderesponsable) = New List(Of tipoderesponsable)

        Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)

            Try
                Dim query As String = "select * from tipoderesponsable where Estado<>0 order by Nombre"
                Dim cmd As SqlCommand = New SqlCommand(query, oconexion)
                cmd.CommandType = CommandType.Text
                oconexion.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        lista.Add(New tipoderesponsable() With {
                            .idTipoResponsable = Convert.ToInt32(dr("idTiporesponsable")),
                            .Nombre = dr("Nombre").ToString(),
                            .Estado = dr("Estado").ToString()
                        })
                    End While
                End Using

            Catch ex As Exception
                lista = New List(Of tipoderesponsable)()
            End Try
        End Using

        Return lista
    End Function
End Class
