<%@ Page Title="Проверка статуса записи на прием" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="prov.aspx.vb" Inherits="Appointment.prov" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="registrationform ">
      
        <h4>Проверка статуса записи на прием.</h4>

        <p>Введите код записи в следующее поле и нажмите кнопку проверить:</p>
            <br />
                   <div class="form-group">
                        
                        <div class="col-lg-10">
                            <asp:TextBox ID="TextBoxCode" runat="server" placeholder="хххххх12345" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCode"
                                CssClass="text-danger" ErrorMessage="Поле  заполнять обязательно." />
                        </div>
                    </div>
             <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Проверить" />
                            
                        </div>
                    </div>
            <br />
           <br />
           <br />
          <asp:Panel ID="Panel1" runat="server">
              <p >
                  <asp:Label ID="LabelFIO" runat="server" Text="" CssClass="control-label"></asp:Label>,
              </p>
              <p >
                  Ваша заявка на посещение специалиста <span style="color: #008000; font-weight: bold">принята</span>.</p>
              <p >
                  Талон №:<asp:Label ID="LabelTalonNum" runat="server" Text="" CssClass="control-label"></asp:Label></p>
              <p >
                  Филиал/отделение:<b><asp:Label ID="LabelFilial" runat="server" Text="" CssClass="control-label"></asp:Label></b>
                   Специальность врача: 
                  <b><asp:Label ID="LabelSpec" runat="server" Text="" CssClass="control-label"></asp:Label></b></p>
              <p >
                  Врач: <b><asp:Label ID="LabelVrach" runat="server" Text="" CssClass="control-label"></asp:Label></b></p>
              <p >
                  Дата/время талона:<span class="Apple-converted-space">&nbsp;</span><b><asp:Label ID="LabelDate" runat="server" Text="" CssClass="control-label"></asp:Label></b></p>
              <p >
                  &nbsp;</p>
              <p >
                  Вам необходимо за 15 минут до указанного времени явиться к кабинету выбранного Вами врача. С собой иметь – паспорт, полис, СНИЛС, при возможности распечатанная данная страница.</p>
              <p >
                  Если ранее Вы не обращались в указанную поликлинику, Вам необходимо за 30 минут до времени приема подойти в регистратуру, с собой иметь – паспорт, полис, СНИЛС.</p>
              <p >
                  При обращении к врачу необходимо иметь с собой сменную обувь или надетые на обувь бахилы.</p>
              <p >
                  Если Вас отказались принять по данному обращению, Вы имеет право обратиться к руководителю организации, либо в форме обратной связи на сайте организации.</p>
              <p >
                  Для отмены записи пройдите, пожалуйста, <asp:HyperLink ID="HyperLinkForCancel" runat="server" Target="_blank">по этой ссылке</asp:HyperLink></p>
              <p >
                  С уважением, <asp:Label ID="LabelOrg" runat="server" Text="" CssClass="control-label"></asp:Label></p>



          </asp:Panel>
          <asp:Panel ID="Panel2" runat="server">
                 <p >
              &nbsp;</p>
          <p>
              <asp:Label ID="LabelFIO2" runat="server" Text="" CssClass="control-label"></asp:Label>, Ваша заявка на посещение специалиста <b><span style="color: #FF0000; font-weight: bold">отклонена</span></b>.</p>
          <p>
              Талон №:<asp:Label ID="LabelTalonNum2" runat="server" Text="" CssClass="control-label"></asp:Label></p>
              <p>
                   Филиал/отделение:<b><asp:Label ID="LabelFilial2" runat="server" Text="" CssClass="control-label"></asp:Label>
              </p>
          <p>
              Специальность врача: <b><asp:Label ID="LabelSpecialnost2" runat="server" Text="" CssClass="control-label"></asp:Label></b></p>
          <p>
              Врач:<span class="Apple-converted-space">&nbsp;</span><b><asp:Label ID="LabelVrach2" runat="server" Text="" CssClass="control-label"></asp:Label></b></p>
          <br>
          <p >
              Дата/время талона:<span class="Apple-converted-space">&nbsp;</span><b><asp:Label ID="LabelDate2" runat="server" Text="" CssClass="control-label"></asp:Label></b></p>
          <p >
              Причина отказа: <asp:Label ID="LabelOtkazText" runat="server" Text="" CssClass="control-label" ForeColor="#000066"></asp:Label> </p>
        
          <p >
              Если Вас отказались принять по данному обращению, Вы имеет право обратиться к руководителю организации, либо в форме обратной связи на сайте организации.</p>
          <br />
          <p >
              С уважением, <asp:Label ID="LabelOrg2" runat="server" Text="" CssClass="control-label"></asp:Label></p>
          </asp:Panel>


          <asp:Panel ID="Panel3" runat="server">
              <p>
              <asp:Label ID="LabelFIO3" runat="server" Text="" CssClass="control-label"></asp:Label>, Ваша заявка еще не обработана, пожалуйста, ожидайте. Обычно обработка заявок производится до 17:00 рабочего дня.</p>

          </asp:Panel>
            
        <p>Хорошего Вам дня.</p>



      </div>
</asp:Content>
