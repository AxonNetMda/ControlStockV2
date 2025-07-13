Imports capaAdministracion.capaDatos
Imports System.Data.SqlClient

Public Class Empresa_Editar
    Inherits System.Web.UI.Page
    Dim idEmpresa As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            idEmpresa = Convert.ToInt32(Session("idEmpresa"))
            If idEmpresa <> 1 Then
                cboEstado.Enabled = False
                cboEsDemo.Enabled = False

            End If
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


            If Session("IdEmpresa") IsNot Nothing Then
                Dim _idEmpresa As Integer = Session("IdEmpresa")
                Dim _IdRol As Integer = Session("IdRol")
                If _idEmpresa <> 0 Then



                    If _IdRol = 1 Then
                        CargarDatos(idEmpresa)
                    ElseIf _IdRol = 2 Then
                        CargarDatos(idEmpresa)
                    Else

                    End If

                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "accesoDenegado", "mostrarModal('No esta autorizado', 'No tiene permitido el acceso a este menu. Sus Credenciales no son suficientes Comuniquese con el administrador del sistema.');", True)
                    Response.Redirect("Panel.aspx")
                End If
            Else

            End If




        End If
    End Sub
    Private Sub CargarDatos(nIdEmpresa As Integer)
        Dim query As String = "SELECT * FROM Empresa WHERE idEmpresa = @idEmpresa"
        Dim lst As List(Of empresa) = New CD_Empresa().Listarporcodigo(nIdEmpresa)
        Using con As New SqlConnection(conectar.Cadena)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@idEmpresa", nIdEmpresa) ' ID de empresa a cargar (puede venir de un parámetro)
                con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim valorCelda As Integer
                    txtidEmpresa.Value = reader("idEmpresa").ToString()
                    txtNombreComercial.Text = reader("NombreComercial").ToString()
                    txtRazonSocial.Text = reader("RazonSocial").ToString()
                    txtDireccion.Text = reader("Domicilio").ToString()
                    txtCodigoPostal.Text = reader("CodigoPostal").ToString()
                    txtLocalidad.Text = reader("Localidad").ToString()
                    txtProvincia.Text = reader("Provincia").ToString()
                    txtTelefono.Text = reader("Celular").ToString()
                    txtEmail.Text = reader("Email").ToString()
                    txtPais.Text = reader("Pais").ToString()
                    txtCantidadDiasDemo.Text = Convert.ToInt32(reader("CantidadDiasDemo"))
                    For Each item As ListItem In cboTipoResponsable.Items
                        If Integer.TryParse(reader("idTipoResponsable").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboTipoResponsable.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    valorCelda = 0
                    For Each item As ListItem In cboTipoDocumento.Items
                        If Integer.TryParse(reader("idTipoDocumento").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboTipoDocumento.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    txtNumeroDocumento.Text = reader("NumeroDocumento").ToString()
                    If Not Convert.IsDBNull(reader("FechaInicioActividades")) Then
                        Dim fecha As DateTime = Convert.ToDateTime(reader("FechaInicioActividades"))
                        txtInicioActividades.Text = fecha.ToString("yyyy-MM-dd")
                    Else
                        txtInicioActividades.Text = ""
                    End If
                    valorCelda = 0
                    For Each item As ListItem In cboEstado.Items

                        If Integer.TryParse(reader("Estado").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboEstado.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    For Each item As ListItem In cboEsDemo.Items
                        If Integer.TryParse(reader("EsDemo").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboEsDemo.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    If Not Convert.IsDBNull(reader("FechaInicioDemo")) Then
                        Dim fecha As DateTime = Convert.ToDateTime(reader("FechaInicioDemo"))
                        txtFechaInicioDemo.Text = fecha.ToString("yyyy-MM-dd")
                    Else
                        txtFechaInicioDemo.Text = ""
                    End If
                    For Each item As ListItem In cboCategoria.Items
                        If Integer.TryParse(reader("IdCategoria").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboCategoria.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    If Not Convert.IsDBNull(reader("FechaAlta")) Then
                        Dim fecha As DateTime = Convert.ToDateTime(reader("FechaAlta"))
                        txtFechaAlta.Text = fecha.ToString("yyyy-MM-dd")
                    Else
                        txtFechaAlta.Text = ""
                    End If

                End If
            End Using
        End Using
    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try


            Dim query As String = "UPDATE Empresa SET RazonSocial=@RazonSocial, NombreComercial=@NombreComercial, Domicilio=@Domicilio, 
                              CodigoPostal=@CodigoPostal, Localidad=@Localidad, Provincia=@Provincia, Pais=@Pais, Celular=@Celular,
                              Email=@Email, IdTipoResponsable=@idTipoResponsable, idTipoDocumento=@IdTipoDocumento, NumeroDocumento=@NumeroDocumento, 
                              idCategoria=@IdCategoria, EsDemo=@EsDemo, FechaInicioDemo=@FechaInicioDemo, CantidadDiasDemo=@CantidadDiasDemo, FechaInicioActividades=@FechaInicioActividades, 
                              Estado=@Estado WHERE idEmpresa=@idEmpresa"
            Using con As New SqlConnection(conectar.Cadena)
                idEmpresa = Convert.ToInt32(Request.QueryString("Id"))
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa) ' ID de empresa a actualizar
                    cmd.Parameters.AddWithValue("@RazonSocial", UCase(txtRazonSocial.Text))
                    cmd.Parameters.AddWithValue("@NombreComercial", UCase(txtNombreComercial.Text))
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
                    cmd.Parameters.AddWithValue("@CantidadDiasDemo", Convert.ToInt32(txtCantidadDiasDemo.Text))
                    cmd.Parameters.AddWithValue("@FechaInicioActividades", Convert.ToDateTime(txtInicioActividades.Text))
                    cmd.Parameters.AddWithValue("@Estado", cboEstado.SelectedValue)
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Response.Redirect("~/../Account/Panel.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class