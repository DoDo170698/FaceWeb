var StgfilePage = {
    init: function () {

        StgfilePage.onEvent();
        StgfilePage.upEvent();
    },
    onEvent: function () {

        jQuery(document).on("click", ".form-files .delFile", function () {
            jQuery(this).closest("tr").remove();
            Utils.refreshCountTable(jQuery("#DragBoxFrmUpfile_tbody"));
        });
        jQuery(document).on("click", ".form-files .delFiles", function () {

            var formFiles = jQuery(this).closest(".form-files");
            formFiles.find("tbody .checkboxes").each(function () {
                if (jQuery(this).prop("checked")) {
                    jQuery(this).closest("tr").remove();
                }
            });
            formFiles.find(".group-checkable").prop("checked", false);
            Utils.refreshCountTable(jQuery("#DragBoxFrmUpfile_tbody"));
        });
        jQuery(document).on("click", ".cancelUpfile", function () {
            jQuery(this).closest("form").find("tbody tr").each(function () {
                jQuery(this).remove();
            });
            jQuery(this).closest("form").find(".tickrows").prop("checked", false);
            jQuery(this).closest(".ui-dialog-content").dialog('close');
        });
        jQuery(document).on("click", ".miniDialog", function () {
            jQuery(jQuery(this).attr("data-rel")).removeClass("hidden");
            jQuery(this).closest(".ui-dialog-content").dialog('close');
        });
        jQuery(document).on("click", ".showDialog", function () {
            jQuery(jQuery(this).addClass("hidden").attr("data-rel")).dialog("open");
        });
        jQuery(document).on("change", ".slOcrForm", function () {
            jQuery(this).closest("form").find(".ocrforms").val(jQuery(this).val());
        });
        jQuery(document).on("change", ".slDoctype", function () {
            jQuery(this).closest("form").find(".doctypes").val(jQuery(this).val());
        });
        jQuery(document).on("change", ".slChangeFT", function () {
            if (jQuery(this).val() == "textarea") {
                jQuery(this).closest(".scrollItem").find(".ofTextarea").removeClass("hidden");
            } else {
                jQuery(this).closest(".scrollItem").find(".ofTextarea").addClass("hidden");
            }
        });
        jQuery(document).on("click", ".addUpfile", function () {
            var inputUpfile = jQuery(jQuery(this).attr("data-rel"));
            inputUpfile.val("").trigger("click");
        });
        jQuery(document).on("click", ".clickUpfile", function () {
            var data = jQuery(this).getData();
            var inputUpfile = jQuery(data.rel);
            var elTarget = jQuery(inputUpfile.attr("data-target"));
            var items = elTarget.find("tbody").find("tr");

            jQuery("#FrmUpfile").attr("action", data.href);
            jQuery("#FrmUpfileParent").val(data.parentId);
            jQuery("#FrmUpfileParentName").val(data.parentName);
            jQuery("#FrmUpfileTreefolder").val(data.treefolder);

            if (items.length > 0) {
                StgfilePage.dialogUp(elTarget);
            }
            else {
                inputUpfile.val("").trigger("click");
            }
        });
        jQuery(document).on("submit", "#FrmUpfile", function () {
            try {
                var form = jQuery(this);
                var action = form.attr("action");
                if (form.find("tbody .progress").length > 0) {
                    alert("Tài liệu đang được tải lên. Vui lòng đợi trong ít phút.");
                    return false;
                }
                if (form.find("tbody .files").length === 0) {
                    alert("Chưa có tài liệu nào được tải lên");
                    return false;
                }
                form.find("[name='RedirectPath']").val(Utils.getRedirect());
                return true;
            }
            catch (e) {
            }

            return false;
        });
        jQuery(document).on("change", ".changeDoctype", function () {
            try {
                var obj = jQuery(this);
                var target = jQuery(this)
                    .attr("data-target");

                var data = jQuery(this).getDataUppername();
                data.RedirectPath = Utils.getRedirect();
                data.IDDoctype = jQuery(this).val();

                delete data.Target;

                jQuery.ajax({
                    type: "POST",
                    async: true,
                    url: data.Href,
                    data: data,
                    beforeSend: function () {
                        obj.addClass("loadingr");
                    },
                    complete: function () {
                        obj.removeClass("loadingr");
                    },
                    error: function () {
                        obj.removeClass("loadingr");
                    },
                    success: function (response) {
                        Utils.sectionBuilder(response);
                        if (response.hasOwnProperty("isCust")) {
                            Utils.closeOverlay();
                            jQuery(target).html(response.htCust);
                        }
                        Utils.updateImageViewer();
                        Utils.updatePlayer(jQuery(target));
                        Utils.updateTab(jQuery(target));
                        Utils.updateInputDate(jQuery(target));
                        Utils.updateFormState(jQuery(target));
                        Utils.updateScrollBar(jQuery(target));
                        Autocomplete.init(jQuery(target));
                        Main.upEvent();
                    }
                });
            } catch (e) {
            }
        });

        jQuery(".slChangeFT").trigger("change");
    },
    upEvent: function (container) {
        if (Utils.isEmpty(container))
            container = jQuery(document);

        container.find(".inputStgFile").each(function () {
            //if (!jQuery(this).hasClass("setAjaxUploaded")) {
            var obj = jQuery(this).addClass("setAjaxUploaded");
            obj.ajaxUploader({
                name: "FileDocument",
                postUrl: Cdata.Storage.domain + "/uploader/upfile",
                onBegin: function (e, t) {

                    try {
                        var data = obj.getData();
                        if (!obj.hasClass(".folderOpenning") && jQuery(".folderOpenning").length > 0) {
                            data = jQuery(".folderOpenning").getData();
                        }
                        jQuery("#FrmUpfile").attr("action", data.href);
                        jQuery("#FrmUpfileParent").val(data.parentId);
                        jQuery("#FrmUpfileParentName").val(data.parentName);
                        jQuery("#FrmUpfileTreefolder").val(data.treefolder);
                    } catch (e) { }

                    StgfilePage.dialogUp(jQuery(obj.attr("data-target")));
                    return true;
                },
                onClientLoadStart: function (e, file, t) {


                    var elTarget = jQuery(obj.attr("data-target"));
                    var row = elTarget.find("tfoot tr").clone();
                    row.attr("id", StgfilePage.getRowId(file.id));
                    row.find(".files").val(file.name);
                    row.find(".sizes").val(Utils.convertSize(file.size));
                    row.find(".tickrow").prop("checked", false);
                    row.find(".doctypes").val(jQuery("#FrmUpfileDoctypes").val());
                    row.find(".ocrforms").val(jQuery("#FrmUpfileOCRForms").val());


                    var extentions = file.type.replace("application/", ".").replace("image/",".");
                    if (
                        (obj.attr("data-type") == "OCR" && (Utils.IsImage(extentions) || Utils.IsPdf(extentions)))
                        || obj.attr("data-type") != "OCR"
                    ) {
                        elTarget.find("tbody").append(row);
                        elTarget.find(".useScrollBar")
                            .perfectScrollbar("update")
                            .scrollTop(1000);
                        StgfilePage.upEventRow(jQuery(StgfilePage.getRowId(file.id, true)));
                        Utils.refreshCountTable(jQuery("#DragBoxFrmUpfile_tbody"));
                    } else {
                        if (obj.attr("data-type") == "OCR") {
                            Utils.setError("Chỉ nhận định dạng file là ảnh hoặc PDF");
                        }
                    }

                },
                onClientProgress: function (e, file) {
                    StgfilePage.onProgress(e, file);
                },
                onServerProgress: function (e, file, t) {
                    StgfilePage.onProgress(e, file);
                },
                onClientAbort: function (e, file) {
                    StgfilePage.onAbort(e, file);
                },
                onClientError: function (e, file) {
                    StgfilePage.onAbort(e, file);
                },
                onServerAbort: function (e, file, t) {
                    StgfilePage.onAbort(e, file);
                },
                onServerError: function (e, file, t) {
                    StgfilePage.onAbort(e, file);
                },
                onSuccess: function (e, file, t, data) {
                    var row = jQuery(StgfilePage.getRowId(file.id, true));
                    row.find(".filepaths").val(data.FilePath);
                    row.find(".upStatus").html("<i class='loaded'></i>");
                }
            });
            //}
        });

    },
    dialogUp: function (elTarget) {
        elTarget.dialog({
            width: 800,
            height: 300,
            autoOpen: true,
            resizable: false,
            open: function () {
                elTarget.fadeIn();

                jQuery("#Uptree").fadeOut();
                jQuery("#FrmUpfile").fadeIn();
                jQuery("#drap_drop_fixed").removeClass("active");
                jQuery(".drap_drop_fixed_ov").removeClass("active");

                if (elTarget.hasClass("useScrollBar"))
                    jQuery(this).parent(".ui-dialog").addClass("hf50d");
                Utils.openOverlay();
            },
            close: function () {
                jQuery(this).closest(".ui-dialog").removeClass("hiddenDialog");
                var hiddenDialogs = jQuery(document).find(".hiddenDialog");
                if (hiddenDialogs.length > 0) {
                    hiddenDialogs.last().removeClass("hidden");
                } else {
                    Utils.closeOverlay();
                }
            }
        });
    },
    upEventRow: function (row) {
        row.find(".datetime").datetimepicker({
            format: "d-m-Y H:i",
            lang: "vi",
            scrollInput: false
        });
    },
    onProgress: function (e, file) {
        var pc = Math.floor(100 * (e.loaded / e.total));
        var rowId = StgfilePage.getRowId(file.id, true);
        jQuery(rowId).find(".progress-bar").css("width", pc + "%");
        jQuery(rowId).find(".progress-label").text(pc + "%");
    },
    onAbort: function (e, file) {
        jQuery(StgfilePage.getRowId(file.id, true))
            .find(".upStatus")
            .html("<i class='loadfail'></a>");
    },
    getRowId: function (fileId, isSelector) {
        return (isSelector ? "#" : "") + "DocUploadR" + fileId;
    }
};
jQuery(document).ready(function () {
    StgfilePage.init();
});
