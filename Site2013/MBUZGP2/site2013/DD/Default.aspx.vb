Public Class _Default6
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Literal1.Text = "<table><caption>Таблица годов рождения для диспансеризации в " + Now.Year.ToString + " году</caption>"
        Me.Literal1.Text += " <TR><th>Год рождения</th><th>Возраст</th><th>Год рождения</th><th>Возраст</th></TR>"
        Dim age1, age2 As Integer
        Dim ages As New ArrayList()
        For age1 = 18 To 39 Step 3
            ages.Add(age1)

        Next age1
        For age1 = 40 To 99 Step 1
            ages.Add(age1)
        Next
        Dim secondColumn As Integer
        If ((ages.Count Mod 2) <> 0) Then
            secondColumn = ((ages.Count) / 2) - 1
        Else
            secondColumn = (ages.Count / 2)
        End If




        For n = 0 To secondColumn - 1
            Me.Literal1.Text += "<tr><td>" + (Now.Year - ages(n)).ToString + "</td><td>" + ages(n).ToString + "</td><td>" + (Now.Year - ages(n + secondColumn)).ToString + "</td><td>" + ages(n + secondColumn).ToString + "</td></tr>"
        Next



        Me.Literal1.Text += "</table>"
    End Sub

End Class