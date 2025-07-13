<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="recuperarclave.aspx.vb" Inherits="capaAdministracion.recuperarclave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - Verificacion de cuenta</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
    <Scripts>
        <asp:ScriptReference Name="MsAjaxBundle" />
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
        <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
        <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
        <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
        <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
        <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
        <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
        <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
        <asp:ScriptReference Name="WebFormsBundle" />
    </Scripts>
</asp:ScriptManager>
            <nav class="navbar navbar-dark bg-dark">
            <div class="container">
                <ul class="navbar-nav">
                        <!-- Imagen redonda de usuario -->
                        <li class="nav-item">
                            <img src='<%: ResolveUrl("~/imagenes/logo.png") %>' class="rounded-circle" style="width: 60px; height: 60px; object-fit: cover;" alt="Usuario" />
                            <a class="navbar-brand" runat="server" href="~/Account/login.aspx">RECUPERAR CONTRASEÑA</a>

                        </li>
                    </ul>
            </div>
        </nav>


        <div class="d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <asp:Panel runat="server" CssClass="card p-4 shadow" style="width: 100%; max-width: 400px;">
            <!-- Campos de login -->
                <h2 class="text-center">VERIFIQUE SU CORREO</h2>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
              <div class="mb-3">
                <asp:Label AssociatedControlID="txtEmail" runat="server" Text="Razón Social" />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control text-capitalize" width="400px" />
             </div>
             <asp:LinkButton ID="btnReenviar" runat="server" Text="Reenviar correo de verificacion" OnClick="btnReenviar_Click" CssClass="w-100" />
          </asp:Panel>        
        </div>    
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</html>
