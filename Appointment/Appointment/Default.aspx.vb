Public Class _Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim db As New mainDataContext


        'получаем организацию
        Dim ord = From p In db.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host

        If ord.First.id = 7 Then
            Me.Literal1.Text = "<li><div class='attention panel'> Внимание! При записи к терапевту выберите врача к которому вы прикреплены. Уточнить имя или участок своего лечащего врача вы можете в регистратуре, по телефонам регистратуры а так же в форме обратной связи на официальной странице поликлиники. Выбрав не своего врача Вам откажут в записи либо в приеме, предложив заново записаться к своему лечащему врачу.</div> </li>"
        Else
            Me.Literal1.Text = ""
        End If
    End Sub

End Class