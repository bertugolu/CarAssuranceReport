$(function () {
    var plate = window.CAR.plateHelper.getPlate() || "ABC 123";
    $("#plate").val(plate);

    setTimeout(function () {
        window.location = "/results?plate=" + plate;
    }, 5000);
});

