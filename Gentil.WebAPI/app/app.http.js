angular
    .module('gentilApp')
    .factory('HttpProviderInterceptorService', httpProviderInterceptor);

angular
    .module('gentilApp')
    .config(function ($httpProvider) {
        $httpProvider.interceptors.push('HttpProviderInterceptorService');
    });

function httpProviderInterceptor($q, $location, $cookies) {
    return {
        responseError: responseError
    };

    function responseError(response) {
        switch (response.status) {
            case 304:
                return $q.resolve(response);
            case 400:
                var msg = response.statusText;
                if (response.data && response.data.Message) {
                    msg += '\n\n' + response.data.Message;
                }
                alert(msg);
                break;
            case 401:
                $cookies.remove('XSRF-TOKEN');
                $location.path('/login');
                break;
            case 403:
                alert('Acceso prohibido');
                $location.path("/");
                //$location.path('/forbidden');
                break;
            case 404:
            case 405:
                alert(response.statusText);
                //$location.path('/notfound');
                break;
            case 500:
                var msg = response.statusText;
                if (response.data && response.data.ExceptionMessage) {
                    msg += '\n\n' + response.data.ExceptionMessage;
                }
                alert(msg);
                //$location.path('/error');
                break;
        }
        return $q.reject(response);
    };
};