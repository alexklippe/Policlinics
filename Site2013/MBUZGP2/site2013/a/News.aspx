<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/admin.Master" CodeBehind="News.aspx.vb" Inherits="site2013.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="LinqDataSource1" Height="50px" Width="100%">
        <Fields>
            
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            
  <asp:TemplateField HeaderText="Дата" SortExpression="date" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"  Text='<%# Bind("date")%>' EnableTheming="true"  ></asp:TextBox> 
                </EditItemTemplate>
                <InsertItemTemplate>
                   
                    <asp:TextBox ID="TextBox3" runat="server"  Text='<%# Bind("date")%>' EnableTheming="true"  ></asp:TextBox> 
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server"  Text='<%# Bind("date")%>' ></asp:Label> 
                </ItemTemplate>

            </asp:TemplateField>


            <asp:TemplateField HeaderText="Заголовок" SortExpression="Title" ControlStyle-Width="99%">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Wrap="true" Text='<%# Bind("Title")%>'  TextMode="MultiLine" Rows="2"></asp:TextBox> 
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Wrap="true" Text='<%# Bind("Title")%>'  TextMode="MultiLine" Rows="2" ></asp:TextBox> 
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"  Text='<%# Bind("Title")%>' ></asp:Label> 
                </ItemTemplate>

            </asp:TemplateField>



            
            <asp:TemplateField HeaderText="Текст" SortExpression="Text" ControlStyle-Width="99%">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Wrap="true" Text='<%# Bind("Text") %>'  TextMode="MultiLine" Rows="10" EnableViewState ="true"></asp:TextBox> 
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Wrap="true" Text='<%# Bind("Text")%>'  TextMode="MultiLine" Rows="10" EnableViewState="true"></asp:TextBox> 
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"  Text='<%# Bind("Text") %>' ></asp:Label> 
                </ItemTemplate>

            </asp:TemplateField>

           
            
            
            <%--<asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />--%>
            <asp:CheckBoxField DataField="del" HeaderText="Удалено" SortExpression="del" ReadOnly="false"  />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"  />
        </Fields>
    </asp:DetailsView>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"   AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" Width="100%" EnableSortingAndPagingCallbacks="True" EnablePersistedSelection="True">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Title" HeaderText="Заголовок" SortExpression="Title" ControlStyle-Width="99%" />
            <asp:BoundField DataField="Text" HeaderText="Текст" SortExpression="Text" ControlStyle-Width="99%"/>
            <asp:BoundField DataField="date" HeaderText="Дата" SortExpression="date" />
            <asp:CheckBoxField DataField="del" HeaderText="Удалено" SortExpression="del" />
            <asp:BoundField DataField="UserCreate" HeaderText="Пользователь" SortExpression="UserDoIt" />
            
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Сохранить" />
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="site2013.ContactsDataContext"
         EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="NewsTable" OrderBy="date desc"
        >
    </asp:LinqDataSource>
</asp:Content>
