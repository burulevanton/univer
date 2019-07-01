using System;

namespace soa_lab3_client
{
    class Program
    {
        private static int DisplayMenu()
        {
            Console.WriteLine("What are you want?");
            Console.WriteLine("1. makeCaps");
            Console.WriteLine("2. countOneWord");
            Console.WriteLine("3. countCharacters");
            Console.WriteLine("4. countWords");
            Console.WriteLine("5. countWordsOnWebPage");
            Console.WriteLine("6. Exit");
            var result = Console.ReadLine();
            var a = 6;
            try { a = Convert.ToInt32(result); }
            catch (System.FormatException)
            {
                Console.WriteLine("Неверно введено число");
                Console.ReadKey();
            }
            return a;
        }

        private static void CountOneWord(GlobalTextAnalyzerService.GlobalTextAnalyzerClient client)
        {
            Console.WriteLine("Введите текст:");
            var text = Console.ReadLine();
            if (text == "")
            {
                Console.WriteLine("Текст отсутствует");
                return;
            }
            Console.WriteLine("Введите слово:");
            var word = Console.ReadLine();
            if(word == "")
            {
                Console.WriteLine("Слово отсутствует");
                return;
            }
            var responce = client.count_one_wordAsync(new GlobalTextAnalyzerService.count_one_word() { text = text, word = word });
            responce.Wait();
            Console.WriteLine(responce.Result.count_one_wordResponse.count_one_wordResult);
        }

        private static void CountCharacters(GlobalTextAnalyzerService.GlobalTextAnalyzerClient client)
        {
            Console.WriteLine("Введите текст:");
            var text = Console.ReadLine();
            if (text == "")
            {
                Console.WriteLine("Текст отсутствует");
                return;
            }
            var responce = client.count_charactersAsync(new GlobalTextAnalyzerService.count_characters() { text = text });
            responce.Wait();
            foreach (var r in responce.Result.count_charactersResponse.count_charactersResult)
            {
                Console.WriteLine($"{r.key} - {r.value}");
            }
        }

        private static void CountWords(GlobalTextAnalyzerService.GlobalTextAnalyzerClient client)
        {
            Console.WriteLine("Введите текст:");
            var text = Console.ReadLine();
            if (text == "")
            {
                Console.WriteLine("Текст отсутствует");
                return;
            }
            var responce = client.count_wordsAsync(new GlobalTextAnalyzerService.count_words() { text = text });
            responce.Wait();
            foreach (var r in responce.Result.count_wordsResponse.count_wordsResult)
            {
                Console.WriteLine($"{r.key} - {r.value}");
            }
        }

        private static void MakeCaps(GlobalTextAnalyzerService.GlobalTextAnalyzerClient client)
        {
            Console.WriteLine("Введите текст:");
            var text = Console.ReadLine();
            if (text == "")
            {
                Console.WriteLine("Текст отсутствует");
                return;
            }
            var responce = client.make_capsAsync(new GlobalTextAnalyzerService.make_caps() { text = text });
            responce.Wait();
            Console.WriteLine(responce.Result.make_capsResponse.make_capsResult);
        }

        private static void CountWordsOnWebPage(GlobalTextAnalyzerService.GlobalTextAnalyzerClient client)
        {
            Console.WriteLine("Введите URL:");
            var url = Console.ReadLine();
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                Console.WriteLine("Некорректный URL");
                return;
            }
            var responce = client.count_words_on_web_pageAsync(new GlobalTextAnalyzerService.count_words_on_web_page() { url = url });
            responce.Wait();
            foreach (var r in responce.Result.count_words_on_web_pageResponse.count_words_on_web_pageResult)
                Console.WriteLine($"{r.key} - {r.value}");
        }
        static void Main(string[] args)
        {
            var client = new GlobalTextAnalyzerService.GlobalTextAnalyzerClient();
            try
            {
                while (true)
                {
                    var answer = DisplayMenu();
                    switch (answer)
                    {
                        case 1:
                            MakeCaps(client);
                            break;
                        case 2:
                            CountOneWord(client);
                            break;
                        case 3:
                            CountCharacters(client);
                            break;
                        case 4:
                            CountWords(client);
                            break;
                        case 5:
                            CountWordsOnWebPage(client);
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                    }
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка сервера");
            }
            Console.ReadKey();
        }
    }
}
