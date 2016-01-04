(function () {
    'use strict';
    var app = angular.module('Hotel', ['ngMaterial']);
    app.controller('HomeCtrl', HomeCtrl);
    function HomeCtrl($scope, $mdToast) {
        var init = function () {
            $scope.login = function () {
                location.assign("http://hoteloauth.somee.com/?redir=" + location.origin + "/home/login?token=");
            }

            $scope.facebooklogin = function () {
                location.assign("https://www.facebook.com/dialog/oauth?client_id=609321552474818&auth_type=rerequest&scope=email&redirect_uri=" + location.origin + "/home/facebooklogin");
            }
        };

        init();
    }
})();