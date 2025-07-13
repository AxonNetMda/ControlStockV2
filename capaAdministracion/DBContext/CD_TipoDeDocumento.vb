Imports capaAdministracion.capaDatos
Imports System.Data
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports capaAdministracion

Public Class CD_TipoDeDocumento
    Public lista As List(Of tipodedocumento) = New List(Of tipodedocumento)
    Dim oconexion As New SqlConnection(conectar.Cadena)
    Public Function Listar() As List(Of tipodedocumento)
        Dim lista As List(Of tipodedocumento) = New List(Of tipodedocumento)()
        Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)

            Try
                Dim query As String
                query = "select * FROM tipodedocumento ORDER BY Nombre"
                Dim cmd As SqlCommand = New SqlCommand(query, oconexion)
                cmd.CommandType = CommandType.Text
                oconexion.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        lista.Add(New tipodedocumento() With {
                            .IdDocumento = Convert.ToInt32(dr("idDocumento")),
                            .IdTipoDocumento = Convert.ToInt32(dr("idTipoDocumento")),
                            .Nombre = dr("Nombre").ToString(),
                            .Estado = Convert.ToBoolean(dr("Estado"))
                        })
                    End While

                End Using

            Catch ex As Exception
                lista = New List(Of tipodedocumento)()
            End Try
        End Using

        Return lista
    End Function


End Class
