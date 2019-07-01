#include "BoardPosition.h"

int BoardPosition::getRow() const {
	return _row;
}

int BoardPosition::getColumn() const {
	return _column;
}

BoardPosition::BoardPosition() : _row(0), _column(0) {}

BoardPosition::BoardPosition(int row, int column) : _row(row), _column(column) {}

BoardPosition::BoardPosition(const BoardPosition &other) : _row(other.getRow()), _column(other.getColumn()) {}

BoardPosition operator+(const BoardPosition &self, const BoardPosition &other) {
	return BoardPosition(self.getRow() + other.getRow(), self.getColumn() + other.getColumn());
}


BoardPosition operator-(const BoardPosition &self, const BoardPosition &other) {
	return BoardPosition(self.getRow() - other.getRow(), self.getColumn() - other.getColumn());
}