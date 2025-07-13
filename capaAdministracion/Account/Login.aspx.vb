Imports System.Data.SqlClient
Imports System.Web.Security
Imports capaAdministracion.capaDatos
Public Class Login
	Inherits System.Web.UI.Page




	Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
		Dim usuario As String = txtUsuario.Text.Trim()
		Dim clave As String = txtClave.Text.Trim()

		If String.IsNullOrEmpty(usuario) OrElse String.IsNullOrEmpty(clave) Then
			lblMensaje.Text = "Debe completar usuario y contraseña."
			Return
		End If

		Try
			Using conn As New SqlConnection(conectar.Cadena)
				Dim cmd As New SqlCommand("SELECT dbo.usuarios.IdUsuario, dbo.usuarios.Nombre,dbo.usuarios.idRol, dbo.usuarios.Movil, dbo.usuarios.Email, dbo.usuarios.Clave,
											dbo.usuarios.Token, dbo.usuarios.CuentaActiva, dbo.usuarios.Estado, dbo.usuarios.IdEmpresa, dbo.empresa.NombreComercial as NombreEmpresa,
											dbo.empresa.EsDemo, dbo.empresa.FechaInicioDemo, dbo.empresa.CantidadDiasDemo FROM dbo.usuarios
											INNER JOIN dbo.empresa ON dbo.usuarios.IdEmpresa = dbo.empresa.IdEmpresa WHERE dbo.usuarios.Email = @Email AND CuentaActiva = 1", conn)
				cmd.Parameters.AddWithValue("@Email", usuario)
				conn.Open()
				Using reader As SqlDataReader = cmd.ExecuteReader()
					If reader.Read() Then
						Dim fechaInicio As DateTime
						If Not Convert.IsDBNull(reader("FechaInicioDemo")) AndAlso Not String.IsNullOrEmpty(reader("FechaInicioDemo").ToString()) Then
							fechaInicio = Convert.ToDateTime(reader("FechaInicioDemo"))
						Else
							' Opcional: asignar una fecha por defecto o manejar el caso
							fechaInicio = Date.MinValue
						End If
						'im fechaInicio As DateTime = Convert.ToDateTime(reader("FechaInicioDemo"))
						Dim fechaHoy As DateTime = DateTime.Today
						Dim EsDemo As Integer = 0
						Dim diferenciaDias As Integer = (fechaHoy - fechaInicio).Days
						Dim claveEncriptadaBD As String = reader("Clave").ToString()
						If VerificarClave(clave, claveEncriptadaBD) Then
							' Autenticación válida: guardamos datos en sesión
							Session.Add("IdSucursal", 1)
							Session.Add("IdUsuario", reader("IdUsuario"))
							Session("Nombre") = reader("Nombre").ToString()
							Session("IdRol") = reader("IdRol")
							Session("IdEmpresa") = reader("IdEmpresa")
							Session("NombreEmpresa") = reader("NombreEmpresa")
							If reader("EsDemo") Then
								If diferenciaDias > reader("CantidadDiasDemo") Then
									EsDemo = 0
								Else
									EsDemo = 1
								End If
								Session.Add("EsDemo", reader("EsDemo"))
								Session.Add("FechaInicioDemo", reader("FechaInicioDemo"))
								Session.Add("CantidadDiasDemo", reader("CantidadDiasDemo"))
							Else

							End If

							Response.Redirect("../Default.aspx?EsDemo=" & EsDemo & "&DiasDemo=" & reader("CantidadDiasDemo") & "&DiferenciaDias=" & diferenciaDias)
						Else
							lblMensaje.Text = "Contraseña incorrecta."
						End If
					Else
						lblMensaje.Text = "Usuario no encontrado o cuenta inactiva."
					End If
				End Using
			End Using
		Catch ex As Exception
			lblMensaje.Text = "Error al iniciar sesión: " & ex.Message
		End Try
	End Sub

	Private Function VerificarClave(claveIngresada As String, claveEncriptada As String) As Boolean
		' Comparación de hash SHA256
		Dim sha As New Security.Cryptography.SHA256Managed()
		Dim bytes = System.Text.Encoding.UTF8.GetBytes(claveIngresada)
		Dim hash = sha.ComputeHash(bytes)
		Dim claveIngresadaHash = BitConverter.ToString(hash).Replace("-", "")
		Return claveIngresadaHash.Equals(claveEncriptada, StringComparison.OrdinalIgnoreCase)
	End Function

    Protected Sub lnkOlvideContraseña_Click(sender As Object, e As EventArgs)
		Response.Redirect("~/Account/nuevaclave.aspx")
	End Sub
End Class

