using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int positionX = 10;
            int positionY = 10;

            char characterSymbol = '@';
            
            Player player = new Player(positionX, positionY, characterSymbol);
            Render render = new Render();

            render.DrawCharacter(player);

            Console.ReadKey();
        }      
    }

    class Player
    {
        public Player(int positionX, int positionY, char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }
    }

    class Render
    {
        public void DrawCharacter(Player character)
        {
            Console.SetCursorPosition(character.PositionX, character.PositionY);
            Console.WriteLine(character.Symbol);
        }
    }
}
