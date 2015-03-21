;(function() {
    'use strict';
    angular.module('recollection')
    .filter('monthDayYear', function ($filter) {
        return function (input) {
            if (input == null) {
                return "";
            }

            var _date = $filter('date')(new Date(input), 'MMM dd yyyy');
            return _date.toUpperCase();
        }
    })
})();