from spyne import srpc, ServiceBase, Integer, String, AnyDict, ComplexModel, Array, Mandatory
import analyzer


class Pair(ComplexModel):
    __namespace__ = 'globalTextAnalyzer'
    key = String
    value = Integer


ArrayPairs = Array(Pair)
ArrayPairs.__type_name__ = "ArrayPairs"


def dict_to_array_pair(d : dict) -> list:
    pairs = []
    for key, value in d.items():
        p = Pair()
        p.key = key
        p.value = value
        pairs.append(p)
    return pairs


class GlobalTextAnalyzer(ServiceBase):
    __service_name__ = "GlobalTextAnalyzer"

    @srpc(String, String, _returns=Integer)
    def count_one_word(word, text):
        return analyzer.count_one_word(word, text)

    @srpc(String, _returns=ArrayPairs)
    def count_characters(text):
        return dict_to_array_pair(analyzer.count_characters(text))

    @srpc(String, _returns=ArrayPairs)
    def count_words(text):
        return dict_to_array_pair(analyzer.count_words(text))

    @srpc(String, _returns=String)
    def make_caps(text):
        return analyzer.make_caps(text)

    @srpc(String, _returns=ArrayPairs)
    def count_words_on_web_page(url):
        return dict_to_array_pair(analyzer.count_words_on_web_page(url))
