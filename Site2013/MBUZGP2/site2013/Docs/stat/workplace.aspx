<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="workplace.aspx.vb" Inherits="site2013.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    .auto-style2 {
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Сводная ведомость результатов проведения специальной оценки условий труда</h3>
    <hr />

    <table class="auto-style1">
        <tr>
            <td rowspan="3" class="auto-style2">Наименование</td>
            <td colspan="2" rowspan="2" class="auto-style2">Количество рабочих мест и численность работников, занятых на этих рабочих местах</td>
            <td colspan="7" class="auto-style2">Количество рабочих мест и численность занятых на них работников по классам (подклассам) условий труда из числа рабочих мест, указанных в графе 3 (единиц)</td>
        </tr>
        <tr>
            <td class="auto-style2" rowspan="2">класс 1</td>
            <td class="auto-style2" rowspan="2">класс 2</td>
            <td class="auto-style2" colspan="4">класс 3</td>
            <td class="auto-style2" rowspan="2">класс 4</td>
        </tr>
        <tr>
            <td class="auto-style2">всего</td>
            <td class="auto-style2">в том числе на которых проведена специальная оценка условий труда</td>
            <td class="auto-style2">3.1</td>
            <td class="auto-style2">3.2</td>
            <td class="auto-style2">3.3</td>
            <td class="auto-style2">3.4</td>
        </tr>
        <tr>
            <td class="auto-style2">1</td>
            <td class="auto-style2">2</td>
            <td class="auto-style2">3</td>
            <td class="auto-style2">4</td>
            <td class="auto-style2">5</td>
            <td class="auto-style2">6</td>
            <td class="auto-style2">7</td>
            <td class="auto-style2">8</td>
            <td class="auto-style2">9</td>
            <td class="auto-style2">10</td>
        </tr>
        <tr>
            <td>Рабочие места (ед.)</td>
            <td class="auto-style2">454</td>
            <td class="auto-style2">454</td>
            <td class="auto-style2">6</td>
            <td class="auto-style2">171</td>
            <td class="auto-style2">88</td>
            <td class="auto-style2">182</td>
            <td class="auto-style2">7</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
        </tr>
        <tr>
            <td>Работники, занятые на рабочих местах (чел.)</td>
            <td class="auto-style2">528</td>
            <td class="auto-style2">528</td>
            <td class="auto-style2">18</td>
            <td class="auto-style2">170</td>
            <td class="auto-style2">106</td>
            <td class="auto-style2">227</td>
            <td class="auto-style2">7</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
        </tr>
        <tr>
            <td>из них женщин</td>
            <td class="auto-style2">459</td>
            <td class="auto-style2">459</td>
            <td class="auto-style2">13</td>
            <td class="auto-style2">141</td>
            <td class="auto-style2">101</td>
            <td class="auto-style2">198</td>
            <td class="auto-style2">6</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
        </tr>
        <tr>
            <td>из них лиц в возрасте до 18 лет</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
        </tr>
        <tr>
            <td>из них инвалидов</td>
            <td class="auto-style2">49</td>
            <td class="auto-style2">49</td>
            <td class="auto-style2">5</td>
            <td class="auto-style2">16</td>
            <td class="auto-style2">10</td>
            <td class="auto-style2">17</td>
            <td class="auto-style2">1</td>
            <td class="auto-style2">0</td>
            <td class="auto-style2">0</td>
        </tr>
    </table>

&nbsp;&nbsp;&nbsp; 

    <br />
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Docs/pdf/2019/условия труда сводная ведомость.pdf" Target="_blank">Сводная ведомость результатов проведения специальной оценки условий труда</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Docs/pdf/2019/Условия труда Перечень мероприятий.pdf" Target="_blank">Перечень рекомендуемых мероприятий по улучшению условий труда</asp:HyperLink>
    <br />

</asp:Content>
