$(document).ready(function () {
    $('input[type=range]').mouseup(function () {
        var range_id = $(this).attr('id');
        var range_value = $(this).val();
        $('#range-value-' + range_id).html(range_value);
    });
    $('.overlay, .close-modal').click(function () {
        $('.overlay').hide();
        $('.modal').hide();
    });
});
var openTerms = function () {
    $('.overlay').show();
    $('.modal').show();
}