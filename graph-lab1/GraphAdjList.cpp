#include "GraphAdjList.h"

void GraphAdjList::addEdge(int from, int to, int weight)
{
	if (!isWeight)
		weight = 1;
	data[from][to] = weight;
	if (!isOriented)
		data[to][from] = weight;
}
int GraphAdjList::changeEdge(int from, int to, int newWeight)
{
	int oldWeight = data[from][to];
	data[from][to] = newWeight;
	if (!isOriented)
		data[from][to] = newWeight;
	return oldWeight;
}
GraphAdjList * GraphAdjList::toAdjList()
{
	return this;
}
void GraphAdjList::removeEdge(int from, int to)
{
	data[from].erase(to);
	if (!isOriented)
		data[to].erase(from);
}
