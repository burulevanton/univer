#include <locale>
#include <vector>
#include <iostream>
#include "word_counter.h"
#include <fstream>
#include <cstring>

void WordCounter::addWord(string word) {
    locale locale;
    for (auto &c : word)
        c = tolower(c, locale);
    words[word]++;
}

WordCounter::WordCounter(string fileName) {
    locale locale;
    ifstream file(fileName);
    string line;
    while (getline(file, line)) {
        string word;
        for (auto &c : line) {
            if (isalpha(c, locale))
                word += c;
            else if (!word.empty()) {
                addWord(word);
                word = "";
            }
        }
        if (!word.empty())
            addWord(word);
    }
    file.close();
}

void WordCounter::show(string fileName, SortMode sortMode) {
    vector<pair<string, int>> pairs;
    for (auto &pair : words)
        pairs.emplace_back(pair);
    ofstream file(fileName);
    sort_words(pairs, sortMode);
    for (auto &pair : pairs)
        file << pair.first << " " << pair.second << endl;
    file.close();
}

void WordCounter::sort_words(vector<pair<string, int>> &words,SortMode sortmode) {
    for (int i = 0; i < words.size() - 1; i++) {
        for (int j = 0; j < words.size() - i - 1; j++) {
            if (compare_pairs(words[j], words[j + 1], sortmode)) {
                pair<string, int> temp = words[j];
                words[j] = words[j + 1];
                words[j + 1] = temp;
            }
        }
    }
}
bool WordCounter::compare_pairs(pair<string, int> first, pair<string, int> second, SortMode sortmode) {
    switch (sortmode)
    {
        case WORDS:
            return strcmp(first.first.c_str(), second.first.c_str()) > 0;
        case COUNTER:
            /*if(first.second==second.second)
                return strcmp(first.first.c_str(), second.first.c_str()) > 0;*/
            return first.second < second.second;
        default:
            break;
    }
}