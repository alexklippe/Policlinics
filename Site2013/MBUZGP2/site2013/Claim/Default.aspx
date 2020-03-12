<%@ Page Title="Обратная связь" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="site2013._Default5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelMainForm" runat="server">
        <h1>Обратная связь</h1>
        <br />
        <br />
        <table  class=".clear" id="claimTable">
            <tr>
                <td>Тема обращения:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="309px">
                        <asp:ListItem>Жалоба</asp:ListItem>
                        <asp:ListItem>Предложение</asp:ListItem>
                        <asp:ListItem>Благодарность</asp:ListItem>
                        <asp:ListItem>Прочее</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Фамилия Имя Отчество:</td>
                <td>
                    <asp:TextBox ID="TextBoxFIO" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxFIO" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Адрес:</td>
                <td>
                    <asp:TextBox ID="TextBoxAddress" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Контактный телефон:</td>
                <td>
                    <asp:TextBox ID="TextBoxTelephone" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>e-mail:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Ошибка" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Подразделение поликлиники:</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="LinqDataSourceFilials" DataTextField="name" DataValueField="id" Width="309px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">Тект обращения (3000 символов):</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxText" runat="server" Height="500px" TextMode="MultiLine" Width="589px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxText" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Добавить файл (не более 5Мб):<br /> (&quot;.pdf&quot;, &quot;.doc&quot;, &quot;.docx&quot;, &quot;.jpg&quot;, &quot;.png&quot;, &quot;.zip&quot;)</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="319px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    Обращаем Ваше внимание, что отправляя сообщение, Вы соглашаетесь с обработкой своих персональных данных, согласно ФЗ № 152-ФЗ от 27.07.2006 «О персональных данных».</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Отправить" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
        <asp:LinqDataSource ID="LinqDataSourceFilials" runat="server" ContextTypeName="site2013.ContactsDataContext" EntityTypeName="" OrderBy="porjadokSortirovki" Select="new (name, id)" TableName="filials">
                    </asp:LinqDataSource>
    </asp:Panel>
</asp:Content>
