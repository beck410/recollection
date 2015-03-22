﻿; (function () {
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
    .controller('peopleModalController', function (person, $modalInstance, apiMemory, apiNote,apiImage) {
        var vm = this;
        vm.person = person;
        vm.newMemory = { PersId: person.ID };

        apiMemory.getPersonMemories(person.ID, function (memories) {
            vm.memories = memories;
        })

        apiNote.getPersonNotes(person.ID, function (notes){
            vm.notes = notes
        })

        apiImage.getPersonImages(person.ID, function (images) {
            vm.images = images
            console.log(images);
        })

        vm.cancel = function () {
            console.log('working');
            $modalInstance.dismiss('cancel');
        };


        vm.clearForm = function () {
            vm.newPerson = { PersId: person.ID };
        }

        vm.addNewMemory = function () {
            apiMemory.postPersonMemory(vm.newMemory, function () {
                vm.newMemory = { PersId: person.ID }
                apiMemory.getPersonMemories(person.ID, function (memories) {
                    vm.memories = memories;
                })
            })
        }
    })
})();