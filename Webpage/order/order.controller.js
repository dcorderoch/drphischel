(function () {
    'use strict';

    angular   ///modulo al que pertenece
        .module('app')
        .controller('OrderController', OrderController);

    OrderController.$inject = ['OrderService', '$rootScope', 'FlashService', '$scope'];
    function OrderController(OrderService,$rootScope, FlashService, $scope) {
        
        $scope.order={};
        var vm = this;
        
        $scope.createOrder= createOrder;  //variables locales y para vistas

        function createOrder(){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
            OrderService.Create($scope.order)
            .then(function(response) {
                
                    FlashService.Success('Pedido Creado',true);  //si funco se muestra un approve
                
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