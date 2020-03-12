<%@ Page Title="Администрирование сайта" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="Default.aspx.vb" Inherits="Appointment._Default3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%: Title %>.</h2>
    <div class="jumbotron">
    
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/a/OrgEdit.aspx">Сведения об организации</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/a/FilialsEdit.aspx">Сведения о филиалах/отделениях</asp:HyperLink><br />
     <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/a/WorkTimeWebRegByFilial.aspx">Рабочее время оператора обрабатывающего заявки записи</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/a/SpecEdit.aspx">Каталог специальностей</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/a/FilialsSpec.aspx">Специальности, доступные в филиале/отделении</asp:HyperLink><br />
     <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/a/VrachCategory.aspx">Категории врачей</asp:HyperLink><br />
     <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/a/VrachObrazovanie.aspx">Образование врачей</asp:HyperLink><br />
     <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/a/Vrach.aspx">Справочник врачей</asp:HyperLink><br />
     <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/a/Filial-Spec-Vrach.aspx">Врачи по специальностям</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/a/Raspisanie.aspx">Расписание</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/a/Talons.aspx">Талоны</asp:HyperLink><br />
        <hr />
        <h2>Заявки</h2>
        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/a/accepted.aspx">Заявки на запись</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/a/ListAppClients.aspx">Список всех записанных</asp:HyperLink><br />

        <hr />
        <h2>Отчеты</h2>
        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/a/rep/stat1.aspx">Статистика по записи</asp:HyperLink><br />

    </div>
</asp:Content>
