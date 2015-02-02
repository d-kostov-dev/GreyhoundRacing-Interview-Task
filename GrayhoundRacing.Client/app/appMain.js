'use strict';

var appMain = angular.module('appMain', ['ngRoute', 'httpQRequest']);

appMain.constant("appSettings", {
    // Paths
    templatesFolder: "templates",
    apiUrl: "http://localhost:14069/",

    // Configurations

    // License Stuff
    author: "Dimitar Kostov",
    authorLink: "http://dkostov.dotnet.bg",
    poweredBy: "AngularJs"
});

appMain.config(function ($routeProvider, appSettings) {

    $routeProvider.when("/home", {
        controller: "HomeController",
        templateUrl: appSettings.templatesFolder + "/home.html"
    });

    $routeProvider.when("/clientSort", {
        controller: "ClientSortController",
        templateUrl: appSettings.templatesFolder + "/clientSort.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});