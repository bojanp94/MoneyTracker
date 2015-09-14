$(function () {
    var total_pages = $('.total-pages').text();
    var page = $('.current').text();

    if (page == 1)
        $('.previous').addClass('disabled').prop('disabled', true);

    if (page == total_pages)
        $('.next').addClass('disabled').prop('disabled', true);

    SetDates();
});

function SetDates() {
    $('.date').each(function () {
        var date = moment($(this).data('date')).fromNow();
        $(this).text(date);
    });
}