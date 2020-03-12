<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="SpecEdit.aspx.vb" Inherits="Appointment.SpecEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Справочник специальностей</h1>

    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableInsert="True" EnableUpdate="True" EntityTypeName="" OrderBy="SpecialnostName" TableName="Specialnost" Where="IdOrg == @IdOrg">
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgId" Name="IdOrg" PropertyName="Value" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
    
    <asp:HiddenField ID="OrgId" runat="server" />
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="SpecialnostName" HeaderText="SpecialnostName" SortExpression="SpecialnostName" />
            <asp:BoundField DataField="SpecialnostDescr" HeaderText="SpecialnostDescr" SortExpression="SpecialnostDescr" />
            <asp:BoundField DataField="SpecFilID" HeaderText="SpecFilID" SortExpression="SpecFilID" Visible="False" />
            <asp:BoundField DataField="IntervalPriemaByDefault" HeaderText="IntervalPriemaByDefault" SortExpression="IntervalPriemaByDefault" />
        </Columns>
    </asp:GridView>


    <asp:Panel ID="Panel1" runat="server">
        <h4>Добавить новую специальность</h4>
            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Appointment.mainDataContext" EnableInsert="True" EntityTypeName="" TableName="Specialnost">
                  <InsertParameters>

             <asp:ControlParameter ControlID="OrgId" Name="IdOrg" PropertyName="Value" Type="Int32" />
           

        </InsertParameters>
</asp:LinqDataSource>

<asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="LinqDataSource2" DefaultMode="Insert" Height="50px" Width="125px">
    <Fields>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="SpecialnostName" HeaderText="SpecialnostName" SortExpression="SpecialnostName" />
        <asp:BoundField DataField="SpecialnostDescr" HeaderText="SpecialnostDescr" SortExpression="SpecialnostDescr" />
        <asp:BoundField DataField="SpecFilID" HeaderText="SpecFilID" SortExpression="SpecFilID" />
        <asp:BoundField DataField="IntervalPriemaByDefault" HeaderText="IntervalPriemaByDefault" SortExpression="IntervalPriemaByDefault" />
        <asp:BoundField DataField="IdOrg" HeaderText="IdOrg" ReadOnly="True" SortExpression="IdOrg" Visible="False" />
        <asp:CommandField ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>
    </asp:Panel>
</asp:Content>
