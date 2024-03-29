using System;

namespace Lerning
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int health = 8;
            int maxHealth = 20;
            int persentFull = 100;
            int persentHealth = 0;

            char symbolHealth = '#';
            char symbolEmpty = ' ';

            persentHealth = (health * persentFull) / maxHealth;

            DrawBar(persentHealth, symbolHealth, symbolEmpty);
        }

        static void DrawBar(int persentHealth, char symbolHealth, char symbolEmpty)
        {
            string healthPrefix = "Health ";
            string healthInSybols = string.Empty;
            string damagedHealthInSymbols = string.Empty;

            int healthInBar = 0;
            int lengthBar = 10;

            healthInBar = persentHealth / lengthBar;

            if (healthInBar >= 0 && healthInBar <= lengthBar)
            {
                healthInSybols = GenerateLineSymbols(symbolHealth, healthInBar);
                damagedHealthInSymbols = GenerateLineSymbols(symbolEmpty, lengthBar - healthInBar);

                Console.Write($"{healthPrefix}{persentHealth}%\n" +
                              $"{healthPrefix}[{healthInSybols}{damagedHealthInSymbols}]");
            }
            else
            {
                Console.WriteLine("Incorrect data . . .");
            }

            Console.ReadKey();
        }

        static string GenerateLineSymbols(char symbolHealth, int lengthOfSybols)
        {
            string line = string.Empty;

            for (int i = 0; i < lengthOfSybols; i++)
            {
                line += symbolHealth;
            }

            return line;
        }
    }
}
