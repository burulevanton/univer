#include "GraphListOfEdges.h"


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
            file<<item.second;
        file<<"\n";
    }
    file.close();
}