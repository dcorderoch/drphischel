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
        $scope.selection=[];


        initController();
        
        function initController() {
            loadAllSpecialitiesK();
            $scope.medicSpecialities.push({"Name":"Nicolas", MedicalSpecialtyId:"123"});
            $scope.medicSpecialities.push({"Name":"Alfonso",MedicalSpecialtyId:"456"});
            $scope.medicSpecialities.push({"Name":"Emmanuel",MedicalSpecialtyId:"789"});
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
            $scope.newDoc.Specialties=  $scope.selection;
            $scope.newDoc.Approved ="false";
            console.log($scope.newDoc);
            DoctorService.Create($scope.newDoc)
                .then(function() {
                    $scope.newDoc ={};   
                },function(response){
                    FlashService.Error('Error en la creacion de doctor');      
                });
        }
        
            // toggle selection for a given spec by name
        $scope.toggleSelection = function toggleSelection(specialtyId) {
            var idx = $scope.selection.indexOf(specialtyId);
 
             // is currently selected
             if (idx > -1) {
               $scope.selection.splice(idx, 1);
             }

             // is newly selected
             else {
               $scope.selection.push(specialtyId);
             }
        };
        
    }
})();
