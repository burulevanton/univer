#include <iostream>
#include "Graph.h"
using namespace std;

int main(){
    Graph g;
    g.readGraph("input.txt");
    //Graph gg=g.getSpaingTreeBoruvka();
    Graph gg = g.getSpaingTreeKruscal();
    // Graph gg=g.getSpaingTreePrima();
    //gg.transformToAdjList();
    gg.writeGraph("output.txt");
    return 0;
}