#include <iostream>
#include "Graph.h"
using namespace std;

int main(){
    Graph g;
    g.readGraph("E:\\graph\\graph-lab2\\input.txt");
    g.transformToAdjList();
    g.transformToListOfEdges();
    Graph kek = g.getSpaingTreePrima();
    kek.transformToListOfEdges();
    kek.writeGraph("E:\\graph\\graph-lab2\\output.txt");
    return 0;
}