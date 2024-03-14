using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Queue<int> numbers = new Queue<int>();

            int countQueue = 5;
            int minRandom = 10;
            int maxRandom = 101;
            int resultProfit = 0;

            numbers = GenerateCostomers(countQueue, minRandom, maxRandom);  
            resultProfit = GetProfit(numbers);

            Console.WriteLine($"Прибыль за день: {resultProfit}");
            Console.ReadKey();
        }

        private static Queue<int> GenerateCostomers(int queueSize,int minRandom, int maxRandom)
        {
            Random random = new Random();
            Queue<int> numbers = new Queue<int>();

            int newCoast = 0;

            for (int i = 0; i < queueSize; i++)
            {
                newCoast = random.Next(minRandom, maxRandom);
                numbers.Enqueue(newCoast);              
            }

            return numbers;
        }

        private static int GetProfit(Queue<int> numbers)
        {
            int newCostomer = 0;
            int profit = 0;

            while (numbers.Count > 0)
            {
                newCostomer = numbers.Dequeue();

                ShowQueue(numbers);

                Console.WriteLine($"Прибыль: {profit}");
                Console.WriteLine($"Стоимость покупки: {newCostomer}");

                profit += newCostomer;

                Console.WriteLine($"Итог: {profit}\nНажмите любую клавишу,чтобы обсужить следующего клиента. . . ");
                Console.ReadKey();
                Console.Clear();
            }

            return profit;
        }

        private static void ShowQueue(Queue<int> queue)
        {
            Console.WriteLine($"Очередь:");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
