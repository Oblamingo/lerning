using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char MenuAddProfile = '1';
            const char MenuShowAllProfile = '2';
            const char MenuDeleteProfile = '3';
            const char MenuExit = '4';

            ConsoleKeyInfo chooseMenu;

            bool isWork = true;

            Dictionary<int,string> stuffProfiles = new Dictionary<int,string>();

            stuffProfiles.Add(1,"Имен Фамилий Отцович Уборщик");
            stuffProfiles.Add(2,"Иван Иванов Иванович Креативный Дизайнер");
            stuffProfiles.Add(3,"Сергей Суровов Ульянович Охранник");
            stuffProfiles.Add(4,"Сергей Иванов Сергеевич Админ");

            while (isWork)
            {
                Console.WriteLine($"{MenuAddProfile}) добавить досье\n" +
                                  $"{MenuShowAllProfile}) вывести все досье\n" +
                                  $"{MenuDeleteProfile}) удалить досье\n" +
                                  $"{MenuExit}) выход\n");

                chooseMenu = Console.ReadKey();

                switch (chooseMenu.KeyChar)
                {
                    case MenuAddProfile:
                        InputNewDossier(stuffProfiles);
                        break;

                    case MenuShowAllProfile:
                        ShowAllDossies(stuffProfiles);
                        break;

                    case MenuDeleteProfile:
                        DeleteOneDossier(stuffProfiles);
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

        private static void DeleteOneDossier(Dictionary<int, string> stuffProfiles)
        {
            int userInputDelete = 0;

            string tempValue = string.Empty;

            Console.Clear();
            Console.WriteLine("Вы в меню удаления досье.\nПожалуйста укажеите номер пользователя для удаления.");

            ShowAllDossies(stuffProfiles, true);

            if (int.TryParse(Console.ReadLine(), out userInputDelete))
            {
                if (userInputDelete != 0)
                {
                    if (stuffProfiles.TryGetValue(userInputDelete, out tempValue))
                    {
                        stuffProfiles.Remove(userInputDelete);
                    }
                    else
                    {
                        Console.WriteLine($"В словаре нет значения соответствующего ключу {userInputDelete}");
                    }

                    Console.Beep();
                }
            }

            ShowAllDossies(stuffProfiles, true);

            WaitForKey();
        }

        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        private static void ShowAllDossies(Dictionary<int, string> stuffProfiles, bool goThrough = false)
        {
            string fullDocier = string.Empty;

            char whiteSpaceChar = ' ';
            char replaceChar = '-';

            Console.WriteLine();

            foreach(KeyValuePair<int, string> dossie in stuffProfiles)
            {
                fullDocier = dossie.Value;
                fullDocier = fullDocier.Replace(whiteSpaceChar, replaceChar);
                fullDocier = $"{dossie.Key}){fullDocier}";

                Console.WriteLine(fullDocier);
            }

            if (goThrough == false)
            {
                WaitForKey();
            }
        }

        private static void InputNewDossier(Dictionary<int,string> stuffProfiles)
        {
            string newName = string.Empty;
            string newSurName = string.Empty;
            string newFatherName = string.Empty;
            string newPost = string.Empty;

            int newPosition = stuffProfiles.Keys.Count + 1;

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

            stuffProfiles.Add(newPosition, $"{newName} {newSurName} {newFatherName} {newPost}");

            Console.WriteLine("Пользователь успешно добавлен.");

            WaitForKey();
        }
    }
}
