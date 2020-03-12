Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Me.Request.IsSecureConnection = False And
        Not Me.Request.Url.DnsSafeHost = "localhost" Then
            Response.Redirect("https://tgp2.ru/" + Request.Url.PathAndQuery.ToString)
        End If
    End Sub





End Class