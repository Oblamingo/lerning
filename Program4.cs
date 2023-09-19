string firstName = "Пушкин";
string secondName = "Александр";

Console.WriteLine($"Имя {firstName} Фамилия {secondName}");

string tempString = firstName;
firstName = secondName;
secondName = tempString;

Console.WriteLine($"Имя {firstName} Фамилия {secondName}");
