;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiFactory', function ($http, USERID,API) {
        //PLACES
        function _getPlaces(cb) {
            var url = API + 'places/' + USERID
            $http.get(url)
            .success(function (obj) {
                console.log(obj.Data.place);
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

        //PEOPLE
        function _getPeople(cb) {
            var url = API + 'persons/' + USERID
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.people);
            })
            .error(function(err){
                console.log('get people error: ',err);
            })
        }

        function _postPeople(person,cb) {
            var url = API + 'persons/' + USERID;
            $http.post(url,person)
            .success(function (status) {
                console.log(status);
                cb(person);
            })
            .error(function (err) {
                console.log('post person error: ',err);
            })
        }

        function _putPeople(place, cb) {
            var url = API + 'persons/' + USERID + '/UPDATE/' + place.ID;
            $http.put(url, person)
            .success(function(person) {
                console.log("edit sent");
                cb(person);
            })
            .error(function (err) {
                console.log('edit person err: ',err)
            })
        }

        function _deletePeople(id, cb) {
            var url = API + 'persons/' + USERID + '/DELETE/' + id;
            $http.delete(url)
            .success(function(status) {
                console.log(status);
                cb();
            })
            .error(function(err) {
                console.log('delete person err',err);
            })
        }

         function _getByRelationshipType(relationshipType,cb) {
             var url = API + 'persons/' + USERID + '/Type/' + relationshipType;
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.people);
            })
            .error(function(err){
                console.log('get people  by relationship error: ',err);
            })
        }


        return {
            getPlaces: _getPlaces,
            postPlace: _postPlace,
            putPlace: _putPlace,
            deletePlace: _deletePlace,
            getPeople: _getPeople,
            postPeople: _postPeople,
            putPeople: _putPeople,
            deletePeople: _deletePeople,
            getByRelationshipType: _getByRelationshipType
        };
    });
})();