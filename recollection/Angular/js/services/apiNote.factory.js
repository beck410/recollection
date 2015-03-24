;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiNote', function ($http, USERID,API) {
       
        function _getPersonNotes(personID, cb) {
            var url = API + 'Notes/' + USERID + '/Person/' + personID;
            console.log(url);
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.notes);
            })
            .error(function (err) {
                console.log('get person notes error: ', err);
            })
        }

        function _postPersonNote(note, cb) {
            var url = API + 'Notes/' + USERID + '/Person/' + note.PersID;
            $http.post(url,note)
            .success(function () {
                cb();
            })
            .error(function (err) {
                console.log('post memory error: ',err);
            }) 
        }

        function _deleteNote(id, cb) {
            var url = API + 'Notes/' + USERID + '/Delete/' + id;
            console.log(url);
            $http.delete(url)
            .success(function () {
              cb()
            })
            .error(function (err) {
                console.log("delete note error: ",err);
            })
        }

        function _putNote(note,cb) {
            var url = API + 'Notes/' + USERID + '/Update/' + note.ID;
            $http.put(url, note)
            .success(function () {
                cb();
            })
            .error(function (err) {
                console.log('edit note error',err);
            })
        }

        return {
            getPersonNotes: _getPersonNotes,
            postPersonNote: _postPersonNote,
            deleteNote: _deleteNote,
            putNote: _putNote
        };
    });
})();