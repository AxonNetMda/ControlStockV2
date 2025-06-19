<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Panel.aspx.vb" Inherits="capaAdministracion.Panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	    <h2>Panel de Administración</h2>
    <p>Accediste como <strong><%: Context.User.Identity.Name %></strong></p>
    <p>Desde aquí podrás gestionar usuarios, contenido, reportes, etc.</p>

</asp:Content>
