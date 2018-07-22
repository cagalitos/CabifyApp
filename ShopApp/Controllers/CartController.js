(function () {

    'use strict';
    
    cabifyShop.controller('CartController',

        function CartController($window, $scope, CartService) {

            var vm = this;

            vm.refreshCart = function () {

                var localcart = JSON.parse($window.localStorage.getItem('userCart'));

                CartService.processCart(localcart)
                    .then(function (data) {

                        $scope.cart = data;

                    }, function (data, status, headers, config) {
                        var test = "";
                    });

            }

            vm.removeFromCart = function(item) {

                var localcart = JSON.parse($window.localStorage.getItem('userCart'));

                localcart.splice(item.cartItemId - 1, 1);

                $window.localStorage.setItem('userCart', JSON.stringify(localcart));

                vm.refreshCart();

            }

            vm.refreshCart();

            $scope.$on('refreshCart', function () {
                vm.refreshCart();
            });

        });
})();
