angular
    .module('gentilApp')
    .controller('policiesController', policiesController);

function policiesController($scope, $http, $routeParams) {
    $http({ method: "GET", url: 'api/client/' + $routeParams.name, cache: false })
        .then(
            function (response) {
                $scope.ClientName = response.data.Name;
            },
            function (response) { });

    $http({ method: "GET", url: 'api/client/' + $routeParams.name + '/policies', cache: false })
        .then(
            function (response) {
                $scope.policies = response.data;
            },
            function (response) { });
    
}