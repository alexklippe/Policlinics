Public Class OrgEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim db As New mainDataContext
            Dim quer = From p In db.Organization Where p.OrgTestDomainName = Request.Url.Host Or p.OrgDomainName = Request.Url.Host Select p

            If quer.Count > 0 Then
                Me.OrgID.Value = quer.First.id
            Else
                Me.LinqDataSource1.EnableInsert = True
                Me.DetailsView1.DefaultMode = DetailsViewMode.Insert

            End If
        Catch ex As Exception

        End Try


    End Sub

End Class