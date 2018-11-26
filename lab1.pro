PREDICATES

is_negative(integer).
is_positive(integer).
_abs(integer, integer).
pow(integer, integer, integer).

expr1(integer, integer, real)
expr2(integer, integer, real)

CLAUSES

is_negative(X) :- X < 0.
is_positive(X) :- NOT(is_negative(X)).
_abs(X, Z) :- is_negative(X), Z = X * (-1).
_abs(X, Z) :- is_positive(X), Z = X.

pow(_, 0, 1) :- !.
pow(X, 1, X) :- !.
pow(X, Y, Z) :- is_positive(Y), COUNTER = Y - 1, pow(X, COUNTER, RESULT), Z = X * RESULT.
pow(X, Y, Z) :- is_negative(Y), _abs(Y, ABS_Y), pow(X, ABS_Y, RESULT), Z = 1 / RESULT.

expr1(X, Y, Z) :- X_Plus_6 = X + 6, pow(X_Plus_6, 2, X_POW_2), Z = X_POW_2 + Y / log(3.56).
expr2(X, Y, Z) :- pow(X,2,X_POW_2), First_bracket = 25+ Y + X_POW_2, pow(Y, X, Y_POW_X), Y_POW_X_6 = Y_POW_X * 6, Second_bracket = Y_POW_X_6 * sin(330), Z = First_bracket/Second_bracket.

GOAL

Write("X="),readreal(X),
Write("Y="),readreal(Y),
expr2(X,Y,Z).
