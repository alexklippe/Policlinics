<%@ Page Title="::Контакты" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="Contacts.aspx.vb" Inherits="site2013.Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>График приема руководителей МБУЗ «ГП №2»</h2>
    <hr />
     <br />
    <table cellspacing="0" style="width:100%;border-collapse:collapse">

        <tbody>
            <tr>
                <td><strong>Главный врач</strong><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Юрий Борисович Иванов</td><td>пятница с 14.00-17.00</td>
            </tr>
             <tr>
                <td><strong>Зам. главного врача по медицинской части</strong><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Елена Владимировна Кусинова</td><td>среда с 14.00-17.00</td>
            </tr>
                         <tr>
                <td><strong>Зам. главного врача по ОМР</strong><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;Инга Валерьевна Визир</td><td>четверг с 14.00-17.00</td>
            </tr>
        </tbody>
    </table>
   
<br />
    <hr />
    <h2>&nbsp;</h2>
<h2>Телефоны:</h2>

    <asp:Panel ID="PanelUser" runat="server">
        <!-- Название филиала -->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1"
            DataKeyNames="id" ShowHeader="False" OnRowDataBound="OnRowDataBound" GridLines="None" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="TableHead"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Name").Replace(vbcrlf,"<br />") %>'
                             CssClass="TableHeadText"></asp:Label></b></div>
                        <!-- Таблица по филиалу-->
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                            ShowHeader="False" Width="99%">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="70%">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("cabinetName").Replace(vbcrlf,"<br />") %>'
                                            CssClass="tableItemCellHead"></asp:Label></b>
                                            <asp:Label ID="Label3" runat="server" Text='<%# doFIO(Eval("id"))%>'
                                            CssClass="tableItemCellText" ></asp:Label></b>
                                            
                                     
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="30%" DataField="cabinetTel" HeaderText="cabinetTel" />
                            </Columns>
                        </asp:GridView>
                         <br /><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="site2013.ContactsDataContext"
            EntityTypeName="" OrderBy="porjadokSortirovki" Select="new (id, name)" TableName="filials">
        </asp:LinqDataSource>
        
         <asp:LinqDataSource ID="LinqDataSource3" runat="server" 
            ContextTypeName="site2013.ContactsDataContext" EntityTypeName="" 
            Select="new (Surname, Name, MidName, Cabinet)" TableName="Sotrudnikis" 
            Where="Cabinet == @Cabinet">
            <WhereParameters>
                <asp:Parameter DefaultValue="10" Name="Cabinet" Type="Object" />
            </WhereParameters>
        </asp:LinqDataSource>

        <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="site2013.ContactsDataContext"
            EntityTypeName="" OrderBy="id" Select="new (id, cabinetName, cabinetTel, Sotrudnikis, NotShow)"
            TableName="Cabinets" Where="IDFilial == @IDFilial &amp;&amp; NotShow != @NotShow">
            <WhereParameters>
                <asp:Parameter DefaultValue="1" Name="IDFilial" Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="NotShow" Type="Boolean" />
            </WhereParameters>
        </asp:LinqDataSource>
    </asp:Panel>
    <asp:Panel ID="PanelAdmin" runat="server">
        
    <br />
        <hr />
        <h2>Электронная почта</h2>
        <br />
        <a href="mailto:tagmuz@tgp2.ru">tagmuz@tgp2.ru</a> 
    </asp:Panel>
</asp:Content>
