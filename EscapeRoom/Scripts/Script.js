$(document).ready(function () {
    var calView = "month";

    $.getJSON("/calendar/data", function (data) {
        $("#calendar").fullCalendar({
            events: data,
            eventRender: function (event, element) {
                element.find('.fc-title').append("(" + event.inventory + ")");
            }
            
        });
       
    });

    $("#calView").on("click", function() {
        if (calView === "listMonth") {
            $("#calendar").fullCalendar("changeView", "month");
            calView = "month";
        }
        else {
            $("#calendar").fullCalendar("changeView", "listMonth");
            calView = "listMonth";
        }
    });
});