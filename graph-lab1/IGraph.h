#pragma once
#include <string>

class GraphAdjMatrix;
class GraphAdjList;
class GraphListOfEdges;

class IGraph {
public:
	virtual void readGraph(std::string fileName) = 0;
	virtual void addEdge(int from, int to, int weight) = 0;
	virtual void removeEdge(int from, int to) = 0;
	virtual int changeEdge(int from, int to, int newWeight) = 0;
	virtual GraphAdjMatrix* toAdjMatrix() = 0;
	virtual GraphAdjList* toAdjList() = 0;
	virtual GraphListOfEdges* toListOfEdges() = 0;
	virtual void writeGraph(std::string fileName) = 0;
};
