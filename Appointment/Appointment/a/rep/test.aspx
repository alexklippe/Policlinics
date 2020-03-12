<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="Appointment.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

          <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    

    <asp:Button ID="Button1" runat="server" Text="Сформировать" />
    <hr />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
