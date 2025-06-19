<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmar.aspx.vb" Inherits="capaAdministracion.Confirmar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Confirmar Cuenta</title>
    <meta charset="utf-8" />
    <script type="text/javascript">
        setTimeout(function () {
            window.location.href = '~/Default.aspx';
        }, 3000); // redireccionar en 3 segundos
    </script></head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMensaje" runat="server" Text="Procesando confirmación..."></asp:Label>
        </div>
    </form>
</body>
</html>
