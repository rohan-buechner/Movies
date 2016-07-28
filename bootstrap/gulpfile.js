/* gulpfile.js */
var 
    gulp = require('gulp'),
    sass = require('gulp-sass');

// source and distribution folder
var
    source = 'src/',
    dest = '../HelloMovies/Content/';

// Bootstrap scss source
var bootstrapSass = {
        in: './node_modules/bootstrap-sass/'
    };

// fonts
var fonts = {
        in: [source + 'fonts/*.*', bootstrapSass.in + 'assets/fonts/**/*'],
        out: dest + 'fonts/'
    };

 // css source file: .scss files
var css = {
    in: source + 'scss/bootstrap-main.scss',
    out: dest + 'css/',
    watch: source + 'scss/**/*',
    sassOpts: {
        outputStyle: 'nested',
        precision: 8,
        errLogToConsole: true,
        includePaths: [bootstrapSass.in + 'assets/stylesheets']
    }
};


gulp.task('fonts', function () {
    return gulp
        .src(fonts.in)
        .pipe(gulp.dest(fonts.out));
});


// compile scss
gulp.task('sass', ['fonts'], function () {
    return gulp.src(css.in)
        .pipe(sass(css.sassOpts))
        .pipe(gulp.dest(css.out));
});


// default task
gulp.task('default', ['sass'], function () {
     gulp.watch(css.watch, ['sass']);
});