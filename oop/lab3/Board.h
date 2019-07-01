#pragma once

#include <map>
#include <vector>
#include <iomanip>
using namespace std;

#include "BoardPosition.h"
#include "FigureColor.h"
#include "FigureType.h"


class Figure;

class Board {
private:
	struct FigureRecord {
		int current;
		int max;
	};

	vector<vector<Figure*>> _field;
	map<FigureColor, map<FigureType, FigureRecord>> _figures_bank;
	void removeFigure(Figure *figure);

public:
	explicit Board(string fileName);
	Board(const Board &other);
	~Board();
	vector<const Figure *> figures(FigureColor color) const;
	const Figure *figure(FigureColor color, FigureType type) const;
	const Figure*operator[](const BoardPosition &position) const;
	void moveFigure(const Figure *figure, const BoardPosition &newPosition);
	bool isValidCell(const Figure *figure, const BoardPosition &newPosition) const;
	void initFigure(FigureColor color, FigureType type, const BoardPosition &position, bool ignoreBank);
	void killKing(FigureColor kingColor, const Figure **targetFigure, BoardPosition &newPosition);
	string figureTypeToString(FigureType type);
	void drawBoard();
};

#include "Figure.h"