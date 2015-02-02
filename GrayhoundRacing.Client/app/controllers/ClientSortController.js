'use strict';

appMain.controller('ClientSortController', function ($scope, $routeParams, RaceEventService) {
    $scope.sortingData = {
        predicate: "Name",
        reverse: false
    };

    function getData() {
        RaceEventService.getAllRaces()
        .then(function (response) {
            $scope.currentRaces = response;
            setTimeout(getData, 1000);
        });
    }
    
    getData();
});