;(function() {
    'use strict';
    angular.module('recollection')
    .controller('placesController', function ($routeParams, $modal, USERID, apiPlace,$scope,uploadImage) {
        var vm = this;
        vm.newPlace = { UserID: USERID }



        apiPlace.getPlaces(function(places) {
            vm.places = places;
        })

        vm.fileSelected = function (event) {
            uploadImage.setThumbnail(vm.files[0], function (fileName,base64) {
                vm.fileName = fileName;
                vm.files[0].dataUrl = base64;
                $scope.$apply();
            })
        }

        vm.clearForm = function () {
            vm.newPlace = { UserID: USERID };
            vm.files = null;
            vm.fileName = null;
        }

        vm.addNewPlace = function () {
            if (vm.files) {
                uploadImage.uploadToS3(vm.files, USERID, vm.fileName, function (fileLink) {
                    vm.newPlace.MainImage = fileLink;
                    apiPlace.postPlace(vm.newPlace, function () {
                        vm.newPlace = { UserID: USERID }
                        vm.files = null;
                        vm.fileName = null;
                        apiPlace.getPlaces(function (places) {
                            vm.places = places;
                        })
                    })
                })
            } else {
                console.log('no image added');
            }
        }

        vm.deletePlace = function (id, place) {
            apiPlace.deletePlace(place.ID, function (placeID) {
                apiPlace.getPlaces(function(places) {
                    vm.places = places;
                })
            })
        }

        vm.placeDetails = function (place) {
            var modalInstance = $modal.open({
                templateUrl: '/Angular/views/placeModal.html',
                controller: 'placeModalController',
                controllerAs: 'placeDetails',
                size: 'lg',
                backdrop: false,
                resolve: {
                    place: function () {
                        return place;
                    }
                }
            })
        }
    })
    .controller('placeModalController', function (place, $scope, $modalInstance, uploadImage, apiImage, apiNote, apiPlace, apiMemory) {
        var vm = this;
        vm.place = place;
        vm.newMemory = { LocationID: place.ID };
        vm.newNote = { LocationID: place.ID };
        vm.newImage = { LocationID: place.ID };
        vm.placeFormVisible = false;
        vm.editPlace = { ID: place.ID };
        vm.editMemoryVisible = false;
        vm.editMemory = {};
        vm.editNoteVisible = false;
        vm.editNote = {};

        apiMemory.getPlaceMemories(place.ID, function (memories) {
            vm.memories = memories;
        })

        apiNote.getPlaceNotes(place.ID, function (notes){
            vm.notes = notes
        })

        apiImage.getPlaceImages(place.ID, function (images) {
            vm.images = images
        })

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        vm.showEditPlaceForm = function () {
            vm.editPlace = place;
            vm.placeFormVisible = true;
        }

        vm.editPlaceInDB = function () {
            apiPlace.putPlace(vm.editPlace, function (newPlaceDetails) {
                vm.place = vm.editPlace;
                vm.placeFormVisible = false;
            })
        }

        vm.cancelEditPlace = function () {
            vm.placeFormVisible = false;
        }

        vm.clearForm = function (type) {
            if (type === 'memory') {
                vm.newMemory = { LocationID: place.ID };
                return;
            }

            if (type === 'note') {
                vm.newNote = { LocationID: place.ID };
                return;
            }

            if(type === 'image'){
                vm.newImage = {LocationID: place.ID};
            }
            vm.newNote = { LocationID: place.ID };
        }

        vm.addNewMemory = function () {
            apiMemory.postPlaceMemory(vm.newMemory, function () {
                vm.newMemory = { LocationID: place.ID }
                apiMemory.getPlaceMemories(place.ID, function (memories) {
                    vm.memories = memories;
                })
            })
        }

        vm.addNewNote = function () {
            apiNote.postPlaceNote(vm.newNote, function () {
                vm.newNote = { LocationID: place.ID }
                apiNote.getPlaceNotes(place.ID, function (notes) {
                    vm.notes = notes;
                })
            })
        }

        vm.addNewImage = function () {
            if (vm.files) {
                uploadImage.uploadToS3(vm.files, place.ID, vm.fileName, function (fileLink) {
                    vm.newImage.ImageLink = fileLink;
                    apiImage.postPlaceImage(vm.newImage, function (image) {
                        vm.newImage = { LocationID: place.ID }
                        vm.files = null;
                        apiImage.getPlaceImages(place.ID, function (images) {
                            vm.images = images;
                        })
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
                    apiMemory.getPlaceMemories(place.ID, function (memories) {
                        vm.memories = memories;
                        vm.editMemoryVisible = false;
                    })
                })
            }

            if (type === 'note') {
                apiNote.putNote(vm.editNote, function () {
                    apiNote.getPlaceNotes(place.ID, function (notes) {
                        vm.notes = notes;
                        vm.editNoteVisible = false;
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

        vm.delete = function (type, index, obj) {
            console.log('clicked');
            if (type === "memory") {
                apiMemory.deleteMemory(obj.ID, function (memory) {
                    apiMemory.getPlaceMemories(place.ID, function (memories) {
                        vm.memories = memories;
                    })
                });
            }

            if (type == 'note') {
                apiNote.deleteNote(obj.ID, function (note) {
                    apiNote.getPlaceNotes(place.ID, function (notes){
                        vm.notes = notes;
                    })
                })
            }

            if (type == 'image') {
                apiImage.deleteImage(obj.ID, function () {
                    apiImage.getPlaceImages(place.ID, function (images){
                        vm.images = images;
                    })
                })
            }
        }
    })
})();