Public Class claim
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim message As New System.Net.Mail.MailMessage()
    
        message.To.Add("alexklippe@mail.ru")
        message.To.Add("stomat73@mail.ru")




        If Me.FileUpload1.HasFile Then
            Try
                If FileUpload1.FileBytes.Count > 5242880 Then
                    Me.LabelError.Text = "Файл превышает масимальное значение."
                    Return
                End If
                Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower

                Dim arr() As String = {".pdf", ".doc", ".docx", ".jpg", ".png", ".zip"}
                Dim ok As Boolean = False
                For Each arr_o In arr
                    If arr_o = fileExt Then
                        ok = True
                    End If
                Next
                If ok = False Then
                    Me.LabelError.Text = "Файл имеет запрещенное расширение."
                    Return
                End If


            Catch ex As Exception

            End Try
            Try
                FileUpload1.SaveAs(System.IO.Path.GetTempPath() + FileUpload1.FileName.ToString)
            Catch ex As Exception
                Me.LabelError.Text = "Не удалось загрузить файл. " + ex.ToString
            End Try

            Try
                Dim attach As New System.Net.Mail.Attachment(FileUpload1.FileContent, FileUpload1.FileName)
                message.Attachments.Add(attach)
            Catch ex As Exception

            End Try


        End If

        'Dim link As New ClaimDataContext
        'Dim row As New Claims With {.Title = Me.DropDownList1.SelectedValue.ToString, .Filial = CInt(DropDownList2.SelectedValue), .UserName = Me.TextBoxFIO.Text, .UserAddress = Me.TextBoxAddress.Text, .UserContact = Me.TextBoxTelephone.Text, .UserEMail = Me.TextBoxEmail.Text, .UserText = Me.TextBoxText.Text, .UserAddedFiles = Me.FileUpload1.FileName.ToString, .CreateDateTime = Now()}
        'link.Claims.InsertOnSubmit(row)
        'link.SubmitChanges()

        message.Subject = "Срочно! ОБРАЩЕНИЕ с сайта СП 1: "
        message.Priority = Net.Mail.MailPriority.High

        message.Body = "Сообщение от: " + Me.TextBoxFIO.Text + vbCrLf + "Адрес: " + Me.TextBoxAddress.Text + vbCrLf + "Контактный телефон: " + Me.TextBoxTelephone.Text + vbCrLf + _
            "e-mail: " + Me.TextBoxEmail.Text + vbCrLf + vbCrLf + vbCrLf + Me.TextBoxText.Text
        message.ReplyToList.Add(Me.TextBoxEmail.Text)
        Try
            Dim smtpClient As New System.Net.Mail.SmtpClient
            smtpClient.Send(message)
            Me.LabelError.Text = "Сообщение успешно отправлено и будет рассмотрено в установленные законодательством сроки."
            Me.LabelErrorPanel.Text = "Сообщение успешно отправлено и будет рассмотрено в установленные законодательством сроки."
            Me.LabelError.ForeColor = Drawing.Color.Green
            Me.Button1.Visible = False
            Me.PanelMainForm.Visible = False
            Me.PanelResult.Visible = True
            Me.LabelErrorPanel.Visible = True
        Catch ex As Exception
            Me.LabelError.Text = "Сообщение не отправлено. Приносим свои извиниения за технические неполадки"
            Me.LabelErrorPanel.Text = "Сообщение не отправлено. Приносим свои извиниения за технические неполадки"
            Me.SetFocus(LabelError)
        End Try






    End Sub
End Class