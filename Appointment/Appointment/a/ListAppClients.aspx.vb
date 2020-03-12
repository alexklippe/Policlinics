Public Class ListAppClients
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        def()

    End Sub
    Sub def()
        Dim days As DateTime = Now.Date
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host

        Me.LinqDataSource1.WhereParameters.Item(0).DefaultValue = "0"
        Me.LinqDataSource1.WhereParameters.Item(1).DefaultValue = days
        Me.LinqDataSource1.WhereParameters.Item(2).DefaultValue = query.First.id.ToString
        Me.LinqDataSource1.WhereParameters.Item(3).DefaultValue = days.AddDays(60)
        Me.Label1.Text = days
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'только за сегодня
        Dim days As DateTime = Now.Date
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host

        Me.LinqDataSource1.WhereParameters.Item(0).DefaultValue = "0"
        Me.LinqDataSource1.WhereParameters.Item(1).DefaultValue = days
        Me.LinqDataSource1.WhereParameters.Item(2).DefaultValue = query.First.id.ToString
        Me.LinqDataSource1.WhereParameters.Item(3).DefaultValue = days.AddDays(1)
        Me.Label1.Text = days
        Me.LinqDataSource1.DataBind()
        Me.GridView1.DataBind()

    End Sub

  
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'с сегодня +60 дней
        def()
        Me.LinqDataSource1.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'прошлые 7 дней
        Dim days As DateTime = Now.Date
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host

        Me.LinqDataSource1.WhereParameters.Item(0).DefaultValue = "0"
        Me.LinqDataSource1.WhereParameters.Item(1).DefaultValue = days.AddDays(-7)
        Me.LinqDataSource1.WhereParameters.Item(2).DefaultValue = query.First.id.ToString
        Me.LinqDataSource1.WhereParameters.Item(3).DefaultValue = days.AddDays(-1)
        Me.Label1.Text = days
        Me.LinqDataSource1.DataBind()
        Me.GridView1.DataBind()
    End Sub
End Class