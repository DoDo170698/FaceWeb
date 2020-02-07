var CustomTree = {

    init: function () {
        CustomTree.onEvent();
        //CustomTree.initTree(jQuery(document));
    },
    onEvent: function ()
    {
        jQuery(document).on("click", '.organizational-chart div', function () {
            if (jQuery(this).next("ol").is(":visible"))
            {
                jQuery(this).next("ol").slideUp("fast");
                jQuery(this).find(".fa").toggleClass("fa-folder fa-folder-open");
            }
            else
            {
                jQuery(this).parent().parent().find("li > ol").slideUp("fast");
                jQuery(this).parent().parent().find("li > div > h3 > .fa").removeClass("fa-folder-open");
                jQuery(this).parent().parent().find("li > div > h3 > .fa").addClass("fa-folder");
                jQuery(this).next("ol").slideDown("fast");
                jQuery(this).find(".fa").toggleClass("fa-folder fa-folder-open");



            }
        });
        jQuery(document).on("click", ".useTree .fa-caret-right", function () {
            var obj = jQuery(this);
            var faFolder = obj.find(".fa-folder");
            var treeFolder = obj.closest(".tree-folder");
            var treeFolderContent = treeFolder.find(".tree-folder-content").first();

            var tree = obj.closest(".useTree");
            tree.find(".tree-folder-name.active").removeClass("active");
            var nodeActive = obj.closest(".tree-folder-header").find(".tree-folder-name").first();
                nodeActive.addClass("active");

            var dataNode = nodeActive.getDataUppername();
            if (typeof dataNode.Selector != "undefined" && !Utils.isEmpty(dataNode.Selector)) {
                jQuery(dataNode.Selector).val(dataNode.ID);
            }

            if (treeFolderContent.length != 0)
            {
                treeFolderContent.slideDown(100);
                faFolder.removeClass("fa-folder").addClass("fa-folder-open");
                obj.removeClass("fa-caret-right").addClass("fa-caret-down");
            }
            else
            {
                var data = obj.getDataUppername();
                if (data.Url.replace("#", "").length == 0) {
                    return;
                }
                jQuery.ajax({
                    type: "POST",
                    async: true,
                    url: data.Url,
                    data: data,
                    beforeSend: function () {
                        faFolder.removeClass("fa-folder").addClass("fa-folder-open loading-inline");
                    },
                    complete: function () {
                        faFolder.removeClass("loading-inline");
                        obj.removeClass("fa-caret-right").addClass("fa-caret-down");
                    },
                    error: function () {
                        faFolder.removeClass("loading-inline");
                    },
                    success: function (response) {

                        Utils.sectionBuilder(response);
                        if (response.hasOwnProperty("isCust")) {
                            treeFolder.append(response.htCust);
                        }
                        if (typeof data.Sortable != "undefined") {
                            treeFolder.find(".fa-caret-right").attr("data-sortname", data.Sortable);
                        }
                        if (typeof data.Deep != 'undefined' && data.Deep == "1") {
                            obj.attr("data-deep", 0);
                            setTimeout(function () {
                                treeFolder.find(".fa-caret-right")
                                .first()
                                .attr("data-dept", 0)
                                .trigger("click");
                            }, 50);
                        }
                        Utils.updateScrollBar(treeFolder.closest(".treeViewer"));
                    }
                });
            }
        });
        jQuery(document).on("click", ".useTree .fa-caret-down", function () {
            var obj = jQuery(this);
            var faFolder = obj.find(".fa-folder-open");
            var treeFolder = obj.closest(".tree-folder");
            faFolder.removeClass("fa-folder-open").addClass("fa-folder");
            treeFolder.find(".tree-folder-content").first().slideUp(100);
            treeFolder.find(".tree-loader").removeClass("none");
            obj.removeClass("fa-caret-down").addClass("fa-caret-right");


            var tree = obj.closest(".useTree");
            tree.find(".tree-folder-name.active").removeClass("active");
            var nodeActive = obj.closest(".tree-folder-header").find(".tree-folder-name").first();
                nodeActive.addClass("active");

            var dataNode = nodeActive.getDataUppername();
            if (typeof dataNode.Selector != "undefined" && !Utils.isEmpty(dataNode.Selector)) {
                jQuery(dataNode.Selector).val(dataNode.ID);
            }
        });
        jQuery(document).on("click", ".useTree .tree-folder-name", function () {
            var tree = jQuery(this).closest(".useTree");
                tree.find(".tree-folder-name.active").removeClass("active");

            var data = jQuery(this).getDataUppername();
            if (typeof data.Selector != "undefined" && !Utils.isEmpty(data.Selector)) {
                jQuery(data.Selector).val(data.ID);
            }
            jQuery(this).addClass("active");
        });
        jQuery(document).on("click", ".btnChoisedFolder", function () {
            var data = jQuery(this).getDataUppername();
            var treeContainer = jQuery(this).closest(".tree-container");
            var tree = treeContainer.find(".tree");
            var folderSelected = tree.find(".active");
            if (folderSelected.length == 0)
            {
                alert(data.MessageNotSelected);
                return false;
            }
            else if (!folderSelected.hasClass("isCreate")) {
                alert(data.MessageNotCreate.replace("{foldername}", folderSelected.attr("data-name")));
                return false;
            }
            else if (folderSelected.hasClass("current")) {
                alert(data.MessageNotChange.replace("{foldername}", folderSelected.attr("data-name")));
                return false;
            }
            else {
                var rel = jQuery(data.Rel);
                var relData = rel.getDataUppername();
                var folderData = folderSelected.getDataUppername();

                rel.val(folderData.Name);
                jQuery(relData.Targetid).val(folderData.ID);
            }
            Utils.closeCDialog(jQuery(this), true);
        });
    },

    initTree: function (container) {

        container.find(".treeViewer").each(function () {
            var obj = jQuery(this);
            var data = obj.getDataUppername();
            jQuery.ajax({
                type: "POST",
                async: true,
                url: data.Url,
                data: data,
                beforeSend: function () {
                    obj.addClass("loading-inline");
                },
                complete: function () {
                    obj.removeClass("loading-inline");
                },
                error: function () {
                    obj.removeClass("loading-inline");
                },
                success: function (response) {
                    Utils.sectionBuilder(response);
                    if (response.hasOwnProperty("isCust")) {
                        obj.append(response.htCust);
                    }
                    Utils.updateScrollBar(obj);

                    if (typeof data.Sortable != "undefined") {
                        obj.find(".fa-caret-right").attr("data-sortname", data.Sortable);
                    }
                    if (typeof data.Deep != 'undefined' && data.Deep == "1") {
                        obj.attr("data-deep", 0)
                            .find(".fa-caret-right")
                            .first()
                            .attr("data-deep", 1)
                            .trigger("click");
                    }
                }
            });
        });

        container.find(".treeStatic").tree({
            dataSource: {
                data: function () {

                },
                delay: 400
            }
        });
    },
};
jQuery(document).ready(function () {
    CustomTree.init();
});