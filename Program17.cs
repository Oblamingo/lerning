Console.Title = $"two two";

int maxNumber = 1000;
int findNumber = 1;
int startNumber = 2;
int degree = 0;

Random random = new Random();

int randomNumber = random.Next(maxNumber);

while (findNumber <= randomNumber)
{    
    findNumber *= startNumber;
    degree++;
}

Console.WriteLine($"{startNumber} в степени {degree} равное {findNumber} больше случайного {randomNumber}");
