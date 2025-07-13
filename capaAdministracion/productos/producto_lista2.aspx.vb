Imports System.Data
Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos

Public Class producto_lista2
    Inherits System.Web.UI.Page
    Public Property filtro As String


    ' Cadena de conexión
    Private ReadOnly CADENA2 As String = conectar.Cadena

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        If Not Page.IsPostBack Then
            If Request.QueryString("filtro") = "0" Then
                filtro = ""
            Else
                filtro = Request.QueryString("filtro")
            End If
            CargarProductos()
            'Dim scomando As String = "SELECT ... FROM ... WHERE ..." ' Tu SQL aquí
            'sqlProducto.SelectCommand = scomando
        End If
    End Sub

    Private Sub CargarProductos()
        Dim consulta As String = "
            SELECT producto.idProducto, producto.CodigoBarras, producto.Nombre, producto.idCategoria, producto.idSubCategoria,
                    producto.idMarca, producto.idProveedor, producto.PrecioCosto, producto.AlicuotaIVA, producto.Ganancia, 
                    dbo.preciodeventa2(PrecioCosto, AlicuotaIVA, Ganancia) as PrecioVenta, producto_categoria.Nombre as NombreCategoria, 
                    producto.Redondeo, dbo.producto.StockCritico, producto.Estado, producto_marca.Nombre AS NombreMarca, proveedor.RazonSocial,
                    dbo.producto.MostrarCatalogo
                    FROM dbo.producto
                    LEFT JOIN producto_categoria ON producto.idcategoria = producto_categoria.idCategoria
                    LEFT JOIN producto_marca ON producto.idMarca = producto_marca.idMarca
                    LEFT JOIN proveedor ON producto.idProveedor = proveedor.idProveedor " & filtro & " ORDER BY producto.Nombre"


        Using conn As New SqlConnection(CADENA2)
            Using cmd As New SqlCommand(consulta, conn)
                Using da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Guardar en ViewState o Session si lo necesitás luego
                    ViewState("Producto") = dt

                    ' Vincular el DataTable al SqlDataSource si no lo hacés directamente en el markup
                    sqlProducto.SelectCommand = consulta
                    sqlProducto.DataBind()
                End Using
            End Using
        End Using
    End Sub
End Class


