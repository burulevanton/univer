cmake_minimum_required(VERSION 3.8)
project(lab3)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp BoardPosition.h BoardPosition.cpp FigureColor.h FigureType.h Board.h Board.cpp Figure.h Figure.cpp FigureBishop.h FigureBishop.cpp FigureKing.cpp FigureKing.h FigureKnight.h FigureKnight.cpp FigurePawn.h FigurePawn.cpp FigureRook.h FigureRook.cpp FigureQueen.h FigureQueen.cpp)
add_executable(lab3 ${SOURCE_FILES})