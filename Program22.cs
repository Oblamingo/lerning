Random random = new Random();

int randomMax = 1;
int randomMin = 10;
int arraySize = 30;
int numbersLength = 0;

string initialArray = "";
string localMaxArray = "";

int[] array = new int[arraySize];

numbersLength = array.Length - 1;

for (int i = 0; i < array.Length; i++)
{
    array[i] = random.Next(randomMax, randomMin);
    initialArray += Convert.ToString(array[i] + " ");
}

if ((array[0] > array[1]))
{
    localMaxArray += array[0] + " ";
}

for (int j = 1; j < numbersLength; j++)
{
    if (array[j] > array[j + 1] && array[j] > array[j - 1])
    {
        localMaxArray += array[j] + " ";
    }
}

if (array[numbersLength] > array[numbersLength - 1])
{
    localMaxArray += "" + array[numbersLength];
}

Console.WriteLine($"Исходный массив:{initialArray}\n" +
                  $"Локальные максимумы: {localMaxArray}\n" +
                  $"Длина массива {array.Length}");

Console.ReadKey();
