var Autocomplete = {

    init: function (container) {
        Autocomplete.category(container);
        Autocomplete.customer(container);
        Autocomplete.customerType(container);
        Autocomplete.supplier(container);
    },
    customer: function (container) {
        container.find(".autocompleteCustomer").each(function () {
            if (!jQuery(this).hasClass("inited")) {
                var obj = jQuery(this);
                obj.addClass("inited");
                var isShowAll = obj.attr("data-show-all");
                obj.autocomplete({
                    appendTo: "body",
                    source: function (req, res) {
                        jQuery.ajax({
                            type: "POST",
                            async: true,
                            data: { Term: req.term, IsShowAll: isShowAll },
                            url: "/autocomplete/customer",
                            success: function (response) {
                                Autocomplete._source(res, response);
                            }
                        });
                    },
                    open: function (event, ui) {
                        Autocomplete._open(event, ui);
                    },
                    change: function (event, ui) {
                        if (obj.hasClass("useTrigger")) {
                            obj.trigger("change");
                        }
                    },
                    delay: 0,
                    autoFocus: true,
                    minLength: 0,
                    select: function (a, b) {

                        return Autocomplete._selectCustomer(a, b, jQuery(this));

                    },
                }).click(function () {
                    jQuery(this).autocomplete("search", "");
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    return Autocomplete._renderItem(ul, item, jQuery(this.element));
                };
            }
        });
    },
    customerType: function (container) {
        container.find(".autocompleteCustomerType").each(function () {
            if (!jQuery(this).hasClass("inited")) {
                var obj = jQuery(this);
                obj.addClass("inited");
                var isShowAll = obj.attr("data-show-all");
                obj.autocomplete({
                    appendTo: "body",
                    source: function (req, res) {
                        jQuery.ajax({
                            type: "POST",
                            async: true,
                            data: { Term: req.term, IsShowAll: isShowAll },
                            url: "/autocomplete/CustomerType",
                            success: function (response) {
                                Autocomplete._source(res, response);
                            }
                        });
                    },
                    open: function (event, ui) {
                        Autocomplete._open(event, ui);
                    },
                    change: function (event, ui) {
                        if (obj.hasClass("useTrigger")) {
                            obj.trigger("change");
                        }
                    },
                    delay: 0,
                    autoFocus: true,
                    minLength: 0,
                    select: function (a, b) {

                        return Autocomplete._selectCustomer(a, b, jQuery(this));

                    },
                }).click(function () {
                    jQuery(this).autocomplete("search", "");
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    return Autocomplete._renderItem(ul, item, jQuery(this.element));
                };
            }
        });
    },
    supplier: function (container) {
        container.find(".autocompleteSupplier").each(function () {
            if (!jQuery(this).hasClass("inited")) {
                var obj = jQuery(this);
                obj.addClass("inited");
                var isShowAll = obj.attr("data-show-all");
                obj.autocomplete({
                    appendTo: "body",
                    source: function (req, res) {
                        jQuery.ajax({
                            type: "POST",
                            async: true,
                            data: { Term: req.term, IsShowAll: isShowAll },
                            url: "/autocomplete/Supplier",
                            success: function (response) {
                                Autocomplete._source(res, response);
                            }
                        });
                    },
                    open: function (event, ui) {
                        Autocomplete._open(event, ui);
                    },
                    change: function (event, ui) {
                        if (obj.hasClass("useTrigger")) {
                            obj.trigger("change");
                        }
                    },
                    delay: 0,
                    autoFocus: true,
                    minLength: 0,
                    select: function (a, b) {
                        return Autocomplete._selectItem(a, b, jQuery(this));
                    },
                }).click(function () {
                    jQuery(this).autocomplete("search", "");
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    return Autocomplete._renderItem(ul, item, jQuery(this.element));
                };
            }
        });
    },
    category: function (container) {

        container.find(".autocompleteCategory").each(function () {
            if (!jQuery(this).hasClass("inited")) {
                var obj = jQuery(this);
                obj.addClass("inited");
                obj.autocomplete({
                    appendTo: "body",
                    source: function (req, res) {
                        jQuery.ajax({
                            type: "POST",
                            async: true,
                            data: { Term: req.term, Type: obj.attr("data-type"), Parent: obj.attr("data-parent"), IDNotIn: obj.attr("data-id-not-id") },
                            url: "/autocomplete/category",
                            success: function (response) {
                                Autocomplete._source(res, response);
                            }
                        });
                    },
                    open: function (event, ui) {
                        Autocomplete._open(event, ui);
                    },
                    select: function (a, b) {
                        return Autocomplete._selectItem(a, b, jQuery(this));
                    },
                    delay: 350,
                    minLength: 0
                }).click(function () {
                    jQuery(this).autocomplete("search", "");
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    return Autocomplete._renderItem(ul, item, jQuery(this.element));
                };
            }
        });
    },
    seller: function (container) {

        container.find(".autocompleteSeller").each(function () {
            if (!jQuery(this).hasClass("inited")) {
                var obj = jQuery(this);
                obj.addClass("inited");
                obj.autocomplete({
                    appendTo: "body",
                    source: function (req, res) {
                        jQuery.ajax({
                            type: "POST",
                            async: true,
                            data: { Term: req.term, IDNotIn: obj.attr("data-id-not-in") },
                            url: Utils.getDomain() + "/" + Cdata.VirtualPath + "/autocomplete/seller.html",
                            success: function (response) {
                                Autocomplete._source(res, response);
                            }
                        });
                    },
                    open: function (event, ui) {
                        Autocomplete._open(event, ui);
                    },
                    select: function (a, b) {
                        return Autocomplete._selectItem(a, b, jQuery(this));
                    },
                    delay: 350,
                    minLength: 0
                }).click(function () {
                    jQuery(this).autocomplete("search", "");
                }).autocomplete("instance")._renderItem = function (ul, item) {
                    return Autocomplete._renderItem(ul, item, jQuery(this.element));
                };
            }
        });
    },
    _source: function (res, response) {
        if (Utils.notEmpty(response.data)) {
            var items = [];
            for (var i in response.data) {
                var item = response.data[i];
                var itemA = {
                    value: item.Name,
                    label: item.Name,
                    id: item.ID,
                    desc: ""
                };
                if (typeof item.Parents != "undefined")
                    itemA.desc = item.Parents;

                items.push(itemA);
            }
            res(items);
        } else {
            Utils.sectionBuilder(response);
            res();
        }
    },
    _open: function (event, ui) {
        var $input = jQuery(event.target),
            $results = $input.autocomplete("widget"),
            top = $input.offset().top,
            height = $results.css({ height: "auto" }).height(),
            inputHeight = $input.height(),
            bodyHeight = jQuery('body').height();
        if ((top + height + inputHeight) > bodyHeight) {
            var h = (bodyHeight - top + inputHeight - 50);
            if (h > 150)
                $results.css({ height: h + "px" });
        }
    },
    _selectItem: function (a, b, el) {
        var name = el.attr("data-name");
        var target = el.attr("data-target");
        var targetId = el.attr("data-targetid");
        var selectTarget = el.attr("data-select-target");
        var selectUrl = el.attr("data-select-url");
        if (!Utils.isEmpty(targetId)) {
            jQuery(targetId).attr("value",b.item.id);
            setTimeout(function () {
                try {
                    var form = el.closest("form");
                    if (form.hasClass("bootstrapValidator")) {
                        form.bootstrapValidator('revalidateField', el.attr("name"));
                    }
                } catch (e) { }
            }, 300);
        }
        if (!Utils.isEmpty(selectTarget)) {
            jQuery.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: true,
                url: selectUrl,
                data: JSON.stringify({
                    'id': b.item.id,
                }),
                dataType: "json",
                success: function (data) {
                    Utils.destroyValidator(jQuery(selectTarget));
                    if (data.hasOwnProperty("isCust")) {
                        jQuery(selectTarget).html(data.htCust);
                    }
                    Utils.bootstrapValidator(jQuery(selectTarget));
                    Utils.autoResize();
                    Main.upEvent();

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
        if (!Utils.isEmpty(target)) {
            var col = 12;
            var shareSetting = "";
            if (jQuery(target).hasClass("shareItems")) {
                col = 3;
                var data = jQuery(target).getDataUppername();
                shareSetting = '<div class="col-sm-9">' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input checked type="checkbox" value="1" class="colored-success tickItem" name="View' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelView + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Update' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelUpdate + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Delete' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelDelete + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Create' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelCreate + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Copy' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelCopy + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Download' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelDownload + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Move' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelMove + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickItem" name="Share' + name + b.item.id + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + data.LabelShare + '</span>' +
                    '</label>' +
                    '</div>' +
                    '<div class="checkbox col-sm-2 nopadlr">' +
                    '<label>' +
                    '<input type="checkbox" value="1" class="colored-success tickAll">' +
                    '<span class="nowrap text">' + data.LabelAll + '</span>' +
                    '</label>' +
                    '</div>' +
                    '</div>';
            }
            var item = jQuery(target).find(".scrollItem[data-id='" + b.item.id + "']");
            if (item.length == 0) {
                item = '<div class="scrollItem tickGroup" data-id="' + b.item.id + '" style="display: none">' +
                    '<div class="col-sm-' + col + '">' +
                    '<div class="checkbox">' +
                    '<label>' +
                    '<input checked type="checkbox" value="' + b.item.id + '" class="colored-success tickKey" name="' + name + '" id="Rand' + (new Date()).getTime() + '">' +
                    '<span class="nowrap text">' + b.item.label + '</span>' +
                    '</label>' +
                    '</div>' +
                    '</div>' +
                    shareSetting +
                    '</div>';
            }
            else {
                item.css('display', 'none').find("input[type='checkbox']").prop("checked", true);
            }
            jQuery(target).prepend(jQuery(item).fadeIn("1000"));

            jQuery(this).val("");
            return false;
        }

        return true;
    },
    _selectCustomer: function (a, b, el) {
        var name = el.attr("data-name");
        var target = el.attr("data-target");
        var targetId = el.attr("data-targetid");
        var selectUrl = el.attr("data-select-url");
        var autoFill = !el.hasClass("notAutoFill");

        var selectTarget = el.attr("data-select-target");
        var autocompleteUrl = el.attr("data-autocomplete-url");
        if (autocompleteUrl == undefined)
            autocompleteUrl = Utils.getDomain() + "/" + Cdata.VirtualPath + "/customer/getbyid.html";


        if (!Utils.isEmpty(targetId)) {

            if (!jQuery(targetId).hasClass("nofill")) {
                jQuery(targetId).val(b.item.id);
            }
            jQuery.ajax({
                type: "POST",
                async: true,
                data: { id: b.item.id },
                url: autocompleteUrl,
                success: function (response) {
                    if (!Utils.isEmpty(response) && autoFill) {
                        var form = el.closest("form");
                        for (var k in response) {
                            var mySelect = $('select[name="' + k + '"]');
                            var textarea = $('textarea[name="' + k + '"]');
                            if (mySelect.hasClass("nofill"))
                                continue;
                            if (textarea.hasClass("nofill"))
                                continue;
                            if (mySelect != undefined && mySelect.length != 0) {
                                if (response[k] === 0) {
                                    if (mySelect.find("option[value='0']").length > 0) {
                                        mySelect.val(0);

                                    } else
                                        mySelect.val("");
                                } else {
                                    var child = mySelect.attr("data-child-name");
                                    mySelect.val(response[k]);
                                    if (mySelect.hasClass("useTrigger")) {
                                        if (child != undefined)
                                            mySelect.attr("data-selected", response[child]);
                                        mySelect.trigger("change");
                                    }
                                }
                            }

                            else if (textarea != undefined && textarea.length != 0) {
                                textarea.val(response[k]);
                            }
                            else {
                                var name = "input[name='" + k + "']";
                                var input = form.find(name).filter(':input:visible:first');
                                if (input.hasClass("nofill"))
                                    continue;
                                if (k.indexOf("Date") != -1) {
                                    var jsonDate = new Date(parseInt(response[k].replace('/Date(', '')));
                                    var date = jsonDate.getDate() + "-" + (jsonDate.getMonth() + 1) + "-" + jsonDate.getFullYear();
                                    input.val(date);
                                }
                                else {
                                    input.val(response[k]);
                                }
                                if (input.hasClass("useTrigger")) {
                                    input.trigger("change");
                                }
                            }
                        }
                        form.find("select.autoSelect2").each(function () {
                            $(this).select2();
                        })

                        Utils.resetValidator(form);
                        return true;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
        if (!Utils.isEmpty(selectTarget)) {
            jQuery.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                async: true,
                url: selectUrl,
                data: JSON.stringify({
                    'id': b.item.id,
                }),
                dataType: "json",
                success: function (data) {
                    Utils.destroyValidator(jQuery(selectTarget));
                    if (data.hasOwnProperty("isCust")) {
                        el.closest("form").find(selectTarget).html(data.htCust);
                    }
                    Utils.bootstrapValidator(jQuery(selectTarget));
                    Utils.autoResize();
                    Main.upEvent();

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
    },
    _renderItem: function (ul, item, el) {
        return jQuery("<li class='itemf' style='width: " + el.width() + "px'>")
            .append("<div><a title='" + item.label + "'>" + item.label + "</a></div><div class='detail' title='" + item.desc + "'>" + item.desc + "</div>")
            .appendTo(ul);
    },
};