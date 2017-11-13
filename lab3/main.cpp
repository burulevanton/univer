#include <iostream>
#include <string>
using namespace std;
enum colors{
    WHITE,
    BLACK
};
class TFigure{
private:
    int chasrPosToInt(char position){
        switch(position){
            case 'a' :
                return 0;
            case 'b' :
                return 1;
            case 'c':
                return 2;
            case 'd':
                return 3;
            case 'e':
                return 4;
            case 'f':
                return 5;
            case 'g':
                return 6;
            case 'h':
                return 7;
            default:
                return -1;
        }
    }
protected:
    int position_X;
    int position_Y;
    colors color;
public:
    TFigure(char pos_X, int pos_y, colors color){
        this->position_X=chasrPosToInt(pos_X);
        this->position_Y=pos_y;
        this->color=color;
        TFigure *figures[32] = Board::getArray();
    }

};
class Board{
private:
    static TFigure *figures[32];
public:
    static TFigure* getArray(){
        return *figures;
    }
};