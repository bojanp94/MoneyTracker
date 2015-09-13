$(function () {
    SetDates();
});

function SetDates() {
    $('.date').each(function () {
        var date = moment($(this).data('date')).fromNow();
        $(this).text(date);
    });
}