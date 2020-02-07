"use strict";

$(document).ready(function () {

    $.fn.initAnimation = function () {
        $(this).each(function () {
            var animation_class = $(this).data('animate');
            var delay = $(this).data('delay');
            delay = delay ? delay : 0;
            var obj = $(this);
            setTimeout(function () {
                obj.removeClass('not-animated').addClass(animation_class).addClass('animated');
                obj.removeClass('hide-iframe');
                obj.css('visibility', 'visible');
            }, delay);
        });
    };
    $.fn.resetAnimation = function () {
        $(this).each(function () {
            var animation_class = $(this).data('animate');
            $(this).removeClass(animation_class).removeClass('animated').addClass('not-animated');
        });
    };
    $.fn.progressbar_animate = function () {
        $(this).each(function () {
            var progressbar = $(this);
            var value = progressbar.data('value');
            var meter = progressbar.find('.progressbar-meter');
            meter.removeClass('has-animation').css('width', '0');
            setTimeout(function () {
                meter.addClass('has-animation').css('width', value + '%');
            }, 300);
            progressbar.find('.progressbar-value span').countTo({
                from: 0,
                to: value,
                speed: 1500,
                refreshInterval: 1500 / value
            });
        });
    }

    function init() {

        $(window).trigger('resize');

        /* CSS Animation with waypoint */
        $('[data-animate]').each(function () {
            var element = $(this);
            element.waypoint(function () {
                element.initAnimation();
            }, {
                triggerOnce: true,
                offset: 'bottom-in-view'
            });
        });

        /* init code here */
        /* -------------- */
        /* Menu toggle */
        $('#menu-toggle').on("click", function (e) {
            e.preventDefault();
            e.stopPropagation();
            if (window.matchMedia("(max-width: 992px)").matches) {

                if ($(this).hasClass('opened')) {
                    $(this).removeClass('opened');
                    $('#mobile-menu').removeClass('opened');
                } else {
                    $(this).addClass('opened');
                    $('#mobile-menu').addClass('opened');
                }
            }
            return false;
        });
        $('html,body').on("click", function (e) {
            if ($('#menu-toggle').hasClass('opened')) {
                e.preventDefault();
                e.stopPropagation();
                $('#menu-toggle').removeClass('opened');
                $('#mobile-menu').removeClass('opened');
            }
        });
        $('#mobile-menu').on("click", function (e) {
            e.preventDefault();
            e.stopPropagation();
        });

        /* Mobile Menu Item Click */
        $('#mobile-menu .menu-item').on("click", function () {
            if ($(this).siblings('.submenu').length == 0) {
                window.location = $(this).attr('href');
                return;
            }
            var parent_li = $(this).parent();
            if (parent_li.hasClass('opened')) {
                parent_li.removeClass('opened');
                parent_li.children('.submenu').slideUp(300);
            } else {
                parent_li.addClass('opened');
                parent_li.children('.submenu').slideDown(300);
            }
            return false;
        });
        $('#mobile-menu .sub-menu-item a').on("click", function () {
            window.location = $(this).attr('href');
        });

        $('.panel').on('hidden.bs.collapse', function (e) {
            //alert('Event fired HIDDEN on #' + e.currentTarget.id);
            $(this).removeClass('open');
        })
        $('.panel').on('shown.bs.collapse', function (e) {
            $(this).addClass('open');
        })
    }

    /* Initialization */
    init();
});

