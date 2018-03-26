#pragma once
#include "IGraph.h"
#include <vector>
class GraphAdjMatrix :
	public IGraph
{
private:
	bool isOriented, isWeight;
	std::vector<std::vector<int, int>> data;
public:
	GraphAdjMatrix(bool isOriented, bool isWeight, int size);
	void readGraph(std::ifstream file);
	void addEdge(int from, int to, int weight);
	void removeEdge(int from, int to);
	int changeEdge(int from, int to, int newWeight);
	GraphAdjMatrix* toAdjMatrix();
	GraphAdjList* toAdjList();
	GraphListOfEdges * toListOfEdges();
	void writeGraph(std::string fileName);
};

