using System;
using System.Linq;

namespace Zig_Zag_Matrix
{
    class Program
    {
        private static int[][] matrix; 
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new int[rows][];
            int[,] maxPaths = new int[rows, cols];
            int[,] previousRowIndex = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            for (int row = 1; row < rows; row++)
            {
                maxPaths[row, 0] = matrix[row][0];
            }
            for (int col = 1; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    maxPaths[row, col] = matrix[row][col];
                }
            }
            int previousMax = 0;

        }
    }
}
