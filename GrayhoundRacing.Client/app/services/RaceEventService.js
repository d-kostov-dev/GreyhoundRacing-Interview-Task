appMain.factory('RaceEventService', function (httQ, appSettings) {
    var serviceUrl = appSettings.apiUrl + "/api/Race";

    return {
        getAllRaces: function () {
            return httQ.get(serviceUrl);
        }
    };
});