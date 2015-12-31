(function () {
    'use strict';
    app.controller('HomeCtrl', DemoCtrl);
    function DemoCtrl($scope, $mdToast) {
        var init = function () {
            $scope.isRegister = false;
            $scope.Account = {};
            $scope.login = function () {
                if($scope.Account.Username && $scope.Account.Password)
                {

                }
                else
                {
                    $mdToast.show($mdToast.simple().textContent('Please complete all fields'));
                }
            };
            $scope.register = function () {

            };
        };

        init();
    }
})();