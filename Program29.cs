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

        static void DrawBar(int persentHealth, char symbolHealth,char symbolEmpty)
        {
            string healthPrefix = "Health ";
            string lineOfSymbols = string.Empty;

            int healthInBar = 0;
            int lengthBar = 10;
            
            healthInBar = persentHealth / lengthBar;            

            if (healthInBar >= 0 && healthInBar <= lengthBar)
            {
                for (int i = 0; i < healthInBar; i++)
                {
                    lineOfSymbols += symbolHealth;
                }               

                for (int i = healthInBar; i < lengthBar; i++)
                {
                    lineOfSymbols += symbolEmpty;
                }

                Console.Write($"{healthPrefix}{persentHealth}%\n" +
                              $"{healthPrefix}[{lineOfSymbols}]");
            }
            else
            {
                Console.WriteLine("Incorrect data . . .");
            }

            Console.ReadKey();
        }
    }
}
