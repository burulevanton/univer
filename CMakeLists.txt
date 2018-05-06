project(graph-lab1)

set(CMAKE_CXX_STANDARD 11)

add_executable(graph-lab1 graph-lab1/main.cpp graph-lab1/Graph.h)

add_executable(graph-lab2 graph-lab2/main.cpp graph-lab2/Graph.h graph-lab2/DSU.cpp graph-lab2/DSU.h)