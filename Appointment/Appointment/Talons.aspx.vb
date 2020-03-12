Public Class Talons2
    Inherits System.Web.UI.Page

    Dim ipAddress As String = Context.Request.ServerVariables("HTTP_X_FORWARDED_FOR") + " " + Context.Request.ServerVariables("REMOTE_ADDR")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim culture As New System.Globalization.CultureInfo("ru-ru")
        If Request.HttpMethod.ToString = "GET" Then
            Try


                If Request.Params.Item("vsid").Length > 0 Then
                    Dim IdVrachaScpec As Integer = CInt(Request.Params.Item("vsid").ToString)
                    Dim DatePriem As Date = System.DateTime.FromBinary(Request.Params.Item("pDate").ToString)
                    Dim db As New mainDataContext
                    'Dim tal = From q In db.Talons Where q.VrachSpec_ID = IdVrachaScpec Select q

                    Dim talons = From q In db.ViewByTalonId Where q.VrachSpecID = IdVrachaScpec And q.DateTimePriem.Value.Date >= Now.Date And q.DateTimePriem.Value.Date = DatePriem.Date And q.status = 1 And (q.ReservedTill < Now Or q.ReservedTill.HasValue = False) Select q

                    Dim vr_sp_id = (From q22 In db.Vrach_Spec_ID Where q22.id = IdVrachaScpec Select q22).FirstOrDefault

                    If talons.Count > 0 And (talons.First.OrgDomainName = Request.Url.Host.ToString Or talons.First.OrgTestDomainName = Request.Url.Host.ToString) Then
                        OrgId.Value = talons.First.OrgId

                        'получаем организацию
                        Me.Literal1.Text = Me.Literal1.Text + "<h2>" + talons.First.OrgFullName.ToString + "</h2>"

                        'Формируем сведения о враче и дне записи
                        Me.Literal2.Text = Me.Literal2.Text + "Филиал/отделение: <span class='text-info'>" + talons.First.filialName + "</span><br/>"
                        Me.Literal2.Text = Me.Literal2.Text + "Адрес оказания помощи: <span class='text-info'>" + talons.First.filialAddress + "</span><br/>"
                        Me.Literal2.Text = Me.Literal2.Text + "Специальность врача: <span class='text-info'>" + talons.First.SpecialnostName + "</span><br/>"
                        Me.Literal2.Text = Me.Literal2.Text + "Врач: <span class='text-info'>" + talons.First.Surname + " " + talons.First.Name + " " + talons.First.MidName + ""
                        If vr_sp_id.Description Is Nothing Then
                            Me.Literal2.Text = Me.Literal2.Text + "</span><br/>"
                        Else
                            Me.Literal2.Text = Me.Literal2.Text + " | " + vr_sp_id.Description.Trim + "</span><br/>"
                        End If

                        Me.Literal2.Text = Me.Literal2.Text + "Категория врача: <span class='text-info'>" + talons.First.CategoryName + "</span><br/>"
                        Me.Literal2.Text = Me.Literal2.Text + "Образование врача: <span class='text-info'>" + talons.First.Obrazovanie + "</span><br/>"
                        Me.Literal2.Text = Me.Literal2.Text + "Дата приема: <span class='text-info'>" + culture.DateTimeFormat.GetDayName(talons.First.DateTimePriem.Value.DayOfWeek) + " " + (talons.First.DateTimePriem.Value.Date) + "</span><br/>"
                        If Not vr_sp_id.OsobennostPriema Is Nothing Then

                            Me.Literal2.Text = Me.Literal2.Text + "Особенности приема: <span class='text-info'>" + vr_sp_id.OsobennostPriema.Trim + "</span><br/>"
                        End If

                        'для терапевта
                        If talons.First.SpecialnostName.ToString.ToLower = "терапевт" Then
                            Me.Literal4.Text = "<li><div class='attention panel'> Внимание! При записи к терапевту выберите врача к которому вы прикреплены. Уточнить имя или участок своего лечащего врача вы можете в регистратуре, по телефонам регистратуры а так же в форме обратной связи на официальной странице поликлиники. Выбрав не своего врача Вам откажут в записи либо в приеме, предложив заново записаться к своему лечащему врачу.</div> </li>"
                        Else
                            Me.Literal4.Text = ""
                        End If
                        'формируем доступные талоны
                        For Each s In talons
                            Me.Literal3.Text = Me.Literal3.Text + "<div><a class='btn btn-primary' href='" + Request.Url.Scheme.ToString + Uri.SchemeDelimiter.ToString _
                                + Request.Url.Host.ToString + ":" + Request.Url.Port.ToString + "/reg?tid=" + s.id.ToString + "&pdate=" + s.DateTimePriem.Value.ToBinary.ToString + "'>" + _
                                s.DateTimePriem.Value.ToShortTimeString.ToString + "</a></div><br />"
                        Next
                    Else
                        gl.LogItem("Отображение информации о талоне переброс клиента в расписание 1", "TalonID=" + talons.First.id.ToString, 310, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
                        Response.Redirect("http://" + Request.Url.Authority + "/raspisanie")
                    End If
                    gl.LogItem("Отображение информации о талоне клиенту", "TalonID=" + talons.First.id.ToString, 300, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
                Else
                    gl.LogItem("Отображение информации о талоне переброс клиента в расписание 2", "", 320, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
                    Response.Redirect("http://" + Request.Url.Authority + "/raspisanie")
                End If



            Catch ex As Exception
                gl.sendEvent(ex.ToString, "6 talons.aspx.vb")
                gl.LogItem("Отображение информации о талоне клиенту Ошибка", " " + ex.ToString, 301, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
                Response.Redirect("http://" + Request.Url.Authority + "/raspisanie")
            End Try
        Else
            gl.LogItem("Отображение информации о талоне переброс клиента в расписание 3", "", 330, gl.GetOrgId(Request.Url.Host), Me.Page.AppRelativeVirtualPath, ipAddress)
            Response.Redirect("http://" + Request.Url.Authority + "/raspisanie")
        End If
    End Sub

End Class