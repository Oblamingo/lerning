Console.WriteLine("Введите фразу для повтора:");
string reapeatString = Console.ReadLine();

Console.WriteLine("Введите кол-во повторов фразы:");
int.TryParse(Console.ReadLine(), out int repeatCount);

while (repeatCount-- > 0)
    Console.WriteLine(reapeatString);
