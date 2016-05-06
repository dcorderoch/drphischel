(function () {
    'use strict';

    angular   ///modulo al que pertenece
        .module('app')
        .controller('OrderController', OrderController);

    OrderController.$inject = ['OrderService', '$rootScope', 'FlashService', '$scope'];
    function OrderController(OrderService, $rootScope, FlashService, $scope) {
        
        $scope.order={};
        var vm = this;
        
        $scope.createOrder= createOrder;  //variables locales y para vistas
        $scope.branches=[];
        $scope.branchSelected = false;
        $scope.branchId;
        $scope.medicines=[];
        
        initController();
        
        function initController() {
            loadAllBranches();
        };
        
        
        function setBranch(selectedBranch){
            
            $scope.branchSelected = true;
            $scope.branchId = selectedBranch.BranchId;
            loadAllMedicines();
        }
        
        
        function createOrder(){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
            OrderService.Create($scope.order)
            .then(function(response) {
                 $scope.dataLoading=false; 
                    FlashService.Success('Pedido Creado',true);  //si funco se muestra un approve
                
                },function(response){ 
                    FlashService.Error(response.status);
                    $scope.dataLoading= false;
            });
        }
        
       function loadAllBranches() {
            SpecialityService.GetAll()
                .then(function (branches) {
                    $scope.branches = branches.data;
            },function(){
                 FlashService.Error("Error al cargar especialidades");       
            });
        }
        function loadAllMedicines(){
            MedicineService.GetAll()
                .then(function(medicines){
                    $scope.medicines = medicines;
                    
                }, function(){
                    FlashService.Error("Error al cargar medicinas");
            });
        }
        
        
    
    }
} ) ();  // La funcion se auto llama
///importante no se pueden hacer dos pedidos (con y sin prescripcion al mismo tiempo)