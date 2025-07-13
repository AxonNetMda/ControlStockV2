<%@ Page Title="Perfil" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.vb" Inherits="capaAdministracion.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mi Perfil</h2>
    <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" />

    <div class="mb-3">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="txtMovil">Móvil</label>
        <asp:TextBox ID="txtMovil" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="txtEmail">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label for="ddlRol">Rol</label>
        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
    </div>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" />
</asp:Content>