/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

'use strict';

var gulp = require('gulp');
var del = require('del');
var sass = require('gulp-sass');

gulp.task('sass', function () {
  return gulp.src('Styles/main.scss')
    .pipe(sass({outputStyle: 'compressed'}).on('error', sass.logError))
    .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('sass:watch', function () {
  gulp.watch('./Styles/**/*.scss', ['sass']);
});

var paths = {
  scripts: ['Scripts/**/*.js', 'Scripts/**/*.ts', 'Scripts/**/*.map'],
};

gulp.task('clean', function () {
  return del(['wwwroot/scripts/**/*']);
});

gulp.task('default', function () {
  gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/scripts'))
});