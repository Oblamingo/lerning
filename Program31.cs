using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char MenuAddProfile = '1';
            const char MenuShowAllProfile = '2';
            const char MenuDeleteProfile = '3';
            const char MenuFindUser = '4';
            const char MenuExit = '5';

            bool isWork = true;

            ConsoleKeyInfo chooseMenu;

            string[] stuffProfiles = new string[0];
            string[] stuffPost = new string[0];

            stuffProfiles = CreateNewElementOfArray($"Имен Фамилий Отцович", stuffProfiles);
            stuffPost = CreateNewElementOfArray("Уборщик", stuffPost);

            stuffProfiles = CreateNewElementOfArray("Иван Иванов Иванович", stuffProfiles);
            stuffPost = CreateNewElementOfArray("Креативный Дизайнер", stuffPost);

            stuffProfiles = CreateNewElementOfArray("Сергей Суровов Ульянович", stuffProfiles);
            stuffPost = CreateNewElementOfArray("Охранник", stuffPost);

            stuffProfiles = CreateNewElementOfArray("Сергей Иванов Сергеевич", stuffProfiles);
            stuffPost = CreateNewElementOfArray("Админ", stuffPost);

            while (isWork)
            {
                Console.WriteLine($"{MenuAddProfile}) добавить досье\n" +
                                  $"{MenuShowAllProfile}) вывести все досье\n" +
                                  $"{MenuDeleteProfile}) удалить досье\n" +
                                  $"{MenuFindUser}) поиск по фамилии\n" +
                                  $"{MenuExit}) выход\n");

                chooseMenu = Console.ReadKey();

                switch (chooseMenu.KeyChar)
                {
                    case MenuAddProfile:
                        InputNewDossier(ref stuffProfiles, ref stuffPost);
                        break;
                    case MenuShowAllProfile:
                        ShowAllDossies(stuffProfiles, stuffPost);
                        break;
                    case MenuDeleteProfile:
                        DeleteOneDossier(ref stuffProfiles, ref stuffPost);
                        break;
                    case MenuFindUser:
                        FindSomeDossier(stuffProfiles, stuffPost);
                        break;
                    case MenuExit:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Не верный ввод. Нажмите любую клавишу . . .");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }

        private static void FindSomeDossier(string[] stuffProfiles, string[] stuffPost)
        {
            string codeExit = "quit";
            string userInput = string.Empty;
            string surName = string.Empty;
            string outputFounds = string.Empty;

            int limitLength = 2;
            int notFound = -1;

            Console.Clear();
            Console.WriteLine($"Вы в меню поиска досье по фамилии.");

            while (userInput != codeExit)
            {
                Console.WriteLine();
                Console.WriteLine($"Пожалуста введите Фамилию(Для выхода {codeExit}):");

                userInput = Console.ReadLine().ToLower();

                if (userInput != codeExit && userInput.Length >= limitLength)
                {
                    for (int i = 0; i < stuffProfiles.Length; i++)
                    {
                        surName = GetSecondName(stuffProfiles[i]).ToLower();

                        if (surName.IndexOf(userInput) != notFound)
                        {
                            Console.WriteLine(stuffProfiles[i]);
                        }
                    }

                    outputFounds = string.Empty;
                }
            }
        }

        private static string GetSecondName(string stuffProfiles)
        {
            char splitChar = ' ';

            int surNamePos = 1;

            string[] userProfile = new string[3];

            userProfile = stuffProfiles.Split(splitChar);

            return userProfile[surNamePos];
        }

        private static void DeleteOneDossier(ref string[] stuffProfiles, ref string[] stuffPost)
        {
            int userInputDelete = 0;

            Console.Clear();
            Console.WriteLine("Вы в меню удаления досье.\nПожалуйста укажеите номер пользователя для удаления.");

            ShowAllDossies(stuffProfiles, stuffPost, true);

            if (int.TryParse(Console.ReadLine(), out userInputDelete))
            {
                if (userInputDelete != 0)
                {
                    userInputDelete--;

                    stuffProfiles = DeleteOneElement(stuffProfiles, userInputDelete);
                    stuffPost = DeleteOneElement(stuffPost, userInputDelete);

                    Console.Beep();
                }
            }

            ShowAllDossies(stuffProfiles, stuffPost, true);

            WaitForKey();
        }

        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        private static string[] DeleteOneElement(string[] currentArray, int deletedElement)
        {
            int numeric = 0;

            string[] saveArray = new string[currentArray.Length - 1];

            for (int i = 0; i < currentArray.Length; i++)
            {
                if (i != deletedElement)
                {
                    saveArray[numeric] = currentArray[i];
                    numeric++;
                }
            }

            return saveArray;
        }

        private static void ShowAllDossies(string[] stuffProfiles, string[] stuffPost, bool goThrough = false)
        {
            string fullDocier = string.Empty;

            char whiteSpaceChar = ' ';
            char replaceChar = '-';

            Console.WriteLine();

            for (int i = 0; i < stuffProfiles.Length; i++)
            {
                fullDocier = stuffProfiles[i] + whiteSpaceChar + stuffPost[i];
                fullDocier = $"{i + 1})"+ fullDocier.Replace(whiteSpaceChar, replaceChar);

                Console.WriteLine($"{fullDocier}");
            }

            if (goThrough == false)
            {
                WaitForKey();
            }
        }

        private static void InputNewDossier(ref string[] stuffProfiles, ref string[] stuffPost)
        {
            string newName = string.Empty;
            string newSurName = string.Empty;
            string newFatherName = string.Empty;
            string newPost = string.Empty;

            Console.Clear();
            Console.WriteLine("Вы в меню ввода нового досье.\nПожалуста введите требуемые данные.");
            Console.Write("Имя:");

            newName = Console.ReadLine();

            Console.Write("Фамилия:");

            newSurName = Console.ReadLine();

            Console.Write("Отчество:");

            newFatherName = Console.ReadLine();

            Console.Write("Должность:");

            newPost = Console.ReadLine();

            stuffPost = CreateNewElementOfArray(newPost, stuffPost);
            stuffProfiles = CreateNewElementOfArray($"{newName} {newSurName} {newFatherName}", stuffProfiles);

            Console.WriteLine("Пользователь успешно добавлен.");

            WaitForKey();
        }

        private static string[] CreateNewElementOfArray(string newElement, string[] currentArray)
        {
            string[] tempArray = new string[currentArray.Length + 1];

            for (int i = 0; i < currentArray.Length; i++)
            {
                tempArray[i] = currentArray[i];
            }

            tempArray[tempArray.Length - 1] = newElement;

            return tempArray;
        }
    }
}
