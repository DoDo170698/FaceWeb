var UpfilePage = {

    init: function () {

        UpfilePage.onEvent();
        UpfilePage.upEvent();
    },
    //getData: function (a) {
    //    var data = {};
    //    try {
    //        a.each(function () {
    //            jQuery.each(this.attributes, function () {
    //                var name = this.name.toLowerCase();
    //                if (name.indexOf("data-") === 0) {
    //                    var k = "";
    //                    var args = name.split("-");
    //                    for (var n = 0; n < args.length; n++) {
    //                        if (n == 0) continue;
    //                        if (n == 1) {
    //                            k += args[n];
    //                        }
    //                        else {
    //                            k += args[n].capitalize()
    //                        }
    //                    }
    //                    data[k] = this.value;
    //                }
    //            });
    //        });
    //    } catch (e) {
    //    }
    //    return data;
    //},
    onEvent: function () {

        //jQuery(document).on("click", ".attachFile", function () {
        //    var data = UpfilePage.getData(jQuery(this));
        //    jQuery(data.rel).attr("data-target", data.target);
        //    jQuery(data.rel).attr("data-file-name", data.fileName);
        //    jQuery(data.rel).attr("data-file-path", data.filePath);
        //    jQuery(data.rel).attr("data-file-title", data.fileTitle);
        //    jQuery(data.rel).attr("data-file-url", data.fileUrl);

        //    jQuery(data.rel).val("").trigger("click");
        //});
        //jQuery(document).on("click", ".delMember", function () {
        //    jQuery(this).closest(".member").slideUp("slow", function () {
        //        var parent = jQuery(this).parent();
        //        if (parent.find(".member").length == 1) {
        //            parent.addClass("hidden");
        //        }
        //        jQuery(this).remove();
        //    });
        //});

    },
    upEvent: function (container) {
        //if (Utils.isEmpty(container))
        //    container = jQuery(document);

        //container.find(".inputUpFile").each(function () {
        //    var obj = jQuery(this);
        //    if (!obj.hasClass("setUpFiled")) {
        //        obj.hasClass("setUpFiled");
        //        obj.ajaxUploader({
        //            name: "FileDocument",
        //            postUrl:"/uploader/upfile",
        //            //elTarget: obj.attr("data-target"),
        //            onBegin: function (e, t) {
        //                return true;
        //            },
        //            onClientLoadStart: function (e, file, t) {
        //            },
        //            onClientProgress: function (e, file, t) {
        //                jQuery(obj.attr("data-target")).addClass("loading");
        //            },
        //            onServerProgress: function (e, file, t) {
        //                jQuery(obj.attr("data-target")).addClass("loading");
        //            },
        //            onClientAbort: function (e, file, t) {
        //                jQuery(obj.attr("data-target")).removeClass("loading");
        //            },
        //            onClientError: function (e, file, t) {
        //                jQuery(obj.attr("data-target")).removeClass("loading");
        //            },
        //            onServerAbort: function (e, file, t) {
        //                jQuery(obj.attr("data-target")).removeClass("loading");
        //            },
        //            onServerError: function (e, file, t) {
        //                jQuery(obj.attr("data-target")).removeClass("loading");
        //            },
        //            onSuccess: function (e, file, t, data) {
        //                var dataObj = obj.getData();
        //                var targetObj = jQuery(dataObj.target);
        //                targetObj.closest(".hidden").removeClass("hidden");

        //                if (targetObj.hasClass("ui-group-item")) {
        //                    var item = jQuery(
        //                        "<div class='form-group has-feedback member'>" +
        //                        "<div class='col-lg-12'>" +
        //                        "<input name='" + dataObj.filePath + "' type='hidden' value='" + data.FilePath + "'/>" +
        //                        "<input name='" + dataObj.fileName + "' type='text' class='form-control' data-bv-notempty-message='" + dataObj.bvNotemptyMessage + "' data-bv-notempty='true' data-bv-field='" + dataObj.fileName + "' value='" + data.FileName + "' />" +
        //                        "<i class='glyphicon glyphicon-remove delMember'></i>" +
        //                        "</div>" +
        //                        "</div>"
        //                    );
        //                    targetObj.removeClass("loading").append(item);
        //                    item.bootstrapValidator();
        //                }
        //                else if (targetObj.hasClass("link-block-item")) {

        //                    var extention = data.FileName.substr((data.FileName.lastIndexOf('.')));
        //                    console.log(extention);
        //                    var isImage = (/\.(gif|jpg|jpeg|tiff|png)$/i).test(extention);
        //                    console.log(isImage);
        //                    if (isImage && targetObj.hasClass("show-img") ) {
        //                        targetObj.removeClass("loading").append(
        //                            "<span class='fileitem member'>" +
        //                            "<img class='img-thumbnail' src='" + Cdata.SrcPath(data.FilePath) + "' title='" + data.FileName + "' />" +
        //                            "<input name='" + dataObj.fileName + "' class='fileNames' type='hidden' value='" + data.FileName + "' />" +
        //                            "<input name='" + dataObj.filePath + "' class='filePaths' type='hidden' value='" + data.FilePath + "'/>" +
        //                            "<button type='button' class='btn btn-xs btn-link close delMember'>x</button>" +
        //                            "</span>"
        //                        );
        //                    } else {
        //                        targetObj.removeClass("loading").append(
        //                            "<span class='fileitem member'>" +
        //                            "<a  class='img-thumbnail' target='_blank' style='padding-right:25px;' href='" + Cdata.SrcPath(data.FilePath) + "' ><i class='fa fa-file-o'></i> " + data.FileName + "</a>" +
        //                            "<input name='" + dataObj.fileName + "' class='fileNames' type='hidden' value='" + data.FileName + "' />" +
        //                            "<input name='" + dataObj.filePath + "' class='filePaths' type='hidden' value='" + data.FilePath + "'/>" +
        //                            "<button type='button' class='btn btn-xs btn-link close delMember'>x</button>" +
        //                            "</span>");
        //                    }
        //                }
        //                else {
        //                    targetObj.removeClass("loading").append(
        //                        "<span class='fileitem member' style=\"padding: 5px 15px\">" +
        //                        "<a target=\"_blank\" href=\"" + Cdata.SrcPath(data.FilePath) + "\">" + data.FileName + "</a>" +
        //                        "<input name='" + dataObj.fileName + "' class='fileNames' type='hidden' value='" + data.FileName + "' />" +
        //                        "<input name='" + dataObj.filePath + "' class='filePaths' type='hidden' value='" + data.FilePath + "'/>" +
        //                        "<button type='button' class='btn btn-xs btn-link close delMember'>x</button>" +
        //                        "</span>"
        //                    );
        //                }
        //            }
        //        });
        //    }
        //});

        //container.find(".inputUpFiles").each(function () {
        //    var obj = jQuery(this);
        //    if (!obj.hasClass("setUpFiled")) {
        //        obj.hasClass("setUpFiled");
        //        obj.ajaxUploader({
        //            name: "FileDocument",
        //            postUrl: "/uploader/upfile",
        //            //elTarget: obj.attr("data-target"),
        //            onBegin: function (e, elTarget) {
        //                return true;
        //            },
        //            onClientLoadStart: function (e, file, t) {

        //            },
        //            onClientProgress: function (e, file) {
        //                UpfilePage.onProgress(e, file);
        //            },
        //            onServerProgress: function (e, file, t) {
        //                UpfilePage.onProgress(e, file);
        //            },
        //            onClientAbort: function (e, file) {
        //                UpfilePage.onAbort(e, file);
        //            },
        //            onClientError: function (e, file) {
        //                UpfilePage.onAbort(e, file);
        //            },
        //            onServerAbort: function (e, file, t) {
        //                UpfilePage.onAbort(e, file);
        //            },
        //            onServerError: function (e, file, t) {
        //                UpfilePage.onAbort(e, file);
        //            },
        //            onSuccess: function (e, file, t, data) {

        //            }
        //        });
        //    }
        //});
        //container.find("#InputAvatar").each(function () {
        //    var obj = jQuery(this);
        //    if (!obj.hasClass("setUpFiled")) {
        //        obj.ajaxUploader({
        //            name: "FileDocument",
        //            dragBox: "#AvatarDrager",
        //            postUrl: "/uploader/upfile",
        //            onBegin: function () {
        //                jQuery("#AvatarDrager").addClass("loading");
        //                return true;
        //            },
        //            onChange: function () {
        //                return true;
        //            },
        //            onDrop: function () {
        //                return true;
        //            },
        //            onClientLoadStart: function () {
        //            },
        //            onClientProgress: function () {
        //            },
        //            onClientAbort: function () {
        //                jQuery("#AvatarDrager").removeClass("loading");
        //            },
        //            onClientError: function () {
        //                jQuery("#AvatarDrager").removeClass("loading");
        //            },
        //            onSuccess: function (e, file, dragbox, data) {
        //                var html = "";
        //                var thumbPath = "/thumb/120xauto/" + data.FilePath;
        //                var avatarUrl = thumbPath + "?" + (new Date).getTime();
        //                html += "<a class='imgavt'>";
        //                html += "<img id='ImageAvatar' src='" + avatarUrl + "' />";
        //                html += "</a>";
        //                html += "<input type='hidden' name='Avatar' value='" + thumbPath + "' />";

        //                jQuery("#AvatarDrager").removeClass("loading");
        //                jQuery("#AvatarDrager").html(html);
        //                jQuery("#ImageAvatar").load(function () {
        //                    AvatarPage.initCrop();
        //                });
        //            }
        //        });
        //    }
        //});
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
        var rowId = UpfilePage.getRowId(file.id, true);
        jQuery(rowId).find(".progress-bar").css("width", pc + "%");
        jQuery(rowId).find(".progress-label").text(pc + "%");
    },
    onAbort: function (e, file) {
        jQuery(UpfilePage.getRowId(file.id, true))
            .find(".upStatus")
            .html("<a href='#' class='loadfail' title='Tải tài liệu lên không thành công' ></a>");
    },
    getRowId: function (fileId, isSelector) {
        return (isSelector ? "#" : "") + "DocUploadR" + fileId;
    }
};
jQuery(document).ready(function () {
    UpfilePage.init();
})