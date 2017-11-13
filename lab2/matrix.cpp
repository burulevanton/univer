#include <iomanip>
#include "matrix.h"
Matrix::Matrix() :matrix_width(3), matrix_height(3) {
    Array = new double*[matrix_width];
    for (int i = 0; i<matrix_width; i++) {
        Array[i] = new double[matrix_height];
    }
}
Matrix::Matrix(int width, int height) :matrix_width(width), matrix_height(height) {
    Array = new double*[matrix_width];
    for (int i = 0; i<matrix_width; i++) {
        Array[i] = new double[matrix_height];
    }
    /*for (int i = 0; i<matrix_width; i++) {
        for (int j = 0; j<matrix_height; j++) {
            Array[i][j] = i + j;
        }
    }*/
}
Matrix::Matrix(const Matrix &other) :matrix_width(other.matrix_width), matrix_height(other.matrix_height) {
    Array = new double*[matrix_width];
    for (int i = 0; i<matrix_width; i++) {
        Array[i] = new double[matrix_height];
    }
    for (int i = 0; i<matrix_width; i++) {
        for (int j = 0; j<matrix_height; j++) {
            this->Array[i][j] = other.Array[i][j];
        }
    }
}
Matrix::~Matrix() {
    for (int i = 0; i<matrix_width; i++) {
        delete[] Array[i];
    }
    delete[] Array;
}
Matrix Matrix::operator+(const Matrix& other) {
    if (this->matrix_height != other.matrix_height || this->matrix_width != other.matrix_width) {
        cerr << "Can't sum" << endl;
        exit(1);
    }
    Matrix result(this->matrix_width, this->matrix_height);
    for (int i = 0; i<this->matrix_width; i++) {
        for (int j = 0; j<this->matrix_height; j++) {
            result.Array[i][j] = this->Array[i][j] + other.Array[i][j];
        }
    }
    return result;
}
Matrix Matrix::operator-(const Matrix& other) {
    if (this->matrix_height != other.matrix_height || this->matrix_width != other.matrix_width) {
        cerr << "Can't dif" << endl;
        exit(1);
    }
    Matrix result(this->matrix_width, this->matrix_height);
    for (int i = 0; i<this->matrix_width; i++) {
        for (int j = 0; j<this->matrix_height; j++) {
            result.Array[i][j] = this->Array[i][j] - other.Array[i][j];
        }
    }
    return result;
}

Matrix Matrix::operator*(const Matrix &other)
{
    if (this->matrix_height!=other.matrix_width) {
        cerr << "Can't multiplicate" << endl;
        exit(1);
    }
    Matrix result(this->matrix_width, other.matrix_height);
    for (int i = 0; i < result.matrix_width; i++) {
        for (int j = 0; j < result.matrix_height; j++) {
            result[i][j] = 0;
            for (int k = 0; k < this->matrix_height; k++) {
                result[i][j] += this->Array[i][k] * other.Array[k][j];
            }
        }
    }
    return result;
}

const Matrix operator*(const Matrix& m, double d) {
    Matrix result(m.matrix_width, m.matrix_height);
    for (int i = 0; i<m.matrix_width; i++) {
        for (int j = 0; j<m.matrix_height; j++) {
            result[i][j] = m.Array[i][j] * d;
        }
    }
    return result;
}
const Matrix operator*(double d, const Matrix& m) {
    return m*d;
}
double* Matrix::operator[](int index) {
    return Array[index];
}
Matrix& Matrix::operator=(const Matrix &other) {
    if (&other == this) return *this;
    if (this->matrix_width != other.matrix_width || this->matrix_height != other.matrix_height) {
        cerr << "different sizes of matrix";
        exit(1);
    }
    for (int i = 0; i<this->matrix_width; i++) {
        for (int j = 0; j<this->matrix_height; j++) {
            this->Array[i][j] = other.Array[i][j];
        }
    }
    return *this;
}
Matrix& Matrix::operator+=(const Matrix &other) {
    *this = *this + other;
    return *this;
}
Matrix& Matrix::operator-=(const Matrix &other) {
    *this = *this - other;
    return *this;
}
Matrix& Matrix::operator*=(const Matrix &other) {
    *this = *this*other;
}
Matrix& Matrix::operator*=(double num) {
    *this = *this*num;
    return *this;
}
bool Matrix::operator==(const Matrix &other) {
    if (this->matrix_width != other.matrix_width || this->matrix_height != other.matrix_height) {
        return false;
    }
    for (int i = 0; i<this->matrix_width; i++) {
        for (int j = 0; j<this->matrix_height; j++) {
            if (this->Array[i][j] != other.Array[i][j])
                return false;
        }
    }
    return true;
}
bool Matrix::operator!=(const Matrix &other) {
    return !(*this == other);
}
ostream &operator<<(ostream &output, const Matrix &obj)
{
    for (int i = 0; i<obj.matrix_width; i++) {
        for (int j = 0; j<obj.matrix_height; j++) {
            output << setw(5) << obj.Array[i][j];
        }
        cout << endl;
    }
    output << endl;
    return output;
}