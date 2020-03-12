

Public Class gl
    Shared Sub sendEvent(ByVal ex2 As String, Optional ByVal addText As String = "")
        Try
            Dim db As New mainDataContext
            'получаем организацию
            Dim s As New System.Net.Mail.SmtpClient
            Dim cred As New System.Net.NetworkCredential
            cred.UserName = "www-robot@tgp2.ru"
            cred.Password = "Ghb.nLkzLtntq"

            s.Host = "smtp.mail.ru"
            s.Port = "587"
            s.EnableSsl = True
            s.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            s.Credentials = cred
            'отправляем письмо в регистратуру
            'Заголовок
            Dim mail As New System.Net.Mail.MailMessage
            Dim MailFrom As New System.Net.Mail.MailAddress(cred.UserName)

            mail.From = MailFrom

            mail.To.Add("admin@tgp2.ru")
            mail.To.Add("alex@jabbam.net")

            mail.IsBodyHtml = True
            mail.BodyEncoding = System.Text.Encoding.UTF8
            'тема
            mail.Subject = "Ошибка на сайте записи"
            mail.Priority = Net.Mail.MailPriority.High
            'тело сообщения
            Dim msText As String = "Доп текст: " + vbCrLf + vbCrLf + "текст ошибки" + ex2
        Catch ex As Exception

        End Try



    End Sub
    Shared Sub LogItem(ByVal title As String, ByVal text As String, Optional ByVal code As Integer = 0, Optional ByVal idorg As Integer = 0, Optional ByVal site As String = "", Optional ByVal IP As String = "")
        Try
            Dim db As New mainDataContext



            Dim q As New Log With {.code = code, .idOrg = idorg, .Text = text.Substring(0, 254), .Title = title.Substring(0, 99), .Site = site, .DateTime = Now, .ClientIPAddress = IP}

            db.Log.InsertOnSubmit(q)
            db.SubmitChanges()
        Catch ex As Exception

        End Try




    End Sub

    Shared Function GetOrgId(ByVal ReqUrlHost As String) As Integer
        Dim OrgId As Integer = 0
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = ReqUrlHost Or p.OrgTestDomainName = ReqUrlHost
        OrgId = query.First.id
        Return OrgId
    End Function


    ''' <summary>
    ''' Returns a random string of the specified length. 
    ''' </summary>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' All supported characters are contained in the chars() string array. Characters can be added or removed from this array to
    ''' add or remove them from inclusion when the random string is created.
    ''' bpell
    ''' </remarks>
    Shared Function RandomString(ByVal length As Integer) As String
        Dim sb As New System.Text.StringBuilder
        Dim chars() As String = {"а", "б", "в", "г", "д", "е", "ж", "и", "й", "к", "л", "м", "н", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ь", "ы", "ъ", "э", _
               "ю", "я", "А", "Б", "В", "Г", "Д", "Е", "Ж", "И", "Й", "К", "Л", "М", "Н", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", _
               "Ш", "Щ", "Э", "Ю", "Я", "1", "2", "4", "5", "6", "7", "8", "9"}
        Dim upperBound As Integer = UBound(chars)
        Dim r As New Random
        For x As Integer = 1 To length
            sb.Append(chars(Int(r.Next(0, upperBound))))
        Next

        Return sb.ToString

    End Function

End Class
