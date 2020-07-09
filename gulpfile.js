const gulp = require('gulp');
const shell = require('gulp-shell');
const { series } = require('gulp');

function startDb() {
    return gulp.src(__filename)
        .pipe(shell(['docker-compose up -d tv-cast-db']));
}

function ddlDbCreate() {
    return gulp.src(__filename)
        .pipe(shell(['docker-compose exec -d tv-cast-db bash -c "psql -U tvcast -d postgres -a -f /sql/postgres_db.sql"']))
        .pipe(shell(['docker-compose exec -d tv-cast-db bash -c "psql -U tvcast -d postgres -a -f /sql/postgres_public_person.sql"']))
        .pipe(shell(['docker-compose exec -d tv-cast-db bash -c "psql -U tvcast -d postgres -a -f /sql/postgres_public_character.sql"']))
        .pipe(shell(['docker-compose exec -d tv-cast-db bash -c "psql -U tvcast -d postgres -a -f /sql/postgres_public_show.sql"']))
        .pipe(shell(['docker-compose exec -d tv-cast-db bash -c "psql -U tvcast -d postgres -a -f /sql/postgres_public_casting.sql"']));
}

function build() {
    return gulp.src(__filename)
        .pipe(shell(['dotnet build']));
}

function publishWorker() {
    return gulp.src(__filename)
        .pipe(shell(['dotnet publish TvCast.ApiWorker -o ./wwwroot/worker']));
}

function publishApi() {
    return gulp.src(__filename)
        .pipe(shell(['dotnet publish TvCast.Api -o ./wwwroot/api']));
}

function startApi() {
    return gulp.src(__filename)
        .pipe(shell(['docker-compose up -d tv-cast-api']));
}

function startWorker() {
    return gulp.src(__filename)
        .pipe(shell(['docker-compose up -d tv-cast-worker']));
}

function logsWorker() {
    return gulp.src(__filename)
        .pipe(shell(['docker-compose logs tv-cast-worker']));
}

exports.startDb = startDb;
exports.ddlDbCreate = ddlDbCreate;
exports.build = build;
exports.publishWorker = publishWorker;
exports.publishApi = publishApi;
exports.startApi = startApi;
exports.startWorker = startWorker;
exports.logsWorker = logsWorker;

exports.default = series(startDb, build, publishWorker, publishApi, ddlDbCreate, startApi, startWorker);