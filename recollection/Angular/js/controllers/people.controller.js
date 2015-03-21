; (function () {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams, USERID, apiFactory,$location) {
        var vm = this;
        vm.newPerson = { UserID: USERID };

        vm.clearForm = function () {
            vm.newPerson = { UserID: USERID };
            console.log("qefewqf");
        }

        vm.addNewPerson = function (){
            apiFactory.postPeople(vm.newPerson, function () {
                vm.newPerson = { UserID: USERID }
                $location.path('/People/All');
            })
        }
    })
    .controller('allPeopleController', function ($routeParams, apiFactory,$scope, $timeout) {
        var vm = this;
        apiFactory.getPeople(function (people) {
            vm.people = people;
        })

        vm.deletePerson = function (id, person) {
            apiFactory.deletePeople(person.ID, function (personID) {
                console.log(vm.people[id]);
                delete vm.people[id];
            })
        }

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