Console.Title = "USA Department";

const int MenuChangeName = 1;
const int MenuChangePassword = 2;
const int MenuChangeColorText = 3;
const int MenuGetCage = 4;
const int MenuExit = 9;
const int MenuColorRed = 1;
const int MenuColorGreen = 2;

int menuNavigatorType = 0;
int silienceNumber = 0;
int countTries = 3;
int userGameNumber = 0;

bool isWorking = true;
bool isPasswordCorrect = false;
bool isPlaying = true;
bool isWinInGame = false;

ConsoleColor consoleColorDeafualt = Console.ForegroundColor;
ConsoleColor consoleColorGreen = ConsoleColor.Green;
ConsoleColor consoleColorRed = ConsoleColor.Red;
ConsoleColor consoleColorName = ConsoleColor.Magenta;
ConsoleColor userConsoleColor = consoleColorDeafualt;

Random randomNumers = new Random();

string userName = "admin";
string userPassword = "admin";
string authorisationName = string.Empty;
string authorisationPassword = string.Empty;

string errorInputLogin = "Не верный логин или пароль. Повторите попытку.";
string errorInputWrong = "Не корректный ввод!";
string errorWrongTryGame = "Не угадал!";
string messageChangeName = "Введите новое имя:";
string messageChangePassword = "Введите новый пароль:";

while (isWorking)
{
    Console.Clear();

    if (isPasswordCorrect)
    {
        Console.ForegroundColor = consoleColorName;
        Console.WriteLine($"Добрый день агент, {userName}!");
        Console.ForegroundColor = consoleColorDeafualt;
        Console.WriteLine(  $"[{MenuChangeName}] Изменить имя\r\n" +
                            $"[{MenuChangePassword}] Изменить пароль\r\n" +
                            $"[{MenuChangeColorText}] Изменить цвет ввода текста\r\n" +
                            $"[{MenuGetCage}] Угадать код от сейфа\r\n" +
                            $"[{MenuExit}] Выход из программы");
        Console.ForegroundColor = userConsoleColor;

        if (int.TryParse(Console.ReadLine(), out menuNavigatorType))
        {
            switch (menuNavigatorType)
            {
                case MenuChangeName:
                    Console.ForegroundColor = consoleColorDeafualt;
                    Console.Write(messageChangeName);

                    Console.ForegroundColor = userConsoleColor;
                    userName = Console.ReadLine();

                    isPasswordCorrect = false;
                    break;

                case MenuChangePassword:
                    Console.ForegroundColor = consoleColorDeafualt;
                    Console.Write(messageChangePassword);

                    Console.ForegroundColor = userConsoleColor;
                    userPassword = Console.ReadLine();

                    isPasswordCorrect = false;
                    break;

                case MenuChangeColorText:
                    Console.ForegroundColor = consoleColorDeafualt;
                    Console.WriteLine($"Выберите цвет ввода:" +
                                      $"[{MenuColorRed}] Красный\r\n" +
                                      $"[{MenuColorGreen}] Зелёный\r\n");

                    if (int.TryParse(Console.ReadLine(), out menuNavigatorType))
                    {
                        switch (menuNavigatorType)
                        {
                            case MenuColorRed:
                                userConsoleColor = consoleColorRed;
                                break;

                            case MenuColorGreen:
                                userConsoleColor = consoleColorGreen;
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = consoleColorRed;
                        Console.WriteLine(errorInputWrong);
                    }
                    break;

                case MenuGetCage:
                    while (isPlaying)
                    {
                        Console.Clear();
                        silienceNumber = randomNumers.Next(1, 2);
                        isWinInGame = false;
                        countTries = 5;

                        while (!isWinInGame && countTries > 0)
                        {
                            Console.ForegroundColor = consoleColorDeafualt;
                            Console.WriteLine($"Введите предполагаемое число. У вас {countTries} попыток");

                            Console.ForegroundColor = userConsoleColor;

                            if (int.TryParse(Console.ReadLine(), out userGameNumber))
                            {
                                if (userGameNumber == silienceNumber)
                                {
                                    isWinInGame = true;
                                    continue;
                                }
                                else
                                {
                                    countTries--;

                                    Console.ForegroundColor = consoleColorRed;
                                    Console.WriteLine(errorWrongTryGame);
                                }
                            }
                            else
                            {
                                countTries--;

                                Console.ForegroundColor = consoleColorRed;
                                Console.WriteLine(errorInputWrong);
                            }
                        }

                        if (isWinInGame)
                        {
                            Console.ForegroundColor = consoleColorGreen;
                            Console.WriteLine("Ты угадал код!");
                        }
                        else
                        {
                            Console.ForegroundColor = consoleColorGreen;
                            Console.WriteLine("Ты проиграл все попытки!");
                        }

                        Console.ForegroundColor = consoleColorDeafualt;
                        Console.WriteLine("Сыграем снова?Y/N\r\n");

                        Console.ForegroundColor = userConsoleColor;
                        ConsoleKeyInfo key = Console.ReadKey();

                        if (key.Key != ConsoleKey.Y)
                        {
                            isPlaying = false;
                            continue;
                        }
                    }
                    break;

                case MenuExit:
                    isWorking = false;
                    break;
            }
        }
    }
    else
    {
        Console.ForegroundColor = consoleColorName;
        Console.WriteLine($"Вас приветствует консульсто США\r\nАвторизация");

        Console.ForegroundColor = consoleColorDeafualt;
        Console.Write($"Логин:");

        Console.ForegroundColor = userConsoleColor;
        authorisationName = Console.ReadLine();

        Console.ForegroundColor = consoleColorDeafualt;
        Console.Write($"Пароль:");

        Console.ForegroundColor = userConsoleColor;
        authorisationPassword = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(authorisationName) && !string.IsNullOrWhiteSpace(authorisationPassword))
        {
            if (userName == authorisationName && userPassword == authorisationPassword)
            {
                if (userPassword == authorisationPassword)
                {
                    isPasswordCorrect = true;

                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(250, 500);
                    Thread.Sleep(50);
                    Console.Beep(350, 250);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(250, 500);
                    Thread.Sleep(50);
                    Console.Beep(350, 250);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                }
            }
            else
            {
                Console.Beep();
                Console.Beep();
                Console.Beep();

                Console.ForegroundColor = consoleColorRed;
                Console.WriteLine(errorInputLogin);

                Console.ReadKey();
            }
        }
    }
}
