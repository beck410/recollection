;(function() {
    'use strict';
    angular.module('recollection')
    .controller('placesController', function ($routeParams, USERID, apiPlace,$scope,uploadImage) {
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
    })
})();