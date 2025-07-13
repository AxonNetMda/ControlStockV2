Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos
Public Class Empresa_Listado_Datos
    Inherits System.Web.UI.Page
    Dim IdEmpresa As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            idempresa = Request.QueryString("IdEmpresa")
            CargarEmpresas()
            gvEmpresa.UseAccessibleHeader = True
            gvEmpresa.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub
    Private Sub CargarEmpresas()
        Dim ssql As String = ""
        If IdEmpresa = 0 Then
            ssql = "SELECT * FROM Empresa order by NombreComercial"
        Else
            ssql = "SELECT * FROM Empresa where idEmpresa=" & IdEmpresa & " order by NombreComercial"
        End If
        Dim dtEmpresas As New DataTable()
        Using conn As New SqlConnection(conectar.Cadena)
            Dim cmd As New SqlCommand(ssql, conn)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dtEmpresas)
        End Using

        gvEmpresa.DataSource = dtEmpresas
        gvEmpresa.DataBind()
    End Sub
    Protected Sub btnNuevaEmpresa_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Empresa/Empresa_nuevo.aspx")
    End Sub

    Protected Sub gvEmpresa_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Dim idEmpresa As Integer = Convert.ToInt32(e.CommandArgument)

        If e.CommandName = "Editar" Then
            Response.Redirect("Empresa_editar.aspx?id=" & idEmpresa)
        ElseIf e.CommandName = "Borrar" Then
            BorrarEmpresa(idEmpresa)
            CargarEmpresas()
        End If
    End Sub

    Private Sub BorrarEmpresa(id As Integer)
        Using conn As New SqlConnection(conectar.Cadena)
            Dim cmd As New SqlCommand("DELETE FROM Empresa WHERE IdEmpresa = @IdEmpresa", conn)
            cmd.Parameters.AddWithValue("@IdEmpresa", id)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class