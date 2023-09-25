$("main").css("min-height", "calc(98.2vh - " + ($("header").height() + $("footer").height()) + "px)");

$(document).ready(function () {
    $(window).on("resize", function () {
        $("main").css("min-height", "calc(98.2vh - " + ($("header").height() + $("footer").height()) + "px)");
    });
});