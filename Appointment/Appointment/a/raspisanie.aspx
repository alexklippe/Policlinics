<%@ Page Title="Расписание" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="raspisanie.aspx.vb" Inherits="Appointment.Filial_Spec_Vrach_ADD" %>
<%@ Register src="CAlendarItem.ascx" tagname="CAlendarItem" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" Visible="False">
  
        
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
     

 
      <table class="tableizer-table">
          <tr class="tableizer-firstrow">
              <td>Пон</td>
              <td>Вт</td>
              <td>Ср</td>
              <td>Чт</td>
              <td>Пт</td>
              <td rowspan="8"> </td>
              <td class="sundays ">Сб</td>
              <td>Вс</td>
              <td>&nbsp;</td>
          </tr>
          <tr>
              <td>
               
                  <uc1:CAlendarItem ID="CAlendarItem1" runat="server" />
               
              </td>
              <td><uc1:CAlendarItem ID="CAlendarItem2" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem3" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem4" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem5" runat="server" /></td>
              
              <td><uc1:CAlendarItem ID="CAlendarItem6" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem7" runat="server" /></td>
              <td>
                  <asp:Button ID="Button3" runat="server" Text="Заполнить вниз" ToolTip="Заполнить поля ниже в соответствии с этой неделей" />
              </td>
          </tr>
          <tr>
              <td><uc1:CAlendarItem ID="CAlendarItem8" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem9" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem10" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem11" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem12" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem13" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem14" runat="server" /></td>
              <td>
                  <asp:Button ID="Button4" runat="server" Text="Заполнить вниз" ToolTip="Заполнить поля ниже в соответствии с этой неделей" />
              </td>
          </tr>
          <tr>
              <td><uc1:CAlendarItem ID="CAlendarItem15" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem16" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem17" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem18" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem19" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem20" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem21" runat="server" /></td>
              <td>
                  <asp:Button ID="Button5" runat="server" Text="Заполнить вниз" ToolTip="Заполнить поля ниже в соответствии с этой неделей" />
              </td>
          </tr>
          <tr>
              <td><uc1:CAlendarItem ID="CAlendarItem22" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem23" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem24" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem25" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem26" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem27" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem28" runat="server" /></td>
              <td>
                  <asp:Button ID="Button6" runat="server" Text="Заполнить вниз" ToolTip="Заполнить поля ниже в соответствии с этой неделей" />
              </td>
          </tr>
          <tr>
              <td><uc1:CAlendarItem ID="CAlendarItem29" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem30" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem31" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem32" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem33" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem34" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem35" runat="server" /></td>
              <td>
                  <asp:Button ID="Button7" runat="server" Text="Заполнить вниз" ToolTip="Заполнить поля ниже в соответствии с этой неделей" />
              </td>
          </tr>
          
          <tr>
              <td><uc1:CAlendarItem ID="CAlendarItem36" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem37" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem38" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem39" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem40" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem41" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem42" runat="server" /></td>
              <td>
                  <asp:Button ID="Button8" runat="server" Text="Заполнить вниз" ToolTip="Заполнить поля ниже в соответствии с этой неделей" />
              </td>
          </tr>
           <tr>
              <td><uc1:CAlendarItem ID="CAlendarItem43" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem44" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem45" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem46" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem47" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem48" runat="server" /></td>
              <td><uc1:CAlendarItem ID="CAlendarItem49" runat="server" /></td>
              <td>&nbsp;</td>
          </tr>
      </table>

       <br />
     
        </asp:PlaceHolder>
    <asp:Button ID="Button2" runat="server" Text="Сохранить" />
  
&nbsp;
      <asp:Label ID="Label2" runat="server"></asp:Label>
  
</asp:Content>
