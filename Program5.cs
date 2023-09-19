Console.WriteLine($"Сколько у Вас монет?");
int.TryParse(Console.ReadLine(), out int yourCouins);

int cristPrice = 3;

Console.WriteLine($"Сколько купить кристаллов?\r\nЦена кристала {cristPrice}");
int.TryParse(Console.ReadLine(), out int countItems);

yourCouins -= countItems*cristPrice;

Console.WriteLine($"В инвентаре {countItems} кристаллов {yourCouins} монет");
