Console.WriteLine($"Сколько у Вас монет?");
int.TryParse(Console.ReadLine(), out int playerCoins);

int crystalPrice = 3;

Console.WriteLine($"Цена кристала {crystalPrice}\r\nСколько купить кристаллов?");
int.TryParse(Console.ReadLine(), out int crystals);

playerCoins -= crystals * crystalPrice;

Console.WriteLine($"В инвентаре {crystals} кристаллов, {playerCoins} монет");
