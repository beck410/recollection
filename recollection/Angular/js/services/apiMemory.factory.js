;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiMemory', function ($http, USERID,API) {
       
        function _getPersonMemories(personID, cb) {
            var url = API + 'Memories/' + USERID + '/Person/' + personID;
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.notes);
            })
            .error(function(err){
                console.log('get person memories error: ',err);
            })
        }

        function _getPlaceMemories(personID, cb) {
            var url = API + 'Memories/' + USERID + '/Place/' + personID;
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.notes);
            })
            .error(function(err){
                console.log('get person memories error: ',err);
            })
        }

        function _postPersonMemory(memory,cb) {
            var url = API + 'Memories/' + USERID + '/Person/' + memory.PersID;
            $http.post(url,memory)
            .success(function () {
                cb();
            })
            .error(function (err) {
                console.log('post memory error: ',err);
            })
        }

        function _postPlaceMemory(memory,cb) {
            var url = API + 'Memories/' + USERID + '/Place/' + memory.PersID;
            $http.post(url,memory)
            .success(function () {
                cb();
            })
            .error(function (err) {
                console.log('post memory error: ',err);
            })
        }

        function _deleteMemory(id,cb) {
            var url = API + 'Memories/' + USERID + '/Delete/' + id;
            console.log(url);
            $http.delete(url)
            .success(function () {
              cb()
            })
            .error(function (err) {
                console.log("delete memory error: ",err);
            })
        }

        function _putMemory(memory,cb) {
            var url = API + 'Memories/' + USERID + '/Update/' + memory.ID;
            $http.put(url, memory)
            .success(function () {
                cb();
            })
            .error(function (err) {
                console.log('edit memory error',err);
            })
        }

        return {
            getPersonMemories: _getPersonMemories,
            getPlaceMemories: _getPlaceMemories,
            postPersonMemory: _postPersonMemory,
            postPlaceMemory: _postPlaceMemory,
            deleteMemory: _deleteMemory,
            putMemory: _putMemory
        };
    });
})();