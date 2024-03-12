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

            int userX = 1;
            int userY = 1;

            bool isWork = true;

            Console.CursorVisible = false;

            GenerateRandomExitPosition(ref map, emptyChar, exitChar);

            while (isWork)
            {
                Console.Clear();

                DrawMap(map);

                Console.SetCursorPosition(userX, userY);
                Console.Write(userChar);
                
                GetNewPositionPlayer(wallChar,ref userX,ref userY, map);

                isWork = CheckExitPosition(userX, userY, map, exitChar);                
            }
        }

        private static bool CheckExitPosition(int userX, int userY, char[,] map, char exit)
        {
            bool isWork = true;

            if (map[userY, userX] == exit)
            {
                isWork = false;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("U WIN!");
                Console.ReadKey();
            }

            return isWork;
        }

        private static void GenerateRandomExitPosition(ref char[,]map,char emptySpace, char exitChar)
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

        private static void GetNewPositionPlayer(char wallChar,ref int userX,ref int userY, char[,] map)
        {
            int newUserPositionX;
            int newUserPositionY;

            int[] direction = GetDirection();

            newUserPositionX = userX + direction[0];
            newUserPositionY = userY + direction[1];

            if (map[newUserPositionY,newUserPositionX] != wallChar)
            {
                userX = newUserPositionX;
                userY = newUserPositionY;
            }
        }

        private static int[] GetDirection()
        {
            int[] resultDirection = {0,0};

            int X = 0;
            int Y = 1;
            int positiveMove = 1;
            int negativeMove = -1;

            ConsoleKeyInfo consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.UpArrow:
                    resultDirection[Y] = negativeMove;
                    break;

                case ConsoleKey.DownArrow:
                    resultDirection[Y] = positiveMove;
                    break;

                case ConsoleKey.LeftArrow:
                    resultDirection[X] = negativeMove;
                    break;

                case ConsoleKey.RightArrow:
                    resultDirection[X] = positiveMove;
                    break;
            }

            return resultDirection;
        }
    }
}
