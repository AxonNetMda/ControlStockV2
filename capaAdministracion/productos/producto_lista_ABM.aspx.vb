﻿Imports System.Data.SqlClient
Imports System.IO
Imports capaAdministracion.capaDatos
Public Class producto_lista_ABM
    Inherits System.Web.UI.Page
    Public Property sTitulo As String
    Public Property sAccion As String
    Public Property nidSubcategoria As Integer = 0
    Dim Redondeo As Decimal
    Public Property nIdCategoria As Integer
    Dim ImgCarpetaProductos As String = My.Settings.CarpetaProductos
    Dim ImgProductoDefault As String = My.Settings.imgProductoDefault
    Dim CarpetaImagen As String = ImgCarpetaProductos & "/" & ImgProductoDefault
    Dim HayError As Boolean = False
    Dim nidProducto As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            CalcularImportes()
        Else
            PanelDatos.Enabled = True

            sTitulo = Request.QueryString("TituloForm")
            sAccion = Request.QueryString("Accion")
            nidSubcategoria = Request.QueryString("idSubcategoria")
            nIdCategoria = Request.QueryString("idCategoria")
            nidProducto = Request.QueryString("idProducto")
            lblTitulo.Text = sTitulo
            Dim i As Integer = 0


            cboEstado.Items.Insert(0, New ListItem("Activo", 1))
            cboEstado.Items.Insert(1, New ListItem("No Activo", 0))
            cboEstado.DataTextField = "Activo"
            cboEstado.DataValueField = 1
            cboEstado.SelectedIndex = 0

            Dim listcateg As List(Of categoria) = New CD_Categoria().Listar(0)
            For item = 0 To listcateg.Count - 1
                cboCategoria.Items.Insert(item, New ListItem(listcateg(item).Nombre, listcateg(item).idCategoria))
            Next
            cboCategoria.SelectedIndex = 0

            'Dim listsubcateg As List(Of subcategoria) = New CD_Subcategoria().ListarSubcategoria(nIdCategoria)
            'For item = 0 To listsubcateg.Count - 1
            '    cboSubCategoria.Items.Insert(item, New ListItem(listsubcateg(item).Nombre, listsubcateg(item).idSubCategoria))
            'Next
            'cboSubCategoria.SelectedIndex = 0

            Dim listmarca As List(Of marca) = New CD_Marca().Listar(0)
            For item = 0 To listmarca.Count - 1
                cboMarcas.Items.Insert(item, New ListItem(listmarca(item).Nombre, listmarca(item).idMarca))
            Next
            cboMarcas.SelectedIndex = 0
            Dim listProvee As List(Of proveedor) = New CD_Proveedor().Listar(0)
            For item = 0 To listProvee.Count - 1
                cboProveedor.Items.Insert(item, New ListItem(listProvee(item).RazonSocial, listProvee(item).idProveedor))
            Next
            cboProveedor.SelectedIndex = 0
            txtidProducto.Value = 0
            txtCodigoBarras.Text = ""
            txtNombre.Text = ""
            txtPrecioCosto.Text = 0
            txtAlicuotaIVA.Text = 0
            lblImporteIVA.Text = 0
            txtGanancia.Text = 0
            lblImporteGanancia.Text = 0
            txtStockCritico.Text = 0
            'txtRedondeo.Text = 0
            txtIdProd.Text = 0
            txtNotas.Text = ""
            txtUltimaCompra.Text = Date.Today
            lblTotalCosto.Text = 0
            lblTotalPrecioVenta.Text = 0

            If sAccion <> "N" Then
                Dim TotalaRedondear As Decimal
                Dim listaprod As List(Of producto) = New CD_Producto().Listar(nidProducto)
                'Dim dia As DateTime = Convert.ToDateTime(listaprod(0).FechaUltimaCompra)
                Dim valorCelda As Integer
                If listaprod.Count > 0 Then
                    Dim redon As Decimal = 0
                    txtidProducto.Value = listaprod(0).idProducto
                    txtIdProd.Text = listaprod(0).idProducto
                    txtCodigoBarras.Text = listaprod(0).CodigoBarras
                    txtNombre.Text = listaprod(0).Nombre
                    txtPrecioCosto.Text = FormatNumber(listaprod(0).PrecioCosto, 2)
                    txtAlicuotaIVA.Text = FormatNumber(listaprod(0).AlicuotaIVA, 2)
                    lblImporteIVA.Text = FormatNumber(CDbl(txtPrecioCosto.Text) * (CDbl(txtAlicuotaIVA.Text) / 100), 2)
                    lblTotalCosto.Text = FormatNumber(CDbl(txtPrecioCosto.Text) + CDbl(lblImporteIVA.Text), 2)
                    txtGanancia.Text = FormatNumber(listaprod(0).Ganancia, 2)
                    lblImporteGanancia.Text = FormatNumber(CDbl(lblTotalCosto.Text) * (CDbl(txtGanancia.Text) / 100), 2)
                    lblTotalPrecioVenta.Text = FormatNumber(CDbl(lblTotalCosto.Text) + CDbl(lblImporteGanancia.Text), 2)
                    txtStockCritico.Text = listaprod(0).StockCritico
                    txtNotas.Text = listaprod(0).Notas


                    txtUltimaCompra.Text = listaprod(0).FechaUltimaCompra


                    For Each item As ListItem In cboCategoria.Items
                        If Integer.TryParse(listaprod(0).oCategoria.idCategoria, valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then
                                cboCategoria.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    For Each item As ListItem In cboMarcas.Items
                        If Integer.TryParse(listaprod(0).oMarca.idMarca, valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then

                                cboMarcas.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    For Each item As ListItem In cboProveedor.Items
                        If Integer.TryParse(listaprod(0).oProveedor.idProveedor, valorCelda) Then
                            ' Compara el valor de la celda con el valor del ítem del ComboBox.
                            If item.Value = valorCelda.ToString() Then

                                cboProveedor.SelectedValue = item.Value
                                Exit For
                            End If
                        End If
                    Next
                    For Each item As ListItem In cboEstado.Items

                        ' Compara el valor de la celda con el valor del ítem del ComboBox.
                        If item.Value = listaprod(0).Estado Then
                            txtIdEstado.Value = listaprod(0).Estado
                            cboEstado.SelectedValue = item.Value
                            Exit For
                        End If
                    Next

                    If sAccion = "E" Then
                        PanelDatos.Enabled = True
                    ElseIf sAccion = "B" Then
                        PanelDatos.Enabled = False
                    End If
                Else

                End If
            End If
        End If
    End Sub
    Public Shared Function Redondear(ByVal Importe As Double, ByVal redondeo As Double) As Double

        Dim ValorEntero As Double
        Dim redondeado As Double
        Dim unidad As Integer
        Dim decena As Integer
        Dim centena As Integer
        Dim Unidaddemil As Integer
        Dim Decenademil As Integer
        Dim Centenademil As Integer
        Dim millon As Integer


        ValorEntero = Int(Importe)
        redondeado = Len(Convert.ToInt32(redondeo)) - 1

        unidad = (ValorEntero Mod 10)
        decena = (((ValorEntero Mod 100 - ValorEntero Mod 10) / 10) * 10) + unidad
        centena = (((ValorEntero Mod 1000 - ValorEntero Mod 100) / 100) * 100) + decena
        Unidaddemil = (((ValorEntero Mod 10000 - ValorEntero Mod 1000) / 1000) * 1000) + centena
        Decenademil = (((ValorEntero Mod 100000 - ValorEntero Mod 10000) / 10000) * 10000) + Unidaddemil
        Centenademil = (((ValorEntero Mod 1000000 - ValorEntero Mod 100000) / 100000) * 100000) + Decenademil
        millon = (((ValorEntero Mod 10000000 - ValorEntero Mod 1000000) / 1000000) * 1000000) + Centenademil
        'ParteDecimal = decena + unidad
        Select Case redondeado
            Case = 0

            Case = 2
                '10
                ValorEntero = ValorEntero + (redondeo - unidad)
            Case = 3
                '100

                If (redondeo / 2) >= decena Then
                    ValorEntero = (redondeo - decena) * -1
                Else
                    ValorEntero = ValorEntero - (decena) * -1
                End If
            Case = 4
                '1.000
                If centena = 0 Then

                ElseIf centena >= redondeo Then
                    ValorEntero = 1000 - centena
                ElseIf centena < redondeo Then
                    ValorEntero = (1000 - centena)
                Else

                End If
                'ValorEntero = ValorEntero + (10000 - Unidaddemil)
            Case = 5
                ValorEntero = ValorEntero + (100000 - Decenademil)
            Case = 6
                ValorEntero = ValorEntero + (1000000 - Centenademil)
                '100.000
            Case = 7
                ValorEntero = ValorEntero + (10000000 - millon)
            Case Else
                ValorEntero = ValorEntero - decena
        End Select

        'If decena = 0 Then

        'ElseIf decena >= 50 Then
        '    ValorEntero = ValorEntero + (100 - decena)
        'ElseIf decena < 50 Then
        '    ValorEntero = ValorEntero - decena
        'Else

        'End If
        Return ValorEntero



    End Function
    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs)
        Dim script As String = ""
        Dim sExt As String
        Dim pahtFoto1 As String
        HayError = False
        If Trim(txtNombre.Text) = "" Then
            lblMensajeAtencion.Text = "El nombre del usuario no puede ser vacio"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowModal", "$(document).ready(function() { $('#MdlAtencion').modal('show'); });", True)
            HayError = True
            Exit Sub
        End If

        Dim objproducto As producto = New producto() With {
            .idProducto = Convert.ToInt32(txtidProducto.Value),
            .Nombre = UCase(txtNombre.Text),
            .CodigoBarras = UCase(txtCodigoBarras.Text),
            .oCategoria = New categoria() With {.idCategoria = Convert.ToInt32(cboCategoria.SelectedValue)},
            .oMarca = New marca() With {.idMarca = Convert.ToInt32(cboMarcas.SelectedValue)},
            .oProveedor = New proveedor() With {.idProveedor = Convert.ToInt32(cboProveedor.SelectedValue)},
            .PrecioCosto = txtPrecioCosto.Text,
            .AlicuotaIVA = txtAlicuotaIVA.Text,
            .Ganancia = txtGanancia.Text,
            .StockCritico = txtStockCritico.Text,
            .Notas = txtNotas.Text,
            .FechaCreacion = Date.Today,
            .Estado = Convert.ToInt32(cboEstado.SelectedValue)}
        Dim idgenerado As Integer = 0


        Using conn As New SqlClient.SqlConnection(conectar.Cadena)
            Dim query As String = ""
            Dim cmd As SqlCommand
            Dim mensaje As String = ""
            Dim resultado As Boolean = False
            mensaje = ""
            If Convert.ToInt32(txtidProducto.Value) = 0 Then
                idgenerado = New CD_Producto().Registrar(objproducto, mensaje)
            Else
                If Request.QueryString("Accion") = "E" Then
                    resultado = New CD_Producto().Editar(objproducto, mensaje)
                Else
                    resultado = New CD_Producto().Eliminar(objproducto, mensaje)
                End If
            End If

            If mensaje = "" Then
                Response.Redirect("producto_lista2.aspx")
            Else
                lblMensajeAtencion.Text = mensaje
                script = "$(function() { showModalMensaje(); }); "
                ScriptManager.RegisterStartupScript(Me, Page.GetType(), "btn1", script, True)
            End If
        End Using
    End Sub
    'Private Function ValidaExtension(ByVal sExtension As String) As Boolean
    '    Select Case sExtension
    '        Case ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".jfif"
    '            Return True
    '        Case Else
    '            Return False
    '    End Select
    'End Function
    Private Sub CalcularImportes()
        Dim catidadaRedondear As Decimal
        Dim redon As Decimal = 0
        lblImporteIVA.Text = FormatNumber(CDbl(txtPrecioCosto.Text) * (CDbl(txtAlicuotaIVA.Text) / 100), 2)
        lblTotalCosto.Text = FormatNumber(CDbl(txtPrecioCosto.Text) + CDbl(lblImporteIVA.Text), 2)
        lblImporteGanancia.Text = FormatNumber(CDbl(lblTotalCosto.Text) * (CDbl(txtGanancia.Text) / 100), 2)
        catidadaRedondear = FormatNumber(CDbl(lblTotalCosto.Text) + CDbl(lblImporteGanancia.Text), 2)
        lblTotalPrecioVenta.Text = catidadaRedondear
        'txtRedondeo.Text = FormatNumber(catidadaRedondear - CDbl(lblTotalPrecioVenta.Text), 2)
        'redon = catidadaRedondear - CDbl(lblTotalPrecioVenta.Text)
        'If redon >= 0 Then
        '    txtRedondeo.Text = FormatNumber(redon, 2) * -1
        'Else
        '    txtRedondeo.Text = FormatNumber(redon, 2)
        'End If
    End Sub


    Protected Sub txtPrecioCostoTextChanged(sender As Object, e As EventArgs) Handles txtPrecioCosto.TextChanged
        If IsPostBack Then
            If IsNumeric(txtPrecioCosto.Text) Then
                txtPrecioCosto.Text = FormatNumber(txtPrecioCosto.Text, 2)
            Else
                txtPrecioCosto.Text = FormatNumber(0, 2)
            End If
            CalcularImportes()
        End If
    End Sub

    Protected Function GuardarImagen(ByVal sFileupload As Object, ByVal sNombreImagen As String, ByVal Numerofoto As Integer, ByVal carpetadestino As String, ByVal img As Image) As String
        Dim targetDirectory As String = Server.MapPath(carpetadestino & "/")
        Dim nprod As Integer = Request.QueryString("idProducto")
        Dim nuevoNombreArchivo As String = ""


        If sNombreImagen = "sinfoto.jpg" Then

        Else

            ' Verificar si se ha seleccionado un archivo
            If Not sFileupload.HasFile Then
                Return sNombreImagen
                Exit Function
            Else
                Try
                    ' Obtener la extensión del archivo
                    Dim extension As String = Path.GetExtension(sFileupload.FileName).ToLower()

                    ' Validar la extensión de la imagen
                    If extension = ".jpg" OrElse extension = ".jpeg" OrElse extension = ".png" OrElse extension = ".gif" Then
                        ' Generar un nuevo nombre para la imagen
                        Dim nuevoNombre As String = txtidProducto.Value().PadLeft(5, "0"c) & "_" & Numerofoto.ToString().PadLeft(5, "0"c) & extension
                        sNombreImagen = nuevoNombre
                        ' Definir la ruta de la carpeta donde se guardará la imagen

                        If Not Directory.Exists(targetDirectory) Then
                            Directory.CreateDirectory(targetDirectory)
                        End If
                        ' Eliminar imagen anterior si no es la imagen por defecto
                        Dim rutaAnterior As String = Path.Combine(targetDirectory, sNombreImagen)
                        If sNombreImagen <> ImgProductoDefault AndAlso File.Exists(rutaAnterior) Then
                            Try
                                File.Delete(rutaAnterior)
                            Catch ex As Exception
                                lblMensajeAtencion.Text = "No se pudo eliminar la imagen anterior: " & ex.Message
                            End Try
                        End If

                        ' Combinar la ruta de la carpeta con el nuevo nombre de la imagen
                        Dim rutaCompleta As String = Path.Combine(targetDirectory, nuevoNombre)

                        ' Guardar la imagen en la carpeta especificada
                        sFileupload.SaveAs(rutaCompleta)

                        ' Mostrar la imagen cargada en el control Image
                        img.ImageUrl = carpetadestino & "/" & nuevoNombre

                        ' Mostrar un mensaje de éxito
                        lblMensajeAtencion.ForeColor = System.Drawing.Color.Red
                        lblMensajeAtencion.Text = ""
                    Else
                        ' Mostrar mensaje de error si el archivo no es una imagen válida
                        'lblMensajeAtencion.Text = "Error al procesar el archivo: " & ex.Message
                        lblMensajeAtencion.ForeColor = System.Drawing.Color.Red
                        sNombreImagen = ImgProductoDefault
                        lblMensajeAtencion.Text = "Solo se permiten archivos de imagen (.jpg, .jpeg, .png, .gif, webp)."
                    End If
                Catch ex As Exception
                    sNombreImagen = ImgProductoDefault
                    lblMensajeAtencion.ForeColor = System.Drawing.Color.Red
                    lblMensajeAtencion.Text = "Ocurrió un error al cargar la imagen: Solo se permiten archivos de imagen (.jpg, .jpeg, .png, .gif, webp). " & ex.Message
                Finally
                    lblMensajeAtencion.ForeColor = System.Drawing.Color.Red
                    ' Manejar cualquier error que ocurra
                    'sNombreImagen = "sinfoto.jpg"
                    lblMensajeAtencion.Text = ""
                End Try
            End If
            If lblMensajeAtencion.Text <> "" Then
                Dim Script As String = "$(function() { showModalMensaje(); }); "
                ScriptManager.RegisterStartupScript(Me, Page.GetType(), "btn1", Script, True)
            End If

        End If
        Return sNombreImagen
    End Function
    Private Function ValidaExtension(ByVal sExtension As String) As Boolean
        Select Case sExtension
            Case ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".jfif", ".wepb"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function SegunRedondeo(ByVal numero As Decimal, ByVal Redondeo As Integer) As Integer
        ' Extraer las centenas y las decenas del número
        Dim centenas As Integer = CInt(Math.Floor(numero / Redondeo)) * Redondeo
        Dim decenas As Integer = CInt(numero Mod Redondeo)

        ' Si la decena es 50 o más, redondear hacia la centena superior
        If decenas >= 50 Then
            Return centenas + Redondeo
        Else
            ' Si la decena es menor a 50, redondear hacia la centena inferior
            Return centenas
        End If
    End Function
End Class