(function () {
    'use strict';

    angular   ///modulo al que pertenece
        .module('app')
        .controller('OrderController', OrderController);

    OrderController.$inject = ['OrderService', 'MedicineService', 'BranchOfficeService', '$rootScope', 'FlashService', '$scope'];
    function OrderController(OrderService, MedicineService, BranchOfficeService, $rootScope, FlashService, $scope) {
        
        $scope.order={};
        var vm = this;
        
        //funciones
        $scope.createOrder= createOrder;  //variables locales y para vistas
        $scope.load =load;
        
        //Arrays de datos obtenidos del servidor
        $scope.branches=[];
        $scope.medicines=[];
        
        //COntrol de la sucursal obtenida y si mostrar el form de crear pedido
        $scope.branchSelected = false;
        $scope.branchId;
        
        //Array intermedio de seleccion del checkbox.
        $scope.selection=[];

        initController();
        
        function initController() {
            
            loadAllBranches();
            $scope.branches.push({"Name":"Nicolas", BranchOfficeId:"123"});
            $scope.branches.push({"Name":"Alfonso",BranchOfficeId:"456"});
            $scope.branches.push({"Name":"Emmanuel",BranchOfficeId:"789"});
            
             $scope.medicines.push({"Name":"Nicolas", MedicineId:"123"});
            $scope.medicines.push({"Name":"Alfonso",MedicineId:"456"});
            $scope.medicines.push({"Name":"Emmanuel",MedicineId:"789"});
        };
        
        function load(branchSelected){
            
              $scope.branchSelected=true;
              $scope.branchId = branchSelected.BranchOfficeId;
              loadAllMedicines();
        }
        
        function createOrder(){   //pedido sin prescripcion
 
            $scope.dataLoading=true;      //se muestra un data loading mientras se hace el pedido
            $scope.order.BranchOfficeId = $scope.branchId;
            $scope.order.medicineIds=  $scope.selection;
            OrderService.Create($scope.order)
            .then(function(response) {
                 $scope.dataLoading=false; 
                    FlashService.Success('Pedido Creado',true);  //si funco se muestra un approve
                
                },function(response){ 
                    FlashService.Error(response.status);
                    $scope.dataLoading= false;
            });
        }
        
        function loadMedicines(){
            MedicineService.GetByBranch()
                .then(function(medicines){
                    $scope.medicines = medicines;
                    
                }, function(){
                    FlashService.Error("Error al cargar medicinas");
            });
        }
        
       function loadAllBranches() {
            BranchOfficeService.GetAll()
                .then(function (branches) {
                    $scope.branches = branches.data;
            },function(){
                 FlashService.Error("Error al cargar las sucursales");       
            });
        }
        
                    // toggle selection for a given spec by name
        $scope.toggleSelection = function toggleSelection(MedicineId) {
            var idx = $scope.selection.indexOf(MedicineId);
 
             // is currently selected
             if (idx > -1) {
               $scope.selection.splice(idx, 1);
             }

             // is newly selected
             else {
               $scope.selection.push(MedicineId);
             }
        };
    
    }
} ) ();  // La funcion se auto llama
///importante no se pueden hacer dos pedidos (con y sin prescripcion al mismo tiempo)