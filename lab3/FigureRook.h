#pragma once

#include "Figure.h"

class FigureRook : public Figure {
private:
	void checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const;

public:
	explicit FigureRook(FigureColor color);
	vector<BoardPosition> availableMoves(const Board *board) const override;
};