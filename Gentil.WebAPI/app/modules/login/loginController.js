angular
    .module('gentilApp')
    .controller('loginController', loginController);

function loginController($scope, $session) {
    $session.clear();

    $scope.submit = function () {
        $scope.$broadcast('show-errors-check-validity', 'form');
        if ($scope.form.$valid) {
            $session.logIn($scope.user, $scope.password);
        }
    };
}