(function () {

    'use strict';

    cabifyShop.controller('ItemsController',

        function ItemsController($window, $rootScope, $scope, ItemsService) {

            var vm = this;

            vm.addToCart = function (item) {

                var cart = JSON.parse($window.localStorage.getItem('userCart'));

                if (cart === null || cart.length === 0) {
                    cart = [];
                    item.id = 1;
                }
                else {
                    item.id = cart[cart.length - 1].id + 1;
                }
                
                cart.push(item);

                $window.localStorage.setItem('userCart', JSON.stringify(cart));

                $rootScope.$broadcast('refreshCart');
            }

            ItemsService.getItems()
                .then(function (data) {

                    $scope.items = data;

                }, function (data, status, headers, config) {
                    var test = "";
                });

        });

})();
