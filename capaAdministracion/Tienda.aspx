<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tienda.aspx.vb" Inherits="Tienda" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Catálogo Tienda</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">
            <div class="row">
                <asp:PlaceHolder ID="productosContainer" runat="server" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        let cantidadCarrito = 0;
        function agregarAlCarrito(idProducto, precio) {
            cantidadCarrito++;
            const xhr = new XMLHttpRequest();
            xhr.open("POST", "GuardarEnCarrito.aspx", true);
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xhr.send(`idProducto=${idProducto}&precio=${precio}&cantidad=1`);
        }
    </script>
</body>
</html>
