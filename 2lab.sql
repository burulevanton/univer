CREATE TYPE Detail_colors AS ENUM( --фиксированный список цветов детали
  'чёрный',
  'белый',
  'красный',
  'синий',
  'серый',
  'зелёный',
  'жёлтый',
  'оранжевый'
);

CREATE TABLE Detail( -- таблица деталей
  id SERIAL PRIMARY KEY, --уникальный идентификатор детали, тип данных Serial для auto_increment, первичный ключ
  name VARCHAR(50) NOT NULL, --название детали, строковой тип данных, максимум 50 символов, не может быть пустым
  price MONEY CHECK (price>0 :: MONEY), --цена детали(в рублях), должна быть положительной
  color Detail_colors, --цвет детали, должен иметь значения из фиксированного списка
  weight INTEGER CHECK (weight>0) --вес детали(в граммах), проверка на положительность
);

CREATE TABLE Provider( --таблица поставщиков
  id SERIAL PRIMARY KEY, --уникальный идентификатор детали, auto_increment, первичный ключ
  name VARCHAR(50) NOT NULL , --название поставщика, строковый тип данных, максимум 50 символов
  city VARCHAR(50) NOT NULL , --город поставщика, строковый тип данных, максимум 50 символов
  UNIQUE(name, city), -- данное свойство обеспечивает уникальность названия поставщика в рамках города
  address VARCHAR(120) NOT NULL DEFAULT 'неизвестен', --адрес поставщика, 120 символов, не может быть пустым, по умолчанию - неизвестен
  rating INT CHECK (rating>=1 AND rating<=10) --рейтинг поставщика
);

CREATE TABLE Project( --таблица проектов
  id SERIAL PRIMARY KEY, --уникальный идентификатор проекта, auto_increment
  name VARCHAR(50)  NOT NULL, --название проекта, строковый тип данных, максимум 50 символов, не может быть пустым
  city VARCHAR(50) NOT NULL, --город проекта, строковый тип данных, максимум 50 символов, не может быть пустым
  address VARCHAR(120) NOT NULL, --адрес проекта, строковый тип данных, максимум 120 символов, не может быть пустым
  budget MONEY CHECK (budget>0::MONEY) --бюджет проекта, целочисленный тип данных, должен быть положительным
);

CREATE TABLE Supply( --таблица поставок
  id_detail INTEGER REFERENCES Detail(id) ON UPDATE CASCADE ON DELETE CASCADE , --уникальный идентификатор детали, внешний ключ
  id_provider INTEGER REFERENCES Provider(id) ON UPDATE CASCADE  ON DELETE CASCADE , --уникальный идентификатор поставщика, внешний ключ
  id_project INTEGER REFERENCES Project(id) ON UPDATE CASCADE ON DELETE CASCADE , --уникальный идентификатор проекта, внешний ключ
  number_of_details INTEGER CHECK (number_of_details>0) --количество деталей, должен быть положительным
);