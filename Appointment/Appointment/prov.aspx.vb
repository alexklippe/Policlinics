Public Class prov
    Inherits System.Web.UI.Page
    Dim URLp As String = "https://"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.Params.Item("code") Is Nothing Then
            TextBoxCode.Text = Request.Params.Item("code").ToString
            checkStatus()
        Else
            Me.Panel1.Visible = False
            Me.Panel2.Visible = False
            Me.Panel3.Visible = False

        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
   
        checkStatus()
    End Sub
    Private Sub checkStatus()
        Dim tid As String = ""
        Dim code As String = ""
        Dim tmp As String = ""

        If Me.TextBoxCode.Text.Length >= 10 Then
            tmp = Me.TextBoxCode.Text
        Else
            Try
                tmp = Request.Params.Item("code").ToString
               
            Catch ex As Exception
                Return

            End Try
        End If
        Try

      
        tid = CInt(tmp.Substring(6))
        code = tmp.Substring(0, 6)

            Dim db As New mainDataContext

            Dim tal = (From q In db.Talons Where q.id = tid And q.RNDCode = code Select q).First
            Dim talons = (From p In db.ViewByTalonId Where p.id = tid Select p).First
            Dim org = (From p In db.Organization Where p.id = talons.OrgId Select p).First
            Dim FIO As String = ""
            'подтверждено
            If tal.ClientSex = True Then
                'мужч
                FIO = "Уважаемый " + tal.ClientName.ToString + " " + tal.ClientMidname + " " + tal.ClientSurname.Substring(0, 1) + "."
            Else
                'жен
                FIO = "Уважаемая " + tal.ClientName.ToString + " " + tal.ClientMidname + " " + tal.ClientSurname.Substring(0, 1) + "."
            End If

            If tal.Accepted = 1 Then
                LabelFIO.Text = FIO
                LabelTalonNum.Text = tal.id
                LabelFilial.Text = talons.filialName.ToString + " " + talons.filialAddress.ToString
                LabelSpec.Text = talons.SpecialnostName.ToString
                LabelVrach.Text = talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString
                LabelDate.Text = tal.DateTimePriem.ToString
                HyperLinkForCancel.NavigateUrl = URLp + org.OrgDomainName + "/success?tid=" + tal.id.ToString + "&tdate=" + tal.DateTimePriem.Value.ToBinary.ToString + "&zdate=" + tal.ReservedTill.Value.ToBinary.ToString + "&code=" + tal.RNDCode
                LabelOrg.Text = org.OrgShortName.ToString
                Me.Panel1.Visible = True
                Me.Panel2.Visible = False
                btnSubmit.Enabled = False
                Me.Panel3.Visible = False
            ElseIf tal.Accepted = 2 Then
                'отказано
                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.Panel3.Visible = False

                LabelFIO2.Text = FIO

                btnSubmit.Enabled = False
                LabelTalonNum2.Text = tal.id
                LabelFilial2.Text = talons.filialName.ToString + " " + talons.filialAddress.ToString
                LabelSpecialnost2.Text = talons.SpecialnostName.ToString
                LabelVrach2.Text = talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString
                LabelDate2.Text = tal.DateTimePriem.ToString
                LabelOrg2.Text = org.OrgShortName.ToString
                Me.LabelOtkazText.Text = tal.AcceptedText.ToString

            Else
                'нет статуса
                Me.Panel1.Visible = False
                Me.Panel2.Visible = False
                Me.Panel3.Visible = True
                LabelFIO3.Text = FIO


            End If
        Catch ex As Exception

        End Try
    End Sub
End Class