PREDICATES
country(string, string, integer, string)
show_all()
show_greater_then(integer)
show_lesser_then(integer)

CLAUSES

country("russia", "moscow", 146,"europe").
country("belarus", "minsk", 9,"europe").
country("china","pekin", 1386, "asia").
country("kanada","ottawa",36,"amerika").

show_all() :- country(X,Y,Z,Q), writef("country: %s. capital: %s. peopleCount: %dM. Continent: %s.",X,Y,Z,Q), nl, fail.
show_greater_then(V):- country(X,Y,Z,Q), Z>V, writef("country: %s. capital: %s. peopleCount: %dM. Continent: %s.",X,Y,Z,Q),nl, fail.
show_lesser_then(V):- country(X,Y,Z,Q), Z<V, writef("country: %s. capital: %s. peopleCount: %dM. Continent: %s.", X,Y,Z,Q), nl, fail.

GOAL
show_lesser_then(40).