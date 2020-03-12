<%@ Page Title="Ссылки на государственные и региональные порталы" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="links.aspx.vb" Inherits="sp1taganrog.ru.links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1><hr />
     <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="http://www.rostov-tfoms.ru/" Target="_blank"  class="btn btn-default" >Территориальный фонд обязательного медицинского страхования (ТФОМС) Ростовской области</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="http://minzdrav.donland.ru/" Target="_blank" class="btn btn-default" >Министерство здравоохранения Ростовской области</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink4" runat="server" 
        NavigateUrl="http://www.rosminzdrav.ru/" Target="_blank" class="btn btn-default" >Министерство здравоохранения РФ</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink5" runat="server" 
        NavigateUrl="http://government.ru/department/23/" Target="_blank" class="btn btn-default" >Правительство России</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink6" runat="server" 
        NavigateUrl="http://www.uztag.ru/" Target="_blank" class="btn btn-default" >Управление здравоохранения г. Таганрога</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink7" runat="server" 
        NavigateUrl="http://tagancity.ru/" Target="_blank" class="btn btn-default" >портал города Таганрога</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="http://www.rusregioninform.ru/yuzhnyy-federalnyy-okrug/rostovskaya-oblast/" Target="_blank" class="btn btn-default" >Главный интернет портал Регионов России</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink9" runat="server" 
        NavigateUrl="http://www.medkrug.ru/" Target="_blank" class="btn btn-default" >сайт для пацинетов</asp:HyperLink>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink10" runat="server"  class="btn btn-default" 
        NavigateUrl="http://www.rostov-tfoms.ru/konsultant-predstaviteli/graph" 
        Target="_blank">График работы консультант-представителей ТФОМС Ростовской области</asp:HyperLink>
    <br />
</asp:Content>
