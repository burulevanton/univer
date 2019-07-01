#pragma once

#include "Figure.h"

class FigureBishop : public Figure {
private:
	void checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const;

public:
	explicit FigureBishop(FigureColor color);
	vector<BoardPosition> availableMoves(const Board *board) const override;
};