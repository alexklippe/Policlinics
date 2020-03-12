$(document).ready(function () {
    if ($.cookie('blind') == 'blind') {
        set_cookie();
    } else { $.cookie('blind', 'normal', { path: '/' }); }

    $(".a-settings").click(function () {
        $(".access").hide();
        $("body").css("margin-top", "0");
        $(".blind_menu").show();
        $("body").removeClass('small_font medium_font big_font').addClass('normal');
        $("body").removeClass("blue_background black_background white_background blind");
        $.cookie('blind', 'normal', { path: '/' });

    })


    $(".blind_menu").click(function () {
        $.cookie('blind', 'blind', { path: '/' });
        $("body").addClass('blind');
        set_cookie();
    });

    $('.a-fontsize a').click(function () {
        fontsize = $(this).attr('rel');
        $.cookie('blind-font-size', fontsize, { path: '/' });
        set_font_size();
        return false;
    });

    $('.a-colors a ').click(function () {
        colors = $(this).attr('rel');
        $.cookie('blind-color', colors, { path: '/' });
        set_colors();
        return false;
    });
    $('.a-imagesoff').click(function () {

        $("img").toggleClass('blind_img');
        clr = $("img").attr('class');
        $.cookie('blind-images', clr, { path: '/' });
        set_images();
        return false;
    });

    function set_cookie() {
        $("body").css("margin-top", "55px");
        $(".access").show();
        $(".blind_menu").hide();
        $("body").removeClass("normal");
        if ((!$.cookie('blind-color'))) {
            $.cookie('blind-color', 'white_background', { path: '/' });
        }
        if (!$.cookie('blind-font-size')) {
            $.cookie('blind-font-size', 'medium_font', { path: '/' });
        }
        if (!$.cookie('blind-images')) {
            $.cookie('blind-images', '', { path: '/' });
        }
        set_font_size();
        set_colors();
        set_images();

    }

    function set_font_size() {
        $('body').removeClass('small_font medium_font big_font').addClass($.cookie('blind-font-size'));
    }

    function set_colors() {
        $("body, div .sidebar").removeClass("blue_background white_background black_background").addClass($.cookie('blind-color'));
        $("div").removeClass("blue_background white_background black_background").addClass($.cookie('blind-color'));
    }
    function set_images() {

        $("img, .block_m .block3 .filling .booklet img, object").removeClass("blind_img").addClass($.cookie('blind-images'));
        $("body").removeClass("blind_img").addClass($.cookie('blind-images'));
    }

});