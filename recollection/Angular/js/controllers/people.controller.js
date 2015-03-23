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
            apiPerson.postPeople(vm.newPerson, function () {
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
    .controller('peopleModalController', function (person, $scope, $modalInstance, apiMemory, apiNote,apiImage,uploadImage) {
        var vm = this;
        vm.person = person;
        vm.newMemory = { PersId: person.ID };
        vm.newNote = { PersId: person.ID };
        vm.newImage = { PersID: person.ID };

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


        vm.clearForm = function (type) {
            if (type === 'memory') {
                vm.newMemory = { PersId: person.ID };
                return;
            }

            if(type === 'image'){
                vm.newImage = {PersID: person.ID};
            }
            vm.newNote = { PersId: person.ID };
        }

        vm.addNewMemory = function () {
            apiMemory.postPersonMemory(vm.newMemory, function () {
                vm.newMemory = { PersId: person.ID }
                apiMemory.getPersonMemories(person.ID, function (memories) {
                    vm.memories = memories;
                })
            })
        }

        vm.addNewNote = function () {
            apiNote.postPersonNote(vm.newNote, function () {
                vm.newNote = { PersId: person.ID }
                apiNote.getPersonNotes(person.ID, function (notes) {
                    vm.notes = notes;
                })
            })
        }

        vm.addNewImage = function () {
            apiImage.postPersonImage(vm.newImage, function (image) {
                console.log('image added to db: ' + image );
                if (vm.files) {
                    uploadImage.uploadToS3(vm.files, person.ID, vm.fileName, function (fileLink) {
                        vm.newImage.ImageLink = fileLink;
                        console.log('file uploaded to s3: ' + fileLink);
                        apiImage.getPersonImages(person.ID,function(images){
                            vm.newestImage = images[0];
                            console.log('newest image: ' + vm.newestImage);
                        })
                        var id = vm.newestImage.ID;
                        apiImage.editPersonImage(id, vm.newImage, function () {
                            console.log('db image edited');
                            apiImage.getPersonImages(person.ID, function (images) {
                                vm.images = images;
                            })
                        })
                    })
                }
            })
        }

        vm.fileSelected = function (event) {
            uploadImage.setThumbnail(vm.files[0], function (fileName,base64) {
                vm.fileName = fileName;
                vm.files[0].dataUrl = base64;
                $scope.$apply();
            })
        }
    })
})();