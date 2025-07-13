Imports System.Data.SqlClient
Imports System.Text
Imports System.Runtime.InteropServices
Imports capaAdministracion.capaDatos
Public Class CD_ProductoFotos
    Public lista As List(Of productofotos) = New List(Of productofotos)
    Dim oconexion As New SqlConnection(conectar.Cadena)
    Public Function Listar(ByVal nIdproductofotos As Integer) As List(Of productofotos)
        Dim lista As List(Of productofotos) = New List(Of productofotos)()
        Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)

            Try
                Dim query As StringBuilder = New StringBuilder()
                query.AppendLine("SELECT dbo.producto_foto.idProductoFoto, dbo.producto_foto.idEmpresa, dbo.producto_foto.idproducto, ")
                query.AppendLine("dbo.producto.Nombre as NombreProducto, dbo.producto_foto.rutacarpeta, dbo.producto_foto.nombrefoto, dbo.producto_foto.Estado, ")
                query.AppendLine("dbo.empresa.NombreComercial As NombreEmpresa FROM dbo.producto_foto ")
                query.AppendLine("INNER JOIN dbo.producto ON dbo.producto_foto.idproducto = dbo.producto.idProducto ")
                query.AppendLine("INNER JOIN dbo.empresa ON dbo.producto_foto.idEmpresa = dbo.empresa.IdEmpresa")

                If nIdproductofotos = 0 Then
                    query.AppendLine(" WHERE producto_foto.Estado <>0 order by formadepago.nombre ")
                Else
                    query.AppendLine("WHERE producto_foto.idProductoFoto =" & nIdproductofotos & " and producto_foto.Estado<>0 order by IdEmpresa")
                End If

                Dim cmd As SqlCommand = New SqlCommand(query.ToString(), oconexion)
                cmd.CommandType = CommandType.Text
                oconexion.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        lista.Add(New productofotos() With {
                            .IdProductoFoto = Convert.ToInt32(dr("IdProductoFoto")),
                            .Idproducto = Convert.ToInt32(dr("IdProducto")),
                            .oEmpresa = New empresa() With {.IdEmpresa = dr("idEmpresa"), .NombreComercial = dr("NombreEmpresa")},
                            .rutacarpeta = dr("rutacarpeta").ToString(),
                            .nombrefoto = dr("nombrefoto").ToString(),
                            .Estado = Convert.ToBoolean(dr("Estado"))
                        })

                    End While

                End Using

            Catch ex As Exception
                lista = New List(Of productofotos)()
            End Try
        End Using

        Return lista
    End Function

    Public Function GuardarFoto(ByVal obj As productofotos, <Out> ByRef Mensaje As String) As Integer
        Dim idGenerado As Integer = 0
        Mensaje = String.Empty

        Try
            '@idProducto int,
            '@idEmpresa int,
            '@RutaFoto varchar(200),
            '@NombreFoto varchar(200),
            '@Estado bit,
            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_producto_GuardarFoto", oconexion)
                cmd.Parameters.AddWithValue("@idProductoFoto", obj.IdProductoFoto)
                cmd.Parameters.AddWithValue("@idProducto", obj.Idproducto)
                cmd.Parameters.AddWithValue("@idEmpresa", obj.oEmpresa.IdEmpresa)
                cmd.Parameters.AddWithValue("@RutaFoto", obj.rutacarpeta)
                cmd.Parameters.AddWithValue("@NombreFoto", obj.nombrefoto)
                cmd.Parameters.AddWithValue("@Estado", True)
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
                cmd.CommandType = CommandType.StoredProcedure
                oconexion.Open()
                cmd.ExecuteNonQuery()
                idGenerado = Convert.ToInt32(cmd.Parameters("@Resultado").Value)
                Mensaje = cmd.Parameters("@Mensaje").Value.ToString()
            End Using

        Catch ex As Exception
            idGenerado = 0
            Mensaje = ex.Message
        End Try

        Return idGenerado
    End Function


    Public Function EliminarFoto(ByVal obj As productofotos, <Out> ByRef Mensaje As String) As Boolean
        Dim Respuesta As Boolean = False
        Mensaje = String.Empty

        Try

            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_productofoto_eliminar", oconexion)
                cmd.Parameters.AddWithValue("@IdProductoFoto", obj.IdProductoFoto)
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
                cmd.CommandType = CommandType.StoredProcedure
                oconexion.Open()
                cmd.ExecuteNonQuery()
                Respuesta = Convert.ToBoolean(cmd.Parameters("@Resultado").Value)
                Mensaje = cmd.Parameters("@Mensaje").Value.ToString()
            End Using

        Catch ex As Exception
            Respuesta = False
            Mensaje = ex.Message
        End Try

        Return Respuesta

    End Function

End Class
