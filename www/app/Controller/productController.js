angular.module('abioka')
.controller('productController', ['$scope', 'context', 'restService', 'translationService', function ($scope, context, restService, translationService) {
    $scope.localResourceFile = "Resources/Definition/product";
    $scope.apiName = "Product";
    BaseRepositoryCtrl.call(this, $scope, context, translationService, restService);
}]);
