Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos
Imports System.Threading.Tasks
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Public Class Registrarse
    Inherits System.Web.UI.Page
    '    CREATE TYPE TipoFormaPago AS TABLE (
    '    IdFormaPago INT,
    '    NombreFormaPago VARCHAR(100),
    '    AliasCuenta VARCHAR(100),
    '    CBU VARCHAR(100),
    '    Estado BIT
    ')
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Dim lstDoc As List(Of tipodedocumento) = New CD_TipoDeDocumento().Listar()
            For item = 0 To lstDoc.Count - 1
                cboTipoDocumento.Items.Insert(item, New ListItem(lstDoc(item).Nombre, lstDoc(item).IdTipoDocumento))
            Next
            txtIdSucursal.Value = 0
            txtIdUsuario.Value = 0
            cboTipoDocumento.SelectedIndex = 0
            Dim lstres As List(Of tipoderesponsable) = New CD_TipoResponsable().Listar()
            For item = 0 To lstres.Count - 1
                cboTipoResponsable.Items.Insert(item, New ListItem(lstres(item).Nombre, lstres(item).idTipoResponsable))
            Next
            txtNombreUsuario.Text = ""
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
        End If
    End Sub
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        RegistrarEmpresa()
        'Try
        '    Dim nombre As String = txtNombreUsuario.Text.Trim()
        '    Dim email As String = txtEmail.Text.Trim()
        '    Dim movil As String = txtMovil.Text.Trim()
        '    Dim clave As String = txtClave.Text.Trim()
        '    Dim claveEncriptada As String = EncriptarClave(clave)
        '    Dim idRol As Integer = 5 ' Invitado por defecto
        '    Dim token As String = GenerarToken()
        '    Dim cmd As SqlCommand
        '    Using conn As New SqlConnection(conectar.Cadena)

        '        conn.Open()

        '        Dim dtFormas As New DataTable()
        '        dtFormas.Columns.Add("IdFormaPago", GetType(Integer))
        '        dtFormas.Columns.Add("NombreFormaPago", GetType(String))
        '        dtFormas.Columns.Add("AliasCuenta", GetType(String))
        '        dtFormas.Columns.Add("CBU", GetType(String))
        '        dtFormas.Columns.Add("Estado", GetType(Boolean))

        '        ' Agregar varias filas
        '        dtFormas.Rows.Add(1, "Transferencia", "MiCuenta", "123456789", True)
        '        dtFormas.Rows.Add(2, "MercadoPago", "MiAlias", "654321987", True)

        '        cmd.Parameters.AddWithValue("@FormasPago", dtFormas)
        '        cmd.Parameters("@FormasPago").SqlDbType = SqlDbType.Structured
        '        ' Verificar si ya existe el email
        '        Dim existeCmd As New SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Email = @Email", conn)
        '        existeCmd.Parameters.AddWithValue("@Email", email)
        '        Dim existe As Integer = Convert.ToInt32(existeCmd.ExecuteScalar())

        '        If existe > 0 Then
        '            ' Si existe, actualiza clave y token, reinicia estado
        '            Dim updateCmd As New SqlCommand("UPDATE Usuarios SET Clave = @Clave, Token = @Token, CuentaActiva = 0, Estado = 1 WHERE Email = @Email", conn)
        '            updateCmd.Parameters.AddWithValue("@Clave", claveEncriptada)
        '            updateCmd.Parameters.AddWithValue("@Token", token)
        '            updateCmd.Parameters.AddWithValue("@Email", email)
        '            updateCmd.ExecuteNonQuery()
        '        Else
        '            ' Si no existe, inserta nuevo registro
        '            Dim insertCmd As New SqlCommand("INSERT INTO Usuarios (Nombre, Email, Movil, IdRol, Token, CuentaActiva, Estado, Clave) VALUES (@Nombre, @Email, @Movil, @IdRol, @Token, 0, 1, @Clave)", conn)
        '            insertCmd.Parameters.AddWithValue("@Nombre", nombre)
        '            insertCmd.Parameters.AddWithValue("@Email", email)
        '            insertCmd.Parameters.AddWithValue("@Movil", movil)
        '            insertCmd.Parameters.AddWithValue("@IdRol", idRol)
        '            insertCmd.Parameters.AddWithValue("@Token", token)
        '            insertCmd.Parameters.AddWithValue("@Clave", claveEncriptada)
        '            insertCmd.ExecuteNonQuery()
        '        End If
        '    End Using

        '    EnviarCorreoValidacion(email, token)
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroExitoso", "mostrarModal('Registro exitoso', 'Revisa tu correo electrónico para activar tu cuenta.');", True)
        'Catch ex As Exception
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroError", "mostrarModal('Error en el registro', '" & ex.Message.Replace("'", "\'") & "');", True)
        'End Try
    End Sub
    Private Function EncriptarClave(clave As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(clave)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim sb As New StringBuilder()
            For Each b In hash
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function
    Private Function GenerarToken() As String
        Using rng As New RNGCryptoServiceProvider()
            Dim tokenData(15) As Byte
            rng.GetBytes(tokenData)
            Return BitConverter.ToString(tokenData).Replace("-", "").ToLower()
        End Using
    End Function

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
    Private Function CrearPreferencia() As String
        Dim url As String = "https://api.mercadopago.com/checkout/preferences?access_token=TU_ACCESS_TOKEN"

        Dim json As String = "{
            ""items"": [{
                ""title"": ""Suscripción mensual a Sin Límites"",
                ""quantity"": 1,
                ""unit_price"": 4999
            }],
            ""back_urls"": {
                ""success"": ""https://axonnet.store/exito.aspx"",
                ""failure"": ""https://axonnet.store/error.aspx"",
                ""pending"": ""https://axonnet.store/pendiente.aspx""
            },
            ""auto_return"": ""approved""
        }"

        Dim request As WebRequest = WebRequest.Create(url)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim bytes As Byte() = Encoding.UTF8.GetBytes(json)
        request.ContentLength = bytes.Length

        Using stream As Stream = request.GetRequestStream()
            stream.Write(bytes, 0, bytes.Length)
        End Using

        Dim response As WebResponse = request.GetResponse()
        Using reader As New StreamReader(response.GetResponseStream())
            Dim result As String = reader.ReadToEnd()
            Dim jsonObj = JObject.Parse(result)
            Return jsonObj("id").ToString()
        End Using
    End Function
    Private Function GuardarModificacion() As Boolean


    End Function

    Protected Sub RegistrarEmpresa()
        Try
            Dim nombre As String = txtNombreUsuario.Text.Trim()
            Dim email As String = txtEmail.Text.Trim()
            Dim movil As String = txtMovil.Text.Trim()
            Dim clave As String = txtClave.Text.Trim()
            Dim claveEncriptada As String = EncriptarClave(clave)
            Dim idRol As Integer = 2 ' Invitado por defecto
            Dim token As String = GenerarToken()
            If txtIdEmpresa.Value = "" Then
                txtIdEmpresa.Value = 0
            End If
            Using conn As New SqlConnection(conectar.Cadena)
                Using cmd As New SqlCommand("[sp_RegistrarEmpresa]", conn)

                    cmd.CommandType = CommandType.StoredProcedure
                    ' Parámetros escalares de Empresa
                    cmd.Parameters.AddWithValue("@IdEmpresa", Convert.ToInt32(txtIdEmpresa.Value))
                    cmd.Parameters.AddWithValue("@NombreComercial", Convert.ToString(txtNombreComercial.Text))
                    cmd.Parameters.AddWithValue("@RazonSocial", Convert.ToString(txtRazonSocial.Text))
                    cmd.Parameters.AddWithValue("@DomicilioEmpresa", Convert.ToString(txtDireccionEmpresa.Text))
                    cmd.Parameters.AddWithValue("@CodigoPostalEmpresa", Convert.ToString(txtCodigoPostalEmpresa.Text))
                    cmd.Parameters.AddWithValue("@LocalidadEmpresa", Convert.ToString(txtLocalidadEmpresa.Text))
                    cmd.Parameters.AddWithValue("@ProvinciaEmpresa", Convert.ToString(txtProvinciaEmpresa.Text))
                    cmd.Parameters.AddWithValue("@PaisEmpresa", Convert.ToString(txtPaisEmpresa.Text))
                    cmd.Parameters.AddWithValue("@EmailEmpresa", Convert.ToString(txtEmailEmpresa.Text))
                    cmd.Parameters.AddWithValue("@idTipoResponsable", Convert.ToString(cboTipoResponsable.SelectedValue))
                    cmd.Parameters.AddWithValue("@idTipoDocumento", Convert.ToString(cboTipoDocumento.SelectedValue))
                    cmd.Parameters.AddWithValue("@NumeroDocumento", Convert.ToString(txtNumeroDocumento.Text))
                    cmd.Parameters.AddWithValue("@idCategoriaEmpresa", 1)
                    cmd.Parameters.AddWithValue("@EsDemo", 1)
                    cmd.Parameters.AddWithValue("@FechaInicioDemo", Date.Today.ToString("dd/MM/yyyy"))
                    cmd.Parameters.AddWithValue("@FechaAlta", Date.Today.ToString("dd/MM/yyyy"))

                    ' Parametros escalares de Usuario
                    cmd.Parameters.AddWithValue("@NombreUsuario", UCase(nombre))
                    cmd.Parameters.AddWithValue("@EmailUsuario", email)
                    cmd.Parameters.AddWithValue("@MovilUsuario", movil)
                    cmd.Parameters.AddWithValue("@IdRol", idRol)
                    cmd.Parameters.AddWithValue("@Token", token)
                    cmd.Parameters.AddWithValue("@Clave", claveEncriptada)

                    ' Parametros escalares de Sucursal
                    cmd.Parameters.AddWithValue("@NombreSucursal", txtNombresucursal.Text)
                    cmd.Parameters.AddWithValue("@DireccionSucursal", txtDomicilioSucursal.Text)
                    cmd.Parameters.AddWithValue("@CodigoPostalSucursal", txtCodigoPostalSucursal.Text)
                    cmd.Parameters.AddWithValue("@LocalidadSucursal", txtLocalidadSucursal.Text)
                    cmd.Parameters.AddWithValue("@ProvinciaSucursal", txtProvinciaSucursal.Text)
                    cmd.Parameters.AddWithValue("@PaisSucursal", txtPaisSucursal.Text)
                    cmd.Parameters.AddWithValue("@TelefonoSucursal", Convert.ToString(txtTelefonoSucursal.Text))
                    cmd.Parameters.AddWithValue("@MovilSucursal", Convert.ToString(txtMovilSucursal.Text))
                    cmd.Parameters.AddWithValue("@EmailSucursal", txtEmailSucursal.Text)
                    cmd.Parameters.AddWithValue("@instagram", txtInstagramSucursal.Text)

                    ' Crear DataTable para @FormasPago
                    Dim dtFormasPago As New DataTable()
                    dtFormasPago.Columns.Add("IdFormaPago", GetType(Integer))
                    dtFormasPago.Columns.Add("NombreFormaPago", GetType(String))
                    dtFormasPago.Columns.Add("AliasCuenta", GetType(String))
                    dtFormasPago.Columns.Add("CBU", GetType(String))
                    dtFormasPago.Columns.Add("Estado", GetType(Boolean))


                    ' Agregar formas de pago agregar parámetro tipo tabla
                    BuscarCheckBoxes(Page, dtFormasPago)
                    Dim pFormasPago As New SqlParameter("@FormasPago", SqlDbType.Structured)
                    pFormasPago.TypeName = "TipoFormaPago"
                    pFormasPago.Value = dtFormasPago
                    cmd.Parameters.Add(pFormasPago)

                    ' Parámetros de salida
                    Dim pMensaje As New SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    pMensaje.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(pMensaje)

                    Dim pResultado As New SqlParameter("@Resultado", SqlDbType.Int)
                    pResultado.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(pResultado)

                    conn.Open()
                    cmd.ExecuteNonQuery()

                    Dim mensaje As String = pMensaje.Value.ToString()
                    Dim resultado As Integer = Convert.ToInt32(pResultado.Value)
                    If resultado <> 0 Then
                        EnviarCorreoValidacion(email, token)
                        Response.Redirect("verificarCorreoRegistracion.aspx?mail='" & email & "'&Token='" & token & "'")
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroExitoso", "mostrarModal('Registro exitoso', 'Revisa tu correo electrónico para activar tu cuenta.');", True)
                    End If
                End Using
            End Using


        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "registroError", "mostrarModal('Error en el registro', '" & ex.Message.Replace("'", "\'") & "');", True)
        End Try
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

End Class