;(function() {
    'use strict';
    angular.module('recollection')
    .controller('placesController', function ($routeParams, apiPlace) {
        var vm = this;



        apiPlace.getPlaces(function(places) {
            vm.places = places;
        })

        //var place = {
        //    "ID": 6,
        //    "Name": "The Shack",
        //    "Address": "LA, Florida"
        //}
        //apiFactory.putPlace(place, function(place) {
        //    console.log(place);
        //}

        //apiFactory.deletePlace(4, function () {
        //});

    })
})();