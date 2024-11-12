using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Program
    {
        static Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"cat", "kot"}, {"dog", "pies"}, {"horse", "koń"}, {"mouse", "mysz"}, {"frog", "żaba"}, {"wolf", "wilk"}, {"monkey", "małpa"},
            {"fox", "lis"}, {"tiger", "tygrys"}, {"lion", "lew"}, {"elephant", "słoń"}, {"parrot", "papuga"}, {"pig", "świnia"}, {"sheep", "owca"},
            {"cow", "krowa"}, {"chicken", "kurczak"}
        };
        static List<string> history = new List<string>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("English - Polish dictionary");
                Console.WriteLine("[1] Translator");
                Console.WriteLine("[2] See all words");
                Console.WriteLine("[3] Add new word");
                Console.WriteLine("[4] Delete word");
                Console.WriteLine("[5] See translation history");
                Console.WriteLine("[6] Test");
                Console.WriteLine("[0] Exit");

                string wybor = Console.ReadLine();

                switch (wybor)
                {
                    case "1":
                        Translator();
                        break;
                    case "2":
                        SeeWords();
                        break;
                    case "3":
                        AddWord();
                        break;
                    case "4":
                        DeleteWord();
                        break;
                    case "5":
                        SeeHistory();
                        break;
                    case "6":
                        Test();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Wrong number. Press to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Translator() {
            Console.Write("Type word to translate: ");
            string word = Console.ReadLine().ToLower();

            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine($"Translation {word} -> {dictionary[word]}");
                history.Add($"{word} -> {dictionary[word]}");

            }
            else if (dictionary.ContainsValue(word))
            {
                string value = dictionary.FirstOrDefault(x => x.Value == word).Key;
                Console.WriteLine($"Translation {word} -> {value}");
                history.Add($"{word} -> {value}");

            }
            else
            {
                Console.WriteLine("Unknown word");
            }
            Console.WriteLine("Press to continue.");
            Console.ReadKey();
        }
        static void SeeWords() {
            Console.WriteLine("Choose display option:");
            Console.WriteLine("1. English-Polish");
            Console.WriteLine("2. Polish-English");
            string choice = Console.ReadLine();

            if (choice == "1"){
                var sorted = dictionary.OrderBy(x => x.Key);
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
            else if (choice == "2"){
                var sorted = dictionary.OrderBy(x => x.Value);
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Value} -> {item.Key}");
                }
            }
            else {
                Console.WriteLine("Wrong number");
            }

            Console.WriteLine("Press to continue");
            Console.ReadKey();
        }
        static void AddWord() {
            Console.Write("Type word in polish: ");
            string polish = Console.ReadLine().ToLower();
            Console.Write("Type english translation of this word: ");
            string english = Console.ReadLine().ToLower();

            if (!dictionary.ContainsKey(english) && !dictionary.ContainsValue(polish))
            {
                dictionary[english] = polish;
                Console.WriteLine("New word added");
            }
            else
            {
                Console.WriteLine("This word already is in dictionary");
            }
            Console.WriteLine("Press to continue");
            Console.ReadKey();
        }
        static void DeleteWord() {
            Console.Write("Type word you want to delete: ");
            string word = Console.ReadLine().ToLower();

            if (dictionary.Remove(word) || dictionary.Remove(dictionary.FirstOrDefault(x => x.Value == word).Key))
            {
                Console.WriteLine("Word has been deleted");
            }
            else
            {
                Console.WriteLine("No such word in dictionary");
            }
            Console.WriteLine("Press to continue");
            Console.ReadKey();
        }
        static void SeeHistory() {
            Console.WriteLine("Translation history: ");
            foreach(string x in history)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Press to continue");
            Console.ReadKey();
        }
        static void Test() {
            HashSet<string> hashlist = new HashSet<string>();
            Random random = new Random();
            int points = 0;
            Console.WriteLine("Choose test version:");
            Console.WriteLine("1. English to Polish");
            Console.WriteLine("2. Polish to English");
            string version = Console.ReadLine();

            List<string> testWords = version == "1" ? dictionary.Keys.ToList() : dictionary.Values.ToList();

            while (hashlist.Count < testWords.Count-5)
            {
                string word = testWords[random.Next(testWords.Count)];
                if (hashlist.Contains(word)) 
                    continue;

                Console.Write($"Type translation for word: \"{word}\": ");
                string answer = Console.ReadLine().ToLower();

                string correctAnswer = version == "1" ? dictionary[word] : dictionary.FirstOrDefault(x => x.Value == word).Key ;

                if (answer == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    points++;
                }
                else
                {
                    Console.WriteLine($"Wrong! Correct translation is: {correctAnswer}");
                }
                hashlist.Add(word);
            }

            Console.WriteLine($"Test is finished. Your score is {points}/{testWords.Count - 5}. Press to continue");
            Console.ReadKey();
        }

    }
}
