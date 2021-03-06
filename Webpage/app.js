(function () {
    'use strict';
 //El modulo principal del proyecto
    angular
        .module('app', ['ngRoute', 'ngCookies', 'ui.calendar']) //se llama a ngRoute (routeo entre paginas, ngCookies para cookies)
        .config(config)   //funcion de config se llama de primero, no hay que cambiarlo
        .run(run);
      //la funcion run se llama de primero tambien, no hay que cambiarlo
    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {  //Inyectar dependencias de routeProvider y locationProvider 
        $routeProvider
                                      //un alias del controlador, vm significa view model

            .when('/acceptDoctor',{
                controller: 'AcceptDoctorController',
                templateUrl: 'acceptDoctor/acceptDoctor.view.html',
                controlerAs: 'vm'           
            })
            .when('/addSpecialities',{
                controller: 'AddSpecialityController',
                templateUrl: 'addSpecialities/addSpecialities.view.html',
                controlerAs: 'vm'
            })   
        
            .when('/appointment',{
                controller:  'AppointmentController', 
                templateUrl: 'appointment/appointment.view.html', 
                controlerAs: 'vm'
            })
        
            .when('/prescription',{
                controller:  'PrescriptionController', 
                templateUrl: 'prescription/prescription.view.html', 
                controlerAs: 'vm'
            })

            .when('/charge',{
                controller: 'ChargeController',
                templateUrl: 'charge/charge.view.html',
                controlerAs: 'vm'           
            })

            .when('/checkRecord',{
                controller: 'CheckRecordController',
                templateUrl: 'checkRecord/checkRecord.view.html',
                controlerAs: 'vm'           
            })
            .when('/createAppointment',{
                controller: 'CreateAppointmentController',
                templateUrl: 'createAppointment/createAppointment.view.html',
                controlerAs: 'vm'           
            })
            .when('/createPatient',{
                controller: 'CreatePatientController',
                templateUrl: 'createPatient/createPatient.view.html',
                controlerAs: 'vm'           
            })
            .when('/', {
                controller: 'HomeController',//esta es la extension de url que sucede cuando se esta en el HomeController
                templateUrl: 'home/home.view.html',  //El controlador de este when home.controller.js
                controllerAs: 'vm'     //Vista es el archivo home/home.view.html
            })      
            .when('/homeA',{
                controller: 'HomeAController',
                templateUrl: 'homeA/homeA.view.html',
                controlerAs: 'vm'           
            })
            .when('/homeP',{
                controller: 'HomePController',
                templateUrl: 'homeP/homeP.view.html',
                controlerAs: 'vm'           
            })
           .when('/login', {
                controller: 'LoginController',
                templateUrl: 'login/login.view.html',
                controllerAs: 'vm'
            })
            .when('/newDoctor',{
                controller: 'NewDoctorController',
                templateUrl: 'newdoctor/newdoctor.view.html',
                controlerAs: 'vm'
            })
            .when('/order',{
                controller:  'OrderController', 
                templateUrl: 'order/order.view.html', 
                controlerAs: 'vm'
            })
            .when('/patient',{
                controller: 'PatientController',
                templateUrl: 'patient/patient.view.html',
                controlerAs: 'vm'
            }) 
            .when('/record',{
                controller: 'RecordController',
                templateUrl: 'record/record.view.html',
                controlerAs: 'vm'           
            })
            .when('/sync',{
                controller: 'SyncController',
                templateUrl: 'sync/sync.view.html',
                controlerAs: 'vm'           
            })

            .otherwise({ redirectTo: '/login' });//Esta es la url por defecto
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];  //cosas que se corren al comienzo del proyecto
    function run($rootScope, $location, $cookieStore, $http) {      //no hay que modificar esto
        // Mantener al usuario logeado cuando se refresca la pagina
     
        $rootScope.globals = $cookieStore.get('globals') || {}; // Se mantiene el usuario
        if ($rootScope.globals.currentUser) {                            // se crean las cookies
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
//            // Redirige a la pagina de login cuando se intenta hacer trampa (Watch out evil-doers)
//            var restrictedPage = $.inArray($location.path(), ['/login']) === -1;
//            var loggedIn = $rootScope.globals.currentUser;
//            if (restrictedPage && !loggedIn) {
//                $location.path('/login');
//            }//Si intenta meterse en una pagina restringida
//            // redirect to login page if not logged in and trying to access a restrictedPage page
        });
    }

})();