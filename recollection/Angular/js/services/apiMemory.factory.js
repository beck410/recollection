;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiMemory', function ($http, USERID,API) {
       
        function _getPersonMemories(personID, cb) {
            var url = API + 'Memories/' + USERID + '/Person/' + personID;
            console.log(url);
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.notes);
            })
            .error(function(err){
                console.log('get person memories error: ',err);
            })
        }

        return {
            getPersonMemories: _getPersonMemories
        };
    });
})();