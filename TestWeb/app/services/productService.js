(function () {
    'use strict';

    angular
        .module('productApp')
        .factory('productService', productService);

    productService.$inject = ['$http'];
    var BASE_URL = 'http://localhost:61109/api/product/';
    function productService($http) {
        var service = {
            getAll: function () {
                return $http.get(BASE_URL);
            },
            create: function (product) {
                return $http.post(BASE_URL, product);
            },
            update: function (product) {
                return $http.put(BASE_URL + '/' + product.Id, product);
            },
            delete: function (id) {
                return $http.delete(BASE_URL + '/' + id);
            }
        };

        return service;

        
    }
})();