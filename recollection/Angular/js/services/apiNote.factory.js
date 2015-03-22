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

        return {
            getPersonNotes: _getPersonNotes
        };
    });
})();