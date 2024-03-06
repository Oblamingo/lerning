using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string MenuSum = "sum";
            const string MenuExit = "exit";

            bool isEnter = true;

            int sumNumbers = 0;
            int arraySize = 0;
            int inputInt = 0;

            string inputLine = string.Empty;
            string messageTemp = string.Empty;

            int[] numbers = new int[arraySize];
            int[] tempNumbers = new int[arraySize];

            while (isEnter)
            {
                if (numbers.Length > 0)
                {
                    foreach (int i in numbers)
                    {
                        messageTemp += $"{i} ";
                    }

                    Console.WriteLine($"Entered array:{messageTemp}");

                    messageTemp = string.Empty;
                }

                Console.WriteLine("Enter command:");                

                inputLine = Console.ReadLine().ToLower();

                switch (inputLine)
                {
                    case MenuSum:
                        foreach (int i in numbers)
                            sumNumbers += i;

                        Console.WriteLine($"Sum = {sumNumbers}\nPress any key. . .");
                        Console.ReadKey();
                        
                        sumNumbers = 0;                        
                        break;

                    case MenuExit:
                        isEnter = false;
                        break;

                    default:
                        if (int.TryParse(inputLine, out inputInt))
                        {
                            tempNumbers = new int[numbers.Length + 1];

                            for (int i = 0; i < numbers.Length; i++)
                            {
                                tempNumbers[i] = numbers[i];
                            }

                            tempNumbers[tempNumbers.Length - 1] = inputInt;
                            numbers = tempNumbers;
                        }
                        else
                        {
                            Console.WriteLine("Wrong command\nPress any key. . .");
                            Console.ReadKey();
                        }
                        break;
                }

                Console.Clear();
            }
        }
    }
}
