Public Class WorkTimeWebRegByFilial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        OrgId.Value = query.First.id
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New mainDataContext
        Dim q = From p In db.WorkTimeEndZapisi Where p.idFilial = Me.DropDownList1.SelectedValue And p.DayOfWeek = Me.DropDownList3.SelectedValue Select p

        If q.Count > 0 Then
            'написать, что уже есть такая запись


        Else
            Dim ord As New WorkTimeEndZapisi With {.idFilial = Me.DropDownList1.SelectedValue, _
                                                   .IsWorkDay = Me.CheckBoxWeekend.Checked, _
                                                   .DayOfWeek = Me.DropDownList3.SelectedValue}
            If Not Me.TextBoxTime.Text = "" Then
                Dim tm As TimeSpan

                If TimeSpan.TryParse(Me.TextBoxTime.Text, tm) = True Then
                    ord.EndWorkTime = tm
                End If

            End If
            db.WorkTimeEndZapisi.InsertOnSubmit(ord)
            db.SubmitChanges()
            Me.LinqDataSourceWorkTime.DataBind()
            Me.GridView1.DataBind()

        End If

    End Sub
End Class