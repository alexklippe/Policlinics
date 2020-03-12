<%@ Page Title="Платые услуги" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="platnye.aspx.vb" Inherits="site2013.platnye" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</style>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Прейскурант</h1>

   <%-- <h4 class="auto-style1">Раздел находится в разработке, приносим извинения за причиненные неудобства</h4>--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Visible="true" 
        DataKeyNames="id" DataSourceID="LinqDataSource1" ShowHeader="False" OnRowDataBound="OnRowDataBound" GridLines="None" Width="100%" >
        <Columns>
        <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="Name" >
            <ItemTemplate>
                <div class="TableHead">
                  <asp:Label ID="Label7" runat="server" Text='<%# Eval("Name").Replace(vbcrlf,"<br />") %>'  CssClass="TableHeadText"  ></asp:Label></b>
                  </div>
                       
                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  ShowHeader="true" Width="100%" HeaderStyle-BackColor ="blue"> 
                          
                       <Columns>
                           <asp:BoundField ItemStyle-Width="10%" DataField="Code" HeaderText="Код" />
                             <asp:BoundField ItemStyle-Width="60%" DataField="Name" HeaderText="Наименование" />
                            <asp:BoundField ItemStyle-Width="15%" DataField="Money" HeaderText="Цена" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                           <asp:BoundField ItemStyle-Width="15%" DataField="PriceLgota" HeaderText="Цена для льготных категорий(*)" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />

                            </Columns>
                     
                      </asp:GridView>  <br />
            </ItemTemplate>
        
        
        
        </asp:TemplateField>
           
        </Columns>
         <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFFFFF" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
    </asp:GridView>




    <br />
    <strong>*Перечень</strong> категорий граждан, имеющих право на льготу при оплате за платные медицинские услуги, оказываемые муниципальным бюджетным учреждением здравоохранения «Городская поликлиника №2»:<br />
    
    <table>
        <tr align="center">
            <th>Наименование льготной категории граждан</th>
            <th>Документы, являющиеся основанием для оказания медицинской услуги на льготной основе</th>
        </tr>
        <tr>
            <td>Ветераны ВОВ, инвалиды ВОВ и лица, приравненные к ним категории граждан</td>
            <td>Удостоверение ветерана ВОВ, инвалида ВОВ, справка органов Управления социальной защиты населения г.Таганрога</td>
        </tr>
        <tr>
            <td>Труженики тыла</td>
            <td>Удостоверение, справка органов Управления социальной защиты населения г.Таганрога</td>
        </tr>
        <tr>
            <td>Участники боевых действий и лица, приравненные к ним категории граждан</td>
            <td>Удостоверение участника боевых действий справка органов Управления социальной защиты населения г.Таганрога</td>
        </tr>
        <tr>
            <td>Инвалиды I и II группы общего заболевания</td>
            <td>Справка МСЭК</td>
        </tr>
        <tr>
            <td class="auto-style2">Лица, подвергшиеся воздействию радиации вследствие катастрофы на ЧАЭС, а также вследствие ядерных испытаний на Семипалатинском полигоне, и приравненные к ним категории граждан</td>
            <td class="auto-style2">Удостоверение, справка органов Управления социальной защиты населения г.Таганрога </td>
        </tr>
        <tr>
            <td>Ветераны труда</td>
            <td>Удостоверение ветерана труда</td>
        </tr>
        <tr>
            <td>Пенсионеры</td>
            <td>Пенсионное удостоверение</td>
        </tr>
        <tr>
            <td>Беременные женщины</td>
            <td>Справка из медицинского учреждения</td>
        </tr>
        <tr>
            <td>Организованное прохождение проф.осмотров бюджетными учреждениями здравоохранения, бюджетными учреждениями образования и коммерческими предприятиями (от 10 человек)</td>
            <td>Договор с юридическими лицами на проведения проф.осмотра</td>
        </tr>
        <tr>
            <td>Дети от 0 до 18 лет</td>
            <td>Договор с юридическими лицами</td>
        </tr>
</table>
    <br />
    <br />
   <!-- Прейскурант и перечень платных услуг утвержден приказом №189 от 07 мая 2015г<br />
    <a href="../Docs/uslugi/Приказ%20189%20Платные.pdf" target="_blank">Приказ 189 Платные</a><br /> -->
    <a href="../Docs/uslugi/Приказы.zip" target="_blank">Приказы и приложения</a><br />

 <a href="docs/Приказ по ПД на 01.01.18.pdf" target="_blank">Приказ о назначении персонала, оказывающего платные услуги и контроле оказания платных услуг</a><br />
<%--       <a href="../Docs/uslugi/Приложение%203%20Перечень%20льгот.pdf" target="_blank">Приложение 3 Перечень льгот</a><br />
    <a href="../Docs/uslugi/Приложение%204%20Прейскурант%20льгота2018.pdf" target="_blank">Приложение 4 Прейскурант льгота</a><br />--%>
    <br />
    <br />




    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="site2013.UslugiDataContext" EntityTypeName="" OrderBy="Name" 
        TableName="PlatnyeUslugiGroups" Where=" deleted == @del">
        <WhereParameters>
              <asp:Parameter DefaultValue="False" Name="del" Type="Boolean" />
          </WhereParameters>
    </asp:LinqDataSource>

      <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
        ContextTypeName="site2013.UslugiDataContext" EntityTypeName="" OrderBy="Name" 
                              TableName="PlatnyeUslugiItems" Where="idGroup == @idGroup &amp;&amp; del == @del" 
        >
          <WhereParameters>
              <asp:Parameter DefaultValue="1942" Name="idGroup" Type="Int32" />
              <asp:Parameter DefaultValue="False" Name="del" Type="Boolean" />
          </WhereParameters>
        
                    </asp:LinqDataSource>

</asp:Content>
