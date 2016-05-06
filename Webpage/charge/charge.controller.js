(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('ChargeController', ChargeController);
 
    ChargeController.$inject = ['$location', 'ChargeService', 'FlashService', '$rootScope','$scope'];
    function ChargeController(location, ChargeService, FlashService, $rootScope, $scope) {
        var vm = this;
 
        //CRUD
        $scope.allCharges = []; //Read
        $scope.charge = charge; //Delete
        
        //Mostrar
         $scope.showReport = false;

        $scope.toggle = function() {
        
            $scope.showReport = !$scope.showReport;
        };
        
        function charge() {
            ChargeService.GetAll()
                .then(function (charges) {
                    $scope.allCharges = charges.data;
            },function(){
                 FlashService.Error("Error al cobrar a los doctores");       
            });
        }

    }
 
})();