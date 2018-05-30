angular
    .module('gentilApp')
    .controller('homeController', homeController);

function homeController($scope, $http) {
    $scope.getClientByID = function () {
        $scope.id = 'a0ece5db-cd14-4f21-812f-966633e7be86';

        $http({ method: "GET", url: 'api/client/' + $scope.id, cache: false })
            .then(
            function (response) {
                alert(JSON.stringify(response.data));
            },
            function (response) { });
    };

    $scope.getClientByName = function () {
        $scope.name = 'Manning';

        $http({ method: "GET", url: 'api/client/' + $scope.name, cache: false })
            .then(
            function (response) {
                alert(JSON.stringify(response.data));
            },
            function (response) { });
    };

    $scope.getPoliciesByClientName = function () {
        $scope.name = 'Manning';

        $http({ method: "GET", url: 'api/client/' + $scope.name + '/policies', cache: false })
            .then(
            function (response) {
                alert(JSON.stringify(response.data));
            },
            function (response) { });
    };

    $scope.getClientByPolicyId = function () {
        $scope.id = '64cceef9-3a01-49ae-a23b-3761b604800b';

        $http({ method: "GET", url: 'api/policy/' + $scope.id + '/client', cache: false })
            .then(
            function (response) {
                alert(JSON.stringify(response.data));
            },
            function (response) { });
    };

}