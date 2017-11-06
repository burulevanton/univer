SELECT * FROM economist_providers; --список всех поставщиков
SELECT * FROM economist_providers WHERE description = 'надёжный'; --список всех надёжных поставщиков
SELECT * FROM economist_providers WHERE description = 'ненадёжный'; --список всех ненадёжных поставщиков

SELECT * FROM economist_details; --список всех деталей
SELECT * FROM economist_details WHERE description='дорогая'; --список всех дорогих деталей
SELECT * FROM economist_details WHERE description='дешёвая'; --список всех дешёвых деталей

SELECT * FROM economist_projects; --список всех проектов
SELECT * FROM economist_projects WHERE city='Челябинск'; --список всех проектов из Челябинска
SELECT * FROM economist_projects WHERE budget>70000::MONEY; --список всех проектов больше 70000

SELECT * FROM economist_supply; --список всех поставок
SELECT * FROM economist_supply WHERE detail_description='дорогая'; --список всех поставок дорогих деталей
SELECT * FROM economist_supply WHERE detail_description='дешёвая'; --список всех поставок дешёвых деталей
SELECT * FROM economist_supply WHERE provider_description='надёжный'; --список всех поставок от надёжных поставщиков
SELECT * FROM economist_supply WHERE provider_description='ненадёжный'; --список всех поставок от ненадёжных поставщиков
SELECT * FROM economist_supply WHERE total_cost > 90::MONEY;-- список всех поставок по стоимости превыщающих 90тысяч рублей