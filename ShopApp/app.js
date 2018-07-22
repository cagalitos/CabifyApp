var cabifyShop;
(function () {
    'use strict';
    cabifyShop = angular
        .module('cabifyShop', ['ngResource', 'ngRoute'])
        .config(function () {

        })
        .run(
            function ($rootScope) {

                $rootScope.wHeight = window.innerHeight - 50;

        });

})();