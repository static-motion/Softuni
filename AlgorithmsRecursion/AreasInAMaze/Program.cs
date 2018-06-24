using System;
using System.Collections.Generic;

namespace AreasInAMaze
{
    class Program
    {
        private static int nextArea = 1;
        private static SortedSet<Area> foundAreas = new SortedSet<Area>();

        private static char[,] maze;

        static void Main()
        {
            ReadMaze();
            DiscoverAreas();
            PrintAreas();
        }

        private static void ReadMaze()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            maze = new char[rows, cols];
            char[] line;
            for (int i = 0; i < rows; i++)
            {
                line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    maze[i, j] = line[j];
                }
            }
        }

        private static void PrintAreas()
        {
            Console.WriteLine("Total areas found: {0}", foundAreas.Count);
            int areanum = 1;
            foreach (var area in foundAreas)
            {
                Console.WriteLine(area.ToString(areanum));
                areanum++;
            }
        }

        private static void DiscoverAreas()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == ' ')
                    {
                        Area area = new Area(nextArea, i, j);
                        MarkArea(i, j, area);
                        nextArea++;
                        foundAreas.Add(area);
                    }
                }
            }
        }

        private static void MarkArea(int row, int col, Area area)
        {
            if (row < 0 || row >= maze.GetLength(0) || col < 0 || col >= maze.GetLength(1))
            {
                return;
            }

            if (maze[row, col] == '*' || maze[row, col] == '^')
            {
                return;
            }

            maze[row, col] = '^';
            area.Size++;

            MarkArea(row, col + 1, area);
            MarkArea(row - 1, col, area);
            MarkArea(row, col - 1, area);
            MarkArea(row + 1, col, area);
        }
    }
}
