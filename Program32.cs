using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map ={
                            {'#','#','#','#','#','#','#','#','#','#'},
                            {'#',' ','#',' ',' ',' ','#',' ',' ','#'},
                            {'#',' ','#',' ','#',' ',' ',' ','#','#'},
                            {'#',' ','#',' ','#',' ','#',' ',' ','#'},
                            {'#',' ','#',' ',' ',' ',' ','#',' ','#'},
                            {'#',' ','#',' ','#','#','#',' ',' ','#'},
                            {'#',' ','#',' ','#',' ','#',' ',' ','#'},
                            {'#',' ','#',' ',' ',' ',' ',' ','#','#'},
                            {'#',' ',' ',' ','#',' ','#',' ',' ','#'},
                            {'#','#','#','#','#','#','#','#','#','#'}
                            };

            char userChar = '@';
            char exitChar = 'E';
            char emptyChar = ' ';
            char wallChar = '#';

            int userPositionX = 1;
            int userPositionY = 1;

            bool isWork = true;

            Console.CursorVisible = false;

            GenerateRandomExitPosition(ref map, emptyChar, exitChar);

            while (isWork)
            {
                Console.Clear();

                DrawMap(map);

                Console.SetCursorPosition(userPositionX, userPositionY);
                Console.Write(userChar);
                
                GetNewPositionPlayer(wallChar,ref userPositionX,ref userPositionY, map);

                isWork = CheckExitPosition(userPositionX, userPositionY, map, exitChar);                
            }
        }

        private static bool CheckExitPosition(int userPositionX, int userPositionY, char[,] map, char exit)
        {
            bool isWork = true;

            if (map[userPositionY, userPositionX] == exit)
            {
                isWork = false;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("U WIN!");
                Console.ReadKey();
            }

            return isWork;
        }

        private static void GenerateRandomExitPosition(ref char[,]map, char emptySpace, char exitChar)
        {
            Random random = new Random();

            int emptySpaces = 1;
            int userPosition = 1;
            int randomExitPosition = 0;

            bool exitStands = false;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j]== emptySpace)
                        emptySpaces++;
                }
            }

            randomExitPosition = random.Next(userPosition, emptySpaces);
            emptySpaces = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == emptySpace)
                    {
                        emptySpaces++;

                        if(exitStands==false && emptySpaces == randomExitPosition)
                        {
                            exitStands = true;
                            map[i, j] = exitChar;
                        }
                    }
                }
            }
        }

        private static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void GetNewPositionPlayer(char wallChar,ref int userPositionX,ref int userPositionY, char[,] map)
        {
            int newUserPositionX;
            int newUserPositionY;

            int[] direction = GetDirection();

            newUserPositionX = userPositionX + direction[0];
            newUserPositionY = userPositionY + direction[1];

            if (map[newUserPositionY,newUserPositionX] != wallChar)
            {
                userPositionX = newUserPositionX;
                userPositionY = newUserPositionY;
            }
        }

        private static int[] GetDirection()
        {
            const ConsoleKey MoveUpKey = ConsoleKey.UpArrow;
            const ConsoleKey MoveDownArrow = ConsoleKey.DownArrow;
            const ConsoleKey MoveLeftArrow = ConsoleKey.LeftArrow;
            const ConsoleKey MoveRightArrow = ConsoleKey.RightArrow;

            int[] resultDirection = {0,0};

            int directionX = 0;
            int directionY = 1;
            int positiveMove = 1;
            int negativeMove = -1;

            ConsoleKeyInfo consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case MoveUpKey:
                    resultDirection[directionY] = negativeMove;
                    break;

                case MoveDownArrow:
                    resultDirection[directionY] = positiveMove;
                    break;

                case MoveLeftArrow:
                    resultDirection[directionX] = negativeMove;
                    break;

                case MoveRightArrow:
                    resultDirection[directionX] = positiveMove;
                    break;
            }

            return resultDirection;
        }
    }
}
