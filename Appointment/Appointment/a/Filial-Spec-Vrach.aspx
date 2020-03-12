<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="Filial-Spec-Vrach.aspx.vb" Inherits="Appointment.Filial_Spec_Vrach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Список Врачей по специальностям в филиале</h1>
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
    <br />
    <br />
    Врачи, которые отображаются по выбранной специальности:<br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
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


       <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="Vrach" Where="IdOrg == @IdOrg" OrderBy="Surname, Name, MidName" Select="new (id, Surname, Name, MidName, BirthDay, IdOrg)">
          <WhereParameters>
              <asp:ControlParameter ControlID="OrgId" Name="IdOrg" PropertyName="Value" Type="Int32" />
          </WhereParameters>
      </asp:LinqDataSource>
      <br />
    Врачи, которых можно добавить к выбранной специальности:<br />
      <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource2" PageSize="100">
          <Columns>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
              <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" ReadOnly="True" />
              <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
              <asp:BoundField DataField="MidName" HeaderText="MidName" ReadOnly="True" SortExpression="MidName" />
              <asp:BoundField DataField="BirthDay" HeaderText="BirthDay" ReadOnly="True" SortExpression="BirthDay" />
              <asp:BoundField DataField="IdOrg" HeaderText="IdOrg" ReadOnly="True" SortExpression="IdOrg" />
          </Columns>
      </asp:GridView>

</asp:Content>
