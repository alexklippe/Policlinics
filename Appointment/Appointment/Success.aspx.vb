Imports System.Threading
Public Class Success
    Inherits System.Web.UI.Page
    Dim MailThread As New System.Threading.Thread(AddressOf SendMail)
    Dim MailThreadClient As New System.Threading.Thread(AddressOf SendMailtoClient)
    Dim talid As Integer
    Dim tdate As Date
    Dim zdate As Date
    Dim code As String
    Dim ipAddress As String = Context.Request.ServerVariables("HTTP_X_FORWARDED_FOR") + " " + Context.Request.ServerVariables("REMOTE_ADDR")
    Dim URLp As String = "https://"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Request.Params.Item("tid") = "" Then
                'отмена либо успешная запись
                If Not Request.Params.Item("tdate") Is Nothing Then
                    'отмена записи
                    talid = CInt(Request.Params.Item("tid"))
                    tdate = Date.FromBinary(Request.Params.Item("tdate"))
                    code = CStr(Request.Params.Item("code"))
                    Dim db As New mainDataContext
                    Dim tal = (From q In db.Talons Where q.id = talid And q.DateTimePriem = tdate Select q).First
                    If tdate = tal.DateTimePriem And code = tal.RNDCode Then
                        tal.status = 1
                        tal.Accepted = Nothing
                        tal.RNDCode = Nothing
                        tal.ReservedTill = Now.AddMinutes(30)
                        db.SubmitChanges()
                        gl.LogItem("Отмена записи на прием", "TalonID=" + tal.id.ToString, 100, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
                        MailThread.Start()
                        MailThreadClient.Start()
                        Me.Panel1.Visible = False
                        Me.Panel2.Visible = True
                        Me.Panel3.Visible = False
                    Else
                        Me.Panel1.Visible = False
                        Me.Panel2.Visible = False
                        Me.Panel3.Visible = True
                    End If

                Else 'успешная запись отображаем инфо о проверке статуса записи
                    talid = CInt(Request.Params.Item("tid"))
                    Dim talrnd As String = CStr(Request.Params.Item("rn"))
                    Dim db As New mainDataContext
                    Dim tal = (From q In db.Talons Where q.id = talid And q.RNDCode = talrnd).First
                    If tal.id = talid Then
                        'если действительно найден такой талон
                        Me.Label1.Text = talrnd.ToString + talid.ToString
                        Me.HyperLink1.NavigateUrl = "~/prov?code=" + talrnd.ToString + talid.ToString

                        Me.Panel1.Visible = True
                        Me.Panel2.Visible = False
                        Me.Panel3.Visible = False
                    Else 'если не найден
                        Me.Panel1.Visible = False
                        Me.Panel2.Visible = False
                        Me.Panel3.Visible = True
                    End If


                End If

            Else
                Me.Panel1.Visible = False
                Me.Panel2.Visible = False
                Me.Panel3.Visible = True
            End If
        Catch ex As Exception
            gl.sendEvent(ex.ToString, "1 success.aspx.vb")
        End Try

    End Sub
    Sub SendMail()
        'настройки почтового сервера
        Try
            Dim db As New mainDataContext
            Dim talons = (From p In db.ViewByTalonId Where p.id = talid Select p).First
            Dim tal = (From q In db.Talons Where q.id = talid Select q).First
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
                'mail.To.Add(talons.filialEmail)
            Else
                mail.To.Add(org.SMTPMailToDefault)
            End If

            mail.IsBodyHtml = True
            mail.BodyEncoding = System.Text.Encoding.UTF8
            'тема
            mail.Subject = "Отмена ЗАПИСИ На ПРИЕМ с САЙТА"
            mail.Priority = Net.Mail.MailPriority.High
            'тело сообщения
            Dim msText As String = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>Запись на прием с сайта</title>"
            msText += "</head><body><h2>Произведена отмена записи Пациента</h2><form action='http://" + org.OrgDomainName + "/a/accepted' method='get'><fieldset>"
            msText += "<p>Фамилия: " + tal.ClientSurname.ToString.Substring(0, 1) + "</p>"
            msText += "<p>Имя: " + tal.ClientName.ToString + "</p>"
            msText += "<p>Отчество: " + tal.ClientMidname.ToString + "</p>"
            msText += "<p>Дата рождения: " + tal.ClientBirthday.Value.ToShortDateString + "</p>"
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

            msText += "<p>Специальность врача: " + talons.SpecialnostName.ToString + "</p>"
            msText += "<p>Врач: " + talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString + "</p><br />"
            msText += "<p>Дата/время талона: " + tal.DateTimePriem.ToString + "</p>"
            msText += " <p>Номер талона: " + tal.id.ToString + "</p><br />"

            msText += "<p>E-mail пациента: " + tal.ClientEmail.ToString + "</p>"
            msText += "<p>Телефон пациента: " + tal.ClientPhone.ToString + "</p><br />"

            msText += "<input id='HiddenIDTALON' name='HiddenIDTALON'  type='hidden' value='" + tal.id.ToString + "' />"
            ''  msText += "<select id='Select1' name='Select1'><option value='1' selected >Подтверждаю запись на прием</option><option value='2'>ОТКАЗЫВАЮ в записи на прием</option></select>"
            ''   msText += "<p>Причина отказа:</p><textarea id='TextOtkaza' name='TextOtkaza' type='text' cols='100' rows='5' ></textarea><br /><input type='submit' value='Отправить' formtarget='_blank'>"
            msText += "</fieldset></form>"
            ' msText += "<p>Для подтверждения/отказа пройдите по ссылке: <a href='http://" + org.OrgDomainName + "/a/accepted?HiddenIDTALON=" + tal.id.ToString + "</a></p>"
            msText += "</body></html>"
            mail.Body = msText
            Try
                s.Send(mail)
                gl.LogItem("Отмена записи на прием отправка письма оператору", "TalonID=" + tal.id.ToString, 110, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
            Catch ex As Exception
                gl.LogItem("Отмена записи на прием отправка письма оператору Ошибка", "TalonID=" + tal.id.ToString + " " + ex.ToString, 111, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
            End Try

        Catch ex As Exception
            gl.sendEvent(ex.ToString, "2 success.aspx.vb")
        End Try

    End Sub

    Sub SendMailtoClient()


        Dim db As New mainDataContext
        Dim talons = (From p In db.ViewByTalonId Where p.id = talid Select p).First
        Dim tal = (From q In db.Talons Where q.id = talid Select q).First
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
            mail.Subject = org.OrgShortName.ToString + ". Подтверждение отмены записи на прием."
            'тело сообщения
            msText = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>Подтверждение записи на прием</title>"
            msText += "</head><body>"
            msText += "<h2>" + org.OrgFullName.ToString + "</h2>"
            msText += "<h2>" + URLp + org.OrgDomainName.ToString + "</h2>"
            msText += "<p><b>" + tal.ClientSurname.ToString + " " + tal.ClientName.ToString + " " + tal.ClientMidname.ToString + "</b>, Ваша заявка на посещение специалиста отменена, талон освобожден.</p>"
            msText += "<p>Талон №:" + talid.ToString + "</p>"
            msText += "<p>Филиал/отделение: <b>" + talons.filialName.ToString + "</b> Специальность врача: <b>" + talons.SpecialnostName.ToString + "</b></p>"
            msText += "<p>Врач: <b>" + talons.Surname.ToString + " " + talons.Name.ToString + " " + talons.MidName.ToString + "</b></p><br />"
            msText += "<p>Дата/время талона: <b>" + tal.DateTimePriem.ToString + "</b></p>"
            msText += " <p>Если вы обратитесь в учреждение с этим талоном, в приеме будет отказано.</p>"
            msText += "<p>С уважением, " + org.OrgShortName.ToString + "</p> "

            mail.Body = msText

            Try
                s.Send(mail)
                gl.LogItem("Отмена записи на прием отправка письма клиенту", "TalonID=" + tal.id.ToString, 120, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
            Catch ex As Exception
                gl.LogItem("Отмена записи на прием отправка письма клиенту Ошибка", "TalonID=" + tal.id.ToString + " " + ex.ToString, 121, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
            End Try

            tal.MessageToClientSent = True
            db.SubmitChanges()
        Catch ex As Exception

            gl.LogItem("Отмена записи на прием формирование письма клиенту Ошибка", ex.ToString, 131, org.id, Me.Page.AppRelativeVirtualPath, ipAddress)
            gl.sendEvent(ex.ToString, "3 success.aspx.vb")
        End Try
    End Sub
End Class