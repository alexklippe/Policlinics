Public Class _Default1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Function textNews(ByVal txt As String) As String
        Dim tmp As String = txt

        tmp = txt.Replace("[", "<").Replace("]", ">").Replace(vbCrLf, "<br />")

        Return tmp
    End Function
End Class