(function () {
    'use strict';

    angular
        .module('app')   //Pertenece al modulo app de app.js
        .controller('LoginController', LoginController);//Nombre del controlador, se debe poner 2 veces.


//Injeccion de dependencias: Location: para URL, AuthenServ.. $scope se utiliza para variables locales que se pueden 
//usar en la vista tambien. http es lo de rest. 
    LoginController.$inject = ['$location', 'AuthenticationService', 'FlashService','$scope','$http', '$rootScope'];
    function LoginController($location, AuthenticationService, FlashService, $scope, $http, $rootScope) {

        var vm = this; //se pueden utilizar objetos y variables de las inyecciones en la vista
        $scope.roles=[{"id":1,"Name":"Paciente"},{"id":2,"Name":"Doctor"},{"id":3,"Name":"Admin"}];
        $scope.login = login;
        $scope.loginData={};


        initController();
        function initController() { // Se inicializa el servicio de limpiar credenciales en AuthenticationService       
           // AuthenticationService.ClearCredentials();
            console.log($scope.roles);
        }//Estos parentesis del final indican que esto se inicia automaticamente

        function login(selectedRol) {
            $scope.dataLoading = true; 
            console.log(selectedRol);
            if (selectedRol.id==1){
                AuthenticationService.Login( $scope.loginData)
                    .then(function(response){
                        
                        $rootScope.userId= response.data.UserId;
                        $rootScope.patientName = response.data.Name;
                        $location.path('/homeP');
                    },function(response){
                        FlashService.Error("Paciente no existe");//errores
                        $scope.dataLoading = false;
                });                   
            }
            else if (selectedRol.id==2){
                AuthenticationService.Login( $scope.loginData)
                    .then(function(response){
                    
                        $rootScope.doctorId= response.data.UserId;
                        $rootScope.doctorName = response.data.Name;        
                        $location.path('/');
                    },function(response){
                        FlashService.Error("Doctor no existe");//errores
                        $scope.dataLoading = false;
                });  
            }
            else{
                AuthenticationService.Login( $scope.loginData)
                    .then(function(response){
                    
                        $rootScope.adminName = response.data.Name;   
                        $location.path('/homeA');
                    },function(response){
                        FlashService.Error("Admin no existe");//errores
                        $scope.dataLoading = false;
                });  
            }
        }
    }
}) ();