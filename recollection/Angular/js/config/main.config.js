﻿;(function() {
    'use strict';
    angular.module('recollection')
    .config(function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/Angular/recollection.html',
            controller: 'dashboardController',
            controllerAs: 'db'
        })
        .when('/People', {
            templateUrl: '/Angular/views/people.html',
            controller: 'peopleController',
            controllerAs: 'people'
        })
        .when('/Places', {
            templateUrl: '/Angular/views/places.html',
            controller: 'placesController',
            controllerAs: 'places'
        })
    })
})();