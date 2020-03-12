<%@ Page Title="Домашняя страница" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="site2013._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
       
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

   <%-- <div class="ads-line">Внимание КОНКУРС "Образ будущего страны" <a href="Ads/ONFKonkurs.aspx">  узнать подробнее..</a></div>--%>


    <br />
      <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center"  CssClass="AdOnStart">
        <br />
       <h3> Внимание! Наша поликлиника переходит на использование единого программного обеспечения бюджетных медицинских организаций <span class="auto-style1">ЕГИСЗ РО</span>. В связи с этим возможно медленное обслуживание в регистратурах поликлиники, во время переходного периода и обучения персонала. Также при обращении в поликлинику необходимо <span class="auto-style1"><strong>иметь при себе действующие полис медицинского страхования, паспорт и СНИЛС</strong></span>. Приносим извинения за причинённые неудобства. </h3>
      <p><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Docs/DVBT2.aspx" Visible="False">Подробнее..</asp:HyperLink></p>
        

    </asp:Panel>
    <br />
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center"  CssClass="AdOnStart">
        <br />
       <h3 style="box-sizing: border-box; font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-weight: 500; line-height: 1.1; margin-top: 20px; margin-bottom: 10px; font-size: 24px; color: rgb(51, 51, 51); font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;"> <a id="MainContent_HyperLink3" href="Ads/perepis.aspx" style="box-sizing: border-box; color: rgb(42, 100, 150); text-decoration: underline; outline: 0px;">Таганрог готовится к переписи населения 2020 года: регистраторы начнут работу уже в августе 2019 года</a></h3>
        

        <p>
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Ads/perepis.aspx" Target="_blank">Подробнее...</asp:HyperLink>
        </p>
        

    </asp:Panel>
    <div class="mainInfo">
    <h4>Единый Call-центр записи на прием</h4>
     <address style="text-align:center">
      <abbr title="Телефон"></abbr>
    <a href="tel:+7-863-461-9300" class="btn btn-default">8 (8634) 619-300</a></address>
    <h4>Важно для вашего здоровья</h4>
    <ul style="list-style-type:none;">
          <li>                <a href="Docs/gripp.aspx" style="color:#FF372C">Иммунизация против гриппа</a></li>
        <li><a href="../info/gripp2019.aspx">ЧТОБЫ НЕ ЗАБОЛЕТЬ ГРИППОМ…</a></li>
          <li>     <a href="../info/vac.aspx">            Вакцинопрофилактика</a></li>
     <li>                <a href="../DD/">Диспансеризация</a></li>
