using System.Drawing;

Random randomizer = new Random();

int randomNumber = 0;
int sumNumbers3 = 0;
int sumNumbers5 = 0;
int sumNumbersAll = 0;
int magicNumber3 = 3;
int magicNumber5 = 5;
int startPeriodNumber = 100;
string magicalNumberString3 = "";
string magicalNumberString5 = "";
ConsoleColor defaultColor = Console.ForegroundColor;

randomNumber = randomizer.Next(magicNumber3, startPeriodNumber);

for (int i = 0; i <= randomNumber; i++)
{
    if (i % magicNumber3 == 0 && i / magicNumber3 != 0)
    { 
        sumNumbers3 += i;
        magicalNumberString3 += $"{i} ";
    }
    if (i % magicNumber5 == 0 && i / magicNumber5 != 0)
    {
        sumNumbers5 += i;
        magicalNumberString5 += $"{i} ";
    }
}
sumNumbersAll= sumNumbers3 + sumNumbers5;

Console.Write($"Случайное число : ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{randomNumber}");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nЧисла кратные {magicNumber3} и их сумма: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{magicalNumberString3}({sumNumbers3})");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nЧисла кратные {magicNumber5} и их сумма: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{magicalNumberString5}({sumNumbers5})");

Console.ForegroundColor = defaultColor;
Console.Write($"\r\nСумма кратных {magicNumber3} и {magicNumber5} числам: ");

Console.ForegroundColor = ConsoleColor.Green;
Console.Write($"{sumNumbersAll}");

Console.ForegroundColor = defaultColor;
