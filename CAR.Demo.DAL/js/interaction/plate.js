(function initLoadingPage() {

    window.CAR = window.CAR || {};
    window.CAR.plateHelper = window.CAR.plateHelper || {};

    window.CAR.plateHelper.getPlate = function () {
        return getParameterByName("plate");
    };

    function getParameterByName (name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }


})()