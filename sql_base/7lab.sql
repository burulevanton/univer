CREATE ROLE economist;
grant SELECT, INSERT, UPDATE, DELETE on provider, supply to economist;
grant SELECT on detail, project to economist;

create role director;
grant SELECT, INSERT, UPDATE, DELETE on provider, detail, project to director;
grant SELECT, DELETE on supply to director;

CREATE USER economist1 WITH PASSWORD 'economist';
GRANT economist to economist1;

CREATE USER director1 WITH PASSWORD 'director';
GRANT director to director1;
