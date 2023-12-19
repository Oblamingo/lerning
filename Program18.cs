Console.Title = $"Bracers";

string userLineSybols = string.Empty;

int currentNesting = 0;
int nesting = 0;
int nuberToCheckClosing = 2;

char magicOpenBracer = '(';
char magicCloseBracer = ')';

Console.WriteLine($"Введите строку из символов '{magicOpenBracer}' и '{magicCloseBracer}'");
userLineSybols = Console.ReadLine()??"";

if (userLineSybols.Length % nuberToCheckClosing == 0)
{
    if (userLineSybols[0] != magicCloseBracer && userLineSybols[userLineSybols.Length-1] != magicOpenBracer)
    {
        foreach (char oneSymbol in userLineSybols)
        {
            if (currentNesting >= 0)
            {
                if (oneSymbol == magicOpenBracer)
                {
                    currentNesting++;
                }
                else if (oneSymbol == magicCloseBracer)
                {
                    currentNesting--;
                }
            }
            else
            {
                break;
            }

            if (currentNesting > nesting)
            {
                nesting = currentNesting;
            }
        }
    }
    else
    {
        currentNesting = -1;
    }
}
else
{
    currentNesting = -1;
}

if (currentNesting == 0)
{
    Console.WriteLine($"Строка корректная {userLineSybols} Максимальная вложенность {nesting}");
}
else
{
    Console.WriteLine($"Ошибка! Не верная строка {userLineSybols}");
}
