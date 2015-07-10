(function () {
    
    var InvoiceController = function ($scope, $routeParams, InvoiceFactory) {
            $scope.Thisinvoice = [];
            
                
        function init() {
            InvoiceFactory.getInvoice($routeParams.InvoiceID)
                .success(function (CustInvoice) {
                    $scope.Thisinvoice = CustInvoice.getInvoice.INVOICE_ITEM;
                    $scope.custAccount = Thisinvoice.custAccount;  // by doing this the rest of the references work for the single valued items
                
	
                    if ( angular.isArray(CustInvoice.getInvoice.INVOICE_ITEM) ) {
                        $scope.Thisinvoice = CustInvoice.getInvoice.INVOICE_ITEM;
                        $scope.custAccount = Thisinvoice.custAccount;  // by doing this the rest of the references work for the single valued items
                        }
                    else {
                        $scope.Thisinvoice = [CustInvoice.getInvoice.INVOICE_ITEM];
                        $scope.custAccount = Thisinvoice.custAccount;  // by doing this the rest of the references work for the single valued items
                        }
                
                })
                .error(function (data, status, headers, config) {
                    $log.log(data.error + ' ' + status);
                });
        }
        
        init();
        
    };
        InvoiceController.$inject = ['$scope', '$routeParams', 'InvoiceFactory'];
        angular.module('Acme_Demo')
        .controller('InvoiceController', InvoiceController);     
    
}());