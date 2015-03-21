;(function() {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams,USERID,apiFactory) {
        var vm = this;

    })
    .controller('allPeopleController', function ($routeParams, apiFactory) {
        var vm = this;
        apiFactory.getPeople(function (people) {
            vm.people = people;
        })
    })
})();