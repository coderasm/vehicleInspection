'use strict';

define([
	'angular',
	'angularRoute',
	'views/allfloored'
], function (angular, angularRoute, view) {
    // Declare app level module which depends on views, and components
    return angular.module('myApp', [
		'ngRoute',
		'myApp.allfloored'
    ]).
	config(['$routeProvider', function ($routeProvider) {
	    $routeProvider.otherwise({ redirectTo: '/allfloored' });
	}]);
});
