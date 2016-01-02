(function () {
    'use strict';
    app.controller('StaffCtrl', StaffCtrl);
    function StaffCtrl($scope, $mdToast, $rootScope, $http) {
        var init = function () {
            $scope.ListStaff = [];
            $scope.Load = function()
            {
                var req = {
                    method: 'GET',
                    url: apiurl + "account/GetStaffAccount",
                    headers: {
                        'token': token
                    }
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.ListStaff = Result.data.Data;
                    }
                    else {
                        $rootScope.showMessage('Get staff error');
                    }
                });
            }
            $scope.Add = function()
            {
                location.href = 'http://hoteloauth.somee.com/home/register?redir=' + location.origin + "/account/addstaff";
            }
            $scope.Delete =function(Email)
            {
                var req = {
                    method: 'POST',
                    url: apiurl + "account/deletestaff",
                    headers: {
                        'token': token
                    },
                    data: '"' + Email + '"'
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $rootScope.showMessage('Delete success');
                        $scope.Load();
                    }
                    else {
                        $rootScope.showMessage('Something error');
                    }
                });
            }
        }
        init();
        $scope.Load();
    }
})()