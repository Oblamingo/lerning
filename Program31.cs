using System;
using System.Xml.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;

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
            
            CreateNewElementOfArray($"Имен Фамилий Отцович", ref stuffProfiles);
            CreateNewElementOfArray("Уборщик", ref stuffPost);
            CreateNewElementOfArray("Иван Иванов Иванович", ref stuffProfiles);
            CreateNewElementOfArray("Креативный Дизайнер", ref stuffPost);
            CreateNewElementOfArray("Сергей Суровов Ульянович", ref stuffProfiles);
            CreateNewElementOfArray("Охранник", ref stuffPost);
            CreateNewElementOfArray("Сергей Иванов Сергеевич", ref stuffProfiles);
            CreateNewElementOfArray("Админ", ref stuffPost);

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
            string outputFounds= string.Empty;

            int limitLength = 2;
            int notFound = -1;

            Console.Clear();
            Console.WriteLine($"Вы в меню поиска досье по фамилии.");

            while (userInput != codeExit)
            {
                Console.WriteLine();
                Console.WriteLine($"Пожалуста введите Фамилию(Для выхода {codeExit}):");

                userInput = Console.ReadLine().ToLower();

                if (userInput != codeExit && userInput.Length>=limitLength)
                {
                    for (int i = 0; i < stuffProfiles.Length; i++)
                    {
                        surName = GetSecondName(stuffProfiles[i]).ToLower();

                        if(surName.IndexOf(userInput) != notFound)
                        {
                            Console.WriteLine(stuffProfiles[i]);                            
                        }
                    }

                    outputFounds=string.Empty;
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

                    DeleteOneElement(ref stuffProfiles, userInputDelete);
                    DeleteOneElement(ref stuffPost, userInputDelete);

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

        private static void DeleteOneElement(ref string[] currentArray,int deletedElement)
        {
            string[] saveArray = new string[currentArray.Length - 1];
            int numeric = 0;

            for (int i = 0; i < currentArray.Length; i++)
            {
                if (i != deletedElement)
                {
                    saveArray[numeric] = currentArray[i];
                    numeric++;
                }
            }

            currentArray = saveArray;
        }

        private static void ShowAllDossies(string[] stuffProfiles, string[] stuffPost, bool goThrough = false)
        {
            string fullNameAndPost = string.Empty;

            Console.WriteLine();

            for (int i = 0; i < stuffProfiles.Length; i++)
            {
                fullNameAndPost = $"{i + 1})";
                fullNameAndPost += GenerateFullDossier(stuffProfiles[i], stuffPost[i]);

                Console.WriteLine($"{fullNameAndPost}");
            }

            if (goThrough == false)
            {
                WaitForKey();
            }
        }

        private static string GenerateFullDossier(string nameWithSpaces, string postWithSpaces)
        {
            string fullNamePost = string.Empty;

            char whiteSpaceChar = ' ';
            char replaceChar = '-';

            fullNamePost = nameWithSpaces + whiteSpaceChar + postWithSpaces;
            fullNamePost = fullNamePost.Replace(whiteSpaceChar, replaceChar);

            return fullNamePost;
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

            CreateNewElementOfArray(newPost, ref stuffPost);
            CreateNewElementOfArray($"{newName} {newSurName} {newFatherName}", ref stuffProfiles);

            Console.WriteLine("Пользователь успешно добавлен.");

            WaitForKey();
        }

        private static void CreateNewElementOfArray(string newElement,ref string[] currentArray)
        {
            int newLengthArray = currentArray.Length + 1;

            string[] tempArray = new string[newLengthArray];

            for (int i = 0; i < currentArray.Length; i++)
            {
                tempArray[i] = currentArray[i];
            }

            tempArray[tempArray.Length-1] = newElement;
            currentArray = tempArray;
        }
    }
}
