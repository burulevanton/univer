#include <iostream>
#include "matrix.h"
#include "BigInt.h"

int main() {
    Matrix a(2,2);
    Matrix b(2,2);
    Matrix c(3,3);

    for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++) b[i][j] = i+j;

    b *= 2;
    b = a = b + b;

    if (a != b) cout << "Something wrong\n";
    else cout << "As expected\n";

    //b += c; // эта строчка работать не должна, потому что матрицы
    // разной размерности складывать нельзя.

    cout << a << endl
         << c << endl
         << b << endl;

    Matrix d(3,3);
    Matrix d1, d2;

    d1 = 3 * d;
    d2=  d * 3; //результаты должны совпадать
    return 0;
}