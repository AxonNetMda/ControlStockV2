Imports capaAdministracion.capaDatos
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class CD_Empresa_FormadePago
    Public lista As List(Of empresa_formadepago) = New List(Of empresa_formadepago)
    Dim oconexion As New SqlConnection(conectar.Cadena)
    Public Function Listar(ByVal nIdformadepago As Integer, ByVal nIdEmpresa As Integer) As List(Of empresa_formadepago)
        Dim lista As List(Of empresa_formadepago) = New List(Of empresa_formadepago)()
        Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)

            Try
                Dim query As StringBuilder = New StringBuilder()
                query.AppendLine("SELECT dbo.empresa_formadepago.IdFormaPagoEmpresa, dbo.empresa_formadepago.IdFormaPago, dbo.FormaDePago.Nombre AS NombreFormaPago, ")
                query.AppendLine("dbo.empresa_formadepago.Nombre AS EmpresaNombreFormaPago, dbo.empresa_formadepago.AliasCuenta, ")
                query.AppendLine("dbo.empresa_formadepago.CBU,dbo.empresa_formadepago.Estado, dbo.empresa_formadepago.IdEmpresa ")
                query.AppendLine("FROM dbo.empresa_formadepago INNER JOIN dbo.FormaDePago ON dbo.empresa_formadepago.IdFormaPago = dbo.FormaDePago.IdFormaPago ")
                If nIdformadepago = 0 Then
                    query.AppendLine(" WHERE idEmpresa=" & nIdEmpresa & " AND Estado <>0 order by nombre ")
                Else
                    query.AppendLine("WHERE idEmpresa=" & nIdEmpresa & " AND idformadepago =" & nIdformadepago & " ND Estado <>0 order by nombre")
                End If

                Dim cmd As SqlCommand = New SqlCommand(query.ToString(), oconexion)
                cmd.CommandType = CommandType.Text
                oconexion.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    While dr.Read()
                        lista.Add(New empresa_formadepago() With {
                            .IdFormaPagoEmpresa = Convert.ToInt32(dr("idformapagoEmpresa")),
                            .IdFormaPago = New formadepago() With {.IdFormaPago = Convert.ToInt32(dr("idformapago")), .Nombre = dr("NombreFormaPago")},
                            .Nombre = UCase(dr("Nombre").ToString()),
                            .AliasCuenta = dr("AliasCuetna"),
                            .CBU = dr("CBU"),
                            .Estado = Convert.ToBoolean(dr("Estado"))
                        })

                    End While

                End Using

            Catch ex As Exception
                lista = New List(Of empresa_formadepago)()
            End Try
        End Using

        Return lista
    End Function

    Public Function Registrar(ByVal obj As empresa_formadepago, <Out> ByRef Mensaje As String) As Integer
        Dim idGenerado As Integer = 0
        Mensaje = String.Empty

        Try

            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_empresaformapago_add", oconexion)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.IdFormaPago)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.idEmpresa)
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.AliasCuenta)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.CBU)
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

    Public Function Editar(ByVal obj As empresa_formadepago, <Out> ByRef Mensaje As String) As Boolean
        Dim Respuesta As Boolean = False
        Mensaje = String.Empty

        Try

            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_empresaformapago_edit", oconexion)
                cmd.Parameters.AddWithValue("@IdFormaPagoEmpresa", obj.IdFormaPagoEmpresa)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.IdFormaPago)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.idEmpresa)
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.AliasCuenta)
                cmd.Parameters.AddWithValue("@IdFormaPago", obj.CBU)
                cmd.Parameters.AddWithValue("@Estado", True)
                cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output
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

    Public Function Eliminar(ByVal obj As empresa_formadepago, <Out> ByRef Mensaje As String) As Boolean
        Dim Respuesta As Boolean = False
        Mensaje = String.Empty

        Try

            Using oconexion As SqlConnection = New SqlConnection(conectar.Cadena)
                Dim cmd As SqlCommand = New SqlCommand("sp_empresaformapago_borrar", oconexion)
                cmd.Parameters.AddWithValue("@idformapagoempresa", obj.IdFormaPago)
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
