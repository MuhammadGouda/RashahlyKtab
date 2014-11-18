(function () {
    var app = angular.module("EventContributionModule", []);
    app.controller("EventStatsController", ["$http", "$location", function ($http, $location) {

        var self = this;

        self.event = {};
        self.actions = {};
        

        var eventid = $location.absUrl().split('/').pop();

        $http.get("/api/event/" + eventid + '?includestatistics=true').success(function (data) {
            self.event = data;
            //self.actions.fbLink = $location.absUrl();
        }).error(function (data) {

        });
    }]);

    app.controller("ContributionController", function ($http, $location) {
        var self = this;
        
        self.newCont = {
            //"pagesCount": 1000,
            //"book": { "id": 3, "title": "Untitled" },
            //"contributer": {
            //    "id": 4,
            //    "currentEvent": { "id": 1, "title": "Week1" },
            //    "user": { "id": "aaa7e68e-4f47-4a56-bd76-b6319140c903", "userName": "muhammad.gouda@itworx.com" }
            //}
        };

        self.uiHelper = {
            loaded: false, addMode: false, message: "Loading...",
            showAddMode: function () {
                this.addMode = true;
            },
            clearForm: function () {
                self.newCont = {};
                self.uiHelper.addMode = false;
            }
        };
        
        self.getAllConts = function () {
           
            self.uiHelper.addMode = false;
            self.uiHelper.message = "Loading...";
            var eventId = $location.absUrl().split('/').pop();            
            var apiUrl = "/api/contribution/event/" + eventId; // filtring Contributions by selected event            
            $http.get(apiUrl).success(function (data, status, headers, config) {
                self.conts = data;
                self.uiHelper.loaded = true;
            }).error(function (data, status, headers, config) {
                self.uiHelper.message = "Oops!... something went wrong.";
                self.uiHelper.loaded = false;
            });
        };

        self.getMyConts = function () {
            //dirty solution
            //I store current userId in a hidden server side control and pass its value to angularjs function using JQuery selector
            //I should get current userId directly from angularjs objects and services, but still don't know how
            var userId = $("#userId").text();            
            self.uiHelper.addMode = false;
            self.hasData = false;
            self.uiHelper.message = "Loading...";
            var eventId = $location.absUrl().split('/').pop();
            var apiUrl = "/api/Contribution/CurrentContributor/" + eventId + "?userId=" + userId; // filtring Contributions by selected event            
            $http.get(apiUrl).success(function (data, status, headers, config) {
                self.myConts = data;
                self.uiHelper.loaded = true;
                if (data.length > 0)
                    self.hasData = true;
            }).error(function (data, status, headers, config) {
                self.uiHelper.message = "Oops!... something went wrong.";
                self.uiHelper.loaded = false;
            });
        };
        
        self.saveCont = function () {            
            var eventId = $location.absUrl().split('/').pop();                      
            
            
            
            $http.post('/api/contribution', self.newCont).success(function (data, status, headers, config) {               
                
                    self.uiHelper.clearForm();
                    self.getAllconts();
                    self.getMyConts();
            }).error(function (data, status, headers, config) {
                alert('err');
                    self.uiHelper.message = "Oops!... something went wrong.";
                });
        };


    });
})();