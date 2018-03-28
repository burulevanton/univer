#pragma once

#include <iostream>
#include "IGraph.h"


class Graph {
private:
	IGraph * _graph;
	void renewGraph(IGraph *newGraph);
public:
	Graph();
	void readGraph(std::string fileName);
	void addEdge(int from, int to, int weight);
	void removeEdge(int from, int to);
	int changeEdge(int from, int to, int newWeight);
	void transformToAdjMatrix();
	void transformToAdjList();
	void transformToListOfEdges();
	void writeGraph(std::string fileName);
};

