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
        self.isBusy = false;
        self.hasError = false;
        self.errorMessage = '';

        var eventid = $location.absUrl().split('/').pop();

        self.getUserContributions = function () {
            self.isBusy = true;
            $http.get("/api/contributions?eventId=" + eventid).success(function (data, status, headers, config) {
                self.isBusy = false;
                if (data.length > 0) {
                    self.userContributions = data;
                } else {
                    self.hasError = true;
                    self.errorMessage = "You didn't add any books yet";
                }

            }).error(function(data, status, headers, config) {
                self.isBusy = false;
                self.hasError = true;
                self.errorMessage = "Oops,something went wrong! please again later.";
            });

        };

    }]);

})();