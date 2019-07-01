#include <cstring>
#include <iomanip>

#include "BigInt.h"
BigInt::BigInt() = default;
BigInt::BigInt(char *number) {
    if(number!= nullptr){
        string str = number;
        if(str.length()==0){
            this->sign=POSITIVE;
        }
        else{
            if(str[0]=='-'){
                str = str.substr(1);
                this->sign=NEGATIVE;
            }
            else{
                this->sign=POSITIVE;
            }
            for(long long i=str.length();i>0;i-=9){
                if(i<9) {
                    this->digits.push_back(strtol(str.substr(0, 9).c_str(), nullptr, 10));
                }
                else {
                    this->digits.push_back(strtol(str.substr(i - 9, 9).c_str(), nullptr, 10));
                }
            }
        }
        this->removeLeadingZeroes();
    }
}
BigInt::BigInt(long int number) {
    if(number<0){
        this->sign=NEGATIVE;
        number=-number;
    }
    else this->sign = POSITIVE;
    while (number!=0){
        this->digits.push_back(number%this->Base);
        number/=this->Base;
    }
}
BigInt::BigInt(const BigInt &other):sign(other.sign) {
    for(long long i=0;i<other.digits.size();i++){
        this->digits.push_back(other.digits[i]);
    }
}
void BigInt::removeLeadingZeroes() {
    while (this->digits.size()>1 && this->digits.back()==0)
        this->digits.pop_back();
}
ostream& operator<<(ostream &os, const BigInt &number) {
    if(number.digits.empty())
    {
        os<<0;
        return os;
    }
    if(number.sign==NEGATIVE)
        os<<'-';
    os<<number.digits.back();
    char old_fill = os.fill('0');
    for(long long i=number.digits.size()-2;i>=0;i--){
        os<<setw(9)<<number.digits[i];
    }
    os.fill(old_fill);
    return os;
}
BigInt::~BigInt() = default;
bool BigInt::Compare(const vector<long int> num1, const vector<long int> num2) {
    if(num1.size()!=num2.size())
        return num1.size()>num2.size();
    for(long long i=num1.size()-1;i>=0;i--){
        if(num1[i]!=num2[i])
            return num1[i]>num2[i];
    }
    return false;
}
bool BigInt::operator>(const BigInt &other) {
    if(this->sign>other.sign)
        return true;
    if(this->sign<other.sign)
        return false;
    else{
        switch (this->sign){
            case POSITIVE:
                return this->Compare(this->digits,other.digits);
            case NEGATIVE:
                return !(this->Compare(this->digits,other.digits));
        }
    }
}
bool BigInt::operator<(const BigInt &other) {
    return !(*this>other);
}
bool BigInt::operator==(const BigInt &other) {
    if(this->sign!=other.sign)
        return false;
    if(this->digits.size()!=other.digits.size())
        return false;
    for(long long i=0;i<this->digits.size();i++){
        if(this->digits[i]!=other.digits[i])
            return false;
    }
    return true;
}
bool BigInt::operator>=(const BigInt &other) {
    return *this>other || *this==other;
}
bool BigInt::operator<=(const BigInt &other) {
    return *this<other || *this==other;
}
BigInt BigInt::operator-() const{
    BigInt result(*this);
    switch (result.sign){
        case POSITIVE:
            result.sign=NEGATIVE;
            break;
        case NEGATIVE:
            result.sign=POSITIVE;
            break;
    }
    return result;
}
const BigInt BigInt::operator+(const BigInt &other) {
    BigInt result(*this);
    if(this->sign==NEGATIVE){
        if(other.sign==NEGATIVE)
            return -(-*this+(-other));
        else {
            BigInt tmp = other;
            return tmp-(-result);
        }
    }
    else{
        if(other.sign==NEGATIVE)
            return result - (-other);
    }
    int carry = 0;
    for(long long i=0;i<max(other.digits.size(),result.digits.size()) || carry!=0; i++){
        if(i==result.digits.size())
            result.digits.push_back(0);
        result.digits[i]+=carry+(i<other.digits.size() ? other.digits[i] : 0);
        carry=result.digits[i]>=BigInt::Base;
        if(carry!=0)
            result.digits[i]-=BigInt::Base;
    }
    return result;
}
const BigInt BigInt::operator-(const BigInt &other) {
    BigInt result(*this);
    if(other.sign==NEGATIVE)
    {
        return result+(-other);
    }
    else if(result.sign==NEGATIVE) return -(-result+other);
    else if(result<other) {
        BigInt tmp = other;
        return -(tmp-result);
    }
    int carry=0;
    for(long long i=0;i<max(other.digits.size(),result.digits.size()) || carry!=0; i++){
        result.digits[i]-=carry+(i<other.digits.size() ? other.digits[i] : 0);
        carry = result.digits[i]<0;
        if(carry!=0)
            result.digits[i]+=BigInt::Base;
    }
    //result.removeLeadingZeroes();
    return result;
}
BigInt& BigInt::operator=(const BigInt &other) {
    if(*this==other)
        return *this;
    this->sign=other.sign;
    for(long long i=0;i<other.digits.size();i++){
        if (i<this->digits.size())
            this->digits[i] = other.digits[i];
        else
            this->digits.push_back(other.digits[i]);
    }
    return *this;
}
BigInt& BigInt::operator+=(const BigInt &other) {
    *this = *this + other;
    return *this;
}
BigInt& BigInt::operator-=(const BigInt &other) {
    *this = *this - other;
    return *this;
}
const BigInt BigInt::operator++() {
    *this+=1;
    return *this;
}
const BigInt BigInt::operator++(int) {
    *this+=1;
    return *this-1;
}
const BigInt BigInt::operator--() {
    *this-=1;
    return *this;
}
const BigInt BigInt::operator--(int) {
    *this-=1;
    return *this+1;
}
const BigInt BigInt::operator*(const BigInt &other) {
    BigInt result;
    result.digits.resize(this->digits.size()+other.digits.size());
    for(long long i=0;i<this->digits.size();i++){
        int carry = 0;
        for(long long j=0;j<other.digits.size() || carry!=0; j++){
            long long cur = result.digits[i+j] + this->digits[i] *1LL * (j<other.digits.size() ? other.digits[j] : 0) + carry;
            result.digits[i+j] = cur%BigInt::Base;
            carry = cur/BigInt::Base;
        }
    }
    if(this->sign==NEGATIVE)
        if(other.sign==NEGATIVE)
            result.sign=POSITIVE;
        else
            result.sign=NEGATIVE;
    else
        if(other.sign==NEGATIVE)
            result.sign=NEGATIVE;
        else
            result.sign=POSITIVE;
    result.removeLeadingZeroes();
    return result;
}
BigInt& BigInt::operator*=(const BigInt &other) {
    *this = *this*other;
    return *this;
}