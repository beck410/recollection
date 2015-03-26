;(function() {
    'use strict';
    angular.module('recollection')
    .controller('dashboardController', function (apiPlace, apiPerson) {
        var vm = this;
        
        vm.searchForPeople = function () {
            apiPerson.searchForPeople(vm.peopleSearchString, function (people) {
                vm.searchTerm = vm.peopleSearchString;
                vm.searchPeopleResults = people;
                vm.placeSearchString = '';
                vm.searchPlaceResults = null;
            });
        }

        vm.searchForPlaces = function () {
            apiPlace.searchForPlaces(vm.placeSearchString, function (places) {
                vm.searchTerm = vm.placeSearchString;
                vm.searchPlaceResults = places;
                vm.peopleSearchString = '';
                vm.searchPeopleResults = null;
            });
        }
    })
})();