(function () {
    'use strict';
    app.controller('StatisticCtrl', StatisticCtrl);
    function StatisticCtrl($scope, $mdToast, $rootScope, $http) {
        var init = function () {
            $scope.Statis = [];
            $scope.fromDateChange = function () {
                $scope.toDateMin = new Date($scope.Booking.FromDate.addDays(1));
                $scope.Booking.ToDate = new Date($scope.Booking.FromDate.addDays(1));
            }

            $scope.Search = function () {
                var req = {
                    method: 'POST',
                    url: apiurl + "Statistic/getStatisticByRoomType",
                    headers: {
                        'token': token
                    },
                    data: {
                        'start': $scope.Booking.FromDate,
                        'end': $scope.Booking.ToDate
                    }
                };
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.Statis = Result.data.Data;
                        if($scope.Statis.length==0)
                        {
                            $rootScope.showMessage('Nothing to show');
                        }
                    }
                });
            }
        }
        init();
    }
})()