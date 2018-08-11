/// <reference path="angular.min.js" />

var app = angular.module('myApp', []);
app.controller('myCtrl', function($scope) {
    $scope.x1 = "JOHN";
    $scope.x2 = angular.lowercase($scope.x1);
});
