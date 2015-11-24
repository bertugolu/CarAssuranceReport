(function initEmailFactory() {
    angular.module("carApp")
        .factory("emailFactory", ['$http', factory]);

    function factory($http) {
        var result = {};

        result.saveEmail = function (email) {
            return $http({
                method: "POST",
                url: "/api/email",
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                },
                data: {Email: email}
            });
        };

        return result;
    }
})()

