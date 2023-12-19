Console.Title = "Bracers";

string userLineSybols = string.Empty;

int countSybols = 0;
int nesting = 0;
int nuberToCheckClosing = 2;

char magicOpenBracer = '(';
char magicCloseBracer = ')';

Random random = new Random();

Console.WriteLine($"Введите строку из символов '{magicOpenBracer}' и '{magicCloseBracer}'");
userLineSybols = Console.ReadLine() ?? "";

if (userLineSybols.Length % nuberToCheckClosing == 0)
{
    if (userLineSybols[0] != magicCloseBracer && userLineSybols[userLineSybols.Length-1] != magicOpenBracer)
    {
        foreach (char oneChar in userLineSybols)
        {
            if (oneChar == magicOpenBracer)
            {
                countSybols++;
            }
            else if (oneChar == magicCloseBracer)
            {
                countSybols--;
            }
            else
            {
                countSybols = -1;
                break;
            }

            if (countSybols > nesting)
            {
                nesting = countSybols;
            }
        }
    }
    else
    {
        countSybols = -1;
    }
}
else
{
    countSybols = -1;
}

if (countSybols == 0)
{
    Console.WriteLine($"Строка корректная {userLineSybols} Максимальная вложенность {nesting}");
}
else
{
    Console.WriteLine($"Ошибка! Не верная строка {userLineSybols}");
}
