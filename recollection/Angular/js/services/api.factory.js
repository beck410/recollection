﻿;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiFactory', function ($http, USERID,API) {

        function _getPlaces(cb) {
            var url = API + 'places/' + USERID
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.place);
            })
            .error(function(err){
                console.log('get places error: ' + err);
            })
        }

        function _postPlace(place,cb) {
            var url = API + 'places/' + USERID;
            $http.post(url,place)
            .success(function (status) {
                console.log(status);
                cb(place);
            })
            .error(function (err) {
                console.log('post place error: ' + err);
            })
        }

        function _putPlace(place, cb) {
            var url = API + 'places/' + USERID + '/UPDATE/' + place.ID;
            $http.put(url, place)
            .success(function(place) {
                console.log("edit sent");
                cb(place);
            })
            .error(function (err) {
                console.log('edit place err: ' + err)
            })
        }

        function _deletePlace(id, cb) {
            var url = API + 'places/' + USERID + '/DELETE/' + id;
            $http.delete(url)
            .success(function(status) {
                console.log(status);
                cb();
            })
            .error(function(err) {
                console.log('delete place err',err);
            })
        }

        return {
            getPlaces: _getPlaces,
            postPlace: _postPlace,
            putPlace: _putPlace,
            deletePlace: _deletePlace
        };
    });
})();