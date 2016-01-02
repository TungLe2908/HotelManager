/// <reference path="C:\Users\ThanhDat\Source\Repos\HotelManager\HotelManagerWeb\Views/Booking/Dialog.html" />
/// <reference path="C:\Users\ThanhDat\Source\Repos\HotelManager\HotelManagerWeb\Views/Booking/Dialog.html" />
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
            
           
            $scope.Book = function(Booking)
            {
                var req = {
                    method: 'POST',
                    url: apiurl + "room/book",
                    headers: {
                        'token': token
                    },
                    data: {
                        'DateStart': $scope.Booking.FromDate,
                        'DateEnd': $scope.Booking.ToDate,
                        'Email': $scope.Booking.Email,
                        'Quantity': Booking.Quantity,
                        'RoomType': Booking.RoomTypeID
                    }
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        alert('success');
                    }
                    else {

                    }
                });
            }

        };

        init();
    }
})();