#include "DSU.h"

DSU::DSU(int n) {
    this->p = std::vector<int>(static_cast<size_t>(n));
    this->rank = std::vector<int>(static_cast<size_t>(n));
}

void DSU::makeSet(int x) {
    p[x] = x;
    rank[x] = 0;
}

int DSU::find(int x) {
    return (x == p[x] ? x : p[x] = find(p[x]));
}

void DSU::unite(int x, int y) {
    x = find(x);
    y = find(y);
    if (rank[x] < rank[y])
        p[x] = y;
    else{
        p[y] = x;
        if (rank[x] == rank[y])
            ++rank[x];
    }
}