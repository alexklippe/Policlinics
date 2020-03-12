<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="ListAppClients.aspx.vb" Inherits="Appointment.ListAppClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
   
        <h2>Список всех записанных</h2>
        Начиная с <asp:Label runat="server" ID="Label1"></asp:Label>
        <p>Показаны все талоны со статусом записан. Таблица по умолчанию отсортирована по дате и времени записи, можно сортировать по любой колонке нажав на ее заголовок</p>
    <asp:Button ID="Button1" runat="server" Text="Показать только за сегодня" />
        <asp:Button ID="Button2" runat="server" Text="С сегодня +60 дней" />
    <asp:Button ID="Button3" runat="server" Text="Прошлые 7 дней" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <hr />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" PageSize="300">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="filialName" HeaderText="Филиал" SortExpression="filialName" />
                <asp:BoundField DataField="SpecialnostName" HeaderText="Специальность" SortExpression="SpecialnostName" />
                <asp:BoundField DataField="Surname" HeaderText="ВФамилия" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="ВИмя" SortExpression="Name" />
                <asp:BoundField DataField="MidName" HeaderText="ВОтчество" SortExpression="MidName" />
                <%--<asp:BoundField DataField="VrachSpecId" HeaderText="VrachSpecId" SortExpression="VrachSpecId" />--%>
                
                <asp:BoundField DataField="DateTimePriem" HeaderText="Дата время приема" SortExpression="DateTimePriem" />
                <asp:BoundField DataField="status" HeaderText="статус" SortExpression="status" />
          <%--      <asp:BoundField DataField="ReservedTill" HeaderText="резер до" SortExpression="ReservedTill" />--%>
                <asp:BoundField DataField="ClientSurname" HeaderText="КлФамилия" SortExpression="ClientSurname" />
                <asp:BoundField DataField="ClientName" HeaderText="КлИмя" SortExpression="ClientName" />
                <asp:BoundField DataField="ClientMidname" HeaderText="КлОтчество" SortExpression="ClientMidname" />
                <asp:CheckBoxField DataField="ClientSex" HeaderText="пол" SortExpression="ClientSex" />
                <asp:BoundField DataField="ClientBirthday" HeaderText="Дата рожд" SortExpression="ClientBirthday" />
                <asp:BoundField DataField="ClientEmail" HeaderText="Email" SortExpression="ClientEmail" />
                <asp:BoundField DataField="ClientPhone" HeaderText="Телефон" SortExpression="ClientPhone" />
                <asp:BoundField DataField="ClientAddress" HeaderText="Адрес" SortExpression="ClientAddress" />
                <asp:BoundField DataField="ClientPolisNum" HeaderText="Полис номер" SortExpression="ClientPolisNum" />
                <asp:BoundField DataField="ClientPolisOrg" HeaderText="полис Орг" SortExpression="ClientPolisOrg" />
                <asp:BoundField DataField="DateTimeZapisi" HeaderText="Дата время записи" SortExpression="DateTimeZapisi" />
                <asp:BoundField DataField="ClientKarta" HeaderText="Карточка" SortExpression="ClientKarta" />
                <asp:BoundField DataField="Accepted" HeaderText="Подтверждено" SortExpression="Accepted" />
                <asp:BoundField DataField="AcceptedDateTime" HeaderText="Дата подтверждения" SortExpression="AcceptedDateTime" />
                <asp:BoundField DataField="AcceptedText" HeaderText="Текс отказа" SortExpression="AcceptedText" />
                <asp:CheckBoxField DataField="MessageToClientSent" HeaderText="email отправлен" SortExpression="MessageToClientSent" />
                <asp:BoundField DataField="RNDCode" HeaderText="проверочный код" SortExpression="RNDCode" />
                <%--<asp:BoundField DataField="IDFilial" HeaderText="IDFilial" SortExpression="IDFilial" />--%>
                
            </Columns>
        </asp:GridView>
        Список записей<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" OrderBy="DateTimePriem" TableName="ViewTalonsWithVrachAndOrg" Where="status == @status &amp;&amp; DateTimePriem &gt;= @DateTimePriem &amp;&amp; IDOrg == @IDOrg &amp;&amp; DateTimePriem &lt;= @DateTimePriem1">
            <WhereParameters>
                <asp:Parameter DefaultValue="0" Name="status" Type="Int16" />
                <asp:Parameter Name="DateTimePriem" Type="DateTime" />
                <asp:Parameter Name="IDOrg" Type="Int32" />
                <asp:Parameter Name="DateTimePriem1" Type="DateTime" />
            </WhereParameters>
        </asp:LinqDataSource>
    


</asp:Content>

