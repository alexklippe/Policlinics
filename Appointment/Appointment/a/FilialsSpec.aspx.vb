Public Class FilialsSpec
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim db As New mainDataContext
            Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
            OrgId.Value = query.First.id
            If Not DropDownList1.SelectedValue = "" Then
                Dim filial = From p In db.OrgFilials Where p.id = DropDownList1.SelectedValue Select p.filialName
                Me.Label4.Text = filial.First.ToString
            End If
        End If


    End Sub

    
  
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New mainDataContext


        Dim filial = From p In db.OrgFilials Where p.id = DropDownList1.SelectedValue


        Dim ord As New Spec_Filial_ID With {.IDFilial = filial.First.id, .IDOrg = OrgId.Value, .IDSpec = DropDownList4.SelectedValue}

        db.Spec_Filial_ID.InsertOnSubmit(ord)
        db.SubmitChanges()
        Me.LinqDataSource1.DataBind()
        Me.GridView1.DataBind()

        '  Response.Redirect(Request.RawUrl)
    End Sub

  

    Protected Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound
        '' Me.DropDownList1.SelectedItem.Value = 0
        If Not DropDownList1.SelectedValue = "" Then
            Dim db As New mainDataContext
            Dim filial = From p In db.OrgFilials Where p.id = DropDownList1.SelectedValue Select p.filialName
            Me.Label4.Text = filial.First.ToString
        End If
    End Sub
End Class