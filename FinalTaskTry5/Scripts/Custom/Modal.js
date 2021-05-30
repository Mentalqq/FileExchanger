$(document).ready(function ($) {
    $('.add-open').click(function () {
        $('.add-block').fadeIn();
        return false;
    });
    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            e.stopPropagation();
            $('.add-block').fadeOut();
        }
    });
    $('.add-block').click(function (e) {
        if ($(e.target).hasClass('add') == false) {
            $(this).fadeOut();
        }
    });
});

$(document).ready(function ($) {
    $('.folder-add-open').click(function () {
        $('.folder-add-fade').fadeIn();
        return false;
    });
    $(document).keydown(function (e) {
        if (e.keyCode === 27) {
            e.stopPropagation();
            $('.folder-add-fade').fadeOut();
        }
    });
    $('.folder-add-fade').click(function (e) {
        if ($(e.target).hasClass('folder-add') == false) {
            $(this).fadeOut();
        }
    });
});