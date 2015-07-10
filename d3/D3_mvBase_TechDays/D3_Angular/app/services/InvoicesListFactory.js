(function () {
    var InvoicesListFactory = function($http) {
    
    var factory = {};
    factory.getInvoices = function(CustID)
    {       
         
       return $http.get('http://localhost:8181/Invoices/getInvoiceList' + '?CUST_ACCT='+ CustID); // change host address etc to yours or pull from a config file etc.
    };
    
    return factory;
    };
    
    InvoicesListFactory.$inject = ['$http'];
    angular.module('Acme_Demo').factory('InvoicesListFactory', InvoicesListFactory); 
    }());