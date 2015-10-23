angular.module('abioka')
.controller('userController', ['$scope', 'context', 'restService', 'translationService', function ($scope, context, restService, translationService) {
    $scope.localResourceFile = "Resources/Definition/user";
    $scope.apiName = "User";
    BaseRepositoryCtrl.call(this, $scope, context, translationService, restService);

    $scope.messageKey = function () {
        return $scope.selectedModel.Code + " - " + $scope.selectedModel.Name;
    }
}]);
