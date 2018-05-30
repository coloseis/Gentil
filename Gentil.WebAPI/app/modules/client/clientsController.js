angular
    .module('gentilApp')
    .controller('clientsController', clientsController);

function clientsController($scope, $http) {
    $http({ method: "GET", url: 'api/client', cache: false })
        .then(
        function (response) {
            $scope.clients = response.data;
        },
        function (response) { });
}