;(function() {
    'use strict';
    angular.module('recollection')
    .controller('dashboardController', function (apiPlace, apiPerson) {
        var vm = this;
        
        vm.searchForPeople = function () {
            apiPerson.searchForPeople(vm.peopleSearchString, function (people) {
                console.log(people);
            });
        }

        vm.searchForPlaces = function () {
            apiPlace.searchForPlaces(vm.placeSearchString, function (places) {
                console.log(places);
            });
        }
    })
})();