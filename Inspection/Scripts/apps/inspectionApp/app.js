'use strict';

define([
	'angular',
	'angularRoute',
	'views/dealerview'
], function (angular, angularRoute, dealerview) {
    // Declare app level module which depends on views, and components
    return angular.module('myApp', [
		'ngRoute',
		'myApp.dealerview'
    ]).
	config(['$routeProvider', function ($routeProvider) {
	    $routeProvider.otherwise({ redirectTo: '/dealerview' });
	}]);
});
