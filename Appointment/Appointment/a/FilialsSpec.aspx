<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="FilialsSpec.aspx.vb" Inherits="Appointment.FilialsSpec" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Специальности, доступные в филиале</h1>
    <asp:LinqDataSource ID="LinqDataSourceFilials" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" OrderBy="filialName" TableName="OrgFilials" Where="idOrganization == @idOrganization">
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgId" Name="idOrganization" PropertyName="Value" Type="Int32" />
        </WhereParameters>
        </asp:LinqDataSource>
        <asp:HiddenField ID="OrgId" runat="server" />
    Выберите филиал: 
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="LinqDataSourceFilials" DataTextField="filialName" DataValueField="id">
        </asp:DropDownList>
    

        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Spec_Filial_ID" Where="IDFilial == @IDFilial">
            <WhereParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="IDFilial" PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="False" />
                <asp:BoundField DataField="IDFilial" HeaderText="IDFilial" SortExpression="IDFilial" Visible="False" />
                <asp:TemplateField HeaderText="IDSpec" SortExpression="IDSpec">
                    <EditItemTemplate>
                        
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IDSpec") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                          <asp:DropDownList ID="DropDownList2" runat="server" SelectedValue='<%# Bind("IDSpec")%>' DataSourceID="LinqDataSource2" DataTextField="SpecialnostName" DataValueField="id">
        </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("IDSpec") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IDOrg" HeaderText="IDOrg" SortExpression="IDOrg" Visible="False" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" OrderBy="SpecialnostName" TableName="Specialnost" Where="IdOrg == @IdOrg">
            <WhereParameters>
                <asp:ControlParameter ControlID="OrgId" Name="IdOrg" PropertyName="Value" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
      
      <asp:Panel ID="Panel1" runat="server">
        <h4>Добавить специальность в филиал</h4>

          <asp:Label ID="Label3" runat="server" Text="Label">Филиал:</asp:Label><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
          <br /> <asp:Label ID="Label5" runat="server" Text="Label">Выберите специальность:</asp:Label>
             <asp:DropDownList ID="DropDownList4" runat="server"  DataSourceID="LinqDataSource2" DataTextField="SpecialnostName" DataValueField="id">
        </asp:DropDownList><br />

          <asp:Button ID="Button1" runat="server" Text="Добавить" />
          
       
    </asp:Panel>
   
</asp:Content>
