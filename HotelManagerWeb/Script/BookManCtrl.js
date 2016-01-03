(function () {
    'use strict';
    app.controller('BookManCtrl', BookManCtrl);
    function BookManCtrl($scope, $mdToast, $rootScope, $http,$mdDialog, $mdMedia) {
        var init = function () {
            var ListAcc = [];
            $scope.History = {
                'Email': CusEmail,
                'FromDate': null,
            };

            $scope.ListBooking = [];
            $scope.getAccount = function () {
                if (permission > 0) {
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
                            if (CusEmail) {
                                $scope.Search();
                            }
                        }
                        else {

                        }
                    });
                }
            }
            $scope.searchAccount = function (text) {
                if (!text) return ListAcc;
                var Result = [];
                for (var i = 0; i < ListAcc.length; i++) {
                    if (ListAcc[i].indexOf(text) > -1) {
                        Result.push(ListAcc[i]);
                    }
                }
                return Result;
            }
            $scope.Search = function () {
                var reqdata = {};
                if (permission > 0) {
                    if ((!$scope.History.Email || !ListAcc.contains($scope.History.Email)) && !$scope.History.FromDate) {
                            $rootScope.showMessage('Enter correct condition');
                            return;
                    }
                    var date = $scope.History.FromDate != null ? $scope.History.FromDate.yyyymmdd() : null;
                    reqdata= { Email: $scope.History.Email, FromDate: date};
                }
                var req = {
                    method: 'POST',
                    url: apiurl + "booking/getbookinghistory",
                    headers: {
                        'token': token
                    },
                    data:reqdata
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.ListBooking = Result.data.Data;
                        if ($scope.ListBooking.length == 0) {
                            $rootScope.showMessage('Nothing to show');
                        }
                    }
                    else {
                        $rootScope.showMessage('Something error');
                    }
                });
            }
            $scope.Del = function (ev, BookingID) {
                // Appending dialog to document.body to cover sidenav in docs app
                var confirm = $mdDialog.confirm()
                      .title('Would you like to delete the booking?')
                      .targetEvent(ev)
                      .ok('Please do it!')
                      .cancel('Cancel');
                $mdDialog.show(confirm).then(function () {
                    $scope.DoDel(BookingID);
                }, function () {
                });
            };
            $scope.Pay = function(BookingID)
            {
                var req = {
                    method: 'POST',
                    url: apiurl + "booking/pay",
                    headers: {
                        'token': token
                    },
                    data: BookingID
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $rootScope.showMessage('Paid success');
                        $scope.Search();
                    }
                    else {
                        $rootScope.showMessage('Something error');
                    }
                });
            }
            $scope.DoDel = function (BookingID) {
                var req = {
                    method: 'POST',
                    url: apiurl + "booking/delbooking",
                    headers: {
                        'token': token
                    },
                    data: BookingID
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $rootScope.showMessage('Deleted');
                        $scope.Search();
                    }
                    else {
                        $rootScope.showMessage('Something error');
                    }
                });
            }
        }
        init();
        
        if(permission==0)
        {
            $scope.Search();
        }
        else
        {
            $scope.getAccount();
        }
 
    }
})()