Public Class Talons1
    Inherits System.Web.UI.Page
    Dim culture As New System.Globalization.CultureInfo("ru-ru")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        OrgId.Value = query.First.id
        If Not IsPostBack Then
            Me.DropDownListYear.SelectedValue = Now.Year
            Me.DropDownListMonth.SelectedValue = Now.Month
            Me.NumOfWeek.Value = 0
            'FillCalendar()
        Else
            FillCalendar()
            SetFocus(Me.Panel1)
            Me.Panel1.Focus()

        End If
    End Sub
    Function VrachView(ByVal ids As String) As String
        Dim id As Integer = CInt(ids)
        If id > 0 Then
            Dim db As New mainDataContext
            Dim que = (From p In db.Vrach Where p.id = id Select p).First
            Return que.Surname + " " + que.Name + " " + que.MidName
        Else
            Return "-"
        End If
    End Function
    Function getFirstDay() As Date
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday
        Dim SelectedDate As Date
        If DropDownListMonth.SelectedValue = Now.Month.ToString And DropDownListYear.SelectedValue = Now.Year.ToString Then
            SelectedDate = Now.Day.ToString + "." + DropDownListMonth.SelectedValue.ToString + "." + DropDownListYear.SelectedValue.ToString
        Else
            SelectedDate = "1." + DropDownListMonth.SelectedValue.ToString + "." + DropDownListYear.SelectedValue.ToString
        End If

        Dim WeekDayNum As Integer = SelectedDate.DayOfWeek
        Dim firstDay As Date = SelectedDate.AddDays(-WeekDayNum + 1 + (Me.NumOfWeek.Value * 7))

        Return firstDay
    End Function
    Protected Sub GridView1_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim row As GridViewRow = GridView1.Rows(e.NewSelectedIndex)
        Dim db As New mainDataContext
        Dim que = (From p In db.Vrach Where p.id = row.Cells(2).Text Select p).First
        Me.LabelFIO.Text = que.Surname + " " + que.Name + " " + que.MidName
        Me.LabelId.Text = row.Cells(1).Text
        '' Me.PlaceHolder1.Visible = True

        'сбросить неделю
        Me.NumOfWeek.Value = 0
        'очистить таблицу при нажатии на врача

        ClearCalendar()

        FillCalendar()

    End Sub
    Sub ClearCalendar()
        For n = 1 To 7
            Dim tmp = n
            Dim x As PlaceHolder = CType(Me.Panel1.FindControl("PlaceHolder" + (tmp).ToString), PlaceHolder)
            x.Controls.Clear()
        Next

    End Sub
    Sub FillCalendar()
        If Me.LabelFIO.Text = "" Then
            Return
        End If


        Dim firstDay As Date = getFirstDay()
        Dim enddate As Date = getFirstDay().AddDays(7)
        Dim db As New mainDataContext
        For n = 1 To 7 ''заполняем колонки
            Dim tmp = n
            ''массив с расписанием
            Dim que = From p In db.Raspisanie Where p.DatePriem = firstDay.AddDays(tmp - 1) And p.ID_SPEC_VRACH = CInt(Me.LabelId.Text) And p.Status = 0 Select p

            If que.Count > 0 Then
                Dim startTime = que.First.StartPriem
                Dim endTime = que.First.EndPriem
                Dim interval = que.First.intervalpriema
                ''вычисляем количество талонов на текущий день
                Dim QtyTalonsPerThisDay As Integer = ((endTime - startTime).Value.TotalMinutes / interval)
                Dim x As PlaceHolder = CType(Me.Panel1.FindControl("PlaceHolder" + (tmp).ToString), PlaceHolder)
                x.ViewStateMode = UI.ViewStateMode.Enabled

                Dim tm As Date = firstDay.AddDays(tmp - 1) + startTime
                '' Dim pan As New Panel
                For m = 0 To QtyTalonsPerThisDay - 1

                    Dim qTalons = From q In db.Talons Where q.DateTimePriem = tm And q.VrachSpec_ID = CInt(Me.LabelId.Text) Select q

                    ''    pan.ID = "Panel" + n.ToString + m.ToString
                    Dim tal As TalonItem = LoadControl("~/a/TalonItem.ascx")
                    tal.ID = "TalonItem" + n.ToString + m.ToString
                    Dim chb As CheckBox = tal.FindControl("CheckBoxStatus")
                    chb.TextAlign = TextAlign.Left
                    'Dim lblDate As Label = tal.FindControl("LabelDate")
                    'Dim lblTime As Label = tal.FindControl("LabelTime")
                    Dim lblID As HiddenField = tal.FindControl("HiddenField1")
                    If qTalons.Count > 0 Then
                        chb.Text = qTalons.First.DateTimePriem.Value.ToString
                        If qTalons.First.status = 1 Then
                            chb.Checked = True
                        Else
                            chb.Checked = False
                        End If

                        'lblTime.Text = qTalons.First.DateTimePriem.Value.ToShortTimeString
                        lblID.Value = qTalons.First.id
                        If qTalons.First.Accepted = 1 Then
                            chb.Enabled = False
                            chb.BackColor = Drawing.Color.Red
                        End If
                        If qTalons.First.ReservedTill > Now Then
                            chb.Enabled = False
                            chb.BackColor = Drawing.Color.Red
                        End If
                    Else
                        chb.Text = tm.ToString
                        'lblTime.Text = tm.TimeOfDay.ToString
                        lblID.Value = ""
                    End If
                    x.Controls.Add(tal)

                    tm = tm.AddMinutes(interval)
                Next


            End If

        Next



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New mainDataContext
        Dim tal As TalonItem = LoadControl("~/a/TalonItem.ascx")
        ''читаем колонки
        For n = 1 To 7 ''заполняем колонки
            Dim tmp = n
            ''получаем колонку
            Dim x As PlaceHolder = CType(Me.Panel1.FindControl("PlaceHolder" + (tmp).ToString), PlaceHolder)

            Dim m As Integer = 0
            ''пошли по строкам в колонке
            For Each z In x.Controls
                Dim chb As CheckBox = x.Controls.Item(m).FindControl("CheckBoxStatus")
                Dim lblID As HiddenField = x.Controls.Item(m).FindControl("HiddenField1")
                If chb.Checked = True Then 'если стоит галка, то меняем статус либо создаем талон
                    If lblID.Value = "" Then 'создаем если новый
                        Dim ord As New Talons With {.DateTimePriem = CDate(chb.Text), .status = 1, .VrachSpec_ID = CInt(Me.LabelId.Text)}
                        db.Talons.InsertOnSubmit(ord)
                    Else 'меняем если старый

                        ''проверяем не был ли уже оформлен
                        Dim q3 = (From q In db.Talons Where q.id = CInt(lblID.Value) Select q).First
                        If q3.status = 0 And (q3.Accepted = 0 Or IsDBNull(q3.Accepted) = True) Then
                            q3.status = 1
                        End If

                    End If
                Else 'если не стоит галка, проверим еслы раньше стояла галка, то уберем ее, иначе ничего не делаем
                    If Not lblID.Value = "" Then 'проверяем предыдущий статус, при 1 меняем на 0
                        Dim q3 = (From q In db.Talons Where q.id = CInt(lblID.Value) Select q).First

                        If q3.status = 1 Then
                            q3.status = 0

                        End If
                    End If
                End If

                m += 1
            Next
            db.SubmitChanges()
        Next

        SetNextWeek()

    End Sub

    Sub SetNextWeek()
        Me.NumOfWeek.Value = CInt(Me.NumOfWeek.Value) + 1
        ClearCalendar()
        FillCalendar()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            LinqDataSourceSpec.DataBind()
            Me.DropDownList2.DataBind()
            LinqDataSource1.DataBind()
            Me.GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        Try
            LinqDataSource1.DataBind()
            Me.GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class