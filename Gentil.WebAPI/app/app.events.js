//AUTENTICAR ON ROUTE CHANGE
angular.module('gentilApp')
    .run(appRun);

function appRun($rootScope, $session, $location) {
    $rootScope.$on('$routeChangeStart', function (evt, next, curr) {
        
        if (!$session.isLoggedIn() && next.originalPath !== "/login") {
            $location.path('/login');
        }

        if ($session.isLoggedIn() && next.originalPath === "/login") {
            $session.clear();
        }

        return;
    });
}