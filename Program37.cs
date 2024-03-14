using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int[] firstArray = { 1, 2, 1 };
            int[] secondArray = { 3, 2 };

            AddValueToList(numbers, firstArray);
            AddValueToList(numbers, secondArray);
            DrawList(numbers);
        }

        private static void AddValueToList(List<int> numbers, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (numbers.Contains(array[i]) == false)
                {
                    numbers.Add(array[i]);
                }
            }
        }

        private static void DrawList(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}
