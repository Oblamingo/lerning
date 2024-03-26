using System;
using System.Collections.Generic;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database dataBase = new Database();

            dataBase.Work();
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

    public class Database
    {
        List<Player> _players = new List<Player>();

        public void Work()
        {
            bool _isWork = true;

            MenuComand _menuComand;

            while (_isWork)
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
                        PlayerBanner(true);
                        break;

                    case MenuComand.UnbanPlayer:
                        PlayerBanner(false);
                        break;

                    case MenuComand.RemovePlayer:
                        RemovePlayer();
                        break;

                    case MenuComand.Exit:
                        _isWork = IsExit();
                        break;

                    default:
                        Console.WriteLine("Не верная команда");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();
            }
        }

        public bool IsExit()
        {
            bool result = true;

            string _positiveAnswer = "Q";
            string _inputExitUser = string.Empty;

            Console.WriteLine($"\nВыйти? Нажмите {_positiveAnswer}/{_positiveAnswer.ToLower()}");

            _inputExitUser = Console.ReadLine().ToLower();

            if (_inputExitUser == _positiveAnswer)
            {
                result = false;
            }

            return result;
        }

        public void ShowPlayers()
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

        public void AddPlayer()
        {
            string _playerName = string.Empty;

            int _playerLevel = 0;

            Console.WriteLine("Введите имя игрока:");

            _playerName = Console.ReadLine();

            Console.WriteLine("Введите уровень игрока:");

            _playerLevel = GetUserInput();

            if (_playerLevel > 0 && string.IsNullOrEmpty(_playerName) == false)
            {
                _players.Add(new Player(_playerName, _playerLevel));
            }
            else
            {
                Console.WriteLine("Неккоректный ввод");
            }
        }

        public void PlayerBanner(bool isBan)
        {
            Player player = FindPlayer();

            if (player != null)
            {
                player.Banned = isBan;

                Console.WriteLine("Успешно");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        public void RemovePlayer()
        {
            Player player = FindPlayer();

            if (player != null)
            {
                _players.Remove(player);

                Console.WriteLine("Успешно");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }

        private Player FindPlayer()
        {
            int _index = 0;

            Player player = null;

            if (_players.Count > 0)
            {
                Console.WriteLine($"Введите ID игрока");

                _index = GetUserInput();

                if (_index > 0)
                {
                    for (int i = 0; i < _players.Count; i++)
                    {
                        if (_players[i].UniqueId == _index)
                        {
                            player = _players[i];
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

            return player;
        }

        private int GetUserInput()
        {
            int _result = 0;

            int.TryParse(Console.ReadLine(), out _result);

            return _result;
        }
    }

    public class Player
    {
        private static int _id = 1;

        private string _name;

        private int _level;

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            UniqueId = _id++;
        }

        public void ShowInfo()
        {
            string isBanned = Banned ? "ДА" : "НЕТ";

            Console.WriteLine($"ID {UniqueId} Имя {_name} уровень {_level} забанен {isBanned}");
        }

        public bool Banned { get; set; }
        public int UniqueId { get; private set; }
    }
}
