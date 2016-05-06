(function () {
    'use strict';

    angular   ///modulo al que pertenece
        .module('app')
        .controller('AddSpecialityController', AddSpecialityController);

    AddSpecialityController.$inject = ['SpecialityService', '$rootScope', 'FlashService', '$scope'];
    function AddSpecialityController(SpecialityService,$rootScope, FlashService, $scope) {
        
        $scope.speciality={};
        var vm = this;
        
        $scope.addSpeciality= addSpeciality;  //variables locales y para vistas

        function addSpeciality(){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
            SpecialityService.Create()
            .then(function(response) {
                    
                $scope.dataLoading= false;
                FlashService.Success('Especialidad agregada',true);  //si funco se muestra un approve
                
                },function(response){ 
                    FlashService.Error(response.status);
                    $scope.dataLoading= false;
            });
        }        
    
    }
} ) ();  // La funcion se auto llama
///importante no se pueden hacer dos pedidos (con y sin prescripcion al mismo tiempo)
//
//
//