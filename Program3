int countPic = 52;

//start FOR SELF
    Console.WriteLine("Введите сколько у пользовтаеля картинок:");
    var readStr = Console.ReadLine();
    bool countPics= int.TryParse(readStr, out countPic);
    if (!countPics)
    {
        Console.WriteLine("Вы ввели не число. Используем стандартное - 52");
        countPic = 52;
    }
//end FOR SELF

int fullLines = countPic / 3;
int shortLine = countPic % 3;
string allPicsMessage, fullPicsMessage, shortPicsMessage;

allPicsMessage = $"У пользователя всего {countPic} картинки";
fullPicsMessage = $"\r\nИз них можно состявить {fullLines} рядов";
shortPicsMessage = shortLine == 0 ? "" : $"\r\nНе полный ряд состоит из {shortLine} картинок";

Console.WriteLine(allPicsMessage + fullPicsMessage + shortPicsMessage);
