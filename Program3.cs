int countPic = 52;
int fullLines = countPic / 3;
int shortLine = countPic % 3;

Console.WriteLine($"У пользователя всего {countPic} картинки" + 
                  $"\r\nИз них можно состявить {fullLines} рядов" +
                  $"\r\nНе полный ряд состоит из {shortLine} картинок");
