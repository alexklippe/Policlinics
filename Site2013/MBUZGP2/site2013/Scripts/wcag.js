
$(document).ready(function () {
    //sv_settings
    var selector = '#content, #content *, .navbar, .navbar *, .nav, .nav*, .container,  .container *, body';
    //-------------
    $('.fs-outer button').click(function () {
        $(selector).css('font-size', $(this).css('font-size'));
        $.cookie('font-size', $(this).attr('id'));
        $('.fs-outer button').removeClass('active');
        $(this).addClass("active");

    });

    $('.cs-outer button').click(function () {
        $(selector).css('color', $(this).css('color'));
        $(selector).css('background', $(this).css('background'));
        $.cookie('cs', $(this).attr('id'));
        $('.cs-outer button').removeClass('active');
        $(this).addClass("active");

    });

    $('.img-outer button').click(function () {
        if ($.cookie('img') != 'on') {
            $('img').css('display', 'none');
            $.cookie('img', 'on');
            $('#img-onoff-text').text(' Включить');
            $(this).addClass("active");
        } else {
            $('img').css('display', 'block');
            $.cookie('img', 'off');
            $('#img-onoff-text').text(' Выключить');
            $(this).removeClass("active");
        }
    });

    if ($.cookie('sv_on') == 'true') {
        $('#sv_on').addClass('active');
        $('#sv_settings').css('display', 'block');
        if ($.cookie('font-size') !== null) {
            $('#' + $.cookie('font-size')).click();
        }
        if ($.cookie('cs') !== null) {
            $('#' + $.cookie('cs')).click();
        }

    }


    $('#sv_on').click(
    function () {
        if ($.cookie('sv_on') != 'true') {
            $.cookie('sv_on', 'true');
            if ($.cookie('font-size') == "null") {
                $('.fs-n').click();
            }
            if ($.cookie('cs') == "null") {
                $('.cs-bw').click();
            }
        }
        else {
            $.cookie('sv_on', 'false');
        }
        location.reload();
    }
    );

});