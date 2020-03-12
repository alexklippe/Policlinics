<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/a/SiteAdmin.Master" CodeBehind="Vrach.aspx.vb" Inherits="Appointment.Vrach1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Справочник врачей<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EnableInsert="True" EnableUpdate="True" EntityTypeName="" OrderBy="Surname, Name, MidName" TableName="Vrach" Where="IdOrg == @IdOrg">
    <WhereParameters>
        <asp:ControlParameter ControlID="IdOrg" Name="IdOrg" PropertyName="Value" Type="Int32" />
    </WhereParameters>
        </asp:LinqDataSource>
    <asp:HiddenField ID="IdOrg" runat="server" />
    </h1>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="LinqDataSource1" PageSize="100" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" >
            <ItemStyle BackColor="#FFFF99" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
            <ItemStyle BackColor="#FFFFCC" />
            </asp:BoundField>
            <asp:BoundField DataField="MidName" HeaderText="MidName" SortExpression="MidName" />
            <asp:BoundField DataField="TabelNumber" HeaderText="TabelNumber" SortExpression="TabelNumber" />
            <asp:TemplateField HeaderText="ProfObrazovanieID" SortExpression="ProfObrazovanieID">
                <EditItemTemplate>
                   
                    <asp:DropDownList ID="DropDownList3" runat="server" SelectedValue='<%# Bind("ProfObrazovanieID") %>' DataSourceID="LinqDataSource3" DataTextField="Obrazovanie" DataValueField="id">
    </asp:DropDownList>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProfObrazovanieID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                     
                    <asp:Label ID="Label1" runat="server" Text='<%# obr(Eval("ProfObrazovanieID"))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Certification" HeaderText="Certification" SortExpression="Certification" />
            <asp:TemplateField HeaderText="CategoryVrachaID" SortExpression="CategoryVrachaID">
                <EditItemTemplate>
                      <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("CategoryVrachaID") %>' DataSourceID="LinqDataSource2" DataTextField="CategoryName" DataValueField="id">
    </asp:DropDownList>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CategoryVrachaID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                   
                    <asp:Label ID="Label2" runat="server" Text='<%# cat(Eval("CategoryVrachaID"))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="Fired" HeaderText="Fired" SortExpression="Fired" />
            <asp:BoundField DataField="BirthDay" HeaderText="BirthDay" SortExpression="BirthDay" />
            <asp:BoundField DataField="ObrUchr" HeaderText="ObrUchr" SortExpression="ObrUchr" />
            <asp:BoundField DataField="PovyshKvalif" HeaderText="PovyshKvalif" SortExpression="PovyshKvalif" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
     
    <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="ObrazovanieVracha">
    </asp:LinqDataSource>
    
   

    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="CategoriiVracha">
    </asp:LinqDataSource>
    
   

    <asp:Panel ID="Panel1" runat="server">
        <h2>Добавить нового врача</h2>
        Фамилия:<asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox><br />
        Имя:<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox><br />
        Отчество:<asp:TextBox ID="TextBoxMidname" runat="server"></asp:TextBox><br />
        Табельный номер:<asp:TextBox ID="TextBoxTabNum" runat="server"></asp:TextBox><br />
        Дата рождения:<asp:TextBox ID="TextBoxDateBirth" runat="server"></asp:TextBox><br />
        Образование:<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="LinqDataSource3" DataTextField="Obrazovanie" DataValueField="id"></asp:DropDownList><br />
        Учебное заведение:<asp:TextBox ID="TextBoxVUZ" runat="server"></asp:TextBox><br />
        Сертификат:<asp:TextBox ID="TextBoxCert" runat="server" Height="64px" TextMode="MultiLine" Width="224px"></asp:TextBox><br />
        Категория:<asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="LinqDataSource2" DataTextField="CategoryName" DataValueField="id"></asp:DropDownList><br />
        Повышение квалификации:<asp:TextBox ID="TextBoxPovKvalif" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Добавить" />
    </asp:Panel>
    
   

</asp:Content>
