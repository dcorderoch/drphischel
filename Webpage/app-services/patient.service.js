(function () {
    'use strict';

    angular
        .module('app')          //servicio para el cliente
        .factory('PatientService', PatientService);

    PatientService.$inject = ['$http'];
    function PatientService($http) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Delete = Delete;
        service.GetByMedic= GetByMedic;
        service.Update = Update;
        service.CreateByMedic = CreateByMedic;

        return service;

        function Create(data) {
            var response=$http({
                method:"post",
                url:"api/patient/createbyadmin",
                data: data
            });
            return response;    
        }
        
        function GetByMedic(DoctorId) {
            var response=$http({
                method:"post",
                url:"api/doctor/accept",
                data: DoctorId
            });
            return response;    
        }
        
        function Delete(DoctorId) {
            var response=$http({
                method:"post",
                url:"api/patient/delete",
                data: DoctorId
            });
            return response;    
        }

        function Update(data) {   //para registrar un cliente
            var request = $http({
            method: "post",
            url: "api/patient/update",
            data: data
        });
            return request;
        }
        
        function CreateByMedic() {   //para registrar un cliente
            var request = $http({
            method: "post",
            url: "api/patient/createbymedic"
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
