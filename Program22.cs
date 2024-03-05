const int RandomMax = 1;
const int RandomMin = 10;
const int ArraySize = 30;

Random random = new Random();

string initialArray = "";
string localMaxArray = "";

int[] array = new int[ArraySize];

for (int i = 0; i < array.Length; i++)
{
    array[i] = random.Next(RandomMax, RandomMin);
    initialArray += Convert.ToString(array[i] + " ");
}

if ((array[0] > array[1]))
{
    localMaxArray += array[0] + " ";
}

for (int j = 1; j < array.Length - 1; j++)
{
    if (array[j] > array[j + 1] && array[j] > array[j - 1])
    {
        localMaxArray += array[j] + " ";
    }
}

if (array[array.Length - 1] > array[array.Length - 2])
{
    localMaxArray += "" + array[array.Length - 1];
}

Console.WriteLine($"Исходный массив:{initialArray}\n" +
                  $"Локальные максимумы: {localMaxArray}\n" +
                  $"Длина массива {array.Length}");

Console.ReadKey();
