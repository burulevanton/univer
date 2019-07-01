#include <iostream>
#include <iomanip>

using namespace std;

template <typename T>
class Container{
private:
    T *containerPtr;
    int max_size;
    int current_size;
public:
    explicit Container(int);
    ~Container();
    void push(T);
    T pop();
    int size();
    void printContainer();
};

template <typename T>
Container<T>::Container(int size) {
    max_size = size > 0 ? size : 10;
    containerPtr = new T[size];
    current_size=-1;
}

template <typename T>
Container<T>::~Container() {

    delete[] containerPtr;
}

template <typename T>
void Container<T>::push(T other) {
    if(this->current_size==this->max_size-1){
        throw out_of_range("Out of range");
    }
    if(current_size==-1){
        current_size++;
        this->containerPtr[current_size]=other;
    }
    else{
        try{
            if(other>this->containerPtr[current_size]){
                current_size++;
                this->containerPtr[current_size]=other;
            }

        }
        catch(...){
            cerr<<"something goes wrong";
        }
    }

}
template <typename T>
T Container<T>::pop() {
    if(current_size==-1){
        throw out_of_range("Out of range");
    }
    T currentElement = this->containerPtr[current_size];
    this->containerPtr[current_size]=0;
    current_size--;
}

template <typename T>
int Container<T>::size() {
    return current_size+1;
}

template <typename T>
void Container<T>::printContainer() {
    for (int i = max_size-1; i >= 0; i--)
    {
        if(this->containerPtr[i]!=0)
        cout << "|" << setw(4) << this->containerPtr[i] << endl;
    }
}
int main() {
    Container<int> container(5);
    container.push(10);
    container.push(2);
    container.push(3);
    container.push(14);
    container.push(15);
    container.push(9);
    container.push(8);
    container.push(10);
    container.push(14);
    container.printContainer();
    container.pop();
    cout<<endl;
    container.printContainer();
    return 0;
}