Public Class platnye
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim CatalogId As String = GridView1.DataKeys(e.Row.RowIndex).Value.ToString()
            Dim Items As GridView = TryCast(e.Row.FindControl("GridView2"), GridView)
            Me.LinqDataSource2.WhereParameters.Item(0).DefaultValue = CatalogId
            Items.DataSource = LinqDataSource2
            Items.DataBind()
        End If
    End Sub

End Class