<%@ Page Title="Empresa Editar" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Empresa_Editar.aspx.vb" Inherits="capaAdministracion.Empresa_Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="layoutSidenav_content">
           <div class="row justify-content-center">
                <div class="col-lg-8">                                     
                    <div class="card shadow-lg border-0 rounded-lg mt-8 ">
                        <div class="card-header  bg-warning text-black">
                            <h3 class="text-center font-weight-light my-2"><strong><asp:Label runat="server" ID="lblTitulo" >Datos Empresa</asp:Label></strong></h3>                                   
                        </div>                                            
                        <div class="card-body"> 
<%--                            <asp:Panel runat="server" ID="PanelDatos" CssClass="align-content-center">--%>
                            <div class="row">
                                <div class="col-md-6">
                                   <asp:HiddenField runat="server" ID="txtidEmpresa"/>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">                                        
                                            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                                            <label for="txtRazonSocial">Razón Social</label>
                                         </div>
                                    </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">   
                                            <asp:TextBox ID="txtNombreComercial" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                                            <label for="txtNombreComercial">Nombre Comercial:</label>
                                         </div>
                                    </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">  
                                             <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                            <label for="txtDireccion">Dirección:</label>                                        
                                         </div>
                                    </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">
                                             <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>                                       
                                            <label for="txtCodigoPostal">Código Postal:</label>
                                            </div>
                                    </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">  
                                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
                                            <label for="txtLocalidad">Localidad:</label>
                                         </div>
                                    </div>
                                    <div class="form-group">
                                             <div class="form-floating mb-3">
                                                 <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control"></asp:TextBox>
                                                 <label for="txtProvincia">Provincia:</label>
                                              </div>
                                        </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">
                                             <asp:TextBox ID="txtPais" runat="server" CssClass="form-control"></asp:TextBox>
                                             <label for="txtPais">Pais:</label>
                                          </div>
                                    </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">
                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                                            <label for="txtTelefono">Teléfono:</label>
                                          </div>  
                                    </div>
                                    <div class="form-group">
                                         <div class="form-floating mb-3">
                                           <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                             <label for="txtEmail">Email:</label>
                                           </div> 
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                         <div class="form-floating mb-3">   
                                            <asp:TextBox ID="txtInicioActividades" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                            <label for="txtInicioActividades">Inicio de Actividades:</label>
                                         </div>
                                    </div>


                                    <div class="form-group">
                                     <div class="form-floating mb-3">   
                                        <asp:DropDownList ID="cboCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <label for="cboCategoria">Categoria:</label>
                                     </div>
                                </div>
                                    <div class="form-group">
                                      <div class="form-floating mb-3">   
                                         <asp:DropDownList ID="cboTipoResponsable" runat="server" CssClass="form-control"></asp:DropDownList>
                                         <label for="cboTipoResponsable">Tipo Responsable:</label>
                                      </div>
                                 </div>
                                    <div class="form-group">
                                      <div class="form-floating mb-3">   
                                         <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
                                         <label for="cboTipoDocumento">Tipo documento:</label>
                                      </div>
                                  <div class="form-group">
                                     <div class="form-floating mb-3">   
                                        <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                                        <label for="txtNumeroDocumento">N° :</label>
                                    </div>
                                </div>
                               </div>
                                    <div class="form-group">
                                     <div class="form-floating mb-3" style="display:none">   
                                        <asp:DropDownList ID="cboEsDemo" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                        <label for="cboEsDemo">Es Demo:</label>
                                     </div>
                                </div>
                                    <div class="form-group" style="display:none">
                                     <div class="form-floating mb-3">   
                                        <asp:TextBox ID="txtFechaInicioDemo" runat="server" TextMode="Date" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <label for="txtFechaInicioDemo">Inicio demo:</label>
                                     </div>
                                    </div>  
                                     <div class="form-group" style="display:none">
                                      <div class="form-floating mb-3">   
                                         <asp:TextBox ID="txtCantidadDiasDemo" runat="server" TextMode="number" CssClass="form-control" Enabled="false"></asp:TextBox>
                                         <label for="txtCantidadDiasDemo">Dias demo:</label>
                                      </div>
                                     </div>  
                                    <div class="form-group" style="display:none">
                                     <div class="form-floating mb-3">   
                                        <asp:TextBox ID="txtFechaAlta" runat="server" TextMode="Date" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <label for="txtFechaAlta">Fecha Alta:</label>
                                     </div>
                                </div>                                  
                                    <div class="form-group" style="display:none">
                                     <div class="form-floating mb-3">   
                                        
                                        <asp:DropDownList ID="cboEstado" runat="server" CssClass="form-control" />  
                                        <label for="cboEstado">Estado </label>
                                    </div>
                                </div>
                                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                <asp:Button ID="BtnVolver" CssClass="btn btn-success" runat="server" Text="Volver" PostBackUrl="~/Account/Panel.aspx?id=<%=Session('idEmpresa') %>"/>
<%--                             </asp:Panel>--%>
                              </div>
                            </div>
                        </div>
                    </div>
                </div>
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
