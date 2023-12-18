Console.Title = "Honor name";

string userName = string.Empty;
string writeWord = string.Empty;
string tempWord= string.Empty;

char userChar;

int lengthName = 0;
int highFrame = 3;
int widthFrame = 0;
int thicknessFrame = 1;

Console.Write($"Пожалуйста введите Ваше имя:");
userName = Console.ReadLine();

Console.Write($"Пожалуйста введите символ для рамки:");
userChar = Console.ReadKey().KeyChar;

lengthName = userName.Length;
widthFrame = thicknessFrame + lengthName + thicknessFrame;

//circle algorithm

writeWord += "\r\n";
for (int j = 0; j < highFrame; j++)
{
    for (int i = 0; i < widthFrame; i++)
    {
        if (j == thicknessFrame && i>0 && i<= lengthName)
        {
            writeWord += userName[i - thicknessFrame];
        }
        else
        {
            writeWord += userChar;
        }
    }
    writeWord += "\r\n";
}

Console.WriteLine($"{writeWord}");

//short algorithm

tempWord = new String(userChar, widthFrame);

Console.WriteLine($"{tempWord}\r\n" +
                  $"{userChar}{userName}{userChar}\r\n" +
                  $"{tempWord}\r\n");

//admin algorithm

tempWord = string.Empty;

for (int i = 0; i < widthFrame; i++)
{
    tempWord += userChar;
}

Console.WriteLine($"{tempWord}\r\n" +
                  $"{userChar}{userName}{userChar}\r\n" +
                  $"{tempWord}\r\n");

Console.ReadKey();
