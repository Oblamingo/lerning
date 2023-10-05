Console.Title = "CASH MARKET";

const int MenuDollarBuy = 1;
const int MenuEuroBuy = 2;
const int MenuDollarSell = 3;
const int MenuEuroSell = 4;
const int MenuExit= 9;

int menuNavigator = 0;

float dollarCostSell = 35;
float dollarCostBuy = 32;
float euroCostSell = 45;
float euroCostBuy = 41;

float userDollars = 100;
float userEuros = 100;
float userRubles = 1000;

float countUserWantedMoney = 0;

ConsoleColor deafualtConsoleColor = Console.ForegroundColor;
ConsoleColor agreeConsoleColor = ConsoleColor.Green;
ConsoleColor alertConsoleColor = ConsoleColor.Red;

while (menuNavigator!=MenuExit)
{
    Console.Clear();

    Console.ForegroundColor = deafualtConsoleColor;
    Console.Write($"Ваш баланс\r\nДоллар:");

    Console.ForegroundColor = agreeConsoleColor;
    Console.Write($"\t {userDollars}");

    Console.ForegroundColor = deafualtConsoleColor;
    Console.Write($"\r\nЕвро:");

    Console.ForegroundColor = agreeConsoleColor;
    Console.Write($"\t {userEuros}");

    Console.ForegroundColor = deafualtConsoleColor;
    Console.Write($"\r\nРубли:");

    Console.ForegroundColor = agreeConsoleColor;
    Console.Write($"\t {userRubles}");

    Console.ForegroundColor = deafualtConsoleColor;
    Console.Write($"\r\n\nКурс");

    Console.ForegroundColor = alertConsoleColor;
    Console.Write($"\tпокупка ");

    Console.ForegroundColor = agreeConsoleColor;
    Console.Write($"продажа");

    Console.ForegroundColor = deafualtConsoleColor;
    Console.Write($"\r\nДоллар:");
    
    Console.ForegroundColor = alertConsoleColor;
    Console.Write($"\t {dollarCostSell}");
    Console.ForegroundColor = agreeConsoleColor;
    Console.Write($"\t {dollarCostBuy}");

    Console.ForegroundColor = deafualtConsoleColor;
    Console.Write($"\r\nЕвро:");

    Console.ForegroundColor = alertConsoleColor;
    Console.Write($"\t {euroCostSell}");
    Console.ForegroundColor = agreeConsoleColor;
    Console.Write($"\t {euroCostBuy}");

    Console.ForegroundColor = deafualtConsoleColor;
    Console.WriteLine($"\r\n\nВыберите операцию:" +
        $"\r\n[{MenuDollarBuy}] Покупка доллара" +
        $"\r\n[{MenuEuroBuy}] Покупка евро" +
        $"\r\n[{MenuDollarSell}] Продажа доллара" +
        $"\r\n[{MenuEuroSell}] Продажа евро" +
        $"\r\n[{MenuExit}] Выход из программы");

    int.TryParse(Console.ReadLine(), out menuNavigator);

    switch (menuNavigator)
    {
        case MenuDollarBuy:
            {
                Console.ForegroundColor = deafualtConsoleColor;
                Console.WriteLine($"\r\nВведите желаемое кол-во:");

                Console.ForegroundColor = agreeConsoleColor;
                float.TryParse(Console.ReadLine(), out countUserWantedMoney);

                if (countUserWantedMoney > 0 && countUserWantedMoney * dollarCostSell <= userRubles)
                {
                    userRubles-= countUserWantedMoney*dollarCostSell;
                    userDollars += countUserWantedMoney;
                }
                else
                {
                    Console.ForegroundColor = alertConsoleColor;
                    Console.WriteLine($"\r\nНедостатончое кол-во средств для покупки");
                    Console.ReadKey();
                }

                break;
            }
        case MenuEuroBuy:
            {
                Console.ForegroundColor = deafualtConsoleColor;
                Console.WriteLine($"\r\nВведите желаемое кол-во:");

                Console.ForegroundColor = agreeConsoleColor;
                float.TryParse(Console.ReadLine(), out countUserWantedMoney);

                if (countUserWantedMoney > 0 && countUserWantedMoney * euroCostSell <= userRubles)
                {
                    userRubles -= countUserWantedMoney * euroCostSell;
                    userEuros += countUserWantedMoney;
                }
                else
                {
                    Console.ForegroundColor = alertConsoleColor;
                    Console.WriteLine($"\r\nНедостатончое кол-во средств для покупки");
                    Console.ReadKey();
                }
                break;
            }
        case MenuDollarSell:
            {
                Console.ForegroundColor = deafualtConsoleColor;
                Console.WriteLine($"\r\nВведите желаемое кол-во:");

                Console.ForegroundColor = alertConsoleColor;
                float.TryParse(Console.ReadLine(), out countUserWantedMoney);

                if (countUserWantedMoney > 0 && countUserWantedMoney <= userDollars)
                {
                    userRubles += countUserWantedMoney * dollarCostBuy;
                    userDollars -= countUserWantedMoney;
                }
                else
                {
                    Console.ForegroundColor = alertConsoleColor;
                    Console.WriteLine($"\r\nНедостатончое кол-во средств для продажи");
                    Console.ReadKey();
                }
                break;
            }
        case MenuEuroSell:
            {
                Console.ForegroundColor = deafualtConsoleColor;
                Console.WriteLine($"\r\nВведите желаемое кол-во:");

                Console.ForegroundColor = alertConsoleColor;
                float.TryParse(Console.ReadLine(), out countUserWantedMoney);

                if (countUserWantedMoney > 0 && countUserWantedMoney < userEuros)
                {
                    userRubles += countUserWantedMoney * euroCostBuy;
                    userEuros -= countUserWantedMoney;
                }
                else
                {
                    Console.ForegroundColor = alertConsoleColor;
                    Console.WriteLine($"\r\nНедостатончое кол-во средств для продажи");
                    Console.ReadKey();
                }
                break;
            }
        case MenuExit:
            {
                break;
            }
        default:
            {
                Console.ForegroundColor = alertConsoleColor;
                Console.WriteLine($"Вы ввели неверную команду. Возврат в основное меню.");
                Console.ReadKey();
                break;
            }
    }
}
