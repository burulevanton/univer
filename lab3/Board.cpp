#include "Board.h"
#include "FigureRook.h"
#include "FigureBishop.h"
#include "FigureQueen.h"
#include "FigurePawn.h"
#include "FigureKnight.h"
#include "FigureKing.h"

#include <Windows.h>
#include <fstream>
#include<string>
#include <iostream>
#pragma 

FigureType stringToFigureType(std::string type) {
	if (type == "bishop")
		return FigureType::Bishop;
	if (type == "king")
		return FigureType::King;
	if (type == "knight")
		return FigureType::Knight;
	if (type == "pawn")
		return FigureType::Pawn;
	if (type == "queen")
		return FigureType::Queen;
	if (type == "rook")
		return FigureType::Rook;
	throw std::invalid_argument("Unknown figure type!");
}

FigureColor stringToFigureColor(std::string color) {
	if (color == "white")
		return FigureColor::White;
	if (color == "black")
		return FigureColor::Black;
	throw std::invalid_argument("Unknown figure color!");
}


Figure *figureTypeToFigure(FigureColor color, FigureType type) {
	switch (type) {
	case FigureType::Bishop:
		return new FigureBishop(color);
	case FigureType::King:
		return new FigureKing(color);
	case FigureType::Knight:
		return new FigureKnight(color);
	case FigureType::Pawn:
		return new FigurePawn(color);
	case FigureType::Queen:
		return new FigureQueen(color);
	case FigureType::Rook:
		return new FigureRook(color);
	}
}

vector<string> getFigureAttributesFromText(string attributes) {
	char *c_attributes = new char[attributes.size() - 1];
	vector<string> figureAttributes;
	strcpy(c_attributes, attributes.c_str());
	char *attribute = strtok(c_attributes, " ");
	while (attribute != NULL)
	{
		string s(attribute);
		figureAttributes.push_back(s);
		attribute = strtok(NULL, " ");
	}
	return figureAttributes;
}

void Board::initFigure(FigureColor color, FigureType type, const BoardPosition &position, bool ignoreBank) {
	if (!(position.getRow() >= 0 && position.getColumn() >= 0 && position.getColumn()<_field.size() && position.getRow()<_field.size()))
		throw invalid_argument("Invalid position");
	if (_field[position.getRow()][position.getColumn()] != nullptr)
		throw invalid_argument("Cell is busy");
	if (!ignoreBank) {
		if (_figures_bank.at(color).at(type).current + 1 > _figures_bank.at(color).at(type).max)
			throw invalid_argument("Limit of this figure");
		_figures_bank.at(color).at(type).current++;
	}
	Figure *figure = figureTypeToFigure(color, type);
	figure->setPosition(position);
	_field[position.getRow()][position.getColumn()] = figure;
}

void Board::removeFigure(Figure *figure) {
	if (figure == nullptr)
		return;
	if (_figures_bank.at(figure->getColor()).at(figure->getType()).current == 0)
		throw invalid_argument("Limit of this figure");
	_figures_bank.at(figure->getColor()).at(figure->getType()).current--;
	_field[figure->getPosition().getRow()][figure->getPosition().getColumn()] = nullptr;
	delete figure;
}

Board::Board(string fileName) {
	for (int i = 0; i <= 1; i++) {
		auto currentColor = FigureColor(i);
		_figures_bank[currentColor][FigureType::Bishop].max = 2;
		_figures_bank[currentColor][FigureType::King].max = 1;
		_figures_bank[currentColor][FigureType::Knight].max = 2;
		_figures_bank[currentColor][FigureType::Pawn].max = 8;
		_figures_bank[currentColor][FigureType::Queen].max = 1;
		_figures_bank[currentColor][FigureType::Rook].max = 2;
	}
	for (int i = 0; i < 8; i++)
		_field.emplace_back(8);
	ifstream file("input.txt");
	string figure_info;
	while (getline(file, figure_info)) {
		vector<string> attributes = getFigureAttributesFromText(figure_info);
		auto type = attributes[0];
		auto colorStr = attributes[1];
		auto column = static_cast<int>(attributes[2][0]) - 'a';
		attributes[2].erase(0, 1);
		auto row = stoi(attributes[2]);
		initFigure(stringToFigureColor(colorStr), stringToFigureType(type), BoardPosition(row - 1, column), false);
	}
	file.close();
}

Board::Board(const Board &other) {
	_figures_bank = other._figures_bank;
	for (const auto &i : other._field)
		_field.emplace_back(i.size());
	for (int i = 0; i < _field.size(); i++)
		for (int j = 0; j < _field.size(); j++)
			if (other._field[i][j] != nullptr)
				initFigure(other._field[i][j]->getColor(), other._field[i][j]->getType(), other._field[i][j]->getPosition(), true);
}

