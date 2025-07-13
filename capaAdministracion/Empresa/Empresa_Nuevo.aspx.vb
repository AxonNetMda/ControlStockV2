Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos

Public Class Empresa_Nuevo
    Inherits System.Web.UI.Page
    Dim idEmpresa As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("IdEmpresa") IsNot Nothing Then
            Dim _idEmpresa As Integer = Session("IdEmpresa")
            Dim _IdRol As Integer = Session("IdRol")
            If _idEmpresa = 1 And _IdRol = 1 Then
                CargarDatos()
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "accesoDenegado", "mostrarModal('No esta autorizado', 'No tiene permitido el acceso a este menu. Sus Credenciales no son suficientes Comuniquese con el administrador del sistema.');", True)
                Response.Redirect("Panel.aspx")
            End If

        End If
        idEmpresa = 0
        cboEstado.Items.Insert(0, New ListItem("Activo", 1))
        cboEstado.Items.Insert(1, New ListItem("No Activo", 0))
        cboEstado.DataTextField = "Activo"
        cboEstado.DataValueField = 1
        cboEstado.SelectedIndex = 0

        cboEsDemo.Items.Insert(0, New ListItem("Es demo", 1))
        cboEsDemo.Items.Insert(1, New ListItem("No es demo", 0))
        cboEsDemo.DataTextField = "Es demo"
        cboEsDemo.DataValueField = 1
        cboEsDemo.SelectedIndex = 0
        Dim listcateg As List(Of empresa_categoria) = New CD_Empresa_Categoria().Listar(0)
        For item = 0 To listcateg.Count - 1
            cboCategoria.Items.Insert(item, New ListItem(listcateg(item).Nombre, listcateg(item).idEmpresaCAtegoria))
        Next
        cboCategoria.SelectedIndex = 0

        Dim lstTR As List(Of tipoderesponsable) = New CD_TipoResponsable().Listar()
        For item = 0 To lstTR.Count - 1
            cboTipoResponsable.Items.Insert(item, New ListItem(lstTR(item).Nombre, lstTR(item).idTipoResponsable))
        Next
        cboTipoResponsable.SelectedIndex = 0

        Dim lstTd As List(Of tipodedocumento) = New CD_TipoDeDocumento().Listar()
        For item = 0 To lstTd.Count - 1
            cboTipoDocumento.Items.Insert(item, New ListItem(lstTd(item).Nombre, lstTd(item).IdTipoDocumento))
        Next
        cboTipoDocumento.SelectedIndex = 0




    End Sub
    Private Sub CargarDatos()
        txtRazonSocial.Text = ""
        txtNombreComercial.Text = ""
        txtDireccion.Text = ""
        txtCodigoPostal.Text = ""
        txtLocalidad.Text = ""
        txtProvincia.Text = ""
        txtPais.Text = ""
        txtTelefono.Text = ""
        txtEmail.Text = ""
        txtNumeroDocumento.Text = ""
        txtFechaAlta.Enabled = False
        Dim fecha As DateTime = Convert.ToDateTime(Date.Today)
        txtFechaInicioDemo.Text = fecha.ToString("yyyy-MM-dd")
        txtInicioActividades.Text = fecha.ToString("yyyy-MM-dd")
        txtFechaAlta.Text = fecha.ToString("yyyy-MM-dd")
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim query As String = "insert into Empresa (RazonSocial, NombreComercial, Domicilio, CodigoPostal, Localidad, Provincia, Pais, Celular,
                               Email, IdTipoResponsable,idTipoDocumento,NumeroDocumento, idCategoria, EsDemo, FechaInicioDemo, FechaInicioActividades, Estadd) VALUES (
                              @RazonSocial, @NombreComercial, @Domicilio, @CodigoPostal, @Localidad, @Provincia, @Pais, @Celular
                              @Email, @idTipoResponsable, @IdTipoDocumento, @NumeroDocumento, @IdCategoria, @EsDemo, @FechaInicioDemo, @FechaInicioActividades, 
                              @Estado)"
        Using con As New SqlConnection(conectar.Cadena)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@RazonSocial", txtRazonSocial.Text)
                cmd.Parameters.AddWithValue("@NombreComercial", txtNombreComercial.Text)
                cmd.Parameters.AddWithValue("@Domicilio", txtDireccion.Text)
                cmd.Parameters.AddWithValue("@CodigoPostal", txtCodigoPostal.Text)
                cmd.Parameters.AddWithValue("@Localidad", txtLocalidad.Text)
                cmd.Parameters.AddWithValue("@Provincia", txtProvincia.Text)
                cmd.Parameters.AddWithValue("@pais", txtPais.Text)
                cmd.Parameters.AddWithValue("@Celular", txtTelefono.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@IdTipoResponsable", cboTipoResponsable.SelectedValue)
                cmd.Parameters.AddWithValue("@IdTipoDocumento", cboTipoDocumento.SelectedValue)
                cmd.Parameters.AddWithValue("@NumeroDocumento", txtNumeroDocumento.Text)
                cmd.Parameters.AddWithValue("@idCategoria", cboCategoria.SelectedValue)
                cmd.Parameters.AddWithValue("@EsDemo", cboEsDemo.SelectedValue)
                cmd.Parameters.AddWithValue("@FechaInicioDemo", Convert.ToDateTime(txtFechaInicioDemo.Text))
                cmd.Parameters.AddWithValue("@FechaInicioActividades", Convert.ToDateTime(txtInicioActividades.Text))
                cmd.Parameters.AddWithValue("@Estado", cboEstado.SelectedValue)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class