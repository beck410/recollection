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

        function _postPersonImage(image, cb) {
            var url = API + 'Images/' + USERID + '/Person/' + image.PersID;
            $http.post(url,image)
            .success(function () {
                cb(image);
            })
            .error(function (err) {
                console.log('post memory error: ',err);
            }) 
        }

        function _editPersonImage(id,image,cb) {
            var url = API + 'Images/' + USERID + '/Update/' + id;
            $http.put(url, image)
            .success(function (image) {
                cb(image);
            })
            .error(function (err) {
                console.log('edit image err: ', err);
            })
        }

        return {
            getPersonImages: _getPersonImages,
            postPersonImage: _postPersonImage,
            editPersonImage: _editPersonImage
        };
    });
})();