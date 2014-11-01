
(function () {
    var app = angular.module('weekApp', []);
    app.controller('weekController', ['$http', function ($http) {
        
        var self = this;
        self.week = {
            name : "", startDate : new Date(), description : ""
        };

        self.ui = {disableForm: false};
        
        this.addWeek = function () {
            self.ui.disableForm = true;
            $http.post('/api/Week/', self.week)
                .success(function () {
                    self.week = { name: "", startDate: new Date(), description: ":)" }
                    self.ui.disableForm = false;
                })
                .error(function (data, status) { alert(data.Message) });
        };

    }]);



})();