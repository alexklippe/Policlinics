Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Now.Date > "2019-11-30" Then
            Me.Panel1.Visible = False

        End If
        If Now.Date > "2020-12-03" Then
            Me.Panel2.Visible = False

        End If
        'rand number for banner
        Try
            Randomize()
            Dim num As Integer = Math.Ceiling(Rnd() * 3)
            Me.Image1.ImageUrl = "~/img/banners/family/" + num.ToString + ".gif"

        Catch ex As Exception

        End Try

    End Sub


End Class