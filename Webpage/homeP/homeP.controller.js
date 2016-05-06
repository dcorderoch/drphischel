(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('HomePController', HomePController);
 
    HomePController.$inject = ['$location', 'FlashService', '$rootScope','$scope'];
    function HomePController(location, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //Tomar nombre del paciente
        $scope.patientName ;
        initController();

        function initController() {
            loadPatientName();
        }
        
        function loadPatientName() {
            $scope.patientName = $rootScope.patientName;
        }
    }
})();
