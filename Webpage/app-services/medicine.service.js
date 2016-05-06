(function () {
    'use strict';

    angular
        .module('app')
        .factory('MedicamentoService', MedicamentoService);  //servicio de medicamentos

    MedicamentoService.$inject = ['$http'];
    function MedicamentoService($http) {
        var service = {};

        service.GetAll = GetAll; //las funciones que son expuestas
       

        return service;

        function GetAll() {
            var response=$http({
                method:"post",
                url:"api/medicine/getall"
            });
            return response;    
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
