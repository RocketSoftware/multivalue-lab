myApp.factory('customerData', function ($http, $log, $timeout, $q, $resource) {

    return {
        getCustomers: function () {
            var deferred = $q.defer();
			var resource = $resource('http://localhost:9191/api/Customers?max=200', {});
            resource.get(null,
                function (custlist) {
                    deferred.resolve(custlist.CustomerList);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        getCustDetails: function (id) {
            var deferred = $q.defer();
            var resource1 = $resource('http://localhost:9191/api/Customer/:id', { id: '@id' });
            resource1.get({ id: id },
                function (customer) {
                    deferred.resolve(customer);
                },
                function (response) {
                    deferred.reject(response);
                });
            return deferred.promise;
        }
    }
});
