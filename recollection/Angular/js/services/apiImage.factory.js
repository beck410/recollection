;(function() {
    'use strict';
    angular.module('recollection')
    .factory('apiImage', function ($http, USERID,API) {
       
        function _getPersonImages(personID, cb) {
            var url = API + 'Images/' + USERID + '/Person/' + personID;
            $http.get(url)
            .success(function (obj) {
                cb(obj.Data.images);
            })
            .error(function (err) {
                console.log('get person images error: ', err);
            })
        }

        function _postPersonImage(image, cb) {
            var url = API + 'Images/' + USERID;
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

        function _deleteImage(id, cb) {
            var url = API + 'Images/' + USERID + '/Delete/' + id;
            console.log(url);
            $http.delete(url)
            .success(function () {
              cb()
            })
            .error(function (err) {
                console.log("delete images error: ",err);
            })
        }

        return {
            getPersonImages: _getPersonImages,
            postPersonImage: _postPersonImage,
            editPersonImage: _editPersonImage,
            deleteImage: _deleteImage
        };
    });
})();