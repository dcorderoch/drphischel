(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('CheckRecordController', CheckRecordController);
 
    CheckRecordController.$inject = ['$location', 'RecordService', 'FlashService', '$rootScope','$scope'];
    function CheckRecordController(location, RecordService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        $scope.allRecords = []; //get read
        initController();

        function initController() {
            loadAllRecords();            
        }
        
        function loadAllRecords() {
            RecordService.GetByPatient($rootScope.patientId)
                .then(function (records) {
                    $scope.allRecords = records.data;
            },function(){
                 FlashService.Error("Error al cargar los registros");       
            });
        }
    }
})();
