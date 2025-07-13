<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="producto_lista_ABM.aspx.vb" Inherits="capaAdministracion.producto_lista_ABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script src="Scripts/WebForms/MSAjax/MicrosoftAjax.js"></script>
   <script src="Scripts/WebForms/MSAjax/MicrosoftAjaxWebForms.js"></script>
   <link href="css/styles.css" rel="stylesheet" />
    <link href="css/paraimagenes.css" rel="stylesheet" />
    <link href="css/check_css.css" rel="stylesheet" />
    <script type="text/javascript" src="js/plugins/bootstrap/bootstrap-file-input.js"></script>
    <script src="js/datatables/dataTables.fixedHeader.min.js"></script>
    <script src="js/datatables/jquery.dataTables.min.js"></script>
    <script src="js/datatables/jquery3701.js"></script>
    <link href="css/datatables/fixedHeader.dataTables.min.css" rel="stylesheet" />
    <link href="css/datatables/jquery.dataTables.min.css" rel="stylesheet" />  

    <div class="container">
         <div class="card shadow-lg border-0 rounded-lg mt-10">
                <div class="card-header bg-warning text-black">
                    <h4 class="text-center font-weight-light my-1"><strong><asp:Label runat="server" ID="lblTitulo" ></asp:Label></strong></h4>                                   
                </div>                       
                <div class="card-body justify-content-center"> 
                    <div class="row justify-content-center">                            
                       <asp:Panel runat="server" ID="PanelDatos" CssClass="justify-content-center">
                            <asp:HiddenField runat="server" ID="txtidProducto"/>
                            <div class="row">  
                                    <div class="col-md-2">
                                        <div class="form-group">                                                    
                                                <div class="form-floating mb-3">
                                                    <asp:label runat="server" class="form-control " id="txtIdProd" Width="200"></asp:label>
                                                    <label class="text-dark" for="txtIdProd">Id</label>                                   
                                                </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">                                                    
                                                <div class="form-floating mb-3">
                                                    <asp:TextBox runat="server" class="form-control " id="txtCodigoBarras" Width="400"></asp:TextBox>
                                                    <label class="text-dark" for="txtCodigoBarras"><i class="fas fa-user fa-barcode"></i>  Codigo de Barras</label>                                   
                                                </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                                <div class="form-floating mb-3">
                                                    <asp:TextBox runat="server" class="form-control text-capitalize" id="txtNombre"></asp:TextBox>
                                                    <label for="txtNombre">Nombre del producto</label>                                   
                                                </div>
                                        </div>

                                    </div>
                                    <div class="col-md-4">                                       
                                        <div class="form-group">
                                            <div class="form-floating mb-3">
                                                <asp:DropDownList runat="server" CssClass="form-control" id="cboCategoria"></asp:DropDownList>
                                                <label for="cboCategoria">Categoria</label>                                   
                                            </div>
                                        </div>  
                                        <div class="form-group">
                                            <div class="form-floating mb-3">
                                                <asp:DropDownList runat="server" CssClass="form-control" id="cboMarcas" ></asp:DropDownList>
                                                <label for="cboMarcas">Marca</label>                                   
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-floating mb-3">
                                                <asp:DropDownList runat="server" CssClass="form-control bg-warning bg-opacity-25" id="cboProveedor" ></asp:DropDownList>
                                                <label for="cboProveedor">Proveedor</label>                                   
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">   
                                        <div class="form-group">
                                            <div class="form-floating mb-3">
                                                 <asp:label runat="server" cssclass="form-control" id="txtUltimaCompra"  placeholder="Fecha ultima compra" Width="200"></asp:label>
                                                 <label for="txtUltimaCompra">Fecha ultima compra</label> 
                                                 <asp:HiddenField runat="server" ID="HiddenField4" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-floating mb-3">
                                                 <asp:TextBox runat="server" class="form-control" id="txtNotas" placeholder="Notas"></asp:TextBox>
                                                 <label for="txtNotas">Notas</label>                                   
                                            </div>
                                       </div>
                                        <div class="form-group">        
                                            <div class="form-floating mb-3">
                                                    <asp:TextBox runat="server" class="form-control text-end" id="txtStockCritico" Width="200"></asp:TextBox>
                                                    <label for="txtStockCritico">Stock critico</label>                                   
                                            </div>
                                         </div>   
                                        <div class="form-group">         
                                               <div class="form-floating mb-3">
                                                <asp:DropDownList runat="server" class="form-control" id="cboEstado" placeholder="Estado" Width="200"></asp:DropDownList>
                                                <label for="cboEstado">Estado</label> 
                                                <asp:HiddenField runat="server" ID="txtIdEstado" />
                                             </div>      
                                        </div>  

                                    </div>
                            </div>       
                            <hr class="border-success" style="border-width: medium; border-style: solid" /> 
                            <div class="col-md-12">                                        
                                    <div class="card-header bg-warning text-black">
                                         <h6 class="text-center font-weight-light my-1"><strong>CONFIGURACION DEL PRECIO DE VENTA</strong></h6>    
                                        </div>
                                    <br />
                                    <asp:UpdatePanel runat="server">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtPrecioCosto" EventName="TextChanged" /> 
                                                    <asp:AsyncPostBackTrigger ControlID="txtAlicuotaIVA" EventName="TextChanged" />   
                                                    <asp:AsyncPostBackTrigger ControlID="txtGanancia" EventName="TextChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="txtstockcritico" EventName="TextChanged" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <div class="row">
                                                            <div class="col-md-3">                                                     
                                                                <div class="form-group">                                                                
                                                                    <div class="form-floating mb-3">
                                                                        <asp:TextBox runat="server" class="form-control" id="txtPrecioCosto" Width="200" AutoPostBack="true"></asp:TextBox>
                                                                        <label for="txtPrecioCosto">Precio de Costo</label>                                   
                                                                    </div>                                               
                                                                    <div class="form-floating mb-3">
                                                                        <asp:TextBox runat="server" class="form-control" id="txtAlicuotaIVA" Width="200"  AutoPostBack="true" ></asp:TextBox>
                                                                        <label for="txtAlicuotaIVA">Alicuota IVA %</label>                                   
                                                                    </div>
                                                                    <div class="form-floating mb-3">
                                                                        <asp:label runat="server" cssclass="form-control  bg-opacity-25" id="lblImporteIVA" Width="200"></asp:label>
                                                                        <label for="lblImporteIVA">importe IVA $</label>                                   
                                                                    </div>
                                                                    <div class="form-floating mb-3">
                                                                        <asp:label runat="server" class="form-control bg-dark text-white bg-opacity-15 border-1 border-dark" id="lblTotalCosto" AutoPostBack="true" Width="200" Font-Bold="true" Text="0" BorderColor="Black" BorderWidth="1"></asp:label>
                                                                        <label class=" text-white" for="lblTotalCosto">Total Precio Costo</label>                                   
                                                                    </div>
                                                                </div>                                         
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <div class="form-floating mb-3">
                                                                        <asp:TextBox runat="server" class="form-control" id="txtGanancia" AutoPostBack="true" Width="200"></asp:TextBox>
                                                                        <label for="txtGanancia">Ganancia %</label>                                   
                                                                    </div>
                                                                    <div class="form-floating mb-3">
                                                                        <asp:label runat="server" class="form-control bg-dark text-white bg-opacity-15 border-1 border-dark" id="lblImporteGanancia" AutoPostBack="true"  Width="200"></asp:label>
                                                                        <label for="lblImporteGanancia" class="text-white">importe Ganancia $</label>                                   
                                                                    </div>
                                                                    <div class="form-floating mb-3 ">
                                                                        <asp:label runat="server" cssclass="form-control bg-success text-white align-content-end" id="lblTotalPrecioVenta" AutoPostBack="true"  Width="200" Text="0" Font-Bold="true" BorderColor="Black" BorderWidth="1"></asp:label>
                                                                        <label class="text-white" for="lblTotalPrecioVenta">Precio de Venta</label>                                   
                                                                    </div>
                                                                </div>   
                                                            </div>                                                       
                                                    </div> 
                                                </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>                                                                   
                            <hr>
                        </asp:panel> 
                       <div class="card-footer">
                             <footer class="py-4 bg-light mt-auto">
                                <div class="container-fluid px-4">
                                    <div class="d-flex align-items-end justify-content-between small">
                                        <asp:button runat="server" id="Button1" cssclass="btn btn-success" Text="Cancelar" PostBackUrl="~/producto_lista.aspx?idproducto=0&Titulo=''&Accion=''" />
                                        <asp:button runat="server" Id="Button2" cssclass="btn btn-primary" Text="Aceptar " onclick="BtnGuardar_Click" />
                                    </div>
                                </div>
                            </footer>         
                      </div>     
                    </div>
                </div>
         </div>
    </div>


                                                  
                                       
            
    <%--Abrir modal para Validar respuesta                                                                                                                                                                      --%>
<div class="modal fade" id="MdlAtencion" tabindex="-1" role="dialog" aria-labelledby="myMdlAtencion" data-bs-backdrop="static" style="display:none">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">ATENCION</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button> 
      </div>
      <div class="modal-body text-black">
            <asp:Label runat="server" id="lblMensajeAtencion" CssClass="form-label" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>

      </div>
    </div>
  
  </div>
</div>
        <script>

		
           function showModalMensaje() {
			   $("#MdlAtencion").modal("show");
             }

        </script>
</asp:Content>
