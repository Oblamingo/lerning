using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;
            string newWord = string.Empty;
            string successLetter = "y";
            string stopWord = "q";

            bool isWork = true;

            Dictionary<string, string> wikiBook = new Dictionary<string, string>();

            wikiBook.Add("кошка", "Домашнее животное животное на 4х лапах, которое мяукает");
            wikiBook.Add("собака", "Домашнее животное животное на 4х лапах, которое гавкает");
            wikiBook.Add("человек", "Домашнее животное животное на 2х ногах, которое жрёт");


            while (isWork)
            {
                Console.WriteLine($"Введите слово для поиска в словаре ('{stopWord.ToUpper()}'/'{stopWord}' - для выхода ):");

                userInput = Console.ReadLine().ToLower();


                if (userInput == stopWord)
                {
                    isWork = false;
                }
                else if (wikiBook.ContainsKey(userInput))
                {
                    Console.WriteLine($"{userInput} - {wikiBook[userInput]}");
                }
                else
                {
                    newWord = userInput;

                    Console.WriteLine($"Такое слово не найдено.Если хотите добавить значение введите '{successLetter.ToUpper()}'/'{successLetter}'");

                    userInput = Console.ReadLine().ToLower();

                    if (userInput == successLetter)
                    {
                        Console.WriteLine($"Пожалуйста введите описание для слова '{newWord}':");

                        userInput = Console.ReadLine();

                        wikiBook.Add(newWord, userInput);

                        Console.WriteLine($"Успешно добавлено новое слово '{newWord}':");
                    }
                }

                Console.Write("Нажмите любую клавишу . . .");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
