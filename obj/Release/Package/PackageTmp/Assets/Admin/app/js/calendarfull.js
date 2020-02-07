
$(document).ready(function () {
    $('#external-events div.external-event').each(function () {
        var eventObject = {
            title: $.trim($(this).text())
        };
        $(this).data('eventObject', eventObject);
        $(this).draggable({
            zIndex: 999,
            revert: true,
            revertDuration: 0
        });
    });

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
    var data = {};
    try {
        data = JSON.parse(jQuery('#txtCalendar').val());
    } catch (e) {}
    $('#calendarfull').fullCalendar({
        locale: 'vi',
        header: {
            right: 'month,agendaWeek,agendaDay prev,next',
            left: 'title'

        },
        editable: true,
        buttonText: {
            prev: '<i class="fa fa-chevron-left"></i>',
            next: '<i class="fa fa-chevron-right"></i>',
            today: 'Today',
            month: 'Month',
            week: 'Week',
            day: 'Day'
        },
        droppable: true,
        drop: function (date, allDay) {

            var originalEventObject = $(this).data('eventObject');

            var copiedEventObject = $.extend({}, originalEventObject);

            copiedEventObject.start = date;
            copiedEventObject.allDay = allDay;

            $('#calendarfull222').fullCalendar('renderEvent', copiedEventObject, true);

            if ($('#drop-remove').is(':checked')) {
                $(this).remove();
            }

        },

        eventResize: function (event, delta, revertFunc) {

            function padLeft(nr, n, str) {
                return Array(n - String(nr).length + 1).join(str || '0') + nr;
            }

            Number.prototype.padLeft = function (n, str) {
                return Array(n - String(this).length + 1).join(str || '0') + this;
            }

            var startDate = padLeft(event.start.getDate(), 2) + '-' + padLeft((event.start.getMonth() + 1), 2) + '-' + event.start.getFullYear();
            var endDate = padLeft(event.end.getDate(), 2) + '-' + padLeft((event.end.getMonth() + 1), 2) + '-' + event.end.getFullYear();

            data.Name
            jQuery.ajax({
                type: "POST",
                async: true,
                url: event.url,
                data: ({
                    ID: event.id,
                    Name: event.title,
                    StartDate: startDate,
                    EndDate: endDate,
                    allDay: event.allDay,
                    borderColor: event.borderColor,

                }),
                dataType: 'Json',
                success: function (data) {

                },
            });
        },
       
        editable: true,
        eventDrop: function (event, delta, revertFunc) {

            function padLeft(nr, n, str) {
                return Array(n - String(nr).length + 1).join(str || '0') + nr;
            }

            Number.prototype.padLeft = function (n, str) {
                return Array(n - String(this).length + 1).join(str || '0') + this;
            }

            var startDate = padLeft(event.start.getDate(), 2) + '-' + padLeft((event.start.getMonth() + 1), 2) + '-' + event.start.getFullYear();
            var endDate = padLeft(event.end.getDate(), 2) + '-' + padLeft((event.end.getMonth() + 1), 2) + '-' + event.end.getFullYear();
            data.Name
            jQuery.ajax({
                type: "POST",
                async: true,
                url: event.url,
                data: ({
                    ID: event.id,
                    Name: event.title,
                    StartDate: startDate,
                    EndDate: endDate,
                    allDay: event.allDay,
                    borderColor: event.borderColor,
                }),
                dataType: 'Json',
                success: function (data) {

                },
            });
        },
        eventRender: function (event, element) {
            element.append("<a class='quickDelete' href='" + event.urldelete + "'><b><span class='closeon'>X</span></b></a>");
        },
        events: data,
    });
  
    jQuery(document).on('click', '.fc-event', function (e) {
        e.preventDefault();
        jQuery(document).find(".fc-event").removeClass("active");
        $(this).toggleClass("active");

    });
}); // rf end

$('.fc-button-content').each(function () {
});



