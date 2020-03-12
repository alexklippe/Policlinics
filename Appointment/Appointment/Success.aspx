<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Success.aspx.vb" Inherits="Appointment.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="registrationform ">
        <asp:Panel ID="Panel1" runat="server">
        <h4>Запись произведена.</h4>

        <p>Спасибо. Ваша заявка на прием к врачу принята. Просьба дождаться подтверждения записи. Для проверки статуса зайдите на страницу&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server">&quot;СТАТУС ЗАПИСИ&quot;</asp:HyperLink>
            &nbsp;и введите код записи. </p>
            <p>Запишите следующий код для проверки статуса записи на прием (все сиволы указаны русскими буквами):</p>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />
            
        <p>Хорошего Вам дня.</p>

</asp:Panel>

<asp:Panel ID="Panel2" runat="server" Visible="false">
        <h4>Запись отменена. </h4>

        <p>Спасибо. Ваша заявка на прием к врачу отменена. Запись по этому талону будет доступна через 30 минут.</p>

        <p>Хорошего Вам дня.</p>

</asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="false">
        <h4>Никаких действий не произведено. </h4>

        <p>Извините, Ваш запрос не обработан, т.к. был обработан ранее.</p>

        <p>Хорошего Вам дня.</p>

</asp:Panel>
        <a href="Raspisanie">Перейти в расписание</a>

    </div>


</asp:Content>
