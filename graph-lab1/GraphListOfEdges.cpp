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