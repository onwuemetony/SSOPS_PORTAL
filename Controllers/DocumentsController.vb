Imports System.Web.Mvc

Namespace Controllers
    Public Class DocumentsController
        Inherits Controller

        ' GET: Documents
        Function Index() As ActionResult
            Return View()
        End Function

        Function Audits() As ActionResult
            Return View()
        End Function

    End Class
End Namespace