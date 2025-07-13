Public Class Site_Mobile
	Inherits System.Web.UI.MasterPage

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim cantidadImagenes As Integer = 4
            Dim carruselHtml As String = "<div id='carouselExample' class='carousel slide' data-bs-ride='carousel'><div class='carousel-inner'>"

            For i As Integer = 0 To cantidadImagenes - 1
                Dim activeClass As String = If(i = 0, "active", "")
                carruselHtml &= $"<div class='carousel-item {activeClass}'>
                                    <a href='paginaDestino{i + 1}.aspx'>
                                        <img src='carrusel/imagen{i + 1}.png' class='d-block w-100' alt='Imagen {i + 1}' />
                                    </a>
                                  </div>"
            Next

            carruselHtml &= "</div>
                <button class='carousel-control-prev' type='button' data-bs-target='#carouselExample' data-bs-slide='prev'>
                    <span class='carousel-control-prev-icon' aria-hidden='true'></span>
                    <span class='visually-hidden'>Anterior</span>
                </button>
                <button class='carousel-control-next' type='button' data-bs-target='#carouselExample' data-bs-slide='next'>
                    <span class='carousel-control-next-icon' aria-hidden='true'></span>
                    <span class='visually-hidden'>Siguiente</span>
                </button>
            </div>"

            phCarrusel.Controls.Add(New Literal With {.Text = carruselHtml})
        End If
    End Sub

End Class