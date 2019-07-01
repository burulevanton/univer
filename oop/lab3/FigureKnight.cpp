#include "FigureKnight.h"

void FigureKnight::checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const {
	const auto newPosition = getPosition() + delta;
	if (board->isValidCell(this, newPosition))
		moves.push_back(newPosition);
}

FigureKnight::FigureKnight(FigureColor color) : Figure(color, FigureType::Knight) {}

vector<BoardPosition> FigureKnight::availableMoves(const Board *board) const {
	vector<BoardPosition> moves;
	checkDelta(board, moves, BoardPosition(1, -2));
	checkDelta(board, moves, BoardPosition(2, 1));
	checkDelta(board, moves, BoardPosition(2, 1));
	checkDelta(board, moves, BoardPosition(1, 2));
	checkDelta(board, moves, BoardPosition(-1, -2));
	checkDelta(board, moves, BoardPosition(-2, -1));
	checkDelta(board, moves, BoardPosition(-2, 1));
	checkDelta(board, moves, BoardPosition(-1, 2));
	return moves;
}