from zeep import Client

#client = Client('http://localhost:9000/GlobalTextAnalyzer?wsdl')
client = Client('http://54.90.215.5:9000/GlobalTextAnalyzer?wsdl')

def create_answer(result):
    answer = ''
    for r in result:
        answer += r.key + ' - ' + str(r.value) + ' \n'
    return answer


def count_one_word():
    text = input('text = ')
    word = input('word = ')
    return client.service.countOneWord(text, word)


def count_characters():
    text = input('text = ')
    result = client.service.countCharacters(text)
    return create_answer(result)


def count_words():
    text = input('text = ')
    result = client.service.countWords(text)
    return create_answer(result)


def make_caps():
    text = input('text = ')
    return client.service.makeCaps(text)

def count_words_on_web_page():
    url = input('url = ')
    result = client.service.countWordsOnWebPage(url)
    return create_answer(result)


def main_loop():
    while True:
        print('1) Int countOneWord (String text, String word)')
        print('2) (uChar, Int) [] countCharacters (String text)')
        print('3) (String, Int) [] countWords (String text)')
        print('4) String makeCaps (String text)')
        print('5) (String, Int) [] countWordsOnWebPage (String URL)')
        answer = input()
        if answer == '1':
            print('\n' + 'Ответ сервера:' + str(count_one_word()) + '\n')
        elif answer == '2':
            print('\n' + 'Ответ сервера:\n' + str(count_characters()) + '\n')
        elif answer == '3':
            print('\n' + 'Ответ сервера:\n' + str(count_words()) + '\n')
        elif answer == '4':
            print('\n' + 'Ответ сервера:' + str(make_caps()) + '\n')
        elif answer == '5':
            print('\n' + 'Ответ сервера:' + str(count_words_on_web_page()) + '\n')


if __name__ == "__main__":
    main_loop()
