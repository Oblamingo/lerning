Console.WriteLine("Введите кол-во людей в очереди:");
int.TryParse(Console.ReadLine(), out int peopleCount);

int timeForOnePerson = 10;
int minutesInHour = 60;

int fullTimeMinutesWaitingInLine = peopleCount * timeForOnePerson;
int hoursWaitingInLine = fullTimeMinutesWaitingInLine / minutesInHour;
int minutesWaitingInLine = fullTimeMinutesWaitingInLine % minutesInHour;

Console.WriteLine($"В очереди {peopleCount} человек, ваше время ожидания {hoursWaitingInLine}ч. {minutesWaitingInLine}мин.");
