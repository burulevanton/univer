SELECT
  provider.name,
  provider.city,
  CASE WHEN provider.rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM provider INNER JOIN supply ON provider.id = supply.id_provider INNER JOIN detail ON supply.id_detail = detail.id
  GROUP BY provider.id
  ORDER BY description, city, name; --список всех поставщиков

SELECT --список поставщиков с рейтингом ниже среднего
  provider.name,
  provider.city,
  CASE WHEN provider.rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM provider INNER JOIN supply ON provider.id = supply.id_provider INNER JOIN detail ON supply.id_detail = detail.id
  WHERE rating<=(SELECT AVG(rating) FROM provider)
  GROUP BY provider.id
  ORDER BY description, city, name;

SELECT --список поставщиков с рейтингом выше среднего
  provider.name,
  provider.city,
  CASE WHEN provider.rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM provider INNER JOIN supply ON provider.id = supply.id_provider INNER JOIN detail ON supply.id_detail = detail.id
  WHERE rating>=(SELECT AVG(rating) FROM provider)
  GROUP BY provider.id
  ORDER BY description, city, name;

SELECT --список поставщиков с максимальным рейтингом
  provider.name,
  provider.city,
  CASE WHEN provider.rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM provider INNER JOIN supply ON provider.id = supply.id_provider INNER JOIN detail ON supply.id_detail = detail.id
  WHERE rating=(SELECT MAX(rating) FROM provider)
  GROUP BY provider.id
  ORDER BY description, city, name;

SELECT --список поставщиков с минимальным рейтингом
  provider.name,
  provider.city,
  CASE WHEN provider.rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM provider INNER JOIN supply ON provider.id = supply.id_provider INNER JOIN detail ON supply.id_detail = detail.id
  WHERE rating=(SELECT MIN(rating) FROM provider)
  GROUP BY provider.id
  ORDER BY description, city, name;

SELECT --список всех деталей
  detail.name,
  detail.price/1000 AS price,
  detail.color,
  CASE WHEN price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM detail INNER JOIN supply ON detail.id = supply.id_detail
  GROUP BY detail.id
  ORDER BY price DESC, name;

SELECT --список всех деталей с ценой выше средней
  detail.name,
  detail.price/1000 AS price,
  detail.color,
  CASE WHEN price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM detail INNER JOIN supply ON detail.id = supply.id_detail
  WHERE price::NUMERIC>=(SELECT AVG(price::NUMERIC) FROM detail)
  GROUP BY detail.id
  ORDER BY price DESC, name;

SELECT --список всех деталей с ценой ниже средней
  detail.name,
  detail.price/1000 AS price,
  detail.color,
  CASE WHEN price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM detail INNER JOIN supply ON detail.id = supply.id_detail
  WHERE price::NUMERIC<=(SELECT AVG(price::NUMERIC) FROM detail)
  GROUP BY detail.id
  ORDER BY price DESC, name;

SELECT --список всех деталей с минимальной ценой
  detail.name,
  detail.price/1000 AS price,
  detail.color,
  CASE WHEN price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM detail INNER JOIN supply ON detail.id = supply.id_detail
  WHERE price=(SELECT MIN(price) FROM detail)
  GROUP BY detail.id
  ORDER BY price DESC, name;

SELECT --список всех деталей с максимальной ценной
  detail.name,
  detail.price/1000 AS price,
  detail.color,
  CASE WHEN price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS description,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM detail INNER JOIN supply ON detail.id = supply.id_detail
  WHERE price=(SELECT MAX(price) FROM detail)
  GROUP BY detail.id
  ORDER BY price DESC, name;

SELECT --список всех проектов
  project.name,
  project.city,
  project.budget,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM project INNER JOIN supply ON project.id = supply.id_project INNER JOIN detail ON supply.id_detail = detail.id
  GROUP BY project.id
  ORDER BY budget DESC, city, name;

SELECT --список всех проектов с бюджетом выше среднего
  project.name,
  project.city,
  project.budget,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM project INNER JOIN supply ON project.id = supply.id_project INNER JOIN detail ON supply.id_detail = detail.id
  WHERE project.budget::NUMERIC>=(SELECT AVG(budget::NUMERIC) FROM project)
  GROUP BY project.id
  ORDER BY budget DESC, city, name;

SELECT --список всех проектов с бюджетом ниже среднего
  project.name,
  project.city,
  project.budget,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM project INNER JOIN supply ON project.id = supply.id_project INNER JOIN detail ON supply.id_detail = detail.id
  WHERE project.budget::NUMERIC<=(SELECT AVG(budget::NUMERIC) FROM project)
  GROUP BY project.id
  ORDER BY budget DESC, city, name;

SELECT --список всех проектов с максимальным бюджетом
  project.name,
  project.city,
  project.budget,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM project INNER JOIN supply ON project.id = supply.id_project INNER JOIN detail ON supply.id_detail = detail.id
  WHERE project.budget=(SELECT MAX(budget) FROM project)
  GROUP BY project.id
  ORDER BY budget DESC, city, name;

SELECT --список всех проектов с минимальным бюджетом
  project.name,
  project.city,
  project.budget,
  SUM(detail.price*supply.number_of_details/1000) AS sum_cost
  FROM project INNER JOIN supply ON project.id = supply.id_project INNER JOIN detail ON supply.id_detail = detail.id
  WHERE project.budget=(SELECT MIN(budget) FROM project)
  GROUP BY project.id
  ORDER BY budget DESC, city, name;

SELECT Sum(total_cost) FROM director_supply; --сумма всех поставок

SELECT Sum(total_cost) FROM director_supply WHERE detail_description='дорогая'; --сумма поставок дорогих деталей
SELECT Sum(total_cost) FROM director_supply WHERE detail_description='дешёвая'; --сумма поставок дешёвых деталей

SELECT Sum(total_cost) FROM director_supply WHERE provider_description='надёжный'; --сумма поставок от надёжных поставщиков
SELECT Sum(total_cost) FROM director_supply WHERE provider_description='ненадёжный'; --сумма поставок от ненадёжных поставщиков

SELECT Sum(total_cost) FROM director_supply WHERE provider_name='Стройкомплект1';
