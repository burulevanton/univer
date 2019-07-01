import unittest
import analyzer


class GlobalTextAnalyzerTests(unittest.TestCase):

    def test_count_one_word(self):
        count = analyzer.count_one_word('test', 'test, test123 test; test! test - test. test.')
        self.assertEqual(count, 6)

    def test_count_characters(self):
        char_dict = analyzer.count_characters('sobaka, test.')
        self.assertEqual(char_dict['s'], 2)
        self.assertEqual(char_dict['o'], 1)
        self.assertEqual(char_dict['b'], 1)
        self.assertEqual(char_dict['a'], 2)
        self.assertEqual(char_dict['k'], 1)
        self.assertEqual(char_dict['t'], 2)
        self.assertEqual(char_dict['e'], 1)
        self.assertEqual(len(char_dict), 7)

    def test_count_words(self):
        words_dict = analyzer.count_words('Test, test; sobaka')
        self.assertEqual(words_dict['test'], 2)
        self.assertEqual(words_dict['sobaka'], 1)
        self.assertEqual(len(words_dict), 2)

    def test_make_caps(self):
        text = analyzer.make_caps('Test, sobaka')
        self.assertEqual(text, 'TEST, SOBAKA')


if __name__ == '__main__':
    unittest.main()
