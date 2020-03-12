Public Class FilialsEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HiddenField1.Value = Request.Url.Host

        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        HiddenField2.Value = query.First.id
        Dim q2 = From p In db.OrgFilials Where p.idOrganization = query.First.id Select p

        If q2.Count = 0 Then

            Me.DetailsView1.DefaultMode = DetailsViewMode.Insert

        End If

    End Sub



    'Protected Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
    '    If DetailsView1.CurrentMode = DetailsViewMode.Insert Then
    '        Me.DetailsView1.Rows(6).Cells(1).Text = HiddenField2.Value
    '    End If
    'End Sub
End Class