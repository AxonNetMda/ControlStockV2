Imports System.Web.Mvc

Namespace Controllers
    Public Class EmpresaController
        Inherits Controller

        ' GET: Empresa
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Empresa/Details/5
        Function Lista(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Empresa/Create
        Function Nuevo() As ActionResult
            Return View()
        End Function

        ' POST: Empresa/Create
        <HttpPost()>
        Function Nuevo(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Empresa/Edit/5
        Function Editar(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Empresa/Edit/5
        <HttpPost()>
        Function Editar(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Empresa/Delete/5
        Function Borrar(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Empresa/Delete/5
        <HttpPost()>
        Function Borrar(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace