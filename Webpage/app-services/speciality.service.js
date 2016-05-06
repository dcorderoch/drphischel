(function () {

    angular
        .module('app')          //servicio para el cliente
        .factory('SpecialityService', SpecialityService);

    SpecialityService.$inject = ['$http'];
    function SpecialityService($http) {
        var service = {};

        service.AddNew = AddNew;
        service.GetAll = GetAll;
        return service;

        function AddNew(specName) {
            var response=$http({
                method:"post",
                url:"api/admin/addnewspecialty",
                data:specName
            });
            return response;    
        }
        
        function GetAll() {
            var response=$http({
                method:"get",
                url:"api/specialties/getall"
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
