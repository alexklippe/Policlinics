Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin.Security
Imports System.Net
Imports System.IO
Imports System.Net.HttpWebRequest
Imports System.IO.IsolatedStorage

Public Class Site_Mobile
    Inherits System.Web.UI.MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String
    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' Код ниже защищает от XSRF-атак
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Использование маркера Anti-XSRF из файла cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Создание нового маркера Anti-XSRF и его сохранение в файле cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With { _
                 .HttpOnly = True, _
                 .Value = _antiXsrfTokenValue _
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If


        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad


    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Задание маркера Anti-XSRF
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Проверка маркера Anti-XSRF
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Ошибка проверки маркера Anti-XSRF.")
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dbmain As New mainDataContext
        Dim ordmain = From p In dbmain.Organization Where p.OrgDomainName = Request.Url.Host Or p.OrgTestDomainName = Request.Url.Host
        If ordmain.First.id = 6 Then
            Response.Redirect("https://sp1taganrog.ru/Vazhno/Booking")

        ElseIf ordmain.First.id = 7 Then

            Response.Redirect("https://zapisnapriemrostov.ru/?_lpu=75863316@mis_bars")

        End If
        Me.HyperLink1.Attributes.Add("onclick", "inv2();")
        If Not IsPostBack Then
            getCookie()
        End If
        GetContent()
    End Sub
    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click

        ChangeWCGA()
        setCookie()
        GetContent()


    End Sub
    Sub ChangeWCGA()
        If Me.HiddenFieldWCGA.Value = "1" Then  ''слабый на основной
            Me.HiddenFieldWCGA.Value = ""
        Else   ''основной-на слабый
            Me.HiddenFieldWCGA.Value = "1"
        End If

    End Sub

    Sub GetContent()
        If Me.HiddenFieldWCGA.Value = "1" Then  ''для слабовидящих
            LinkButton1.Text = "ОБЫЧНАЯ ВЕРСИЯ"
            Me.LiteralCSS.Text = " <link href=""css/WCGA/bootstrap.min.css"" rel=""stylesheet"" type=""text/css"" />" + _
                     "<link href=""css/WCGA/style.css"" rel=""stylesheet"" type=""text/css"" />" + _
                      "<link href=""css/WCGA/font-awesome.css"" rel=""stylesheet"" type=""text/css"" />"
            Me.LiteralBackStretch.Text = ""
        Else   ''основной
            LinkButton1.Text = "ВЕРСИЯ ДЛЯ СЛАБОВИДЯЩИХ"
            Me.LiteralCSS.Text = " <link href=""css/bootstrap.min.css"" rel=""stylesheet"" type=""text/css"" />" + _
                        "<link href=""css/style.css"" rel=""stylesheet"" type=""text/css"" />" + _
                       "<link href=""css/font-awesome.css"" rel=""stylesheet"" type=""text/css"" />"
            'Me.LiteralBackStretch.Text = "<script src=""../js/jquery.backstretch.js"" type=""text/javascript""></script>" + _
            '                  " <script type=""text/javascript"">" + _
            '                   "'use strict';" + _
            '          "   $.backstretch([""../img/34.jpg""], {duration: 300000, fade: 0  }    );    </script>"

        End If
    End Sub
    Sub setCookie()
        Dim requestCookie = Request.Cookies("WCGA")
        ''     Dim requestCookieGuidValue As Guid
        'If requestCookie IsNot Nothing Then
        '    ' Использование маркера Anti-XSRF из файла cookie
        '    requestCookie.Value = Me.HiddenFieldWCGA.Value
        '    'Page.ViewStateUserKey = _antiXsrfTokenValue
        'Else
        ' Создание нового маркера Anti-XSRF и его сохранение в файле cookie
        ' _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
        '  Page.ViewStateUserKey = _antiXsrfTokenValue

        Dim responseCookie = New HttpCookie("WCGA") With { _
             .HttpOnly = True, _
             .Value = Me.HiddenFieldWCGA.Value _
        }
        If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
            responseCookie.Secure = True
        End If
        Response.Cookies.[Set](responseCookie)
        'End If
    End Sub
    Sub getCookie()
        Dim requestCookie = Request.Cookies("WCGA")
        If requestCookie IsNot Nothing Then
            ' Использование маркера Anti-XSRF из файла cookie
            Me.HiddenFieldWCGA.Value = requestCookie.Value
        End If

    End Sub
End Class