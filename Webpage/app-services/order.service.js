(function () {
    'use strict';

    angular
        .module('app')   // pertenece a app y se llama PedidoService
        .factory('OrderService', OrderService);  //Una factory es un servicio que tiene valores de retorno

    OrderService.$inject = ['$http'];
    function OrderService($http) {       //se inyecta http para rest.
        var service = {};   //variable de servicio es un objeto js y se retorna en las funciones 
       
        service.Create = Create;      //funcion de getall esto se usa para poder usarlo en los controladores.
        return service;      //es una fabrica entonces se retorna el service.

        function Create(theOrder) {  //MEJOR HACER LOS rest de esta forma
            var request =$http({ //Se crea un pedido sin prescripcion
            method: "post",//tipo metodo, se puede usar get o put
            url: "http://192.168.43.108:7444/api/Pedido/Create",
            data: theOrder          //parametros que pide el rest api
        });
            return request;
        };

        // private functions

        function handleSuccess(res) {
            return res.data;
        }
 //manejo de errores
        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();

