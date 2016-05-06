(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('HomeAController', HomeAController);
 
    HomeAController.$inject = ['$location', 'FlashService', '$rootScope','$scope'];
    function HomeAController(location, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //Tomar nombre del paciente
        $scope.adminName ;
        initController();

        function initController() {
            loadAdminName();
        }
        
        function loadAdminName() {
            $scope.adminName = $rootScope.adminName;
        }
    }
})();
