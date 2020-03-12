<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="OrgEdit.aspx.vb" Inherits="Appointment.OrgEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:HiddenField runat="server" ID="OrgID"></asp:HiddenField>
    <h1>Редактирование организации</h1>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Organization" Where="id == @id">
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgID" Name="id" PropertyName="Value" Type="Int32" />
        </WhereParameters>
       
    </asp:LinqDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="LinqDataSource1" Height="50px" Width="756px" >
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="OrgShortName" HeaderText="Сокращенное название организации" SortExpression="OrgShortName" />
            <asp:BoundField DataField="OrgFullName" HeaderText="Полное название организации" SortExpression="OrgFullName" />
            <asp:BoundField DataField="OrgINN" HeaderText="ИНН" SortExpression="OrgINN" />
            <asp:BoundField DataField="OrgOGRN" HeaderText="ОГРН" SortExpression="OrgOGRN" />
            <asp:BoundField DataField="OrgAddress" HeaderText="Адрес организации" SortExpression="OrgAddress" />
            <asp:BoundField DataField="OrgHelpTel" HeaderText="Телефон(ы) для обращения граждан" SortExpression="OrgHelpTel" />
            <asp:BoundField DataField="OrgDomainName" HeaderText="Доменное имя" SortExpression="OrgDomainName" />
            <asp:BoundField DataField="OrgTestDomainName" HeaderText="Тестовое доменное имя" SortExpression="OrgTestDomainName" />
            <asp:BoundField DataField="SMTPServer" HeaderText="SMTP сервер" SortExpression="SMTPServer" />
            <asp:BoundField DataField="SMTPPort" HeaderText="SMTP порт" SortExpression="SMTPPort" />
            <asp:BoundField DataField="SMTPLogin" HeaderText="SMTP Логин" SortExpression="SMTPLogin" />
            <asp:BoundField DataField="SMTPPass" HeaderText="SMTP Пароль" SortExpression="SMTPPass" />
            <asp:BoundField DataField="SMTPMailFrom" HeaderText="SMTP адрес от кого будут отправляться письма" SortExpression="SMTPMailFrom" />
            <asp:BoundField DataField="SMTPMailToDefault" HeaderText="SMTP адрес, куда будут поступать  заявки" SortExpression="SMTPMailToDefault" />
            <asp:CheckBoxField DataField="SMTPSSL" HeaderText="SMTP использует SSL?" SortExpression="SMTPSSL" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
