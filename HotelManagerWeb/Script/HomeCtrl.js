﻿(function () {
    'use strict';
    var app = angular.module('Hotel', ['ngMaterial']);
    app.controller('HomeCtrl', HomeCtrl);
    function HomeCtrl($scope, $mdToast) {
        var init = function () {
            $scope.login = function () {
                location.assign("http://hoteloauth.somee.com/?redir=" + location.origin + "/home/login?token=");
            }
        };

        init();
    }
})();