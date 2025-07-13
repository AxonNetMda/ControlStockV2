<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Empresa_Datos.aspx.vb" Inherits="capaAdministracion.Empresa_Fiscales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<%--    <script src="https://sdk.mercadopago.com/js/v2"></script>
    <script>
        const mp = new MercadoPago("YOUR_PUBLIC_KEY");
    </script>--%>
    <style>
        .mt-3.mb-2 {
            margin-top: 1rem;
            margin-bottom: 0.5rem;
        }
    </style>
<div class="w-100">
    <div class="d-flex justify-content-between mt-3">
        <h2>Datos Empresa</h2>
         <a id="btnVolver" class="btn btn-primary" href="../Account/Panel.aspx">Volver</a>
        </div>
        <!-- Botones de navegación -->
       <div class="d-flex justify-content-between mt-3">
           <button id="btnAnterior" class="btn btn-success btn-sm" type="button" style="display:none;">Anterior</button>
           <div>
               <button id="btnSiguiente" class="btn btn-success btn-sm p-1" type="button">Siguiente</button>
<%--               <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary btn-sm p-1" Text="Registrar" OnClick="btnRegistrar_Click" Style="display:none;" />--%>
           </div>
       </div>

        <!-- Navegación entre tabs -->
        <ul class="nav nav-tabs" id="myTab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="DatosComerciales-tab" data-bs-target="#DatosComerciales" type="button" role="tab" aria-controls="DatosComerciales" aria-selected="true">Datos Comerciales</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="sucursal-tab" data-bs-target="#sucursal" type="button" role="tab" aria-controls="sucursal" aria-selected="false">Casa Central</button>
            </li>
             <li class="nav-item" role="presentation">
                <button class="nav-link" id="pago-tab" data-bs-target="#pago" type="button" role="tab" aria-controls="pago" aria-selected="false">Formas de Pago</button>
            </li>
        </ul>
        <!-- Contenido de las pestañas -->
        <div class="tab-content">
            <div class="tab-pane active" id="DatosComerciales" role="tabpanel" aria-labelledby="DatosComerciales-tab">
                <div class="container w-100 p-5">
                    <!-- contenido de Datos Comerciales -->
                    <div class="row">
                        <div class="col-md-6">
                            <asp:HiddenField ID="txtIdEmpresa" runat="server" />
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtNombreComercial" runat="server" Text="Nombre Comercial" Font-Bold="true" />
                                <asp:TextBox ID="txtNombreComercial" runat="server" CssClass="form-control text-capitalize bg-warning-subtle" width="400px" requerid="true" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtRazonSocial" runat="server" Text="Razón Social" />
                                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control text-capitalize bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtDireccionEmpresa" runat="server" Text="Dirección" />
                                <asp:TextBox ID="txtDireccionEmpresa" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtCodigoPostalEmpresa" runat="server" Text="Código Postal" />
                                <asp:TextBox ID="txtCodigoPostalEmpresa" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtLocalidadEMpresa" runat="server" Text="Localidad" />
                                <asp:TextBox ID="txtLocalidadEmpresa" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtProvinciaEmpresa" runat="server" Text="Provincia" />
                                <asp:TextBox ID="txtProvinciaEmpresa" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtPaisEmpresa" runat="server" Text="País" />
                                <asp:TextBox ID="txtPaisEmpresa" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>

                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtEmailEmpresa" runat="server" Text="Email Eapresa" />
                                <asp:Textbox ID="txtEmailEmpresa" runat="server" TextMode="Email" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div> <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtTelefonoEmpresa" runat="server" Text="Telefono" />
                                 <asp:Textbox ID="txtTelefonoEmpresa" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                             </div>
                            <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtCelular" runat="server" Text="Movil" />
                                 <asp:Textbox ID="txtCelular" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                             </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboTipoDocumento" runat="server" Text="Tipo de Documento" />
                                <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtNumeroDocumento" runat="server" Text="N° de documento" />
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboTipoResponsable" runat="server" Text="Tipo de Responsable" />
                                <asp:DropDownList ID="cboTipoResponsable" runat="server" CssClass="form-control bg-warning-subtle"  width="400px"/>
                            </div>
                        <div class="mb-3">
                            <asp:Label AssociatedControlID="txtFechaInicioActividades" runat="server" Text="Inicio Actividades" />
                            <asp:textbox ID="txtFechaInicioActividades" runat="server" TextMode="Date" CssClass="form-control bg-warning-subtle"  width="400px"/>
                        </div>
                        </div>
                        <!-- txtNombreComercial -->
                        <asp:RequiredFieldValidator ID="rfvNombreComercial" runat="server"
                            ControlToValidate="txtNombreComercial"
                            ErrorMessage="El nombre comercial es obligatorio."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtRazonSocial -->
                        <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server"
                            ControlToValidate="txtRazonSocial"
                            ErrorMessage="La razón social es obligatoria."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtDireccionEmpresa -->
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
                            ControlToValidate="txtDireccionEmpresa"
                            ErrorMessage="La dirección es obligatoria."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtCodigoPostalEmpresa -->
                        <asp:RequiredFieldValidator ID="rfvCP" runat="server"
                            ControlToValidate="txtCodigoPostalEmpresa"
                            ErrorMessage="El código postal es obligatorio."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtLocalidadEmpresa -->
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server"
                            ControlToValidate="txtLocalidadEmpresa"
                            ErrorMessage="La localidad es obligatoria."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtProvinciaEmpresa -->
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server"
                            ControlToValidate="txtProvinciaEmpresa"
                            ErrorMessage="La provincia es obligatoria."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtPaisEmpresa -->
                        <asp:RequiredFieldValidator ID="rfvPais" runat="server"
                            ControlToValidate="txtPaisEmpresa"
                            ErrorMessage="El país es obligatorio."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- cboTipoDocumento -->
                        <asp:RequiredFieldValidator ID="rfvTipoDoc" runat="server"
                            ControlToValidate="cboTipoDocumento"
                            InitialValue=""
                            ErrorMessage="Debe seleccionar un tipo de documento."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- txtNumeroDocumento -->
                        <asp:RequiredFieldValidator ID="rfvNumeroDoc" runat="server"
                            ControlToValidate="txtNumeroDocumento"
                            ErrorMessage="El número de documento es obligatorio."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />

                        <!-- cboTipoResponsable -->
                        <asp:RequiredFieldValidator ID="rfvTipoResponsable" runat="server"
                            ControlToValidate="cboTipoResponsable"
                            InitialValue=""
                            ErrorMessage="Debe seleccionar un tipo de responsable."
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />
                    </div>
                    </div>
                </div>        
            <div class="tab-pane" id="sucursal" role="tabpanel" aria-labelledby="sucursal-tab">
                <div class="container w-100 p-5">
                    <!-- contenido de Datos Sucursales -->

                    <div class="row">
                        <div class="col-md-6">
                            <asp:HiddenField ID="txtIdSucursal" runat="server" />
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtNombreSucursal" runat="server" Text="Nombre Casa Central" />
                                <asp:TextBox ID="txtNombresucursal" runat="server" CssClass="form-control bg-warning-subtle" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtDomicilioSucursal" runat="server" Text="Domicilio"></asp:Label>
                                <asp:TextBox ID="txtDomicilioSucursal" runat="server" CssClass="form-control bg-warning-subtle"></asp:TextBox>
                            </div>
                           
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtCodigoPostalSucursal" runat="server" Text="Código Postal" />
                                <asp:TextBox ID="txtCodigoPostalSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtLocalidadSucursal" runat="server" Text="Localidad" />
                                <asp:TextBox ID="txtLocalidadSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtProvinciaSucursal" runat="server" Text="Provincia" />
                                <asp:TextBox ID="txtProvinciaSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label for="txtPaisSucursal" runat="server" Text="País" />
                                <asp:TextBox ID="txtPaisSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>

                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtTelefonoSucursal" runat="server" Text="Telefono" />
                                <asp:Textbox ID="txtTelefonoSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                             <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtMovilSucursal" runat="server" Text="Movil" />
                                 <asp:Textbox ID="txtMovilSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                             </div>
                             <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtEmailSucursal" runat="server" Text="Email" />
                                 <asp:Textbox ID="txtEmailSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                             </div>
                             <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtInstagramSucursal" runat="server" Text="Instagram" />
                                 <asp:Textbox ID="txtInstagramSucursal" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                             </div>

                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboPuedeComprar" runat="server" Text="Puede Comprar" />
                                <asp:DropDownList ID="cboPuedeComprar" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboRealizaEnvios" runat="server" Text="Realiza Envios" />
                                <asp:DropDownList ID="cboRealizaEnvios" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboEstado" runat="server" Text="Esado" />
                                <asp:DropDownList ID="cboEstado" runat="server" CssClass="form-control bg-warning-subtle" width="400px" />
                            </div>
                            <asp:Label runat="server" ID="lblMensajeConfiguracion" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="pago" role="tabpanel" aria-labelledby="pago-tab">
                <div class="container w-100 p-5">
                 <!-- Formas de Pago -->
                        <div class="col-md-6">
                            <h4>Puede Cobrar con :</h4>
                            <asp:HiddenField ID="txtFormaPago" runat="server" />
                            <div class="mb-3">
                                <asp:CheckBox ID="chkEfectivo" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/efectivo.jpg" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="EFECTIVO" /> 
                            </div>
                            <div class="mb-3">
                                <asp:CheckBox ID="chkDebito" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/visaelectron.jpg" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="TARJETA DE DEBITO" /> 
                            </div>
                            <div class="mb-3">
                                <asp:CheckBox ID="chkTarjetasCredito" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/tarjetaCredito.jpg" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="TARJETA DE CREDITO" /> 
                            </div>

                            <div class="mb-3">
                                <asp:CheckBox ID="chkTransferencia" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/banco45.png" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="TRANSFERENCIA" />
                                <asp:TextBox runat="server" ID="txtCBU" CssClass="form-text d-inline bg-warning-subtle" placeholder="CBU"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtAliasTransferencia" CssClass="form-text d-inline bg-warning-subtle" placeholder="Alias"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:CheckBox ID="chkMercadoPago" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/mp45.png" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="MERCADO PAGO" /> 
                                <asp:TextBox runat="server" ID="txtCBV" CssClass="form-text d-inline bg-warning-subtle" placeholder="CBV"></asp:TextBox>
                                 <asp:TextBox runat="server" ID="txtAliasMP" CssClass="form-text d-inline bg-warning-subtle" placeholder="Alias"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:CheckBox ID="chkCtaDNI" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/cuentadni45.jpg" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="CUENTA DNI" /> 
                                <asp:TextBox runat="server" ID="txtCtaDNICBU" CssClass="form-text d-inline bg-warning-subtle" placeholder="CBU"></asp:TextBox>
                                 <asp:TextBox runat="server" ID="txtCtaDNIAlias" CssClass="form-text d-inline bg-warning-subtle" placeholder="Alias"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:CheckBox ID="chkModo" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/modo45.png" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="MODO" /> 
                                <asp:TextBox runat="server" ID="txtModoCBU" CssClass="form-text d-inline bg-warning-subtle" placeholder="CBU" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtModoAlias" CssClass="form-text d-inline bg-warning-subtle" placeholder="Alias" Visible="false"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-6">
                                  <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary btn-sm" Text="Registrar" OnClick="btnRegistrar_Click"   ValidationGroup="Registro" />

                        </div>
                 </div>
                    <div class="mt-3">
                        <asp:checkbox runat="server" id="chkCondiciones" required="true" Checked="true" Visible="false"/>                    
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                          CssClass="alert alert-danger"
                                            ShowMessageBox="false" ShowSummary="true"
                                            ValidationGroup="Registro" />
                       </div>

                </div>
        </div>
 </div>
        <!-- Script de navegación -->

        <script>
            const btnRegistrar = document.getElementById('<%= btnRegistrar.ClientID %>');
            const chkCondiciones = document.getElementById('<%= chkCondiciones.ClientID %>');

            chkCondiciones?.addEventListener('change', function () {
                if (chkCondiciones.checked) {
                    btnRegistrar.removeAttribute('disabled');
                } else {
                    btnRegistrar.setAttribute('disabled', 'disabled');
                }
            });
            const tabs = document.querySelectorAll('.tab-pane');
            let currentIndex = 0;

            function showTab(index) {
                // Mostrar la pestaña activa
                tabs.forEach((tab, i) => {
                    tab.classList.remove('active', 'show');
                    if (i === index) {
                        tab.classList.add('active', 'show');
                    }
                });

                // Activar la pestaña en el encabezado
                const navLinks = document.querySelectorAll('.nav-tabs .nav-link');
                navLinks.forEach((link, i) => {
                    link.classList.remove('active');
                    link.setAttribute('aria-selected', 'false');
                    if (i === index) {
                        link.classList.add('active');
                        link.setAttribute('aria-selected', 'true');
                    }
                });

                // Mostrar u ocultar botones
                document.getElementById('btnAnterior').style.display = index === 0 ? 'none' : 'inline-block';
                document.getElementById('btnSiguiente').style.display = index === tabs.length - 1 ? 'none' : 'inline-block';
<%--                document.getElementById('<%= btnRegistrar.ClientID %>').style.display = index === tabs.length - 1 ? 'inline-block' : 'none';--%>
                if (index === tabs.length - 1) {
                    btnRegistrar.style.display = 'inline-block';
                    btnRegistrar.disabled = !chkCondiciones.checked;
                } else {
                    btnRegistrar.style.display = 'none';
                }
            }

            document.getElementById('btnSiguiente').addEventListener('click', () => {
                if (currentIndex < tabs.length - 1) {
                    currentIndex++;
                    showTab(currentIndex);
                }
            });

            document.getElementById('btnAnterior').addEventListener('click', () => {
                if (currentIndex > 0) {
                    currentIndex--;
                    showTab(currentIndex);
                }
            });

            //document.getElementById('btnRegistrar').addEventListener('click', () => {
            //    alert("¡Usuario registrado!");
            //    // Si necesitás hacer postback: __doPostBack('btnRegistrar', '');
            //});

            showTab(currentIndex);
        </script>
 

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
  <%--  <script>
        const chkCondiciones = document.getElementById('chkCondiciones');
        const btnRegistrar = document.getElementById('btnRegistrar');

        function actualizarEstadoBoton() {
            btnRegistrar.disabled = !chkCondiciones.checked;
        }

        // Ejecutar al cargar la página por si ya está marcado
        actualizarEstadoBoton();

        // Asociar evento al checkbox
        chkCondiciones.addEventListener('change', actualizarEstadoBoton);
    </script>--%>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const chk = document.getElementById('<%= chkCondiciones.ClientID %>');
        const btn = document.getElementById('<%= btnRegistrar.ClientID %>');

        function actualizarEstado() {
            btn.disabled = !chk.checked;
        }

        if (chk) {
            chk.addEventListener("change", actualizarEstado);
            actualizarEstado(); // Ejecutar al cargar
        }
    });
    </script>

</asp:Content>
