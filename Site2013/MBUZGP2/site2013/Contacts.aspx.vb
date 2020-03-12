Public Class Contacts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.IsInRole("admin") Then
            PanelAdmin.Visible = True

        End If
    End Sub


    Protected Sub OnRowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim FilialId As String = GridView1.DataKeys(e.Row.RowIndex).Value.ToString()
            Dim Items As GridView = TryCast(e.Row.FindControl("GridView2"), GridView)
            Me.LinqDataSource2.WhereParameters.Item(0).DefaultValue = FilialId
            Me.LinqDataSource2.WhereParameters.Item(1).DefaultValue = True
            Items.DataSource = LinqDataSource2
            Items.DataBind()
        End If
    End Sub

    Protected Function doFIO(Optional ByVal id As Integer = 10) As String
        Dim db As New ContactsDataContext
        Dim FIO As String = ""
        Dim query = From p In db.Sotrudnikis Where p.IdCabinet = id Select p


        Try
            If query.Count > 0 Then
                FIO = "<br />  &nbsp;&nbsp;&nbsp;&nbsp;   " + query.First.Surname + " " + query.First.Name + " " + query.First.MidName
            Else
                FIO = ""

            End If

        Catch ex As Exception

        End Try

        Return FIO
    End Function


  
End Class