
(function () {
    cabifyShop.factory('CartService',
        function ($resource, $q, $http) {

            return {

                processCart: function (items) {

                    var deferred = $q.defer();

                    var resource = $resource(
                        API.CART,
                        {

                        },
                        {
                            save: { method: 'POST', isArray: false, data: items }
                        }
                    );

                    resource.save(items,

                        function (item) {
                            deferred.resolve(item);
                        },

                        function (error) {
                            deferred.reject(error)
                        }
                    );

                    return deferred.promise;

                },
                //updateProgress: function (_data) {

                //    var deferred = $q.defer();

                //    var resource = $resource(
                //        API.PROJECTS + '/progress/update',
                //        {

                //        },
                //        {
                //            save: { method: 'POST', isArray: true, data: _data }
                //        }
                //    );

                //    resource.save(_data,
                //        function (item) {
                //            deferred.resolve(item);
                //        },

                //        function (error) {
                //            deferred.reject(error)
                //        }
                //    );
                //    return deferred.promise;

                //},
            }
        });
})();