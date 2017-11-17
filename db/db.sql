CREATE TABLE Users(
  id SERIAL PRIMARY KEY,
  name text NOT NULL,
  password text NOT NULL ,
  phone text NOT NULL ,
  email text NOT NULL
);

CREATE TABLE Sessions (
  session_id UUID PRIMARY KEY,
  user_id INTEGER REFERENCES Users(id)
);