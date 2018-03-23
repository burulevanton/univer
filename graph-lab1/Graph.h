#pragma once

#include "IGraph.h"


class Graph {
private:
	IGraph * _graph;
	void renewGraph(IGraph *newGraph);
public:
	void readGraph(std::string fileName);
	void addEdge(int from, int to, int weight);
	void removeEdge(int from, int to);
	int changeEdge(int from, int to, int newWeight);
	void transformToAdjMatrix();
	void transfromToAdjList();
	void transformToListOfEdges();
	void writeGraph(std::string fileName);
};

