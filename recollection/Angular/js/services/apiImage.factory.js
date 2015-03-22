;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiImage', function ($http, USERID,API) {
       
        function _getPersonImages(personID, cb) {
            var url = API + 'Images/' + USERID + '/Person/' + personID;
            console.log(url);
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.images);
            })
            .error(function (err) {
                console.log('get person images error: ', err);
            })
        }

        return {
            getPersonImages: _getPersonImages
        };
    });
})();