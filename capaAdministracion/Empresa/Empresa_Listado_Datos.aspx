<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Empresa_Listado_Datos.aspx.vb" Inherits="capaAdministracion.Empresa_Listado_Datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
    <div class="container mt-4">
            <h2>Lista de Empresas</h2>
            <asp:Button ID="btnNuevaEmpresa" runat="server" CssClass="btn btn-primary mb-3" Text="Nueva Empresa" OnClick="btnNuevaEmpresa_Click" />
                    <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-success mb-3" Text="Volver" PostBackUrl="~/Account/Panel.aspx" />

            <asp:GridView ID="gvEmpresa" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="IdEmpresa" OnRowCommand="gvEmpresa_RowCommand">

                <Columns>
                    <asp:BoundField DataField="IdEmpresa" HeaderText="ID Empresa" />
                    <asp:BoundField DataField="NombreComercial" HeaderText="Nombre Comercial" ControlStyle-CssClass="text-capitalize" />
                    <asp:TemplateField HeaderText="Es Demo">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" Enabled="false"
                                Checked='<%# Convert.ToBoolean(IIf(Eval("EsDemo") Is DBNull.Value, False, Eval("EsDemo"))) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FechaInicioDemo" HeaderText="Fecha Inicio Demo" DataFormatString="{0:dd/MM/yyyy}" />
                     <asp:BoundField DataField="CantidadDiasDemo" HeaderText="Dias Demo" ItemStyle-HorizontalAlign="Right"  />
                    <asp:TemplateField>
                        <ItemTemplate>
                         <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-warning btn-sm"
                                    CommandName="Editar" CommandArgument='<%# Eval("IdEmpresa") %>'>
                                    <i class="fas fa-pencil-alt"></i>
                                </asp:LinkButton>
        
                                <asp:LinkButton ID="btnBorrar" runat="server" CssClass="btn btn-danger btn-sm"
                                    CommandName="Borrar" CommandArgument='<%# Eval("IdEmpresa") %>'
                                    OnClientClick="return confirm('¿Estás seguro de borrar esta empresa?');">
                                    <i class="fas fa-trash-alt"></i>
                                </asp:LinkButton>                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
        <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
        <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>
        <script>
            $(document).ready(function () {
                $('#<%= gvEmpresa.ClientID %>').DataTable({
				    "pageLength": 10,
				    "language": {
					    "url": "//cdn.datatables.net/plug-ins/1.13.4/i18n/es-ES.json"
				    }
			    });
		    });
        </script>
</asp:Content>
