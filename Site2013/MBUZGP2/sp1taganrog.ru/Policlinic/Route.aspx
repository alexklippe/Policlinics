<%@ Page Title="СХЕМА ПРОЕЗДА" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Route.aspx.vb" Inherits="sp1taganrog.ru.Route" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>><%: Title %></h1>
    <hr />
    <p>Стоматологическая поликлиника № 1 расположена недалеко от вокзала Таганрог I.</p>
    <p>       
На каком транспорте можно проехать:</p>
    Автобусы: 31, 34, 35<br />
    Маршрутки: 31, 34, 35, 74<br />
    Троллейбусы: 2, 5
    <br />
    (поликлиника находится между остановками "ул. имени Ивана Голубца" и "ул. Толбухина")<br /><br />
    <asp:Image ID="Image1" runat="server" class="img img-responsive img-rounded" ImageUrl="~/img/onmap.jpg"/>
</asp:Content>
