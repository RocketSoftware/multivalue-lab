angular.module('rt.encodeuri', []).filter('encodeUri', [
    '$window',
    function ($window) {
        return $window.encodeURIComponent;
    }
]);
