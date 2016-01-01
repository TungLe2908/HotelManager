(function () {
    'use strict';
    app.controller('BookingCtrl', BookingCtrl);
    function BookingCtrl($scope, $mdToast, $rootScope, $http) {
        var init = function () {
            $rootScope.toolbar = true;
            $scope.toDay = new Date();
            $scope.Booking = {};
            $scope.RoomTypes = [];
            $scope.Search = function()
            {
                $http.post(apiurl + "room/getBooking", { 'start': $scope.Booking.FromDate,'end': $scope.Booking.ToDate}).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.RoomTypes = Result.data.Data;
                    }
                    else
                    {

                    }
                });
            }
        };

        init();
    }
})();