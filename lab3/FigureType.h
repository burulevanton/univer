#pragma once

enum class FigureType {
	Bishop = 0,
	King = 1,
	Knight = 2,
	Pawn = 3,
	Queen = 4,
	Rook = 5,
};

const int FIGURE_TYPE_MIN = static_cast<int>(FigureType::Bishop);
const int FIGURE_TYPE_MAX = static_cast<int>(FigureType::Rook);
