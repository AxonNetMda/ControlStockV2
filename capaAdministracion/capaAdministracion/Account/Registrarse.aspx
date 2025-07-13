<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registrarse.aspx.vb" Inherits="capaAdministracion.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

 <div class="d-flex justify-content-center">

     <div class="w-100" style="max-width: 400px;">
    <h2>Registro de nuevo usuario</h2>
    <div class="mb-3">
        <asp:Label AssociatedControlID="txtNombre" runat="server" Text="Nombre completo" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <asp:Label AssociatedControlID="txtMovil" runat="server" Text="Movil" />
        <asp:TextBox ID="txtMovil" runat="server" CssClass="form-control" />
    </div>

    <div class="mb-3">
        <asp:Label AssociatedControlID="txtEmail" runat="server" Text="Email" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <asp:Label AssociatedControlID="txtClave" runat="server" Text="Contraseña" />
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control" />
    </div>
     <div class="mb-3">
     <asp:Label AssociatedControlID="txtClaveConfirmar" runat="server" Text="Contraseña" />
     <asp:TextBox ID="txtClaveConfirmar" runat="server" TextMode="Password" CssClass="form-control" />
 </div>
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-success" />
    <asp:Label runat="server" ID="lblMensaje" text=""></asp:Label>
</div>
     </div>

<!-- Modal Bootstrap -->
<div class="modal fade" id="modalMensaje" tabindex="-1" aria-labelledby="modalMensajeLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header bg-primary text-white">
        <h5 class="modal-title" id="modalMensajeLabel"></h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
      </div>
      <div class="modal-body" id="modalMensajeCuerpo"></div>
    </div>
  </div>
</div>


<script>
	function mostrarModal(titulo, mensaje) {
		document.getElementById('modalMensajeLabel').innerText = titulo;
		document.getElementById('modalMensajeCuerpo').innerText = mensaje;
		var myModal = new bootstrap.Modal(document.getElementById('modalMensaje'), {});
		myModal.show();
	}
</script>

</asp:Content>
