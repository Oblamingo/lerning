string exitWord = "exit";
string enterWord = "";

while (enterWord != exitWord)
{
    Console.WriteLine("Введите фразу для преобразования:");
    enterWord = Console.ReadLine();

    Console.WriteLine($"Вы ввели [{enterWord}]");
}
