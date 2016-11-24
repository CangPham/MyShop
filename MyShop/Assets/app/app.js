var app = angular.module('app', [
    'ui.router',
    'ngCookies',
    'ngResource',
    'datatables'
]);

app.config(['$provide', '$stateProvider', '$urlRouterProvider', '$httpProvider', function ($provide, $stateProvider, $urlRouterProvider, $httpProvider) {

    //================================================
    // Ignore Template Request errors if a page that was requested was not found or unauthorized.  The GET operation could still show up in the browser debugger, but it shouldn't show a $compile:tpload error.
    //================================================
    $provide.decorator('$templateRequest', ['$delegate', function ($delegate) {
        var mySilentProvider = function (tpl, ignoreRequestError) {
            return $delegate(tpl, true);
        }
        return mySilentProvider;
    }]);

    //================================================
    // Add an interceptor for AJAX errors
    //================================================
    $httpProvider.interceptors.push(['$q', '$location', function ($q, $location) {
        return {
            'responseError': function (response) {
                if (response.status === 401)
                    $location.url('/signin');
                return $q.reject(response);
            }
        };
    }]);

    //================================================
    // Routes
    //================================================

    $urlRouterProvider.otherwise('/dashboard/home');

    $stateProvider
        //.state('index', {
        //    url: '', // Catch 'Admin Centre home page' Requests without '#' character.
        //    controller: ['$rootScope', '$scope', '$state', function ($rootScope, $scope, $state) {
        //        console.log($rootScope.loggedIn)
        //        // Check if current user authenicated.
        //        $scope.isAuthenicated = $rootScope.loggedIn;
        //        if ($scope.isAuthenicated) {
        //            // for authenicated user, redirect to Home page.
        //            $state.go('home');
        //        } else {
        //            // for unauthenicated user, redirect to Login page.
        //            $state.go('signin');
        //        }
        //    }]
        //})
          .state('base', {
              abstract: true,
              url: '',
              templateUrl: 'Assets/app/views/base.html'
          })
            .state('signin', {
                url: '/signin',
                parent: 'base',
                templateUrl: 'Assets/app/account/login.html',
                controller: 'signInCtrl'
            })
            .state('register', {
                url: '/register',
                parent: 'base',
                templateUrl: 'Assets/app/account/register.html',
                controller: 'registerCtrl'
            })
           .state('dashboard', {
               url: '/dashboard',
               parent: 'base',
               templateUrl: 'Assets/app/views/dashboard.html'
           })
            .state('home', {
                url: '/home',
                parent: 'dashboard',
                templateUrl: 'Assets/app/home/index.html',
                controller: 'homeCtrl'
            })
            .state('category', {
                url: '/category',
                parent: 'dashboard',
                templateUrl: 'Assets/app/category/index.html',
                controller: 'categoriesCtrl',
                controllerAs: 'vm'
            });

}]);

app.run(['$http', '$cookies', '$cookieStore', function ($http, $cookies, $cookieStore) {
    //If a token exists in the cookie, load it after the app is loaded, so that the application can maintain the authenticated state.
    $http.defaults.headers.common.Authorization = 'Bearer ' + $cookieStore.get('_Token');
    $http.defaults.headers.common.RefreshToken = $cookieStore.get('_RefreshToken');
}]);


//GLOBAL FUNCTIONS - pretty much a root/global controller.
//Get username on each page
//Get updated token on page change.
//Logout available on each page.
app.run(['$rootScope', '$http', '$cookies', '$cookieStore', '$state', function ($rootScope, $http, $cookies, $cookieStore, $state) {

    $rootScope.logout = function () {

        $http.post('/api/Account/Logout')
            .success(function (data, status, headers, config) {
                $http.defaults.headers.common.Authorization = null;
                $http.defaults.headers.common.RefreshToken = null;
                $cookieStore.remove('_Token');
                $cookieStore.remove('_RefreshToken');
                $rootScope.username = '';
                $rootScope.loggedIn = false;
                window.location = '#/signin';
            });

    }

    $rootScope.$on('$stateChangeSuccess', function (event) {
        if ($http.defaults.headers.common.RefreshToken != null) {
            var params = "grant_type=refresh_token&refresh_token=" + $http.defaults.headers.common.RefreshToken;
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
                $cookieStore.put('_RefreshToken', data.refresh_token);

                $http.get('/api/WS_Account/GetCurrentUserName')
                    .success(function (data, status, headers, config) {
                        if (data != "null") {
                            $rootScope.username = data.replace(/["']{1}/gi, "");//Remove any quotes from the username before pushing it out.
                            $rootScope.loggedIn = true;
                        }
                        else
                            $rootScope.loggedIn = false;
                    });


            })
            .error(function (data, status, headers, config) {
                $rootScope.loggedIn = false;
            });
        }
    });

    $rootScope.$on('$stateChangeStart', function (event) {        
        if ($http.defaults.headers.common.RefreshToken == null) {
            window.location = '#/signin';
        }
    });
}]);

