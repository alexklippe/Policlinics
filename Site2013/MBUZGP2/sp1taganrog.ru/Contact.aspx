<%@ Page Title="Контакты" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="sp1taganrog.ru.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Стоматологическая поликлиника №1</p>
    <h3>Адрес:</h3>
    <address>
        
        ул. Дзержинского, 177<br />
        Таганрог, РО 347924<br />
      
    </address>
    
    <h3>Телефоны:</h3>
    <address>
      <abbr title="Телефон">Регистратура:</abbr><br />
    <a href="tel:+7-863-467-9554" class="btn btn-default">8 (8634) 67-95-54</a></address><address>
      <abbr title="Телефон">Главный врач (приемная):</abbr><br />
    <a href="tel:+7-863-467-4581" class="btn btn-default">8 (8634) 67-45-81</a></address><address>
       <abbr title="Телефон">Зам. главного врача по медицинской части:</abbr><br />
    <a href="tel:+7-863-467-0182" class="btn btn-default">8 (8634) 67-01-82</a> </address><address>
    <abbr title="Телефон">Бухгалтерия:</abbr><br />
    <a href="tel:+7-863-467-0182" class="btn btn-default">8 (8634) 67-01-82</a> </address>
      <h3>Обращения граждан:</h3>  
    <address>
        
                <asp:HyperLink runat="server" class="btn btn-primary btn-lg" href="claim">Форма обращений &raquo;</asp:HyperLink>
        <asp:HyperLink runat="server" class="btn btn-primary btn-lg" href="mailto:stomat73@mail.ru">Электронная почта stomat73@mail.ru</asp:HyperLink>
            <br />
       <%-- <strong>Marketing:</strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
    </address>
    <hr />
    <h3>Министерство здравоохранения Ростовской области</h3>
     <address>
        
        ул. 1-ой Конной Армии, 33, г.Ростов-на-Дону<br />
          <abbr title="Телефон">Т:</abbr>
    <a href="tel:+7-863-242-3096" class="btn btn-default">8 (863) 242-30-96</a>
      
    </address>
     <h3>Управление здравоохранения г. Таганрога</h3>
     <address>
        
         ул. Петровская, 74./ пер. Лермонтовский, 5, г. Таганрог, РО 347900<br />
          <abbr title="Телефон">Т:</abbr>
    <a href="tel:+7-863-431-2833" class="btn btn-default">8 (8634) 31-28-33</a>
      
    </address>
         <h3>ТФ №4 ТФОМС Ростовской области</h3>
     <address>
        
         пер. Красный, 11, г. Таганрог, РО 347900<br />
          <abbr title="Телефон">Т:</abbr>
    <a href="tel:+7-863-438-3579" class="btn btn-default">8 (8634) 38-35-79</a>
      
    </address>
             <h3>Территориальный отдел территориального управления Роспотребнадзора по РО в г.Таганроге, Неклиновском, Матвеево-Курганском, Куйбышевском районах</h3>
     <address>
        
         Большой пр., 16 а, г. Таганрог, РО 347930<br />
          <abbr title="Телефон">Т:</abbr>
    <a href="tel:+7-863-464-2425" class="btn btn-default">8 (8634) 64-24-25</a>
      
    </address>

     <h3>Территориальный орган Росздравнадзора по РО</h3>
     <address>
        
          ул. Ченцова, 71/63 "б",  г. Ростов-на-Дону 344037 <br />
          <abbr title="Телефон">Т:</abbr>
    <a href="tel:+7-863-286-9806" class="btn btn-default">8 (863) 286-98-06</a>
      
    </address>

</asp:Content>
