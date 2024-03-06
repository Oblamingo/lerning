const string MenuSum = "sum";
const string MenuExit = "exit";

Random random = new Random();

bool isEnter = true;

int sumNumbers = 0;
int arraySize = 0;
int inputInt = 0;

string inputLine = string.Empty;
string messageTemp = string.Empty;


int[] arrayNumbers = new int[arraySize];
int[] arrayTemp = new int[arraySize];

while (isEnter)
{
    if (arrayNumbers.Length > 0)
    {
        foreach (int i in arrayNumbers)
        {
            messageTemp += $"{i} ";
        }

        Console.WriteLine($"Entered array:{messageTemp}");

        messageTemp = string.Empty;
    }

    Console.WriteLine("Enter command:");

    inputLine = Console.ReadLine().ToLower();

    switch (inputLine)
    {
        case MenuSum:

            foreach (int i in arrayNumbers)
                sumNumbers += i;

            Console.WriteLine($"Sum = {sumNumbers}\nPress any key. . .");
            Console.ReadKey();
            break;

        case MenuExit:

            isEnter = false;
            break;

        default:

            if (int.TryParse(inputLine, out inputInt))
            {
                arrayTemp = new int[arrayNumbers.Length + 1];

                for (int i = 0; i < arrayNumbers.Length; i++)
                {
                    arrayTemp[i] = arrayNumbers[i];
                }

                arrayTemp[arrayTemp.Length - 1] = inputInt;
                arrayNumbers = arrayTemp;
            }
            else
            {
                Console.WriteLine("Wrong command\nPress any key. . .");
                Console.ReadKey();
            }
            break;
    }

    Console.Clear();
}
