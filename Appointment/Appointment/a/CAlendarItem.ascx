<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CAlendarItem.ascx.vb" Inherits="Appointment.CAlendarItem" %>
   
<div style="background-color:#b9b079">
<asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True"></asp:Label>
   <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="Статус сотрудника" AutoPostBack="True" >
       <asp:ListItem Value="0">Раб</asp:ListItem>
       <asp:ListItem Value="1">Вых</asp:ListItem>
       <asp:ListItem Value="2">Отп</asp:ListItem>
       <asp:ListItem Value="3">Боль</asp:ListItem>
       <asp:ListItem Value="4">Отсу</asp:ListItem>
                  </asp:DropDownList>
               
                 
                  <asp:TextBox ID="TextBox6" runat="server" ToolTip="Интервал времени приема, используется для генерации талонов" Width="20px"></asp:TextBox>
                 
                  <br />
    <div style="background-color:#72bebe">
                  <asp:TextBox ID="TextBox2" runat="server" Width="20px" Font-Bold="True" ToolTip="Час начала приема"></asp:TextBox>
                  :<asp:TextBox ID="TextBox3" runat="server" Width="20px" Font-Bold="True" ToolTip="Минуты начала приема"></asp:TextBox>&nbsp;
    <asp:ImageButton ID="ButtonCopy" runat="server" ImageUrl="~/a/img/copy.png" AlternateText="Копировать" ImageAlign="Middle" ToolTip="Копировать..." />
    </div>
                  -<div style="background-color:#72bebe"><asp:TextBox ID="TextBox4" runat="server" Width="20px" Font-Bold="True" ToolTip="Час окончания приема"></asp:TextBox>
                  :<asp:TextBox ID="TextBox5" runat="server" Width="20px" Font-Bold="True" ToolTip="Минуты окончания приема"></asp:TextBox>&nbsp;
    <asp:ImageButton ID="ButtonPaste" runat="server" ImageUrl="~/a/img/paste.png" AlternateText="Вставить" Height="17px" ToolTip="Вставить" Width="19px" />
    </div>


<div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:HiddenField ID="HiddenFieldIdInBase" runat="server" /></div>
