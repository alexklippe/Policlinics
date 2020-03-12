Public Class CAlendarItem
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetColor()

    End Sub



    Protected Sub ButtonCopy_Click(sender As Object, e As ImageClickEventArgs) Handles ButtonCopy.Click
        Dim BS As HiddenField = Parent.FindControl("BufferStatus")

        Dim BI As HiddenField = Parent.FindControl("BufferInterval")
        Dim BSH As HiddenField = Parent.FindControl("BufferStartHour")
        Dim BSM As HiddenField = Parent.FindControl("BufferEndtHour")
        Dim BEH As HiddenField = Parent.FindControl("BufferStartMinute")
        Dim BEM As HiddenField = Parent.FindControl("BufferEndMinute")
        BS.Value = Me.DropDownList3.SelectedValue
        BI.Value = Me.TextBox6.Text

        BSH.Value = Me.TextBox2.Text
        BSM.Value = Me.TextBox3.Text

        BEH.Value = Me.TextBox4.Text
        BEM.Value = Me.TextBox5.Text
    End Sub

    Protected Sub ButtonPaste_Click(sender As Object, e As ImageClickEventArgs) Handles ButtonPaste.Click
        Dim BS As HiddenField = Parent.FindControl("BufferStatus")

        Dim BI As HiddenField = Parent.FindControl("BufferInterval")
        Dim BSH As HiddenField = Parent.FindControl("BufferStartHour")
        Dim BSM As HiddenField = Parent.FindControl("BufferEndtHour")
        Dim BEH As HiddenField = Parent.FindControl("BufferStartMinute")
        Dim BEM As HiddenField = Parent.FindControl("BufferEndMinute")
        Me.DropDownList3.SelectedValue = BS.Value
        Me.TextBox6.Text = BI.Value

        Me.TextBox2.Text = BSH.Value
        Me.TextBox3.Text = BSM.Value

        Me.TextBox4.Text = BEH.Value
        Me.TextBox5.Text = BEM.Value

    End Sub
    Sub SetColor()
        If Me.DropDownList3.SelectedValue = 0 Then
            Me.DropDownList3.BackColor = Drawing.Color.Green
        ElseIf Me.DropDownList3.SelectedValue = 1 Then
            Me.DropDownList3.BackColor = Drawing.Color.Red
        ElseIf Me.DropDownList3.SelectedValue = 2 Then
            Me.DropDownList3.BackColor = Drawing.Color.Blue
        ElseIf Me.DropDownList3.SelectedValue = 3 Then
            Me.DropDownList3.BackColor = Drawing.Color.Yellow
        ElseIf Me.DropDownList3.SelectedValue = 4 Then
            Me.DropDownList3.BackColor = Drawing.Color.Gray
        End If
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList3.SelectedIndexChanged

        SetColor()

    End Sub
End Class