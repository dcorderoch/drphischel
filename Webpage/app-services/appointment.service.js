(function () {
    'use strict';

    angular
        .module('app')          //servicio para el cliente
        .factory('AppointmentService', AppointmentService);

    AppointmentService.$inject = ['$http'];
    function AppointmentService($http) {
        var service = {};

        service.Create = Create;    //de esta forma se pueden utilizar en los controladores
        service.GetById = GetById;

        return service;

        function GetById(DoctorId) {
            var response=$http({
                method:"post",
                url:"api/appointment/getbyDoctorId",
                data: DoctorId
            });
            return response;    
        }

        function Create(data) {   //para registrar un cliente
            var request = $http({
            method: "post",
            url: "api/appointment/create",
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
