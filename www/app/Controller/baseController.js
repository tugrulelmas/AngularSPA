function BaseCtrl($scope, context, translationService) {
    var localResourceLoaded = false;
    var globalResourceLoaded = false;
    loadResources(function () {
        globalResourceLoaded = true;
    });

    $scope.ml = function (resourceName) {
        if (resourceName.indexOf("Global.") === 0 && globalResourceLoaded) {
            var globalResourceName = resourceName.substring(7, resourceName.length);
            return context.resources[globalResourceName];
        } else if (localResourceLoaded) {
            return $scope.resources[resourceName];
        }

        return resourceName;
    };

    $scope.$on('languageChanged', function (event) {
        loadResources(function () {
            if ($scope.$parent.isGlobalController) {
                noty({ text: $scope.ml("Global.LanguageChangedMessage"), layout: 'topRight', type: 'warning', timeout: 15000 });
            }
        });
    });

    function loadResources(callback) {
        translationService.setGlobalResources(callback);
        if ($scope.localResourceFile) {
            translationService.setLocalResources($scope,
                function () {
                    localResourceLoaded = true;
                });
        }
    }
}
