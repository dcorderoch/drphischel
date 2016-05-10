(function () {
    'use strict';

    angular
        .module('app')          //servicio para el cliente
        .factory('BranchOfficeService', BranchOfficeService);

    BranchOfficeService.$inject = ['$http'];
    function BranchOfficeService($http) {
        var service = {};

        service.GetAll = GetAll;

        return service;

        function GetAll() {
            var response=$http({
                method:"get",
                url:"api/branchoffice/getall"
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