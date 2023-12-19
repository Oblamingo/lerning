Console.Title = $"Bracers";

string userLineSybols = string.Empty;

int currentNesting = 0;
int maximunNesting = 0;

char magicOpenBracer = '(';
char magicCloseBracer = ')';

Console.WriteLine($"Введите строку из символов '{magicOpenBracer}' и '{magicCloseBracer}'");
userLineSybols = Console.ReadLine() ?? "";

foreach (char symbol in userLineSybols)
{
    if (symbol == magicOpenBracer)
    {
        currentNesting++;

        if (currentNesting > maximunNesting)
        {
            maximunNesting = currentNesting;
        }
    }
    else if (symbol == magicCloseBracer)
    {
        currentNesting--;

        if (currentNesting < 0)
            break;
    }
}

if (currentNesting == 0)
{
    Console.WriteLine($"Строка корректная {userLineSybols} Максимальная вложенность {maximunNesting}");
}
else
{
    Console.WriteLine($"Ошибка! Не верная строка {userLineSybols}");
}
