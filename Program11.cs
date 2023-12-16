using System;
using System.ComponentModel.Design;

Console.Title = "CASH MARKET";

const int MenuDollarSell = 1;
const int MenuEuroSell = 2;
const int MenuRublesSell = 3;

const int MenuTypeByEuros = 1;
const int MenuTypeByRubles = 2;
const int MenuTypeByDollars = 3;

const int MenuExit = 9;

const int MenuErrorMessageEmpty = 0;
const int MenuErrorSell = 1;
const int MenuErrorComand = 2;

int menuNavigatorCurrency = 0;
int menuNavigatorType = 0;

float dollarCostBuyRubles= 32f;
float dollarCostBuyEuro = 1.1f;

float euroCostBuyRubles = 41f;
float euroCostBuyDollar = 1.4f;

float rublesCostBuyEuro = 0.4f;
float rublesCostBuyDollar = 0.3f;

float templeCalculation = 0;
float preCalculation = 0;

float userDollars = 1000;
float userEuros = 1000;
float userRubles = 1000;

bool isWorking = true;

float userWantedMoneyCount = 0;
float userWantedMoneyCurrency = 0;

int errorMessageType = 0;

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
    Console.Clear();
    isWorking = true;

    Console.ForegroundColor = consoleColorName;
    Console.Write($"Ваш баланс\t|" +
        $"\tОбменный курс");
    Console.ForegroundColor = consoleColorDeafualt;
    Console.Write($"\r\n\t\t|" +
        $"\t\tДоллар\tЕвро\tРубль");
    Console.Write($"\r\nДоллар:\t{userDollars}\t|" +
        $"\tДоллар\t1\t{dollarCostBuyEuro}\t{dollarCostBuyRubles}");
    Console.Write($"\r\nЕвро:\t{userEuros}\t|" +
        $"\tЕвро\t{euroCostBuyDollar}\t1\t{euroCostBuyRubles}");
    Console.Write($"\r\nРубли:\t{userRubles}\t|" +
        $"\tРубли\t{rublesCostBuyDollar}\t{rublesCostBuyEuro}\t1");

    Console.ForegroundColor = consoleColorName;
    Console.WriteLine($"\r\n\nВыберите операцию:");
    Console.ForegroundColor = consoleColorDeafualt;
    Console.WriteLine(  $"[{MenuDollarSell}] Конвертировать доллар" +
                        $"\r\n[{MenuEuroSell}] Конвертировать евро" +
                        $"\r\n[{MenuRublesSell}] Конвертировать рубли" +
                        $"\r\n[{MenuExit}] Выход из программы");

    int.TryParse(Console.ReadLine(), out menuNavigatorType);

    templeCalculation = 0;
    preCalculation = 0;
    errorMessageType = 0;

    switch (menuNavigatorType)
    {      
        case MenuDollarSell:
            Console.ForegroundColor = consoleColorName;
            Console.WriteLine($"Выберите в валюту конвертации Доллара:");
            Console.ForegroundColor = consoleColorDeafualt;
            Console.WriteLine($"[{MenuTypeByRubles}] в Рубли" +
                     $"\r\n[{MenuTypeByEuros}] в Евро");

            int.TryParse(Console.ReadLine(), out menuNavigatorCurrency);

            switch (menuNavigatorCurrency)
            {
                case MenuTypeByEuros:
                    userWantedMoneyCurrency = dollarCostBuyEuro;
                    break;
                case MenuTypeByRubles:
                    userWantedMoneyCurrency = dollarCostBuyRubles;
                    break;
                default:
                    errorMessageType = MenuErrorComand;
                    break;
            }
            break;

        case MenuEuroSell:
            Console.ForegroundColor = consoleColorName;
            Console.WriteLine($"Выберите в валюту конвертации Евро:");
            Console.ForegroundColor = consoleColorDeafualt;
            Console.WriteLine($"[{MenuTypeByRubles}] в Рубли" +
                        $"\r\n[{MenuTypeByDollars}] в Доллары");

            int.TryParse(Console.ReadLine(), out menuNavigatorCurrency);

            switch (menuNavigatorCurrency)
            {
                case MenuTypeByDollars:
                    userWantedMoneyCurrency = euroCostBuyDollar;
                    break;
                case MenuTypeByRubles:
                    userWantedMoneyCurrency = euroCostBuyRubles;
                    break;
                default:
                    errorMessageType = MenuErrorComand;
                    break;
            }
            break;

        case MenuRublesSell:
            Console.ForegroundColor = consoleColorName;
            Console.WriteLine($"Выберите в валюту конвертации Рублей:");
            Console.ForegroundColor = consoleColorDeafualt;
            Console.WriteLine($"[{MenuTypeByEuros}] в Евро" +
                              $"\r\n[{MenuTypeByDollars}] в Доллары");

            int.TryParse(Console.ReadLine(), out menuNavigatorCurrency);

            switch (menuNavigatorCurrency)
            {
                case MenuTypeByDollars:
                    userWantedMoneyCurrency = rublesCostBuyDollar;
                    break;
                case MenuTypeByEuros:
                    userWantedMoneyCurrency = rublesCostBuyEuro;
                    break;
                default:
                    errorMessageType = MenuErrorComand;
                    break;
            }
            break;

        case MenuExit:
                isWorking = false;
                break;  
            
        default:
                errorMessageType = MenuErrorComand;
                break;  
            
    }

    if (errorMessageType == MenuErrorMessageEmpty && isWorking)
    {
        Console.WriteLine(messageEnterCount);
        Console.ForegroundColor = consoleColorAgree;

        float.TryParse(Console.ReadLine(), out userWantedMoneyCount);

        templeCalculation = userWantedMoneyCount * userWantedMoneyCurrency;

        if (userWantedMoneyCount > 0)
        {
            switch (menuNavigatorType)
            {
                case MenuDollarSell:
                    preCalculation = userDollars - userWantedMoneyCount;
                    if (preCalculation >= 0)
                    {
                        userDollars = preCalculation;
                        if (menuNavigatorCurrency == MenuTypeByEuros)
                            userEuros += templeCalculation;

                        else if (menuNavigatorCurrency == MenuTypeByRubles)
                            userRubles += templeCalculation;
                    }
                    else
                        errorMessageType = MenuErrorSell;
                    break;

                case MenuEuroSell:
                    preCalculation = userEuros - userWantedMoneyCount;
                    if (preCalculation >= 0)
                    {
                        userEuros = preCalculation;
                        if (menuNavigatorCurrency == MenuTypeByDollars)
                            userDollars += templeCalculation;

                        else if (menuNavigatorCurrency == MenuTypeByRubles)
                            userRubles += templeCalculation;
                    }
                    else
                        errorMessageType = MenuErrorSell;
                    break;

                case MenuRublesSell:
                    preCalculation = userRubles - userWantedMoneyCount;
                    if (preCalculation >= 0)
                    {
                        userRubles = preCalculation;
                        if (menuNavigatorCurrency == MenuTypeByDollars)
                            userDollars += templeCalculation;

                        else if (menuNavigatorCurrency == MenuTypeByEuros)
                            userEuros += templeCalculation;
                    }
                    else                    
                        errorMessageType = MenuErrorSell;                    
                    break;
            }
        }
    }

    if (errorMessageType > MenuErrorMessageEmpty)
    {
        Console.ForegroundColor = consoleColorAlert;
        switch (errorMessageType)
        {
            case MenuErrorSell:
                messageShowing = messageNoEnoughMoneySell;
                break;
            case MenuErrorComand:
                messageShowing = messageErrorMenu;
                break;
        }
        Console.WriteLine(messageShowing);
    }
}
