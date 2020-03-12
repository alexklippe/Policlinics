Imports System.Threading

Public Class accepted
    Inherits System.Web.UI.Page
    Dim MailThread As New System.Threading.Thread(AddressOf SendMail)
    Dim idTalon As Integer
    Dim ipAddress As String = Context.Request.ServerVariables("HTTP_X_FORWARDED_FOR") + " " + Context.Request.ServerVariables("REMOTE_ADDR")
    Dim URLp As String = "https://"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.HttpMethod = "GET" Or Request.HttpMethod = "POST" Then
            idTalon = CInt(Request.Params.Item("HiddenIDTALON"))
            If idTalon > 0 Then
                acceptTalon(idTalon)
            End If
        End If
        ShowNotAccepted()
        ShowNotSended()
    End Sub

    Sub acceptTalon(ByVal idtal As Integer)
        Dim db As New mainDataContext
        Dim tal = (From q In db.Talons Where q.id = idTalon Select q).First
        'Dim talon = (From q In db.ViewByTalonId Where q.id = idTalon Select q).First
        If CInt(Request.Params.Item("Select1")) = 1 Then
            'Подтверждено
            tal.Accepted = 1
        Else
            'отказано
            tal.Accepted = 2
        End If
        tal.AcceptedDateTime = Now
        tal.AcceptedText = ""
        Try
            tal.AcceptedText = Request.Params.Item("TextOtkaza").ToString
        Catch ex As Exception

        End Try

        Try
            db.SubmitChanges()
            gl.LogItem("Сохранена информация в базе о подтверждении/отказе талона ", "TalonID=" + tal.id.ToString, 410, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
        Catch ex As Exception
            gl.LogItem("Сохранена информация в базе о подтверждении/отказе талона (Ошибка) ", "TalonID=" + tal.id.ToString + " " + ex.ToString, 411, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
        End Try

        'отправляем письмо счастья
        SendMail()


    End Sub
    Sub SendMail()


        Dim db As New mainDataContext

        Dim talons = (From p In db.ViewByTalonId Where p.id = idTalon Select p).First

        Dim tal = (From q In db.Talons Where q.id = idTalon Select q).First

        Dim org = (From p In db.Organization Where p.id = talons.OrgId Select p).First
        Try

            Dim s As New System.Net.Mail.SmtpClient
            Dim cred As New System.Net.NetworkCredential
            cred.UserName = org.SMTPLogin
            cred.Password = org.SMTPPass

            s.Host = org.SMTPServer
            s.Port = org.SMTPPort
            s.EnableSsl = org.SMTPSSL
            s.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            s.Credentials = cred
            'отправляем письмо в регистратуру
            'Заголовок
            Dim mail As New System.Net.Mail.MailMessage
            Dim MailFrom As New System.Net.Mail.MailAddress(org.SMTPMailFrom)
            mail.From = MailFrom
            If talons.filialEmail.Length > 0 Then

                Dim listMail() As String
                listMail = talons.filialEmail.Split(";")
                For n = 0 To listMail.Count - 1
                    mail.ReplyToList.Add(listMail(n))
                Next
            Else
                mail.ReplyToList.Add(org.SMTPMailToDefault)

            End If
            mail.To.Add(tal.ClientEmail.ToString)

            mail.IsBodyHtml = True
            mail.BodyEncoding = System.Text.Encoding.UTF8
            mail.Priority = Net.Mail.MailPriority.High
            'тема
            Dim msText As String
            If tal.Accepted = 1 Then


                mail.Subject = org.OrgShortName.ToString + ". Подтверждение записи на прием."

                'тело сообщения

                msText = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>Подтверждение записи на прием</title>"
                msText += "</head><body>"
                msText += "<h2>" + org.OrgFullName.ToString + "</h2>"
                msText += "<h2>https://" + org.OrgDomainName.ToString + "</h2>"
                msText += "<p><b>" + tal.ClientSurname.ToString + " " + tal.ClientName.ToString + " " + tal.ClientMidname.ToString + "</b>, Ваша заявка на посещение специалиста <span style='color: #008000; font-weight: bold'> принята</sapn>.</p>"
                msText += "<p>Талон №:" + idTalon.ToString + "</p>"
                msText += "<p>Филиал/отделение: <b>" + talons.filialName.ToString + "</b> Специальность врача: <b>" + talons.SpecialnostName.ToString + "</b></p>"
                msText += "<p>Врач: <b>" + talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString + "</b></p><br />"
                msText += "<p>Дата/время талона: <b>" + tal.DateTimePriem.ToString + "</b></p>"

                msText += " <p>Вам необходимо за 15 минут до указанного времени явиться к кабинету выбранного Вами врача. С собой иметь – паспорт, полис, СНИЛС, при возможности распечатанное данное письмо.</p>"
                msText += "  <p>Если ранее Вы не обращались в указанную поликлинику, Вам необходимо за 30 минут до времени приема подойти в регистратуру, с собой иметь – паспорт, полис, СНИЛС.</p>"
                msText += " <p>При обращении к врачу необходимо иметь с собой сменную обувь или бахилы.</p>"
                'msText += " <p>Обращаем Ваше внимание, что если Вы не распечатаете данное письмо, у Вас могут возникнуть затруднения при обращении к врачу, т.к. оно заменяет Вам талон, выданный в регистратуре.</p>"
                msText += " <p>Все возникшие вопросы и претензии Вы можете задать в ответном электронном письме.</p>"
                msText += " <p>Если Вас отказались принять по данному обращению, Вы имеет право обратиться к руководителю организации, либо в форме обратной связи на сайте организации.</p><br />"
                msText += "<p>Для отмены записи пройдите, пожалуйста,  <a href='" + URLp + org.OrgDomainName + "/success?tid=" + idTalon.ToString + "&tdate=" + tal.DateTimePriem.Value.ToBinary.ToString + "&zdate=" + tal.ReservedTill.Value.ToBinary.ToString + "&code=" + tal.RNDCode + "' target='_blank'>по этой ссылке</a></p>"
                msText += "<p>С уважением, " + org.OrgShortName.ToString + "</p> "
            ElseIf tal.Accepted = 2 Then
                mail.Subject = org.OrgShortName.ToString + ". Отказ записи на прием."

                'тело сообщения

                msText = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>Подтверждение записи на прием</title>"
                msText += "</head><body>"
                msText += "<h2>" + org.OrgFullName.ToString + "</h2>"
                msText += "<h2>https://" + org.OrgDomainName.ToString + "</h2>"
                msText += "<p>" + tal.ClientSurname.ToString + " " + tal.ClientName.ToString + " " + tal.ClientMidname.ToString + ", Ваша заявка на посещение специалиста <span style='color: #FF0000; font-weight: bold'>отклонена</span>.</p>"
                msText += "<p>Талон №:" + idTalon.ToString + "</p>"
                msText += "<p>Специальность врача: <b>" + talons.SpecialnostName.ToString + "</b></p>"
                msText += "<p>Врач: <b>" + talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString + "</b></p><br />"
                msText += "<p>Дата/время талона: <b>" + tal.DateTimePriem.ToString + "</b></p>"
                msText += "<p>Причина отказа:<span style='color: #FF0000; font-weight: bold'>" + tal.AcceptedText + "</span></p>"
                msText += " <p>Все возникшие вопросы и претензии Вы можете задать в ответном электронном письме.</p>"
                msText += " <p>Если Вас отказались принять по данному обращению, Вы имеет право обратиться к руководителю организации, либо в форме обратной связи на сайте организации.</p><br />"
                msText += "<p>С уважением, " + org.OrgShortName.ToString + "</p> "
            Else
                Return

            End If
            msText += "</body></html>"
            mail.Body = msText
            Try

                s.Send(mail)

                Try
                    gl.LogItem("Отправка письма с подтверждением клиенту ", "TalonID=" + tal.id.ToString, 400, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
                    tal.MessageToClientSent = True
                    db.SubmitChanges()
                    Me.Label1.Text = "Письмо счастья отправлено."
                Catch ex As Exception
                    gl.LogItem("Отправка письма с подтверждением клиенту (Ошибка) ", "TalonID=" + tal.id.ToString + " " + ex.ToString, 403, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
                End Try

            Catch ex As System.Net.Mail.SmtpException
                gl.LogItem("Отправка письма с подтверждением клиенту (Ошибка) ", "TalonID=" + tal.id.ToString + " status code" + ex.StatusCode.ToString + " message:" + ex.Message.ToString, 401, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
                Me.Label1.ForeColor = Drawing.Color.Red
                Me.Label1.Text = "не доставлено! причина (от почтового сервера):" + ex.Message.ToString + " код ошибки:" + ex.StatusCode.ToString
                If ex.StatusCode = System.Net.Mail.SmtpStatusCode.MailboxUnavailable Then
                    Me.Label1.Text += vbCrLf + "НЕВЕРНО УКАЗАН ПОЧТОВЫЙ АДРЕС"
                End If
                If ex.StatusCode = System.Net.Mail.SmtpStatusCode.TransactionFailed Then
                    '' wait 5 seconds, try a second time

                    Thread.Sleep(10000)

                    s.Send(mail)
                Else
                    Throw

                End If
            Finally
                mail.Dispose()
            End Try
        Catch ex As Exception
            gl.sendEvent(ex.ToString, "7 a/accepted.aspx.vb")
            gl.LogItem("Формирование письма с подтверждением клиенту (Ошибка) ", ex.ToString, 402, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
        End Try



    End Sub

    Sub ShowNotAccepted()
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        Dim OrgId As Integer = query.First.id

        Dim query2 = From q In db.ViewTalonsWithVrachAndOrg Where q.status = 0 And (q.Accepted Is Nothing Or q.Accepted = 0) And q.DateTimePriem >= Now() And q.IDOrg = OrgId And q.ClientSurname <> Nothing Order By q.DateTimePriem Ascending, q.IDFilial Ascending
        Dim cart As String = ""
        Dim clSex As String = "Жен"
        If query2.Count > 0 Then
            '  Dim btn As New Button

            Me.Literal1.Text = "<ul>"
            For Each dbq2 In query2
                Me.Literal1.Text += "<form action='https://" + Request.Url.Authority + "/a/accepted' method='POST'><fieldset><input id='HiddenIDTALON' name='HiddenIDTALON'  type='hidden' value='" + dbq2.id.ToString + "' />"
                If dbq2.ClientKarta = 3 Then
                    cart = "не знаю/завести новую"
                ElseIf dbq2.ClientKarta = 2 Then
                    cart = "на руках"
                ElseIf dbq2.ClientKarta = 1 Then
                    cart = "в учреждении"
                End If
                If dbq2.ClientSex.Value = 1 Then
                    clSex = "Муж"
                End If
                Me.Literal1.Text += "<li>" + dbq2.id.ToString + "<br/>Филиал/отделение: <b>" + dbq2.filialName.ToString + "</b><br/> Врач: " + dbq2.SpecialnostName.ToString + " " + dbq2.Surname.ToString + " " + dbq2.Name.ToString + "</br> Прием: " +
                    dbq2.DateTimePriem.ToString + "</br>Пациент: " +
                    dbq2.ClientSurname.ToString + " " + dbq2.ClientName.ToString + " " + dbq2.ClientMidname.ToString + " " + dbq2.ClientBirthday.Value.ToShortDateString.ToString + " пол: (" + clSex + ")" +
                    "<br />Адрес: " + dbq2.ClientAddress.ToString + " " _
                    + "<br />Полис: " + dbq2.ClientPolisNum + " СК: " + dbq2.ClientPolisOrg + " " _
                    + "<br />Телефон: " + dbq2.ClientPhone.ToString + "<br />E-mail: " + dbq2.ClientEmail + "</br>Карточка: " + cart + "</br>"

                Me.Literal1.Text += "<select id='Select1' name='Select1'><option value='1' selected >Подтверждаю запись на прием</option><option value='2'>ОТКАЗЫВАЮ в записи на прием</option></select>"
                Me.Literal1.Text += "<p>Причина отказа:</p><textarea id='TextOtkaza' name='TextOtkaza' type='text' cols='100' rows='5' ></textarea><br /><input type='submit' value='Отправить' >"
                ' btn.PostBackUrl = "http://" + Request.Url.Authority + "/a/accepted' method='post'><fieldset><input id='HiddenIDTALON' name='HiddenIDTALON'  type='hidden' value='" + dbq2.id.ToString + "'"
                Me.Literal1.Text += "<p>Записался " + dbq2.DateTimeZapisi.ToString + "</p></fieldset></form>"

                Me.Literal1.Text += "</li>"
            Next
            Me.Literal1.Text += "</ul>"
        Else
            Me.Literal1.Text = ""
        End If


    End Sub

    Sub ShowNotSended()
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        Dim OrgId As Integer = query.First.id

        Dim query2 = From q In db.ViewTalonsWithVrachAndOrg Where q.status = 0 And (q.Accepted = 1) And q.DateTimePriem >= Now() And q.IDOrg = OrgId And q.ClientSurname <> Nothing And q.MessageToClientSent Is Nothing Order By q.DateTimePriem Ascending, q.IDFilial Ascending
        Dim cart As String = ""
        Dim clSex As String = "Жен"
        If query2.Count > 0 Then
            Me.Literal2.Text = "<ul>"
            For Each dbq2 In query2
                Me.Literal2.Text += "<form action='https://" + Request.Url.Authority + "/a/accepted' method='post'><fieldset><input id='HiddenIDTALON' name='HiddenIDTALON'  type='hidden' value='" + dbq2.id.ToString + "' />"
                If dbq2.ClientKarta = 3 Then
                    cart = "не знаю/завести новую"
                ElseIf dbq2.ClientKarta = 2 Then
                    cart = "на руках"
                ElseIf dbq2.ClientKarta = 1 Then
                    cart = "в учреждении"
                End If
                If dbq2.ClientSex.Value = 1 Then
                    clSex = "Муж"
                End If
                Me.Literal2.Text += "<li>" + dbq2.id.ToString + "<br/>Филиал/отделение: <b>" + dbq2.filialName.ToString + "</b><br/> Врач: " + dbq2.SpecialnostName.ToString + " " + dbq2.Surname.ToString + " " + dbq2.Name.ToString + "</br> Прием: " + _
                    dbq2.DateTimePriem.ToString + "</br>Пациент: " + _
                    dbq2.ClientSurname.ToString + " " + dbq2.ClientName.ToString + " " + dbq2.ClientMidname.ToString + " " + dbq2.ClientBirthday.Value.ToShortDateString.ToString + " пол: (" + clSex + ")" + _
                    "<br />Адрес: " + dbq2.ClientAddress.ToString + " " _
                    + "<br />Полис: " + dbq2.ClientPolisNum + " СК: " + dbq2.ClientPolisOrg + " " _
                    + "<br />Телефон: " + dbq2.ClientPhone.ToString + "<br />E-mail: " + dbq2.ClientEmail + "</br>Карточка: " + cart + "</br>"
                Me.Literal2.Text += "<select id='Select1' name='Select1'><option value='1' selected >Подтверждаю запись на прием</option><option value='2'>ОТКАЗЫВАЮ в записи на прием</option></select>"
                Me.Literal2.Text += "<p>Причина отказа:</p><textarea id='TextOtkaza' name='TextOtkaza' type='text' cols='100' rows='5' ></textarea><br /><input type='submit' value='Отправить' >"
                Me.Literal2.Text += "<p>Записался " + dbq2.DateTimeZapisi.ToString + "</p></fieldset></form>"

                Me.Literal2.Text += "</li>"
            Next
            Me.Literal2.Text += "</ul>"
        Else
            Me.Literal2.Text = ""
        End If


    End Sub

End Class