CREATE VIEW economist_providers AS SELECT
  provider.name,
  provider.city,
  provider.address,
  provider.rating,
  CASE WHEN rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS description
  FROM provider
  ORDER BY city,name, rating DESC;

CREATE VIEW economist_details AS SELECT
  detail.name,
  detail.price/1000 AS price,
  detail.color,
  detail.weight::REAL/1000 AS weight,
  CASE WHEN price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS description
  FROM detail
  ORDER BY price DESC, name, color, weight ASC;

CREATE VIEW economist_projects AS SELECT
  project.name,
  project.city,
  project.address,
  project.budget
  FROM project
  ORDER BY city,name, budget DESC;

CREATE VIEW economist_supply AS SELECT
  detail.name AS detail_name,
  project.city AS detail_city,
  detail.color,
  CASE WHEN detail.price<1000::MONEY
    THEN 'дешёвая'
    ELSE 'дорогая'
    END AS detail_description,
  provider.name AS provider_name,
  provider.city AS provider_city,
  CASE WHEN provider.rating<6
    THEN 'ненадёжный'
    ELSE 'надёжный'
    END AS provider_description,
  supply.number_of_details,
  detail.weight::REAL*supply.number_of_details/1000 AS total_weight,
  detail.price*supply.number_of_details/1000 AS total_cost
  FROM project, detail, provider,supply
  WHERE supply.id_detail=detail.id AND supply.id_project=project.id AND supply.id_provider=provider.id
  ORDER BY detail_name, provider_name, total_cost DESC , total_weight DESC;