Random random = new Random();
int randomMin = 1;
int randomMax = 11;
int rowNumber = 1;
int columnNumber = 0;
int sumLine = 0;
int multiplyColumn = 1;
int arraySize = 2;

int[,] array = new int[arraySize, arraySize];

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        array[i, j] = random.Next(randomMin, randomMax);
        Console.Write($"{array[i, j]} ");
    }

    Console.WriteLine();
}

for (int i = 0; i < array.GetLength(1); i++)
{
    sumLine += array[rowNumber, i];
}

for (int i = 0; i < array.GetLength(0); i++)
{
    multiplyColumn *= array[i, columnNumber];
}

Console.WriteLine($"\nСумма чисел {rowNumber+1} ряда: {sumLine}"+
                  $"\nПроизведение чисел {columnNumber+1} столбца: {multiplyColumn}");
Console.ReadLine();
