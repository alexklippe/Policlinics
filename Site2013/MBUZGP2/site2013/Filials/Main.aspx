<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Main.aspx.vb" Inherits="site2013.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   <h1>Муниципальное бюджетное учреждение здравоохранения &quot;Городская поликлиника №2&quot;</h1>
    <h2><asp:Label ID="Label1" runat="server"></asp:Label></h2>
<br />
&nbsp;находится по адресу
    <asp:Label ID="Label2" runat="server"></asp:Label>

<p>
    Часы работы:&nbsp;
    <asp:Label ID="Label3" runat="server"></asp:Label>
</p>
<p>
    Главный врач: Иванов Юрий Борисович</p>
<p>
    Заведующий:
    <asp:Label ID="Label4" runat="server"></asp:Label>
</p>
<p>
    Телефон руководителя:<asp:Label ID="Label5" runat="server"></asp:Label>
&nbsp;Кабинет:
    <asp:Label ID="Label7" runat="server"></asp:Label>
</p>
<p>
    Телефон регистратуры:<asp:Label ID="Label6" runat="server"></asp:Label>
</p>
<p>
    Как добраться:
    <asp:Label ID="Label8" runat="server"></asp:Label>
</p>
<p>
    &nbsp;</p>
</asp:Content>
