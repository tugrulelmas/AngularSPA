angular.module('abioka')
.controller('mainController', ['$scope', 'context', 'translationService', function ($scope, context, translationService) {
    BaseCtrl.call(this, $scope, context, translationService);
}]);
