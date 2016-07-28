MoviesApp.filter('getById', function () {
    return function (input, id) {
        var i = 0, len = input.length;
        for (i; i < len; i++) {
            if (input[i].Id == id) {
                return input[i];
            }
        }
        return null;
    }
});