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
                DrawArray(numbers);

                Console.WriteLine($"{MenuSum} - Для суммирования чисел\n" + 
                                  $"{MenuExit} - Для выхода\n" +
                                  $"Введите команду или число:");

                inputLine = Console.ReadLine().ToLower();

                switch (inputLine)
                {
                    case MenuSum:
                        DrawSumOfArrray(numbers);
                        break;

                    case MenuExit:
                        isEnter = false;
                        break;

                    default:
                        numbers = AddNewElementOfArray(inputLine,numbers);
                        break;
                }

                Console.Clear();
            }
        }

        private static void DrawArray(List<int> numbers)
        {
            ConsoleColor consoleColorDefault = Console.ForegroundColor;

            string messageTemp = string.Empty;

            if (numbers.Count > 0)
            {
                foreach (int number in numbers)
                {
                    messageTemp += $"{number} ";
                }

                Console.WriteLine($"Введённый массив:");

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{messageTemp}");

                Console.ForegroundColor = consoleColorDefault;
            }
        }

        private static void DrawSumOfArrray(List<int> numbers)
        {
            ConsoleColor consoleColorDefault = Console.ForegroundColor;

            int sumResult = 0;

            foreach (int number in numbers)
            {
                sumResult += number;
            }

            Console.Write($"Сумма = ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{sumResult}");

            Console.ForegroundColor = consoleColorDefault;

            Console.WriteLine("Нажмите любую клавишу. . .");
            Console.ReadKey();
        }

        private static List<int> AddNewElementOfArray(string inputLine, List<int> numbers)
        {
            ConsoleColor consoleColorDefault = Console.ForegroundColor;

            int inputInt = 0;

            if (int.TryParse(inputLine, out inputInt))
            {
                numbers.Add(inputInt);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Не верная команада");

                Console.ForegroundColor = consoleColorDefault;

                Console.WriteLine("Нажмите любую клавишу. . .");
                Console.ReadKey();
            }

            return numbers;
        }
    }
}
