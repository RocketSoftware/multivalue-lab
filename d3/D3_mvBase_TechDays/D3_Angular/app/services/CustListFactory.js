(function () {
    var CustListFactory = function($http) {
    
    var factory = {};
    factory.getCustomers = function(CustName, CustAddress, CustPhone, CustTerrNo)
    {       
         
       return $http.get('http://localhost:8181/Invoices/getCustList' + '?NAMES='+ CustName + '&ADDRS=' + CustAddress + '&PHONE=' + CustPhone + '&STERR=' + CustTerrNo); // change host address etc to yours or pull from a config file etc.
    };
    
    factory.deleteCustomer = function(CUSTID) {
            return $http.get('http://localhost:8181/Invoices/delete_cust_item' + '?CUSTID=' + CUSTID); // change host address etc to yours or pull from a config file etc.
        }
    factory.writeCustomer = function(data) {
            return $http.get('http://localhost:8181/Invoices/writecustitem' + '?CUSTID='+ data.AcctNo + '&NAME=' + data.Name + '&ADDR=' + data.Address + '&CITY=' + data.City + '&STATE=' + data.State + '&ZIP=' + data.Zip + '&PHONE=' + data.Phone); // change host address etc to yours or pull from a config file etc.
    };
    
    return factory;
    };
    
    CustListFactory.$inject = ['$http'];
    angular.module('Acme_Demo').factory('CustListFactory', CustListFactory); 
    
    }());