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

            int sizeArray = 0;

            bool isWork = true;

            ConsoleKeyInfo chooseMenu;

            string[] stuffProfiles = new string[sizeArray];
            string[] stuffPost = new string[sizeArray];

            CreateProfileAndPost("Имен", "Фамилий", "Отцович", "Уборщик", ref stuffProfiles, ref stuffPost);
            CreateProfileAndPost("Иван", "Иванов", "Иванович", "Креативный Дизайнер", ref stuffProfiles, ref stuffPost);
            CreateProfileAndPost("Сергей", "Суровов", "Ульянович", "Охранник", ref stuffProfiles, ref stuffPost);
            CreateProfileAndPost("Сергей", "Иванов", "Сергеевич", "Админ", ref stuffProfiles, ref stuffPost);

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
                        InputNewProfileAndPost(ref stuffProfiles, ref stuffPost);
                        break;
                    case MenuShowAllProfile:
                        ShowAllProfilesAndPost(stuffProfiles, stuffPost);
                        break;
                    case MenuDeleteProfile:
                        DeleteSomeProfile(ref stuffProfiles, ref stuffPost);
                        break;
                    case MenuFindUser:
                        FindSomeUser(stuffProfiles, stuffPost);
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

        private static void FindSomeUser(string[] stuffProfiles, string[] stuffPost)
        {
            string codeExit = "quit";
            string userInput = string.Empty;
            string surName = string.Empty;
            string outputFounds= string.Empty;

            int outputFoundCount = 0;
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
                            outputFoundCount++;
                            outputFounds = $"{outputFoundCount})";
                            outputFounds += GenerateFullNameAndPost(stuffProfiles[i], stuffPost[i]);
                            
                            Console.WriteLine(outputFounds);                            
                        }
                    }

                    outputFoundCount = 0;
                    outputFounds=string.Empty;
                }
            }
        }

        private static string GetSecondName(string stuffProfiles)
        {
            char splitChar = ' ';

            int surNameArrayPos = 1;

            string[] userProfile = new string[3];

            userProfile = stuffProfiles.Split(new char[] { splitChar });

            return userProfile[surNameArrayPos];
        }

        private static void DeleteSomeProfile(ref string[] stuffProfiles, ref string[] stuffPost)
        {
            int userInputDelete = 0;

            Console.Clear();
            Console.WriteLine("Вы в меню удаления досье.\nПожалуйста укажеите номер пользователя для удаления.");

            ShowAllProfilesAndPost(stuffProfiles, stuffPost, true);

            if (int.TryParse(Console.ReadLine(), out userInputDelete))
            {
                if (userInputDelete != 0)
                {
                    userInputDelete--;

                    DeleteUser(userInputDelete, ref stuffProfiles, ref stuffPost);

                    Console.Beep();
                }
            }

            ShowAllProfilesAndPost(stuffProfiles, stuffPost, true);

            WaitForKey();
        }

        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        private static void DeleteUser(int number, ref string[] stuffProfiles, ref string[] stuffPost)
        {
            int newLengthArray = stuffProfiles.Length - 1;
            int numeric = 0;

            string[] saveStuffProfiles = new string[newLengthArray];
            string[] saveStuffPost = new string[newLengthArray];

            for (int i = 0; i < stuffProfiles.Length; i++)
            {
                if (i != number)
                {
                    saveStuffProfiles[numeric] = stuffProfiles[i];
                    saveStuffPost[numeric] = stuffPost[i];
                    numeric++;
                }
            }

            stuffProfiles = saveStuffProfiles;
            stuffPost = saveStuffPost;
        }

        private static void ShowAllProfilesAndPost(string[] stuffProfiles, string[] stuffPost, bool goThrough = false)
        {
            string fullNameAndPost = string.Empty;

            Console.WriteLine();

            for (int i = 0; i < stuffProfiles.Length; i++)
            {
                fullNameAndPost = $"{i + 1})";
                fullNameAndPost += GenerateFullNameAndPost(stuffProfiles[i], stuffPost[i]);

                Console.WriteLine($"{fullNameAndPost}");
            }

            if (goThrough == false)
            {
                WaitForKey();
            }
        }

        private static string GenerateFullNameAndPost(string nameWithSpaces, string postWithSpaces)
        {
            string fullNamePost = string.Empty;
            char whiteSpaceChar = ' ';
            char replaceChar = '-';

            fullNamePost = nameWithSpaces + whiteSpaceChar + postWithSpaces;
            fullNamePost = fullNamePost.Replace(whiteSpaceChar, replaceChar);

            return fullNamePost;
        }

        private static void InputNewProfileAndPost(ref string[] stuffProfiles, ref string[] stuffPost)
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

            CreateProfileAndPost(newName, newSurName, newFatherName, newPost, ref stuffProfiles, ref stuffPost);

            Console.WriteLine("Пользователь успешно добавлен.");

            WaitForKey();
        }

        private static void CreateProfileAndPost(string name, string secondName, string fatherName, string post, ref string[] stuffProfiles, ref string[] stuffPost)
        {
            int newLengthArray = stuffProfiles.Length + 1;

            string[] tempStuffProfiles = new string[newLengthArray];
            string[] tempStuffPost = new string[newLengthArray];

            for (int i = 0; i < stuffProfiles.Length; i++)
            {
                tempStuffProfiles[i] = stuffProfiles[i];
                tempStuffPost[i] = stuffPost[i];
            }

            tempStuffProfiles[newLengthArray - 1] = $"{name} {secondName} {fatherName}";
            tempStuffPost[newLengthArray - 1] = $"{post}";

            stuffProfiles = tempStuffProfiles;
            stuffPost = tempStuffPost;
        }
    }
}
