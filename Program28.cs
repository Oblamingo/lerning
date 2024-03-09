using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введённое число {GetNumberFromUser()}"); ;
            Console.ReadKey();
        }

        private static int GetNumberFromUser()
        {
            bool isUserNumberEmpty = true;

            int userNumber = 0;

            while (isUserNumberEmpty)
            {
                Console.WriteLine("Пожалуйста введите целое число:");

                if (int.TryParse(Console.ReadLine(), out userNumber) == false)
                {
                    Console.WriteLine("Не верный вод. Нажмите любую клавишу . . .");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    isUserNumberEmpty = false;
                }
            }

            return userNumber;
        }
    }
}
