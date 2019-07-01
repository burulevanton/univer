#include <iostream>

#include <string>
#include <fstream>
#include <map>
#include <vector>
#include <sstream>
#include <algorithm>
#include <functional>
#include <limits>
#include <queue>


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
    else {
        p[y] = x;
        if (rank[x] == rank[y])
            ++rank[x];
    }
}

class GraphAdjMatrix;
class GraphAdjList;
class GraphListOfEdges;

class IGraph {
public:
    virtual void readGraph(std::ifstream& file) = 0;
    virtual void addEdge(int from, int to, int weight) = 0;
    virtual void removeEdge(int from, int to) = 0;
    virtual int changeEdge(int from, int to, int newWeight) = 0;
    virtual GraphAdjMatrix* toAdjMatrix() = 0;
    virtual GraphAdjList* toAdjList() = 0;
    virtual GraphListOfEdges* toListOfEdges() = 0;
    virtual void writeGraph(std::string fileName) = 0;
};

class GraphAdjList :
        public IGraph
{
private:
    bool isOriented, isWeight;
    std::vector<std::map<int, int>> data;
public:
    GraphAdjList() = default;
    GraphAdjList(bool isOriented, bool isWeight, int countOfVortex);
    void readGraph(std::ifstream& file) override;
    void addEdge(int from, int to, int weight) override;
    void removeEdge(int from, int to) override;
    int changeEdge(int from, int to, int newWeight) override;
    GraphAdjMatrix* toAdjMatrix() override;
    GraphAdjList* toAdjList() override;
    GraphListOfEdges * toListOfEdges() override;
    void writeGraph(std::string fileName) override;

    IGraph *getSpaingTreePrima() const;
};

class GraphAdjMatrix :
        public IGraph
{
private:
    bool isOriented, isWeight;
    std::vector<std::vector<int>> data;
public:
    GraphAdjMatrix() = default;
    GraphAdjMatrix(bool isOriented, bool isWeight, int size);
    void readGraph(std::ifstream& file) override;
    void addEdge(int from, int to, int weight) override;
    void removeEdge(int from, int to) override;
    int changeEdge(int from, int to, int newWeight) override;
    GraphAdjMatrix* toAdjMatrix() override;
    GraphAdjList* toAdjList() override;
    GraphListOfEdges * toListOfEdges() override;
    void writeGraph(std::string fileName) override;
};

class GraphListOfEdges :
        public IGraph
{
private:
    bool isOriented, isWeight;
    int vertexCount;
    std::map<std::pair<int, int>, int> data;
public:
    GraphListOfEdges() = default;
    GraphListOfEdges(bool isOriented, bool isWeight, int vertexCount);
    void readGraph(std::ifstream& file) override;
    void addEdge(int from, int to, int weight) override;
    void removeEdge(int from, int to) override;
    int changeEdge(int from, int to, int newWeight) override;
    GraphAdjMatrix* toAdjMatrix() override;
    GraphAdjList* toAdjList() override;
    GraphListOfEdges * toListOfEdges() override;
    void writeGraph(std::string fileName) override;

    IGraph *getSpaingTreeKruscal()const;
    IGraph *getSpaingTreeBoruvka() const;

};

/*GraphAdjList start*/

void GraphAdjList::addEdge(int from, int to, int weight)
{
    if (!isWeight)
        weight = 1;
    data[from][to] = weight;
    if (!isOriented)
        data[to][from] = weight;
}
int GraphAdjList::changeEdge(int from, int to, int newWeight)
{
    int oldWeight = data[from][to];
    data[from][to] = newWeight;
    if (!isOriented)
        data[from][to] = newWeight;
    return oldWeight;
}

void GraphAdjList::removeEdge(int from, int to)
{
    data[from].erase(to);
    if (!isOriented)
        data[to].erase(from);
}

GraphAdjList * GraphAdjList::toAdjList()
{
    return this;
}

GraphAdjMatrix* GraphAdjList::toAdjMatrix() {
    auto graph = new GraphAdjMatrix(this->isOriented, this->isWeight, this->data.size());
    for (auto i = 0; i<this->data.size(); i++)
        for (const auto &pair : data[i])
            graph->addEdge(i, pair.first, pair.second);
    return graph;
}

GraphListOfEdges* GraphAdjList::toListOfEdges() {
    auto graph = new GraphListOfEdges(this->isOriented, this->isWeight, this->data.size());
    for (auto i = 0; i<data.size(); i++)
        for (const auto &pair : data[i])
            graph->addEdge(i, pair.first, pair.second);
    return graph;
}

