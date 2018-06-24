using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Stability_Check
{
    class Program
    {
        private static int[,] matrix;
        private static int b = int.Parse(Console.ReadLine());
        private static int n = int.Parse(Console.ReadLine());
        static void Main()
        {
            Dictionary<int, long> sums = new Dictionary<int, long>();
            
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(line[j]);
                }
            }
            int border = n - b;
            long maxValue = 0;
            for (int row = 0; row <= border; row++)
            {
                for (int col = 0; col <= border; col++)
                {
                    maxValue += matrix[row, col];
                }
            }

            long currentValue = maxValue;
            for (int row = 0; row <= n - b; row++)
            {
                for (int i = 1; i <= n - b; i++)
                {
                    currentValue = AddRows(row, i, currentValue);
                    if (currentValue > maxValue)
                        maxValue = currentValue;
                }
                if (row != 0)
                {
                    currentValue = AddCols(row, currentValue);
                }
                if (currentValue > maxValue)
                    maxValue = currentValue;
            }
            Console.WriteLine(maxValue);
        }

        private static long AddCols(int row, long currentValue)
        {
            for (int col = 0; col < b; col++)
            {
                currentValue = currentValue - matrix[row - 1, col] + matrix[row + b - 1, col];
            }
            return currentValue;
        }

        private static long AddRows(int row, int col, long currentValue)
        {
            int count = 0;
            for (int i = row; count < n - b; i++)
            {
                currentValue = currentValue - matrix[i, col - 1] + matrix[i, col + b - 1];
                count++;
            }
            return currentValue;
        }
    }
}
