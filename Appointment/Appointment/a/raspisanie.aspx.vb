Public Class Filial_Spec_Vrach_ADD
    Inherits System.Web.UI.Page
    Dim culture As New System.Globalization.CultureInfo("ru-ru")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        OrgId.Value = query.First.id
        If Not IsPostBack Then
            Me.DropDownListYear.SelectedValue = Now.Year
            Me.DropDownListMonth.SelectedValue = Now.Month
        Else
            ' FillCalendar()

        End If
        'If Me.LabelId.Text = "0" Then
        '    Me.PlaceHolder1.Visible = False
        'Else
        '    Me.PlaceHolder1.Visible = True
        'End If

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
    ''получаем дату первого квадратика
    Function getFirstDay() As Date
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday
        Dim SelectedDate As Date = "1." + DropDownListMonth.SelectedValue.ToString + "." + DropDownListYear.SelectedValue.ToString
        Dim WeekDayNum As Integer = SelectedDate.DayOfWeek
        Dim firstDay As Date = SelectedDate.AddDays(-WeekDayNum - 6)

        Return firstDay
    End Function

    Function TimeAddZero(ByVal d As Integer) As String

        Return 0
    End Function


    Sub FillCalendar()


        Dim firstDay As Date = getFirstDay()
        Dim enddate As Date = getFirstDay().AddDays(49)
        Dim db As New mainDataContext

        For n = 0 To 49
            Dim tmp As Integer = n

            Dim que = From p In db.Raspisanie Where p.DatePriem = firstDay.AddDays(tmp) And p.ID_SPEC_VRACH = CInt(Me.LabelId.Text) Select p

            If Not Me.PlaceHolder1.FindControl("CAlendarItem" + (n + 1).ToString) Is Nothing Then
                Dim x As CAlendarItem = CType(PlaceHolder1.FindControl("CAlendarItem" + (n + 1).ToString), CAlendarItem)
                Dim itemDD As DropDownList = x.FindControl("DropDownList3")
                Dim itemLbl As Label = x.FindControl("Label1")
                Dim itemStartHour As TextBox = x.FindControl("TextBox2")
                Dim itemEndHour As TextBox = x.FindControl("TextBox4")
                Dim itemStartMin As TextBox = x.FindControl("TextBox3")
                Dim itemEndMin As TextBox = x.FindControl("TextBox5")
                Dim itemInterval As TextBox = x.FindControl("TextBox6")
                Dim IdInBase As HiddenField = x.FindControl("HiddenFieldIdInBase")
                itemLbl.Text = firstDay.AddDays(tmp).Day.ToString + "." + firstDay.AddDays(tmp).Month.ToString


                If que.Count > 0 Then
                    itemDD.SelectedValue = que.First.Status
                    If que.First.intervalpriema Is Nothing Then
                        Dim qu2 = From q2 In db.ViewIntervalBySpec Where q2.id = CInt(Me.DropDownList2.SelectedValue.ToString) Select q2.IntervalPriemaByDefault
                        If qu2.Count > 0 Then
                            itemInterval.Text = qu2.First
                        End If

                    Else
                        itemInterval.Text = que.First.intervalpriema
                    End If


                    IdInBase.Value = que.First.id
                    If que.First.Status = 0 Then
                        Dim startPr As TimeSpan
                        Dim endPr As TimeSpan
                        Try
                            startPr = que.First.StartPriem.Value
                            endPr = que.First.EndPriem.Value
                        Catch ex As Exception
                            itemStartHour.Text = ""
                            itemStartMin.Text = ""
                            itemEndHour.Text = ""
                            itemEndMin.Text = ""
                        End Try

                        itemStartHour.Text = startPr.Hours
                        itemStartMin.Text = startPr.Minutes.ToString
                        itemEndHour.Text = endPr.Hours
                        itemEndMin.Text = endPr.Minutes.ToString
                    Else
                        itemStartHour.Text = ""
                        itemStartMin.Text = ""
                        itemEndHour.Text = ""
                        itemEndMin.Text = ""

                    End If
                Else
                    itemDD.SelectedValue = 4
                    itemStartHour.Text = ""
                    itemStartMin.Text = ""
                    itemEndHour.Text = ""
                    itemEndMin.Text = ""
                    '' itemInterval.Text = ""
                    IdInBase.Value = ""
                    Dim qu2 = From q2 In db.ViewIntervalBySpec Where q2.IDSpec = CInt(Me.DropDownList2.SelectedValue.ToString) Select q2.IntervalPriemaByDefault
                    If qu2.Count > 0 Then
                        itemInterval.Text = qu2.First
                    End If
                End If ' if count >0
                x.SetColor()

            End If 'find control
        Next
        Me.PlaceHolder1.Visible = True

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'кнопка показать
        FillCalendar()

    End Sub



    Protected Sub GridView1_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim row As GridViewRow = GridView1.Rows(e.NewSelectedIndex)
        Dim db As New mainDataContext
        Dim que = (From p In db.Vrach Where p.id = row.Cells(2).Text Select p).First
        Me.LabelFIO.Text = que.Surname + " " + que.Name + " " + que.MidName
        Me.LabelId.Text = row.Cells(1).Text
        Me.LabelVrachId.Text = row.Cells(2).Text
        Me.PlaceHolder1.Visible = True
        FillCalendar()

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Сохранить
        Me.PlaceHolder1.Visible = False

        Dim firstDay As Date = getFirstDay()
        Dim enddate As Date = getFirstDay().AddDays(49)
        Dim db As New mainDataContext

        For n = 0 To 49
            Dim tmp As Integer = n


            '' Dim que = From p In db.Raspisanie Where p.DatePriem = firstDay.AddDays(tmp) And p.ID_SPEC_VRACH = CInt(Me.LabelId.Text) Select p

            If Not Me.PlaceHolder1.FindControl("CAlendarItem" + (n + 1).ToString) Is Nothing Then
                Dim x As CAlendarItem = CType(PlaceHolder1.FindControl("CAlendarItem" + (n + 1).ToString), CAlendarItem)
                Dim itemDD As DropDownList = x.FindControl("DropDownList3")
                Dim itemLbl As Label = x.FindControl("Label1")
                Dim itemStartHour As TextBox = x.FindControl("TextBox2")
                Dim itemEndHour As TextBox = x.FindControl("TextBox4")
                Dim itemStartMin As TextBox = x.FindControl("TextBox3")
                Dim itemEndMin As TextBox = x.FindControl("TextBox5")
                Dim itemInterval As TextBox = x.FindControl("TextBox6")
                Dim IdInBase As HiddenField = x.FindControl("HiddenFieldIdInBase")
                Dim startTime As TimeSpan
                Dim EndTime As TimeSpan
                'проверяем по дате есть ли в базе
                Dim que = From p In db.Raspisanie Where p.DatePriem = itemLbl.Text + "." + Me.DropDownListYear.Text And p.ID_SPEC_VRACH = CInt(Me.LabelId.Text) Select p

                If que.Count > 0 Then
                    IdInBase.Value = que.First.id

                End If

                If IdInBase.Value = "" Then
                    'новая строка в базе
                    'status 0-работает, 1-выходной,2-отпуск,3-больничный,4-отсутствует по иным причинам
                    Dim ord As New Raspisanie With {.DatePriem = firstDay.AddDays(tmp), _
                                                    .ID_SPEC_VRACH = CInt(Me.LabelId.Text), _
                                                    .Status = itemDD.SelectedValue}
                    If itemDD.SelectedValue = 0 Then 'работает
                        If TimeSpan.TryParse(itemStartHour.Text + ":" + itemStartMin.Text + ":00", startTime) = True Then
                            ord.StartPriem = startTime
                        Else
                            'в случае если указано работает, но нет даты тогда ставим статус отсутствует, чтобы не возникало ошибок
                            ord.Status = 4
                        End If
                        If TimeSpan.TryParse(itemEndHour.Text + ":" + itemEndMin.Text + ":00", EndTime) = True Then
                            ord.EndPriem = EndTime
                        Else
                            'в случае если указано работает, но нет даты тогда ставим статус отсутствует, чтобы не возникало ошибок
                            ord.Status = 4
                        End If
                    Else
                        ord.Status = itemDD.SelectedValue
                    End If

                    If Not itemInterval.Text = "" Then
                        ord.intervalpriema = CInt(itemInterval.Text)
                    End If


                    db.Raspisanie.InsertOnSubmit(ord)
                Else
                    'существет уже в базе
                    Dim qu = (From p In db.Raspisanie Where p.id = CInt(IdInBase.Value) Select p).First

                    qu.Status = itemDD.SelectedValue
                    If qu.Status = 0 Then
                        If TimeSpan.TryParse(itemStartHour.Text + ":" + itemStartMin.Text + ":00", startTime) = True Then
                            qu.StartPriem = startTime
                        Else
                            'если с временем фигня какаято
                            qu.Status = 4
                        End If
                        If TimeSpan.TryParse(itemEndHour.Text + ":" + itemEndMin.Text + ":00", EndTime) = True Then
                            qu.EndPriem = EndTime
                        Else
                            'если с временем фигня какаято
                            qu.Status = 4
                        End If
                    Else
                        qu.Status = itemDD.SelectedValue
                    End If

                    If Not itemInterval.Text = "" Then
                        qu.intervalpriema = CInt(itemInterval.Text)
                    End If


                End If


            End If
        Next
        db.SubmitChanges()
        FillCalendar()
        Me.Label2.Text = "Сохранено успешно."
        Me.Label2.ForeColor = Drawing.Color.Green
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

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '' заполняем со второй недели
        fill(1)

    End Sub


    Sub fill(ByVal start As Integer)
        For n = (start * 7) + 1 To 49
            Dim tmp As Integer = n
            Dim x_source As CAlendarItem = CType(PlaceHolder1.FindControl("CAlendarItem" + (n - 7).ToString), CAlendarItem)
            Dim x_target As CAlendarItem = CType(PlaceHolder1.FindControl("CAlendarItem" + (n).ToString), CAlendarItem)

            Dim itemDD_s As DropDownList = x_source.FindControl("DropDownList3")
            Dim itemStartHour_s As TextBox = x_source.FindControl("TextBox2")
            Dim itemEndHour_s As TextBox = x_source.FindControl("TextBox4")
            Dim itemStartMin_s As TextBox = x_source.FindControl("TextBox3")
            Dim itemEndMin_s As TextBox = x_source.FindControl("TextBox5")
            Dim itemInterval_S As TextBox = x_source.FindControl("TextBox6")

            Dim itemDD_t As DropDownList = x_target.FindControl("DropDownList3")
            Dim itemStartHour_t As TextBox = x_target.FindControl("TextBox2")
            Dim itemEndHour_t As TextBox = x_target.FindControl("TextBox4")
            Dim itemStartMin_t As TextBox = x_target.FindControl("TextBox3")
            Dim itemEndMin_t As TextBox = x_target.FindControl("TextBox5")
            Dim itemInterval_t As TextBox = x_target.FindControl("TextBox6")

            itemDD_t.SelectedValue = itemDD_s.SelectedValue
            itemStartHour_t.Text = itemStartHour_s.Text
            itemEndHour_t.Text = itemEndHour_s.Text
            itemStartMin_t.Text = itemStartMin_s.Text
            itemEndMin_t.Text = itemEndMin_s.Text
            itemInterval_t.Text = itemInterval_S.Text
            x_target.SetColor()
        Next n
        Me.Label2.Text = ""
        Me.Label2.ForeColor = Drawing.Color.Black
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '' заполняем со 3 недели
        fill(2)
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '' заполняем со 4 недели
        fill(3)
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '' заполняем со 5 недели
        fill(4)
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        '' заполняем со 6 недели
        fill(5)
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        '' заполняем со 7 недели
        fill(6)
    End Sub
End Class