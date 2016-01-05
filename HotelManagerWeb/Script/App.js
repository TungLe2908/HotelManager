Date.prototype.addDays = function(days)
{
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
};
Date.prototype.yyyymmdd = function() {
    var yyyy = this.getFullYear().toString();
    var mm = (this.getMonth()+1).toString(); // getMonth() is zero-based
    var dd  = this.getDate().toString();
    return yyyy + "/" +(mm[1]?mm:"0"+mm[0]) + "/" +(dd[1]?dd:"0"+dd[0]); // padding
};
Array.prototype.contains = function(obj) {
    var i = this.length;
    while (i--) {
        if (this[i] === obj) {
            return true;
        }
    }
    return false;
}

var apiurl = "http://api.aloraha.com/api/";
var app = angular.module('Hotel', ['ngMaterial']);
app.directive('focusMe', function($timeout) {
    return {
        scope: { trigger: '=focusMe' },
        link: function(scope, element) {
            scope.$watch('trigger', function(value) {
                if(value === true) { 
                    //console.log('trigger',value);
                    //$timeout(function() {
                    element[0].focus();
                    scope.trigger = false;
                    //});
                }
            });
        }
    };
});
app.filter('range', function() {
    return function(input, total) {
        total = parseInt(total);

        for (var i=1; i<=total; i++) {
            input.push(i);
        }

        return input;
    };
});


app.controller("MainCtrl", MainCtrl);
function MainCtrl($scope,$rootScope,$mdToast,$document) {
    $rootScope.permission = permission;
    $scope.Navigate = function(Link) {
        location.href = Link;
    }
    $rootScope.showMessage = function (mes) {
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
        $mdToast.show($mdToast.simple().textContent(mes).position(getToastPosition()).hideDelay(3000));
    }
}