GraphAdjList::GraphAdjList(bool isOriented, bool isWeight, int countOfVortex) : isOriented(isOriented),
                                                                                isWeight(isWeight) {
    this->data = std::vector<std::map<int, int>>(countOfVortex);
}

void GraphAdjList::readGraph(std::ifstream &file) {
    int countOfVertex;
    file >> countOfVertex;
    file >> this->isOriented;
    file >> this->isWeight;
    this->data = std::vector<std::map<int, int>>(countOfVertex);
    for (int i = 0; i<countOfVertex; i++)
    {
        std::string s;
        getline(file, s);
        std::istringstream input(s);
        while (!input.eof()) {
            int to, weight;
            file >> to;
            if (isWeight)
                file >> weight;
            addEdge(i, to - 1, weight);
        }
    }
    file.close();
}

void GraphAdjList::writeGraph(std::string fileName) {
    std::ofstream file(fileName);
    file << "L " << this->data.size() << "\n";
    file << isOriented << " " << isWeight << "\n";
    std::vector<std::vector<std::pair<int, int>>> _data;
    for (const auto &row : this->data) {
        std::vector<std::pair<int, int>> pairs(row.begin(), row.end());
        std::sort(pairs.begin(), pairs.end(), [](const std::pair<int, int> &a,
                                                 const std::pair<int, int> &b) {
            return a.second < b.second;
        });
        _data.emplace_back(pairs);
    }
    for (const auto &row : _data) {
        std::string del;
        for (const auto &pair : row) {
            file << del << (pair.first + 1);
            if (this->isWeight)
                file << " " << pair.second;
            del = " ";
        }
        file << "\n";
    }
    file.close();
}

IGraph* GraphAdjList::getSpaingTreePrima() const {
    std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>> pq;
    std::vector<int> distances(data.size(), std::numeric_limits<int>::max());
    std::vector<int> parent(data.size(), -1);
    std::vector<bool> inMST(data.size(), false);
    pq.push(std::make_pair(0, 0));
    distances[0] = 0;

    while (!pq.empty()) {
        auto u = pq.top().second;
        pq.pop();
        inMST[u] = true;
        for (const auto &pair : data[u]) {
            int v = pair.first;
            int weight = pair.second;
            if (!inMST[v] && distances[v] > weight) {
                distances[v] = weight;
                pq.push(std::make_pair(distances[v], v));
                parent[v] = u;
            }
        }
    }

    auto graph = new GraphAdjList(isOriented, isWeight, data.size());
    for (int i = 1; i < parent.size(); i++)
        graph->addEdge(parent[i], i, distances[i]);
    return graph;
}

/*GraphAdjList end*/

/*GraphAdjMatrix start*/
void GraphAdjMatrix::addEdge(int from, int to, int weight)
{
    if (!isWeight)
        weight = 1;
    data[from][to] = weight;
    if (!isOriented)
        data[to][from] = weight;
}

void GraphAdjMatrix::removeEdge(int from, int to)
{
    data[from][to] = 0;
    if (!isOriented)
        data[to][from] = 0;
}

int GraphAdjMatrix::changeEdge(int from, int to, int newWeight)
{
    int oldWeight = data[from][to];
    data[from][to] = newWeight;
    if (!isOriented)
        data[to][from] = newWeight;
    return oldWeight;
}
GraphAdjMatrix::GraphAdjMatrix(bool isOriented, bool isWeight, int size) : isOriented(isOriented), isWeight(isWeight) {
    for (auto i = 0; i<size; i++)
        this->data.emplace_back(size);
}

GraphAdjMatrix* GraphAdjMatrix::toAdjMatrix() {
    return this;
}

GraphAdjList* GraphAdjMatrix::toAdjList() {
    auto graph = new GraphAdjList(this->isOriented, this->isWeight, this->data.size());
    for (auto i = 0; i<data.size(); i++)
        for (auto j = 0; j<data[i].size(); j++)
            if (data[i][j] != 0)
                graph->addEdge(i, j, data[i][j]);
    return graph;
}

GraphListOfEdges* GraphAdjMatrix::toListOfEdges() {
    auto graph = new GraphListOfEdges(this->isOriented, this->isWeight, this->data.size());
    for (auto i = 0; i<data.size(); i++)
        for (auto j = 0; j<data[i].size(); j++)
            if (data[i][j] != 0)
                graph->addEdge(i, j, data[i][j]);
    return graph;
}

