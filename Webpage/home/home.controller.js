(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('HomeController', HomeController);
 
    HomeController.$inject = ['$location', 'FlashService', '$rootScope','$scope'];
    function HomeController(location, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //Tomar nombre del paciente
        $scope.doctorName ;
        initController();

        function initController() {
            loadDoctorName();
        }
        
        function loadDoctorName() {
            $scope.doctorName = $rootScope.loadDoctorName;
        }
    }
})();
