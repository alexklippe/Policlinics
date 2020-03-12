<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="Talons.aspx.vb" Inherits="Appointment.Talons1" %>

<%@ Register Src="~/a/TalonItem.ascx" TagPrefix="uc1" TagName="TalonItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

    <h1>Талоны</h1>
    
     <asp:LinqDataSource ID="LinqDataSourceFilials" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" OrderBy="filialName" TableName="OrgFilials" Where="idOrganization == @idOrganization">
        <WhereParameters>
            <asp:ControlParameter ControlID="OrgId" Name="idOrganization" PropertyName="Value" Type="Int32" />
            
        </WhereParameters>
        </asp:LinqDataSource>
        <asp:HiddenField ID="OrgId" runat="server" /><asp:HiddenField runat="server" ID="NumOfWeek"></asp:HiddenField>
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
    год
      <asp:DropDownList ID="DropDownListYear" runat="server">
          <asp:ListItem>2015</asp:ListItem>
          <asp:ListItem>2016</asp:ListItem>
          <asp:ListItem>2017</asp:ListItem>
          <asp:ListItem>2018</asp:ListItem>
          <asp:ListItem>2019</asp:ListItem>
          <asp:ListItem>2020</asp:ListItem>
          <asp:ListItem>2021</asp:ListItem>
          <asp:ListItem>2022</asp:ListItem>
          <asp:ListItem>2023</asp:ListItem>
          <asp:ListItem>2024</asp:ListItem>
          <asp:ListItem>2025</asp:ListItem>
      </asp:DropDownList>
месяц
      <asp:DropDownList ID="DropDownListMonth" runat="server">
          <asp:ListItem Value="1">Январь</asp:ListItem>
          <asp:ListItem Value="2">Февраль</asp:ListItem>
          <asp:ListItem Value="3">Март</asp:ListItem>
          <asp:ListItem Value="4">Апрель</asp:ListItem>
          <asp:ListItem Value="5">Май</asp:ListItem>
          <asp:ListItem Value="6">Июнь</asp:ListItem>
          <asp:ListItem Value="7">Июль</asp:ListItem>
          <asp:ListItem Value="8">Август</asp:ListItem>
          <asp:ListItem Value="9">Сентябрь</asp:ListItem>
          <asp:ListItem Value="10">Октябрь</asp:ListItem>
          <asp:ListItem Value="11">Ноябрь</asp:ListItem>
          <asp:ListItem Value="12">Декабрь</asp:ListItem>
      </asp:DropDownList>
        Расписание для: <asp:Label ID="LabelId" runat="server" Text="0"></asp:Label> <asp:Label ID="LabelFIO" runat="server" Text="" Font-Size="Medium" Font-Bold="True"></asp:Label>
      <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="idVrach" HeaderText="idVrach" ReadOnly="True" SortExpression="idVrach" />
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
    <table class="auto-style1" >
        <tr>
            <td>Понедельник</td>
            <td>Вторник</td>
            <td>Среда</td>
            <td>Четверг</td>
            <td>Пятница</td>
            <td>Суббота</td>
            <td>Воскресенье</td>
        </tr>
      
        
        <tr>
            <asp:Panel ID="Panel1" runat="server">
            <td><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder></td>
            <td><asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder></td>
            <td><asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder></td>
            <td><asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder></td>
            <td><asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder></td>
            <td><asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder></td>
            <td><asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder></td>
                </asp:Panel>
        </tr>
            
    </table>
    <asp:Button ID="Button1" runat="server" Text="Сохранить и перейти к следующей неделе" OnClientClick="document.getElementById('<%# Eval(Button1.ClientID) %>').value='Подождите...';document.getElementById('<%# Eval(Button1.ClientID) %>').disabled = true;" />
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
