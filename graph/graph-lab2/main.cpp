#include <iostream>
#include "Graph.h"
using namespace std;

int main(){
    Graph g;
    g.readGraph("input.txt");
    g.transformToAdjMatrix();
    g.writeGraph("output.txt");
    //Graph gg=g.getSpaingTreeBoruvka();
    //Graph gg = g.getSpaingTreeKruscal();
    /*Graph gg=g.getSpaingTreePrima();
    gg.transformToAdjMatrix();
    gg.writeGraph("output.txt");*/
    return 0;
}