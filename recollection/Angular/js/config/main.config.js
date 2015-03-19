;(function() {
    'use strict';
    angular.module('recollection')
    .config(function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/Angular/recollection.html',
            Controller: 'dashboardController',
            ControllerAs: 'db'
        })
        .when('/People', {
            templateUrl: '/Angular/views/people.html',
            Controller: 'peopleController'
        })
        .when('/Places', {
            templateUrl: '/Angular/views/places.html',
            Controller: 'placesController'
        })
    })
})();