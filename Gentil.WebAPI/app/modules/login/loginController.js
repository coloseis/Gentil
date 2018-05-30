angular
    .module('gentilApp')
    .controller('loginController', loginController);

function loginController($scope, $session) {
    $scope.email = 'manningblankenship@quotezart.com';

    $session.clear();

    $scope.submit = function () {
        $scope.$broadcast('show-errors-check-validity', 'form');
        if ($scope.form.$valid) {
            $session.logIn($scope.email);
        }
    };
}