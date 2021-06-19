
var triggerDateTimePicker = function () {
    $('.datetimepicker').datetimepicker({
        format: 'M/D/Y',
        clearButton: false,
        time: true,
        weekStart: 1
    });
    //$('.datetimepicker').datetimepicker();
    $('.datetimepicker').attr('autocomplete', 'off');
};