<%--<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.uztag.ru/000000.html">График работы передвижной флюорографической установки</asp:HyperLink></li>--%>
       
     <li><asp:Label runat="server" Text="!!! " ID="LabelNew" Style="font-size: large; font-weight: bold;" ForeColor="Red"></asp:Label>
                            <a href="../info/Narkomania.aspx">Наркомания</a></li>
                        <li>
                            <a href="../info/TabacVl.aspx">Вред курения</a>
                        </li><li><a href="../Docs/Insult.aspx">Профилактика Инсульта</a></li>
    <li><a href="https://vk.com/@gp2_taganrog-vsemirnyi-den-serdca">Берегите свое сердце</a></li>
    <li><a href="https://vk.com/@gp2_taganrog-stenokardiya">Стенокардия</a></li> 
     <%--   <li><a href="https://vk.com/@gp2_taganrog-20-oktyabrya-vsemirnyi-dnem-borby-s-osteoporozom">Остеопороз</a></li>--%>
     
                        <li><a href="../info/tub.aspx">Туберкулез</a></li>
                        <li><a href="../Docs/VICH.aspx">Профилактика ВИЧ, СПИД</a></li>
                        <li><a href="../info/depress.aspx">Депрессия</a></li>
    <li><asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" NavigateUrl="https://aataganrog.ru/">Группа Анонимные Алкоголики</asp:HyperLink></li>
                        
                        <li><a href="../Docs/KGL.aspx">Крымская геморрагическая лихорадка</a></li>
                        <li><a href="../Docs/ПАМЯТКА_по_МАЛЯРИИ.pdf">Опасность малярии</a></li>
        <li><a href="Docs/GenOne.aspx">Проект "Старшее поколение"</a></li>
        </ul>
       

       </div> 



      <div class="sidebar">
                <div class="sidebar-inner">

                    <h4>Информация!</h4>
                    <ul>
                     <%--   <li><asp:Label runat="server" Text="!!! " ID="LabelNew" Style="font-size: large; font-weight: bold;" ForeColor="Red"></asp:Label>
                            <a href="../Docs/pdf/2017/ПАМЯТКАГрипп2017ГП2.pdf">ГРИПП Памятка ГП2</a>
                        </li>--%>
                       
                        <li>
                            <a href="../Docs/pdf/2017/Бесплатно или платно.pdf">Платно или бесплатно?</a>
                        </li>
                        <li>
                            <a href="../Docs/pdf/2019/Сроки%20ожидания.pdf">Сроки ожидания</a>
                        </li>
                         <li><a href="../Docs/pdf/2019/памятка семьям с детьми.pdf" target="_blank">Меры соц поддержки семьям с детьми</a></li>
                         <li><a href="../info/InsComp.aspx">Страховые компании</a></li>
                        <li><a href="../Docs/pdf/2017/ГРИПП2017.pdf">ГРИПП Памятка</a></li>
                                               
                            <li><asp:Label runat="server" Text="!!! " ID="Label1" Style="font-size: large; font-weight: bold;" ForeColor="Red"></asp:Label>
                            <a href="../Uslugi/Mamogr.aspx">Маммография 2019</a>
                        </li>
                         <li>  <a href="../Docs/2017/CalendVac.aspx">Календарь прививок</a></li>
                       
                        <li>
                            <asp:HyperLink ID="HyperLink1"
                                runat="server" NavigateUrl="~/Docs/AnalysUro.aspx">Правила сдачи анализов</asp:HyperLink></li>
                        <li><a href="../Docs/boln.aspx">Листок нетрудоспособности (больничный лист)</a></li>
                        <li><a href="../Docs/MedPomosh.aspx">О доступности медицинской помощи</a></li>
                        <li><a href="http://pravo.gov.ru/proxy/ips/?docbody=&nd=102104881" target="_blank">Медико-социальная экспертиза</a></li>
                        <li><a href="../Docs/Default.aspx#ua">Гражданам Украины..</a></li>
                        <li><a href="../info/lawyers.aspx">Бесплатная Юридическая Помощь</a></li>
                        <li><a href="http://www.genproc.gov.ru/anticor/" _target="blank">Противодействие коррупции</a></li>
                        <li><a href="https://vk.com/gp2_taganrog">Мы ВКонтакте</a></li>

                    </ul>
                </div>







                <div class="sidebar-inner">
                    <h4>Анкетирование!</h4>
                    <ul>
                        <li><a href="https://docs.google.com/forms/d/1KyVmtSrvIK-xGh0VvuE5VhNs6-ZghBLkjvrM_21m7S8/viewform?usp=send_form" target="_blank">Оцените работу регистратуры</a></li>
                        <li>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="https://anketa.rosminzdrav.ru/staticogvjustank/61/1" Target="_blank" ToolTip="АНКЕТА для оценки качества условий оказания услуг медицинскими организациями в амбулаторных условиях">Анкета оценки качества</asp:HyperLink>
                        </li>
                         <li><a target="_blank" ToolTip="Итоговая оценка качества условий оказания услуг по медицинским организациям г. Таганрога в 2018 году, а также список учреждений здравоохранения, независимая оценка деятельности которых производится в 2019 году" href="https://bus.gov.ru/pub/top-organizations-second">Итоговая оценка качестваусловий оказания услуг</a></li>
                    </ul>
                </div>
                <div class="sidebar-inner">
                    <h4>Наши услуги</h4>
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink4" NavigateUrl="~/Uslugi/XRay.aspx" runat="server">Рентген кабинет</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/DD" runat="server">ДИСПАНСЕРИЗАЦИЯ</asp:HyperLink></li>

                    </ul>
                </div>
                <!-- всякое-->
           <%--     <p></p>
                <iframe src="https://nok.rosminzdrav.ru/MO/GetBanner/6224/1" border="0" scrolling="no" allowtransparency="true" width="100%" height="110" style="border: 0;"></iframe>
                <asp:HyperLink runat="server" NavigateUrl="https://www.rosminzdrav.ru/polls/9-anketa-dlya-otsenki-kachestva-okazaniya-uslug-meditsinskimi-organizatsiyami-v-ambulatornyh-usloviyah?region_code=ROS" Target="_blank" ImageUrl="~/img/anketa_banner.png" ImageWidth="100%" ToolTip="Оценка качества оказания услуг МО">Оценка качества оказания услуг МО</asp:HyperLink>--%>
                <p></p>
                <asp:HyperLink runat="server" ImageUrl="~/img/TFOMS.png" NavigateUrl="http://rostov-tfoms.ru/goryachaya-liniya" Target="_blank" ToolTip="Горячая линия по вопросам ОМС и оказания медицинских услуг">Горячая линия по вопросам ОМС и оказанию медицинских услуг</asp:HyperLink>
                (по вопросам ОМС и оказания медицинских услуг)
                <br />
                <br />
                <asp:HyperLink runat="server" ImageUrl="http://www.takzdorovo.ru/files/bd/8c1/02895f7ede3d4d49d97a9c0aaa8/200x200_TAKZDOROVO.gif" NavigateUrl="http://takzdorovo.ru" Target="_blank" ToolTip="ПОРТАЛ О ЗДОРОВОМ ОБРАЗЕ ЖИЗНИ">ПОРТАЛ О ЗДОРОВОМ ОБРАЗЕ ЖИЗНИ</asp:HyperLink>
                <br />
                </div>
            <!-- end sidebar -->
    <!-- news-->
                    <div class="news">
                    <h4>Последние новости</h4>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" DataSourceID="MasterNewsLinqDataSource1" PageSize="3"
                        ShowHeader="False" CssClass="news-item-side" BorderStyle="None" BorderWidth="0px">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <b>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("date").ToShortDateString().Replace(vbCrLf, "<br />") %>'
                                            CssClass="date"></asp:Label></b>

                                    <b>
                                        <asp:HyperLink ID="Label2" runat="server" Text='<%# Eval("Title").Replace(vbCrLf, "<br />") %>'
                                            NavigateUrl="~/News/Default.aspx"></asp:HyperLink></b><br />

                                    <asp:Label ID="Label3" runat="server" Text='<%# textNews(Eval("Text"))%>'></asp:Label>



                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="MasterNewsLinqDataSource1" runat="server"
                        ContextTypeName="site2013.ContactsDataContext" EntityTypeName=""
                        OrderBy="date desc" TableName="NewsTable"
                        Where="del == @del">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="False" Name="del" Type="Boolean" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/News/Default.aspx">Все новости...</asp:HyperLink>
                </div>
    <br />
    <div>
    <iframe src="https://nok.rosminzdrav.ru/MO/GetBanner/6224/1" border="0" scrolling="no" allowtransparency="true" width="300" height="110" style="border: 0;"></iframe>
        </div>
      <!-- баннеры -->
    <div class="banner">
        
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="https://ya-roditel.ru" Target="_blank"><asp:Image ID="Image1" runat="server" CssClass="bannerFamily" /></asp:HyperLink>

    </div>
</asp:Content>
