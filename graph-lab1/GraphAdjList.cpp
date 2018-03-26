#include "GraphAdjList.h"
#include <sstream>

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
        string s;
        getline(s,file);
        std::istringstream input(s);
        while(!input.eof()) {
            int to, weight;
            file >> to;
            if (isWeight)
                file >> weight;
            addEdge(i, to - 1, weight);
        }
    }
}