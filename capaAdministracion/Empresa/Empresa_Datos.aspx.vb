Imports capaAdministracion.capaDatos
Imports System.Data.SqlClient

Public Class Empresa_Fiscales
    Inherits System.Web.UI.Page
    Dim nIdEmpresa As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            nIdEmpresa = Session("IdEmpresa")
            Dim lstDoc As List(Of tipodedocumento) = New CD_TipoDeDocumento().Listar()
            For item = 0 To lstDoc.Count - 1
                cboTipoDocumento.Items.Insert(item, New ListItem(lstDoc(item).Nombre, lstDoc(item).IdTipoDocumento))
            Next
            txtIdSucursal.Value = 0
            cboTipoDocumento.SelectedIndex = 0
            Dim lstres As List(Of tipoderesponsable) = New CD_TipoResponsable().Listar()
            For item = 0 To lstres.Count - 1
                cboTipoResponsable.Items.Insert(item, New ListItem(lstres(item).Nombre, lstres(item).idTipoResponsable))
            Next
            cboTipoResponsable.SelectedIndex = 0
            cboEstado.Items.Insert(0, New ListItem("Activo", 1))
            cboEstado.Items.Insert(1, New ListItem("No Activo", 0))
            cboEstado.DataTextField = "Activo"
            cboEstado.DataValueField = 1
            cboEstado.SelectedIndex = 0

            cboPuedeComprar.Items.Insert(0, New ListItem("SI", 1))
            cboPuedeComprar.Items.Insert(1, New ListItem("NO", 0))
            cboPuedeComprar.DataTextField = "SI"
            cboPuedeComprar.DataValueField = 1
            cboPuedeComprar.SelectedIndex = 0
            'Dim preferenceId As String = CrearPreferencia()
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "mp", $"initMercadoPago('{preferenceId}');", True)
            cboRealizaEnvios.Items.Insert(0, New ListItem("SI", 1))
            cboRealizaEnvios.Items.Insert(1, New ListItem("NO", 0))
            cboRealizaEnvios.DataTextField = "SI"
            cboRealizaEnvios.DataValueField = 1
            cboRealizaEnvios.SelectedIndex = 0
            CargarDatos(nIdEmpresa)

        End If
    End Sub
    Private Sub CargarDatos(nIdEmpresa As Integer)
        Dim query As String = "SELECT * FROM Empresa WHERE idEmpresa = @idEmpresa"
        Dim lst As List(Of empresa) = New CD_Empresa().Listarporcodigo(nIdEmpresa)
        Dim reader As SqlDataReader
        Using con As New SqlConnection(conectar.Cadena)

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@idEmpresa", nIdEmpresa) ' ID de empresa a cargar (puede venir de un parámetro)
                con.Open()
                reader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim valorCelda As Integer
                    txtIdEmpresa.Value = reader("idEmpresa").ToString()
                    txtNombreComercial.Text = reader("NombreComercial").ToString()
                    txtRazonSocial.Text = reader("RazonSocial").ToString()
                    txtDireccionEmpresa.Text = reader("Domicilio").ToString()
                    txtCodigoPostalEmpresa.Text = reader("CodigoPostal").ToString()
                    txtLocalidadEmpresa.Text = reader("Localidad").ToString()
                    txtCelular.Text = reader("Celular").ToString()
                    txtProvinciaEmpresa.Text = reader("Provincia").ToString()
                    txtTelefonoEmpresa.Text = reader("Celular").ToString()
                    txtEmailEmpresa.Text = reader("Email").ToString()
                    txtPaisEmpresa.Text = reader("Pais").ToString()
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
                        txtFechaInicioActividades.Text = fecha.ToString("yyyy-MM-dd")
                    Else
                        txtFechaInicioActividades.Text = ""
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

                    reader.Close()
                    reader = Nothing

                End If
            End Using

            query = "SELECT * from sucursal where idEmpresa=@IdEmpresa AND EsDepositoCentral=1"
            Using cmd As New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@idEmpresa", nIdEmpresa) ' ID de empresa a cargar (puede venir de un parámetro)
                'con.Open()


                reader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim valorCelda As Integer
                    txtNombresucursal.Text = reader("Nombre").ToString()
                    txtDomicilioSucursal.Text = reader("Direccion").ToString()
                    txtCodigoPostalSucursal.Text = reader("CodigoPostal").ToString()
                    txtLocalidadSucursal.Text = reader("Localidad").ToString()
                    txtProvinciaSucursal.Text = reader("Provincia").ToString()
                    txtPaisSucursal.Text = reader("Pais").ToString()
                    txtTelefonoSucursal.Text = reader("Telefono").ToString()
                    txtMovilSucursal.Text = reader("Celular").ToString()
                    txtEmailSucursal.Text = reader("Email").ToString()
                    txtInstagramSucursal.Text = reader("Instagram").ToString()


                    For Each item As ListItem In cboPuedeComprar.Items
                        If Integer.TryParse(reader("PuedeComprar").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboPuedeComprar.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    valorCelda = 0
                    For Each item As ListItem In cboRealizaEnvios.Items
                        If Integer.TryParse(reader("HaceEnvios").ToString(), valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboRealizaEnvios.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
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
                    BuscarFormaPago()
                End If
            End Using
        End Using
    End Sub

    Protected Sub RegistrarEmpresa()
        Try
            Using conn As New SqlConnection(conectar.Cadena)
                Using cmd As New SqlCommand("sp_ModificarEmpresa", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    nIdEmpresa = Session("idEmpresa")
                    ' ==== PARÁMETROS DE EMPRESA ====
                    cmd.Parameters.AddWithValue("@idEmpresa", nIdEmpresa) ' O tu valor dinámico
                    cmd.Parameters.AddWithValue("@NombreComercial", txtNombreComercial.Text)
                    cmd.Parameters.AddWithValue("@RazonSocial", txtRazonSocial.Text)
                    cmd.Parameters.AddWithValue("@DomicilioEmpresa", txtDireccionEmpresa.Text)
                    cmd.Parameters.AddWithValue("@CodigoPostalEmpresa", txtCodigoPostalEmpresa.Text)
                    cmd.Parameters.AddWithValue("@LocalidadEmpresa", txtLocalidadEmpresa.Text)
                    cmd.Parameters.AddWithValue("@ProvinciaEmpresa", txtProvinciaEmpresa.Text)
                    cmd.Parameters.AddWithValue("@PaisEmpresa", txtPaisEmpresa.Text)
                    cmd.Parameters.AddWithValue("@IdTipoResponsable", cboTipoResponsable.SelectedValue)
                    cmd.Parameters.AddWithValue("@idTipoDocumento", cboTipoDocumento.SelectedValue)
                    cmd.Parameters.AddWithValue("@NumeroDocumento", txtNumeroDocumento.Text)
                    cmd.Parameters.AddWithValue("@TelefonoEmpresa", txtTelefonoEmpresa.Text)
                    cmd.Parameters.AddWithValue("@CelularEmpresa", txtCelular.Text)
                    cmd.Parameters.AddWithValue("@EmailEmpresa", txtEmailEmpresa.Text)
                    cmd.Parameters.AddWithValue("@IdCategoriaEmpresa", 1)
                    cmd.Parameters.AddWithValue("@FechaInicioActividades", Convert.ToDateTime(txtFechaInicioActividades.Text))

                    ' ==== PARÁMETROS DE SUCURSAL ====
                    cmd.Parameters.AddWithValue("@NombreSucursal", txtNombresucursal.Text)
                    cmd.Parameters.AddWithValue("@DireccionSucursal", txtDomicilioSucursal.Text)
                    cmd.Parameters.AddWithValue("@CodigoPostalSucursal", txtCodigoPostalSucursal.Text)
                    cmd.Parameters.AddWithValue("@LocalidadSucursal", txtLocalidadSucursal.Text)
                    cmd.Parameters.AddWithValue("@ProvinciaSucursal", txtProvinciaSucursal.Text)
                    cmd.Parameters.AddWithValue("@PaisSucursal", txtPaisSucursal.Text)
                    cmd.Parameters.AddWithValue("@TelefonoSucursal", txtTelefonoSucursal.Text)
                    cmd.Parameters.AddWithValue("@MovilSucursal", txtMovilSucursal.Text)
                    cmd.Parameters.AddWithValue("@EmailSucursal", txtEmailSucursal.Text)
                    cmd.Parameters.AddWithValue("@instagram", txtInstagramSucursal.Text)
                    cmd.Parameters.AddWithValue("@HaceEnvios", True)
                    cmd.Parameters.AddWithValue("@PuedeComprar", True)
                    cmd.Parameters.AddWithValue("@EsCentral", True)

                    ' ==== FORMAS DE PAGO ====
                    Dim dtFormasPago As New DataTable()
                    dtFormasPago.Columns.Add("IdFormaPago", GetType(Integer))
                    dtFormasPago.Columns.Add("NombreFormaPago", GetType(String))
                    dtFormasPago.Columns.Add("AliasCuenta", GetType(String))
                    dtFormasPago.Columns.Add("CBU", GetType(String))
                    dtFormasPago.Columns.Add("Estado", GetType(Boolean))

                    If chkEfectivo.Checked Then
                        dtFormasPago.Rows.Add(1, "Efectivo", "", "", True)
                    Else
                        dtFormasPago.Rows.Add(1, "Efectivo", "", "", False)
                    End If

                    If chkDebito.Checked Then
                        dtFormasPago.Rows.Add(2, "Débito", "", "", True)
                    Else
                        dtFormasPago.Rows.Add(2, "Débito", "", "", False)
                    End If
                    If chkTarjetasCredito.Checked Then
                        dtFormasPago.Rows.Add(3, "Crédito", "", "", True)
                    Else
                        dtFormasPago.Rows.Add(3, "Crédito", "", "", False)

                    End If
                    If chkTransferencia.Checked Then
                        dtFormasPago.Rows.Add(4, "Transferencia", txtAliasTransferencia.Text, txtCBU.Text, True)
                    Else
                        dtFormasPago.Rows.Add(4, "Transferencia", "", "", False)
                    End If
                    If chkMercadoPago.Checked Then
                        dtFormasPago.Rows.Add(5, "Mercado Pago", txtAliasMP.Text, txtCBV.Text, True)
                    Else
                        dtFormasPago.Rows.Add(5, "Mercado Pago", "", "", False)
                    End If

                    If chkCtaDNI.Checked Then
                        dtFormasPago.Rows.Add(6, "Cuenta DNI", txtCtaDNIAlias.Text, txtCtaDNICBU.Text, True)
                    Else
                        dtFormasPago.Rows.Add(6, "Cuenta DNI", "", "", False)
                    End If
                    If chkModo.Checked Then
                        dtFormasPago.Rows.Add(7, "Modo", txtModoAlias.Text, txtModoCBU.Text, True)
                    Else
                        dtFormasPago.Rows.Add(7, "Modo", "", "", False)
                    End If

                    Dim pFormasPago As New SqlParameter("@FormasPago", SqlDbType.Structured)
                    pFormasPago.TypeName = "TipoFormaPago"
                    pFormasPago.Value = dtFormasPago
                    cmd.Parameters.Add(pFormasPago)

                    ' ==== PARÁMETROS DE SALIDA ====
                    Dim pMensaje As New SqlParameter("@Mensaje", SqlDbType.VarChar, 500) With {
                        .Direction = ParameterDirection.Output
                    }
                    Dim pResultado As New SqlParameter("@Resultado", SqlDbType.Int) With {
                        .Direction = ParameterDirection.Output
                    }

                    cmd.Parameters.Add(pMensaje)
                    cmd.Parameters.Add(pResultado)

                    conn.Open()
                    cmd.ExecuteNonQuery()

                    ' ==== RESULTADO ====
                    Dim mensaje As String = pMensaje.Value.ToString()
                    Dim resultado As Integer = Convert.ToInt32(pResultado.Value)

                    If resultado > 0 Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ok", $"mostrarModal('Correcto', '{mensaje}');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error", $"mostrarModal('Error', '{mensaje}');", True)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "catch", $"mostrarModal('Error inesperado', '{ex.Message.Replace("'", "\'")}');", True)
        End Try
    End Sub
    Private Sub BuscarFormaPago()
        Dim FP As Integer
        Dim QUERY As String = "SELECT * FROM empresa_formadepago WHERE idEmpresa=" & nIdEmpresa

        Using con As New SqlConnection(conectar.Cadena)
            Try


                Dim da As New SqlDataAdapter(QUERY, con)
                Dim dt As New DataTable


                Dim xCmd As New SqlCommand(QUERY, con)
                Dim xDR As SqlDataReader

                xCmd = New SqlCommand(QUERY, con)
                con.Open()
                xDR = xCmd.ExecuteReader


                While (xDR.Read)

                    Select Case xDR.Item("IdFormaPago")
                        Case = 1
                            chkEfectivo.Checked = True
                        Case 2
                            chkDebito.Checked = True
                        Case 3
                            chkTarjetasCredito.Checked = True
                        Case 4
                            chkTransferencia.Checked = True
                            txtCBV.Text = xDR.Item("CBU")
                            txtCtaDNIAlias.Text = xDR.Item("AliasCuenta")
                        Case 5
                            chkMercadoPago.Checked = True
                            txtCBV.Text = xDR.Item("CBU")
                            txtAliasMP.Text = xDR.Item("AliasCuenta")
                        Case 6
                            chkCtaDNI.Checked = True
                            txtCBV.Text = xDR.Item("CBU")
                            txtCtaDNIAlias.Text = xDR.Item("AliasCuenta")
                        Case 7
                            chkCtaDNI.Checked = True
                        Case Else

                    End Select
                End While

                con.Close()
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroError", "mostrarModal('Error', '" & ex.Message.Replace("'", "\'") & "');", True)
            End Try
        End Using
    End Sub
    Private Sub BuscarCheckBoxes(ctrl As Control, dtFormasPago As DataTable)
        For Each child As Control In ctrl.Controls
            If TypeOf child Is CheckBox Then
                Dim chk As CheckBox = CType(child, CheckBox)
                If chk.Checked Then
                    Select Case chk.ID
                        Case "chkEfectivo"
                            dtFormasPago.Rows.Add(1, "Efectivo", "", "", True)
                        Case "chkDebito"
                            dtFormasPago.Rows.Add(2, "Débito", "", "", True)
                        Case "chkTarjetasCredito"
                            dtFormasPago.Rows.Add(3, "Tarjeta de crédito", "", "", True)
                        Case "chkTransferencia"
                            dtFormasPago.Rows.Add(4, "Transferencia", txtAliasTransferencia.Text, txtCBU.Text, True)
                        Case "chkMercadoPago"
                            dtFormasPago.Rows.Add(5, "Mercado Pago", txtAliasMP.Text, txtCBV.Text, True)
                        Case "chkCtaDNI"
                            dtFormasPago.Rows.Add(6, "Cuenta DNI", txtCtaDNIAlias.Text, txtCtaDNICBU.Text, True)
                        Case "chkModo"
                            dtFormasPago.Rows.Add(7, "Modo", txtModoAlias.Text, txtModoCBU.Text, True)
                    End Select
                End If
            End If

            ' Buscar en hijos
            If child.HasControls() Then
                BuscarCheckBoxes(child, dtFormasPago)
            End If
        Next
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        RegistrarEmpresa()
    End Sub
End Class