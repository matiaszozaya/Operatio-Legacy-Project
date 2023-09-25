$(document).ready(function () {
    $("main").css("min-height", "calc(99.9% - " + ($("header").height() + $("footer").height()) + "px)");

    $(window).on("resize", function () {
        $("main").css("min-height", "calc(99.9% - " + ($("header").height() + $("footer").height()) + "px)");
    });
});