	//function rule_check() {
	//	if($(".scrollItem_item").is(":visible")){
	//		var item_length = 0;
	//		var item_ckecked = 0;
	//		$(".scrollItem_item").each(function () {
	//			item_length = $(this).find(".scrollItem").length;
	//			item_ckecked = $(this).find('.colored-success:checkbox:checked').length;
	//			if(parseInt(item_length)>0){
	//				if( parseInt(item_ckecked) == 0){
	//					$(this).find(".scrollItem_item_title").find(".fa_some").addClass("hidden");
	//					$(this).find(".scrollItem_item_title").find(".fa_all").addClass("hidden");
	//				}else if(parseInt(item_ckecked) == parseInt(item_length) ){
	//					$(this).find(".scrollItem_item_title").find(".fa_some").addClass("hidden");
	//					$(this).find(".scrollItem_item_title").find(".fa_all").removeClass("hidden");
	//				}else{
	//					$(this).find(".scrollItem_item_title").find(".fa_some").removeClass("hidden");
	//					$(this).find(".scrollItem_item_title").find(".fa_all").addClass("hidden");
	//				}
	//			}
	//		});
	//	}
	//}
	//rule_check();
	//Phân quyền
	jQuery(document).on("click", ".scrollItem_item_title", function () {
		if($(this).parents(".scrollItem_item").find('.scrollItem_content').is(":visible")){
			$(this).parents(".scrollItem_item").find('.scrollItem_content').slideUp();
		}else{
			$(this).parents(".scrollItem_item").find('.scrollItem_content').slideDown();
		}
        $(this).parents(".scrollItem_item").toggleClass("open");
        $(this).find(".fa_left").toggleClass('fa-caret-right fa-caret-down');
        rule_check();
	});
	jQuery(document).on("click", ".scrollItem_content .checkbox .colored-success", function () {
		rule_check();
	});
	jQuery(document).on("click", ".ui-dialog .ui-dialog-titlebar-close", function () {
		$(".scrollItem_item_title").find(".fa_some").addClass("hidden");
		$(".scrollItem_item_title").find(".fa_all").addClass("hidden");
	});
    var Cust = {
        dataTables_filter_col: function() {
        //Fix col sm as col md
            if($('.dataTables_filter > .quickSearch > div[class*="col"').is(":visible")){
                jQuery(document).find('.dataTables_filter > .quickSearch div[class*="col"').each(function(){
                    var obj = $(this);
                    var arr = obj.attr('class').split(' ');
                    for(var i=0; i<arr.length; i++){
                        var class_sm = arr[i];
                        var col_sm = 'col-sm-';
                        if(class_sm.indexOf(col_sm) !== -1){
                            obj.removeClass(class_sm);
                        }
                    }
                    for(var j=0; j<arr.length; j++){
                        var class_md = arr[j];
                        var col_md = 'col-md-';
                        if(class_md.indexOf(col_md) !== -1){
                            var res = class_md.replace("md", "sm");
                            obj.addClass(res);
                        }
                    }

                });
            }
        },
        check_required_input: function() {
            jQuery(document).find(".form-control").each(function(){
                var attr = $(this).attr('data-bv-notempty');
                if (typeof attr !== typeof undefined && attr !== false && attr==='true') {
                    if(jQuery(this).parent().prev("label").is(":visible") && (jQuery(this).parent().prev("label").find(".red").size() === 0)){
                        var label_text = jQuery(this).parent().prev("label").html();
                        jQuery(this).parent().prev("label").html(label_text+' <span class="red">*</span>');
                    }
                }
            });
        },
    	 fileViewer_height_fn: function() {
    	    if($("#FileViewer").is(":visible")){
    	        if($(window).width() > 991){
    	            //fix FileViewer height
    	            $("#FileViewer").css("height", "auto");
    	            $("#FileViewer #outerContainer").css("height",  "auto");
    	            $("#FileViewer .group-tab .tab-data").css("height",  "auto");
    	            var window_height = $(window).outerHeight(true);
                    var navbar_height = 0;
                    if($(".header_banner").is(":visible")){
                        navbar_height = $(".navbar").outerHeight(true) + $(".header_banner").outerHeight(true);
                    }else{
                        navbar_height = $(".navbar").outerHeight(true);
                    }
    	            var breadcrumbs_height = $(".page-breadcrumbs").outerHeight(true);
    	            var file_button_action_height = $("#FileViewer .file_button_action").outerHeight(true);
    	            var toolbarViewer_Scanfile_height = $("#FileViewer .toolbarViewer_Scanfile").outerHeight(true);
    	            var label_group_tab_custom_height = $("#FileViewer .label_group_tab_custom").outerHeight(true);
    	            var fileViewer_height = window_height - (navbar_height + breadcrumbs_height+2);
    	            var outerContainer_height = fileViewer_height - (file_button_action_height+2);
    	            var items_Scan_height  = fileViewer_height - (toolbarViewer_Scanfile_height+2);
    	            var tab_data_height = fileViewer_height - (label_group_tab_custom_height+2);
    	            var sidebar_menu_height = window_height - (navbar_height +2);
    	            var outerContainer_height_i = "height: "+outerContainer_height+"px !important";
    	            $("#FileViewer").css("height", fileViewer_height);
    	            $("#FileViewer .secrtc2 .widget").css("height", fileViewer_height);
    	            $("#FileViewer .secrtc1 .ScanResult").css("height", fileViewer_height);
    	            $("#FileViewer .secrtc1 .ScanResult .items_Scan").css("height", items_Scan_height);
    	            $("#FileViewer #outerContainer").css("height", outerContainer_height);
    	            $("#FileViewer #DocProIMGMap").attr('style', outerContainer_height_i);
    	            $("#FileViewer .doc-viewer").attr('style', outerContainer_height_i);
    	            $("#FileViewer .group-tab .tab-data").css("height", tab_data_height);
    	            $(".page-sidebar .sidebar-menu").css("height", sidebar_menu_height);
    	        }else{
    	            $("#FileViewer").css("height", "auto");
    	            $("#FileViewer .secrtc2 .widget").css("height", fileViewer_height);
    	            $("#FileViewer .secrtc1 .ScanResult").css("height", fileViewer_height);
    	            $("#FileViewer .secrtc1 .ScanResult .items_Scan").css("height", items_Scan_height);
    	            $("#FileViewer #outerContainer").css("height",  outerContainer_height);
    	            $("#FileViewer #DocProIMGMap").attr('style', outerContainer_height_i);
    	            $("#FileViewer .doc-viewer").attr('style', outerContainer_height_i);
    	            $("#FileViewer .group-tab .tab-data").css("height",  "auto");
    	            $(".page-sidebar .sidebar-menu").css("height","auto");
    	        }
    	    }

    	},
         newsfeedimg: function() {
            // NewsFeed image grid
             $(".timeline-body").each(function () {
                if ($(this).find(".card-image").is(":visible")) {
                    var NewsFeed_Image_Count = $(this).find(".card-image").length;
                    //alert(NewsFeed_Image_Count);
                    if(parseInt(NewsFeed_Image_Count) > 2){
                        $(this).find(".card-image").addClass("multi_card_img");
                        $(this).find(".card-image").addClass("hidden");
                        $(this).find(".card-image:eq(0)").removeClass("hidden");
                        $(this).find(".card-image:eq(1)").removeClass("hidden").addClass("equal_height");
                        $(this).find(".card-image:eq(2)").removeClass("hidden").addClass("equal_height");
                        var temp_img_heights = 0;
                        $(this).find(".card-image.equal_height img").each(function () {
                            var temp_img_height = jQuery(this).height();
                            if (parseInt(temp_img_height) > parseInt(temp_img_heights)) {
                                temp_img_heights = temp_img_height;
                            }
                        });
                        $(this).find(".card-image.equal_height").css("height", temp_img_heights);
                        $(this).find(".card-image.equal_height img").css("height", temp_img_heights);
                        $(this).find(".card-image.equal_height").addClass("fit_thumbnail");
                        if(parseInt(NewsFeed_Image_Count-3) > 0){
                            var other_img_count_msg = "<div class='other_img_count'>"+(NewsFeed_Image_Count-3)+"<i class='ion-plus-round'></i></div>";
                            $(this).find(".card-image.equal_height:eq(1) img").after(other_img_count_msg);
                            var other_img_count = $(this).find(".other_img_count").width();
                            $(this).find(".other_img_count").css("margin-left", -(other_img_count/2));
                        }
                    }else if (parseInt(NewsFeed_Image_Count) == 2){
                        $(this).find(".card-image").addClass("two_card_img");
                    }else{
                        $(this).find(".card-image").addClass("one_card_img");
                    }
                }

             });
        },
        Scroll_table: function() {
            if($("table.table").is(":visible")){
                jQuery("table.table").each(function () {
                    var obj = jQuery(this);
                    if(!obj.parent().hasClass("over_auto")){
                        obj.wrapAll('<div class="over_auto"></div>');
                    }
                    obj.find("tbody tr").each(function () {
                        $(this).find("td").each(function (index) {
                            var data_title =  $(this).parents("tbody").prev("thead").find("tr").find("th").eq(index).clone().children().remove().end().text();
                            if(data_title.trim()){
                                $(this).attr("data-title",data_title);
                            }
                        });
                    });
                });
            }
        },
        Scroll_tab_group: function() {
            if($(".group_tab_scroll").is(":visible")){
                var group_tab_scroll_w =0;
                group_tab_scroll_w = $(".group_tab_scroll").outerWidth(true);

                var group_tab_w = 0;
                $(".group_tab_scroll .tabitem:not(.hidden)").each(function () {
                    var group_tab_item_w = $(this).outerWidth(true) + 2;
                    $(this).addClass("tab_show");
                    group_tab_w = group_tab_w + group_tab_item_w;
                });
                if(group_tab_w > group_tab_scroll_w)
                {
                    jQuery(".group_tab_scroll_next").removeClass("hidden");
                    var tab_each_itemt = 0;
                    jQuery(".group_tab_scroll > .tab_show").each(function () {
                        var tab_show_w = jQuery(this).outerWidth(true);
                        if (parseInt(tab_show_w) > parseInt(tab_each_itemt)){
                            tab_each_itemt = tab_show_w;
                        }
                    });
                    jQuery(".group_tab_scroll > .tab_show").css("width", tab_each_itemt);
                    var tab_length = jQuery(".group_tab_scroll > .tab_show").length;
                    $(".group_tab_scroll").css("width", tab_each_itemt*tab_length);
                    var translate_css_px = 0;
                    var tem_w = tab_each_itemt*tab_length;

                    $(".group_tab_scroll_next").click(function () {
                        jQuery(".group_tab_scroll_prev").removeClass("hidden");
                        translate_css_px = translate_css_px - tab_each_itemt;
                        var translate_css = 'translateX('+translate_css_px+'px)';
                        $(".group_tab_scroll").css({"transform" : translate_css});
                        tem_w = tem_w -  tab_each_itemt;
                        $(".group_tab_scroll_prev").show();
                        if( tem_w <= group_tab_scroll_w  ){
                            $(this).hide();
                        }
                    });
                    $(".group_tab_scroll_prev").click(function () {
                        translate_css_px = translate_css_px + tab_each_itemt;
                        var translate_css = 'translateX('+translate_css_px+'px)';
                        $(".group_tab_scroll").css({"transform" : translate_css});
                        tem_w = tem_w +  tab_each_itemt;
                        $(".group_tab_scroll_next").show();
                        if( tem_w >= (tab_each_itemt*tab_length)  ){
                            $(this).hide();
                        }
                    });
                }
            }
        },
        Table_sort: function() {
            if($("table .sortitem").is(":visible")){
                $(document).find(".sortitem").parents("th").addClass("sortitem_th");
            }
        }
    };
