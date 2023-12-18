Console.Title = "Silence message";

string systemPassword = "qwerty";
string userEnterPassword = string.Empty;
string enterMessage = "Вас приветствует консульсто США\r\nАвторизация";
string silenceMessage = "##########################\r\n" +
                        "#  Секретное донесение:  #\r\n" +
                        "#     Ты красавчик!      #\r\n" +
                        "##########################";

int countTries = 3;

Console.WriteLine(enterMessage);

while (countTries>0)
{
    countTries--;

    Console.Write($"Пароль:");
    userEnterPassword = Console.ReadLine()??"";

    if (userEnterPassword == systemPassword)
    {        
        Console.WriteLine(silenceMessage); 
        countTries = 0;
    }
    else 
    {
        Console.WriteLine($"Вы ввели не верный пароль.У Вас осталось {countTries} попыток");
    }    
}
