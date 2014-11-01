(function () {
    var app = angular.module("EventContributionModule", []);
    app.controller("EventDetailsController", ["$http", "$location", function ($http, $location) {

        var self = this;

        self.event = {};
        self.statistics = {};

        var eventid = $location.absUrl().split('/').pop();

        $http.get("/api/event/" + eventid).success(function (data) {
            self.event = data;
        }).error(function (data) {

        });
    }]);
})();