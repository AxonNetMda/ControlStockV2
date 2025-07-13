Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos

Public Class Confirmar
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim token As String = Request.QueryString("token")
		If String.IsNullOrEmpty(token) Then
			lblMensaje.Text = "Token inválido o faltante."
			Return
		End If

		Try
			Using conn As New SqlConnection(conectar.Cadena)
				Dim cmd As New SqlCommand("UPDATE Usuarios SET CuentaActiva = 1 WHERE Token = @Token", conn)
				cmd.Parameters.AddWithValue("@Token", token)
				conn.Open()
				Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

				If rowsAffected > 0 Then
					lblMensaje.Text = "Cuenta activada correctamente. Serás redirigido en unos segundos..."
				Else
					lblMensaje.Text = "Token inválido o cuenta ya confirmada."
				End If
			End Using
		Catch ex As Exception
			lblMensaje.Text = "Error al activar la cuenta: " & ex.Message
		End Try
	End Sub

End Class