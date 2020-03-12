Public Class SpecEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim quer = From p In db.Organization Where p.OrgTestDomainName = Request.Url.Host Or p.OrgDomainName = Request.Url.Host Select p

        If quer.Count > 0 Then
            Me.OrgID.Value = quer.First.id
     
        End If
    End Sub

    
    Protected Sub DetailsView1_ItemCreated(sender As Object, e As EventArgs)

    End Sub

    Protected Sub DetailsView1_ItemInserted(sender As Object, e As DetailsViewInsertedEventArgs) Handles DetailsView1.ItemInserted
        Response.Redirect(Request.RawUrl)
    End Sub
End Class