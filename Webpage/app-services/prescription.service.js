(function () {
    'use strict';

    angular
        .module('app')          //servicio para el cliente
        .factory('PrescriptionService', PrescriptionService);

    PrescriptionService.$inject = ['$http'];
    function PrescriptionService($http) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Delete = Delete;
        service.GetByMedic= GetByMedic;
        service.Update = Update;

        return service;

        function Create(data) {
            var response=$http({
                method:"post",
                url:"api/prescription/create",
                data: data
            });
            return response;    
        }
        
        function GetByMedic(DoctorId) {
            var response=$http({
                method:"post",
                url:"api/prescription/getbydoctorid",
                data: DoctorId
            });
            return response;    
        }
        
        function Delete(PrescriptionId) {
            var response=$http({
                method:"post",
                url:"api/prescription/delete",
                data: PrescriptionId
            });
            return response;    
        }

        function Update(data) {   //para registrar un cliente
            var request = $http({
            method: "post",
            url: "api/prescription/update",
            data: data
        });
            return request;
        }
        

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
