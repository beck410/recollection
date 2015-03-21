; (function () {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams, USERID, $location) {
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
    .controller('allPeopleController', function ($routeParams, apiPerson,$location,$modal) {
        var vm = this;
        apiPerson.getPeople(function (people) {
            vm.people = people;
        })

        vm.deletePerson = function (id, person) {
            apiPerson.deletePeople(person.ID, function (personID) {
                console.log(vm.people[id]);
                delete vm.people[id];
            })
        }

        vm.personDetails = function (person) {
            var modalInstance = $modal.open({
                templateUrl: '/Angular/views/peopleModal.html',
                controller: 'peopleModalController',
                controllerAs: 'personDetails',
                size: 'lg',
                backdrop: false,
                resolve: {
                    person: function () {
                        return person;
                    }
                }
            })
        }

    })
    .controller('FamilyPeopleController', function ($routeParams, apiPerson) {
        var vm = this;
        apiPerson.getByRelationshipType('Family',function (people) {
            vm.people = people;
        })
    })
    .controller('FriendsPeopleController', function ($routeParams, apiPerson) {
        var vm = this;
        apiPerson.getByRelationshipType('Friends',function (people) {
            vm.people = people;
        })
    })
    .controller('BusinessPeopleController', function ($routeParams, apiPerson) {
        var vm = this;
        apiPerson.getByRelationshipType('Business',function (people) {
            vm.people = people;
        })
    })
    .controller('OtherPeopleController', function ($routeParams, apiPerson) {
        var vm = this;
        apiPerson.getByRelationshipType('Other',function (people) {
            vm.people = people;
        })
    })
    .controller('peopleModalController', function (person, $modalInstance, apiPerson) {
        var vm = this;
        vm.person = person;

        vm.cancel = function () {
            console.log('cancel clicked');
            $modalInstance.dismiss('cancel');
        };
    })
})();