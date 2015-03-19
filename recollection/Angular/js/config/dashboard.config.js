; (function () {
    'use strict';
    angular.module('recollection')
    .config(function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/Angular/recollection.html'
        })
    })
})();