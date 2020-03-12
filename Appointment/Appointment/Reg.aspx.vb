Imports System.Threading


Public Class _Default1
    Inherits System.Web.UI.Page
    Dim MailThread As New System.Threading.Thread(AddressOf SendMail)
    Dim ipAddress As String = Context.Request.ServerVariables("HTTP_X_FORWARDED_FOR") + " " + Context.Request.ServerVariables("REMOTE_ADDR")
    Dim URLp As String = "https://"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim culture As New System.Globalization.CultureInfo("ru-ru")
            If Request.HttpMethod.ToString = "GET" Then
                Try


                    If Request.Params.Item("tid").Length > 0 Then
                        Dim IdTalon As Integer = CInt(Request.Params.Item("tid").ToString)
                        Dim DateTimePriem As Date = System.DateTime.FromBinary(Request.Params.Item("pDate").ToString)
                        Dim db As New mainDataContext
                        'Dim tal = From q In db.Talons Where q.VrachSpec_ID = IdVrachaScpec Select q
                        'проверка на роботы и сайты подложки

                        Dim talons = From q In db.ViewByTalonId Where q.id = IdTalon And q.DateTimePriem.Value = DateTimePriem And q.status = 1 And (q.ReservedTill < Now Or q.ReservedTill.HasValue = False) And _
                        (q.Accepted = 0 Or q.Accepted.HasValue = False) Select q

                        If talons.Count > 0 And (talons.First.OrgDomainName = Request.Url.Host.ToString Or talons.First.OrgTestDomainName = Request.Url.Host.ToString) And _
                            (talons.First.OrgDomainName = Request.UrlReferrer.Host.ToString Or talons.First.OrgTestDomainName = Request.UrlReferrer.Host.ToString) Then
                            HiddenFieldIdTalon.Value = talons.First.id

                            'получаем организацию
                            'Me.Literal1.Text = Me.Literal1.Text + "<h2>" + talons.First.OrgFullName.ToString + "</h2>"

                            'Формируем сведения о враче и дне записи
                            Me.Labelorg.Text = talons.First.OrgFullName.ToString
                            Me.LabelFil.Text = talons.First.filialName.ToString
                            Me.LabelAdd.Text = talons.First.filialAddress.ToString
                            Me.LabelSpec.Text = talons.First.SpecialnostName.ToString
                            Me.LabelVrach.Text = talons.First.Surname.ToString + " " + talons.First.Name.ToString + " " + talons.First.MidName.ToString
                            Me.LabelKat.Text = talons.First.CategoryName.ToString
                            Me.LabelObr.Text = talons.First.Obrazovanie.ToString
                            Me.LabelOsobenn.Text = (From d In db.Vrach_Spec_ID Where d.id = talons.First.VrachSpecID Select d.OsobennostPriema).First
                            Me.Labeldesc.Text = (From d In db.Vrach_Spec_ID Where d.id = talons.First.VrachSpecID Select d.Description).First
                            If talons.First.Certification Is Nothing Then
                                Me.LabelCert.Text = ""
                            Else
                                talons.First.Certification.ToString()
                            End If


                            Me.LabelDT.Text = culture.DateTimeFormat.GetDayName(talons.First.DateTimePriem.Value.DayOfWeek) + " " + (talons.First.DateTimePriem.Value.Date) + " " + talons.First.DateTimePriem.Value.ToShortTimeString

                            'резервируем талон
                            Dim tal = (From q In db.Talons Where q.id = IdTalon Select q).First
                            If getWCGA() = "1" Then
                                tal.ReservedTill = Now.AddMinutes(60)
                                Me.LabelTimeout.Text = "60"
                            Else
                                tal.ReservedTill = Now.AddMinutes(20)
                            End If

                            db.SubmitChanges()

                            'ТаймАйт 20 минут
                            Response.AppendHeader("Refresh", "1200;url=" + Request.Url.Scheme.ToString + Uri.SchemeDelimiter.ToString + _
                                            Request.Url.Host.ToString + ":" + Request.Url.Port.ToString + "/raspisanie")
                        Else
                            Response.Redirect(URLp + Request.Url.Authority + "/raspisanie")
                        End If

                    Else
                        Response.Redirect(URLp + Request.Url.Authority + "/raspisanie")
                    End If

                Catch ex As Exception
                    gl.sendEvent(ex.ToString, "4 reg.aspx.vb")
                    Response.Redirect(URLp + Request.Url.Authority + "/raspisanie")
                End Try
            Else
                Response.Redirect(URLp + Request.Url.Authority + "/raspisanie")
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'отменяем резерв талона
        Dim db As New mainDataContext
        Dim tal = (From q In db.Talons Where q.id = CInt(HiddenFieldIdTalon.Value) Select q).First
        tal.ReservedTill = Now
        db.SubmitChanges()
        Response.Redirect("~/Raspisanie")
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'получаем рандом код записи из 6 символов
        Dim rnd As String = gl.RandomString(6)
        'производим запись
        Dim db As New mainDataContext
        Dim tal = (From q In db.Talons Where q.id = CInt(HiddenFieldIdTalon.Value) Select q).First
        tal.status = 0 '0-занят
        tal.DateTimeZapisi = Now
        tal.ClientAddress = Me.TextBoxAddress.Text
        tal.ClientBirthday = Me.TextBoxBirthDay.Text
        tal.ClientEmail = Me.TextBoxEmail.Text
        tal.ClientMidname = Me.TextBoxMidName.Text
        tal.ClientName = Me.TextBoxName.Text
        tal.ClientPhone = Me.TextBoxPhone.Text
        tal.ClientPolisNum = Me.TextBoxPolisNum.Text
        tal.ClientPolisOrg = Me.TextBoxInsuranseCompany.Text
        tal.ClientSex = Me.RadioButtonList1.SelectedValue
        tal.ClientSurname = Me.TextBoxSurname.Text
        tal.ClientKarta = Me.DropDownListMedKarta.SelectedValue
        tal.RNDCode = rnd
        Try
            db.SubmitChanges()
            gl.LogItem("Запись на прием (запись в базу)", "TalonID=" + tal.id.ToString, 200, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
            'отправляем письма
            MailThread.Start()
            'Переходим на страницу с окончанием записи

            Response.Redirect("~/Success.aspx?tid=" + tal.id.ToString + "&rn=" + tal.RNDCode.ToString)
        Catch ex As Exception
            gl.LogItem("Запись на прием (запись в базу) ошибка", "TalonID=" + tal.id.ToString + " " + ex.ToString, 201, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
        End Try

    End Sub
    Sub SendMail()
        'настройки почтового сервера



        Dim db As New mainDataContext

        Dim talons = (From p In db.ViewByTalonId Where p.id = CInt(HiddenFieldIdTalon.Value) Select p).First

        Dim tal = (From q In db.Talons Where q.id = CInt(HiddenFieldIdTalon.Value) Select q).First

        Dim org = (From p In db.Organization Where p.id = talons.OrgId Select p).First

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
                mail.To.Add(listMail(n))
            Next
            ' mail.To.Add(talons.filialEmail)
        Else
            mail.To.Add(org.SMTPMailToDefault)
        End If
        mail.IsBodyHtml = True
        mail.BodyEncoding = System.Text.Encoding.UTF8

        'тема

        mail.Subject = "Запись на прием " + tal.ClientSurname.ToString + " к " + talons.Surname.ToString
        mail.Priority = Net.Mail.MailPriority.High
        'тело сообщения

        Dim msText As String = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>Запись на прием с сайта</title>"
        msText += "</head><body><h2>Произведена запись Пациента</h2><form action='" + URLp + org.OrgDomainName + "/a/accepted' method='get'><fieldset>"
        msText += "<p>Фамилия: <b>" + tal.ClientSurname.ToString + "</b></p>"
        msText += "<p>Имя: <b>" + tal.ClientName.ToString + "</b></p>"
        msText += "<p>Отчество: <b>" + tal.ClientMidname.ToString + "</b></p>"
        msText += "<p>Дата рождения: <b>" + tal.ClientBirthday.Value.ToShortDateString + "</b></p>"
        If tal.ClientSex = True Then
            msText += "<p>Пол: МУЖ</p>"
        Else
            msText += "<p>Пол: ЖЕН</p>"
        End If
        msText += "<p>Адрес: " + tal.ClientAddress.ToString + "</p>"
        msText += "<p>Страховой полис номер: " + tal.ClientPolisNum.ToString + "</p>"
        msText += "<p>Страховой полис организация: " + tal.ClientPolisOrg.ToString + "</p><br />"
        If tal.ClientKarta.Value = 1 Then
            msText += "<p>Карточка пациента: в учреждении</p><br />"
        ElseIf tal.ClientKarta.Value = 2 Then
            msText += "<p>Карточка пациента: на руках</p><br />"
        ElseIf tal.ClientKarta.Value = 3 Then
            msText += "<p>Карточка пациента: не знаю/создать новую</p><br />"
        End If
        msText += "<p>Филиал/отделение: " + talons.filialName.ToString + "</p>"
        msText += "<p>Специальность врача: " + talons.SpecialnostName.ToString + "</p>"
        msText += "<p>Врач: <b>" + talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString + "</b></p><br />"
        msText += "<p>Дата/время талона: <b>" + tal.DateTimePriem.ToString + "</b></p>"
        msText += " <p>Номер талона: " + tal.id.ToString + "</p><br />"

        msText += "<p>E-mail пациента: " + tal.ClientEmail.ToString + "</p>"
        msText += "<p>Телефон пациента: " + tal.ClientPhone.ToString + "</p><br />"

        msText += "<input id='HiddenIDTALON' name='HiddenIDTALON'  type='hidden' value='" + tal.id.ToString + "' />"
        msText += "<select id='Select1' name='Select1'><option value='1' selected >Подтверждаю запись на прием</option><option value='2'>ОТКАЗЫВАЮ в записи на прием</option></select>"
        msText += "<p>Причина отказа:</p><textarea id='TextOtkaza' name='TextOtkaza' type='text' cols='100' rows='5' ></textarea><br /><input type='submit' value='Отправить' formtarget='_blank'>"
        msText += "</fieldset></form>"
        ' msText += "<p>Для подтверждения/отказа пройдите по ссылке: <a href='http://" + org.OrgDomainName + "/a/accepted?HiddenIDTALON=" + tal.id.ToString + "</a></p>"
        msText += "</body></html>"
        mail.Body = msText
        Try

            s.Send(mail)

            gl.LogItem("Запись на прием (отправка письма оператору)", "TalonID=" + tal.id.ToString, 210, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
        Catch ex As System.Net.Mail.SmtpException
            gl.sendEvent(ex.ToString, "5 reg.aspx.vb")
            gl.LogItem("Запись на прием (отправка письма оператору) ошибка", "TalonID=" + tal.id.ToString + " status code" + ex.StatusCode.ToString + " stack:" + ex.StackTrace.ToString + " " + ex.ToString, 201, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)

            If ex.StatusCode = System.Net.Mail.SmtpStatusCode.TransactionFailed Then
                '' wait 5 seconds, try a second time

                Thread.Sleep(10000)

                s.Send(mail)
            Else
                Throw

            End If
        Finally
            '            mail.Dispose()
            'dispose later
        End Try
        ''*********************************************************************
        ''письмо клиенту с кодом записи
        mail.Subject = org.OrgShortName.ToString + ". Запись на прием."

        'тело сообщения

        msText = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>Подтверждение записи на прием</title>"
        msText += "</head><body>"
        msText += "<h2>" + org.OrgFullName.ToString + "</h2>"
        msText += "<h2>" + URLp + org.OrgDomainName.ToString + "</h2>"
        msText += "<p><b>" + tal.ClientName.ToString + " " + tal.ClientMidname.ToString + "</b>, Ваша заявка на посещение специалиста принята.</p>"
        msText += "<p>Талон №:" + tal.id.ToString + "</p>"
        msText += "<p>Филиал/отделение: <b>" + talons.filialName.ToString + "</b> Специальность врача: <b>" + talons.SpecialnostName.ToString + "</b></p>"
        msText += "<p>Врач: <b>" + talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString + "</b></p><br />"
        msText += "<p>Дата/время талона: <b>" + tal.DateTimePriem.ToString + "</b></p>"

        msText += " <p>Ваша заявка на запись на прием к врачу находится на обработке и ей присвоен код: " + tal.RNDCode.ToString + tal.id.ToString + "</p>"
        msText += "  <p>Для проверки статуса записи на прием можете воспользоваться этим кодом на странице <a href='" + URLp + org.OrgDomainName + "/prov?code=" + tal.RNDCode.ToString + tal.id.ToString + "' target='_blank'>СТАТУС ЗАПИСИ</a>.</p>"
        msText += "<p>Для отмены записи пройдите, пожалуйста,  <a href='" + URLp + org.OrgDomainName + "/success?tid=" + tal.id.ToString + "&tdate=" + tal.DateTimePriem.Value.ToBinary.ToString + "&zdate=" + tal.ReservedTill.Value.ToBinary.ToString + "' target='_blank'>по этой ссылке</a></p>"
        msText += "<p>С уважением, " + org.OrgShortName.ToString + "</p> "
        msText += "</body></html>"
        mail.Priority = Net.Mail.MailPriority.Low
        mail.Body = msText
        mail.To.Clear()
        mail.To.Add(tal.ClientEmail.ToString)

        Try

            s.Send(mail)

            gl.LogItem("Запись на прием (отправка письма оператору)", "TalonID=" + tal.id.ToString, 210, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
        Catch ex As System.Net.Mail.SmtpException
            gl.sendEvent(ex.ToString, "5 reg.aspx.vb")
            gl.LogItem("Запись на прием (отправка письма оператору) ошибка", "TalonID=" + tal.id.ToString + " status code" + ex.StatusCode.ToString + " stack:" + ex.StackTrace.ToString + " " + ex.ToString, 201, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)

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

    End Sub
    Function getWCGA()
        Dim requestCookie = Request.Cookies("WCGA")
        If requestCookie IsNot Nothing Then
            ' Использование маркера Anti-XSRF из файла cookie
            Return requestCookie.Value
        Else
            Return 0
        End If

    End Function
End Class