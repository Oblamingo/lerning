Console.WriteLine("Введите кол-во людей в очереди:");
int.TryParse(Console.ReadLine(), out int peopleCount);

int timeForOnePerson = 10;
int timeDivider = 60;

int fullTimeMinutes = peopleCount * timeForOnePerson;
int hoursWait = fullTimeMinutes / timeDivider;
int minutesWait = fullTimeMinutes % timeDivider;

Console.WriteLine($"В очереди {peopleCount} человек, ваше время ожидания {hoursWait}ч. {minutesWait}мин.");
