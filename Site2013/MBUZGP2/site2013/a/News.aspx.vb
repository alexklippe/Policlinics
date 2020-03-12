Public Class News
    Inherits System.Web.UI.Page




    Protected Sub DetailsView1_ItemInserting(sender As Object, e As DetailsViewInsertEventArgs) Handles DetailsView1.ItemInserting
        'Dim date3 As TextBox = CType(DetailsView1.FindControl("TextBox3"), TextBox)
        'Dim title3 As TextBox = CType(DetailsView1.FindControl("TextBox2"), TextBox)
        'Dim text3 As TextBox = CType(DetailsView1.FindControl("TextBox1"), TextBox)

        e.Values("UserCreate") = Me.User.Identity.Name.ToString
        'e.Values("Title") = title3.Text
        'e.Values("Text") = text3.Text



    End Sub

    Protected Sub DetailsView1_ItemInserted(sender As Object, e As DetailsViewInsertedEventArgs) Handles DetailsView1.ItemInserted
        GridView1.DataBind()


    End Sub

    Protected Sub DetailsView1_ItemUpdating(sender As Object, e As DetailsViewUpdateEventArgs) Handles DetailsView1.ItemUpdating

    End Sub

    Protected Sub DetailsView1_ItemUpdated(sender As Object, e As DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated
        GridView1.DataBind()
    End Sub

    Protected Sub DetailsView1_ItemDeleted(sender As Object, e As DetailsViewDeletedEventArgs) Handles DetailsView1.ItemDeleted
        GridView1.DataBind()
    End Sub
End Class