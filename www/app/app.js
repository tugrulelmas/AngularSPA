angular.module('abioka', ['ngRoute', 'ngSanitize', 'ngResource'])
.constant('abiokaSettings',
    {
        apiUrl: "http://localhost/AngularSPA.Api/api/"
    }
)
.value('context',
    {
        user: {
            lang: "en"
        },
        resources: {}
    }
)
.directive("modal", function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            scope.$parent.$parent.showModal = function () {
              element.modal('show');
            }
            scope.$parent.$parent.hideModal = function () {
                element.modal('hide');
            }
        }
    }
})
.directive("modalconfirm", function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            scope.$parent.$parent.$parent.showConfirmModal = function () {
                element.modal('show');
            }
            scope.$parent.$parent.$parent.hideConfirmModal = function () {
                element.modal('hide');
            }
        }
    }
})
.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
     .when('/home', { templateUrl: 'Views/main.html', controller: 'mainController' })
     .when('/customer', { templateUrl: 'Views/customer.html', controller: 'customerController' })
     .when('/product', { templateUrl: 'Views/product.html', controller: 'productController' })
     .when('/user', { templateUrl: 'Views/user.html', controller: 'userController' })
     .otherwise({ redirectTo: '/home' });

    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);
