angular
    .module('gentilApp')
    .controller('usuariosController', ['$scope', 'Usuario', usuariosController]);

function usuariosController($scope, Usuario) {
    Usuario.query().$promise.then(function (users) {
        $scope.users = users;
    });

    $scope.nuevo = function() {
        alert('nuevo');
    };

    $scope.borrar = function (id) {
        alert(id);
    };
}