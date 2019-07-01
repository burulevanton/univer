
#include "FigureBishop.h"

void FigureBishop::checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const {
	auto currentPos = getPosition();
	while (board->isValidCell(this, currentPos = currentPos + delta)) {
		moves.push_back(currentPos);
		const auto &enemy = board->operator[](currentPos);
		if (enemy != nullptr && enemy->getColor() != getColor())
			return;
	}
}

FigureBishop::FigureBishop(FigureColor color) :Figure(color, FigureType::Bishop) {}

vector<BoardPosition> FigureBishop::availableMoves(const Board *board) const {
	vector<BoardPosition> moves;
	checkDelta(board, moves, BoardPosition(1, -1));
	checkDelta(board, moves, BoardPosition(1, 1));
	checkDelta(board, moves, BoardPosition(-1, -1));
	checkDelta(board, moves, BoardPosition(-1, 1));
	return moves;
}