;(function () {
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
        .when('/People/All', {
            templateUrl: '/Angular/views/peopleCategory.html',
            controller: 'allPeopleController',
            controllerAs: 'showPeople'
        })
        .when('/People/Family', {
            templateUrl: '/Angular/views/peopleCategory.html',
            controller: 'FamilyPeopleController',
            controllerAs: 'showPeople'
        })
        .when('/People/Friends', {
            templateUrl: '/Angular/views/peopleCategory.html',
            controller: 'FriendsPeopleController',
            controllerAs: 'showPeople'
        })
        .when('/People/Business', {
            templateUrl: '/Angular/views/peopleCategory.html',
            controller: 'BusinessPeopleController',
            controllerAs: 'showPeople'
        })
        .when('/People/Other', {
            templateUrl: '/Angular/views/peopleCategory.html',
            controller: 'OtherPeopleController',
            controllerAs: 'showPeople'
        })
        .when('/Places', {
            templateUrl: '/Angular/views/places.html',
            controller: 'placesController',
            controllerAs: 'places'
        })
    })
})();