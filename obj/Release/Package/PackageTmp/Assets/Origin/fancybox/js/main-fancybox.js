$(document).ready( function () {
    $("[data-fancybox]").fancybox({
        margin: [44, 0, 22, 0],
        loop: true,
        buttons: [
            "zoom",
            //"share",
            //"slideShow",
            "fullScreen",
            "download",
            //"thumbs",
            "close"
        ],
    });
    //$(".jobFile_Fancybox").click(function () {
    //    $(this).parents(".jobFile_Attach").find(".jobFile_Name").click();
    //});
})