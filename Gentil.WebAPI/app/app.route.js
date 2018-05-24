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
        .when('/usuarios', {
            templateUrl: modules + 'usuario/usuarios.html',
            controller: 'usuariosController'
        })
        .when('/usuario', {
            templateUrl: modules + 'usuario/usuario.html',
            controller: 'usuarioController'
        })
        .when('/usuario/:id', {
            templateUrl: modules + 'usuario/usuario.html',
            controller: 'usuarioController'
        })
        .otherwise({
            redirectTo: '/'
        });
}