<%@ Page Title="Управление учетной записью" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="sp1Taganrog_2.Manage" %>

<%@ Import Namespace="sp1Taganrog_2" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Изменение параметров учетной записи</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Пароль:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Изменить]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Создать]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>Внешние имена входа:</dt>
                    <dd><%:LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Управление]" runat="server" />

                    </dd>
                    <%--
                        Номера телефонов можно использовать в качестве второго проверочного фактора для системы двухфакторной проверки подлинности.
                        В <a href="http://go.microsoft.com/fwlink/?LinkId=403804">этой статье</a>
                        вы можете узнать, как для этого приложения ASP.NET настроить двухфакторную проверку подлинности с использованием SMS.
                        Настроив двухфакторную проверку подлинности, раскомментируйте следующие блоки.
                    --%>
                    <%--
                    <dt>Номер телефона:</dt>
                     --%>
                    <% If HasPhoneNumber Then %>
                    <%--
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Добавить]" />
                    </dd>
                    --%>
                    <% Else %>
                    <%--
                    <dd>
                    
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Изменить]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Удалить]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    --%>
                    <% End If %>
                    <dt>Двухфакторная проверка подлинности:</dt>
                    <dd>
                        <p>
                            Поставщики двухфакторной проверки подлинности не настроены. В <a href="http://go.microsoft.com/fwlink/?LinkId=403804">этой статье</a>
                            вы можете узнать, как для этого приложения ASP.NET настроить двухфакторную проверку подлинности.
                        </p>                        
                        <% If TwoFactorEnabled Then %>
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Отключить]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% Else %>
                       	<%--
                       	отключенный
                        <asp:LinkButton Text="[Включить]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% End If %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>

