Console.WriteLine("Здраствуйте!\r\nВведите Ваше имя пожалуйста:");
string userName = Console.ReadLine();

Console.WriteLine("Подскажите, сколько Вам полных лет:");
string  userAge = Console.ReadLine();

Console.WriteLine("Пожалуйста, укажите знак зодиака:");
string userSignType = Console.ReadLine();

Console.WriteLine("Расскажите, где вы работаете:");
string userWorkPlace = Console.ReadLine();

Console.WriteLine($"Вас зовут {name}, Вам {old} год, Вы {typeMonth} и работаете {workPlace}.");
