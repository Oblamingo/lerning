Random randomizer = new Random();

int randomNumber = 0;
int sumNumbers = 0;
int firstMagicDivider = 3;
int secondMagicDivider = 5;
int endRandomizerNumber = 100;

ConsoleColor defaultColor = Console.ForegroundColor;

randomNumber = randomizer.Next(firstMagicDivider, endRandomizerNumber);

for (int i = firstMagicDivider; i <= randomNumber; i++)
{
    if (i % firstMagicDivider == 0 || i % secondMagicDivider == 0)
    {
        sumNumbers += i;
    }
}

Console.Write($"Случайное число : ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{randomNumber}");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nСумма кратных {firstMagicDivider} и {secondMagicDivider} числам: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{sumNumbers}");

Console.ForegroundColor = defaultColor;
