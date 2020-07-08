const gulp = require('gulp');
const shell = require('gulp-shell');

function build() {
    return gulp.src(__filename)
        .pipe(shell(['dotnet build']));
}

function publishWorker() {
    return gulp.src(__filename)
        .pipe(shell(['dotnet publish TvCast.Worker -o ./wwwroot/worker']));
}


exports.build = build;
exports.publishWorker = publishWorker;