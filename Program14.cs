Console.Title = "Honor name";

string lineSymbols = string.Empty;
string lineNameAndSymbols = string.Empty;
string userName = string.Empty;

char userChar;

Console.Write($"Пожалуйста введите Ваше имя:");
userName = Console.ReadLine();

Console.Write($"Пожалуйста введите символ для рамки:");
userChar = Console.ReadKey().KeyChar;

lineNameAndSymbols = userChar + userName + userChar;

for (int i = 0; i < lineNameAndSymbols.Length; i++)
{
    lineSymbols += userChar;
}

Console.WriteLine($"\r\n" +
                  $"{lineSymbols}\r\n" +
                  $"{lineNameAndSymbols}\r\n" +
                  $"{lineSymbols}\r\n");

Console.ReadKey();
