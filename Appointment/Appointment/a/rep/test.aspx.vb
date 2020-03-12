Public Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host

        HiddenField1.Value = query.First.id
        Me.TextBox1.Text = "26.02.2018"
        Me.TextBox2.Text = "01.03.2018"
    End Sub

    Protected Sub Generate()
        Dim db As New mainDataContext
        Dim dStart, dEnd As DateTime
        Dim format() = {"dd.MM.yyyy", "d/M/yyyy", "dd-MM-yyyy"}
        dStart = Date.ParseExact(TextBox1.Text, format,
            System.Globalization.DateTimeFormatInfo.InvariantInfo,
            Globalization.DateTimeStyles.None)
        ' dStart = CDate(TextBox1.Text)
        dEnd = DateTime.ParseExact(TextBox2.Text, format,
            System.Globalization.DateTimeFormatInfo.InvariantInfo,
            Globalization.DateTimeStyles.None)
        dEnd = dEnd.AddHours(23).AddMinutes(59).AddSeconds(59)

        Literal1.Text = "За период с " + dStart.ToLongDateString + " " + dStart.ToLongTimeString + " по " + dEnd.ToLongDateString + " " + dEnd.ToLongTimeString + "<br /><br />"
        'Total 
        Dim query = From p In db.ViewTalonsWithVrachAndOrg Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted > 0 Select p.id

        Literal1.Text += "Всего записалось: " + query.Count.ToString + "<br />"

        'total Accepted
        query = From p In db.ViewTalonsWithVrachAndOrg Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted = 1 Select p.id

        Literal1.Text += "Всего одобрено: " + query.Count.ToString + "<br />"

        'total declined
        query = From p In db.ViewTalonsWithVrachAndOrg Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted = 2 Select p.id

        Literal1.Text += "Всего отклонено: " + query.Count.ToString + "<br />"

        'total unical
        Dim query3 = From p In db.ViewTalonsWithVrachAndOrg
                Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted > 0
                Group By p.ClientSurname,
                p.ClientMidname,
                p.ClientName
                Into g = Group
                Select ClientSurname, ClientMidname, ClientName


        Dim query2 = From q In query3 Select q

        Literal1.Text += "Всего уникальных записей: " + query2.Count.ToString + "<br />"

        'Total fils
        Dim query4 = From p In db.ViewTalonsWithVrachAndOrg
                Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted > 0
                Group By filialName = p.filialName
                Into g = Group
                Select filialName, Total = g.Count

        Literal1.Text += "<hr />Всего записалось по филиалам: " + "<br />"
        For Each row In query4
            Literal1.Text += row.filialName.ToString + ":" + row.Total.ToString + "<br />"
        Next

        'Total fils accepted
        query4 = From p In db.ViewTalonsWithVrachAndOrg
                Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted = 1
                Group By filialName = p.filialName
                Into g = Group
                Select filialName, Total = g.Count

        Literal1.Text += "Всего подтверждено по филиалам: " + "<br />"
        For Each row In query4
            Literal1.Text += row.filialName.ToString + ":" + row.Total.ToString + "<br />"
        Next
        'Total fils declined
        query4 = From p In db.ViewTalonsWithVrachAndOrg
                Where p.IDOrg = HiddenField1.Value And (p.DateTimePriem >= dStart And p.DateTimePriem <= dEnd) And p.Accepted = 2
                Group By filialName = p.filialName
                Into g = Group
                Select filialName, Total = g.Count

        Literal1.Text += "Всего отказано по филиалам: " + "<br />"
        For Each row In query4
            Literal1.Text += row.filialName.ToString + ":" + row.Total.ToString + "<br />"
        Next

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Generate()

    End Sub
End Class