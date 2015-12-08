$(function initValidation() {
    $("#submitPlate").submit(function (event) {
        if ($("#plateInput").val() == 0) {
            event.preventDefault();
        }
    });
});