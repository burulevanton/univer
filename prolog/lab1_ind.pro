PREDICATES

pow(integer, integer, integer)
expr1(integer, integer, real)
expr2(integer, integer, real)


CLAUSES

pow(X,1,X) :-!.
pow(Y,N,X) :- N1=N-1, pow(Y, N1, X1), X=X1*Y.

GOAL

pow(3,4,X)
