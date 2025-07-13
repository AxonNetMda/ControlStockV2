Public Class producto
    Public Property idProducto As Integer
    Public Property CodigoBarras As String
    Public Property Nombre As String
    Public Property oCategoria As categoria
    Public Property oMarca As marca
    Public Property oProveedor As proveedor
    Public Property PrecioCosto As Decimal
    Public Property AlicuotaIVA As Decimal
    Public Property Ganancia As Decimal
    Public Property StockCritico As Integer
    Public Property Notas As String
    Public Property FechaUltimaCompra As Date
    Public Property FechaCreacion As Date
    Public Property FechaUltimaActualizacion As Date
    Public Property Estado As Boolean
    Public Property PrecioVenta As Decimal

End Class
