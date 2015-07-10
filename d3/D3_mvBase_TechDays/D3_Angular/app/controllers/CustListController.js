(function () {
    
    var CustListController = function ($scope, $routeParams, CustListFactory) {
        $scope.customerList = [];

                
        function init() {
            CustListFactory.getCustomers($routeParams.CustName, $routeParams.CustAddress, $routeParams.CustPhone, $routeParams.CustTerrNo)
                .success(function (customers) {
                    if ( angular.isArray(customers.getCustList.CUSTLIST.foundCustomers) ) {
                        $scope.customerList = customers.getCustList.CUSTLIST.foundCustomers;
                       
                        }
                    else {
                        $scope.customerList = [customers.getCustList.CUSTLIST.foundCustomers];
                        }
                
                })
                .error(function (data, status, headers, config) {
                    $log.log(data.error + ' ' + status);
                });
        }
        
        init();
        
        $scope.doSort = function(propName) {
           $scope.sortBy = propName;
           $scope.reverse = !$scope.reverse;
        };
            
        
        $scope.deleteCustomer = function(CUSTID) {
            CustListFactory.deleteCustomer(CUSTID)
                .success(function(status) {
                    if (status) {
                        for (var i=0,len=$scope.customerList.length;i<len;i++) {
                            if ($scope.customerList[i].foundAcctNo === CUSTID) {
                               $scope.customerList.splice(i,1);
                               break;
                            }
                        }  
                    }
                    else {
                        $window.alert('Unable to delete customer');   
                    }
                    
                })
                .error(function(data, status, headers, config) {
                    $log.log(data.error + ' ' + status);
                });
        };
        
        // add New Row
        $scope.addNewRow = function() {
                         
        $scope.inserted = {
            foundAcctNo: '',
            foundName: '',
            foundAddress: '',
            foundCity: '',
            foundState: '',
            foundZip: '',
            foundPhone: ''
            };
                         
            $scope.customerList.push($scope.inserted);                        
        };
        // Update/create Customer
        $scope.addCustomer = function(data) {
            CustListFactory.writeCustomer(data)
                .success(function(status){
                    if (status) {
                        $scope.newrec = "New Customer Added to DB";
                     }
                    else{ $scope.newrec = "Failed to write Customer Item";
                    }
            })
                .error(function(data, status, headers, config) {
                    $log.log(data.error + ' ' + status);
                });
        }
    };
    

    
    CustListController.$inject = ['$scope', '$routeParams', 'CustListFactory'];
    angular.module('Acme_Demo')
        .controller('CustListController', CustListController);
    
     
    
}());