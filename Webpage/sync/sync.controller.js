(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('SyncController', SyncController);
 
    SyncController.$inject = ['$location', 'MedicineService', 'FlashService', '$rootScope','$scope'];
    function SyncController(location, MedicineService, FlashService, $rootScope,$scope) {
        var vm = this;
 

        $scope.syncMedics= syncMedics;
        
        function syncMedics() {
            MedicineService.Sync()
                .then(function (patients) {
                 FlashService.Success("Se sincronizaron los medicamentos");                          
            },function(){
                 FlashService.Error("Error al sincronizar los medicamentos");       
            });
        }

    }
 
})();