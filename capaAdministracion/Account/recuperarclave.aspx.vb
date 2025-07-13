Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports capaAdministracion.capaDatos

Public Class recuperarclave
    Inherits System.Web.UI.Page
    Dim token As String = ""
    Dim Email As String = ""
    Dim Mensaje As String = ""
    Dim clave As String = Convert.ToString(Date.Now.Ticks)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnReenviar_Click(sender As Object, e As EventArgs)
        Try
            Dim email As String = txtEmail.Text.Trim()
            Dim token As String = GenerarToken()
            Dim filasAfectadas As Integer = 0
            Using conn As New SqlConnection(conectar.Cadena)
                Using cmd As New SqlCommand("UPDATE usuarios set Token=@token, clave=@clave WHERE email=@email", conn)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@Token", token)
                    cmd.Parameters.AddWithValue("@Clave", clave)
                    filasAfectadas = cmd.ExecuteNonQuery()
                End Using
            End Using
            If filasAfectadas = 0 Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('Error al enviar el correo: " & Mensaje.Replace("'", "\'") & "');", True)
            Else
                If Not EnviarCorreoValidacion(txtEmail.Text, token, Mensaje) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('no se puede actualizar el registro de usuario " & Mensaje.Replace("'", "\'") & "');", True)
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Atencion", "alert('Verifique su correo );", True)
                End If
            End If
        Catch ex As Exception
            Mensaje = ex.Message
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('Error al enviar el correo: " & Mensaje.Replace("'", "\'") & "');", True)
        End Try






    End Sub
    Private Function EnviarCorreoValidacion(destinatario As String, token As String, msm As String) As Boolean
        Dim Exito As Boolean = False
        Try
            Dim mensaje As New MailMessage()
            mensaje.From = New MailAddress("axonnetmda@gmail.com", "Axonnet")
            mensaje.To.Add(destinatario)
            mensaje.Subject = "Confirmación de cuenta"
            mensaje.Body = "Haz clic en el siguiente enlace para activar tu cuenta: " &
                       Request.Url.GetLeftPart(UriPartial.Authority) & "/Account/nuevaclave.aspx?token=" & token & "&Clave=" & clave
            mensaje.IsBodyHtml = False

            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Credentials = New System.Net.NetworkCredential("axonnetmda@gmail.com", "mvbg nnga pxnd tuom")
            smtp.Port = 587 ' ← Cambia esto de 465 a 587
            smtp.EnableSsl = True
            'smtp.Timeout = 20000 ' 20 segundos
            'smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            'smtp.UseDefaultCredentials = False

            smtp.Send(mensaje)
            Exito = True
        Catch ex As Exception
            Exito = False
            msm = ex.Message

        End Try
        Return Exito
    End Function
    Private Function GenerarToken() As String
        Using rng As New RNGCryptoServiceProvider()
            Dim tokenData(15) As Byte
            rng.GetBytes(tokenData)
            Return BitConverter.ToString(tokenData).Replace("-", "").ToLower()
        End Using
    End Function
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

End Class