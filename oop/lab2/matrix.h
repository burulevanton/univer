#ifndef LAB2_MATRIX_H
#define LAB2_MATRIX_H

#include <iostream>
using namespace std;

class Matrix {
private:
    double** Array;
    int matrix_width;
    int matrix_height;
public:
    Matrix();
    Matrix(const Matrix&);
    Matrix(int, int);
    ~Matrix();
    Matrix operator+ (const Matrix&);
    Matrix operator- (const Matrix&);
    Matrix operator*(const Matrix&);
    friend const Matrix operator*(const Matrix&, double);
    friend const Matrix operator*(double, const Matrix&);
    double* operator[](int);
    Matrix& operator=(const Matrix&);
    Matrix& operator+=(const Matrix&);
    Matrix& operator-=(const Matrix&);
    Matrix& operator*=(const Matrix&);
    Matrix&operator*=(double);
    bool operator==(const Matrix&);
    bool operator!=(const Matrix&);
    friend ostream &operator<<(ostream &, const Matrix &);
};

#endif //LAB2_MATRIX_H
