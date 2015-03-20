;(function() {
    'use strict';
    angular.module('recollection')
    .controller('peopleController', function ($routeParams,USERID) {
        var vm = this;
        console.log(USERID);

        vm.test = "does people controller work?";
    })
})();