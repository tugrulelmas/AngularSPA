angular.module('abioka')

.service('translationService', ['$resource', 'context', function ($resource, context) {
    function getRecources(languageFilePath, callback) {
        if (sessionStorage) {
            if (sessionStorage.getItem(languageFilePath)) {
                callback(JSON.parse(sessionStorage.getItem(languageFilePath)));
            } else {
                $resource(languageFilePath).get(function (data) {
                    sessionStorage.setItem(languageFilePath, JSON.stringify(data));
                    callback(data);
                });
            };
        } else {
            $resource(languageFilePath).get(function (data) {
                callback(data);
            });
        }
    }

    this.setGlobalResources = function (callback) {
        var languageFilePath = 'Resources/Global_' + context.user.lang + '.json';
        getRecources(languageFilePath, function (data) {
            context.resources = data;
            callback();
        });
    };

    this.setLocalResources = function ($scope, callback) {
        var languageFilePath = $scope.localResourceFile + "_" + context.user.lang + '.json';
        getRecources(languageFilePath, function (data) {
            $scope.resources = data;
            callback();
        });
    };
}]);
