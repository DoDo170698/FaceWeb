var QLNS = {
    init: function () {
        QLNS.onEvent();
        QLNS.upEVent();
    },
    onEvent: function (container) {

        $(document).on("change", ".selected_change", function () {
            var select = $(this);
            var id = select.val();
            var url = select.attr("data-url");
            var target = $(select.attr("data-target"));
            var idCustomer = select.closest("form").find('select[name="IDCustomer"]').val();
            if (isExist(target, id, $("#messeage_err"))) {
                return false;
            }
            var temp = $(select.attr("data-temp")).html();
            var ms = new Date().getMilliseconds();
            target.append(temp);
            var deleteItem = target.find("tr:last td a.deleteItem.check");
            deleteItem.attr("data-val", id);
            deleteItem.attr("data-target-change", "#productContainer");
            target.find("tr:last").attr("data-id", "tr_" + ms);
            target.find("tr:last").attr("id", "tr_" + select.val());
            try {

                jQuery.ajax({
                    type: "POST",
                    async: true,
                    url: url,
                    data: {
                        id: id,
                        trTarget: "tr_" + ms,
                        idCustomer: idCustomer
                    },
                    beforeSend: function () {
                    },
                    complete: function () {
                    },
                    error: function () {
                    },
                    success: function (response) {
                        if (!response.isCustom) {
                            alert("Lỗi");
                            return false;
                        }
                        var datas = response.data;
                        var tr = $(document).find("tr[data-id='" + response.trTarget + "']");
                        for (var key in datas) {
                            var val = datas[key];
                            var input = tr.find("td div input[name='" + key + "']");
                            if (input.hasClass("moneyFormat"))
                                val = val.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
                            input.val(val);
                        }
                    }
                });
            } catch (e) {
                console.log(e);
            }

            return false;
        });
        $(document).on("change", ".selected_customer_change", function () {
            var select = $(this);
            var id = select.val();
            var url = select.attr("data-url");
            var target = select.attr("data-target");
            try {

                jQuery.ajax({
                    type: "POST",
                    async: true,
                    url: url,
                    data: {
                        id: id,
                        target: target
                    },
                    beforeSend: function () {
                    },
                    complete: function () {
                    },
                    error: function () {
                    },
                    success: function (response) {
                        if (!response.isCustom) {
                            alert("Lỗi");
                            return false;
                        }
                        var datas = response.data;
                        var target = $(response.target);
                        var ctProducts = response.ctProducts;
                        for (var key in datas) {
                            var val = datas[key];
                            var input = target.find("input[name='" + key + "']");
                            input.val(val);
                        }
                        if (!Utils.isEmpty(ctProducts)) {
                            for (var i = 0; i < ctProducts.length; i++) {
                                var trProduct = $(ctProducts[i].IDTr);
                                if (trProduct.length >0 ) {
                                    var inputPrice = trProduct.find("td div input[name='ProductPrice']");
                                    inputPrice.val(ctProducts[i].Price);
                                    inputPrice.trigger("change");
                                }
                            }
                        }
                    }
                });
            } catch (e) {
                console.log(e);
            }

            return false;
        });
        $(document).on("change", ".calTotal", function () {
            var current = $(this);
            var amount = parseFloat(current.closest("tr").find('input[name="ProductAmount"]').val().replaceAll(",", ""));
            amount = isNaN(amount) ? 0 : amount;
            var total = $(current.closest("tr").find('input[name="Total"]'));
            var price = parseFloat(current.closest("tr").find('input[name="ProductPrice"]').val().replaceAll(",", ""));
            price = isNaN(price) ? 0 : price;
            var promotion = parseFloat(current.closest("tr").find('input[name="ProductPromotion"]').val().replaceAll(",", ""));
            promotion = isNaN(promotion) ? 0 : promotion;
            total.val(Math.round(price * amount - price * promotion * amount / 100).toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));

            var orderTotal = $("#valueOrder");
            var value = 0;
            $("#productContainer").find("input[name='Total']").each(function () {
                var val = parseFloat($(this).val().replaceAll(",", ""));
                value += Math.round(val);
            });
            orderTotal.html(value.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") + " VNĐ");
            orderTotal.next().attr("value", value);
        });
        $(document).on("change", ".customer_select_change", function () {
            var select = $(this);
            var id = select.val();
            var url = select.attr("data-url");
            var target = select.attr("data-target");
            var quater = $(select.attr("data-quater")).val();
            var year = $(select.attr("data-year")).val();
            var type = $(select.attr("data-type")).val();
            try {

                jQuery.ajax({
                    type: "POST",
                    async: true,
                    url: url,
                    data: {
                        IDCustomer: id,
                        Quater: quater,
                        Year: year,
                        Type: type
                    },
                    beforeSend: function () {
                    },
                    complete: function () {
                    },
                    error: function () {
                    },
                    success: function (response) {
                        $(target).html(response.custHTML);
                        if (!Utils.isEmpty(response.addRes)) {
                            var addRes = response.addRes;
                            var total = addRes.Total;
                            var idTotal = addRes.IDTotal;
                            //var idRealTotal = addRes.IDRealTotal;
                            var inputValue = addRes.InputValue;
                            var detailOrder = addRes.DetailOrder;
                            $(detailOrder).attr("data-value", total);
                            $(idTotal).val(total.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
                            $(".cal_OrderDiscount").trigger("click");
                        }
                    }
                });
            } catch (e) {
                console.log(e);
            }

            return false;
        });
        $(document).on("change", ".trigger_customer_select_change", function () {
            try {
                var object = $(this);
                var target = $(object.attr("data-target"));
                target.trigger("change");
            } catch (e) {
                return false;
            }

        });
        $(document).on("click", ".cal_OrderDiscount", function () {
            var obj = $(this);
            var obj_discount = $(obj.attr("data-discount"));
            var obj_event = $(obj.attr("data-event"));
            var obj_total = $(obj.attr("data-total"));
            var obj_realTotal = $(obj.attr("data-real-total"));
            var discount = Number(obj_discount.val());
            var event = Number(obj_event.val().replaceAll(",", ""));
            var total = Number(obj_total.val().replaceAll(",", ""));
            var realTotal = total - event - (total * discount / 100);//total - event - ;
            obj_total.val(total.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
            obj_realTotal.val(realTotal.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
        });
        $(document).on("change", ".trigger_cal_OrderDiscount", function () {
            $(".cal_OrderDiscount").trigger("click");
        });

    },
    upEVent: function () {
    },
    onAutoResize: function () {
        $("#checkIn_Table.large-only").find("tr.employeeInfo").each(function () {
            var employHeight = jQuery(this).height();
            var tableInner = $(this).find(".large-only");
            var sumHeght = 0;
            var count = 0;
            var trInner = tableInner.find("tr.checkInRow");
            trInner.each(function () {
                count = jQuery(this).attr('data-count');
                var tdHeight = jQuery(this).height();
                sumHeght = sumHeght + tdHeight;
            });
            if (sumHeght < employHeight) {
                tableInner.closest("div").css('max-height', employHeight + 'px');
                var height = employHeight / count;
                trInner.each(function () {
                    jQuery(this).css('height', height + 'px');
                });
            }
        });
    },
};
jQuery(document).ready(function () {
    QLNS.init();
    $(".down-file-ajax").click(function () {
        var obj = $(this);
        var url = obj.attr("data-url");
        try {

            jQuery.ajax({
                type: "POST",
                async: true,
                url: url,
                data: {
                },
                beforeSend: function () {
                },
                complete: function () {
                },
                error: function () {
                },
                success: function (response) {
                    if (Utils.isEmpty(response.FullPath)) {
                        alert("Không tồn tại file");
                        return;
                    };
                    window.open(response.FullPath);
                }
            });
        } catch (e) {
            console.log(e);
        }
    });
});

function isExist(target, val, mess) {

    var check = false;
    var valueCheck = target.attr("data-value");
    var arrays = JSON.parse(valueCheck);
    if (Utils.isEmpty(arrays) || arrays.length <= 0) {
        $(mess).addClass("hidden");
        mess.html("");
        arrays.push(val);
        check = false;
    } else {
        for (var i = 0; i < arrays.length; i++) {
            if (parseInt(val) == parseInt(arrays[i])) {
                check = true;
            }
        }
        if (check) {
            mess.removeClass("hidden");
            mess.html(mess.attr("data-message"));
        } else {
            $(mess).addClass("hidden");
            mess.html("");
            arrays.push(val);
            check = false;
        }
    }
    target.attr("data-value", JSON.stringify(arrays));
    return check;
};

