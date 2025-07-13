<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="producto_lista.aspx.vb" Inherits="capaAdministracion.producto_lista2" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Bootstrap y jQuery -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>

    <!-- DataTables + Responsive -->
    <link href="https://cdn.datatables.net/1.13.6/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/responsive/2.5.0/css/responsive.bootstrap5.min.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.6/js/dataTables.bootstrap5.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.5.0/js/dataTables.responsive.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.5.0/js/responsive.bootstrap5.min.js"></script>

    <style>
        html, body {
            margin: 0;
            padding: 0;
            width: 100%;
            max-width: 100%;
        }

        @media (max-width: 767px) {
            table.dataTable.dtr-inline.collapsed > tbody > tr > td:first-child::before {
                top: 14px;
                left: 14px;
                height: 14px;
                width: 14px;
                display: block;
                position: absolute;
                color: white;
                border: 1px solid white;
                border-radius: 14px;
                text-align: center;
                line-height: 14px;
                content: '+';
                background-color: #0d6efd;
            }
        }
    </style>
    <div class="container-fluid px-3">
        <ol class="breadcrumb mb-4">
            <li class="breadcrumb-item"><a href="DefaultAdmin.aspx">ADMINISTRACION</a></li>
            <li class="breadcrumb-item active">Productos</li>
        </ol>

        <div class="mb-3">
            <a class="btn btn-primary" href="producto_lista_ABM.aspx?IdProducto=0">
                <i class="fa fa-plus"></i> Nuevo producto
            </a>
        </div>

        <table id="dgvData" class="table table-bordered table-striped table-hover nowrap w-100 dt-responsive">
            <thead>
                <tr>
                    <th data-priority="1">ID</th>
                    <th data-priority="2">Nombre</th>
                    <th data-priority="100">Categoría</th>
                    <th data-priority="100">Marca</th>
                    <th data-priority="100">Proveedor</th>
                    <th data-priority="100">Stock Crítico</th>
                    <th data-priority="100">Estado</th>
                    <th data-priority="100">Catálogo</th>
                    <th data-priority="100">Precio</th>
                    <th data-priority="10001">Acciones</th>
                </tr>
            </thead>
            <tbody>
                <% If sqlProducto.SelectCommand <> "" Then
                        For Each row As DataRow In CType(sqlProducto.Select(DataSourceSelectArguments.Empty), DataView).Table.Rows %>
                    <tr>
                        <td class="text-end"><%= row("idProducto") %></td>
                        <td><%= row("Nombre") %></td>
                        <td><%= row("NombreCategoria") %></td>
                        <td><%= row("NombreMarca") %></td>
                        <td><%= row("RazonSocial") %></td>
                        <td class="text-end"><%= row("StockCritico") %></td>
                        <td class="text-center"><input type="checkbox" disabled <%= If(CBool(row("Estado")), "checked", "") %> /></td>
                        <td class="text-center"><input type="checkbox" disabled <%= If(CBool(row("MostrarCatalogo")), "checked", "") %> /></td>
                        <td class="text-end">$ <%= Format(CDec(row("PrecioVenta")), "#,##0.00") %></td>
                        <td>
                            <a class="btn btn-info btn-sm" href="producto_lista_ABM.aspx?idProducto=<%= row("idProducto") %>&TituloForm=MODIFICAR PRODUCTO&Accion=E"><i class="fas fa-edit"></i></a>
                            <a class="btn btn-success btn-sm" href="producto_fotos.aspx?idProducto=<%= row("idProducto") %>&TituloForm=FOTOS PRODUCTO&Accion=F"><i class="fas fa-camera"></i></a>
                            <a class="btn btn-danger btn-sm" href="producto_lista_ABM.aspx?idProducto=<%= row("idProducto") %>&TituloForm=ELIMINAR PRODUCTO&Accion=B"><i class="fas fa-trash"></i></a>
                            <a class="btn btn-warning btn-sm" href="producto_Etiquetas.aspx?idProducto=<%= row("idProducto") %>&TituloForm=ETIQUETAS&Accion=Q"><i class="fas fa-qrcode"></i></a>
                        </td>
                    </tr>
                <% Next
                    End If %>
            </tbody>
        </table>

        <asp:SqlDataSource ID="sqlProducto" runat="server" ConnectionString="<%$ ConnectionStrings:CADENA2 %>" SelectCommand=""></asp:SqlDataSource>
    </div>

    <script>
        $(document).ready(function () {
            $('#dgvData').DataTable({
                responsive: true,
                autoWidth: false,
                order: [[1, 'asc']],
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                },
                columnDefs: [
                    { responsivePriority: 1, targets: 0 }, // ID
                    { responsivePriority: 2, targets: 1 }, // Nombre
                    { responsivePriority: 10001, targets: -1 } // Acciones
                ]
            });
        });
    </script>
</asp:Content>
