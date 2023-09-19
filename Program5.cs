Console.WriteLine($"Сколько у Вас монет?");
int.TryParse(Console.ReadLine(), out int yourCouins);

int crystalPrice = 3;

Console.WriteLine($"Цена кристала {crystalPrice}\r\nСколько купить кристаллов?");
int.TryParse(Console.ReadLine(), out int countItems);

yourCouins -= countItems * crystalPrice;

Console.WriteLine($"В инвентаре {countItems} кристаллов {yourCouins} монет");

