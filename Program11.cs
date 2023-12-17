Console.Title = "CASH MARKET";

const int MenuDollarToRubles = 1;
const int MenuDollarToEuro = 2;
const int MenuEuroToDollar = 3;
const int MenuEuroToRubles = 4;
const int MenuRublesToEuro = 5;
const int MenuRublesToDollar = 6;
const int MenuExit = 9;

int menuNavigatorType = 0;

float dollarToRubles = 32f;
float dollarToEuro = 1.1f;
float euroToRubles = 41f;
float euroToDollar = 1.4f;
float rublesToEuro = 0.4f;
float rublesToDollar = 0.3f;
float templeCalculation = 0;
float userDollars = 1000;
float userEuros = 1000;
float userRubles = 1000;
float userWantedMoneyCount = 0;

bool isWorking = true;

string messageEnterCount = $"Введите желаемое кол-во:";
string messageNoEnoughMoneySell = $"Недостатончое кол-во средств для продажи";
string messageErrorMenu = $"Вы ввели неверную команду. Возврат в основное меню.";
string messageShowing = "";

ConsoleColor consoleColorDeafualt = Console.ForegroundColor;
ConsoleColor consoleColorAgree = ConsoleColor.Green;
ConsoleColor consoleColorAlert = ConsoleColor.Red;
ConsoleColor consoleColorName = ConsoleColor.Magenta;

while (isWorking)
{
    messageShowing = "";

    Console.Clear(); 
    Console.ForegroundColor = consoleColorName;
    Console.Write($"Ваш баланс\t|\tОбменный курс\r\n");
    Console.ForegroundColor = consoleColorDeafualt;
    Console.Write($"\t\t|\t\tДоллар\tЕвро\tРубль\r\n");
    Console.Write($"Доллар:\t{userDollars}\t|\tДоллар\t1\t{dollarToEuro}\t{dollarToRubles}\r\n");
    Console.Write($"Евро:\t{userEuros}\t|\tЕвро\t{euroToDollar}\t1\t{euroToRubles}\r\n");
    Console.Write($"Рубли:\t{userRubles}\t|\tРубли\t{rublesToDollar}\t{rublesToEuro}\t1");

    Console.ForegroundColor = consoleColorName;
    Console.WriteLine($"\r\n\nВыберите операцию:");
    Console.ForegroundColor = consoleColorDeafualt;
    Console.WriteLine(  $"[{MenuDollarToRubles}] Конвертировать доллар в рубли\r\n" +
                        $"[{MenuDollarToEuro}] Конвертировать доллар в евро\r\n" +
                        $"[{MenuEuroToDollar}] Конвертировать евро в доллар\r\n" +
                        $"[{MenuEuroToRubles}] Конвертировать евро в рубли\r\n" +
                        $"[{MenuRublesToEuro}] Конвертировать рубли в евро\r\n" +
                        $"[{MenuRublesToDollar}] Конвертировать рубли в доллар\r\n" +
                        $"[{MenuExit}] Выход из программы");

    if (int.TryParse(Console.ReadLine(), out menuNavigatorType))
    {
        if (menuNavigatorType == MenuExit)
        {
            isWorking = false;
            continue;
        }
        else
        {
            Console.WriteLine(messageEnterCount);
            Console.ForegroundColor = consoleColorAgree;

            if (float.TryParse(Console.ReadLine(), out userWantedMoneyCount))
            {
                if (userWantedMoneyCount > 0)
                {
                    switch (menuNavigatorType)
                    {
                        case MenuDollarToRubles:
                            templeCalculation = userDollars - userWantedMoneyCount;

                            if (templeCalculation >= 0)
                            {
                                userDollars = templeCalculation;
                                userRubles += userWantedMoneyCount * dollarToRubles;
                            }
                            else
                            {
                                messageShowing = messageNoEnoughMoneySell;
                            }
                            break;

                        case MenuDollarToEuro:
                            templeCalculation = userDollars - userWantedMoneyCount;

                            if (templeCalculation >= 0)
                            {
                                userDollars = templeCalculation;
                                userEuros += userWantedMoneyCount * dollarToEuro;
                            }
                            else
                            {
                                messageShowing = messageNoEnoughMoneySell;
                            }
                            break;

                        case MenuEuroToDollar:
                            templeCalculation = userEuros - userWantedMoneyCount;

                            if (templeCalculation >= 0)
                            {
                                userEuros = templeCalculation;
                                userDollars += userWantedMoneyCount * euroToDollar;
                            }
                            else
                            {
                                messageShowing = messageNoEnoughMoneySell;
                            }
                            break;

                        case MenuEuroToRubles:
                            templeCalculation = userEuros - userWantedMoneyCount;

                            if (templeCalculation >= 0)
                            {
                                userEuros = templeCalculation;
                                userRubles += userWantedMoneyCount * euroToRubles;
                            }
                            else
                            {
                                messageShowing = messageNoEnoughMoneySell;
                            }
                            break;

                        case MenuRublesToEuro:
                            templeCalculation = userRubles - userWantedMoneyCount;

                            if (templeCalculation >= 0)
                            {
                                userRubles = templeCalculation;
                                userEuros += userWantedMoneyCount * rublesToEuro;
                            }
                            else
                            {
                                messageShowing = messageNoEnoughMoneySell;
                            }
                            break;

                        case MenuRublesToDollar:
                            templeCalculation = userRubles - userWantedMoneyCount;

                            if (templeCalculation >= 0)
                            {
                                userRubles = templeCalculation;
                                userDollars += userWantedMoneyCount * rublesToDollar;
                            }
                            else
                            {
                                messageShowing = messageNoEnoughMoneySell;
                            }
                            break;

                        default:
                            messageShowing = messageErrorMenu;
                            break;
                    }
                }
            }
            else
            {
                messageShowing = messageErrorMenu;
            }
        }
    }
    else
    {
        messageShowing = messageErrorMenu;
    }

    if (string.IsNullOrWhiteSpace(messageShowing))
    {
        Console.ForegroundColor = consoleColorAlert;
        Console.WriteLine(messageShowing);
    }
}
