Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Runtime.InteropServices
Imports capaAdministracion.capaDatos

Public Class CD_Empresa
    Public lista As List(Of empresa) = New List(Of empresa)
    Dim oconexion As New SqlConnection(conectar.Cadena)
    Public Function Listar() As List(Of empresa)
        Dim lista As List(Of empresa) = New List(Of empresa)()
        Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)

            Try
                Dim query As StringBuilder = New StringBuilder()
                query.AppendLine("Select empresa_datos.*, tiposderesponsables.Nombre as NombreResponsable, tiposdocumentos.Nombre AS NombreDocumento ")
                query.AppendLine("From empresa_datos ")
                query.AppendLine("INNER Join tiposderesponsables ON empresa_datos.idTipoResponsable = tiposderesponsables.idTipoResponsable ")
                query.AppendLine("INNER Join tiposdocumentos ON empresa_datos.idTipoDocumento = tiposdocumentos.idTipoDocumento")
                Dim cmd As SqlCommand = New SqlCommand(query.ToString(), oconexion)
                cmd.CommandType = CommandType.Text
                oconexion.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        lista.Add(New empresa() With {
                            .IdEmpresa = Convert.ToInt32(dr("idEmpresa")),
                            .RazonSocial = dr("RazonSocial").ToString(),
                            .NombreComercial = dr("NombreComercial").ToString(),
                            .Domicilio = dr("Direccion").ToString(),
                            .CodigoPostal = dr("CodigoPostal").ToString(),
                            .Localidad = dr("Localidad").ToString(),
                            .Provincia = dr("Provincia").ToString(),
                            .Telefono = dr("Telefono").ToString(),
                            .Email = dr("Email").ToString(),
                            .oTipoResponsable = New tipoderesponsable() With {.idTipoResponsable = Convert.ToInt32(dr("idTipoResponsable")), .Nombre = dr("NombreResponsable")},
                            .oTipoDocumento = New tipodedocumento() With {.IdTipoDocumento = Convert.ToInt32(dr("idTipoDocumento")), .Nombre = dr("NombreDocumento")},
                            .NumeroDocumento = dr("NumeroDocumento"),
                            .EsDemo = dr("EsDemo"),
                            .FechaInicioDemo = dr("FechaInicioDemo"),
                            .IdCategoria = New empresa_categoria() With {.idEmpresaCAtegoria = dr("idEmpresaCategoria")},
                            .FechaInicioActividades = Convert.ToDateTime(dr("InicioActividades").ToString()),
                            .IngresosBrutos = dr("IngresosBrutos"),
                            .Estado = dr("Estado")
                        })

                    End While

                End Using

            Catch ex As Exception
                lista = New List(Of empresa)()
            End Try
        End Using

        Return lista
    End Function
    Public Function Listarporcodigo(ByVal nEmpresa As Integer) As List(Of empresa)
        Dim lista As List(Of empresa) = New List(Of empresa)()
        Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)

            Try
                Dim query As StringBuilder = New StringBuilder()
                If nEmpresa = 0 Then
                    query.AppendLine("Select empresa_datos.*, tiposderesponsables.Nombre as NombreResponsable, tiposdocumentos.Nombre AS NombreDocumento ")
                    query.AppendLine("From empresa_datos ")
                    query.AppendLine("INNER Join tiposderesponsables ON empresa_datos.idTipoResponsable = tiposderesponsables.idTipoResponsable ")
                    query.AppendLine("INNER Join tiposdocumentos ON empresa_datos.idTipoDocumento = tiposdocumentos.idTipoDocumento")
                Else
                    query.AppendLine("Select empresa_datos.*, tiposderesponsables.Nombre as NombreResponsable, tiposdocumentos.Nombre AS NombreDocumento ")
                    query.AppendLine("From empresa_datos ")
                    query.AppendLine("INNER Join tiposderesponsables ON empresa_datos.idTipoResponsable = tiposderesponsables.idTipoResponsable ")
                    query.AppendLine("INNER Join tiposdocumentos ON empresa_datos.idTipoDocumento = tiposdocumentos.idTipoDocumento")
                    query.AppendLine("WHERE idempresa=" & nEmpresa)
                End If
                Dim cmd As SqlCommand = New SqlCommand(Query.ToString(), oconexion)
                cmd.CommandType = CommandType.Text
                oconexion.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        lista.Add(New empresa() With {
                            .IdEmpresa = Convert.ToInt32(dr("idEmpresa")),
                            .RazonSocial = dr("RazonSocial").ToString(),
                            .NombreComercial = dr("NombreComercial").ToString(),
                            .Domicilio = dr("Direccion").ToString(),
                            .CodigoPostal = dr("CodigoPostal").ToString(),
                            .Localidad = dr("Localidad").ToString(),
                            .Provincia = dr("Provincia").ToString(),
                            .Telefono = dr("Telefono").ToString(),
                            .Email = dr("Email").ToString(),
                            .oTipoResponsable = New tipoderesponsable() With {.idTipoResponsable = Convert.ToInt32(dr("idTipoResponsable")), .Nombre = dr("NombreResponsable")},
                            .oTipoDocumento = New tipodedocumento() With {.IdTipoDocumento = Convert.ToInt32(dr("idTipoDocumento")), .Nombre = dr("NombreDocumento")},
                            .NumeroDocumento = dr("NumeroDocumento"),
                            .EsDemo = dr("EsDemo"),
                            .FechaInicioDemo = dr("FechaInicioDemo"),
                            .IdCategoria = New empresa_categoria() With {.idEmpresaCAtegoria = dr("idEmpresaCategoria")},
                            .FechaInicioActividades = Convert.ToDateTime(dr("InicioActividades").ToString()),
                            .IngresosBrutos = dr("IngresosBrutos"),
                            .Estado = dr("Estado")
                        })

                    End While

                End Using

            Catch ex As Exception
                lista = New List(Of empresa)()
            End Try
        End Using

        Return lista
    End Function

    Public Function Registrar(ByVal obj As empresa, <Out> ByRef Mensaje As String) As Integer
        Dim idGenerado As Integer = 0
        Mensaje = String.Empty

        Try
            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_empresa_datos_add", oconexion)
                cmd.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial)
                cmd.Parameters.AddWithValue("@NombreComercial", obj.NombreComercial)
                cmd.Parameters.AddWithValue("@Direccion", obj.Domicilio)
                cmd.Parameters.AddWithValue("@CodigoPostal", obj.CodigoPostal)
                cmd.Parameters.AddWithValue("@Localidad", obj.Localidad)
                cmd.Parameters.AddWithValue("@Provincia", obj.Provincia)
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono)
                cmd.Parameters.AddWithValue("@Email", obj.Email)
                cmd.Parameters.AddWithValue("@idTipoResponsable", obj.oTipoResponsable.idTipoResponsable)
                cmd.Parameters.AddWithValue("@idTipoDocumento", obj.oTipoDocumento.IdTipoDocumento)
                cmd.Parameters.AddWithValue("@NumeroDocumento", obj.NumeroDocumento)
                cmd.Parameters.AddWithValue("@InicioActividades", Format(obj.FechaInicioActividades, "yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@IngresosBrutos", obj.IngresosBrutos)
                cmd.Parameters.AddWithValue("@Estado", obj.Estado)
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

    Public Function Editar(ByVal obj As empresa, <Out> ByRef Mensaje As String) As Boolean
        Dim Respuesta As Boolean = False
        Mensaje = String.Empty

        Try

            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_empresa_datos_edit", oconexion)
                cmd.Parameters.AddWithValue("@idEmpresa", obj.IdEmpresa)
                cmd.Parameters.AddWithValue("@RazonSocial", obj.RazonSocial)
                cmd.Parameters.AddWithValue("@NombreComercial", obj.NombreComercial)
                cmd.Parameters.AddWithValue("@Direccion", obj.Domicilio)
                cmd.Parameters.AddWithValue("@CodigoPostal", obj.CodigoPostal)
                cmd.Parameters.AddWithValue("@Localidad", obj.Localidad)
                cmd.Parameters.AddWithValue("@Provincia", obj.Provincia)
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono)
                cmd.Parameters.AddWithValue("@Email", obj.Email)
                cmd.Parameters.AddWithValue("@idTipoResponsable", obj.oTipoResponsable.idTipoResponsable)
                cmd.Parameters.AddWithValue("@idTipoDocumento", obj.oTipoDocumento.IdTipoDocumento)
                cmd.Parameters.AddWithValue("@NumeroDocumento", obj.NumeroDocumento)
                cmd.Parameters.AddWithValue("@InicioActividades", Format(obj.FechaInicioActividades, "yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@IngresosBrutos", obj.IngresosBrutos)
                cmd.Parameters.AddWithValue("@Estado", obj.Estado)
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
                cmd.CommandType = CommandType.StoredProcedure
                oconexion.Open()
                cmd.ExecuteNonQuery()
                Mensaje = cmd.Parameters("@Mensaje").Value.ToString()
            End Using

        Catch ex As Exception
            Respuesta = False
            Mensaje = ex.Message
        End Try

        Return Respuesta
    End Function

    Public Function Eliminar(ByVal obj As empresa, <Out> ByRef Mensaje As String) As Boolean
        Dim Respuesta As Boolean = False
        Mensaje = String.Empty
        Try
            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_empresa_datos_borrar", oconexion)
                cmd.Parameters.AddWithValue("@idEmpresa", obj.IdEmpresa)
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