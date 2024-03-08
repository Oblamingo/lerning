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
            int userNumber = 0;

            while (userNumber==0)
            {
                Console.WriteLine("Пожалуйста введите целое число отличное от нуля:");

                if (int.TryParse(Console.ReadLine(), out userNumber) == false)
                {
                    Console.WriteLine("Не верный вод. Нажмите любую клавишу . . .");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            return userNumber;
        }
    }
}
