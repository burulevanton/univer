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
