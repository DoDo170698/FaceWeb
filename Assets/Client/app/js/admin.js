var Admin = {
    init: function () {

        Admin.upEvent();
        Admin.onEvent();
        Admin.triggers();
    },
    upEvent: function (container) {

    },
    onEvent: function () {

        jQuery(document).on("keyup", "#UpConfigValue", function () {
            var v = parseInt(jQuery(this).val());
            if (isNaN(v))
            {
                v = 0;
            } else
            {
                v = v * 1024;
            }
            var sizeConvert = Utils.convertSize(v);
            jQuery("#UpConfigValueConvert").html(sizeConvert);
        });

        jQuery(document).on("change", ".changeSLUpdate", function () {
            var data = jQuery(this).getDataUppername();
            var url = jQuery(this).attr("data-url");
            if (!Utils.isEmpty(url))
            {
                data["Value"] = jQuery(this).val();
                jQuery.ajax({
                    type: "POST",
                    async: true,
                    url: url,
                    data: data,
                    success: function (response) {

                    }
                });
            }
        });
        jQuery(document).on("change", "#UpBlockContentType, #CrBlockContentType", function () {
            var form = jQuery(this).closest("form");
            form.find(".gLoaiTin").addClass("hidden");
            form.find(".gChuyenMuc").addClass("hidden");
            form.find(".gSoLuongHienThi").addClass("hidden");
            form.find(".gKieuHienThi").addClass("hidden");
            form.find(".gBaiVietCuThe").addClass("hidden");
            form.find(".gNoiDung").addClass("hidden");
            form.find(".gBanner").addClass("hidden");
            form.find(".attachFile").addClass("hidden");

            var contentType = parseInt(jQuery(this).val());
            switch (contentType)
            {
                case 1: //Code
                    break;
                case 2: //Header
                case 3: //Footer
                    break;
                case 4: //Banner
                    form.find(".gBanner").removeClass("hidden");
                    form.find(".attachFile").removeClass("hidden");
                    break;
                case 5: //Html
                    form.find(".gNoiDung").removeClass("hidden");
                    break;
                default:
                    form.find(".gLoaiTin").removeClass("hidden");
                    form.find(".gChuyenMuc").removeClass("hidden");
                    form.find(".gSoLuongHienThi").removeClass("hidden");
                    form.find(".gKieuHienThi").removeClass("hidden");
                    form.find(".gBaiVietCuThe").removeClass("hidden");
                    form.find(".autocompleteItem").attr("data-type", contentType);
                    break;
            };
        });
        jQuery(document).on("click", ".addFormItem", function () {

            var form = jQuery(this).closest("form");
            var tpl = form.find(".tplFormItem").last().clone();
            tpl.removeClass("has-error");
            tpl.find(".form-control").each(function(){
                jQuery(this).val("");
                var orginName = jQuery(this).attr("data-originname");
                jQuery(this).attr("Name", orginName);
                jQuery(this).attr("data-bv-field", orginName);
            });
            tpl.find(".deleteAnswer").removeClass("hidden");
            tpl.find(".help-block").css("display", "none");
            tpl.find(".form-control-feedback").css("display", "none").removeClass("glyphicon").removeClass("glyphicon-remove");
            jQuery(tpl).insertAfter(form.find(".tplFormItem").last());
        });
        jQuery(document).on("click", ".deleteAnswer", function () {
            jQuery(this).closest(".answerItem").remove();
        });
    },

    triggers: function () {
        jQuery("#UpBlockContentType").trigger("change");
    }
};
jQuery(document).ready(function () {
    Admin.init();
});