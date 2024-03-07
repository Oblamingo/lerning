using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int tempNumber = 0;
            int minRandom = 1;
            int maxRandom = 30;
            int arraySize = 30;

            int[] numbers = new int[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandom, maxRandom);

                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        tempNumber = numbers[j];
                        numbers[j] = numbers[i];
                        numbers[i] = tempNumber;
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
