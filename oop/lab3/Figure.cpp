#include "Figure.h"

FigureColor Figure::getColor() const {
	return _color;
}
FigureType Figure::getType() const {
	return _type;
}
const BoardPosition& Figure::getPosition() const {
	return _position;
}

void Figure::setPosition(const BoardPosition &position) {
	_position = position;
}

Figure::Figure(FigureColor color, FigureType type) : _color(color), _type(type) {}