Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("IdUsuario") IsNot Nothing Then
            Dim idEmpresa As Integer = 0
            If Session("idEmpresa") IsNot Nothing Then
                Integer.TryParse(Session("idEmpresa").ToString(), idEmpresa)
            End If

            'Select Case idEmpresa
            '    Case 1
            '        phMenuMaster.Controls.Add(New LiteralControl(GenerarMenuProveedor()))
            '    Case > 1
            '        phMenuMaster.Controls.Add(New LiteralControl(GenerarMenuCliente()))
            '    Case Else
            '        ' No se muestra ningún menú
            'End Select
        End If
    End Sub
End Class