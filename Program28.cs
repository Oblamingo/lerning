using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userNumber = 0;

            GetNumberFromUser(out userNumber);

            Console.WriteLine($"Введённое число {userNumber}"); ;
            Console.ReadKey();
        }

        private static void GetNumberFromUser(out int userNumber)
        {
            userNumber = 0;

            while (userNumber==0)
            {
                Console.WriteLine("Пожалуйста введите целое число отличное от нуля:");

                if (!int.TryParse(Console.ReadLine(), out userNumber))
                {
                    Console.WriteLine("Не верный вод. Нажмите любую клавишу . . .");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
