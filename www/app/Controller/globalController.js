angular.module('abioka')
.controller('globalController', ['$scope', '$route', 'context', 'restService', 'translationService', function ($scope, $route, context, restService, translationService) {
    BaseCtrl.call(this, $scope, context, translationService);
    $scope.isGlobalController = true;

    $scope.changeLanguage = function (language) {
        var oldLanguage = context.user.lang;
        context.user.lang = language
        if (oldLanguage !== language) {
            $scope.$broadcast('languageChanged');
        }
    };

    function setCompanyCaption() {
        $scope.companyCaption = $scope.ml("Global.Company") + ": " + context.user.company.Name;
    };
}]);
