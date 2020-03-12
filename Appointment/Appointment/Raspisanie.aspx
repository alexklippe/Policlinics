<%@ page title="Расписание" language="vb" autoeventwireup="false" masterpagefile="~/Site.Master" codebehind="Raspisanie.aspx.vb" inherits="Appointment.Raspisanie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table table-striped">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <h2><%: Title %>.</h2>
        <div class="registrationform">


            <asp:Literal ID="Literal1" runat="server"></asp:Literal><br />
            <div class="registrationform text-info" role="alert">
                Для записи на прием нажмите на синий квадратик с цифрой. Квадратик отображается только при наличии свободных талонов. Цифра показывает количество свободных талонов на указанный день.

            </div>
            <br />
            <div class="registrationform text-success " role="alert">
                Выберите Филиал/отделение: 
            <div class="ddl">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="LinqDataSource1" DataTextField="filialName" DataValueField="id" CssClass="form-control ddl"></asp:DropDownList>
            </div>
            </div>
            <br />
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Appointment.mainDataContext" EntityTypeName="" TableName="OrgFilials" Where="idOrganization == @idOrganization">
                <WhereParameters>
                    <asp:ControlParameter ControlID="HiddenField1" Name="idOrganization" PropertyName="Value" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        </div>
    </table>

</asp:Content>
