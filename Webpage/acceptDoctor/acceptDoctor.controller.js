(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('AcceptDoctorController', AcceptDoctorController);
 
    AcceptDoctorController.$inject = ['$location', 'DoctorService', 'FlashService', '$rootScope', '$scope'];
    function AcceptDoctorController(location, DoctorService, FlashService, $rootScope, $scope) {
        var vm = this;
 
        //CRUD
        $scope.allDoctors = []; //Read
        $scope.acceptDoctor = acceptDoctor;   //Update
        $scope.rejectDoctor= rejectDoctor;    //Create
 
        initController();

        function initController() {
            loadPendingDoctors(  );
        }
        
        function loadPendingDoctors() {
            DoctorService.GetPending()
                .then(function (doctors) {
                    $scope.allDoctors = doctors.data;
            },function(){
                 FlashService.Error("Error al cargar doctores pendientes");       
            });
        }

        function acceptDoctor(Doctorid) {
            
            DoctorService.acceptDoctor(Doctorid)
            .then(function () {
                loadPendingDoctors();
                FlashService.Success('Doctor aceptado', true);   
            },function(){
                FlashService.Error("Doctor no ha podido ser aceptado, intente nuevamente mas tarde");       
            });
        }
        
        
        function rejectDoctor(Doctorid){
            
            DoctorService.rejectDoctor(Doctorid)
                .then(function() {
                    loadPendingDoctors();
                    FlashService.Success('Doctor rechazado', true); 
                },function(response){
                    FlashService.Error('Doctor no ha podido ser rechazado, intente nuevamente mas tarde');      
                });
        }
    }
 
})();