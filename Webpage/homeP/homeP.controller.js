(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('HomePController', HomePController);
 
    HomePController.$inject = ['$location', 'PatientService', 'FlashService', '$rootScope','$scope'];
    function NewDoctorController(location, PatientService, FlashService, $rootScope,$scope) {
        var vm = this;
 
        //Tomar especialidades
        $scope.medicSpecialities = []; //Read
        //Crear
        $scope.createDoctor= createDoctor;    //Create
        

        function initController() {
            loadAllSpecialities();
        }();
        
        function loadAllSpecialities() {
            SpecialityService.GetAll()
                .then(function (specialities) {
                    $scope.medicSpecialities = specialities.data;
            },function(){
                 FlashService.Error("Error al cargar especialidades");       
            });
        }

}
 
})();
