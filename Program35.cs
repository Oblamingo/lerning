using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuSum = "sum";
            const string MenuExit = "exit";

            List<int> numbers = new List<int>();

            bool isEnter = true;

            string inputLine = string.Empty;

            while (isEnter)
            {
                DrawList(numbers);

                Console.WriteLine($"{MenuSum} - Для суммирования чисел\n" +
                                  $"{MenuExit} - Для выхода\n" +
                                  $"Введите команду или число:");

                inputLine = Console.ReadLine().ToLower();

                switch (inputLine)
                {
                    case MenuSum:
                        DrawSumOfList(numbers);
                        break;

                    case MenuExit:
                        isEnter = false;
                        break;

                    default:
                        AddNewElementOfList(inputLine, numbers);
                        break;
                }

                Console.Clear();
            }
        }

        private static void DrawList(List<int> numbers)
        {
            string messageTemp = string.Empty;

            if (numbers.Count > 0)
            {
                foreach (int number in numbers)
                {
                    messageTemp += $"{number} ";
                }

                Console.WriteLine($"Введённый массив:");

                ShowMesseage($"{messageTemp}");
            }
        }

        private static void DrawSumOfList(List<int> numbers)
        {
            int sumResult = 0;

            foreach (int number in numbers)
            {
                sumResult += number;
            }

            Console.Write($"Сумма = ");

            ShowMesseage($"{sumResult}");
            ShowAwait();
        }

        private static void AddNewElementOfList(string inputLine, List<int> numbers)
        {
            int inputInt = 0;

            if (int.TryParse(inputLine, out inputInt))
            {
                numbers.Add(inputInt);
            }
            else
            {
                ShowMesseage("Не верная команада", true);
                ShowAwait();
            }
        }

        private static void ShowMesseage(string text, bool isError = false)
        {
            ConsoleColor newConsoleColor = ConsoleColor.Green;
            ConsoleColor consoleColorDefault = Console.ForegroundColor;

            if (isError)
            {
                newConsoleColor = ConsoleColor.Red;
            }

            Console.ForegroundColor = newConsoleColor;

            Console.WriteLine($"{text}");

            Console.ForegroundColor = consoleColorDefault;

        }

        private static void ShowAwait()
        {
            Console.WriteLine("Нажмите любую клавишу. . .");
            Console.ReadKey();
        }
    }
}
