#pragma once

#include "Figure.h"

class FigurePawn : public Figure {
private:
	void checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const;
	void checkAttack(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const;

public:
	explicit FigurePawn(FigureColor color);
	vector<BoardPosition> availableMoves(const Board *board) const override;
};
