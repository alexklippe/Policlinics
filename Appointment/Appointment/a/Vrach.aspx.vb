Public Class Vrach1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        IdOrg.Value = query.First.id
    End Sub
    Function cat(ByVal ids As String) As String
        Dim id As Integer = CInt(ids)
        If ID > 0 Then

            Dim db As New mainDataContext
            Dim query = From q In db.CategoriiVracha Where q.id = id Select q.CategoryName
            Return query.First.ToString
        Else
            Return "-"
        End If
    End Function
    Function obr(ByVal ids As String) As String
        Dim id As Integer = CInt(ids)
        If id > 0 Then


            Dim db As New mainDataContext
            Dim query = From q In db.ObrazovanieVracha Where q.id = id Select q.Obrazovanie
            Return query.First.ToString
        Else
            Return "-"

        End If
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New mainDataContext
        Dim queryOrg = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host


        Dim query = (From q In db.Vrach Where q.Surname = Me.TextBoxSurname.Text.Trim And q.Name = Me.TextBoxName.Text.Trim And q.MidName = Me.TextBoxMidname.Text.Trim).Count
        If query > 0 Then
            Response.Write("<script>alert('Такой врач уже есть в справочнике');</script>")

        Else

            Dim ord As New Vrach With {.Surname = Me.TextBoxSurname.Text.Trim, _
                                            .MidName = Me.TextBoxMidname.Text.Trim, _
                                            .Name = Me.TextBoxName.Text.Trim, _
                                            .ProfObrazovanieID = CInt(Me.DropDownList2.SelectedValue), _
                                            .Certification = Me.TextBoxCert.Text.Trim, _
                                            .CategoryVrachaID = CInt(Me.DropDownList4.SelectedValue), _
                                            .IdOrg = Me.IdOrg.Value}
            If Not TextBoxDateBirth.Text = "" Then
                ord.BirthDay = CDate(TextBoxDateBirth.Text.Trim)
            End If
            If Not TextBoxTabNum.Text = "" Then
                ord.TabelNumber = CInt(Me.TextBoxTabNum.Text.Trim)
            End If



            ord.ObrUchr = Me.TextBoxVUZ.Text.Trim
            ord.PovyshKvalif = Me.TextBoxPovKvalif.Text.Trim

            db.Vrach.InsertOnSubmit(ord)
            db.SubmitChanges()
            Response.Redirect(Request.RawUrl)
        End If





    End Sub
End Class