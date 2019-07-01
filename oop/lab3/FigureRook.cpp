#include "FigureRook.h"

void FigureRook::checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const {
	auto currentPos = getPosition();
	while (board->isValidCell(this, currentPos = currentPos + delta)) {
		moves.push_back(currentPos);
		const auto &enemy = board->operator[](currentPos);
		if (enemy != nullptr && enemy->getColor() != getColor())
			return;
	}
}

FigureRook::FigureRook(FigureColor color) :Figure(color, FigureType::Rook) {}

vector<BoardPosition> FigureRook::availableMoves(const Board *board) const {
	vector<BoardPosition> moves;
	checkDelta(board, moves, BoardPosition(-1, 0));
	checkDelta(board, moves, BoardPosition(1, 0));
	checkDelta(board, moves, BoardPosition(0, -1));
	checkDelta(board, moves, BoardPosition(0, 1));
	return moves;
}