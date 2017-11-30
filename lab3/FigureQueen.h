#pragma once

#include "Figure.h"

class FigureQueen : public Figure {
private:
	vector<Figure *> _similarFigures;
public:
	explicit FigureQueen(FigureColor color);
	~FigureQueen();
	vector<BoardPosition> availableMoves(const Board *board) const override;
};