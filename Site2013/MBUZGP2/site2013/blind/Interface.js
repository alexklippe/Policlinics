$(document).ready(function () {
    /*str = 0;
	$('.vote_lines dl dt small').each(function(){
		tmp = $(this).html();
		tmp = tmp.replace(" голосов)", "");
		tmp = tmp.replace("(", "");
		str += tmp*1
	})
	//alert(str);
	$('.vote_lines dl dd span.hidden').each(function(){
		tmp = $(this).html()*1;
		if (tmp>0)
			tmp = tmp/str*100;
		$(this).html(tmp);
	})*/

    // Voting
    var refreshSelect = function () {
        $("#voting table form .vote_answer").attr("value", $("#voting table form li.select .value").text());
    }
    refreshSelect();
    $("#voting table form li span").click(function () {
        var li = $(this).parents("li");
        var lis = $("#voting table form li");
        if (!li.hasClass("select")) {
            lis.removeClass("select");
            li.addClass("select");
            refreshSelect();
        }
    });

    var go_line = function (line) {
        var percent_obj = line.find(".percent");
        var percent = parseInt(line.find(".hidden").text());
        var line_obj = line.find(".line");
        var tmp_percent = 0;
        var line_interval = 0;
        if (percent != 0) line_interval = setInterval(function () {
            tmp_percent++;
            line_obj.css("width", (355 * tmp_percent / 100) + "px");
            percent_obj.text(tmp_percent);
            if (tmp_percent == percent) clearInterval(line_interval);
        }, 500 / percent);
    }
    $("#voting table .results").each(function () {
        var obj = $(this);
        var max_percent = 0;
        var max_obj;
        obj.find("dl").each(function () {
            var cur_percent = parseInt($(this).find("dd .hidden").text());
            if (cur_percent > max_percent) { max_percent = cur_percent; max_obj = $(this); }
            go_line($(this).find("dd"));
        });
        max_obj.addClass("pop");
    });
    $("#voting_list .vote_lines").each(function () {
        var obj = $(this);
        var max_percent = 0;
        var max_obj;
        obj.find("dl").each(function () {
            var cur_percent = parseInt($(this).find("dd .hidden").text());
            if (cur_percent > max_percent) { max_percent = cur_percent; max_obj = $(this); }
            go_line($(this).find("dd"));
        });
        max_obj.addClass("pop");
    });
    /*$("#voting table form .submit input").click(function(){
		$(this).parents("#voting").addClass("success");
		$("#voting table .results").each(function(){
			var obj = $(this);
			var max_percent = 0;
			var max_obj;
			obj.find("dl").each(function(){
				var cur_percent = parseInt($(this).find("dd .hidden").text());
				if (cur_percent>max_percent) { max_percent = cur_percent; max_obj = $(this); }
				go_line($(this).find("dd"));
			});
			max_obj.addClass("pop");
		});
		return false;
	});*/

    // Pager
    $("#pager .button").mouseenter(function () { $(this).addClass("button_hover"); }).mouseleave(function () { $(this).removeClass("button_hover"); })
    $("#pager ul li").mouseenter(function () { if (!$(this).hasClass("cur")) $(this).addClass("hover"); }).mouseleave(function () { if (!$(this).hasClass("cur")) $(this).removeClass("hover"); })

});