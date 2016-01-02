﻿(function () {
    'use strict';
    app.controller('BookingCtrl', BookingCtrl);
    function BookingCtrl($scope, $mdToast, $rootScope, $http) {
        var init = function () {
            $scope.toDay = new Date();
            $scope.Booking = {};
            $scope.RoomTypes = [];
            var ListAcc = [];

            $scope.fromDateChange = function()
            {
                $scope.toDateMin = new Date($scope.Booking.FromDate.addDays(1));
                $scope.Booking.ToDate = new Date($scope.Booking.FromDate.addDays(1));
            }

            $scope.Search = function()
            {
                $http.post(apiurl + "booking/getBooking", { 'start': $scope.Booking.FromDate,'end': $scope.Booking.ToDate}).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.RoomTypes = Result.data.Data;
                    }
                    else
                    {

                    }
                });
            }

            $scope.getAccount = function()
            {
                if(permission>0)
                {
                    var req = {
                        method: 'GET',
                        url: apiurl + "account/getcusaccount",
                        headers: {
                            'token': token
                        }
                    }
                    $http(req).then(function (Result) {
                        if (Result.data.Code == 1) {
                            ListAcc = Result.data.Data;
                        }
                        else {

                        }
                    });
                }
            }
            
            $scope.searchAccount = function(text)
            {
                var Result = [];
                for(var i=0;i<ListAcc.length;i++)
                {
                    if(ListAcc[i].indexOf(text)>-1)
                    {
                        Result.push(ListAcc[i]);
                    }
                }
                return Result;
            }
           
            $scope.Book = function(Booking)
            {
                if (permission > 0)
                {
                    if (!$scope.Booking.Email || !ListAcc.contains($scope.Booking.Email)) {
                        $rootScope.showMessage('Enter correct customer email!');
                        return;
                    }
                }
                var req = {
                    method: 'POST',
                    url: apiurl + "booking/book",
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
                        $rootScope.showMessage('Booking success');
                        location.href = '/booking/management';
                    }
                    else {
                        $rootScope.showMessage('Booking error');
                    }
                });
            }

        };

        init();
        $scope.getAccount();
    }
})();