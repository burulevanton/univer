#pragma once

#include <iostream>

#include <string>
#include <fstream>
#include <map>
#include <vector>
#include <sstream>

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
    void readGraph(std::ifstream& file) override ;
    void addEdge(int from, int to, int weight) override ;
    void removeEdge(int from, int to) override ;
    int changeEdge(int from, int to, int newWeight) override ;
    GraphAdjMatrix* toAdjMatrix() override ;
    GraphAdjList* toAdjList() override ;
    GraphListOfEdges * toListOfEdges() override ;
    void writeGraph(std::string fileName) override ;
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
    void readGraph(std::ifstream& file) override ;
    void addEdge(int from, int to, int weight) override ;
    void removeEdge(int from, int to) override ;
    int changeEdge(int from, int to, int newWeight) override ;
    GraphAdjMatrix* toAdjMatrix() override ;
    GraphAdjList* toAdjList() override ;
    GraphListOfEdges * toListOfEdges() override ;
    void writeGraph(std::string fileName) override ;
};

class GraphListOfEdges :
        public IGraph
{
private:
    bool isOriented, isWeight;
    int vertexCount;
    std::map<std::pair<int, int>, int> data;
public:
    GraphListOfEdges(){};
    GraphListOfEdges(bool isOriented, bool isWeight, int vertexCount);
    void readGraph(std::ifstream& file) override ;
    void addEdge(int from, int to, int weight) override ;
    void removeEdge(int from, int to) override ;
    int changeEdge(int from, int to, int newWeight) override ;
    GraphAdjMatrix* toAdjMatrix() override ;
    GraphAdjList* toAdjList() override ;
    GraphListOfEdges * toListOfEdges() override ;
    void writeGraph(std::string fileName) override ;
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
    for(auto i = 0; i<this->data.size();i++)
        for(const auto &pair : data[i])
            graph->addEdge(i,pair.first,pair.second);
    return graph;
}

GraphListOfEdges* GraphAdjList::toListOfEdges() {
    auto graph = new GraphListOfEdges(this->isOriented, this->isWeight, this->data.size());
    for(auto i =0;i<data.size();i++)
        for(const auto &pair : data[i])
            graph->addEdge(i,pair.first,pair.second);
    return graph;
}

GraphAdjList::GraphAdjList(bool isOriented, bool isWeight, int countOfVortex) : isOriented(isOriented),
                                                                                isWeight(isWeight){
    this->data = std::vector<std::map<int,int>>(countOfVortex);
}

