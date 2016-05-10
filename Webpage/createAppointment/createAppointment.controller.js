(function () {
    'use strict';

    angular   ///modulo al que pertenece
        .module('app')
        .controller('CreateAppointmentController', CreateAppointmentController);

    CreateAppointmentController.$inject = ['AppointmentService', 'DoctorService', '$rootScope', 'FlashService', '$scope'];
    function CreateAppointmentController(AppointmentService, DoctorService, $rootScope, FlashService, $scope) {
        
        $scope.newAppointment={};
        $scope.allDoctors=[];
        var vm = this;
        
        $scope.createA= createA;  //variables locales y para vistas
        
        initController();
        
        function initController(){
            
            loadDoctors();
            console.log($scope.allDoctors);
        }
        

        function createA(DoctorId){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
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
        
        function loadDoctors(){
            $scope.allDoctors.push({"Name":"Nicolas"});
            $scope.allDoctors.push({"Name":"Alfonso"});
            $scope.allDoctors.push({"Name":"Emmanuel"});
            DoctorService.GetByPatient($rootScope.userId)
                .then(function(doctors){
                       $scope.allDoctors = doctors.data;
                }, function(){
                    FlashService.Error("Error al cargar doctores del usuario"); 
                });
        }
    }
} ) ();  // La funcion se auto llama
