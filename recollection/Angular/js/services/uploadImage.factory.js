﻿;(function() {
    'use strict';
    angular.module('recollection')
    .factory('uploadImage', function ($upload, USERID) {

        function _uploadToS3(filesArray, persID, fileName, cb) {
            var file = filesArray[0];

            $upload.upload({
                url: 'https://recollectionimages.s3.amazonaws.com',
                method: 'POST',
                data: {
                    'Content-Type': file.type,
                    awsaccesskeyid: 'AKIAIUNACKD5KNQVYYDQ',
                    acl: 'public-read',
                    policy: 'eyJleHBpcmF0aW9uIjoiMjAyMC0wMS0wMVQwMDowMDowMFoiLCJjb25kaXRpb25zIjpbeyJidWNrZXQiOiJyZWNvbGxlY3Rpb25pbWFnZXMifSx7ImFjbCI6ICJwdWJsaWMtcmVhZCJ9LFsic3RhcnRzLXdpdGgiLCIkQ29udGVudC1UeXBlIiwiIl0sWyJzdGFydHMtd2l0aCIsIiRrZXkiLCIiXV19',
                    signature: 'GTY+MahjpwnuywHMfz/UQD9G+nc='
                },
                fields: {
                 key: persID + '/' + fileName
                },
                file: file
            })
            .success(function (data, status, headers, config) {
                var filelink = 'https://s3-us-west-2.amazonaws.com/recollectionimages/' + persID + '/' + config.file.name;
                cb(filelink);
            })
            .error(function (err) {
                console.log('upload to s3 error',err);
            })
        }

        function _setThumbnail(file, cb) {
            _imageToBase64(file, function (base64) {
                var fileName = file.name;
                cb(fileName, base64);
            });
        }

        function _imageToBase64(file, cb) {
            if (file && file.type.indexOf('image') > -1) {
                var fr = new FileReader();
                fr.readAsDataURL(file);
                fr.onload = function (e) {
                    cb(e.target.result);
                };
            }
        }
        
        return {
            uploadToS3: _uploadToS3,
            setThumbnail: _setThumbnail
        };
    });
})();