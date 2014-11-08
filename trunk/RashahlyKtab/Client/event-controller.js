(function () {
    var app = angular.module('EventApp', []);
    app.controller('EventsController', function ($scope, $http) {
              

        self = this;
        self.newEvent = { title: "", startDate: "", endDate: "" };
        
        self.uiHelper = {
            loaded: false, addMode: false, message: "جاري التحميل ...",
            showAddMode : function () {
                this.addMode = true;                
            },
            clearForm: function () {
                self.newEvent = { title: "", startDate: "", endDate: "" };
                self.uiHelper.addMode = false;
            }
        };
       
        self.dateHelper = {
            updateEndDate: function (strDate) {
                var startDate = strToDate(strDate);
                self.newEvent.endDate = (addDays(startDate, 7));//endDate = startDate + 7 days;                                 
            }
        };
        
        self.getAllEvents = function () {            
            self.uiHelper.addMode = false;
            self.uiHelper.message = "جاري التحميل ...";
            $http.get("/api/event").success(function (data, status, headers, config) {
                self.events = data;
                self.uiHelper.loaded = true;
            }).error(function (data, status, headers, config) {
                self.uiHelper.message= "عذرا .. تعذر الاتصال ، رجاء حاول مرة أخرى أو اتصل بالدعم الفني";
                self.uiHelper.loaded = false;
            });
        };

        self.saveEvent = function () {
            $http.post('/api/event',
                { 'title': self.newEvent.title, 'startDate': strToDate(self.newEvent.startDate), 'endDate': self.newEvent.endDate }
                ).success(function (data, status, headers, config) {
                self.uiHelper.clearForm();
                self.getAllEvents();                
            }).error(function (data, status, headers, config) {
                self.uiHelper.message = "Oops... something went wrong";                
            });
        };

        self.publishEvent = function () {
            alert("Not Implemented");
        };
    });
    //define custom angularjs directive of type attribute named 'jqdatepicker' 
    //the purpose of this new directive is to enforce setting the property of the control to the selected value from JQuery datepicker
    //because the default behavior of JQuery datepicker does not set the value of the associated control
    app.directive('jqdatepicker', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ctrl) {
                $(element).datepicker({
                    dateFormat: 'dd.mm.yy',
                    onSelect: function (date) {
                        ctrl.$setViewValue(date);
                        ctrl.$render();
                        scope.$apply();
                    }
                });
            }
        };
    });
})();