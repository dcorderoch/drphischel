(function () {
    'use strict';

    angular   ///modulo al que pertenece
        .module('app')
        .controller('CreateAppointmentController', CreateAppointmentController);

    CreateAppointmentController.$inject = ['AppointmentService', '$rootScope', 'FlashService', '$scope'];
    function CreateAppointmentController(AppointmentService, $rootScope, FlashService, $scope) {
        
        $scope.newAppointment={};
        var vm = this;
        
        $scope.createA= createA;  //variables locales y para vistas

        function createA(DoctorId){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
            newAppointment.DoctorId = DoctorId;
            newAppointment.UserId = $rootScope.userId;
            AppointmentService.Create($scope.newAppointment)
            .then(function(response) {
                            
                $scope.dataLoading=false;      //se muestra un data loading mientras se hace el pedido
                FlashService.Success('Cita creada',true);  //si funco se muestra un approve
                
                },function(response){ 
                    FlashService.Error(response.status);
                    $scope.dataLoading= false;
            });
        }        
        
        function 
    
    }
} ) ();  // La funcion se auto llama
