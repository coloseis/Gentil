angular
    .module('gentilApp')
    .controller('usuariosController', usuariosController);

function usuariosController($scope, $filter, Usuario) {
    $scope.load = function () {
        Usuario.query().$promise.then(function (users) {
            $scope.users = users;
        });
    };

    $scope.nuevo = function () {
        alert('nuevo');
    };

    $scope.borrar = function (id) {
        var item = $filter('filter')($scope.users, { ID: id })[0];
        var borrar = confirm('¿Está seguro de que desea eliminar este usuario de forma permanente?\n\nUsuario:' + item.Name + '\nRol:' + item.Role);

        if (borrar) {
            Usuario.delete({ id: id }, function () { $scope.load(); }, function () { });
        }
    };

    $scope.load();
}