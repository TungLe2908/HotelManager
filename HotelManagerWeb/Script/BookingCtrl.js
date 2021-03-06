﻿(function () {
    'use strict';
    app.controller('BookingCtrl', BookingCtrl);
    function BookingCtrl($scope, $mdToast, $rootScope, $http) {
        var init = function () {
            $scope.toDay = new Date();
            $scope.Booking = {};
            $scope.User = null;
            $scope.RoomTypes = [];
            var ListAcc = [];

            $scope.fromDateChange = function()
            {
                $scope.toDateMin = new Date($scope.Booking.FromDate.addDays(1));
                $scope.Booking.ToDate = new Date($scope.Booking.FromDate.addDays(1));
            }

            $scope.Search = function()
            {
                var req = {
                    method: 'POST',
                    url: apiurl + "booking/getBooking",
                    headers: {
                        'token': token
                    },
                    data: { 'start': $scope.Booking.FromDate.yyyymmdd(), 'end': $scope.Booking.ToDate.yyyymmdd() }
                }
                $http(req).then(function (Result) {
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
                    var Acc = (ListAcc[i].Email + ' ' + ListAcc[i].Name).toLowerCase();
                    if (Acc.indexOf(text.toLowerCase()) > -1)
                    {
                        Result.push(ListAcc[i]);
                    }
                }
                return Result;
            }
           
            var IsEmail = function(Email)
            {
                for(var i=0;i<ListAcc.length;i++)
                {
                    if (ListAcc[i].Email == Email)
                        return true;
                }
                return false;
            }

            $scope.Book = function(Booking)
            {
                if (permission > 0)
                {
                    if (!$scope.User.Email || !IsEmail($scope.User.Email)) {
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
                        'DateStart': $scope.Booking.FromDate.yyyymmdd(),
                        'DateEnd': $scope.Booking.ToDate.yyyymmdd(),
                        'Email': $scope.User?$scope.User.Email:null,
                        'Quantity': Booking.Quantity,
                        'RoomType': Booking.RoomTypeID
                    }
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        var ex = '';
                        if (permission > 0)
                        {
                            ex = '?email=' + $scope.User.Email;
                        }
                        $rootScope.showMessage('Booking success');
                        location.href = '/booking/management'+ex;
                    }
                    else {
                        $rootScope.showMessage('Booking error');
                    }
                });
            }

            $scope.AddCus = function () {
                location.href = 'http://hoteloauth.somee.com/home/register?redir=' + location.origin + "/account/addcus"
            };

        };

        init();
        $scope.getAccount();
    }
})();