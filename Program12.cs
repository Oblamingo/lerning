Console.Title = "USA Department";

const string CommandChangeName = "1";
const string CommandChangePassword = "2";
const string MenuChangeColorText = "3";
const string MenuGetCage = "4";
const string MenuExit = "9";
const string MenuColorRed = "1";
const string MenuColorGreen = "2";

string menuNavigatorType = "0";
int silienceNumber = 0;
int countTries = 3;
int userGameNumber = 0;
int minimumRandomNumber = 1;
int maximumRandomNumber = 5;

bool isWorking = true;
bool isPasswordCorrect = false;
bool isPlaying = true;
bool isWinInGame = false;

ConsoleColor consoleColorDeafualt = Console.ForegroundColor;
ConsoleColor consoleColorGreen = ConsoleColor.Green;
ConsoleColor consoleColorRed = ConsoleColor.Red;
ConsoleColor consoleColorName = ConsoleColor.Magenta;
ConsoleColor userConsoleColor = consoleColorDeafualt;

ConsoleKey isUserWantPlay = ConsoleKey.Y;

ConsoleKeyInfo userInputKey = new ConsoleKeyInfo();

Random random = new Random();

string defaultName = "admin";
string userName = defaultName;
string userPassword = defaultName;
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
        Console.WriteLine($"[{CommandChangeName}] Изменить имя\r\n" +
                            $"[{CommandChangePassword}] Изменить пароль\r\n" +
                            $"[{MenuChangeColorText}] Изменить цвет ввода текста\r\n" +
                            $"[{MenuGetCage}] Угадать код от сейфа\r\n" +
                            $"[{MenuExit}] Выход из программы");

        Console.ForegroundColor = userConsoleColor;
        menuNavigatorType = Console.ReadLine() ?? MenuExit;

        switch (menuNavigatorType)
        {
            case CommandChangeName:
                Console.ForegroundColor = consoleColorDeafualt;
                Console.Write(messageChangeName);

                Console.ForegroundColor = userConsoleColor;
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    userName = defaultName;

                    Console.ForegroundColor = consoleColorRed;
                    Console.WriteLine(errorInputWrong);
                    Console.ReadKey();
                }

                isPasswordCorrect = false;
                break;

            case CommandChangePassword:
                Console.ForegroundColor = consoleColorDeafualt;
                Console.Write(messageChangePassword);

                Console.ForegroundColor = userConsoleColor;
                userPassword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    userName = defaultName;

                    Console.ForegroundColor = consoleColorRed;
                    Console.WriteLine(errorInputWrong);
                    Console.ReadKey();
                }

                isPasswordCorrect = false;
                break;

            case MenuChangeColorText:
                Console.ForegroundColor = consoleColorDeafualt;
                Console.WriteLine($"Выберите цвет ввода:" +
                                  $"[{MenuColorRed}] Красный\r\n" +
                                  $"[{MenuColorGreen}] Зелёный\r\n");

                Console.ForegroundColor = userConsoleColor;
                menuNavigatorType = Console.ReadLine();

                switch (menuNavigatorType)
                {
                    case MenuColorRed:
                        userConsoleColor = consoleColorRed;
                        break;

                    case MenuColorGreen:
                        userConsoleColor = consoleColorGreen;
                        break;
                    default:
                        userConsoleColor = consoleColorDeafualt;
                        break;
                }
                break;

            case MenuGetCage:
                while (isPlaying)
                {
                    Console.Clear();
                    silienceNumber = random.Next(minimumRandomNumber, maximumRandomNumber);
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
                    userInputKey = Console.ReadKey();

                    if (userInputKey.Key != isUserWantPlay)
                    {
                        isPlaying = false;
                    }
                }
                break;

            case MenuExit:
                isWorking = false;
                break;
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
