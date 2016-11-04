(function () {
    'use strict';
    app.controller('signInCtrl', ['$scope', '$rootScope', '$http', '$cookies', '$cookieStore', '$state', '$stateParams', function ($scope, $rootScope, $http, $cookies, $cookieStore, $state, $stateParams) {
        $scope.message = $stateParams.message;
        $scope.signIn = function () {
            $scope.showMessage = false;
            var params = "grant_type=password&username=" + $scope.username + "&password=" + $scope.password;
            $http({
                url: '/Token',
                method: "POST",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                data: params
            })
            .success(function (data, status, headers, config) {
                $http.defaults.headers.common.Authorization = "Bearer " + data.access_token;
                $http.defaults.headers.common.RefreshToken = data.refresh_token;

                $cookieStore.put('_Token', data.access_token);
                $state.go('home');
            })
            .error(function (data, status, headers, config) {
                $scope.message = data.error_description.replace(/["']{1}/gi, "");
                $scope.showMessage = true;
            });
        }
    }]);
})();