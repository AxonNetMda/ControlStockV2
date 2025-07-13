<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registrarse.aspx.vb" Inherits="capaAdministracion.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://sdk.mercadopago.com/js/v2"></script>
    <script>
        const mp = new MercadoPago("YOUR_PUBLIC_KEY");
    </script>
    <style>
        .mt-3.mb-2 {
            margin-top: 1rem;
            margin-bottom: 0.5rem;
        }
    </style>
    <div class="w-100">
        <h2>Registro de nuevo usuario</h2>
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
                <button class="nav-link" id="home-tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="false">Datos del Usuario</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="sucursal-tab" data-bs-target="#sucursal" type="button" role="tab" aria-controls="sucursal" aria-selected="false">Casa Central</button>
            </li>
             <li class="nav-item" role="presentation">
                <button class="nav-link" id="pago-tab" data-bs-target="#pago" type="button" role="tab" aria-controls="pago" aria-selected="false">Formas de Pago</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="settings-tab" data-bs-target="#settings" type="button" role="tab" aria-controls="settings" aria-selected="false">Confirmar</button>
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
                                <asp:Label AssociatedControlID="txtNombreComercial" runat="server" Text="Nombre Comercial" />
                                <asp:TextBox ID="txtNombreComercial" runat="server" CssClass="form-control text-capitalize" width="400px" requerid="true" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtRazonSocial" runat="server" Text="Razón Social" />
                                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control text-capitalize" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtDireccionEmpresa" runat="server" Text="Dirección" />
                                <asp:TextBox ID="txtDireccionEmpresa" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtCodigoPostalEmpresa" runat="server" Text="Código Postal" />
                                <asp:TextBox ID="txtCodigoPostalEmpresa" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtLocalidadEMpresa" runat="server" Text="Localidad" />
                                <asp:TextBox ID="txtLocalidadEmpresa" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtProvinciaEmpresa" runat="server" Text="Provincia" />
                                <asp:TextBox ID="txtProvinciaEmpresa" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtPaisEmpresa" runat="server" Text="País" />
                                <asp:TextBox ID="txtPaisEmpresa" runat="server" CssClass="form-control" width="400px" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtEmailEmpresa" runat="server" Text="Email Empresa" />
                                <asp:Textbox ID="txtEmailEmpresa" runat="server" TextMode="Email" CssClass="form-control" width="400px" />
                            </div> <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtTelefonoEmpresa" runat="server" Text="Telefono" />
                                 <asp:Textbox ID="txtTelefonoEmpresa" runat="server" CssClass="form-control" width="400px" />
                             </div>
                            <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtCelular" runat="server" Text="Movil" />
                                 <asp:Textbox ID="txtCelular" runat="server" CssClass="form-control" width="400px" />
                             </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtFechaInicioActividades" runat="server" Text="Inicio Actividades" />
                                <asp:textbox ID="txtFechaInicioActividades" runat="server" TextMode="Date" CssClass="form-control" width="200px"/>
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboTipoResponsable" runat="server" Text="Tipo de Responsable" />
                                <asp:DropDownList ID="cboTipoResponsable" runat="server" CssClass="form-control" width="400px"/>
                            </div>

                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboTipoDocumento" runat="server" Text="Tipo de Documento" />
                                <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtNumeroDocumento" runat="server" Text="N° de documento" />
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control" width="400px" />
                            </div>
                        </div> 
               
                            <asp:Label runat="server" ID="Label2" Text=""></asp:Label>
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
      
            <div class="tab-pane " id="home" role="tabpanel" aria-labelledby="DatosComerciales-tab">
                <!-- contenido de Datos Personales -->
                <div class="container w-100 p-5">
                    <!-- campos de datos personales -->
                    <div class="row">
                        <div class="col-md-6">
                            <asp:HiddenField ID="txtIdUsuario" runat="server" />
                        <div class="mb-3">
                            <asp:Label AssociatedControlID="txtNombreUsuario" runat="server" Text="Nombre de usuario"/>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" AutoCompleteType="Disabled" />
                        </div>
                        <div class="mb-3">
                            <asp:Label AssociatedControlID="txtMovil" runat="server" Text="Móvil" />
                            <asp:TextBox ID="txtMovil" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <asp:Label AssociatedControlID="txtEmail" runat="server" Text="Email" />
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" />
                        </div>
                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtClave" runat="server" Text="Contraseña" />
                                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control" width="200px" AutoCompleteType="Disabled" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtClaveConfirmar" runat="server" Text="Confirmar Contraseña" />
                                <asp:TextBox ID="txtClaveConfirmar" runat="server" TextMode="Password" CssClass="form-control" width="200px"  />
                            </div>

