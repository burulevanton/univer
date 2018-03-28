project(graph-lab1)

set(CMAKE_CXX_STANDARD 11)

add_executable(graph-lab1 graph-lab1/main.cpp graph-lab1/Graph.cpp graph-lab1/Graph.h graph-lab1/GraphAdjList.cpp
        graph-lab1/GraphAdjList.h graph-lab1/GraphAdjMatrix.cpp graph-lab1/GraphAdjMatrix.h graph-lab1/GraphListOfEdges.cpp
        graph-lab1/GraphListOfEdges.h graph-lab1/IGraph.h)