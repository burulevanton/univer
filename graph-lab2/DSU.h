#ifndef GRAPH_LAB1_DSU_H
#define GRAPH_LAB1_DSU_H

#include <vector>


class DSU {
private:
    std::vector<int> p;
    std::vector<int> rank;
public:
    explicit DSU(int n);
    void makeSet(int x);
    int find(int x);
    void unite(int x, int y);
};


#endif