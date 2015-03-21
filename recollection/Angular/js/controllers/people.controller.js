;(function() {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams,USERID,apiFactory) {
        var vm = this;

        apiFactory.getPeople(function(people) {
            vm.people = people;
        })

    })
})();