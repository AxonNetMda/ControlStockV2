Imports System.Data.SqlClient
Imports System.Net.Mail
Imports capaAdministracion.capaDatos

Public Class Confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim token As String = Request.QueryString("token")
        Dim mail As String = Request.QueryString("mail")


        If String.IsNullOrEmpty(token) Then
            lblMensaje.Text = "Token inválido o faltante."
            Return
        End If
        'If String.IsNullOrEmpty(mail) Then
        '    lblMensaje.Text = "Email inválido o faltante."
        '    Return
        'End If



        Try
            Using conn As New SqlConnection(conectar.Cadena)
                Dim cmd As New SqlCommand("UPDATE Usuarios SET CuentaActiva = 1 WHERE Token = @Token", conn)
                cmd.Parameters.AddWithValue("@Token", token)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    lblMensaje.Text = "Cuenta activada correctamente. Serás redirigido en unos segundos..."
                    Response.Redirect("~/default.aspx")
                Else
                    lblMensaje.Text = "Token inválido o cuenta ya confirmada."
                End If
            End Using
        Catch ex As Exception
            lblMensaje.Text = "Error al activar la cuenta: " & ex.Message
        End Try
    End Sub
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