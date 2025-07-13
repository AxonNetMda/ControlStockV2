<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="capaAdministracion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <!-- Menú dinámico según empresa -->
    
       
    <main>
        
        <section class="row" aria-labelledby="aspnetTitle">
            <%if Session("idUsuario") IsNot Nothing Then
                    If Session("idEmpresa") IsNot Nothing Then %>
                        <h2 class="d-flex justify-content-center mt-3 text-danger-emphasis">Bienvenido</h2>
                        <h3 id="Empresa" class="d-flex justify-content-center mt-3">Su empresa a gestionar es : <%=Session("NombreEmpresa") %></h3>
                    <% Else %>
                        <h1 id="aspnetTitle" class="d-flex justify-content-center mt-3">Sistema de control de stock e inventario</h1>
                        <p>En esta pagna Ud. podra gestionar el stock de su empresa o comercio.</p>
                        <p>Puede manejar un deposito central y sucursales. Pudiendo saber el stock en el instante de toda la empresa</p>
                        <p>Hacer Reposiciones desde la casa central a cada sucursal, y poder realizar transferencias de mercaderia</p>
                        <p>entre las sucursales.</p>
                    <% end if %>
                <%Else%>
                        <h1 id="aspnetTitle3" class="d-flex justify-content-center mt-3">Sistema de control de stock e inventario</h1>
                        <p>En esta pagna Ud. podra gestionar el stock de su empresa o comercio.</p>
                        <p>Puede manejar un deposito central y sucursales. Pudiendo saber el stock en el instante de toda la empresa</p>
                        <p>Hacer Reposiciones desde la casa central a cada sucursal, y poder realizar transferencias de mercaderia</p>
                        <p>entre las sucursales.</p>
                   
            <%

                End If %>
            
        </section>
        <hr class="bg-danger"/>
        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Productos</h2>
                <p>
                   Los productos estan clasificados por categorias, puede gestionar su precio de compra y de venta
                </p>
                
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Compras</h2>
                <p>
                    Registracion de compras, con comprobantes y por proveedores
                </p>
                <p>
                   Gestion de Proveedores
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Ventas</h2>
                <p>
                    Emision de Comprobantes de ventas
                </p>
                <p>
                  Gestion de Clientes
                </p>
            </section>
        </div>
    </main>

</asp:Content>
