-- global

REVOKE CREATE ON SCHEMA public FROM public;
REVOKE EXECUTE ON ALL FUNCTIONS IN SCHEMA public FROM public;

-- user [role]

CREATE ROLE role_user;

GRANT USAGE ON SCHEMA public TO role_user;
GRANT SELECT ON ALL TABLES IN SCHEMA public TO role_user;

-- operator [role]

CREATE ROLE role_operator;

GRANT role_user TO role_operator;
GRANT CREATE ON SCHEMA public TO role_operator;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA public TO role_operator;
GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO role_operator;
GRANT INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO role_operator;

-- admin [role]

CREATE ROLE role_admin;

GRANT role_operator TO role_admin;

-- users

CREATE USER "user"
  PASSWORD 'user';
GRANT role_user TO "user";

CREATE USER "operator"
  PASSWORD 'operator';
GRANT role_operator TO "operator";

CREATE USER "admin"
  PASSWORD 'admin'
  CREATEROLE;
GRANT role_admin TO "postgres", "admin";
