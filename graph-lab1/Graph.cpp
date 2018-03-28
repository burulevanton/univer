#include "Graph.h"
Graph::Graph() {
    this->_graph = nullptr;
}
void Graph::readGraph(std::string fileName) {
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

void Graph::addEdge(int from, int to, int weight) {
	this->_graph->addEdge(from, to, weight);
}

void Graph::removeEdge(int from, int to) {
	this->_graph->removeEdge(from, to);
}

int Graph::changeEdge(int from, int to, int newWeight) {
	return this->_graph->changeEdge(from, to, newWeight);
}
void Graph::renewGraph(IGraph *newGraph) {
	if (newGraph == this->_graph)
		return;
	delete(this->_graph);
	this->_graph = newGraph;
}
void Graph::transformToAdjMatrix() {
	auto newGraph = (IGraph *)this->_graph->toAdjMatrix();
	this->renewGraph(newGraph);
}

void Graph::transformToAdjList() {
	auto newGraph = (IGraph *)this->_graph->toAdjList();
	this->renewGraph(newGraph);
}

void Graph::transformToListOfEdges() {
	auto newGraph = (IGraph *)this->_graph->toListOfEdges();
	this->renewGraph(newGraph);
}

void Graph::writeGraph(std::string fileName) {
	this->_graph->writeGraph(fileName);
}

