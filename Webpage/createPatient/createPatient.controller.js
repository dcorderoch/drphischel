(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('CreatePatientController', CreatePatientController);
 
    CreatePatientController.$inject = ['$location', 'PatientService', 'FlashService', '$rootScope','$scope'];
    
    function CreatePatientController(location, PatientService, FlashService, $rootScope, $scope) {
        var vm = this;
      
        //Crear
        $scope.newPatient={};
        $scope.createPatient= createPatient;    //Create
    
        function createPatient(){
            
            PatientService.Create($scope.newPatient)
                .then(function() {
                    $scope.newPatient ={};   
                },function(response){
                    FlashService.Error('Error en la creacion de paciente');      
                });
        }
    }
 
})();