void GraphAdjMatrix::readGraph(std::ifstream &file) {
    int countOfVortex;
    file >> countOfVortex;
    file >> this->isOriented;
    file >> this->isWeight;
    for (auto i = 0; i<countOfVortex; i++)
        this->data.emplace_back(countOfVortex);
    for (auto i = 0; i<countOfVortex; i++)
        for (auto j = 0; j<countOfVortex; j++)
        {
            int weight;
            file >> weight;
            if (weight != 0)
                this->addEdge(i, j, weight);
        }
    file.close();
}

void GraphAdjMatrix::writeGraph(std::string fileName) {
    std::ofstream file(fileName);
    file << "C " << this->data.size() << "\n";
    file << isOriented << " " << isWeight << "\n";
    for (const auto &row : this->data) {
        std::string del;
        for (const auto &item : row) {
            file << del << item;
            del = " ";
        }
        file << "\n";
    }
    file.close();
}

/*GraphAdjMatrix end*/

/*GraphListOfEdges start*/

void GraphListOfEdges::addEdge(int from, int to, int weight)
{
    if (!isWeight)
        weight = 1;
    if (!isOriented && data.count(std::make_pair(to, from)) > 0)
        return;
    data[std::make_pair(from, to)] = weight;
    /*if (!isOriented)
        data[std::make_pair(to, from)] = weight;*/
}

void GraphListOfEdges::removeEdge(int from, int to)
{
    data.erase(std::make_pair(from, to));
    /*if (!isOriented)
        data.erase(std::make_pair(to, from));*/
}

int GraphListOfEdges::changeEdge(int from, int to, int newWeight)
{
    int oldWeight = data[std::make_pair(from, to)];
    data[std::make_pair(from, to)] = newWeight;
    /*if (!isOriented)
        data[std::make_pair(to, from)] = newWeight;*/
    return oldWeight;
}

GraphListOfEdges::GraphListOfEdges(bool isOriented, bool isWeight, int vertexCount) :isOriented(isOriented),
                                                                                     isWeight(isWeight),
                                                                                     vertexCount(vertexCount) {}

GraphListOfEdges* GraphListOfEdges::toListOfEdges() { return this; }

GraphAdjList* GraphListOfEdges::toAdjList() {
    auto graph = new GraphAdjList(this->isOriented, this->isWeight, this->vertexCount);
    for (const auto &item : data)
        graph->addEdge(item.first.first, item.first.second, item.second);
    return graph;
}

GraphAdjMatrix* GraphListOfEdges::toAdjMatrix() {
    auto graph = new GraphAdjMatrix(this->isOriented, this->isWeight, this->vertexCount);
    for (const auto &item : data)
        graph->addEdge(item.first.first, item.first.second, item.second);
    return graph;
}

void GraphListOfEdges::readGraph(std::ifstream &file) {
    file >> this->vertexCount;
    int m;
    file >> m;
    file >> this->isOriented;
    file >> this->isWeight;
    for (auto i = 0; i<m; i++)
    {
        int from, to, weight;
        file >> from >> to;
        if (isWeight)
            file >> weight;
        this->addEdge(from - 1, to - 1, weight);
    }
    file.close();
}

void GraphListOfEdges::writeGraph(std::string fileName) {
    std::ofstream file(fileName);
    file << "E " << this->vertexCount << " " << this->data.size() << "\n";
    file << isOriented << " " << isWeight << "\n";
    std::vector<std::pair<std::pair<int, int>, int>> pairs;
    for (const auto &pair : data)
        pairs.emplace_back(pair);
    std::sort(pairs.begin(), pairs.end(),
              [](const std::pair<std::pair<int, int>, int> &a,
                 const std::pair<std::pair<int, int>, int> &b) {
                  return a.second < b.second;
              });
    for (const auto &item : pairs) {
        file << (item.first.first + 1) << " " << (item.first.second + 1);
        if (isWeight)
            file << " " << item.second;
        file << "\n";
    }
    file.close();
}

