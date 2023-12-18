Console.Title = "Honor name";

string userName = string.Empty;
string writeWord = "";
string tempWord= string.Empty;

char userChar;

int lengthname = 0;

Console.Write($"Пожалуйста введите Ваше имя:");
userName = Console.ReadLine();

Console.Write($"Пожалуйста введите символ для рамки:");
userChar = Console.ReadKey().KeyChar;

lengthname = userName.Length;

//circle algorithm

writeWord += "\r\n";
for (int j = 0; j < 3; j++)
{
    for (int i = 0; i < lengthname + 2; i++)
    {
        if (j==1 && i>0 && i<= lengthname)
        {
            writeWord += userName[i-1];
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

tempWord = new String(userChar, lengthname + 2);

Console.WriteLine($"{tempWord}\r\n" +
                  $"{userChar}{userName}{userChar}\r\n" +
                  $"{tempWord}\r\n");

Console.ReadKey();

