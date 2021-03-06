'use strict';

define([
	'angular',
	'angularRoute',
	'components/version/version'
], function(angular) {
	angular.module('myApp.floored', ['ngRoute', 'flooredApp.version'])
	.config(['$routeProvider', function($routeProvider) {
		$routeProvider.when('/floored', {
			templateUrl: 'views/allfloored.html',
			controller: 'flooredcontroller'
		});
	}])
	// We can load the controller only when needed from an external file
	.controller('View2Ctrl', ['$scope', '$injector', function($scope, $injector) {
		require(['views/allfloored'], function(allfloored) {
			// injector method takes an array of modules as the first argument
			// if you want your controller to be able to use components from
			// any of your other modules, make sure you include it together with 'ng'
			// Furthermore we need to pass on the $scope as it's unique to this controller
			$injector.invoke(allfloored, this, {'$scope': $scope});
		});
	}]);
});