PREDICATES

is_even(integer)
is_odd(integer)

CLAUSES

is_even(X) :- X mod 2 = 0,
		Write(X, " - even"),!;
		Write(X, " - odd").
is_odd(X) :- NOT(is_even(X)).

GOAL

Write("X="),readreal(X),

is_even(X),nl.