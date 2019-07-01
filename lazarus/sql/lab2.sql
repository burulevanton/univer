CREATE TABLE Department(
  id SERIAL PRIMARY KEY,
  name VARCHAR(120) NOT NULL,
  phone_number VARCHAR(30) NOT NULL,
  head_of_department VARCHAR(50) not null
);

CREATE table Teacher(
  id SERIAL PRIMARY KEY,
  name varchar(20) not null ,
  surname varchar(20) not null ,
  patronymic varchar(30) not null,
  academic_title varchar(50) not null,
  id_department integer references Department(id) on update cascade on delete cascade
);

CREATE TABLE UniversityGroup(
  id SERIAL PRIMARY KEY,
  number INTEGER not null,
  department_id integer references Department(id) on update cascade on delete cascade,
  students_amount INTEGER not null ,
  average_score REAL not null ,
  group_leader varchar(50) not null
);

create table Student(
  id serial primary key,
  id_group integer references UniversityGroup(id) on update cascade on delete cascade,
  number_in_group integer not null,
  name varchar(20) not null,
  surname varchar(20) not null,
  patronymic varchar(30) not null,
  birth_date date not null,
  address varchar(100) not null,
  average_score real not null
);

CREATE TABLE Subject(
  id SERIAL PRIMARY KEY,
  name VARCHAR(50) not null,
  hours_amount integer not null,
  hours_of_lectures integer not null,
  hours_of_practice integer not null,
  number_of_semesters integer not null
);

create table Performance(
  id_student integer references Student(id) on update cascade on delete cascade,
  id_group integer references UniversityGroup(id) on update cascade on delete cascade,
  id_subject integer references Subject(id) on update cascade on delete cascade,
  id_teacher integer references Teacher(id) on update cascade on delete cascade,
  score integer not null
);


