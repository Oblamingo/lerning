
string firstName = "Пушкин";
string secondName = "Александр";

Console.WriteLine($"Имя {firstName} Фамилия {secondName}");

string temp = firstName;
firstName = secondName;
secondName = temp;

Console.WriteLine($"Имя {firstName} Фамилия {secondName}");
