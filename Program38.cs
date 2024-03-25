using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player firstPlayer = new Player("Вася",23,156, Characters.Bard, "Песня" );
            Player secondPlayer = new Player("Коля",35,170, Characters.Warrior, "Ярость" );

            firstPlayer.ShowPlayer();
            secondPlayer.ShowPlayer();

            Console.ReadKey();
        }      
    }

   enum Characters
    {
        Bard,
        Warrior,
        Mage
    }

    class Player
    {
        private string _name;
        private int _age;
        private int _height;
        private Characters _character;
        private string _skill;

        public Player(string name, int age, int height, Characters character, string skill)
        {
            _name = name;
            _age = age;
            _height = height;
            _character = character;
            _skill = skill;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"Имя:{_name}\n" +
                              $"Возраст:{_age}\n" +
                              $"Рост:{_height}\n" +
                              $"Персонаж:{_character}\n" +
                              $"Навык:{_skill}\n");
        }
    }
}
