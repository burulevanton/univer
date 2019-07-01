#ifndef LAB2_BIGINT_H
#define LAB2_BIGINT_H

#include <iostream>
#include <vector>

using namespace std;

enum Sign{
    POSITIVE = true,
    NEGATIVE = false
};

class BigInt{
private:
    Sign sign;
    vector<long int> digits;
    int Base = 1000000000;
    bool Compare(vector<long int> num1, vector<long int>num2);
public:
    BigInt();
    BigInt(char *);
    BigInt(long int);
    BigInt(const BigInt&);
    void removeLeadingZeroes();
    ~BigInt();
    friend ostream& operator <<(ostream &, const BigInt&);
    bool operator<(const BigInt&);
    bool operator>(const BigInt&);
    bool operator==(const BigInt&);
    bool operator>=(const BigInt&);
    bool operator<=(const BigInt&);
    const BigInt operator+ (const BigInt&);
    const BigInt operator- (const BigInt&);
    BigInt operator-() const;
    BigInt& operator=(const BigInt&);
    BigInt& operator+=(const BigInt&);
    BigInt& operator-=(const BigInt&);
    const BigInt operator++();
    const BigInt operator++(int);
    const BigInt operator--();
    const BigInt operator--(int);
    const BigInt operator*(const BigInt&);
    BigInt& operator*=(const BigInt&);
};

#endif //LAB2_BIGINT_H
