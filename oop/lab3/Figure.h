#pragma once

#include <vector>
using namespace std;

#include "BoardPosition.h"
#include "FigureColor.h"
#include "FigureType.h"

class Board;

class Figure {
private:
	FigureColor _color;
	FigureType  _type;
	BoardPosition _position;

public:
	FigureColor getColor() const;
	FigureType getType() const;
	const BoardPosition &getPosition() const;
	void setPosition(const BoardPosition &position);
	Figure(FigureColor color, FigureType type);

	virtual vector<BoardPosition> availableMoves(const Board *board) const = 0;
};

#include "Board.h"