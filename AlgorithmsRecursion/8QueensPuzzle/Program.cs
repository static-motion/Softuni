using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensPuzzle
{
    class Program
    {
        class EightQueens
        {
            private static int solutionsFound = 0;
            const int Size = 8;
            static bool[,] chessboard = new bool[Size, Size];
            static HashSet<int> attackedCols = new HashSet<int>();
            static HashSet<int> attackedLeftDiag = new HashSet<int>();
            static HashSet<int> attackedRightDiag = new HashSet<int>();

            public void Solve()
            {
                PutQueens(0);
            }

            static void PutQueens(int row)
            {
                if (row == Size)
                {
                    PrintSolution();
                }
                else
                {
                    for (int col = 0; col < Size; col++)
                    {
                        if (CanPlaceQueen(row, col))
                        {
                            MarkAllAttackedPosition(row, col);
                            PutQueens(row + 1);
                            UnmarkAllAttackedPositions(row, col);
                        }
                    }
                }
            }

            private static void UnmarkAllAttackedPositions(int row, int col)
            {
                attackedCols.Remove(col);
                attackedLeftDiag.Remove(col - row);
                attackedRightDiag.Remove(col + row);
                chessboard[row, col] = false;
            }

            private static void MarkAllAttackedPosition(int row, int col)
            {
                attackedCols.Add(col);
                attackedLeftDiag.Add(col - row);
                attackedRightDiag.Add(col + row);
                chessboard[row, col] = true;
            }

            private static bool CanPlaceQueen(int row, int col)
            {
                bool isAttacked = attackedCols.Contains(col) ||
                                  attackedLeftDiag.Contains(col - row) ||
                                  attackedRightDiag.Contains(col + row);

                return !isAttacked;
            }

            private static void PrintSolution()
            {
                for (int row = 0; row < Size; row++)
                {
                    for (int col = 0; col < Size; col++)
                    {
                        if (chessboard[row, col])
                        {
                            Console.Write("* ");
                            continue;
                        }
                        Console.Write("- ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                solutionsFound++;
            }
        }
        static void Main()
        {
            EightQueens board = new EightQueens();
            board.Solve();
        }
    }
}
