(function () {
    
    var InvoicesListController = function ($scope, $routeParams, InvoicesListFactory) {
            $scope.invoicesList = [];
            $scope.custName = ""
//        $scope.emptyArr = {prop1:null,prop2:null};
                
        function init() {
            InvoicesListFactory.getInvoices($routeParams.CustID)
                .success(function (invoices) {
                $scope.invoicesList = invoices.getInvoiceList.INVOICE_LIST;
                $scope.custName = invoiceList.custname;
                
	
                    if ( angular.isArray(invoices.getInvoiceList.INVOICE_LIST) ) {
                        $scope.invoicesList = invoices.getInvoiceList.INVOICE_LIST;
                       
                        }
                    else {
                        $scope.invoicesList = [invoices.getInvoiceList.INVOICE_LIST];
                        }
                
                })
                .error(function (data, status, headers, config) {
                    $log.log(data.error + ' ' + status);
                });
        }
        
        init();
        
    };
        InvoicesListController.$inject = ['$scope', '$routeParams', 'InvoicesListFactory'];
        angular.module('Acme_Demo')
        .controller('InvoicesListController', InvoicesListController);
    
     
    
}());