Imports Microsoft.VisualBasic


Public Class Raspisanie
    Inherits System.Web.UI.Page
    Dim showDays As Integer = 9
    Dim culture As New System.Globalization.CultureInfo("ru-ru")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext
    

        'получаем организацию
        Dim ord = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        For Each s In ord
            Me.Literal1.Text = "<h2>" + s.OrgFullName.ToString + "</h2><br/>"
            Me.HiddenField1.Value = s.id
            If Not IsPostBack Then
                LinqDataSource1.DataBind()
                DropDownList1.DataBind()
                DropDownList1.Items.Add("все")
            End If


            Dim fil As System.Linq.IQueryable(Of Appointment.OrgFilials)
            'пошли по филиалам
            If DropDownList1.SelectedItem.Text = "все" Then
                fil = From p2 In db.OrgFilials Where p2.idOrganization.Value = s.id Select p2
            Else
                fil = From p2 In db.OrgFilials Where p2.idOrganization.Value = s.id And p2.id = DropDownList1.SelectedValue Select p2
            End If


            'отображаем dropdown сос писком филиалов

            'Dim dd As New DropDownList
            'dd.DataSource = fil
            'dd.DataTextField = "filialName"
            'dd.DataValueField = "ID"
            'dd.AutoPostBack = True
            'dd.ID = "DDFilials"


            Me.Literal2.Text = ""
            For Each fils In fil

                'колонска, с которой отображаются талоны
                Dim showCol As Integer = ShowCols(fils.id)
                Dim regPhone As String = ""
                Try
                    regPhone = fils.FilialRegPhone.ToString
                Catch ex As Exception

                End Try
                Me.Literal2.Text = Me.Literal2.Text + "<h3>" + fils.filialName.ToString + " | " + fils.filialAddress.ToString + " | " + regPhone.ToString + "</h3><br/>"
                'а теперь само расписание по специальностям
                Dim spec_id = From p3 In db.Spec_Filial_ID Where p3.IDFilial = fils.id Order By p3.Specialnost.SpecialnostName Select p3
                For Each specs In spec_id
                    Dim SpecName = (From p4 In db.Specialnost Where p4.id = specs.IDSpec Select p4).FirstOrDefault

                    Me.Literal2.Text = Me.Literal2.Text + "<h4>" + SpecName.SpecialnostName.ToString + "</h4>"
                    If specs.IDSpec = 7 Then
                        Me.Literal2.Text = Me.Literal2.Text + "<div class='attention panel'> Внимание! Выберите своего терапевта к которому вы прикреплены. Уточнить имя или участок своего лечащего врача вы можете в регистратуре, по телефонам регистратуры а так же в форме обратной связи на официальной странице поликлиники. Выбрав не своего врача Вам откажут в записи либо в приеме, предложив заново записаться к своему лечащему врачу.</div>"
                    End If
                    'по врачам

                    Dim vrach_id = From p5 In db.Vrach_Spec_ID Where p5.IDSpec = specs.id Order By p5.Vrach.Surname Select p5
                    For Each vrachs In vrach_id
                        Dim VrachName = (From p6 In db.Vrach Where p6.id = vrachs.IDVrach Select p6).FirstOrDefault
                        Me.Literal2.Text = Me.Literal2.Text + "<span class='VrachName'>" + VrachName.Surname.ToString + " " + VrachName.Name.ToString.Substring(0, 1) + ". " + VrachName.MidName.ToString.Substring(0, 1) + "." + "</span>"
                        'выводим доп инфо по врачу из vrach_spec_id description
                        If Not vrachs.Description Is Nothing Then
                            Me.Literal2.Text = Me.Literal2.Text + "<span class='VrachName'> | " + vrachs.Description.Trim + "</span>"
                        End If
                        'Получение расписания
                        Dim rasp = From p7 In db.Raspisanie Where p7.ID_SPEC_VRACH = vrachs.id And p7.DatePriem >= Now() Order By p7.DatePriem, p7.StartPriem Select p7



                        Me.Literal2.Text = Me.Literal2.Text + "<div class='row rowRasp'>" 'строка
                        Dim qty_rows As Integer = 0
                        For Each rasp_row In rasp
                            'получаем талоны
                            Dim talons = From p In db.Talons Where p.DateTimePriem.Value.Date = rasp_row.DatePriem.Date And _
                                                p.VrachSpec_ID = vrachs.id And p.status = 1 And _
                                                (p.ReservedTill < Now() Or p.ReservedTill.HasValue = False) And (p.Accepted = 0 Or p.Accepted.HasValue = False) Select p

                            Dim talons2 = From p In db.Talons Where p.DateTimePriem.Value.Date = rasp_row.DatePriem.Date And _
                                                p.VrachSpec_ID = vrachs.id

                            Me.Literal2.Text = Me.Literal2.Text + "<div class='col-md-1'>" 'начало колонки
                            'если выходные отображаем другим цветом
                            If rasp_row.DatePriem.DayOfWeek = DayOfWeek.Saturday Or rasp_row.DatePriem.DayOfWeek = DayOfWeek.Sunday Then
                                Me.Literal2.Text = Me.Literal2.Text + "<span class='text-danger medium'>" + culture.DateTimeFormat.GetAbbreviatedDayName(rasp_row.DatePriem.DayOfWeek) + "<br />" + rasp_row.DatePriem.Date.Day.ToString + "." + rasp_row.DatePriem.Date.Month.ToString + "</span>" + "<br />"
                            Else
                                Me.Literal2.Text = Me.Literal2.Text + "<span class='text-warning medium'>" + culture.DateTimeFormat.GetAbbreviatedDayName(rasp_row.DatePriem.DayOfWeek) + "<br />" + rasp_row.DatePriem.Date.Day.ToString + "." + rasp_row.DatePriem.Date.Month.ToString + "</span><br />"
                            End If



                            If rasp_row.Status = 0 Then
                                'вычисляем колонку, с которой показываем талоны

                                'Время приема
                                Me.Literal2.Text = Me.Literal2.Text + "<div class='text-white'>" + rasp_row.StartPriem.Value.ToString.Substring(0, 5) + "-<br />" + rasp_row.EndPriem.Value.ToString.Substring(0, 5)

                                'Добавляем инфо о талонах, но только со след (рабочего) дня.

                                'если есть талоны и 
                                If talons2.Count > 0 And qty_rows >= showCol Then
                                    'показываем талоны
                                    If talons.Count > 0 Then


                                        Me.Literal2.Text = Me.Literal2.Text + " <a class='btn btn-primary-zap' href='" + Request.Url.Scheme.ToString + Uri.SchemeDelimiter.ToString + _
                                            Request.Url.Host.ToString + ":" + Request.Url.Port.ToString + _
                                            "/talons?vsid=" + rasp_row.ID_SPEC_VRACH.ToString + "&pdate=" + rasp_row.DatePriem.ToBinary.ToString + _
                                            "' target='_blank' title='Количество доступных талонов для записи.'><SPAN title=''>" + talons.Count.ToString + "</span></a> </div>"
                                    Else
                                        Me.Literal2.Text = Me.Literal2.Text + " <a class='btn btn-primary-zapend'  title='Свободных талонов нет.'><SPAN title=''>" + talons.Count.ToString + "</span></a> </div>"
                                    End If



                                ElseIf talons2.Count > 0 And qty_rows < showCol Then
                                    Me.Literal2.Text = Me.Literal2.Text + " <a class='btn btn-primary-zapend'  title='Запись завершена.'><SPAN title=''>ЗАКР</span></a> </div>"
                                Else
                                    Me.Literal2.Text = Me.Literal2.Text + "</div>"
                                End If

                                ElseIf rasp_row.Status = 1 Then
                                    Me.Literal2.Text = Me.Literal2.Text + "<div class='text-danger'>Выходной</div>"
                                ElseIf rasp_row.Status = 2 Then
                                    Me.Literal2.Text = Me.Literal2.Text + "<div class='text-danger'>Отпуск</div>"
                                ElseIf rasp_row.Status = 3 Then
                                    Me.Literal2.Text = Me.Literal2.Text + "<div class='text-danger'>Больничн</div>"
                                ElseIf rasp_row.Status = 4 Then
                                    Me.Literal2.Text = Me.Literal2.Text + "<div class='text-danger'>-</div>"
                                End If

                                Me.Literal2.Text = Me.Literal2.Text + "</div>" 'конец колонки
                                qty_rows += 1
                                If qty_rows > showDays Then
                                    Exit For
                                End If
                        Next
                        Me.Literal2.Text = Me.Literal2.Text + "</div>" 'конец строки
                    Next 'по врачам
                    Me.Literal2.Text = Me.Literal2.Text + "<hr />"
                Next ' по специальностям
            Next '  по филиалам
        Next 'организации
    End Sub

    Function ShowCols(ByVal idfilial As Integer) As Integer
        Dim db As New mainDataContext
        Dim ret As Integer = 1 'по умолчанию с первой
        Try
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday



            Dim workDays = (From q In db.WorkTimeEndZapisi Where q.idFilial = idfilial And q.DayOfWeek = Now.DayOfWeek Select q).First
            'но только со след (рабочего) дня.
            'только до 16:00 текущего дня

            'проверяем на гос праздник
            If workDays.IsWorkDay = True Then
                Dim gosHollyday = (From q In db.GosHollydays Where q.date = Now.Date Select q)
                If gosHollyday.Count > 0 Then
                    workDays.IsWorkDay = False
                End If
            End If

            If workDays.IsWorkDay = True And Now.TimeOfDay < workDays.EndWorkTime Then
                'сегодня работаем и нет 16:00
                ret = 1
            Else
                'сегодня работаем но больше 16:00 либо не работаем вовсе
                'проверка следующих дней на выходные
                For n3 = 1 To showDays - 1     'количество отображаемых дней
                    Dim n3tmp As Integer = n3
                    workDays = (From q In db.WorkTimeEndZapisi Where q.idFilial = idfilial And q.DayOfWeek = Now.AddDays(n3tmp).DayOfWeek Select q).First
                    'проверка на гос праздник
                    If workDays.IsWorkDay = True Then
                        Dim gosHollyday = (From q In db.GosHollydays Where q.date = Now.AddDays(n3tmp).Date Select q)
                        If gosHollyday.Count > 0 Then
                            workDays.IsWorkDay = False
                        End If
                    End If 'гос праздники

                    If workDays.IsWorkDay = True Then
                        ret = 1 + n3tmp
                        Exit For
                    End If
                Next

                'а если сегодня выходной?




            End If 'поиск отображаемой колонки с талонами
        Catch ex As Exception

        End Try
        Return ret
    End Function


End Class