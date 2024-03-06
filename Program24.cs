using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int maxRepeatOfNumber = 0;
            int tempMaxRepeatOfNumber = 0;
            int tempRepeatNumber = 0;
            int repeatNumber = 0;
            int minRandom = 1;
            int maxRandom = 6;
            int arraySize = 30;
            int startNumber = 1;

            int[] numbers = new int[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandom, maxRandom);

                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            for (int i = startNumber; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    tempMaxRepeatOfNumber++;
                    tempRepeatNumber = numbers[i];
                }
                else
                {
                    tempMaxRepeatOfNumber = 0;
                }

                if (maxRepeatOfNumber < tempMaxRepeatOfNumber)
                {
                    maxRepeatOfNumber = tempMaxRepeatOfNumber;
                    repeatNumber = tempRepeatNumber;
                }
            }

            if (maxRepeatOfNumber > tempMaxRepeatOfNumber)
            {
                Console.WriteLine($"Number {repeatNumber} repeats {maxRepeatOfNumber + startNumber} times");
            }
            else
            {
                Console.WriteLine("No repeat in array");
            }

            Console.ReadKey();
        }
    }
}
