import re
import requests

from bs4 import BeautifulSoup


def count_one_word(word: str, text: str) -> int:
    counter = 0
    words = re.split('\W', text)
    for wrd in words:
        if wrd == word:
            counter = counter + 1
    return counter


def count_characters(text: str) -> dict:
    char_dict = {}
    for ch in text:
        if ch.isalpha():
            val = char_dict.setdefault(ch, 0)
            char_dict[ch] = val + 1
    return char_dict


def count_words(text: str, regex: str = '\W') -> dict:
    words_dict = {}
    words = re.split(regex, text)
    for wrd in words:
        if len(wrd) > 0 and not (re.match(r'^\d', wrd)):
            wrd = wrd.lower()
            val = words_dict.setdefault(wrd, 0)
            words_dict[wrd] = val + 1
    return words_dict


def make_caps(text: str) -> str:
    return text.upper()


def count_words_on_web_page(url: str) -> dict:
    page = requests.get(url)
    soup = BeautifulSoup(page.content, 'lxml')
    for script in soup(["script", "style"]):
        script.extract()
    text = soup.get_text()
    return count_words(text, '[\W|\d]')
