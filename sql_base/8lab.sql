CREATE FUNCTION check_provider() RETURNS TRIGGER AS $check_provider$
DECLARE
  rating_provider INTEGER;
  detail_price MONEY;
BEGIN
  rating_provider=(SELECT rating FROM provider WHERE id=NEW.id_provider);
  detail_price=(SELECT detail.price FROM detail WHERE id=NEW.id_detail);
  IF (rating_provider<6) AND (detail_price>=1000::MONEY) THEN
    RAISE EXCEPTION 'Ненадёжный поставщик не может поставлять детали стоимостью больше 1000рублей';
  END IF;
  RETURN NEW;
END
$check_provider$ LANGUAGE plpgsql;

CREATE TRIGGER check_provider BEFORE INSERT OR UPDATE ON supply FOR EACH ROW EXECUTE PROCEDURE check_provider();

CREATE FUNCTION check_weight() RETURNS TRIGGER AS $$
DECLARE
weight INTEGER;
BEGIN
  weight=(SELECT detail.weight FROM detail WHERE id=NEW.id_detail);
  if(weight*NEW.number_of_details>1500000) THEN
    RAISE EXCEPTION 'Вес поставки не должен превышать 1.5т';
  END IF;
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER check_weight BEFORE INSERT OR UPDATE ON supply FOR EACH ROW EXECUTE PROCEDURE check_weight();

CREATE FUNCTION check_sum() RETURNS TRIGGER AS $$
DECLARE
  total_cost MONEY = 0;
  i RECORD;
BEGIN
  FOR i IN SELECT * FROM supply WHERE id_project=NEW.id_project
    LOOP
      total_cost=total_cost + (SELECT detail.price FROM detail WHERE id=(SELECT supply.id_detail FROM supply WHERE id=i.id))*(SELECT supply.number_of_details FROM supply WHERE supply.id=i.id);
  END LOOP;
  total_cost=total_cost+(SELECT detail.price FROM detail WHERE id = NEW.id_detail)*NEW.number_of_details;
  if(total_cost>(SELECT project.budget FROM project WHERE id=NEW.id_project)) THEN
    RAISE EXCEPTION 'Суммарная стоимость всех поставок не должна превышать стоимость проекта';
  END IF;
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER  check_sum BEFORE INSERT OR UPDATE ON supply FOR EACH ROW EXECUTE PROCEDURE check_sum();

INSERT INTO supply(id_detail, id_provider, id_project, number_of_details) VALUES (1,1,1,100);
