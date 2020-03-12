<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="WorkTimeWebRegByFilial.aspx.vb" Inherits="Appointment.WorkTimeWebRegByFilial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField ID="OrgId" runat="server" />

    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSourceFilials" DataTextField="filialName" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
    
    <asp:LinqDataSource ID="LinqDataSourceFilials" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="OrgFilials" Where="idOrganization == @idOrganization" Select="new (id, filialName)">
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgId" Name="idOrganization" PropertyName="Value" Type="Int32" />
        </WhereParameters>
     </asp:LinqDataSource>


     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSourceWorkTime">
         <Columns>
             <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
             <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
             <asp:BoundField DataField="idFilial" HeaderText="idFilial" SortExpression="idFilial" Visible="false"  />
             <asp:TemplateField HeaderText="DayOfWeek" SortExpression="DayOfWeek">
                 <EditItemTemplate>
                     <asp:DropDownList ID="DropDownList2" runat="server"  SelectedValue='<%# Bind("DayOfWeek") %>'><asp:ListItem Value="0">Воскресенье</asp:ListItem>
                         <asp:ListItem Value="1">Понедельник</asp:ListItem>
                         <asp:ListItem Value="2">Вторник</asp:ListItem>
                         <asp:ListItem Value="3">Среда</asp:ListItem>
                         <asp:ListItem Value="4">Четверг</asp:ListItem>
                         <asp:ListItem Value="5">Пятница</asp:ListItem>
                         <asp:ListItem Value="6">Суббота</asp:ListItem>
                     </asp:DropDownList>
                   
                 </EditItemTemplate>
                 <ItemTemplate>
                      <asp:DropDownList ID="DropDownList3" runat="server"  SelectedValue='<%# Bind("DayOfWeek") %>' Enabled="false" ><asp:ListItem Value="0">Воскресенье</asp:ListItem>
                         <asp:ListItem Value="1">Понедельник</asp:ListItem>
                         <asp:ListItem Value="2">Вторник</asp:ListItem>
                         <asp:ListItem Value="3">Среда</asp:ListItem>
                         <asp:ListItem Value="4">Четверг</asp:ListItem>
                         <asp:ListItem Value="5">Пятница</asp:ListItem>
                         <asp:ListItem Value="6">Суббота</asp:ListItem>
                     </asp:DropDownList>
               
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="EndWorkTime" HeaderText="EndWorkTime" SortExpression="EndWorkTime" />
             <asp:CheckBoxField DataField="IsWorkDay" HeaderText="IsWorkDay" SortExpression="IsWorkDay" />
         </Columns>
     </asp:GridView>
     <asp:LinqDataSource ID="LinqDataSourceWorkTime" runat="server" ContextTypeName="Appointment.mainDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="WorkTimeEndZapisi" Where="idFilial == @idFilial">
         <WhereParameters>
             <asp:ControlParameter ControlID="DropDownList1" Name="idFilial" PropertyName="SelectedValue" Type="Int32" />
         </WhereParameters>
     </asp:LinqDataSource>


     <br />
     Добавить:<br />
     <asp:Label ID="Label1" runat="server" Text="День недели: "></asp:Label>
      <asp:DropDownList ID="DropDownList3" runat="server"   ><asp:ListItem Value="0">Воскресенье</asp:ListItem>
                         <asp:ListItem Value="1">Понедельник</asp:ListItem>
                         <asp:ListItem Value="2">Вторник</asp:ListItem>
                         <asp:ListItem Value="3">Среда</asp:ListItem>
                         <asp:ListItem Value="4">Четверг</asp:ListItem>
                         <asp:ListItem Value="5">Пятница</asp:ListItem>
                         <asp:ListItem Value="6">Суббота</asp:ListItem>
                     </asp:DropDownList>
     <br />
    <asp:Label ID="Label2" runat="server" Text="Рабочий день заканчивается в: "></asp:Label>
    <asp:TextBox ID="TextBoxTime" runat="server"></asp:TextBox><br />

    <asp:Label ID="Label3" runat="server" Text="Выходной?: "></asp:Label><asp:CheckBox ID="CheckBoxWeekend" runat="server" /><br />
    <asp:Button ID="Button1" runat="server" Text="Добавить" />
     <br />


</asp:Content>
