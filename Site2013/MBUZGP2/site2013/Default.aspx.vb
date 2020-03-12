Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Now.Date > "2020-01-31" Then
            Me.Panel1.Visible = False

        End If
        If Now.Date <= "2019-09-29" Then
            Me.Panel2.Visible = False

        End If

        If Now.Date > CDate("2017-10-15") Then
            Me.LabelNew.Visible = False

        End If

        'прямчем символ новинка
        If Now.Date > CDate("2019-03-31") Then
            Me.LabelNew.Visible = False

        End If
        'rand number for banner
        Try
            Randomize()
            Dim num As Integer = Math.Ceiling(Rnd() * 3)
            Me.Image1.ImageUrl = "~/img/banners/family/" + num.ToString + ".gif"

        Catch ex As Exception

        End Try
    End Sub

    Function textNews(ByVal txt As String) As String
        Dim tmp As String = ""
        Dim lengt As Integer = 99
        txt = txt.Replace("[", "<").Replace("]", ">").Replace(vbCrLf, "<br />")

        If txt.Length > lengt Then
            Dim first, ends As Integer
            Try
                first = txt.IndexOf("[")
                ends = txt.IndexOf("]")

                If first <= 99 Then
                    lengt += ends - first + 99
                    If txt.Length < lengt Then
                        lengt = txt.Length
                        tmp = txt.Substring(0, lengt)
                    Else
                        tmp = txt.Substring(0, lengt) + "..."
                    End If
                Else
                    tmp = txt.Substring(0, lengt) + "..."
                End If

            Catch ex As Exception

            End Try

        Else
            tmp = txt.Replace(vbCrLf, "<br />") + "..."

        End If
        Return tmp
    End Function

    Protected Sub LinqDataSource1_Selecting(sender As Object, e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles MasterNewsLinqDataSource1.Selecting
        e.Arguments.MaximumRows = 3

    End Sub
End Class