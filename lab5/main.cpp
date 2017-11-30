#include <iostream>
#include <locale>
#include "word_counter.h"
using namespace std;

int main() {
    std::locale::global(std::locale(""));
    /*setlocale(LC_ALL,"RUS");*/
    WordCounter w("input.txt");
    w.show("output.txt",COUNTER);

    return 0;
}