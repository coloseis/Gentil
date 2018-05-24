var usuarioService = angular.module('usuarioService', ['ngResource']);

usuarioService.factory('Usuario', ['$resource',
    function ($resource) {
        return $resource('api/users/:id', { id: "@id" }, {
            update: { method: 'PUT' }
        });
    }]);