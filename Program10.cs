Random randomizer = new Random();

int randomNumber = 0;
int sumNumbers3 = 0;
int sumNumbers5 = 0;
int sumNumbersAll = 0;
int firstMagicDivider = 3;
int secondMagicDivider = 5;
int startPeriodNumber = 100;
string magicalNumberString3 = "";
string magicalNumberString5 = "";
ConsoleColor defaultColor = Console.ForegroundColor;

randomNumber = randomizer.Next(firstMagicDivider, startPeriodNumber);

for (int i = 0; i <= randomNumber; i++)
{
    if (i % firstMagicDivider == 0 && i / firstMagicDivider != 0)
    {
        sumNumbers3 += i;
        magicalNumberString3 += $"{i} ";
    }
    else if (i % secondMagicDivider == 0 && i / secondMagicDivider != 0)
    {
        sumNumbers5 += i;
        magicalNumberString5 += $"{i} ";
    }
}
sumNumbersAll = sumNumbers3 + sumNumbers5;

Console.Write($"Случайное число : ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{randomNumber}");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nЧисла кратные {firstMagicDivider} и их сумма: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{magicalNumberString3}({sumNumbers3})");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nЧисла кратные {secondMagicDivider} и их сумма: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{magicalNumberString5}({sumNumbers5})");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nСумма кратных {firstMagicDivider} и {secondMagicDivider} числам: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{sumNumbersAll}");

Console.ForegroundColor = defaultColor;
