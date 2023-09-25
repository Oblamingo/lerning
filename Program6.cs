Console.WriteLine("Введите кол-во людей в очереди:");
int.TryParse(Console.ReadLine(), out int countPeople);

int timeForOnePerson = 10;
int timeDivider = 60;

int fullTimeMinutes = countPeople * timeForOnePerson;
int hoursWait = fullTimeMinutes / timeDivider;
int minutesWait = fullTimeMinutes % timeDivider;

Console.WriteLine($"В очереди {countPeople} человек, ваше время ожидания {hoursWait}ч. {minutesWait}мин.");
