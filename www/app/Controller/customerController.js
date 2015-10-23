angular.module('abioka')
.controller('customerController', ['$scope', 'context', 'restService', 'translationService', function ($scope, context, restService, translationService) {
    $scope.localResourceFile = "Resources/Definition/customer";
    $scope.apiName = "Customer";
    BaseRepositoryCtrl.call(this, $scope, context, translationService, restService);
}]);
