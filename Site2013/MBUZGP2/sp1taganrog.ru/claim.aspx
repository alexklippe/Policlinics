<%@ Page Title="Обратная связь" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="claim.aspx.vb" Inherits="sp1taganrog.ru.claim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Обратная связь</h1>  
    <div class="row">
    <asp:Panel ID="PanelMainForm" runat="server">
        
        <br />
        <br />
        <table style="max-width:800px; min-width:400px;">
            <tr>
                <td>Тема обращения:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="dropdown-header">
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
                    <asp:TextBox ID="TextBoxFIO"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxFIO" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Адрес:</td>
                <td>
                    <asp:TextBox ID="TextBoxAddress" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Контактный телефон:</td>
                <td>
                    <asp:TextBox ID="TextBoxTelephone" runat="server" ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>e-mail:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Ошибка" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="label-warning"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">Тект обращения (3000 символов):</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxText" runat="server" TextMode="MultiLine" CssClass="claimMainTextBox" Height="500px" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxText" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Добавить файл (не более 5Мб):<br /> (&quot;.pdf&quot;, &quot;.doc&quot;, &quot;.docx&quot;, &quot;.jpg&quot;, &quot;.png&quot;, &quot;.zip&quot;)</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="319px" CssClass="btn-default" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    Обращаем Ваше внимание, что отправляя обращение, Вы соглашаетесь с обработкой своих персональных данных, согласно ФЗ № 152-ФЗ «О персональных данных».</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LabelError" runat="server" CssClass="label-warning" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Отправить" CssClass="btn" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
      
    </asp:Panel>
    <asp:Panel ID="PanelResult" runat="server" Visible="False">
        <br /><br />
         <asp:Label ID="LabelErrorPanel" runat="server" CssClass="label-success" ></asp:Label>
        <br /><br />

    </asp:Panel>
        </div>
</asp:Content>
