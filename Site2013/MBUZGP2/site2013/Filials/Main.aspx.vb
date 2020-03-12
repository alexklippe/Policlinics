Public Class Main
    Inherits System.Web.UI.Page
    Private mainModule As New mainModule

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim id As Integer

        If Not Integer.TryParse(Request.Params("Id"), id) Then
            id = 1
        End If

        Dim a As New List(Of String)
        a = mainModule.GetFilialInfo(id)

        Me.Label1.Text = a.Item(0)
        Me.Label2.Text = a.Item(1)
        Me.Label3.Text = a.Item(2)  'время
        Me.Label8.Text = a.Item(3)  'проезд
        Me.Label4.Text = a.Item(4) 'ФИО
        Me.Label7.Text = a.Item(5) 'Кабинет руков
        Me.Label5.Text = a.Item(6) 'Телеф руков
        Me.Label6.Text = a.Item(7) 'телефон регистратуры


    End Sub

End Class