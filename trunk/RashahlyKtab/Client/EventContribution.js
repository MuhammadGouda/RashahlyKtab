(function () {
    var app = angular.module("EventContributionModule", []);

    app.controller("EventDetailsController", ["$http", "$location", function ($http, $location) {

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

    app.controller("UserContributionsController", ["$http", "$location", function ($http, $location) {

        var self = this;
        self.userContributions = [];

        var eventid = $location.absUrl().split('/').pop();

        self.getUserContributions = function () {

            $http.get("/api/contribution").success(function (data, status, headers, config) {
                self.userContributions = data;
            }).error(function(data, status, headers, config) {
                
            });

        };

    }]);

})();