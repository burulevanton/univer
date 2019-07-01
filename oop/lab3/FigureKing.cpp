#include "FigureKing.h"

void FigureKing::checkDelta(const Board *board, vector<BoardPosition> &moves, const BoardPosition &delta) const {
	const auto newPosition = getPosition() + delta;

	if (board->isValidCell(this, newPosition))
		moves.push_back(newPosition);
}

void FigureKing::checkProtectedDelta(const Board *board, vector<BoardPosition> &moves,
	const BoardPosition &delta) const {
	const auto newPosition = getPosition() + delta;
	if (board->isValidCell(this, newPosition)) {
		auto testBoard = new Board(*board);
		testBoard->moveFigure(testBoard->operator[](getPosition()), newPosition);
		const Figure *myFigure = nullptr;
		BoardPosition myPosition;
		testBoard->killKing(getColor(), &myFigure, myPosition);
		if (myFigure == nullptr)
			moves.push_back(newPosition);
		delete testBoard;
	}
}
vector<BoardPosition> FigureKing::getDeltas() const {
	vector<BoardPosition> deltas;
	deltas.emplace_back(1, -1);
	deltas.emplace_back(1, 0);
	deltas.emplace_back(1, 1);
	deltas.emplace_back(0, -1);
	deltas.emplace_back(0, 1);
	deltas.emplace_back(-1, -1);
	deltas.emplace_back(-1, 0);
	deltas.emplace_back(-1, -1);
	return deltas;
}

FigureKing::FigureKing(FigureColor color) : Figure(color, FigureType::King) {}

vector<BoardPosition> FigureKing::availableMoves(const Board *board) const {
	vector<BoardPosition> moves;
	for (const auto &delta : getDeltas())
		checkDelta(board, moves, delta);
	return moves;
}

vector<BoardPosition> FigureKing::availableProtectedMoves(const Board *board) {
	vector<BoardPosition> moves;
	for (const auto &delta : getDeltas())
		checkProtectedDelta(board, moves, delta);
	return moves;
}