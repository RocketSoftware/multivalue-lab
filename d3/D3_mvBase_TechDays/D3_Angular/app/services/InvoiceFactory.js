(function () {
    var InvoiceFactory = function($http) {
    
    var factory = {};
    factory.getInvoice = function(InvoiceID)
    {       
         
       return $http.get('http://localhost:8181/Invoices/getInvoice' + '?INVOICE_NO='+ InvoiceID); // change host address etc to yours or pull from a config file etc.
    };
    
    return factory;
    };
    
    InvoiceFactory.$inject = ['$http'];
    angular.module('Acme_Demo').factory('InvoiceFactory', InvoiceFactory); 
    }());