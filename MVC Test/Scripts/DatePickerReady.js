$(function () {
    $("#dueDate").datepicker({
			showOn: "button",
			buttonImage: "/images/calendar.gif",
			buttonImageOnly: true
});

$("#fromDate, #toDate").datepicker({
    showOn: "button",
    buttonImage: "/images/calendar.gif",
    buttonImageOnly: true,
    beforeShowDay: noBefore
});

//$("#toDate").datepicker({
//    showOn: "button",
//    buttonImage: "/images/calendar.gif",
//    buttonImageOnly: true
//});

$("#fromEditDate, #toEditDate").datepicker({
    showOn: "button",
    buttonImage: "/images/calendar.gif",
    buttonImageOnly: true,
    beforeShowDay: noBefore
});

//$("#toEditDate").datepicker({
//    showOn: "button",
//    buttonImage: "/images/calendar.gif",
//    buttonImageOnly: true
//});

$(".ui-datepicker-trigger").mouseover(function () {
    $(this).css('cursor', 'pointer');
});

});

function noBefore(date) {
    if (date < new Date()) {
        return [false];
    }
    return [true];
}