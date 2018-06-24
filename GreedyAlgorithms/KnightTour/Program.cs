using System;
using System.Collections.Generic;

namespace KnightTour
{
    class Program
    {
        private static int _nextMove = 1;
        private static int _currentRow;
        private static int _currentCol;
        private static int _border;
        private static int[,] matrix =
        {
            {1, 24, 61, 96, 3, 26, 91, 110, 5, 28, 31, 112},
            {62, 95, 2, 25, 92, 141, 4, 27, 114, 111, 6, 29},
            {23, 60, 93, 144, 97, 90, 135, 142, 109, 30, 113, 32},
            {94, 63, 98, 89, 140, 143, 130, 115, 136, 119, 108, 7},
            {59, 22, 139, 100, 129, 134, 137, 126, 107, 116, 33, 118},
            {64, 99, 88, 133, 138, 127, 106, 131, 120, 125, 8, 81,},
            {21, 58, 65, 128, 101, 132, 121, 124, 105, 82, 117, 34},
            {46, 55, 102, 87, 66, 77, 104, 83, 122, 75, 80, 9},
            {57, 20, 47, 54, 103, 86, 123, 76, 79, 84, 35, 74},
            {42, 45, 56, 67, 50, 53, 78, 85, 70, 73, 10, 13},
            {19, 48, 43, 40, 17, 68, 51, 38, 15, 12, 71, 36},
            {44, 41, 18, 49, 52, 39, 16, 69, 72, 37, 14, 11}
        };
        private static int[,] Moves =
        {
            {1, 2}, //M7
            {-1, 2}, //M3
            {1, -2}, //M8
            {-1, -2}, //M4
            {2, 1}, //M5
            {2, -1}, //M6
            {-2, 1}, //M1
            {-2, -1} //M2
        };
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            TraverseBoard(size);
        }
        private static void TraverseBoard(int size)
        {
            int boardSize = size;
            int allMoves = boardSize * boardSize;
            _border = boardSize - 1;
            int[,] board = new int[boardSize, boardSize];
            Move(board, new[] { _currentRow, _currentCol });
            Tour(allMoves, board);
            PrintBoard(board);
        }

        private static void Tour(int allMoves, int[,] board)
        {
            do
            {
                var possibleMoves = GetPossibleMoves(board, _currentRow, _currentCol);
                int[] bestMove = new int[2];
                int minMoves = int.MaxValue;
                foreach (var move in possibleMoves)
                {
                    int row = move[0];
                    int col = move[1];
                    List<int[]> moves = GetPossibleMoves(board, row, col);

                    if (minMoves <= moves.Count)
                        continue;

                    bestMove = move;
                    minMoves = moves.Count;
                }
                Move(board, bestMove);
            } while (_nextMove <= allMoves);
        }

        private static void PrintBoard(int[,] board)
        {
            for (int i = 0; i <= _border; i++)
            {
                for (int j = 0; j <= _border; j++)
                {
                    Console.Write(board[i, j].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }

        private static void Move(int[,] board, int[] bestMove)
        {
            int row = bestMove[0];
            int col = bestMove[1];
            board[row, col] = _nextMove++;
            _currentRow = row;
            _currentCol = col;
        }

        private static List<int[]> GetPossibleMoves(int[,] board,int x, int y)
        {
            var availableMoves = new List<int[]>();
            for (int i = 0; i < Moves.GetLength(0); i++)
            {
                int row = Moves[i, 0] + x;
                int col = Moves[i, 1] + y;
                if (IsInside(row, col) && board[row, col] == 0)
                {
                    availableMoves.Add(new[]{row, col});
                }
            }
            return availableMoves;
        }

        private static bool IsInside(int row, int col)
        {
            return row <= _border && row >= 0 && col <= _border && col >= 0;
        }
    }
}