namespace GradeBook2 {

    angular.module('GradeBook2', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: GradeBook2.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: GradeBook2.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: GradeBook2.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: GradeBook2.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: GradeBook2.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: GradeBook2.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('classSelection', {
                url: '/classSelection',
                templateUrl: '/ngApp/views/classSelection.html',
                controller: GradeBook2.Controllers.ClassSelectionController,
                controllerAs: 'controller'
            })
            .state('studentView', {
                url: '/studentView',
                templateUrl: '/ngApp/views/studentView.html',
                controller: GradeBook2.Controllers.StudentViewController,
                controllerAs: 'controller'
            })
            .state('instructorLogin', {
                url: '/instructorLogin',
                templateUrl: '/ngApp/views/instructorLogin.html',
                controller: GradeBook2.Controllers.InstructorLoginController,
                controllerAs: 'controller'
            })
            .state('studentDetails', {
                url: '/studentDetails/:id',
                templateUrl: '/ngApp/views/studentDetails.html',
                controller: GradeBook2.Controllers.StudentDetailsController,
                controllerAs: 'controller'
            })
            .state('notFound', {
            url: '/notFound',
            templateUrl: '/ngApp/views/notFound.html'
        });

    // Handle request for non-existent route
    $urlRouterProvider.otherwise('/notFound');

    // Enable HTML5 navigation
    $locationProvider.html5Mode(true);
});


angular.module('GradeBook2').factory('authInterceptor', (
    $q: ng.IQService,
    $window: ng.IWindowService,
    $location: ng.ILocationService
) =>
    ({
        request: function (config) {
            config.headers = config.headers || {};
            config.headers['X-Requested-With'] = 'XMLHttpRequest';
            return config;
        },
        responseError: function (rejection) {
            if (rejection.status === 401 || rejection.status === 403) {
                $location.path('/login');
            }
            return $q.reject(rejection);
        }
    })
);

angular.module('GradeBook2').config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptor');
});

    

}
