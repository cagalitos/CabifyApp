
(function () {
    cabifyShop.factory('ItemsService',
        function ($resource, $q, $http) {

            return {

                getItems: function () {

                    var deferred = $q.defer();

                    var resource = $resource(
                        API.ITEMS,
                        {

                        },
                        {
                            query: { method: 'GET', isArray: true }
                        }
                    );

                    resource.query(

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