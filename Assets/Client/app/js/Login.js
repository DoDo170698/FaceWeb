$(document).ready(function () {
    $(".avatar").click(function () {
        $(".lg-container").addClass("open");
        $(".login-frm").delay(400).fadeIn();
    });
    //$(document).keyup(function (e) {
    //    if (e.keyCode == 13) {
    //        $(".avatar").trigger("click");
    //        var btnLogin = $("#btn_login");
    //        if (btnLogin.hasClass("enable")) {
    //            btnLogin.trigger("click");
    //        } else {
    //            btnLogin.addClass("enable");
    //        }
    //    }
    //});
    //$(document).click(function (e) {
    //    var btnLogin = $("#btn_login");
    //    if (!btnLogin.hasClass("enable")) {
    //        btnLogin.addClass("enable");
    //    }
    //    $(".avatar").trigger("click");
    //});
    //$(".form-control").click(function () {
    //    $(".notice").addClass("d-none");
    //});
});