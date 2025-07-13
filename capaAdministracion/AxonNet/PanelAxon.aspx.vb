Imports System.Web.Script.Serialization
Imports System.Data.SqlClient
Imports capaAdministracion.capaDatos

Public Class PanelAxon
    Inherits System.Web.UI.Page
    Public fechasJson As String
    Public importesJson As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("IdUsuario") = Nothing Then
            Response.Redirect("~/Account/login.aspx")
        End If

        If Not IsPostBack Then

            Dim idEmpresa As Integer = 0



            idEmpresa = ObtenerIdEmpresaDesdeSesion()

            If idEmpresa = 1 Then
                phMenu.Controls.Add(New Literal With {
                    .Text = GenerarMenuPrincipal()
                })
            ElseIf idEmpresa > 1 Then
                phMenu.Controls.Add(New Literal With {
                    .Text = GenerarMenuSecundario()
                })
            End If
            Dim fechas As New List(Of String)()
            Dim importes As New List(Of Decimal)()

            Using conn As New SqlConnection(conectar.Cadena)
                Dim query As String = "SELECT fecha, SUM(importe) AS total FROM Estadistica GROUP BY fecha ORDER BY fecha"
                Dim cmd As New SqlCommand(query, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        fechas.Add(CDate(reader("fecha")).ToString("yyyy-MM-dd"))
                        importes.Add(Convert.ToDecimal(reader("total")))
                    End While
                End Using
            End Using

            Dim js As New JavaScriptSerializer()
            fechasJson = js.Serialize(fechas)
            importesJson = js.Serialize(importes)

        End If
    End Sub
    Private Function ObtenerIdEmpresaDesdeSesion() As Integer
        If Session("idEmpresa") IsNot Nothing Then
            Return Convert.ToInt32(Session("idEmpresa"))
        End If
        Return 0
    End Function

    Private Function GenerarMenuPrincipal() As String
        Return "<nav class='navbar navbar-expand-lg bg-warning text-black'>
        <div class='container-fluid'>
            <button class='navbar-toggler' type='button' data-bs-toggle='collapse' data-bs-target='#menuPrincipal' aria-controls='menuPrincipal' aria-expanded='false' aria-label='Toggle navigation'>
                <span class='navbar-toggler-icon'></span>
            </button>
            <div class='collapse navbar-collapse' id='menuPrincipal'>
                <ul class='navbar-nav me-auto mb-2 mb-lg-0'>
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Configuración</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='../Empresa/Empresa_listado_datos.aspx'>Empresas</a></li>
                            <li><a class='dropdown-item' href='#'>Categorías de empresas</a></li>
                            <li><a class='dropdown-item' href='#'>Configurar Carrusel</a></li>
                        </ul>
                    </li>
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Productos</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Categorías 1</a></li>
                            <li><a class='dropdown-item' href='#'>Marcas</a></li>
                            <li><a class='dropdown-item' href='#'>Listado de Productos</a></li>
                        </ul>
                    </li>
                    <!-- Continúa con el resto de menús igual -->
                </ul>
            </div>
        </div>
    </nav>"
    End Function

    Private Function GenerarMenuSecundario() As String
        Return "
        <nav class='navbar navbar-expand-lg navbar-light bg-light border-bottom'>
            <div class='container-fluid'>
                <div class='navbar-nav'>
                    <div class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Empresa</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Subitem 1</a></li>
                            <li><a class='dropdown-item' href='#'>Subitem 2</a></li>
                            <li><a class='dropdown-item' href='#'>Subitem 3</a></li>
                        </ul>
                    </div>
                    <div class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Productos</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Prod 1</a></li>
                            <li><a class='dropdown-item' href='#'>Prod 2</a></li>
                            <li><a class='dropdown-item' href='#'>Prod 3</a></li>
                            <li><a class='dropdown-item' href='#'>Prod 4</a></li>
                        </ul>
                    </div>
                    <div class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Stock</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Stock 1</a></li>
                            <li><a class='dropdown-item' href='#'>Stock 2</a></li>
                            <li><a class='dropdown-item' href='#'>Stock 3</a></li>
                        </ul>
                    </div>
                    <div class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Proveedores</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Prov 1</a></li>
                            <li><a class='dropdown-item' href='#'>Prov 2</a></li>
                            <li><a class='dropdown-item' href='#'>Prov 3</a></li>
                        </ul>
                    </div>
                    <div class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Compras</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Compra 1</a></li>
                            <li><a class='dropdown-item' href='#'>Compra 2</a></li>
                            <li><a class='dropdown-item' href='#'>Compra 3</a></li>
                        </ul>
                    </div>
                    <div class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' role='button' data-bs-toggle='dropdown'>Ventas</a>
                        <ul class='dropdown-menu'>
                            <li><a class='dropdown-item' href='#'>Venta 1</a></li>
                            <li><a class='dropdown-item' href='#'>Venta 2</a></li>
                            <li><a class='dropdown-item' href='#'>Venta 3</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>"
    End Function
    Private Function GenerarMenuProveedor() As String
        Return "
    <nav class='navbar navbar-expand-lg navbar-dark bg-primary'>
        <div class='container'>
            <a class='navbar-brand' href='#'>Menú</a>
            <button class='navbar-toggler' type='button' data-bs-toggle='collapse' data-bs-target='#menuPrincipal' aria-controls='menuPrincipal' aria-expanded='false' aria-label='Toggle navigation'>
                <span class='navbar-toggler-icon'></span>
            </button>

            <div class='collapse navbar-collapse' id='menuPrincipal'>
                <ul class='navbar-nav me-auto mb-2 mb-lg-0'>
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' id='configDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>
                            Configuración
                        </a>
                        <ul class='dropdown-menu' aria-labelledby='configDropdown'>
                            <li><a class='dropdown-item' href='~/Empresa/Empresa_listado_datos.aspx'>Empresas</a></li>
                            <li><a class='dropdown-item' href='#'>Opción 2</a></li>
                            <li><a class='dropdown-item' href='#'>Opción 3</a></li>
                        </ul>
                    </li>
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' id='clientesDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>
                            Clientes
                        </a>
                        <ul class='dropdown-menu' aria-labelledby='clientesDropdown'>
                            <li><a class='dropdown-item' href='#'>Clientes 1</a></li>
                            <li><a class='dropdown-item' href='#'>Clientes 2</a></li>
                            <li><a class='dropdown-item' href='#'>Clientes 3</a></li>
                        </ul>
                    </li>
                    <li class='nav-item dropdown'>
                        <a class='nav-link dropdown-toggle' href='#' id='facturarDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>
                            Facturar
                        </a>
                        <ul class='dropdown-menu' aria-labelledby='facturarDropdown'>
                            <li><a class='dropdown-item' href='#'>Facturar 1</a></li>
                            <li><a class='dropdown-item' href='#'>Facturar 2</a></li>
                            <li><a class='dropdown-item' href='#'>Facturar 3</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>"
    End Function
    Private Function GenerarMenuCliente() As String
        Return "
            <nav class='navbar navbar-expand-lg navbar-light bg-light border-bottom'>
                <div class='container'>
                    <ul class='navbar-nav'>
                        <li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Empresa</a>
                            <ul class='dropdown-menu'>
                                <li><a class='dropdown-item' href='#'>Subitem 1</a></li>
                                <li><a class='dropdown-item' href='#'>Subitem 2</a></li>
                                <li><a class='dropdown-item' href='#'>Subitem 3</a></li>
                            </ul>
                        </li>
                        <li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Productos</a>
                            <ul class='dropdown-menu'>
                                <li><a class='dropdown-item' href='#'>Prod 1</a></li>
                                <li><a class='dropdown-item' href='#'>Prod 2</a></li>
                                <li><a class='dropdown-item' href='#'>Prod 3</a></li>
                                <li><a class='dropdown-item' href='#'>Prod 4</a></li>
                            </ul>
                        </li>
                        <li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Stock</a>
                            <ul class='dropdown-menu'>
                                <li><a class='dropdown-item' href='#'>Stock 1</a></li>
                                <li><a class='dropdown-item' href='#'>Stock 2</a></li>
                                <li><a class='dropdown-item' href='#'>Stock 3</a></li>
                            </ul>
                        </li>
                        <li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Proveedores</a>
                            <ul class='dropdown-menu'>
                                <li><a class='dropdown-item' href='#'>Prov 1</a></li>
                                <li><a class='dropdown-item' href='#'>Prov 2</a></li>
                                <li><a class='dropdown-item' href='#'>Prov 3</a></li>
                            </ul>
                        </li>
                        <li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Compras</a>
                            <ul class='dropdown-menu'>
                                <li><a class='dropdown-item' href='#'>Compra 1</a></li>
                                <li><a class='dropdown-item' href='#'>Compra 2</a></li>
                                <li><a class='dropdown-item' href='#'>Compra 3</a></li>
                            </ul>
                        </li>
                        <li class='nav-item dropdown'>
                            <a class='nav-link dropdown-toggle' href='#' data-bs-toggle='dropdown'>Ventas</a>
                            <ul class='dropdown-menu'>
                                <li><a class='dropdown-item' href='#'>Venta 1</a></li>
                                <li><a class='dropdown-item' href='#'>Venta 2</a></li>
                                <li><a class='dropdown-item' href='#'>Venta 3</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>"
    End Function


End Class