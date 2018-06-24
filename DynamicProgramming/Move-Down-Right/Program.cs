using System;
using System.Collections.Generic;
using System.Linq;

namespace Move_Down_Right
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static int[,] matrix;
        private static int[,] values;
        static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            matrix = new int[rows, cols];
            values = new int[rows, cols];
            FillMatrix();
            CalculateRowsAndCols(rows, cols);
            List<int[]> coords = Traverse(rows - 1, cols - 1).ToList();
            PrintCoordinates(coords);
        }

        private static void FillMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }
        }

        private static void PrintCoordinates(List<int[]> coords)
        {
            for (int i = 0; i < coords.Count; i++)
            {
                int[] pair = coords[i];
                Console.Write($"[{pair[0]}, {pair[1]}] ");
            }
        }

        private static IEnumerable<int[]> Traverse(int row, int col)
        {
            Stack<int[]> coordinates = new Stack<int[]>();
            while (row != 0 || col != 0)
            {
                coordinates.Push(new[] { row, col });
                int left = Left(row, col);
                int up = Up(row, col);
                if (up > left)
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
            while (coordinates.Count > 0)
            {
                yield return coordinates.Pop();
            }
        }

        private static int Up(int row, int col)
        {
            int up = row - 1;
            if (up < 0)
            {
                return up;
            }
            return values[up, col];
        }

        private static int Left(int row, int col)
        {
            int left = col - 1;
            if (left < 0)
            {
                return left;
            }
            return values[row, left];
        }

        private static void CalculateRowsAndCols(int rows, int cols)
        {
            values[0, 0] = matrix[0, 0];
            for (int i = 1; i < cols; i++)
            {
                values[0, i] = values[0, i - 1] + matrix[0, i];
            }
            for (int i = 1; i < rows; i++)
            {
                values[i, 0] = values[i - 1, 0] + matrix[i, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    values[row, col] = Math.Max(values[row - 1, col], values[row, col - 1]) + matrix[row, col];
                }
            }
        }
    }
}
