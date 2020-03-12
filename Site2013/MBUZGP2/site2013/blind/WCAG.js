if ($.cookie("CecutientCookie")=="on"){
    CecutientOn();
    if ($.cookie("fonts")=="small"){SmallFonts();}
    if ($.cookie("fonts")=="medium"){MediumFonts();}
    if ($.cookie("fonts")=="big"){BigFonts();}
    if ($.cookie("image")=="on"){ImageOn();}
    if ($.cookie("image")=="off"){ImageOff();}
    if ($.cookie("style")=="white"){WhiteStyle();}
    if ($.cookie("style")=="black"){BlackStyle();}
    if ($.cookie("style")=="blue"){BlueStyle();}
    if ($.cookie("style")=="green"){GreenStyle();}
}
/*alert($.cookie("fonts")+'&'+$.cookie("CecutientCookie"));*/
/*Включение стилей для слабовидящих*/
$('#CecutientOn').click(function(){CecutientOn();});
/*Включение выключение изображений*/
$('#ImageOn').click(function(){ImageOn();});
$('#ImageOff').click(function(){ImageOff();});
/*Размер шрифта*/
$('#SmallFonts').click(function(){SmallFonts();});
$('#MediumFonts').click(function(){MediumFonts();});
$('#BigFonts').click(function(){BigFonts();});
/*Цветовая схема*/
$('#WhiteStyle').click(function(){WhiteStyle();});
$('#BlackStyle').click(function(){BlackStyle();});
$('#BlueStyle').click(function(){BlueStyle();});
$('#GreenStyle').click(function(){GreenStyle();});
/*Функция обработчик включения стилей*/
function CecutientOn(){
    $('#CecutientOn').css("display","none");
    $('#CecutientOff').css("display","inline-block");
    $('#header1, #banner-fade, #left, #right, #BottomBanners, #AbsoluteTop, #nr, #nl').css("display","none");
    $('#CecutientTop, .TopMenu').css("display","block");
    $('#content').css({"width":"100%","padding":"0px"});
    $('#content *').css({"background":"#fff","color":"#000"});
    $('#bottom, #bottom *').css({"background":"#000","color":"#fff"});
    $('#headerline').css({"color":"#fff","background":"#000","height":"30px"});
    $('.TopMenu').css({"border":"1px solid #000","paddingTop":"10px","paddingBottom":"10px","marginTop":"10px"});
    $('.TopMenu li a').css({"background":"none","paddingTop":"0px","color":"#000"});
    $('.appointments').html("Записаться");
    $.cookie("CecutientCookie", "on", {
        expires: 365,
        path: '/'
    });
    return false;
}
/*Функции изменения размера шрифта*/
function SmallFonts(){
    if ($.cookie("CecutientCookie")=="on"){
        $('#center, .bottom, #CecutientTop').removeClass("MediumFonts BigFonts").addClass("SmallFonts");
        $.cookie("fonts", "small", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
function MediumFonts(){
    if ($.cookie("CecutientCookie")=="on"){
        $('#center, .bottom, #CecutientTop').removeClass("SmallFonts BigFonts").addClass("MediumFonts");
        $.cookie("fonts", "medium", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
function BigFonts(){
    if ($.cookie("CecutientCookie")=="on"){
        $('#center, .bottom, #CecutientTop').removeClass("SmallFonts MediumFonts").addClass("BigFonts");
        $.cookie("fonts", "big", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
/*Функции обработчик отображения изображений*/
function ImageOn(){
    if ($.cookie("CecutientCookie")=="on"){
        $('img').css("display","inline-block");
        $('#ImageOff').css("display","inline-block");
        $('#ImageOn').css("display","none");
        $.cookie("image", "on", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
function ImageOff(){
    if ($.cookie("CecutientCookie")=="on"){
        $('img').css("display","none");
        $('#ImageOff').css("display","none");
        $('#ImageOn').css("display","inline-block");
        $('#CecutientBtn img').css("display","inline-block");
        $.cookie("image", "off", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
/*Функции изменения цветовой схема*/
function WhiteStyle(){
    if ($.cookie("CecutientCookie")=="on"){
        $('body, html').css("background","#fff");
        $('#content').css({"width":"100%","padding":"0px"});
        $('#content *').css({"background":"#fff","color":"#000"});
        $('#CecutientTop').css("color","#000");
        $('.SubMenu').css("background","#fff");
        $('.SubMenu *').css("color","#000");
        $('#bottom, #bottom *').css({"background":"#000","color":"#fff"});
        $('#headerline').css({"color":"#fff","background":"#000"});
        $('.TopMenu').css({"border":"1px solid #000","paddingTop":"10px","paddingBottom":"10px","marginTop":"10px"});
        $('.TopMenu li a').css({"background":"none","paddingTop":"0px","color":"#000"});
        $('.PriceTable tr td').css("border","1px solid #000");
        $.cookie("style", "white", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
function BlackStyle(){
    if ($.cookie("CecutientCookie")=="on"){
        $('body, html').css("background","#000");
        $('#content').css({"width":"100%","padding":"0px"});
        $('#content *').css({"background":"#000","color":"#fff"});
        $('#CecutientTop').css("color","#fff");
        $('.SubMenu').css("background","#000");
        $('.SubMenu *').css("color","#fff");
        $('#bottom, #bottom *').css({"background":"#fff","color":"#000"});
        $('#headerline').css({"color":"#000","background":"#fff"});
        $('.TopMenu').css({"border":"1px solid #fff","paddingTop":"10px","paddingBottom":"10px","marginTop":"10px"});
        $('.TopMenu li a').css({"background":"none","paddingTop":"0px","color":"#fff"});
        $('.PriceTable tr td').css("border","1px solid #fff");
        $.cookie("style", "black", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
function BlueStyle(){
    if ($.cookie("CecutientCookie")=="on"){
        $('body, html').css("background","#9DD1FF");
        $('#content').css({"width":"100%","padding":"0px"});
        $('#content *').css({"background":"#9DD1FF","color":"#063462"});
        $('#CecutientTop').css("color","#063462");
        $('.SubMenu').css("background","#9DD1FF");
        $('.SubMenu *').css("color","#063462");
        $('#bottom, #bottom *').css({"background":"#063462","color":"#9DD1FF"});
        $('#headerline').css({"color":"#9DD1FF","background":"#063462"});
        $('.TopMenu').css({"border":"1px solid #063462","paddingTop":"10px","paddingBottom":"10px","marginTop":"10px"});
        $('.TopMenu li a').css({"background":"none","paddingTop":"0px","color":"#063462"});
        $('.PriceTable tr td').css("border","1px solid #063462");
        $.cookie("style", "blue", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
function GreenStyle(){
    if ($.cookie("CecutientCookie")=="on"){
        $('body, html').css("background","#3B2716");
        $('#content').css({"width":"100%","padding":"0px"});
        $('#content *').css({"background":"#3B2716","color":"#A9E44D"});
        $('#CecutientTop').css("color","#A9E44D");
        $('.SubMenu').css("background","#3B2716");
        $('.SubMenu *').css("color","#A9E44D");
        $('#bottom, #bottom *').css({"background":"#A9E44D","color":"#3B2716"});
        $('#headerline').css({"color":"#3B2716","background":"#A9E44D"});
        $('.TopMenu').css({"border":"1px solid #A9E44D","paddingTop":"10px","paddingBottom":"10px","marginTop":"10px"});
        $('.TopMenu li a').css({"background":"none","paddingTop":"0px","color":"#A9E44D"});
        $('.PriceTable tr td').css("border","1px solid #A9E44D");
        $.cookie("style", "green", {
            expires: 365,
            path: '/'
        });
        return false;
    }
}
/*Отключение версии для слабовидящих*/
$('#CecutientOff').click(function(){
    $.cookie("CecutientCookie", null);
    $.cookie("style", null);
    $.cookie("image", null);
    $.cookie("fonts", null);
    window.location.reload();
    return false;
});
});