<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="capaAdministracion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center" style="min-height: 80vh;">
    <asp:Panel runat="server" CssClass="card p-4 shadow" style="width: 100%; max-width: 400px;">
        <!-- Campos de login -->
            <h2 class="text-center">Iniciar Sesión</h2>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtUsuario" runat="server" Text="Usuario" />
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label AssociatedControlID="txtClave" runat="server" Text="Contraseña" />
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary w-100" />
            <br />
            <asp:LinkButton runat="server" ID="lnkOlvideContraseña" Text="Olvide la contraseña" OnClick="lnkOlvideContraseña_Click"></asp:LinkButton>
      </asp:Panel>        
    </div>
</asp:Content>
