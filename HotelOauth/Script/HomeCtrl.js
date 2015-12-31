(function () {
    'use strict';
    app.controller('HomeCtrl', DemoCtrl);
    function DemoCtrl($scope, $mdToast, $http) {
        var init = function () {
            $scope.isRegister = false;
            $scope.Account = {};

            var showMessage = function (mes) {
                var Position = {
                    bottom: false,
                    top: true,
                    left: false,
                    right: true
                };

                var getToastPosition = function () {
                    return Object.keys(Position)
                      .filter(function (pos) { return Position[pos]; })
                      .join(' ');
                };
                $mdToast.show($mdToast.simple().textContent(mes).position(getToastPosition()));
            }

            $scope.login = function () {
                if ($scope.Account.Email && $scope.Account.Password) {
                    $http.post('/api/oauth/gettoken', { 'Email': $scope.Account.Email, 'Password': $scope.Account.Password }).then(function (Result) {
                        Result = Result.data;
                        if (Result.Code == 0) {
                            showMessage('Username or password are incorrect');
                        }
                        else {
                            if (Redir) {
                                window.location.assign(Redir + Result.Data);
                            }
                            else {
                                showMessage('Loggin success');
                            }
                        }
                    });
                }
                else {
                    showMessage('Please complete all fields');
                }
            };
            $scope.register = function () {
                if ($scope.Account.Email && $scope.Account.Password && $scope.Account.Phone && $scope.Account.Name) {
                    $http.post('/api/oauth/addaccount', { 'Phone': $scope.Account.Phone, 'Name': $scope.Account.Name, 'Email': $scope.Account.Email, 'Pass': $scope.Account.Password }).then(function (Result) {
                        Result = Result.data;
                        if (Result.Code == 0) {
                            showMessage('Please use another email');
                        }
                        else {
                            if ($scope.onlyRegister) {
                                if (Redir) {
                                    window.location.assign(Redir + Result.Data);
                                }
                            }
                            else {

                                $scope.login();
                            }
                        }
                    });
                }
                else {
                    showMessage('Please complete all fields');
                }
            };
        };

        init();
    }
})();