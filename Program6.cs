Console.WriteLine("Введите кол-во людей в очереди:");
int.TryParse(Console.ReadLine(), out int countPeople);

int totalMinutes = countPeople * 10;
int hoursWaiting = totalMinutes / 60;
int minutesWaiting = totalMinutes % 60;

Console.WriteLine($"В очереди {countPeople} человек, ваше время ожидания {hoursWaiting}ч. {minutesWaiting}мин.");
