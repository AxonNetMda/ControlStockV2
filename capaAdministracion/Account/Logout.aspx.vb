Public Class Logout
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Clear()
        Session.Abandon()

        ' Mostrar mensaje y redirigir con retardo
        Dim script As String = """
            setTimeout(function() {
                window.location.href = '~/Default.aspx';
            }, 2000);
        """
        ClientScript.RegisterStartupScript(Me.GetType(), "redirect", script, True)
    End Sub

End Class