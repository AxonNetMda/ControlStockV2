Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos
Imports System.Threading.Tasks
Public Class Registrarse
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub
	Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
		Try
			Dim nombre As String = txtNombre.Text.Trim()
			Dim email As String = txtEmail.Text.Trim()
			Dim movil As String = txtMovil.Text.Trim()
			Dim clave As String = txtClave.Text.Trim()
			Dim claveEncriptada As String = EncriptarClave(clave)
			Dim idRol As Integer = 5 ' Invitado por defecto
			Dim token As String = GenerarToken()
			Using conn As New SqlConnection(conectar.Cadena)
				conn.Open()

				' Verificar si ya existe el email
				Dim existeCmd As New SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Email = @Email", conn)
				existeCmd.Parameters.AddWithValue("@Email", email)
				Dim existe As Integer = Convert.ToInt32(existeCmd.ExecuteScalar())

				If existe > 0 Then
					' Si existe, actualiza clave y token, reinicia estado
					Dim updateCmd As New SqlCommand("UPDATE Usuarios SET Clave = @Clave, Token = @Token, CuentaActiva = 0, Estado = 1 WHERE Email = @Email", conn)
					updateCmd.Parameters.AddWithValue("@Clave", claveEncriptada)
					updateCmd.Parameters.AddWithValue("@Token", token)
					updateCmd.Parameters.AddWithValue("@Email", email)
					updateCmd.ExecuteNonQuery()
				Else
					' Si no existe, inserta nuevo registro
					Dim insertCmd As New SqlCommand("INSERT INTO Usuarios (Nombre, Email, Movil, IdRol, Token, CuentaActiva, Estado, Clave) VALUES (@Nombre, @Email, @Movil, @IdRol, @Token, 0, 1, @Clave)", conn)
					insertCmd.Parameters.AddWithValue("@Nombre", nombre)
					insertCmd.Parameters.AddWithValue("@Email", email)
					insertCmd.Parameters.AddWithValue("@Movil", movil)
					insertCmd.Parameters.AddWithValue("@IdRol", idRol)
					insertCmd.Parameters.AddWithValue("@Token", token)
					insertCmd.Parameters.AddWithValue("@Clave", claveEncriptada)
					insertCmd.ExecuteNonQuery()
				End If
			End Using

			EnviarCorreoValidacion(email, token)
			ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroExitoso", "mostrarModal('Registro exitoso', 'Revisa tu correo electrónico para activar tu cuenta.');", True)
		Catch ex As Exception
			ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroError", "mostrarModal('Error en el registro', '" & ex.Message.Replace("'", "\'") & "');", True)
		End Try
	End Sub
	Private Function EncriptarClave(clave As String) As String
		Using sha256 As SHA256 = SHA256.Create()
			Dim bytes As Byte() = Encoding.UTF8.GetBytes(clave)
			Dim hash As Byte() = sha256.ComputeHash(bytes)
			Dim sb As New StringBuilder()
			For Each b In hash
				sb.Append(b.ToString("x2"))
			Next
			Return sb.ToString()
		End Using
	End Function
	Private Function GenerarToken() As String
		Using rng As New RNGCryptoServiceProvider()
			Dim tokenData(15) As Byte
			rng.GetBytes(tokenData)
			Return BitConverter.ToString(tokenData).Replace("-", "").ToLower()
		End Using
	End Function

	Private Sub EnviarCorreoValidacion(destinatario As String, token As String)
		Try
			Dim mensaje As New MailMessage()
			mensaje.From = New MailAddress("axonnetmda@gmail.com", "Axonnet")
			mensaje.To.Add(destinatario)
			mensaje.Subject = "Confirmación de cuenta"
			mensaje.Body = "Haz clic en el siguiente enlace para activar tu cuenta: " &
					   Request.Url.GetLeftPart(UriPartial.Authority) & "/Account/Confirmar.aspx?token=" & token
			mensaje.IsBodyHtml = False

			Dim smtp As New SmtpClient("smtp.gmail.com")
			smtp.Credentials = New System.Net.NetworkCredential("axonnetmda@gmail.com", "mvbg nnga pxnd tuom")
			smtp.Port = 587 ' ← Cambia esto de 465 a 587
			smtp.EnableSsl = True
			'smtp.Timeout = 20000 ' 20 segundos
			'smtp.DeliveryMethod = SmtpDeliveryMethod.Network
			'smtp.UseDefaultCredentials = False

			smtp.Send(mensaje)
		Catch ex As Exception
			ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('Error al enviar el correo: " & ex.Message.Replace("'", "\'") & "');", True)
		End Try
	End Sub

End Class