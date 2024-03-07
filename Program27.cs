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
            int arraySize = 10;
            int shift = 0;

            int[] numbers = new int[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandom, maxRandom);

                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine("\nВведите целое положительное число на сколько сдвинть по циклу массив влево: ");

            if (int.TryParse(Console.ReadLine(), out shift))
            {
                shift %= numbers.Length;

                for (int i = 0; i < shift; i++)
                {                  
                    tempNumber = numbers[0];

                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        numbers[j] = numbers[j + 1];
                    }

                    numbers[numbers.Length - 1] = tempNumber;
                }

                Console.WriteLine("Измененный массив: ");

                foreach (int num in numbers)
                {
                    Console.Write($"{num} ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }

            Console.ReadKey();
        }
    }
}
