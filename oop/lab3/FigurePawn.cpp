#include "FigurePawn.h"

void FigurePawn::checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const {
	const auto newPosition = getPosition() + delta;
	if (board->isValidCell(this, newPosition) && board->operator[](newPosition))
		moves.push_back(newPosition);
}

void FigurePawn::checkAttack(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const {
	const auto newPosition = getPosition() + delta;
	if (board->isValidCell(this, newPosition) && board->operator[](newPosition) != nullptr)
		moves.push_back(newPosition);
}

FigurePawn::FigurePawn(FigureColor color) : Figure(color, FigureType::Pawn) {}

vector<BoardPosition> FigurePawn::availableMoves(const Board *board) const {
	int rowStroke = getColor() == FigureColor::White ? 1 : -1;
	bool isStartPos = getColor() == FigureColor::White && getPosition().getRow() == 1 ||
		getColor() == FigureColor::Black && getPosition().getRow() == 6;
	vector<BoardPosition> moves;
	checkDelta(board, moves, BoardPosition(1 * rowStroke, 0));
	if (isStartPos)
		checkDelta(board, moves, BoardPosition(2 * rowStroke, 0));
	checkAttack(board, moves, BoardPosition(1 * rowStroke, -1));
	checkAttack(board, moves, BoardPosition(1 * rowStroke, 1));
	return moves;
}
