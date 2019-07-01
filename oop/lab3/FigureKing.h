#pragma once

#include "Figure.h"

class FigureKing : public Figure {
private:
	void checkDelta(const Board *board, vector <BoardPosition> &moves, const BoardPosition &delta) const;
	void checkProtectedDelta(const Board *board, vector <BoardPosition> &moves, const BoardPosition &delta) const;
	vector<BoardPosition> getDeltas() const;

public:
	explicit FigureKing(FigureColor color);
	vector<BoardPosition> availableMoves(const Board *board) const override;
	vector<BoardPosition> availableProtectedMoves(const Board *board);
};