<%--                            <div class="mb-3">
                                <asp:CheckBox ID="chkEstado" runat="server" CssClass="form-check-inline" Text="Habilitado" Checked="true" />
                            </div>
      --%>                      <asp:Label runat="server" ID="lblMensaje" Text=""></asp:Label>
                        </div>
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
                                <asp:TextBox ID="txtNombresucursal" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtDomicilioSucursal" runat="server" Text="Domicilio"></asp:Label>
                                <asp:TextBox ID="txtDomicilioSucursal" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtCodigoPostalSucursal" runat="server" Text="Código Postal" />
                                <asp:TextBox ID="txtCodigoPostalSucursal" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtLocalidadSucursal" runat="server" Text="Localidad" />
                                <asp:TextBox ID="txtLocalidadSucursal" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtProvinciaSucursal" runat="server" Text="Provincia" />
                                <asp:TextBox ID="txtProvinciaSucursal" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label for="txtPaisSucursal" runat="server" Text="País" />
                                <asp:TextBox ID="txtPaisSucursal" runat="server" CssClass="form-control" width="400px" />
                            </div>

                        </div>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="txtTelefonoSucursal" runat="server" Text="Telefono" />
                                <asp:Textbox ID="txtTelefonoSucursal" runat="server" CssClass="form-control" width="400px" />
                            </div>
                             <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtMovilSucursal" runat="server" Text="Movil" />
                                 <asp:Textbox ID="txtMovilSucursal" runat="server" CssClass="form-control" width="400px" />
                             </div>
                             <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtEmailSucursal" runat="server" Text="Email" />
                                 <asp:Textbox ID="txtEmailSucursal" runat="server" CssClass="form-control" width="400px" />
                             </div>
                             <div class="mb-3">
                                 <asp:Label AssociatedControlID="txtInstagramSucursal" runat="server" Text="Instagram" />
                                 <asp:Textbox ID="txtInstagramSucursal" runat="server" CssClass="form-control" width="400px" />
                             </div>

                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboPuedeComprar" runat="server" Text="Puede Comprar" />
                                <asp:DropDownList ID="cboPuedeComprar" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboRealizaEnvios" runat="server" Text="Realiza Envios" />
                                <asp:DropDownList ID="cboRealizaEnvios" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <div class="mb-3">
                                <asp:Label AssociatedControlID="cboEstado" runat="server" Text="Esado" />
                                <asp:DropDownList ID="cboEstado" runat="server" CssClass="form-control" width="400px" />
                            </div>
                            <asp:Label runat="server" ID="lblMensajeConfiguracion" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="pago" role="tabpanel" aria-labelledby="pago-tab">
                <div class="container w-100 p-5">
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
                                <asp:TextBox runat="server" ID="txtCBU" CssClass="form-text d-inline" placeholder="CBU"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtAliasTransferencia" CssClass="form-text d-inline" placeholder="Alias"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:CheckBox ID="chkMercadoPago" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/mp45.png" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="MERCADO PAGO" /> 
                                <asp:TextBox runat="server" ID="txtCBV" CssClass="form-text d-inline" placeholder="CBV"></asp:TextBox>
                                 <asp:TextBox runat="server" ID="txtAliasMP" CssClass="form-text d-inline" placeholder="Alias"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:CheckBox ID="chkCtaDNI" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/cuentadni45.jpg" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="CUENTA DNI" /> 
                                <asp:TextBox runat="server" ID="txtCtaDNICBU" CssClass="form-text d-inline" placeholder="CBU"></asp:TextBox>
                                 <asp:TextBox runat="server" ID="txtCtaDNIAlias" CssClass="form-text d-inline" placeholder="Alias"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:CheckBox ID="chkModo" runat="server" CssClass="form-check-inline" Text="   " />
                                <img src="../imagenes/modo45.png" class="img-thumbnail d-inline" style="width:50PX" />                                  
                                <asp:Label runat="server" CssClass="d-inline" Text="MODO" /> 
                                <asp:TextBox runat="server" ID="txtModoCBU" CssClass="form-text d-inline" placeholder="CBU" Visible="false"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtModoAlias" CssClass="form-text d-inline" placeholder="Alias" Visible="false"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-6">

                        </div>
                 </div>
                </div>
            <div class="tab-pane" id="settings" role="tabpanel" aria-labelledby="settings-tab">
                    <div class="container w-100 p-5">
                        <div style="max-height: 600px; overflow-y: scroll; border: 1px solid #ccc; padding: 15px;">
                            <div style="max-height: 500px; overflow-y: scroll; border: 1px solid #ccc; padding: 15px;">
                                <h3>Condiciones de Contratación del Servicio</h3>
                                <p><strong>Plataforma Web:</strong> <a href="https://axonnet.store" target="_blank">axonnet.store</a></p>
                                <p><strong>Aplicación:</strong> Sin Límites – Sistema de Control de Stock e Inventario</p>
  
                                <ol>
                                <li><strong>Objeto del Servicio:</strong> El alquiler anual de la aplicación "Sin Límites", operativa vía web.</li>
                                <li><strong>Registro y Acceso:</strong> Requiere registro y verificación de pago para habilitación.</li>
                                <li><strong>Modalidad:</strong> Contrato anual con pagos mensuales de USD o su equivalente en pesos argentinos, ajustado por IPC.</li>
                                <li><strong>Pago:</strong> Entre los días 1 y 5 de cada mes. La falta de pago puede suspender el acceso.</li>
                                <li><strong>Facturación:</strong> Mensual, con detalle del ajuste por IPC.</li>
                                <li><strong>Renovación:</strong> Automática tras 12 meses, salvo notificación con 15 días de anticipación.</li>
                                <li><strong>Cancelación:</strong> Previa notificación con 30 días. No hay reintegros por pagos ya efectuados.</li>
                                <li><strong>Obligaciones del Usuario:</strong> Uso legal, responsable y sin compartir accesos.</li>
                                <li><strong>Responsabilidad de Axonnet:</strong> Garantiza funcionamiento salvo mantenimientos o fuerza mayor.</li>
                                <li><strong>Modificaciones:</strong> Se informarán y permitirán baja sin penalidad.</li>
                                <li><strong>Jurisdicción:</strong> Tribunales de la Provincia de Buenos Aires, Argentina.</li>
                                </ol>
                            </div>
                            <div style="margin-top: 10px;">
                                <asp:checkbox runat="server" id="chkCondiciones" required="true" />
                                <label for="chkCondiciones">Acepto las Condiciones de Contratación del Servicio</label>
                                <div class="mt-3">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        CssClass="alert alert-danger"
                                        ShowMessageBox="false" ShowSummary="true"
                                        ValidationGroup="Registro" />
                                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary btn-sm" Text="Registrar" OnClick="btnRegistrar_Click"  ValidationGroup="Registro" Enabled="false" />
                                </div>

                            </div>                    
                        </div>
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
                document.getElementById('<%= btnRegistrar.ClientID %>').style.display = index === tabs.length - 1 ? 'inline-block' : 'none';
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

            document.getElementById('btnRegistrar').addEventListener('click', () => {
                alert("¡Usuario registrado!");
                // Si necesitás hacer postback: __doPostBack('btnRegistrar', '');
            });

            showTab(currentIndex);
        </script>
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
