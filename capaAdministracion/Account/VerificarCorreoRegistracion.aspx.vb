Imports System.Net.Mail

Public Class VerificarCorreoRegistracion
    Inherits System.Web.UI.Page
    Dim token As String
    Dim mail As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        token = Request.QueryString("token")
        mail = Request.QueryString("mail")


        If String.IsNullOrEmpty(token) Then
            lblMensaje.Text = "Token inválido o faltante."
            Return
        End If
        If String.IsNullOrEmpty(mail) Then
            lblMensaje.Text = "Email inválido o faltante."
            Return
        End If

    End Sub

    Protected Sub btnReenviar_Click(sender As Object, e As EventArgs)
        Dim Mensaje As String = ""
        If Not EnviarCorreoValidacion(mail, token, Mensaje) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('Error al enviar el correo: " & Mensaje.Replace("'", "\'") & "');", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Atencion", "alert('Verifique su correo );", True)
        End If

    End Sub
    Private Function EnviarCorreoValidacion(destinatario As String, token As String, msm As String) As Boolean
        Dim Exito As Boolean = False
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
            Exito = True
        Catch ex As Exception
            Exito = False
            msm = ex.Message

        End Try
        Return Exito
    End Function
End Class