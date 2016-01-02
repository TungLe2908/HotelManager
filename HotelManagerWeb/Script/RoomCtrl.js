(function () {
    'use strict';
    app.controller('RoomCtrl', RoomCtrl);
    function RoomCtrl($scope, $mdToast, $rootScope, $http) {
        var init = function () {
            $scope.ListRoom = [];
            $scope.ListType = {};
            $scope.Load = function () {
                var req = {
                    method: 'GET',
                    url: apiurl + "room/getroom",
                    headers: {
                        'token': token
                    }
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.ListRoom = Result.data.Data;
                        /*
                        for (var i = 0; i < $scope.ListRoom.length; i++) {
                            $scope.ListRoom[i].RoomType = $scope.ListType[$scope.ListRoom[i].RoomTypeID];
                        }*/
                    }
                    else {
                        $rootScope.showMessage('Get room error');
                    }
                });
            }

            $scope.LoadType = function () {
                var req = {
                    method: 'GET',
                    url: apiurl + "room/getroomtype",
                    headers: {
                        'token': token
                    }
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $scope.ListType = Result.data.Data;
                        /*
                        for(var i=0;i<Result.length;i++)
                        {
                            $scope.ListType[Result[i].RoomTypeID] = Result[i].RoomTypeName;
                        }*/
                        $scope.Load();
                    }
                    else {
                        $rootScope.showMessage('Get room type error');
                    }
                });
            }

            $scope.Add = function () {
               
            }
            $scope.Delete = function (RoomID) {
                var req = {
                    method: 'POST',
                    url: apiurl + "room/deleteroom",
                    headers: {
                        'token': token
                    },
                    data: '"' + RoomID + '"'
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $rootScope.showMessage('Delete success');
                        $scope.Load();
                    }
                    else {
                        $rootScope.showMessage('Something error');
                    }
                });
            }

            $scope.Change = function(Room)
            {
                var req = {
                    method: 'POST',
                    url: apiurl + "room/updateroom",
                    headers: {
                        'token': token
                    },
                    data: Room
                }
                $http(req).then(function (Result) {
                    if (Result.data.Code == 1) {
                        $rootScope.showMessage('Update room '+Room.RoomID+' success');
                    }
                    else {
                        $rootScope.showMessage('Update room ' + Room.RoomID + ' fail');
                    }
                });
            }
        }
        init();
        $scope.LoadType();
    }
})()