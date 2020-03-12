<%@ Page Title="Главная" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="sp1taganrog.ru._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ДОБРО ПОЖАЛОВАТЬ!</h1>
        <p class="lead">
            Мы рады приветствовать Вас на официальном сайте

Муниципального бюджетного учреждения здравоохранения «Стоматологическая поликлиника №1» города Таганрога
        </p>




        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>
    <div class="row" style="display: flex; justify-content: center">

        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" BackColor="#FFFFCC" BorderColor="#CC0000" BorderStyle="Dashed" BorderWidth="2px" Style="max-width: 1024px; padding: 5px;">
            <h3>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Ads/perepis19.aspx">Таганрог готовится к переписи населения 2020 года: регистраторы начнут работу уже в августе 2019 года</asp:HyperLink></h3>
            <p>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Ads/perepis19.aspx" class="btn btn-default">Подробнее..</asp:HyperLink></p>

        </asp:Panel>

    </div>
    <br />
    <div class="row" style="display: flex; justify-content: center;">
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" BackColor="#FFFFCC" BorderColor="#CC0000" BorderStyle="Dashed" BorderWidth="2px" Style="max-width: 1024px; padding: 5px;">
            <h3>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Docs/files/2019/Инфоргафика МБУЗ сп1.pdf">Порядок маршрутизации в Стоматологической поликлинике №1</asp:HyperLink></h3>
            <p>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Docs/files/2019/Инфоргафика МБУЗ сп1.pdf" class="btn btn-default">Подробнее..</asp:HyperLink></p>

        </asp:Panel>
    </div>
    <%--  <div class="row">
         <div class="myjumbotron">КОНКУРС «Образ будущего страны» <a class="btn btn-default" href="~/ads/onfkonkurs" runat="server">Узнать больше &raquo;</a></div>
    </div>--%>
    <div class="row">

        <div class="col-md-3 myjumbotron">
            <h2>Время работы поликлиники</h2>
            <p>
                Пн: 7.30-19.30<br />
                Вн: 7.30-19.30<br />
                Ср: 7.30-19.30<br />
                Чт: 7.30-19.30<br />
                Пт: 7.30-16.00<br />
                Сб: 7.30-16.00<br />
                Вс: Выходной
            </p>
            <hr />
            <p>
                Выдача талонов: 7:00-15:00
            </p>
            <p>
                <asp:HyperLink runat="server" class="btn btn-default" href="WorkTime.aspx">подробнее &raquo;</asp:HyperLink>
            </p>
        </div>
        <div class="col-md-4 myjumbotron2">
            <h2>Условия и порядок оказания стоматологической помощи</h2>
            <p>
                Общие условия предоставления медицинской помощи. Порядок предоставления населению бесплатной амбулаторной медицинской помощи. Условия оказания медицинской помощи больным, не имеющим экстренных показаний (плановая помощь).
            </p>
            <p>
                <a class="btn btn-default" href="~/Docs/Usloviya" runat="server">Узнать больше &raquo;</a>
            </p>
        </div>

        <div class="col-md-3  myjumbotron">
            <h2>Расписание работы врачей и онлайн запись на прием</h2>

            <p>

                <a class="btn btn-default" href="~/Vazhno/Booking.aspx" runat="server">Перейти &raquo;</a>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 myjumbotron2">
            <h2>Наши услуги</h2>
            <p>
                С полным переченем оказываемых услуг можно ознакомиться здесь..
            </p>
            <p>
                <a runat="server" href="~/Uslugi/VidUslug" class="btn btn-default">Узнать больше &raquo;</a>
            </p>


        </div>
        <div class="col-md-4 myjumbotron2">
            <h2>Анкетирование!</h2>


            <p>
                <asp:HyperLink runat="server" class="btn btn-default" Target="_blank" NavigateUrl="https://docs.google.com/forms/d/1xIXxOuDeuVtcH-puGODbPyNbp64HKCkJCq6GpWuOrfE/viewform">Оцените работу регистратуры &raquo;</asp:HyperLink>
            </p>
            <p>
                <asp:HyperLink runat="server" class="btn btn-default" Target="_blank" NavigateUrl="http://anketa.rosminzdrav.ru/staticogvjustank/61/1">Оцените качество оказания услуг &raquo;</asp:HyperLink>
                <asp:HyperLink runat="server" class="btn btn-default" Target="_blank" NavigateUrl="~/Docs/files/ankets/Результат опроса СП1.pdf">Результат &raquo;</asp:HyperLink>
                <asp:HyperLink runat="server" class="" Target="_blank" NavigateUrl="https://bus.gov.ru/pub/top-organizations-second" ToolTip="Итоговая оценка качества условий оказания услуг по медицинским организациям г. Таганрога в 2018 году, а также список учреждений здравоохранения, независимая оценка деятельности которых производится в 2019 году">Итоговая оценка качества условий оказания услуг &raquo;</asp:HyperLink>
            </p>
        </div>
        <div class="col-md-3 myjumbotron2">
            <h3>План мероприятий по улучшению качества оказания медицинских услуг</h3>


            <p>
                <asp:HyperLink runat="server" class="btn btn-default" Target="_blank" NavigateUrl="~/Docs/PlanService">Оцените работу регистратуры &raquo;</asp:HyperLink>
            </p>

        </div>
    </div>
    <!-- третья строка -->
    <div class="row">
        <div class="col-md-3 myjumbotron2">
            <h2>Для граждан украины!</h2>



            <p>
                <asp:HyperLink runat="server" class="" Target="_blank" NavigateUrl="http://www.rostov-tfoms.ru/migranty/dokumenty-neobkhodimye-dlya-polucheniya-polisa-oms-dlya-grazhdan-ukrainy-peresekayushchikh-granitsu-rf">Получение полиса ОМС для граждан Украины &raquo;</asp:HyperLink>
            </p>

        </div>

        <div class="col-md-4 myjumbotron">
            <h2>Это важно!</h2>
            <p>
                <asp:HyperLink runat="server" class="" NavigateUrl="~/Vazhno/COVID-19.aspx">Коронавирус &raquo;</asp:HyperLink><br />
                <asp:HyperLink runat="server" class="" NavigateUrl="~/Vazhno/GRIPP.aspx">ГРИПП &raquo;</asp:HyperLink><br />
                <asp:HyperLink runat="server" class="" NavigateUrl="~/Vazhno/Vakcine.aspx">Вакцинация &raquo;</asp:HyperLink>
            </p>
            <hr />
            <p>
                <asp:HyperLink runat="server" class="" NavigateUrl="~/Vazhno/d/hiv">1 декабря - всемирный день борьбы со СПИД/ВИЧ &raquo;</asp:HyperLink></p>
            <p>
                <asp:HyperLink runat="server" class="" NavigateUrl="~/Vazhno/d/dia">14 ноября - Всемирный день борьбы с диабетом &raquo;</asp:HyperLink></p>
        </div>

        <div class="col-md-3 myjumbotron2">
            <h2>Горячая линия по вопросам ОМС</h2>

            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://rostov-tfoms.ru/goryachaya-liniya" Target="_blank" ImageUrl="~/img/TFOMS.png">
                </asp:HyperLink>
                <%--  <asp:HyperLink runat="server" class="btn btn-default" ImageUrl="~/img/TFOMS.png" Target="_blank" NavigateUrl="http://rostov-tfoms.ru/goryachaya-liniya" Height="70%" Width="15%">подробнее &raquo;</asp:HyperLink>--%>
            </p>
        </div>

    </div>
    <!-- баннеры -->
    <div class="banner">
        
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="https://ya-roditel.ru" Target="_blank"><asp:Image ID="Image1" runat="server" /></asp:HyperLink>

    </div>
    <!-- четвертая строка -->
    <div class="row">
        <div class="col-md-3 myjumbotron2">
            <h2>Уведомление</h2>
            <p>
                Срок уплаты налогов физических лиц в 2019 году - 02 декабря 2019 года
            </p>
            <p>
                <a runat="server" href="https://www.nalog.ru/rn77/news/activities_fts/7604611/" class="btn btn-default" target="_blank">Узнать больше &raquo;</a>
            </p>

        </div>

        <div class="col-md-4 myjumbotron">
            <h2></h2>
            <iframe src="https://nok.rosminzdrav.ru/MO/GetBanner/6225/1" border="0" scrolling="no" allowtransparency="true" width="300" height="110" style="border: 0;"></iframe>
        </div>

        <div class="col-md-3 myjumbotron2">
            <h2>Противодействие коррупции</h2>

            <p>
                <a runat="server" href="http://www.genproc.gov.ru/anticor/" class="btn btn-default" target="_blank">Узнать больше &raquo;</a>

                <%--    <asp:HyperLink runat="server" class="btn btn-default" ImageUrl="http://rostov-tfoms.ru/images/all/hotline.png" Target="_blank" NavigateUrl="http://rostov-tfoms.ru/goryachaya-liniya">подробнее &raquo;</asp:HyperLink>
                --%>
            </p>
        </div>

    </div>





</asp:Content>
