(function () {
    'use strict';

    angular
        .module('app')
        .factory('MedicineService', MedicineService);  //servicio de medicamentos

    MedicineService.$inject = ['$http'];
    function MedicineService($http) {
        var service = {};

        service.GetAll = GetAll; //las funciones que son expuestas
       service.Sync = Sync;

        return service;

        function GetAll() {
            var response=$http({
                method:"get",
                url:"api/medicine/getall"
            });
            return response;    
        }
        
        function Sync() {
            var response=$http({
                method:"get",
                url:"api/admin/sync"
            });
            return response;    
        }
        function GetByBranch(branchID){
            
            var response=$http({
                method:"post",
                url:"api/medicine/getbybranchoffice",
                data: {BranchOfficeId: branchID}
            })
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
