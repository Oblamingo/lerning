int picturesCount = 52;
int lineLength = 3;
int fullLinesCount = picturesCount / lineLength;
int restPictures = picturesCount % lineLength;

Console.WriteLine($"У пользователя всего {picturesCount} картинки" +
                  $"\r\nИз них можно состявить {fullLinesCount} рядов" +
                  $"\r\nНе полный ряд состоит из {restPictures} картинок");
