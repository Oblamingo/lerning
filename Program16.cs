Console.Title = "Count N between 100 to 1000";

int countNumbers = 0;
int randomNumber = 0;
int startPeriod = 1;
int endPeriod = 28;
int intervalMinimum = 100;
int intervalMaximum = 1000;

Random random = new Random();

randomNumber = random.Next(startPeriod, endPeriod);

for (int i = 0; i < intervalMaximum; i += randomNumber)
{
    if (i >= intervalMinimum)
    {
        countNumbers++;
    }
}

Console.WriteLine($"Найдено {countNumbers} трёхзначных чисел кратных числу {randomNumber}.");
Console.ReadKey();