//--DOCUMENT READY FUNCTION BEGIN
$(document).ready(function () {
    
        Cust.dataTables_filter_col();
        Cust.check_required_input();
        $(document).on( "dialogopen", function( event, ui ) {
            if(jQuery(document).find(".date").is(":visible")){
                jQuery('.date').datetimepicker({
                    format: 'd/m/Y',
                    timepicker:false
                });
            }
            if (jQuery(document).find(".year").is(":visible")) {
                jQuery('.year').datepicker({
                    format: "yyyy",
                    viewMode: "years",
                    minViewMode: "years"
                });
            }
            if(jQuery(document).find('[data-toggle="popover"]').is(":visible")){
                jQuery(document).find('[data-toggle="popover"]').popover();
            }
            if(jQuery(document).find(".selectpicker").is(":visible")){
                $('.selectpicker').selectpicker();
            }
            if(jQuery(document).find(".autoSelect2").is(":visible")){
                $("select.autoSelect2").select2();
            }
            
            // lock scroll position, but retain settings for later
            //var scrollPosition = [
            //  self.pageXOffset || document.documentElement.scrollLeft || document.body.scrollLeft,
            //  self.pageYOffset || document.documentElement.scrollTop  || document.body.scrollTop
            //];
            //var html = jQuery('html'); // it would make more sense to apply this to body, but IE7 won't have that
            //html.data('scroll-position', scrollPosition);
            //html.data('previous-overflow', html.css('overflow'));
            //html.css('overflow', 'hidden');
            //window.scrollTo(scrollPosition[0], scrollPosition[1]);
            
            if((jQuery(document).find("#Overlay").is(":visible"))&&(jQuery(document).find("#Overlay").hasClass("loadingc"))){
                jQuery(document).find("#Overlay").removeClass("loadingc");
            }
            Cust.check_required_input();
        });
        $(document).on( "dialogclose", function( event, ui ) {
            // un-lock scroll position
            //var html = jQuery('html');
            //var scrollPosition = html.data('scroll-position');
            //html.css('overflow', html.data('previous-overflow'));
            //if(scrollPosition != null)
            //    window.scrollTo(scrollPosition[0], scrollPosition[1]);
        });
        jQuery('.widget-buttons > [data-toggle="maximize"]').on("click",function(){
            jQuery("body").toggleClass("maximize");
        });

        jQuery(document).on('click', '.dataFilter_Dropdown .dropdown-toggle', function(){
            jQuery(this).parents(".dataFilter_Dropdown").toggleClass("open");
            jQuery(this).parents(".quickSearch ").find(".dataFilter_Dropdown_target").toggleClass("open");
        });
        jQuery(document).on('click', '.dataFilter_Dropdown_close', function(e){
            e.preventDefault();
            jQuery(this).parents(".quickSearch").find(".dataFilter_Dropdown").toggleClass("open");
            jQuery(this).parents(".quickSearch").find(".dataFilter_Dropdown_target").toggleClass("open");
        });

        function display_dock() {
            //dock
            var dock = $(".dock #dockWrapper");
            dock.css("margin-top", "0px");
            dock.css("opacity", "1");
            //toggle_dock
            var toggle_dock = $(".toggle_dock");
            toggle_dock.css("opacity", "0");
            $(".dock").css("visibility", "visible");
            jQuery(".toggle_dock").addClass("is_hidden");
            jQuery(".toggle_dock").removeClass("is_show");
            localStorage.setItem('toggle_dock_stt', 'dock_is_show');
        }
        function hide_dock() {
            //dock
            var dock = $(".dock #dockWrapper");
            dock.css("margin-top", "100px");
            dock.css("opacity", "0");
            //toggle_dock
            var toggle_dock = $(".toggle_dock");
            toggle_dock.css("opacity", "1");

            $(".dock").css("visibility", "hidden");
            jQuery(".toggle_dock").removeClass("is_hidden");
            jQuery(".toggle_dock").addClass("is_show");
            localStorage.setItem('toggle_dock_stt', 'dock_is_hide');
        }
        jQuery(".btn_show_dock").click(function (e) {
            e.preventDefault();
            //dock
            var dock = $(".dock #dockWrapper");
            dock.animate({ "opacity": "1","margin-top": "0px" }, 300 );

            //toggle_dock
            var toggle_dock = $(".toggle_dock");
            toggle_dock.animate({ "opacity": "0" }, 300 );
            toggle_dock.css({
                'transition': 'all .3s',
                'transform': 'scale(0)',
            });

            jQuery(".toggle_dock").addClass("is_hidden");
            jQuery(".toggle_dock").removeClass("is_show");
            $(".dock").css("visibility", "visible");
            localStorage.setItem('toggle_dock_stt', 'dock_is_show');
        });
        jQuery(".btn_hide_dock").click(function (e) {
            e.preventDefault();
            //dock
            var dock = $(".dock #dockWrapper");
            dock.animate({ "margin-top": "100px", "opacity": "0" }, 300 );

            //toggle_dock
            var toggle_dock = $(".toggle_dock");
            toggle_dock.animate({ "opacity": "1" }, 300 );


            toggle_dock.css({
                'transition': 'all .3s',
                'transform': 'scale(1)',
            });

            jQuery(".toggle_dock").removeClass("is_hidden");
            jQuery(".toggle_dock").addClass("is_show");
            $(".dock").css("visibility", "hidden");
            localStorage.setItem('toggle_dock_stt', 'dock_is_hide');
        });
        if (localStorage.getItem('toggle_dock_stt') == 'dock_is_show') {
            display_dock();
        } else {
            hide_dock();
        }
        $('.multi-action .action-button').on('click', function(){
            $(this).toggleClass('active');
            if($(this).parents().attr("data-original-title") == ""){
                $(this).parents().attr("data-original-title","Danh sách ghim");
                $(this).parents().next(".tooltip").show();
            }else{
                $(this).parents().attr("data-original-title","");
                $(this).parents().next(".tooltip").hide();
            }
        });


        if(jQuery(".databox .databox-right > .databox-text > a").is(":visible")){
            jQuery(".databox .databox-right > .databox-text > a").each(function () {
                var databox_text = jQuery(this).find("span").text();
                jQuery(this).attr("title",databox_text);
                jQuery(this).attr("data-toggle","tooltip");
                jQuery(this).attr("data-placement","top");
            });
            $('[data-toggle="tooltip"]').tooltip();
        }
        if(jQuery(".databox span.databox-text").is(":visible")){
            jQuery(".databox span.databox-text").each(function () {
                var databox_text = jQuery(this).text();
                jQuery(this).attr("title",databox_text);
            });
        }
        if(jQuery(".sidebar-menu .menu-text").is(":visible")){
            jQuery(".sidebar-menu .menu-text").each(function () {
                var menu_text = jQuery(this).text();
                jQuery(this).attr("title",menu_text);
            });
        }
        Cust.fileViewer_height_fn();
        $('[data-toggle="tooltip"]').tooltip();
        //advanced_search_bar
        $(".advanced_search_bar .show_form_btn").focus(function() {
            $(this).parents(".advanced_search_bar").addClass("active");
            $(this).parents(".advanced_search_bar").find(".option_search").fadeIn();
        });
        $(".advanced_search_bar .hide_form_btn").click(function() {
            $(this).parents(".advanced_search_bar").removeClass("active");
            $(this).parents(".option_search").fadeOut();
        });
        //notification
        $(".notifies-dropdown-toggle").click(function() {
            if($(this).parents("li").hasClass("open")){
                $(this).parents("li").removeClass("open");
            }else{
                $(this).parents("li").addClass("open");
            }
        });
        jQuery(document).mouseup(function (e) {
            var container = jQuery(".notifies-dropdown-toggle").parents("li");
            if (container.is(":visible")) {
                if (!container.is(e.target) // if the target of the click isn't the container...
                    && container.has(e.target).length === 0) // ... nor a descendant of the container
                {
                    $(".notifies-dropdown-toggle").parents("li").removeClass("open");
                }
            }
        });

        jQuery(document).mouseup(function (e) {
            var container = jQuery(".bootstrap-select");
            if (container.is(":visible")) {
                if (!container.is(e.target) // if the target of the click isn't the container...
                    && container.has(e.target).length === 0) // ... nor a descendant of the container
                {
                    container.removeClass("open");
                }
            }
        });
    
        jQuery(".navbar .navbar-inner .navbar-header .navbar-account .account-area li.dropdown-hover a .dropdown-expand").click(function(event){
            event.stopPropagation();
            event.preventDefault();
            console.log("U CLICK");
            jQuery(this).parents(".dropdown-hover").find(".dropdown-menu").slideToggle(300);
        });
        $(".mgtitle").click(function(e) {
            e.preventDefault();
            return false;
        });
        //Sidebar Menu Handle
        $(".menu-expand").on('click', function (e) {
            e.preventDefault();
            if($(this).parents(".has_mgtitle").hasClass("open")){
                $(this).parents(".has_mgtitle").removeClass("open").nextUntil(".has_mgtitle","li:not(.hidden)").slideUp();
            }else{
                $(this).parents(".has_mgtitle").addClass("open").nextUntil(".has_mgtitle","li:not(.hidden)").slideDown();
            }
        });
        //End Sidebar Menu Handle

        var dragTimer;
        $(window).on('dragenter', function(){
            $(this).preventDefault();
        });
        $(document).on('dragover', function(e) {
            var dt = e.originalEvent.dataTransfer;
            if (dt.types && (dt.types.indexOf ? dt.types.indexOf('Files') != -1 : dt.types.contains('Files'))) {
                $("#drap_drop_fixed").addClass("active");
                $(".drap_drop_fixed_ov").addClass("active");
                window.clearTimeout(dragTimer);
            }
        });
        $(".sup_header .btn_sup").click(function(){
            jQuery(".support_id").toggleClass("active");
        });
        // JS click user
        $( '.click_caret' ).click(function( event ) {
            event.preventDefault();
            $('.drop_click_caret').toggleClass('open');
        });
        $(document).click(function(e) {
            var target = e.target;
            if (!$(target).is('.click_caret') && !$(target).is('.click_caret')) {
                $('.drop_click_caret').removeClass('open');
            }
        });


        var folderToggle = $(".ListCollaspe li > span");
        $(function () {
            folderToggle.click(function (e) {
                e.preventDefault();
                $(this).next().find("+ ul").toggle("slow");
                $(this).toggleClass("active");
            });
        });
        $(".ListCollaspe").find("li").each(function () {
            if ($(this).children("ul").length == 0) {
                $(this).addClass("nosub");
            }
        });
    // JS ADV SEARCH
    $(document).on("click", ".AdvSearchLink", function(e) {
        e.preventDefault();
        var url = $(this).attr("myhref");
        window.location = url;
    });

    $('.advanced_search_bar .btn-searchs .btn-group').on('show.bs.dropdown', function(){
        $(this).find(".bootstrap-select > .dropdown-menu > .dropdown-menu.inner").addClass("newfeed").perfectScrollbar();
        $(this).find(".bootstrap-select > .dropdown-menu > .dropdown-menu.inner").perfectScrollbar({useBothWheelAxes: false, wheelPropagation: true});     
    });
    //jQuery(document).find(".useTreegrid").each(function () {
    //    jQuery(this).treegrid();
    //}); 
});
//--DOCUMENT READY FUNCTION END
//--WINDOW resize FUNCTION BEGIN

$(window).resize(function () {
	Cust.fileViewer_height_fn();
    Cust.Scroll_tab_group();

});
//--WINDOW resize FUNCTION END



//--WINDOW LOADED FUNCTION BEGIN

$(window).bind("load", function () {
    Cust.newsfeedimg();
    Cust.Scroll_table();
    Cust.Scroll_tab_group();
    Cust.Table_sort();

});
//--WINDOW LOADED FUNCTION END
