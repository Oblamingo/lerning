int countPic = 52;
int lineLength = 3;
int fullLines = countPic / lineLength;
int shortLine = countPic % lineLength;

Console.WriteLine($"У пользователя всего {countPic} картинки" + 
                  $"\r\nИз них можно состявить {fullLines} рядов" +
                  $"\r\nНе полный ряд состоит из {shortLine} картинок");
