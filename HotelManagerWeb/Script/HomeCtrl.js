(function () {
    'use strict';
    var app = angular.module('Hotel', ['ngMaterial']);
    app.controller('HomeCtrl', HomeCtrl);
    function HomeCtrl($scope, $mdToast, $http) {
        var init = function () {
            $scope.showweather = false;
            $scope.login = function () {
                location.assign("http://hoteloauth.somee.com/?redir=" + location.origin + "/home/login?token=");
            }

            $scope.facebooklogin = function () {
                location.assign("https://www.facebook.com/dialog/oauth?client_id=609321552474818&auth_type=rerequest&scope=email&redirect_uri=" + location.origin + "/home/facebooklogin");
            }

            $http.get(apiurl + "weather/get").then(function (Result) {
                if(Result.data.Code==1)
                {
                    $scope.Weather = Result.data.Data;
                    /*
                    for(var i=0;i<Result.length;i++)
                    {
                        $scope.Weather =  $scope.Weather + Result[i].Name + " " + Result[i].Min + "C - " + Result[i].Max + " " + Result[i].Status + "  ";
                    }
                    */
                }
            }
                );
        };

        init();
    }
})();