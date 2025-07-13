Public Class SiteMaster
	Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("IdUsuario") IsNot Nothing Then
                phUsuario.Visible = True
                phAnonimo.Visible = False
                litNombreUsuario.Text = Session("Nombre").ToString()
            Else
                phUsuario.Visible = False
                phAnonimo.Visible = True
                'Response.Redirect("~/Account/login.aspx")
            End If

            Dim idEmpresa As Integer = 0
            If Session("idEmpresa") IsNot Nothing Then
                Integer.TryParse(Session("idEmpresa").ToString(), idEmpresa)
            End If

            'Select Case idEmpresa
            '    Case 1
            '        phMenuMaster.Controls.Add(New LiteralControl(GenerarMenuProveedor()))
            '    Case > 1
            '        phMenuMaster.Controls.Add(New LiteralControl(GenerarMenuCliente()))
            '    Case Else
            '        ' No se muestra ningún menú
            'End Select

        End If
    End Sub
    'Private Function GenerarMenuProveedor() As String
    '    Return "
    '<nav class='navbar navbar-expand-lg navbar-dark bg-primary'>
    '    <div class='container'>
    '        <a class='navbar-brand' href='#'>Menú</a>
    '        <button class='navbar-toggler' type='button' data-bs-toggle='collapse' data-bs-target='#menuPrincipal' aria-controls='menuPrincipal' aria-expanded='false' aria-label='Toggle navigation'>
    '            <span class='navbar-toggler-icon'></span>
    '        </button>

    '        <div class='collapse navbar-collapse' id='menuPrincipal'>
    '            <ul class='navbar-nav me-auto mb-2 mb-lg-0'>
    '                <li class='nav-item dropdown'>
    '                    <a class='nav-link dropdown-toggle' href='#' id='configDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>
    '                        Configuración
    '                    </a>
    '                    <ul class='dropdown-menu' aria-labelledby='configDropdown'>
    '                        <li><a class='dropdown-item' href='~/Empresa/Empresa_listado_datos.aspx'>Empresas</a></li>
    '                        <li><a class='dropdown-item' href='#'>Opción 2</a></li>
    '                        <li><a class='dropdown-item' href='#'>Opción 3</a></li>
    '                    </ul>
    '                </li>
    '                <li class='nav-item dropdown'>
    '                    <a class='nav-link dropdown-toggle' href='#' id='clientesDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>
    '                        Clientes
    '                    </a>
    '                    <ul class='dropdown-menu' aria-labelledby='clientesDropdown'>
    '                        <li><a class='dropdown-item' href='#'>Clientes 1</a></li>
    '                        <li><a class='dropdown-item' href='#'>Clientes 2</a></li>
    '                        <li><a class='dropdown-item' href='#'>Clientes 3</a></li>
    '                    </ul>
    '                </li>
    '                <li class='nav-item dropdown'>
    '                    <a class='nav-link dropdown-toggle' href='#' id='facturarDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>
    '                        Facturar
    '                    </a>
    '                    <ul class='dropdown-menu' aria-labelledby='facturarDropdown'>
    '                        <li><a class='dropdown-item' href='#'>Facturar 1</a></li>
    '                        <li><a class='dropdown-item' href='#'>Facturar 2</a></li>
    '                        <li><a class='dropdown-item' href='#'>Facturar 3</a></li>
    '                    </ul>
    '                </li>
    '            </ul>
    '        </div>
    '    </div>
    '</nav>"
    'End Function


    'Private Function GenerarMenuCliente() As String
    '    Return "
    '        <nav class='navbar navbar-expand-lg navbar-light bg-light border-bottom'>
    '            <div class='container'>
    '                <ul class='navbar-nav'>
    '                    <li class='nav-item dropdown'>
    '                        <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Empresa</a>
    '                        <ul class='dropdown-menu'>
    '                            <li><a class='dropdown-item' href='#'>Subitem 1</a></li>
    '                            <li><a class='dropdown-item' href='#'>Subitem 2</a></li>
    '                            <li><a class='dropdown-item' href='#'>Subitem 3</a></li>
    '                        </ul>
    '                    </li>
    '                    <li class='nav-item dropdown'>
    '                        <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Productos</a>
    '                        <ul class='dropdown-menu'>
    '                            <li><a class='dropdown-item' href='#'>Prod 1</a></li>
    '                            <li><a class='dropdown-item' href='#'>Prod 2</a></li>
    '                            <li><a class='dropdown-item' href='#'>Prod 3</a></li>
    '                            <li><a class='dropdown-item' href='#'>Prod 4</a></li>
    '                        </ul>
    '                    </li>
    '                    <li class='nav-item dropdown'>
    '                        <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Stock</a>
    '                        <ul class='dropdown-menu'>
    '                            <li><a class='dropdown-item' href='#'>Stock 1</a></li>
    '                            <li><a class='dropdown-item' href='#'>Stock 2</a></li>
    '                            <li><a class='dropdown-item' href='#'>Stock 3</a></li>
    '                        </ul>
    '                    </li>
    '                    <li class='nav-item dropdown'>
    '                        <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Proveedores</a>
    '                        <ul class='dropdown-menu'>
    '                            <li><a class='dropdown-item' href='#'>Prov 1</a></li>
    '                            <li><a class='dropdown-item' href='#'>Prov 2</a></li>
    '                            <li><a class='dropdown-item' href='#'>Prov 3</a></li>
    '                        </ul>
    '                    </li>
    '                    <li class='nav-item dropdown'>
    '                        <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Compras</a>
    '                        <ul class='dropdown-menu'>
    '                            <li><a class='dropdown-item' href='#'>Compra 1</a></li>
    '                            <li><a class='dropdown-item' href='#'>Compra 2</a></li>
    '                            <li><a class='dropdown-item' href='#'>Compra 3</a></li>
    '                        </ul>
    '                    </li>
    '                    <li class='nav-item dropdown'>
    '                        <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Ventas</a>
    '                        <ul class='dropdown-menu'>
    '                            <li><a class='dropdown-item' href='#'>Venta 1</a></li>
    '                            <li><a class='dropdown-item' href='#'>Venta 2</a></li>
    '                            <li><a class='dropdown-item' href='#'>Venta 3</a></li>
    '                        </ul>
    '                    </li>
    '                </ul>
    '            </div>
    '        </nav>"
    'End Function
End Class