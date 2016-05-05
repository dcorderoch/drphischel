(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('PatientController', PatientController);
 
    PatientController.$inject = ['$location', 'PatientService', 'FlashService', '$rootScope','$scope'];
    function PatientController(location, PatientService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //CRUD
        $scope.allPatients = []; //Read
        $scope.deletePatient = deletePatient; //Delete
        $scope.editPatient = editPatient;   //Update
        $scope.createPatient= createPatient;    //Create
        
        //Crear
         $scope.showCreate = false;
        $scope.newPatient={};
        
        //Editar
        $scope.editPatientJson ={};
        $scope.showEdit = false;
        $scope.patientEditID;
        
        $scope.toggle = function() {
        
            $scope.showCreate = !$scope.showCreate;
        };
        
        $scope.toggle2 = function(patientID){
            
            $scope.showEdit = !$scope.showEdit;
            $scope.patientEditID = patientID;
        }
 
        initController();

        function initController() {
            loadAllPatients();
            console.log($scope.allPatients);
        }
        
        function loadAllPatients() {
            PatientService.GetAll()
                .then(function (patients) {
                    $scope.allPatients = patients.data;
            },function(){
                 FlashService.Error("Error al cargar pacientes");       
            });
        }

        function deletePatient(id) {
            console.log(id);
            PatientService.Delete(id)
            .then(function () {
                loadAllPatients();
                FlashService.Success('Eliminado de paciente exitoso', true);   
            },function(){
                FlashService.Error("Error al eliminar pacientes");       
            });
        }
        
        function editPatient(patient){
            
            $scope.editPatientJson.UserId = $scope.patientEditID;
            $scope.toggle2(" ");    
        
            PatientService.Update($scope.editPatientJson)
                .then(function() {
                    loadAllPatients();  
                    FlashService.Success('Actualización de paciente exitosos', true);
                    $scope.editPatientJson = {};
                },function(response){
                
                    FlashService.Error('Error en la actualización de paciente');
                });
        }
        
        function createPatient(){
            
            $scope.toggle();
            PatientService.Create($scope.newPatient)
                .then(function() {
                    loadAllPatients();
                    $scope.newPatient ={};   
                },function(response){
                    FlashService.Error('Error en la creacion de paciente');      
                });
        }
    }
 
})();