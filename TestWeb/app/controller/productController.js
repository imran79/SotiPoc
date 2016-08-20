(function () {
    'use strict';
    angular
      .module('productApp')
      .controller('productController', function ($scope, productService) {
          $scope.activeProductId = null;

          $scope.products = productService.getAll();
          $scope.delete = function (product) {
              productService.delete(product.Id).success(function () {
                  console.log('product deleted successfully')
                  getAll();
              }).error(function () {
                  console.log(error);
              });
          };

          $scope.create = function (product) {
              productService.create(product).success(function () {
                  console.log('product added successfully');
                  getAll();
                  $('#ProductName').text = '';
                  $('#Description').text = '';
              }).error(function () {
                  console.log(error);
              });              
          };

       
          $scope.update = function (product) {
              $scope.activeProductId = null;
              productService.update(product).success(function () {
                  console.log('product updated successfully');
                  getAll();
              }).error(function () {
                  console.log(error);
              });
          };
         

          $scope.edit = function (product) {
              $scope.activeProductId = product.Id;
          }

          var getAll = function getAll() {
              productService.getAll().success(function (data) {
                  $scope.products = data;
              }).error(function (error) {
                  console.log(error);
              })
          }

          var init = function () {
              getAll();             
          }
          init();
      });   

}());
