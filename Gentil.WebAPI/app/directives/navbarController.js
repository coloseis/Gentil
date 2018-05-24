angular
    .module('gentilApp')
    .controller('navbarController', function ($scope, $session) {
        $scope.isLoggedIn = function () { return $session.isLoggedIn() };
        $scope.logOut = function () { return $session.clear() };
    })
    .directive('navbar', [
        function () {
            return {
                restrict: 'E',
                controller: 'navbarController',
                templateUrl: './app/directives/navbar.html'
            }
        }
    ]);