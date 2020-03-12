<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ViewSwitcher.ascx.vb" Inherits="sp1taganrog.ru.ViewSwitcher" %>
<div id="viewSwitcher">
    <%: CurrentView %> Вид | <a href="<%: SwitchUrl %>">Переключиться на <%: AlternateView %></a>
</div>
