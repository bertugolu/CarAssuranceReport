(function initEmailController() {
    angular.module("carApp")
        .controller("EmailController", ['emailFactory', Controller]);

    function Controller(emailFactory) {
        var vm = this;
        vm.buttonText = "Sign up!";
        vm.registration = {};

        vm.RegisterEmail = function () {
            if (vm.registration.successful) return;          
            vm.registration = {};

            if (validateEmail(vm.email)) {
                vm.buttonText = "Saving your email...";
                emailFactory.saveEmail(vm.email).then(saveSuccessful, saveError);
            } else {
                vm.registration.errorMessage = "Invalid Email";
            }
        }
        
        function saveSuccessful() {
            vm.registration.successful = true;
            vm.buttonText = "Thanks for signing up!";
        }

        function saveError(data) {
            vm.registration.errorMessage = data.data.Message;
            vm.buttonText = "Sign up!";
        }

        function validateEmail(email) {
            return /^([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x22([^\x0d\x22\x5c\x80-\xff]|\x5c[\x00-\x7f])*\x22)(\x2e([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x22([^\x0d\x22\x5c\x80-\xff]|\x5c[\x00-\x7f])*\x22))*\x40([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x5b([^\x0d\x5b-\x5d\x80-\xff]|\x5c[\x00-\x7f])*\x5d)(\x2e([^\x00-\x20\x22\x28\x29\x2c\x2e\x3a-\x3c\x3e\x40\x5b-\x5d\x7f-\xff]+|\x5b([^\x0d\x5b-\x5d\x80-\xff]|\x5c[\x00-\x7f])*\x5d))*$/.test(email);
        }
    }


})()

