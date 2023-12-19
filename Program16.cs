int countNumbers = 0;
int randomNumber = 0;
int startPeriod = 1;
int endPeriod = 27;
int intervalMinimum = 100;
int intervalMaximum = 1000;

Random random = new Random();

Console.Title = $"Count N between {intervalMinimum} to {intervalMaximum}";

randomNumber = random.Next(startPeriod, endPeriod + 1);

for (int i = 0; i < intervalMaximum; i += randomNumber)
{
    if (i >= intervalMinimum)
    {
        countNumbers++;
    }
}

Console.WriteLine($"Найдено {countNumbers} трёхзначных чисел кратных числу {randomNumber}.");
Console.ReadKey();
