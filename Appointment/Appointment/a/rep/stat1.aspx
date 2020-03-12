<%@ Page Title="Отчет Статистика" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="stat1.aspx.vb" Inherits="Appointment.stat1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" DaysModeTitleFormat="MMMM.yyyy" FirstDayOfWeek="Monday" TargetControlID="TextBox1" TodaysDateFormat="d.MMMM.yyyy" format="dd.MM.yyyy"/>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" BehaviorID="TextBox2_CalendarExtender" TargetControlID="TextBox2" DaysModeTitleFormat="MMMM.yyyy" FirstDayOfWeek="Monday"  TodaysDateFormat="d.MMMM.yyyy" format="dd.MM.yyyy" />

    <asp:Button ID="Button1" runat="server" Text="Сформировать" />
    <hr />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</asp:Content>
