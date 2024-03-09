using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ShowArray(array);

            Shuffle(array);

            ShowArray(array);
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();

            int arrayIndex;
            int tempElement;
            int startRandom = 0;

            for (int i = 0; i < array.Length; i++)
            {
                arrayIndex = random.Next(startRandom, array.Length);
                tempElement = array[arrayIndex];
                array[arrayIndex] = array[i];
                array[i] = tempElement;
            }
        }
        
        static void ShowArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
    }
}
