Imports System.Configuration

Namespace capaDatos
	Public Class conectar
		Public Shared Property Cadena As String = ConfigurationManager.ConnectionStrings("SQLCadena").ToString()
	End Class
End Namespace
