Random random = new Random();

int maxElement = 0;
int arraySize = 10;
int randomMin = 10;
int randomMax = 100;

int[,] array = new int[arraySize, arraySize];

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        array[i, j] = random.Next(randomMin, randomMax);        

        if (maxElement < array[i, j])
        {
            maxElement = array[i, j];
        }

        Console.Write(array[i, j] + " ");
    }

    Console.WriteLine();
}

Console.WriteLine($"Наибольший элемент матрицы: {maxElement}");

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        if (array[i, j] == maxElement)
        {
            array[i, j] = 0;
        }

        Console.Write(array[i, j] + " ");
    }

    Console.WriteLine();
}

Console.ReadKey();
