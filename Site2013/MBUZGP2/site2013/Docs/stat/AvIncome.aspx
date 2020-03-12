<%@ Page Title="Среднемесячный доход" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AvIncome.aspx.vb" Inherits="site2013.AvIncome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #59ABFD;
            background-color: #f5f5f5;
            padding:2px;
            

        }
        .Auto-2{
            text-align:center;
            padding:2px;
        }
        .auto-style2 {
            width: 363px;
            padding:2px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h2 style="text-align: center">Информация о среднемесячной заработной плате  </h2>
    <h3 style="text-align: center">главного врача, главного бухгалтера,
заместителей главного врача и главного бухгалтера </h3>
    <h4 style="text-align: center;font-weight:bold ">МБУЗ "Городская поликлиника №2" 01-05.2019 год (нарастающим итогом с начала года)</h4>
    <hr />
        <table align="left" cellspacing="0" cellpadding="5" class="auto-style1 ">
            <tr align="center">
                <td class="auto-style2">Наименование должности</td>
                <td class="Auto-2">Средняя заработная плата 
(руб.)</td>
                <td class="Auto-2">Максимальная кратность к средней заработной плате 1-го работника</td>
                <td class="Auto-2">Фактическая кратность к средней заработной плате 1-го работника</td>
            </tr>
            <tr>
                <td class="auto-style2">Главный врач</td>
                <td class="Auto-2">51177.39</td>
                <td class="Auto-2">4,0</td>
                <td class="Auto-2">2,12</td>
            </tr>
            <tr>
                <td class="auto-style2">Заместитель главного врача по медицинской части</td>
                <td class="Auto-2">32561,08</td>
                <td class="Auto-2">3,5</td>
                <td class="Auto-2">1,35</td>
            </tr>
            <tr>
                <td class="auto-style2">Заместитель главного врача по организационно-методической работе</td>
                <td class="Auto-2">21153,19</td>
                <td class="Auto-2">3,5</td>
                <td class="Auto-2">0,87</td>
            </tr>
            <tr>
                <td class="auto-style2">Заместитель главного врача по экспертизе временной нетрудоспособности</td>
                <td class="Auto-2">40958,00</td>
                <td class="Auto-2">3,5</td>
                <td class="Auto-2">1,69</td>
            </tr>
            <tr>
                <td class="auto-style2">Главный бухгалтер</td>
                <td class="Auto-2">41320,83</td>
                <td class="Auto-2">3,5</td>
                <td class="Auto-2">1,71</td>
            </tr>
            <tr>
                <td class="auto-style2">Заместитель главного врача по экономическим вопросам</td>
                <td class="Auto-2">40598,44</td>
                <td class="Auto-2">3,5</td>
                <td class="Auto-2">1,68</td>
            </tr>
            <tr>
                <td class="auto-style2">Заместитель главного врача по хозяйственным вопросам </td>
                <td class="Auto-2">36957,35</td>
                <td class="Auto-2">3,5</td>
                <td class="Auto-2">1,53</td>
            </tr>
        </table>



</asp:Content>
