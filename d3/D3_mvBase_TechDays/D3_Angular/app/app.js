(function () {
    
    var app = angular.module('Acme_Demo', ['ngRoute', 'rt.encodeuri', 'ngAnimate', 'xeditable', 'angular-loading-bar']);
    
    app.config(function(cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = true; });
               
    app.config(function ($routeProvider) {

        $routeProvider
            .when('/',
                  {
                    templateUrl: 'app/views/CustSearch.html'
                })
            .when('/CustList/:CustName?/:CustAddress?/:CustPhone?/:CustTerrNo?',
                  {
                    controller: 'CustListController',
                    templateUrl: 'app/views/CustList.html'
                })
        
            .when('/CustInvoices/:CustID',
                  {
                    controller: 'InvoicesListController',
                    templateUrl: 'app/views/CustInvoices.html'
                })
        
            .when('/Invoice/:InvoiceID',
                  {
                    controller: 'InvoiceController',
                    templateUrl: 'app/views/CustInvoice.html'
                })
        
            .otherwise({ redirectTo: '/'});

    });
    
    app.run(function(editableOptions, editableThemes) {
        editableThemes.bs3.inputClass = 'input-sm';
        editableThemes.bs3.buttonsClass = 'btn-sm';
        editableOptions.theme = 'bs3';
    });
    
}());