(function () {
    'use strict';

    angular
        .module('app')          //servicio para el cliente
        .factory('DoctorService', DoctorService);

    DoctorService.$inject = ['$http'];
    function DoctorService($http) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.Delete = Delete;
        service.GetPending = GetPending;
        service.GetByPatient= GetByPatient;
        service.AcceptDoctor = AcceptDoctor;
        service.RejectDoctor = RejectDoctor;

        return service;

        function Create(data) {
            var response=$http({
                method:"post",
                url:"api/doctor/create",
                data: data
            });
            return response;    
        }
        
        function AcceptDoctor(DoctorId) {
            var response=$http({
                method:"post",
                url:"api/doctor/accept",
                data: DoctorId
            });
            return response;    
        }
        
        function RejectDoctor(DoctorId) {
            var response=$http({
                method:"post",
                url:"api/doctor/reject",
                data: DoctorId
            });
            return response;    
        }

        function Delete(data) {   //para registrar un cliente
            var request = $http({
            method: "post",
            url: "api/doctor/delete",
            data: data
        });
            return request;
        }
        
        function GetPending() {   //para registrar un cliente
            var request = $http({
            method: "get",
            url: "api/doctor/getlistofpending"
        });
            return request;
        }
        
        function GetByPatient( UserId) {   //para registrar un cliente
            var request = $http({
            method: "post",
            url: "api/doctor/getbypatient",
            data:   UserId
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
