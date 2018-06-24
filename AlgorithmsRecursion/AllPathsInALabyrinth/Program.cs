using System;
using System.Collections.Generic;
x
namespace AllPathsInALabyrinth
{
    class Program
    {
        private static char[,] labyrinth;
        private static int rows;
        private static int cols;
        private static List<char> paths = new List<char>();
        static void Main()
        {
            ReadLabyrinth();
            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (IsOutsideOfMap(row, col))
            {
                return;
            }
            paths.Add(direction);
            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if(IsNotVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row - 1, col, 'U');
                FindPaths(row, col - 1, 'L');
                FindPaths(row + 1, col, 'D');
                Unmark(row, col);
            }
            paths.RemoveAt(paths.Count - 1);
        }

        private static void Unmark(int row, int col)
        {
            labyrinth[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            labyrinth[row, col] = 'v';
        }

        private static bool IsNotVisited(int row, int col)
        {
            return labyrinth[row, col] != 'v';
        }

        private static bool IsFree(int row, int col)
        {
            return labyrinth[row, col] != '*';
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", paths.GetRange(1, paths.Count - 1)));
        }

        private static bool IsOutsideOfMap(int row, int col)
        {
            return row < 0 || row > rows - 1 || col < 0 || col > cols - 1;
        }
        

        private static void ReadLabyrinth()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            char[] line;
            labyrinth = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = line[col];
                }
            }
        }
    }
}
