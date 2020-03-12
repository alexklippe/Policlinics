<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="VrachCategory.aspx.vb" Inherits="Appointment.VrachCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Справочник категории врачей</h1>
      <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableInsert="True" EnableUpdate="True" EntityTypeName="" OrderBy="CategoryName" TableName="CategoriiVracha"></asp:LinqDataSource>
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
        </Columns>
    </asp:GridView>


    <asp:Panel ID="Panel1" runat="server">
        <h4>Добавить новую категорию</h4>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Appointment.mainDataContext" EnableInsert="True" EntityTypeName="" TableName="CategoriiVracha">
</asp:LinqDataSource>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="LinqDataSource2" DefaultMode="Insert" Height="50px" Width="125px">
    <Fields>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
        <asp:CommandField ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>
    </asp:Panel>
</asp:Content>
