<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="RaspisanieStatic.aspx.vb" Inherits="Appointment.RaspisanieStatic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <h1><%: Title %></h1>
     <asp:LinqDataSource ID="LinqDataSourceFilials" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" OrderBy="filialName" TableName="OrgFilials" Where="idOrganization == @idOrganization">
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgId" Name="idOrganization" PropertyName="Value" Type="Int32" />
        </WhereParameters>
        </asp:LinqDataSource>
        <asp:HiddenField ID="OrgId" runat="server" />
    Выберите филиал: 
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="LinqDataSourceFilials" DataTextField="filialName" DataValueField="id">
        </asp:DropDownList>

    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="LinqDataSourceSpec" DataTextField="SpecialnostName" DataValueField="id" AutoPostBack="True">
    </asp:DropDownList>

    <asp:LinqDataSource ID="LinqDataSourceSpec" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="SpecNamesWithSpecIds" Where="IDFilial == @IDFilial">
        <WhereParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="IDFilial" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>  
            <asp:HiddenField runat="server" ID="BufferStatus" />
            <asp:HiddenField runat="server" ID="BufferInterval" />
            <asp:HiddenField runat="server" ID="BufferStartHour" />
            <asp:HiddenField runat="server" ID="BufferEndtHour" />
            <asp:HiddenField runat="server" ID="BufferStartMinute" />
            <asp:HiddenField runat="server" ID="BufferEndMinute" />
            


    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
             <asp:BoundField DataField="idVrach" HeaderText="idVrach" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:TemplateField HeaderText="IDVrach" SortExpression="IDVrach">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IDVrach") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# VrachView(Eval("IDVrach")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IDSpec" HeaderText="IDSpec" SortExpression="IDSpec" Visible="False" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableDelete="True" EntityTypeName="" TableName="Vrach_Spec_ID" Where="IDSpec == @IDSpec">
        <WhereParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="IDSpec" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>

    Расписание для: <asp:Label ID="LabelId" runat="server" Text="0"></asp:Label> <asp:Label ID="LabelVrachId" runat="server" Text="0"></asp:Label> <asp:Label ID="LabelFIO" runat="server" Text="" Font-Size="Medium" Font-Bold="True"></asp:Label>
      <br />
       
    
      <asp:Button ID="Button1" runat="server" Text="Показать" />
      <br />
      <br />


     <asp:PlaceHolder ID="PlaceHolder1" runat="server">  

         </asp:PlaceHolder>
</asp:Content>
