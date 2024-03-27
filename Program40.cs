using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            database.Work();
        }
    }

    enum MenuComand
    {
        AddPlayer = 1,
        OutputPlayers = 2,
        BanPlayer = 3,
        UnbanPlayer = 4,
        RemovePlayer = 5,
        Exit = 6
    }

    enum PlayerMethods
    {
        Remove,
        Ban,
        Unban
    }

    public class Database
    {
        private List<Player> _players = new List<Player>();

        public void Work()
        {
            bool isWork = true;

            MenuComand _menuComand;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"{(int)MenuComand.AddPlayer}) добавить игрока\n" +
                                  $"{(int)MenuComand.OutputPlayers}) вывести игроков\n" +
                                  $"{(int)MenuComand.BanPlayer}) забанить игрока\n" +
                                  $"{(int)MenuComand.UnbanPlayer}) разбанить игрока\n" +
                                  $"{(int)MenuComand.RemovePlayer}) удалить игрока\n" +
                                  $"{(int)MenuComand.Exit}) выход из программы\n");
                Console.WriteLine("Введите номер команды:");

                _menuComand = (MenuComand)GetUserInput();

                switch (_menuComand)
                {
                    case MenuComand.AddPlayer:
                        AddPlayer();
                        break;

                    case MenuComand.OutputPlayers:
                        ShowPlayers();
                        break;

                    case MenuComand.BanPlayer:
                        ChooseMethod(PlayerMethods.Ban);
                        break;

                    case MenuComand.UnbanPlayer:
                        ChooseMethod(PlayerMethods.Unban);
                        break;

                    case MenuComand.RemovePlayer:
                        ChooseMethod(PlayerMethods.Remove);
                        break;

                    case MenuComand.Exit:
                        isWork = IsWork();
                        break;

                    default:
                        Console.WriteLine("Не верная команда");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
            }
        }

        private bool IsWork()
        {
            string positiveAnswer = "q";
            string inputExitUser = string.Empty;

            Console.WriteLine($"\nВыйти? Нажмите {positiveAnswer.ToUpper()}/{positiveAnswer}");

            inputExitUser = Console.ReadLine().ToLower();

            if (inputExitUser == positiveAnswer)
            {
                return false;
            }

            return true;
        }

        private void ShowPlayers()
        {
            Console.WriteLine("\nВывод игроков");

            if (_players.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                }
            }
        }

        private void AddPlayer()
        {
            string playerName = string.Empty;

            int _playerLevel = 0;

            Console.WriteLine("Введите имя игрока:");

            playerName = Console.ReadLine();

            Console.WriteLine("Введите уровень игрока:");

            _playerLevel = GetUserInput();

            if (_playerLevel > 0 && string.IsNullOrEmpty(playerName) == false)
            {
                _players.Add(new Player(playerName, _playerLevel));
            }
            else
            {
                Console.WriteLine("Неккоректный ввод");
            }
        }

        private void ChooseMethod(Enum method)
        {
            Player player = null;

            if (TryGetPlayer(out player))
            {
                switch(method)
                {
                    case PlayerMethods.Remove:
                        _players.Remove(player);
                        break;

                    case PlayerMethods.Ban:
                        player.Ban();
                        break;       
                        
                    case PlayerMethods.Unban:
                        player.UnBan();
                        break;
                }                

                Console.WriteLine("Успешно");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        private bool TryGetPlayer(out Player player)
        {
            int index = 0;

            bool result = false;
            
            player = null;

            if (_players.Count > 0)
            {
                Console.WriteLine($"Введите ID игрока");

                index = GetUserInput();

                if (index > 0)
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        if (_players[i].UniqueId == index)
                        {
                            player = _players[i];

                            return true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Указанный ID не верен");
                }
            }
            else
            {
                Console.WriteLine("Данные не обнаружены");
            }

            return result;
        }

        private int GetUserInput()
        {
            int result = 0;

            int.TryParse(Console.ReadLine(), out result);

            return result;
        }
    }

    public class Player
    {
        private static int s_id = 1;

        private string _name;

        private int _level;

        private bool _isBanned;

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            UniqueId = s_id++;
        }

        public int UniqueId { get; private set; }

        public void Ban()
        {
            _isBanned = true;
        }

        public void UnBan()
        {
            _isBanned = false;
        }

        public void ShowInfo()
        {
            string isBanned = _isBanned ? "ДА" : "НЕТ";

            Console.WriteLine($"ID {UniqueId} Имя {_name} уровень {_level} забанен {isBanned}");
        }
    }
}
