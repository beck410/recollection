; (function () {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams, USERID, apiFactory) {
        var vm = this;
        vm.newPerson = { UserID: USERID };

        vm.clearForm = function () {
            vm.newPerson = { UserID: USERID };
            console.log("qefewqf");
        }


    })
    .controller('allPeopleController', function ($routeParams, apiFactory) {
        var vm = this;
        apiFactory.getPeople(function (people) {
            vm.people = people;
        })
    })
    .controller('FamilyPeopleController', function ($routeParams, apiFactory) {
        var vm = this;
        apiFactory.getByRelationshipType('Family',function (people) {
            vm.people = people;
        })
    })
    .controller('FriendsPeopleController', function ($routeParams, apiFactory) {
        var vm = this;
        apiFactory.getByRelationshipType('Friends',function (people) {
            vm.people = people;
        })
    })
    .controller('BusinessPeopleController', function ($routeParams, apiFactory) {
        var vm = this;
        apiFactory.getByRelationshipType('Business',function (people) {
            vm.people = people;
        })
    })
    .controller('OtherPeopleController', function ($routeParams, apiFactory) {
        var vm = this;
        apiFactory.getByRelationshipType('Other',function (people) {
            vm.people = people;
        })
    })
})();