using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortest_Path_In_Matrix
{
    class Program
    {
        private static int[][] matrix;
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            ReadMatrix(rows);
            BuildGraph(rows, cols);
        }

        private static void BuildGraph(int rows, int cols)
        {
            var graph = new Dictionary<Cell, List<Cell>>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Cell cell = new Cell(row, col, matrix[row][col]);
                    List<Cell> neighbours = GetConnectedCells(cell);
                    graph.Add(cell, neighbours);
                }
            }
        }

        private static List<Cell> GetConnectedCells(Cell cell)
        {
            int row = cell.Row;
            int col = cell.Col;
            List<Cell> cells = new List<Cell>();

            //TOP
            if (IsInMatrix(row + 1, col))
            {
                cells.Add(new Cell(row + 1, col, matrix[row + 1][col]));
            }
            //DOWN
            if (IsInMatrix(row, col))
            {
                cells.Add(new Cell(row - 1, col, matrix[row - 1][col]));
            }
            //RIGHT
            if (IsInMatrix(row, col + 1))
            {
                cells.Add(new Cell(row, col + 1, matrix[row][col]));
            }
            //LEFT
            if (IsInMatrix(row, col - 1))
            {
                cells.Add(new Cell(row, col - 1, matrix[row][col - 1]));
            }

            return cells;
        }

        private static void ReadMatrix(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }

    class Cell
    {
        public int Row { get; }
        public int Col { get; }
        public int Value { get; }

        public Cell(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }
    }
}
