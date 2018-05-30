angular.module('gentilApp')
    .config(ConfigRouteProvider);

function ConfigRouteProvider($routeProvider) {
    var modules = 'app/modules/';
    $routeProvider
        .when('/', {
            templateUrl: modules + 'home/home.html',
            controller: 'homeController'
        })
        .when('/login', {
            templateUrl: modules + 'login/login.html',
            controller: 'loginController'
        })
        .when('/clients', {
            templateUrl: modules + 'client/clients.html',
            controller: 'clientsController'
        })
        .when('/client/:name/policies', {
            templateUrl: modules + 'client/policies.html',
            controller: 'policiesController'
        })
        .otherwise({
            redirectTo: '/'
        });
}