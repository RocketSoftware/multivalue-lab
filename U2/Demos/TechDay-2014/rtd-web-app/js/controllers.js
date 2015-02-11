'use strict';

/* Controllers */
myApp.controller('CustController', function CustController($scope, $log, $http) {
    $scope.sortOrder = "last_name";
    $scope.customers = [];
    $scope.selectedCustomer = {};

    $scope.LoadCustomers = function () {
		$http.get('http://localhost:9191/api/Customers?max=500').
		  success(function(data, status, headers, config) {
                $scope.customers = data.Customers;
		  }).
		  error(function(data, status, headers, config) {
                alert(data);
		  });
	};

    $scope.EditCustomer = function (id) {
        var creds = {"username":"u2","password":"pass"};
        $http.get('http://localhost:9191/api/Customer/'+id).
            success(function(data, status, headers, config) {
                $scope.selectedCustomer = data;
                $("#dialog-form").dialog("open");
                $log.log(data);
            }).
            error(function(data, status, headers, config) {
                alert(data);
            });
    };

    $scope.SaveCustomer = function () {
        var cust = $scope.selectedCustomer;
        var url = 'http://localhost:9191/api/Customer/'+cust.id;
        //  Must pass the If-Match header to make sure object hasn't changed
        var config = {headers:{"If-Match":cust.u2version}};
        $http.put( url, cust, config).
            success(function(data, status, headers, config) {
                $scope.LoadCustomers();
            }).
            error(function(data, status, headers, config) {
                if (status == 412) {
                    alert("This record has been changed on the server, you must refresh the object first.")
                } else {
                    alert(data);
                }
            });
        $("#dialog-form").dialog("close");
    };

    $scope.CancelCustomer = function () {
        $("#dialog-form").dialog("close");
    };

    // Call the function to load the customer list
    $scope.LoadCustomers();


});
