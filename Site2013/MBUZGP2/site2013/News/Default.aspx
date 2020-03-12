<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="site2013._Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelUser" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="LinqDataSource1" PageSize="20" 
        ShowHeader="False" CssClass="news-item" >
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
              <b><asp:Label ID="Label1" runat="server" Text='<%# Eval("date").ToShortDateString().Replace(vbcrlf,"<br />") %>'
                           CssClass="date"></asp:Label></b>

                            <b> <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title").Replace(vbcrlf,"<br />") %>'
                            CssClass="news-item"></asp:Label></b><br /><br />

                             &nbsp&nbsp<asp:Label ID="Label3" runat="server" Text='<%# textNews(Eval("Text"))%>'  CssClass="news-item"
                            ></asp:Label>
            <br /><br />

       
        
        </ItemTemplate>
        </asp:TemplateField>

        </Columns>
    </asp:GridView>
        </asp:Panel>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="site2013.ContactsDataContext" EntityTypeName="" 
        OrderBy="date desc" TableName="NewsTable" 
        Where="del == @del">
        <WhereParameters>
            <asp:Parameter DefaultValue="False" Name="del" Type="Boolean" />
        </WhereParameters>
    </asp:LinqDataSource>

</asp:Content>
