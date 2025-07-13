Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls
Imports capaAdministracion.capaDatos

Partial Public Class Tienda
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarProductos()
        End If
    End Sub

    Private Function CalcularPrecioVenta(precioCosto As Decimal, iva As Decimal, ganancia As Decimal) As Decimal
        Dim base = precioCosto + (precioCosto * ganancia / 100)
        Return base + (base * iva / 100)
    End Function

    Private Sub CargarProductos()
        Dim connStr = conectar.Cadena
        Dim sql = "
                SELECT 
                    p.idProducto, p.Nombre, p.PrecioCosto, p.AlicuotaIVA, p.Ganancia, p.StockCritico,
                    pf.rutacarpeta, pf.nombrefoto
                FROM dbo.producto p
                LEFT JOIN dbo.producto_foto pf 
                    ON p.idProducto = pf.idproducto AND pf.nombrefoto <> 'sinfoto.jpg'
                WHERE p.Estado = 1
                ORDER BY p.Nombre"

        Dim dt As New DataTable()
        Using conn As New SqlConnection(connStr)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Dim productos = From r In dt.AsEnumerable()
                        Group r By id = r.Field(Of Integer)("idProducto"),
                                 nombre = r.Field(Of String)("Nombre"),
                                 pcosto = r.Field(Of Decimal)("PrecioCosto"),
                                 iva = r.Field(Of Decimal)("AlicuotaIVA"),
                                 gan = r.Field(Of Decimal)("Ganancia"),
                                 stock = r.Field(Of Decimal)("StockCritico")
                        Into Group

        For Each grupo In productos
            Dim idP = grupo.id
            Dim nombre = grupo.nombre
            Dim precioVenta = CalcularPrecioVenta(grupo.pcosto, grupo.iva, grupo.gan)
            Dim stock = grupo.stock

            Dim fotos = grupo.Group.
                Where(Function(r) Not r.IsNull("nombrefoto")).
                Select(Function(r) $"{r("rutacarpeta")}/{r("nombrefoto")}").ToList()

            ' Crear columna
            Dim divCol As New HtmlGenericControl("div")
            divCol.Attributes("class") = "col-md-4 mb-4"

            ' Card
            Dim divCard As New HtmlGenericControl("div")
            divCard.Attributes("class") = "card h-100"

            ' Carrusel
            Dim carouselId = "carousel" & idP
            Dim divCarrusel As New HtmlGenericControl("div")
            divCarrusel.Attributes("id") = carouselId
            divCarrusel.Attributes("class") = "carousel slide"
            divCarrusel.Attributes("data-bs-ride") = "carousel"

            Dim divInner As New HtmlGenericControl("div")
            divInner.Attributes("class") = "carousel-inner"

            For i As Integer = 0 To fotos.Count - 1
                Dim divItem As New HtmlGenericControl("div")
                divItem.Attributes("class") = If(i = 0, "carousel-item active", "carousel-item")

                Dim aLink As New HtmlAnchor()
                aLink.HRef = $"Ficha.aspx?IdProducto={idP}"

                Dim img As New HtmlGenericControl("img")
                img.Attributes("src") = fotos(i)
                img.Attributes("class") = "d-block w-100"
                img.Attributes("alt") = nombre

                aLink.Controls.Add(img)
                divItem.Controls.Add(aLink)
                divInner.Controls.Add(divItem)
            Next

            If fotos.Count > 1 Then
                Dim prev As New HtmlGenericControl("button")
                prev.Attributes("class") = "carousel-control-prev"
                prev.Attributes("type") = "button"
                prev.Attributes("data-bs-target") = "#" & carouselId
                prev.Attributes("data-bs-slide") = "prev"
                prev.InnerHtml = "<span class='carousel-control-prev-icon'></span><span class='visually-hidden'>Anterior</span>"

                Dim nextBtn As New HtmlGenericControl("button")
                nextBtn.Attributes("class") = "carousel-control-next"
                nextBtn.Attributes("type") = "button"
                nextBtn.Attributes("data-bs-target") = "#" & carouselId
                nextBtn.Attributes("data-bs-slide") = "next"
                nextBtn.InnerHtml = "<span class='carousel-control-next-icon'></span><span class='visually-hidden'>Siguiente</span>"

                divCarrusel.Controls.Add(prev)
                divCarrusel.Controls.Add(nextBtn)
            End If

            divCarrusel.Controls.Add(divInner)

            ' Body
            Dim divBody As New HtmlGenericControl("div")
            divBody.Attributes("class") = "card-body text-center"
            divBody.InnerHtml = $"<h5 class='card-title'>{nombre}</h5><p class='text-success fw-bold'>${precioVenta:F2}</p><p>Stock: {stock}</p>"

            ' Footer
            Dim divFooter As New HtmlGenericControl("div")
            divFooter.Attributes("class") = "card-footer text-center"
            divFooter.InnerHtml = $"<button class='btn btn-primary' onclick='agregarAlCarrito({idP},{precioVenta:F2})'>Agregar al carrito</button>"

            divCard.Controls.Add(divCarrusel)
            divCard.Controls.Add(divBody)
            divCard.Controls.Add(divFooter)

            divCol.Controls.Add(divCard)
            productosContainer.Controls.Add(divCol)
        Next
    End Sub
End Class
