#include "GraphAdjMatrix.h"

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
                graph->addEdge(i, j, data[i][k]);
    return graph;
}

GraphListOfEdges* GraphAdjList::toListOfEdges() {
    auto graph = new GraphListOfEdges(this->isOriented, this->isWeight, this->data.size());
    for(auto i=0;i<data.size();i++)
        for(auto j=0;j<data[i].size();j++)
            if(data[i][j]!=0)
                graph->addEdge(i,j,data[i][j]);
    return graph;
}

void GraphAdjMatrix::readGraph(std::ifstream& file) {
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
}