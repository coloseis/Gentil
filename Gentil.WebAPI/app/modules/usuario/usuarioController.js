angular
    .module('gentilApp')
    .controller('usuarioController', usuarioController);

function usuarioController($scope, $location, $routeParams, Usuario) {
    $scope.id = $routeParams.id;

    if ($scope.id) {
        $scope.usuario = Usuario.get({ id: $scope.id });
    } else {
        $scope.usuario = new Usuario();
    }

    $scope.submit = function () {
        $scope.$broadcast('show-errors-check-validity', 'form');
        if ($scope.form.$valid) {
            if ($scope.id) {
                Usuario.update($scope.usuario, function () { $location.path('/usuarios'); }, function () { });
            } else {
                Usuario.save($scope.usuario, function () { $location.path('/usuarios'); }, function () { });
            }
        }
    };
}