MoviesApp.controller('MovieCatalogueCtrl', function ($scope, $q, Movies, GenreTypes, $filter) {

    function init() {
        // use $q.all for parallel call execution
        $q.all([
            Movies.query(),
            GenreTypes.query()
        ]).then(function (result) {
            $scope.movies = result[0];
            $scope.genres = result[1];
        });
    };

    $scope.sortType = 'Title'; // default sort type
    $scope.sortReverse = false;  // sort direction
    $scope.search = '';  // search term    
    $scope.movie = new Movie();

    $scope.submit = function () {
        Movies.save($scope.movie,
        function (resp, headers) {
            // on success, get GenreType text so that we can add it to the grid, then reset the add new movie form
            $scope.movie.Genre = $filter('getById')($scope.genres, $scope.movie.GenreTypeId);  
            $scope.movies.push($scope.movie);
            $scope.movie = new Movie();

            // reset UI validation
            $scope.movieForm.Title.$touched = false;
            $scope.movieForm.Released.$touched = false;
            $scope.movieForm.Genre.$touched = false;
        });
    }

    function Movie(genreTypeId, title, released) {
        this.GenreTypeId = genreTypeId,
        this.Title = title,
        this.Released = released
    };

    init();    
});

