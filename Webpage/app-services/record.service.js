(function () {

    angular
        .module('app')          //servicio para el cliente
        .factory('RecordService', RecordService);

    RecordService.$inject = ['$http'];
    function RecordService($http) {
        var service = {};

        service.GetByPatient = GetByPatient;
        service.Create = Create;
        return service;

        function GetByPatient(UserId) {
            var response=$http({
                method:"post",
                url:"api/medicalrecords/viewallbypatient",
                data:{UserId:UserId}
            });
            return response;    
        }
        
        function Create(medicalRecord) {
            var response=$http({
                method:"post",
                url:"api/medicalrecords/create",
                data:medicalRecord
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
