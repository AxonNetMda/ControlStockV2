<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/site.master" CodeFile="Empresa_lista.aspx.vb" Inherits="Empresa_lista" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
    <div class="container mt-4">
            <h2>Lista de Empresas</h2>
            <asp:Button ID="btnNuevaEmpresa" runat="server" CssClass="btn btn-primary mb-3" Text="Nueva Empresa" OnClick="btnNuevaEmpresa_Click" />
            <%--<asp:GridView ID="gvEmpresa" runat="server" 
                          AutoGenerateColumns="False"
                          CssClass="table table-striped table-bordered"
                          DataKeyNames="IdEmpresa"
                          OnRowCommand="gvEmpresa_RowCommand"
                          UseAccessibleHeader="true"
                          HeaderStyle-BackColor="#f8f9fa"
                          GridLines="None"
                          ShowHeaderWhenEmpty="True"
                          ShowHeader="True">                
                <Columns>
                    <asp:BoundField DataField="IdEmpresa" HeaderText="ID Empresa" />
                    <asp:BoundField DataField="NombreComercial" HeaderText="Nombre Comercial" />
                    <asp:TemplateField HeaderText="Es Demo">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEsDemo" runat="server" Enabled="false"
                                Checked='<%# Convert.ToBoolean(IIf(Eval("EsDemo") Is DBNull.Value, False, Eval("EsDemo"))) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>                    <asp:BoundField DataField="FechaInicioDemo" HeaderText="Fecha Inicio Demo" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm" CommandName="Editar" CommandArgument='<%# Eval("IdEmpresa") %>' />
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger btn-sm" CommandName="Borrar" CommandArgument='<%# Eval("IdEmpresa") %>' OnClientClick="return confirm('¿Estás seguro de borrar esta empresa?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
            <div class="table-responsive">
                 <div class="datatable-container">
                    <asp:GridView ID="gvEmpresa" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-striped table-bordered"
                DataKeyNames="IdEmpresa"
                OnRowCommand="gvEmpresa_RowCommand"
                UseAccessibleHeader="True"
                ShowHeader="True"
                ShowHeaderWhenEmpty="True"
                HeaderStyle-BackColor="#f8f9fa"
                GridLines="None">
                <Columns>
                    <asp:BoundField DataField="IdEmpresa" HeaderText="ID Empresa" />
                    <asp:BoundField DataField="NombreComercial" HeaderText="Nombre Comercial" />
                    <asp:TemplateField HeaderText="Es Demo">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEsDemo" runat="server" Enabled="false"
                                Checked='<%# Convert.ToBoolean(IIf(Eval("EsDemo") Is DBNull.Value, False, Eval("EsDemo"))) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:BoundField DataField="FechaInicioDemo" HeaderText="Fecha Inicio Demo" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <button type="button" class="btn btn-warning btn-sm me-1" onclick="__doPostBack('<%= gvEmpresa.UniqueID %>', 'Editar$<%# Container.DataItem("IdEmpresa") %>')">
                                <i class="fas fa-pencil-alt"></i>
                            </button>
                            <button type="button" class="btn btn-danger btn-sm" onclick="if(confirm('¿Estás seguro de borrar esta empresa?')) __doPostBack('<%= gvEmpresa.UniqueID %>', 'Borrar$<%# Container.DataItem("IdEmpresa") %>')">
                                <i class="fas fa-trash"></i>
                            </button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                 </div>
            </div>
        </div>

        <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
        <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
        <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>
       <%-- <script>
            $(document).ready(function () {
                $('#<%= gvEmpresa.ClientID %>').DataTable({
				    "pageLength": 10,
				    "language": {
					    "url": "//cdn.datatables.net/plug-ins/1.13.4/i18n/es-ES.json"
				    }
			    });
		    });
        </script>--%>

        <script>
            document.addEventListener('DOMContentLoaded', function () {
                const tableId = '<%= gvEmpresa.ClientID %>';
                const tableElement = document.getElementById(tableId);
                if (tableElement) {
                    $('#' + tableId).DataTable({
                        paging: true,
                        pageLength: 10,
                        ordering: true,
                        language: {
                            url: "//cdn.datatables.net/plug-ins/1.13.4/i18n/es-ES.json"
                        }
                    });
                }
            });
        </script>
</asp:Content>
