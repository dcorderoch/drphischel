(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('AppointmentController', AppointmentController);
 
    AppointmentController.$inject = ['$location', 'FlashService', '$rootScope','$scope'];
    function AppointmentController(location, FlashService, $rootScope,$scope) {
        var vm = this;
        
        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        
        var events= [ {title:"Mi cumple", start: new Date(2016,5,6,12,30)},  
                      {title:"Mi cumple", start: new Date(2016,5,6,8,30)},  
                      {title:"Aniversario", start: new Date(2016,7,7,19,30), allDay:false},
                      {title: 'All Day Event',start: new Date(y, m, 1)},
                      {title: 'Long Event',start: new Date(y, m, d - 5),end: new Date(y, m, d - 2)},
                      {id: 999,title: 'Repeating Event',start: new Date(y, m, d - 3, 16, 0),allDay: false},
                      {id: 999,title: 'Repeating Event',start: new Date(y, m, d + 4, 16, 0),allDay: false},
                      {title: 'Birthday Party',start: new Date(y, m, d + 1, 19, 0),end: new Date(y, m, d + 1, 22, 30),allDay: false}
                    ];
        
        $scope.eventSources= [events];
        
        
        $scope.uiConfig = {
      calendar:{
        height: 450,
          width:650,
       // editable: true,
        header:{
          left: 'prev',
          center: 'title',
          right: 'today ,next'
        },
        eventClick: $scope.alertOnEventClick,
    //    eventDrop: $scope.alertOnDrop,
        eventResize: $scope.alertOnResize,
        eventRender: $scope.eventRender
      }
    };
        
//        $scope.calOptions= {
//            height: 450,
//            width:450,
//            editable:false,
//            header:{
//                left:'prev',
//                center:'title',
//                right:'today,next'
//            },
//        eventClick: $scope.alertOnEventClick,
//
//            eventClick: $scope.alertOnEventClick,
//            eventResize: $scope.alertOnResize
//        };
        
    /* alert on Resize */
    $scope.alertOnResize = function(event, delta, revertFunc, jsEvent, ui, view ){
       $scope.alertMessage = ('Event Resized to make dayDelta ' + delta);
    };
        
    /* alert on eventClick */
    $scope.alertOnEventClick = function( date, jsEvent, view){
        $scope.alertMessage = (date.title + ' was clicked ');
    };  
        
            /* alert on eventClick */
    $scope.alertOnEventClick = function( date, jsEvent, view){
        $scope.alertMessage = (date.title + ' was clicked ');
    };
        
             /* Render Tooltip */
    $scope.eventRender = function( event, element, view ) { 
        element.attr({'tooltip': event.title,
                     'tooltip-append-to-body': true});
        $compile(element)($scope);
    };
        
    }
})();
