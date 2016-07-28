var MoviesApp = angular.module('MoviesApp', ['ngRoute', 'ngResource', 'ngMessages'])

    // define app routes
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', { controller: "MovieCatalogueCtrl", templateUrl: '/App/MovieCatalogue/MovieCatalogueView.html' })
            .otherwise({ redirectTo: '/' });
    })

    // connect to back-end api endpoints
    .factory('Movies', function ($resource) {
         return $resource('/api/Movies/:id', { id: '@id' }, { update: { method: 'PUT' } });
    })
    .factory('GenreTypes', function ($resource) {
        return $resource('/api/GenreTypes/:id', { id: '@id' }, { update: { method: 'PUT' } });
    });