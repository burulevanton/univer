#pragma once
#include "IGraph.h"
#include <vector>
#include <map>
class GraphAdjList :
	public IGraph
{
private:
	bool isOriented, isWeight;
	std::vector<std::map<int, int>> data;
public:
    GraphAdjList(bool isOriented, bool isWeight, int countOfVortex);
	void readGraph(std::ifstream& file);
	void addEdge(int from, int to, int weight);
	void removeEdge(int from, int to);
	int changeEdge(int from, int to, int newWeight);
	GraphAdjMatrix* toAdjMatrix();
	GraphAdjList* toAdjList();
	GraphListOfEdges * toListOfEdges();
	void writeGraph(std::string fileName);
};

