#ifndef LAB5_WORD_COUNTER_H
#define LAB5_WORD_COUNTER_H

#include <map>
#include <string>
#include <vector>
using namespace std;

enum SortMode {
    WORDS,
    COUNTER
};

class WordCounter {

private:
    map<string, int> words;
    void addWord(string word);
    void sort_words(vector<pair<string, int>> &words, SortMode sortmode);
    bool compare_pairs(pair<string, int>first, pair<string, int> second,SortMode sortmode);

public:
    explicit WordCounter(string fileName);

    void show(string fileName, SortMode sortMode);

};

#endif //LAB5_WORD_COUNTER_H