IGraph *GraphListOfEdges::getSpaingTreeKruscal() const {
    auto pairs = std::vector<std::pair<std::pair<int, int>, int>>(data.begin(), data.end());
    sort(pairs.begin(), pairs.end(),
         [](std::pair<std::pair<int, int>, int> a,
            std::pair<std::pair<int, int>, int> b) {
             return a.second < b.second;
         });
    DSU dsu(vertexCount);
    for (int i = 0; i < vertexCount; i++)
        dsu.makeSet(i);

    auto graph = new GraphListOfEdges(isOriented, isWeight, vertexCount);
    for (auto &item : pairs) {
        int from = item.first.first;
        int to = item.first.second;
        if (dsu.find(from) != dsu.find(to)) {
            graph->addEdge(from, to, item.second);
            dsu.unite(from, to);
        }
    }
    return graph;
}

IGraph* GraphListOfEdges::getSpaingTreeBoruvka() const {
    auto pairs = std::vector<std::pair<std::pair<int, int>, int>>(data.begin(), data.end());

    DSU dsu(vertexCount);
    for (int i = 0; i < vertexCount; i++)
        dsu.makeSet(i);

    auto graph = new GraphListOfEdges(isOriented, isWeight, vertexCount);
    while (graph->data.size() < vertexCount - 1) {
        auto minEdges = std::map<int, int>();
        for (int i = 0; i < vertexCount; i++)
            minEdges[i] = -1;
        for (int i = 0; i < pairs.size(); i++) {
            auto edge = pairs[i];
            int fromComponent = dsu.find(edge.first.first);
            int toComponent = dsu.find(edge.first.second);
            if (fromComponent != toComponent) {
                if (minEdges[fromComponent] == -1 ||
                    pairs[minEdges[fromComponent]].second > edge.second)
                    minEdges[fromComponent] = i;
                if (minEdges[toComponent] == -1 ||
                    pairs[minEdges[toComponent]].second > edge.second)
                    minEdges[toComponent] = i;
            }
        }
        for (int i = 0; i< minEdges.size(); i++) {
            if (minEdges[i] != -1) {
                auto edge = pairs[minEdges[i]];
                dsu.unite(edge.first.first, edge.first.second);
                graph->addEdge(edge.first.first, edge.first.second, edge.second);
            }
        }
    }
    return graph;
}

/*GraphListOfEdges end*/
class Graph {
private:
    IGraph * _graph;
    void renewGraph(IGraph *newGraph) {
        if (newGraph == this->_graph)
            return;
        delete(this->_graph);
        this->_graph = newGraph;
    }
public:
    Graph() {
        this->_graph = nullptr;
    }
    void readGraph(std::string fileName) {
        std::ifstream file(fileName);
        std::string type;
        file >> type;
        if (type == "L")
            this->renewGraph((IGraph *) new GraphAdjList);
        else if (type == "C")
            this->renewGraph((IGraph *) new GraphAdjMatrix);
        else if (type == "E")
            this->renewGraph((IGraph *) new GraphListOfEdges);
        this->_graph->readGraph(file);
    }
    void addEdge(int from, int to, int weight) {
        this->_graph->addEdge(from, to, weight);
    }
    void removeEdge(int from, int to) {
        this->_graph->removeEdge(from, to);
    }
    int changeEdge(int from, int to, int newWeight) {
        return this->_graph->changeEdge(from, to, newWeight);
    }
    void transformToAdjMatrix() {
        auto newGraph = (IGraph *)this->_graph->toAdjMatrix();
        this->renewGraph(newGraph);
    }
    void transformToAdjList() {
        auto newGraph = (IGraph *)this->_graph->toAdjList();
        this->renewGraph(newGraph);
    }
    void transformToListOfEdges() {
        auto newGraph = (IGraph *)this->_graph->toListOfEdges();
        this->renewGraph(newGraph);
    }
    void writeGraph(std::string fileName) {
        this->_graph->writeGraph(fileName);
    }
    Graph getSpaingTreePrima() {
        transformToAdjList();
        IGraph *temp = reinterpret_cast<GraphAdjList *>(_graph)->getSpaingTreePrima();
        Graph g = Graph();
        g._graph = temp;
        return g;
    }
    Graph getSpaingTreeKruscal() {
        transformToListOfEdges();
        IGraph *temp = reinterpret_cast<GraphListOfEdges *>(_graph)->getSpaingTreeKruscal();
        Graph g = Graph();
        g._graph = temp;
        return g;
    }
    Graph getSpaingTreeBoruvka() {
        transformToListOfEdges();
        IGraph *temp = reinterpret_cast<GraphListOfEdges *>(_graph)->getSpaingTreeBoruvka();
        Graph g = Graph();
        g._graph = temp;
        return g;
    }
};

