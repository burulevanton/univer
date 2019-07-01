cmake_minimum_required(VERSION 3.8)
project(lab2)

set(CMAKE_CXX_STANDARD 14)

set(SOURCE_FILES main.cpp matrix.h matrix.cpp BigInt.h BigInt.cpp)
add_executable(lab2 ${SOURCE_FILES})