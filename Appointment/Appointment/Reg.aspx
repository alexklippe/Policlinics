<%@ page title="" language="vb" autoeventwireup="false" masterpagefile="~/Site.Master" codebehind="Reg.aspx.vb" inherits="Appointment._Default1" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
        <div id="banner">
            <h1>Запись на прием <strong>Талон</strong> </h1>
            <div class="registrationform  ">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Внимание! На оформление талона у Вас есть <asp:Label ID="LabelTimeout" runat="server" Text="Label">20</asp:Label> минут, по истечении этого времени резерв отменится и форма будет обнулена.</legend>
                       

                        <div class="form-group">
                            <asp:Label ID="Label12" runat="server" Text="Организация:" CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="Labelorg" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label13" runat="server" Text="Филиал/отделение:" CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelFil" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label14" runat="server" Text="Адрес оказания помощи: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelAdd" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label15" runat="server" Text="Специальность врача: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelSpec" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label16" runat="server" Text="Врач: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelVrach" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>
                         <div class="form-group">
                            <asp:Label ID="Label23" runat="server" Text="Примечание: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="Labeldesc" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label17" runat="server" Text="Категория врача: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelKat" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label18" runat="server" Text="Образование врача: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelObr" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label20" runat="server" Text="Сертификат врача: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelCert" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label19" runat="server" Text="Дата/время приема: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelDT" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>
                         <div class="form-group">
                            <asp:Label ID="Label22" runat="server" Text="Особенность приема: " CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:Label ID="LabelOsobenn" runat="server" Text="" CssClass="text-info"></asp:Label>
                            </div>
                        </div>

                       
                    </fieldset>

                </div>
            </div>
        </div>
    </div>


    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
        <div class="registrationform">
            <div class="form-horizontal">
                <fieldset>
                    <legend>Персональные данные <i class="fa fa-pencil pull-right"></i></legend>

                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Email" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                                CssClass="text-danger" ErrorMessage="Поле адреса электронной почты заполнять обязательно. " />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<br />в e-mail допущена ошибка" 
                                 CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBoxEmail"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label11" runat="server" Text="Телефон" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxPhone" runat="server" placeholder="8-928-1234567" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPhone"
                                CssClass="text-danger" ErrorMessage="Поле адреса Телефон заполнять обязательно." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Фамилия" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxSurname" runat="server" placeholder="Иванов" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxSurname"
                                CssClass="text-danger" ErrorMessage="Поле Фамилии заполнять обязательно." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Имя" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxName" runat="server" placeholder="Иван" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxname"
                                CssClass="text-danger" ErrorMessage="Поле Имя заполнять обязательно." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Отчество" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxMidName" runat="server" placeholder="Иванович" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Пол" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <div class="radio">
                                <label>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                        <asp:ListItem Selected="True" Value="1">Мужской</asp:ListItem>
                                        <asp:ListItem Value="0">Женский</asp:ListItem>
                                    </asp:RadioButtonList>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Дата рождения" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxBirthDay" runat="server" placeholder="01.01.1970" CssClass="form-control"  type="date" min="1900-01-01" max="2020-12-31"></asp:TextBox>
                      <%--      <asp:MaskedEditExtender ID="TextBoxBirthDay_MaskedEditExtender" runat="server" TargetControlID="TextBoxBirthDay" UserDateFormat="DayMonthYear" CultureName="Ru-ru" ErrorTooltipEnabled="True"  MaskType="Date" Mask="99.99.9999" />--%>
                            
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxBirthday"
                                CssClass="text-danger" ErrorMessage="Поле Дата рождения заполнять обязательно." />
                        </div>
                    </div>
                    <%-- <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Password" CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" CssClass="form-control"
                                    TextMode="Password"></asp:TextBox>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" />
                                    </label>
                                </div>
                            </div>
                        </div>--%>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Адрес регистрации (либо проживания)" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="TextBoxAddress" runat="server" placeholder="Ростовская область, г.Таганрог, ул.Петровская 15, кв. 10" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddress"
                                CssClass="text-danger" ErrorMessage="Поле Адрес заполнять обязательно." />
                        </div>
                    </div>


                    <fieldset>
                        <legend>Полис обязательного медицинского страхования:<i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="Label9" runat="server" Text="Серия и номер" CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="TextBoxPolisNum" runat="server" placeholder="6150610828000000" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPolisNum"
                                    CssClass="text-danger" ErrorMessage="Поле номер полиса заполнять обязательно." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label10" runat="server" Text="Наименование страховой организации" CssClass="col-lg-3 control-label"></asp:Label>
                            <div class="col-lg-9">
                                <asp:TextBox ID="TextBoxInsuranseCompany" runat="server" placeholder="Ростовский филиал ЗАО МАКС-М" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxInsuranseCompany"
                                    CssClass="text-danger" ErrorMessage="Поле Страховая компания заполнять обязательно." />
                            </div>
                        </div>

                    </fieldset>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Медицинская карта" CssClass="col-lg-3 control-label"></asp:Label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="DropDownListMedKarta" runat="server" CssClass="form-control ddl">
                                <asp:ListItem Value="1" Selected="True" >В учреждении</asp:ListItem>
                                <asp:ListItem Value="2">На руках</asp:ListItem>
                                <asp:ListItem Value="3">Завести новую</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-9 col-lg-offset-2">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Записаться" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Отмена" />
                        </div>
                    </div>
                </fieldset>
                
            </div>
        </div>
    </div>
<asp:HiddenField ID="HiddenFieldIdTalon" runat="server" />

</asp:Content>
