PREDICATES 
show_all(integer, integer, integer)
check(integer, integer, integer)

CLAUSES

check(X,Y,Z) :- not(X=Z) and not(Y=Z) and not(X=Y), writef("%d%d%d",X,Y,Z), nl; true.
show_all(X,Y,Z) :- check(X,Y,Z),
		Z<9, Z1= Z+1, show_all(X,Y,Z1);
		Y<9, Y1= Y+1, show_all(X,Y1,0);
		X<9, X1=X+1, show_all(X1,0,0); true.
		
GOAL
show_all(1,0,0).