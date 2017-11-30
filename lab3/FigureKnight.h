#pragma once

#include "Figure.h"

class FigureKnight : public Figure {
private:
	void checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const;

public:
	explicit FigureKnight(FigureColor color);
	vector<BoardPosition> availableMoves(const Board *board) const override;
};