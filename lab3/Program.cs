﻿using System;
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
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
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

            }
            else if (dictionary.ContainsValue(word))
            {
                string value = dictionary.FirstOrDefault(x => x.Value == word).Key;
                Console.WriteLine($"Tłumaczenie {word} -> {value}");

            }
            else
            {
                Console.WriteLine("Unknown word");
            }
            Console.WriteLine("Press to continue.");
            Console.ReadKey();
        }
        static void SeeWords() { }
        static void AddWord() { }
        static void DeleteWord() { }
        static void SeeHistory() { }
        static void Test() { }

    }
}
