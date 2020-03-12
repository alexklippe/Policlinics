Public Class RaspisanieStatic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        OrgId.Value = query.First.id
    End Sub

    Function VrachView(ByVal ids As String) As String
        Dim id As Integer = CInt(ids)
        If id > 0 Then
            Dim db As New mainDataContext
            Dim que = (From p In db.Vrach Where p.id = id Select p).First
            Return que.Surname + " " + que.Name + " " + que.MidName
        Else
            Return "-"
        End If
    End Function


    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            LinqDataSourceSpec.DataBind()
            Me.DropDownList2.DataBind()
            LinqDataSource1.DataBind()
            Me.GridView1.DataBind()
        Catch ex As Exception

        End Try



    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        Try
            LinqDataSource1.DataBind()
            Me.GridView1.DataBind()
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub GridView1_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim row As GridViewRow = GridView1.Rows(e.NewSelectedIndex)
        Dim db As New mainDataContext
        Dim que = (From p In db.Vrach Where p.id = row.Cells(2).Text Select p).First
        Me.LabelFIO.Text = que.Surname + " " + que.Name + " " + que.MidName
        Me.LabelId.Text = row.Cells(1).Text
        Me.LabelVrachId.Text = row.Cells(2).Text
        Me.PlaceHolder1.Visible = True
        FillCalendar()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillCalendar()

    End Sub

    Sub FillCalendar()

    End Sub

End Class