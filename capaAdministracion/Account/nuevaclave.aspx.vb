Imports capaAdministracion.capaDatos
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class nuevclave
    Inherits System.Web.UI.Page
    Dim Mensaje As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            txtClave.Text = ""
            txtClaveConfirma.Text = ""
            txtEmail.Text = ""
        End If
    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs)
        If Trim(txtClave.Text) = Trim(txtClaveConfirma.Text) Then
            Try

                Using conn As New SqlConnection(conectar.Cadena)
                    Dim cmd As New SqlCommand("UPDATE Usuarios SET Clave = @Clave WHERE email = @email", conn)
                    cmd.Parameters.AddWithValue("@Clave", EncriptarClave(txtClave.Text))
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Mensaje = "Cuenta activada correctamente. Serás redirigido en unos segundos..."
                        Response.Redirect("~/Account/login.aspx")
                    Else
                        Mensaje = "Error. no se puede actualizar la clave."
                    End If
                End Using
            Catch ex As Exception
                Mensaje = "Error " & ex.Message
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('Error la claves no coinciden " & Mensaje & " );", True)
            End Try
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", "alert('Error la claves no coinciden );", True)
            txtClave.Focus()
        End If
    End Sub
    Private Function EncriptarClave(clave As String) As String
        Using sha256 As SHA256 = sha256.Create()
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