Console.WriteLine("Здраствуйте!\r\nВведите Ваше имя пожалуйста:");
var name = Console.ReadLine();
Console.WriteLine("Подскажите, сколько Вам полных лет:");
var old = Console.ReadLine();
Console.WriteLine("Пожалуйста, укажите знак зодиака:");
var typeMonth = Console.ReadLine();
Console.WriteLine("Расскажите, где вы работаете:");
var workPlace = Console.ReadLine();
Console.WriteLine($"Вас зовут {name}, Вам {old} год, Вы {typeMonth} и работаете {workPlace}.");
