<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="accepted.aspx.vb" Inherits="Appointment.accepted" EnableSessionState="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Статус:<asp:Label ID="Label1" runat="server" Text="" ForeColor="#00CC00" Font-Bold="True" Font-Size="Large"></asp:Label>

    <hr />
    <h2>Список необработанных талонов</h2>
    <h3 style="background-color:red ">Внимание! Новые или необработаные талоны.</h3>


    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <h3 style="background-color:green ">Внимание! Талоны обработаны, но клиенту не доставлены подтверждениями на их почту.</h3>
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
</asp:Content>
