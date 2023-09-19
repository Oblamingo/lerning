Console.WriteLine("Здраствуйте!\r\nВведите Ваше имя пожалуйста:");
string name = Console.ReadLine();
Console.WriteLine("Подскажите, сколько Вам полных лет:");
string old = Console.ReadLine();
Console.WriteLine("Пожалуйста, укажите знак зодиака:");
string typeMonth = Console.ReadLine();
Console.WriteLine("Расскажите, где вы работаете:");
string workPlace = Console.ReadLine();
Console.WriteLine($"Вас зовут {name}, Вам {old} год, Вы {typeMonth} и работаете {workPlace}.");
