(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('NewDoctorController', NewDoctorController);
 
    NewDoctorController.$inject = ['$location', 'DoctorService', 'SpecialityService','FlashService', '$rootScope','$scope'];
    function NewDoctorController(location, DoctorService, SpecialityService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //Tomar especialidades
        $scope.medicSpecialities = []; //Read
        //Crear
        $scope.createDoctor= createDoctor;    //Create
        $scope.newDoc={};

        initController();
        
        function initController() {
            loadAllSpecialitiesK();
        }
        
        function loadAllSpecialitiesK() {
            
            SpecialityService.GetAll()
                .then(function (specialities) {
                    $scope.medicSpecialities = specialities.data;
            },function(){
                 FlashService.Error("Error al cargar especialidades");       
            });
        }
        
        function createDoctor(){
            
            DoctorService.Get($scope.newDoc)
                .then(function() {
                    $scope.newDoc ={};   
                },function(response){
                    FlashService.Error('Error en la creacion de doctor');      
                });
        }
        
        function loadPendingDoctors() {
            DoctorService.GetPending()
                .then(function (doctors) {
                    $scope.allDoctors = doctors.data;
            },function(){
                 FlashService.Error("Error al cargar doctores pendientes");       
            });
        }
    }
 
})();
