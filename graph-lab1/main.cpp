#include <iostream>
#include <vector>
#include "Graph.h"
using namespace std;

int main(){
    Graph g;
    g.readGraph("E:\\graph\\graph-lab1\\input.txt");
    g.transformToAdjList();
    g.transformToListOfEdges();
    g.writeGraph("E:\\graph\\graph-lab1\\output.txt");
    return 0;
}