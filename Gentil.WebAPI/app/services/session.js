angular
    .module('gentilApp')
    .factory('$session', session);

function session($cookies, $window, $http, $location) {
    return {
        isLoggedIn: function () {
            return $cookies.get('XSRF-TOKEN') ? true : false;
        },
        clear: function () {
            $cookies.remove('XSRF-TOKEN');
            $location.path('/login');
        },
        logIn: function (user, password) {
            $http({
                method: "GET",
                url: 'login',
                params: { user: user, password: $window.btoa(password) },
                cache: false
            })
                .then(
                function (response) {
                    $cookies.put('XSRF-TOKEN', response.data);
                    $location.path('/');
                },
                function(response) {
                    alert('El nombre de usuario y la contraseña que ingresaste no coinciden con nuestros registros.\n\nPor favor, revisa e inténtalo de nuevo.');
                });
        }
    };
}