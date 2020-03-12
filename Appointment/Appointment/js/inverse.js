function inv3(){

javascript: (function () {
    function load_script(src, callback) {
        var s = document.createElement('script');
        s.src = src;
        s.onload = callback;
        document.getElementsByTagName('head')[0].appendChild(s);
    }

    function invertElement() {
        var colorProperties = ['color', 'background-color'];
        var color = null;
        for (var prop in colorProperties) {
            prop = colorProperties[prop];
            if (!$(this).css(prop)) continue;
            if ($(this).data(prop) != $(this).css(prop)) continue;

            if (($(this).css(prop) === 'rgba(0, 0, 0, 0)') || ($(this).css(prop) === 'transparent')) {
                if ($(this).is('body')) {
                    $(this).css(prop, 'black');
                    continue;
                } else {
                    continue;
                }
            }
            color = new RGBColor($(this).css(prop));
            if (color.ok) {
                $(this).css(prop, 'rgb(' + (255 - color.r) + ',' + (255 - color.g) + ',' + (255 - color.b) + ')');
            }
            color = null;
        }
    }

    function setColorData() {
        var colorProperties = ['color', 'background-color'];
        for (var prop in colorProperties) {
            prop = colorProperties[prop];
            $(this).data(prop, $(this).css(prop));
        }
    }

    function invertColors() {
        $(document).live('DOMNodeInserted', function (e) {
            var $toInvert = $(e.target).find('*').andSelf();
            $toInvert.each(setColorData);
            $toInvert.each(invertElement);
        });
        $('*').each(setColorData);
        $('*').each(invertElement);
        $('iframe').each(function () {
            $(this).contents().find('*').each(setColorData);
            $(this).contents().find('*').each(invertElement);
        });
    }
    load_script('http://www.phpied.com/files/rgbcolor/rgbcolor.js', function () {
        if (!window.jQuery) load_script('https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js', invertColors);
        else invertColors();
    });

})(jQuery);
}


function inv() {
    javascript: (function ()
    {
        var css = 'html {-webkit-filter: invert(100%);' + '-moz-filter: invert(100%);' + '-o-filter: invert(100%);' + '-ms-filter: invert(100%); }',
          head = document.getElementsByTagName('head')[0], style = document.createElement('style');
        if (!window.counter)
          { window.counter = 1; }
          else {
              window.counter++;
              if (window.counter % 2 == 0) { var css = 'html {-webkit-filter: invert(0%); -moz-filter: invert(0%); -o-filter: invert(0%); -ms-filter: invert(0%); }' }
          }; style.type = 'text/css'; if (style.styleSheet) { style.styleSheet.cssText = css; } else { style.appendChild(document.createTextNode(css)); } head.appendChild(style);
    })();
}

function inv2() {
    javascript: (function () {
        var css = 'html {-webkit-filter: invert(100%);' + '-moz-filter: invert(100%);' + '-o-filter: invert(100%);' + '-ms-filter: invert(100%); }';
        var head = document.getElementsByTagName('head')[0];
        var style = document.createElement('style');
        if (!window.counter) {
            window.counter = 1;
        } else {
            window.counter++;
            if (window.counter % 2 == 0) {
                var css = 'html {-webkit-filter: invert(0%); -moz-filter: invert(0%); -o-filter: invert(0%); -ms-filter: invert(0%); }'
            }
        }
        style.type = 'text/css';
        if (style.styleSheet) {
            style.styleSheet.cssText = css;
        } else {
            style.appendChild(document.createTextNode(css));
        }
        head.appendChild(style);
    }());
}