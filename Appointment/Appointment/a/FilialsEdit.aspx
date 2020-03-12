<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="FilialsEdit.aspx.vb" Inherits="Appointment.FilialsEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="OrgFilials" Where="idOrganization == @idOrganization">
        <WhereParameters>
            <asp:ControlParameter ControlID="HiddenField2" Name="idOrganization" PropertyName="Value" Type="Int32" />
        </WhereParameters>

        <InsertParameters>

             <asp:ControlParameter ControlID="HiddenField2" Name="idOrganization" PropertyName="Value" Type="Int32" />
           

        </InsertParameters>

    </asp:LinqDataSource>
    
     <asp:LinqDataSource runat="server" ID="LinqSourceOrgs" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="Organization" Where="id == @id">
         <WhereParameters>
             <asp:ControlParameter ControlID="HiddenField2" Name="id" PropertyName="Value" Type="Int32" />
         </WhereParameters>
       
    </asp:LinqDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="id" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="FilialNumber" HeaderText="FilialNumber" SortExpression="FilialNumber" />
            <asp:BoundField DataField="filialName" HeaderText="filialName" SortExpression="filialName" />
            <asp:BoundField DataField="filialHelpTel" HeaderText="filialHelpTel" SortExpression="filialHelpTel" />
            <asp:BoundField DataField="filialAddress" HeaderText="filialAddress" SortExpression="filialAddress" />
            <asp:BoundField DataField="filialDescription" HeaderText="filialDescription" SortExpression="filialDescription" />
           <%-- <asp:BoundField DataField="idOrganization" HeaderText="idOrganization" SortExpression="idOrganization" InsertVisible="True" ReadOnly="True" />--%>
            <asp:BoundField DataField="filialEmail" HeaderText="filialEmail" SortExpression="filialEmail" />
            <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
       
        
    </asp:DetailsView>

    <asp:Button ID="Button1" runat="server" Text="Button" />
    <br />

</asp:Content>
