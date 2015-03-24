; (function () {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams, USERID, $location, uploadImage, apiImage, apiPerson) {
        var vm = this;
        vm.newPerson = { UserID: USERID };

        vm.clearForm = function () {
            vm.newPerson = { UserID: USERID };
            console.log("qefewqf");
        }

        vm.fileSelected = function (event) {
            uploadImage.setThumbnail(vm.files[0], function (fileName,base64) {
                vm.fileName = fileName;
                vm.files[0].dataUrl = base64;
                $scope.$apply();
            })
        }

        vm.addNewPerson = function(){
            if (vm.files) {
                uploadImage.uploadToS3(vm.files,USERID, vm.fileName, function (fileLink) {
                    vm.newPerson.MainImage = fileLink;
                    apiPerson.postPeople(vm.newPerson, function () {
                        vm.newPerson = { UserID: USERID }
                        $location.path('/People/All');
                    })
                })
            } else {
                console.log('no image added');
            }
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
    .controller('peopleModalController', function (person, $scope, $modalInstance, apiPerson, apiMemory, apiNote,apiImage,uploadImage) {
        var vm = this;
        vm.person = person;
        vm.newMemory = { PersId: person.ID };
        vm.newNote = { PersId: person.ID };
        vm.newImage = { PersID: person.ID };
        vm.personFormVisible = false;
        vm.editPerson = { ID: person.ID };
        vm.editMemoryVisible = false;
        vm.editMemory = {};
        vm.editNoteVisible = false;
        vm.editNote = {};

        apiMemory.getPersonMemories(person.ID, function (memories) {
            vm.memories = memories;
        })

        apiNote.getPersonNotes(person.ID, function (notes){
            vm.notes = notes
        })

        apiImage.getPersonImages(person.ID, function (images) {
            vm.images = images
        })

        vm.cancel = function () {
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
            if (vm.files) {
                uploadImage.uploadToS3(vm.files, person.ID, vm.fileName, function (fileLink) {
                    vm.newImage.ImageLink = fileLink;
                    apiImage.postPersonImage(vm.newImage, function (image) {
                        vm.newImage = { PersID: person.ID }
                        vm.files = null;
                        apiImage.getPersonImages(person.ID, function (images) {
                            vm.images = images;
                        })
                    })
                })
            }
        }

        vm.fileSelected = function (event) {
            uploadImage.setThumbnail(vm.files[0], function (fileName,base64) {
                vm.fileName = fileName;
                vm.files[0].dataUrl = base64;
                $scope.$apply();
            })
        }

        vm.showEditPersonForm = function () {
            vm.editPerson = person;
            vm.personFormVisible = true;

        }

        vm.editPersonInDB = function () {
            apiPerson.putPerson(vm.editPerson, function (newPersonDetails) {
                vm.person = vm.editPerson;
                vm.personFormVisible = false;
            })
        }

        vm.cancelEditPerson = function () {
            vm.personFormVisible = false;
        }

        vm.delete = function (type, index, obj) {
            console.log('clicked');
            if (type === "memory") {
                apiMemory.deleteMemory(obj.ID, function (memory) {
                    apiMemory.getPersonMemories(person.ID, function (memories) {
                        vm.memories = memories;
                    })
                });
            }

            if (type == 'note') {
                apiNote.deleteNote(obj.ID, function (note) {
                    apiNote.getPersonNotes(person.ID, function (notes){
                        vm.notes = notes;
                    })
                })
            }

            if (type == 'image') {
                apiImage.deleteImage(obj.ID, function () {
                    apiImage.getPersonImages(person.ID, function (images){
                        vm.images = images;
                    })
                })
            }
        }

        vm.showEdit = function (type, obj) {
            if (type === 'memory') {
                vm.editMemoryVisible = true;
                vm.editMemory = obj;
            }

            if (type == 'note') {
                vm.editNoteVisible = true;
                vm.editNote = obj;
            }
        }

        vm.edit = function (type) {
            console.log('edit clicked');
            if (type === 'memory') {
                apiMemory.putMemory(vm.editMemory, function () {
                    apiMemory.getPersonMemories(person.ID, function (memories) {
                        vm.memories = memories;
                        vm.editMemoryVisible = false;
                    })
                })
            }

            if (type === 'note') {
                apiNote.putNote(vm.editNote, function () {
                    apiNote.getPersonNotes(person.ID, function (notes) {
                        vm.notes = notes;
                        vm.editNoteVisible = false;
                    })
                })
            }
        }
    })
})();