Board::~Board() {
	for (auto &i : _field)
		for (auto &j : i)
			delete j;
}

const Figure *Board::operator[](const BoardPosition &position) const {
	return _field[position.getRow()][position.getColumn()];
}

vector<const Figure*> Board::figures(FigureColor color) const {
	vector<const Figure*> result;
	for (const auto &i : _field)
		for (const auto &k : i)
			if (k != nullptr && k->getColor() == color)
				result.push_back((const Figure *)k);
	return result;
}

const Figure *Board::figure(FigureColor color, FigureType type) const {
	for (const auto &i : _field)
		for (const auto &k : i)
			if (k != nullptr && k->getColor() == color && k->getType() == type)
				return k;
}

void Board::moveFigure(const Figure *figure, const BoardPosition &newPosition) {
	removeFigure(_field[newPosition.getRow()][newPosition.getColumn()]);
	_field[newPosition.getRow()][newPosition.getColumn()] = _field[figure->getPosition().getRow()][figure->getPosition().getColumn()];
	_field[figure->getPosition().getRow()][figure->getPosition().getColumn()] = nullptr;
	_field[newPosition.getRow()][newPosition.getColumn()]->setPosition(newPosition);
}

bool Board::isValidCell(const Figure *figure, const BoardPosition &newPosition) const {
	return newPosition.getRow() >= 0 && newPosition.getColumn() >= 0 &&
		newPosition.getRow() < _field.size() && newPosition.getColumn() < _field[newPosition.getRow()].size() &&
		(_field[newPosition.getRow()][newPosition.getColumn()] == nullptr || _field[newPosition.getRow()][newPosition.getColumn()]->getColor() != figure->getColor());
}

void Board::killKing(FigureColor kingColor, const Figure **targetFigure, BoardPosition &newPosition) {
	vector<const Figure *> current_figures = figures(kingColor == FigureColor::White ? FigureColor::Black : FigureColor::White);
	for (const auto &figure : current_figures) {
		auto moves = figure->availableMoves(this);
		for (const auto &move : moves) {
			if (_field[move.getRow()][move.getColumn()] != nullptr &&
				_field[move.getRow()][move.getColumn()]->getColor() == kingColor &&
				_field[move.getRow()][move.getColumn()]->getType() == FigureType::King) {
				newPosition = move;
				*targetFigure = figure;
				return;
			}
		}
	}
	
}

string figureColorToString(FigureColor color) {
	switch (color) {
	case FigureColor::White:
		return "white";
	case FigureColor::Black:
		return "black";
	}
}

string Board::figureTypeToString(FigureType type) {
	switch (type) {
	case FigureType::Bishop:
		return "bishop";
	case FigureType::King:
		return "king";
	case FigureType::Knight:
		return "knight";
	case FigureType::Pawn:
		return "pawn";
	case FigureType::Queen:
		return "queen";
	case FigureType::Rook:
		return "rook";
	}
}

void print_strip() {
	for (int i = 0; i < 72; i++)
		cout << "*";
	cout << endl;
}

void Board::drawBoard() {
	system("cls");
	system("color 30");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	cout << "*";
	int count = 0;
	for (int i = 0; i < 32; i++)
	{
		count++;
		if (i % 4 == 0)
		{
			print_strip();
			cout << "*";
		}
		for (int j = 0; j < 8; j++)
		{
			switch (count)
			{
			case 2:
				if (_field[7 - i / 4][j] != nullptr)
				{
					SetConsoleTextAttribute(hConsole, (WORD)((3 << 4 | 4)));
					cout << setw(8) << " " + figureTypeToString(_field[7 - i / 4][j]->getType()) + " ";
					SetConsoleTextAttribute(hConsole, (WORD)((3 << 4 | 0)));
					cout << "*";
				}
				else 
					cout << setw(9) << "*";
				break;
			case 3:
				if (_field[7 - i / 4][j] != nullptr)
				{	
					if(_field[7-i/4][j]->getColor()==FigureColor::White)
						SetConsoleTextAttribute(hConsole, (WORD)((3 << 4 | 15)));
					cout << setw(8) << " " + figureColorToString(_field[7 - i / 4][j]->getColor()) + " ";
					SetConsoleTextAttribute(hConsole, (WORD)((3 << 4 | 0)));
					cout << "*";
				}
				else
					cout << setw(9) << "*";
				break;
			default:
				cout << setw(9) << "*";
			}
			if (j == 7 && count == 2)
				cout <<" "<< 8 - i / 4;

		}
		if (count % 4 == 0)
			count = 0;
		cout << endl;
		cout << "*";

	}
	print_strip();
	cout << "    A        B        C        D        E        F        G        H     " << endl;
	cout << endl;
	cout << endl;
	cout << endl;
	cout << endl;
}