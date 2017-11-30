#include "FigureQueen.h"
#include "FigureBishop.h"
#include "FigureRook.h"

FigureQueen::FigureQueen(FigureColor color) :Figure(color, FigureType::Queen) {
	_similarFigures.push_back(new FigureBishop(this->getColor()));
	_similarFigures.push_back(new FigureRook(this->getColor()));
}

FigureQueen::~FigureQueen() {
	for (auto &i : _similarFigures)
		delete i;
}

vector<BoardPosition> FigureQueen::availableMoves(const Board *board) const {
	vector<BoardPosition> moves;
	for (auto &figure : _similarFigures) {
		figure->setPosition(getPosition());
		auto newMoves = figure->availableMoves(board);
		moves.insert(moves.end(), newMoves.begin(), newMoves.end());
	}
	return moves;
}
