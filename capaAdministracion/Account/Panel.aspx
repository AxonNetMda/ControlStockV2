<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Panel.aspx.vb" Inherits="capaAdministracion.Panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <asp:PlaceHolder ID="phMenu" runat="server"></asp:PlaceHolder>
    <div class="container mt-4">
        <asp:PlaceHolder ID="phMenuMaster" runat="server" />
        <main>
         
            <div class="row">
              <div class="col-md-12">
                  <div class="row g-3">
                    <!-- Card 1 -->
                    <div class="col-md-3">
                      <div class="card h-100">
                        <div class="card-header text-center">
                          <strong style="font-size: medium">VENTAS</strong>
                        </div>
                        <div class="card-body text-center">
                          <label class="text-black" style="font-size: large">
                            <i class="fas fa-chart-line"></i> $ 1000
                          </label>
                        </div>
                        <div class="card-footer text-center">
                          <a class="btn btn-light btn-sm">Info...</a>
                        </div>
                      </div>
                    </div>

                    <!-- Card 2 -->
                    <div class="col-md-3">
                      <div class="card h-100">
                        <div class="card-header text-center">
                          <strong style="font-size: medium">CLIENTES</strong>
                        </div>
                        <div class="card-body text-center">
                          <label class="text-black" style="font-size: large">
                            <i class="fas fa-user"></i> 45
                          </label>
                        </div>
                        <div class="card-footer text-center">
                          <a class="btn btn-light btn-sm">Info...</a>
                        </div>
                      </div>
                    </div>

                    <!-- Card 3 -->
                    <div class="col-md-3">
                      <div class="card h-100">
                        <div class="card-header text-center">
                          <strong style="font-size:medium">CAJA DIARIA</strong>
                        </div>
                        <div class="card-body text-center">
                          <label class="text-black" style="font-size: large">
                            <i class="fas fa-dollar-sign"></i> 450.000
                          </label>
                        </div>
                        <div class="card-footer text-center">
                          <a class="btn btn-secolightndary btn-sm">Info...</a>
                        </div>
                      </div>
                    </div>
                   <!-- Card 4 -->
                    <div class="col-md-3">
                      <div class="card h-100">
                        <div class="card-header text-center">
                          <strong style="font-size: medium">PEDIDOS PENDIENTES</strong>
                        </div>
                        <div class="card-body text-center">
                          <label class="text-black" style="font-size: large">
                              <label class="text-black">
                            <i class="fas fa-clipboard"> </i> 4</label>
                          </label>
                        </div>
                        <div class="card-footer text-center">
                          <a class="btn btn-light btn-sm">Info...</a>
                        </div>
                      </div>
                    </div>
                     <!-- Card 5 -->
                      <div class="col-md-3">
                        <div class="card h-100">
                          <div class="card-header text-center">
                            <strong style="font-size: medium">CUENTAS POR COBRAR</strong>
                          </div>
                          <div class="card-body text-center">
                            <label class="text-black" style="font-size: large">
                                <label class="text-black">
                              <i class="fas fa-clipboard"> </i> 4</label>
                            </label>
                          </div>
                          <div class="card-footer text-center">
                            <a class="btn btn-light btn-sm">Info...</a>
                          </div>
                        </div>
                      </div>
                     <!-- Card 6 -->
                      <div class="col-md-3">
                        <div class="card h-100">
                          <div class="card-header text-center">
                            <strong style="font-size: medium">PEDIDOS PROVEEDORES</strong>
                          </div>
                          <div class="card-body text-center">
                            <label class="text-black" style="font-size: large">
                                <label class="text-black">
                              <i class="fas fa-clipboard"> </i> 4</label>
                            </label>
                          </div>
                          <div class="card-footer text-center">
                            <a class="btn btn-light btn-sm">Info...</a>
                          </div>
                        </div>
                      </div>

                  </div>
               <%-- </div>
                <div class="col-md-6">                    
                        <div class="card">
                            <div class="card-header bg-primary text-white">
                                Estadísticas de Ventas por Fecha
                            </div>
                            <div class="card-body">
                                <canvas id="graficoEstadistica"></canvas>
                            </div>
                        </div> --%>                 
                </div>
            </div>

                

        </main>
    </div>
     <script>
        window.onload = function () {
            const fechas = <%= fechasJson %>;
            const importes = <%= importesJson %>;

            const ctx = document.getElementById('graficoEstadistica').getContext('2d');
            new Chart(ctx, {
                type: 'line',
                data: {
                    labels: fechas,
                    datasets: [{
                        label: 'Importe',
                        data: importes,
                        borderColor: 'rgb(75, 192, 192)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        fill: true,
                        tension: 0.3
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        x: {
                            title: { display: true, text: 'Fecha' }
                        },
                        y: {
                            title: { display: true, text: 'Importe ($)' }
                        }
                    }
                }
            });
        }
     </script>
</asp:Content>
