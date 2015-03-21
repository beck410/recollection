;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiPerson', function ($http, USERID,API) {
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
                cb(person);
            })
            .error(function (err) {
                console.log('post person error: ',err);
            })
        }

        function _putPeople(person, cb) {
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
            var url = API + 'persons/DELETE/' + id;
            $http.delete(url)
            .success(function(status) {
                cb(id);
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
            getPeople: _getPeople,
            postPeople: _postPeople,
            putPeople: _putPeople,
            deletePeople: _deletePeople,
            getByRelationshipType: _getByRelationshipType
        };
    });
})();