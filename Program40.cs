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

    enum PlayerMethods
    {
        remove,
        ban,
        unban
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
                        ChooseMethod(PlayerMethods.ban);
                        break;

                    case MenuComand.UnbanPlayer:
                        ChooseMethod(PlayerMethods.unban);
                        break;

                    case MenuComand.RemovePlayer:
                        ChooseMethod(PlayerMethods.remove);
                        break;

                    case MenuComand.Exit:
                        isWork = IsExit();
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

            string positiveAnswer = "Q";
            string inputExitUser = string.Empty;

            Console.WriteLine($"\nВыйти? Нажмите {positiveAnswer}/{positiveAnswer.ToLower()}");

            inputExitUser = Console.ReadLine().ToLower();

            if (inputExitUser == positiveAnswer)
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

        public void ChooseMethod(Enum method)
        {
            Player player = null;

            if (TryGetPlayer(out player))
            {
                switch(method)
                {
                    case PlayerMethods.remove:
                        _players.Remove(player);
                        break;

                    case PlayerMethods.ban:
                        player.SetBanStatus(true);
                        break;       
                        
                    case PlayerMethods.unban:
                        player.SetBanStatus(false);
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

                            result = true;
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

        private bool _banned;

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            UniqueId = s_id++;
        }

        public int UniqueId { get; private set; }

        public void SetBanStatus(bool isBan)
        {
            _banned = isBan;
        }

        public void ShowInfo()
        {
            string isBanned = _banned ? "ДА" : "НЕТ";

            Console.WriteLine($"ID {UniqueId} Имя {_name} уровень {_level} забанен {isBanned}");
        }
    }
}
