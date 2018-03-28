#pragma once
#include "IGraph.h"
#include <map>
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
	void readGraph(std::ifstream& file);
	void addEdge(int from, int to, int weight);
	void removeEdge(int from, int to);
	int changeEdge(int from, int to, int newWeight);
	GraphAdjMatrix* toAdjMatrix();
	GraphAdjList* toAdjList();
	GraphListOfEdges * toListOfEdges();
	void writeGraph(std::string fileName);
};

