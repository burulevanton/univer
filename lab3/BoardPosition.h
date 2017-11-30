#pragma once

class BoardPosition {
private:
	int _row;
	int _column;
public:
	int getRow() const;
	int getColumn() const;
	BoardPosition();
	BoardPosition(int, int);
	BoardPosition(const BoardPosition &other);
	friend BoardPosition operator+(const BoardPosition &self, const BoardPosition &other);
	friend BoardPosition operator-(const BoardPosition &self, const BoardPosition &other);
};


