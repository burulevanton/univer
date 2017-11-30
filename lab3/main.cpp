#include "FigureKing.h"
#include<iostream>
#include<string>

int main() {
	setlocale(LC_ALL, "Russian");
	Board *board = new Board("input.txt");
	board->drawBoard();
	string s;
	cout << "������� ���������� ������ ������: ";
	cin >> s;
	auto column = static_cast<int>(s[0]) - 'a';
	s.erase(0, 1);
	auto row = stoi(s);
	board->initFigure(FigureColor::White, FigureType::King, BoardPosition(row - 1, column), false);
	board->drawBoard();
	cout << "������� ��������� �� �����" << endl;
	cout << endl;
	auto white_king = (const FigureKing*)board->figure(FigureColor::White, FigureType::King);
	auto whiteKingProtectedMovesCount = white_king->availableMoves(board).size();
	const Figure *myFigure = nullptr;
	BoardPosition newPosition;
	board->killKing(FigureColor::White, &myFigure, newPosition);
	string status;
	if (myFigure != nullptr && whiteKingProtectedMovesCount == 0) {
		status = "���\n";
		status += "���������" + board->figureTypeToString(myFigure->getType());
	}
	else if (myFigure != nullptr && whiteKingProtectedMovesCount != 0) {
		status = "���\n";
		status += "��������� " + board->figureTypeToString(myFigure->getType());
	}
	else if (myFigure == nullptr && whiteKingProtectedMovesCount == 0) {
		status = "����������� ��������";
	}
	else
		status = "�� ���������";
	cout << status << endl;
	system("pause");
}