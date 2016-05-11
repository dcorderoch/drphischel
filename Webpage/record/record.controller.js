(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('RecordController', RecordController);
 
    RecordController.$inject = ['$location', 'RecordService', 'PatientService', 'PrescriptionService', 'FlashService', '$rootScope','$scope'];
    function RecordController(location, RecordService, PatientService, PrescriptionService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //variable del nuevo record a agregar
        $scope.newRecord={};
        
        //funciones que se llaman en la vista 
        $scope.createRecord= createRecord;  //variables locales y para vistas
        $scope.patientChosed = patientChosed;
        
        //Pacientes y prescripciones extraidos del servidor
        $scope.patients=[];
        $scope.prescriptions=[];
        
        //Id de paciente obtenido de la vista y variable para esconder y mostrar el form de creare record.
        $scope.patientId;
        $scope.showPatient = false;
        
        initController();
        
        function initController() {
            
            loadAllPatients();

             $scope.prescriptions.push({"UserId":"Nicolas", PrescriptionId:"123"});
            $scope.prescriptions.push({"UserId":"Nicolas",PrescriptionId:"456"});
            $scope.prescriptions.push({"UserId":"Nicolas",PrescriptionId:"789"});
        };
        
        
        function createRecord(selectedPrescription){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
            $scope.newRecord.PrescriptionId = selectedPrescription.PrescriptionId;
            RecordService.Create($scope.newRecord)
            .then(function(response) {
                 $scope.dataLoading=false; 
                    FlashService.Success('Historial clínico agregado',true);  //si funco se muestra un approve
                     $scope.newRecord={};
                },function(response){ 
                    FlashService.Error(response.status);
                    $scope.dataLoading= false;
                    $scope.newRecord={};
            });
        }
        
        function loadAllPrescriptions(){
            PrescriptionService.GetByDoctor($rootScope.doctorId)
                .then(function(prescriptions){
                    $scope.prescriptions = prescriptions;
                    
                }, function(){
                    FlashService.Error("Error al cargar medicinas");
            });
        }
        
        function loadAllPatients(){
            PatientService.GetByMedic($rootScope.doctorId)
                .then(function(users){
                    $scope.patients = users;
                loadAllPrescriptions();
                    
                }, function(){
                    FlashService.Error("Error al cargar pacientes del doctor");
            });
        }        
        
        function patientChosed(selectedPatient){
            
            $scope.showPatient = true;
            $scope.patientId=selectedPatient.UserId;
            loadAllPrescriptions();
          }
        
              
    }
} ) ();  // La funcion se auto llama
///importante no se pueden hacer dos pedidos (con y sin prescripcion al mismo tiempo)