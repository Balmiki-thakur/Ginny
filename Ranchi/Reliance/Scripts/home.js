
//(function () {
//    'use strict';
//    var app;
//    (function () {
//        //create app
//        app = angular.module("tab", ['ngMaterial', 'ngMessages', 'material.svgAssetsCache']);
//        //create controller
//        app.controller('tabController', function ($scope, tabService) {
//            var serv = tabService.getAll();
//            serv.then(function (d) {
//                tabController(d.data, $scope);
//            }, function (error) {
//                console.log('Something went wrong, please check after a while');
//            })
//        });
//        //create service
//        app.service('tabService', function ($http) {
//            this.getAll = function () {
//                return $http({
//                    url: "/Home/TabData", //Here we are calling our controller JSON action
//                    method: "GET"
//                });
//            };
//        });
//    })();
//})();
var TestCtrl = function ($scope, $http) {
    debugger;
    $scope.SendData = function (Data) {
        var GetAll = new Object();
        GetAll.FirstName = 1;
        GetAll.SecondName = 1;
        $http({ 
            url: "aPI/APIForm/GetItem/",
            dataType: 'json',
            method: 'POST',
            data: GetAll,
            headers: {
                "Content-Type": "application/json"
            }
        }).success(function (response) {
            alert(response);
            $scope.value = response;
        })
           .error(function (error) {
               alert(error);
           });
    }
};