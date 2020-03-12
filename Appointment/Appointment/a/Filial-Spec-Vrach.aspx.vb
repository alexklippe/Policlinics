Public Class Filial_Spec_Vrach
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        OrgId.Value = query.First.id
        'If Not DropDownList1.SelectedValue = "" Then
        '    Dim filial = From p In db.OrgFilials Where p.id = DropDownList1.SelectedValue Select p.filialName
        '    Me.Label4.Text = filial.First.ToString
        'End If
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

    Protected Sub DropDownList2_DataBound(sender As Object, e As EventArgs) Handles DropDownList2.DataBound
        Try
            Me.LinqDataSource1.DataBind()
            Me.GridView1.DataBind()
        Catch ex As Exception

        End Try
 

    End Sub

   


    Protected Sub GridView2_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView2.SelectedIndexChanging
        Dim row As GridViewRow = GridView2.Rows(e.NewSelectedIndex)
        Dim db As New mainDataContext
        Dim ord As New Vrach_Spec_ID With {.IDSpec = DropDownList2.SelectedValue, .IDVrach = row.Cells(1).Text, .IdOrg = Me.OrgId.Value}
        db.Vrach_Spec_ID.InsertOnSubmit(ord)
        db.SubmitChanges()
        LinqDataSource1.DataBind()
        LinqDataSource2.DataBind()
        GridView1.DataBind()
        GridView2.DataBind()

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        ''''сначала удаляем расписание и талоны, затем врача из специальности

        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim db As New mainDataContext
        Dim ord_raspis = From q In db.Raspisanie Where q.ID_SPEC_VRACH = row.Cells(1).Text Select q

        For Each d As Raspisanie In ord_raspis
            db.Raspisanie.DeleteOnSubmit(d)

        Next

        Dim ord_talons = From q In db.Talons Where q.VrachSpec_ID = row.Cells(1).Text Select q

        For Each d2 As Talons In ord_talons
            db.Talons.DeleteOnSubmit(d2)

        Next
        Try
            db.SubmitChanges()
        Catch ex As Exception

        End Try




    End Sub
End Class