(function () {
    'use strict';
    app.controller('HomeCtrl', DemoCtrl);
    function DemoCtrl($scope) {
        var init = function () {
            $scope.isRegister = false;
            $scope.Account = {};
            $scope.login = function () {
                var k = 0;
            };
            $scope.register = function () {

            };
        };

        init();
    }
})();