void GraphAdjList::readGraph(std::ifstream &file) {
    int countOfVertex;
    file>>countOfVertex;
    file>>this->isOriented;
    file>>this->isWeight;
    this->data = std::vector<std::map<int,int>>(countOfVertex);
    for(int i=0;i<countOfVertex;i++)
    {
        std::string s;
        getline(file, s);
        std::istringstream input(s);
        while(!input.eof()) {
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
    file<<"L "<<this->data.size()<<"\n";
    file<<isOriented<<" "<<isWeight<<"\n";
    for(const auto &row : this->data) {
        std::string del;
        for(const auto &pair : row){
            file<<del<<(pair.first+1);
            if(this->isWeight)
                file<<" "<<pair.second;
            del = " ";
        }
        file<<"\n";
    }
    file.close();
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
    for(auto i =0;i<size;i++)
        this->data.emplace_back(size);
}

GraphAdjMatrix* GraphAdjMatrix::toAdjMatrix() {
    return this;
}

GraphAdjList* GraphAdjMatrix::toAdjList() {
    auto graph = new GraphAdjList(this->isOriented, this->isWeight, this->data.size());
    for(auto i=0;i<data.size();i++)
        for(auto j=0;j<data[i].size();j++)
            if(data[i][j] != 0)
                graph->addEdge(i, j, data[i][j]);
    return graph;
}

GraphListOfEdges* GraphAdjMatrix::toListOfEdges() {
    auto graph = new GraphListOfEdges(this->isOriented, this->isWeight, this->data.size());
    for(auto i=0;i<data.size();i++)
        for(auto j=0;j<data[i].size();j++)
            if(data[i][j]!=0)
                graph->addEdge(i,j,data[i][j]);
    return graph;
}

void GraphAdjMatrix::readGraph(std::ifstream &file) {
    int countOfVortex;
    file>>countOfVortex;
    file>>this->isOriented;
    file>>this->isWeight;
    for(auto i=0;i<countOfVortex;i++)
        this->data.emplace_back(countOfVortex);
    for(auto i=0;i<countOfVortex;i++)
        for(auto j=0;j<countOfVortex;j++)
        {
            int weight;
            file>>weight;
            if(weight!=0)
                this->addEdge(i,j,weight);
        }
    file.close();
}

void GraphAdjMatrix::writeGraph(std::string fileName) {
    std::ofstream file(fileName);
    file<<"C "<<this->data.size()<<"\n";
    file<<isOriented<<" "<<isWeight<<"\n";
    for(const auto &row : this->data) {
        std::string del;
        for(const auto &item : row){
            file<<del<<item;
            del = " ";
        }
        file<<"\n";
    }
    file.close();
}

/*GraphAdjMatrix end*/

/*GraphListOfEdges start*/

void GraphListOfEdges::addEdge(int from, int to, int weight)
{
    if (!isWeight)
        weight = 1;
    data[std::make_pair(from, to)] = weight;
    if (!isOriented)
        data[std::make_pair(to, from)] = weight;
}

void GraphListOfEdges::removeEdge(int from, int to)
{
    data.erase(std::make_pair(from, to));
    if (!isOriented)
        data.erase(std::make_pair(to, from));
}

int GraphListOfEdges::changeEdge(int from, int to, int newWeight)
{
    int oldWeight = data[std::make_pair(from, to)];
    data[std::make_pair(from, to)] = newWeight;
    if (!isOriented)
        data[std::make_pair(to, from)] = newWeight;
    return oldWeight;
}

GraphListOfEdges::GraphListOfEdges(bool isOriented, bool isWeight, int vertexCount) :isOriented(isOriented),
                                                                                     isWeight(isWeight),
                                                                                     vertexCount(vertexCount) {}

GraphListOfEdges* GraphListOfEdges::toListOfEdges() { return this;}

GraphAdjList* GraphListOfEdges::toAdjList() {
    auto graph = new GraphAdjList(this->isOriented, this->isWeight, this->vertexCount);
    for(const auto &item : data)
        graph->addEdge(item.first.first,item.first.second, item.second);
    return graph;
}

GraphAdjMatrix* GraphListOfEdges::toAdjMatrix() {
    auto graph = new GraphAdjMatrix(this->isOriented, this->isWeight, this->vertexCount);
    for(const auto &item : data)
        graph->addEdge(item.first.first,item.first.second, item.second);
    return graph;
}

void GraphListOfEdges::readGraph(std::ifstream &file) {
    file>>this->vertexCount;
    int m;
    file>>m;
    file>>this->isOriented;
    file>>this->isWeight;
    for(auto i=0;i<m;i++)
    {
        int from,to,weight;
        file>>from>>to;
        if(isWeight)
            file>>weight;
        this->addEdge(from-1,to-1,weight);
    }
    file.close();
}

void GraphListOfEdges::writeGraph(std::string fileName) {
    std::ofstream file(fileName);
    file<<"E "<<this->vertexCount<<" "<<this->data.size()<<"\n";
    file<<isOriented<<" "<<isWeight<<"\n";
    for(const auto &item : this->data) {
        file<<(item.first.first+1) << " "<<(item.first.second+1);
        if(isWeight)
            file<<" "<<item.second;
        file<<"\n";
    }
    file.close();
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
        if(type == "L")
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
};

