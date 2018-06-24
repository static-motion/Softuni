using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int> bunnyCoords = new List<int>();
    static void Main()
    {
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rowsSize = size[0];
        int colsSize = size[1];
        var gameField = new char[rowsSize, colsSize];
        int currentRow = 0;
        int currentCol = 0;                       
        for (int row = 0; row < rowsSize; row++)
        {
            string input = Console.ReadLine();
            for (int col = 0; col < colsSize; col++)
            {
                gameField[row, col] = input[col];
                if(gameField[row, col] == 'P')
                {
                    currentRow = row;
                    currentCol = col;
                    gameField[row, col] = '.';
                }
                else if(gameField[row, col] == 'B')
                {
                    bunnyCoords.Add(row);
                    bunnyCoords.Add(col);
                }
            }
        }
        string directions = Console.ReadLine().ToUpper();
        foreach (var direction in directions)
        {
            switch(direction)
            {
                case 'U':
                    {
                        currentRow--;
                        break;                               
                    }
                case 'D':
                    {
                        currentRow++;
                        break;
                    }
                case 'L':
                    {
                        currentCol--;
                        break;
                    }
                case 'R':
                    {
                        currentCol++;
                        break;
                    }                    
            }
            try
            {
                if (gameField[currentRow, currentCol] == 'B')
                {
                    GameLost(gameField, currentRow, currentCol, rowsSize, colsSize);
                    return;
                }
            }
            catch (SystemException)
            {
                GameWon(gameField, currentRow, currentCol, rowsSize, colsSize);
                return;              
            }

            for (int j = 0; j < bunnyCoords.Count; j+=2)
            {
                int row = bunnyCoords[j];
                int col = bunnyCoords[j + 1];
                if (row + 1 < rowsSize)
                {
                    gameField[row + 1, col] = 'B';
                }
                if (row - 1 >= 0)
                {
                    gameField[row - 1, col] = 'B';
                }
                if (col + 1 < colsSize)
                {
                    gameField[row, col + 1] = 'B';
                }
                if (col - 1 >= 0)
                {
                    gameField[row, col - 1] = 'B';
                }
            }
                
            try
            {
                if(gameField[currentRow, currentCol] == 'B')
                {
                    GameLost(gameField, currentRow, currentCol, rowsSize, colsSize);
                    return;
                }
            }
            catch(SystemException)
            {
                GameWon(gameField, currentRow, currentCol, rowsSize, colsSize);
                return;
            }
            bunnyCoords.Clear();
            for (int row = 0; row < rowsSize; row++)
            {
                for (int col = 0; col < colsSize; col++)
                {
                    if (gameField[row, col] == 'B')
                    {
                        bunnyCoords.Add(row);
                        bunnyCoords.Add(col);
                    }
                }
            }
        }
    }

    private static void GameLost(char[,] gameField, int currentRow, int currentCol, int rowsSize, int colsSize)
    {
        for (int j = 0; j < bunnyCoords.Count; j += 2)
        {
            int row = bunnyCoords[j];
            int col = bunnyCoords[j + 1];
            if (row + 1 < rowsSize)
            {
                gameField[row + 1, col] = 'B';
            }
            if (row - 1 >= 0)
            {
                gameField[row - 1, col] = 'B';
            }
            if (col + 1 < colsSize)
            {
                gameField[row, col + 1] = 'B';
            }
            if (col - 1 >= 0)
            {
                gameField[row, col - 1] = 'B';
            }
        }
        if(currentCol >= colsSize)
        {
            currentCol--;
        }
        else if(currentCol < 0)
        {
            currentCol++;
        }
        if(currentRow >= rowsSize)
        {
            currentRow--;
        }
        else if(currentRow < 0)
        {
            currentRow++;
        }
        for (int row = 0; row < gameField.GetLength(0); row++)
        {
            for (int col = 0; col < gameField.GetLength(1); col++)
            {
                Console.Write(gameField[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("dead: {0} {1}", currentRow, currentCol);
    }

    private static void GameWon(char[,] gameField, int currentRow, int currentCol, int rowsSize, int colsSize)
    {
        for (int j = 0; j < bunnyCoords.Count; j += 2)
        {
            int row = bunnyCoords[j];
            int col = bunnyCoords[j + 1];
            if (row + 1 < rowsSize)
            {
                gameField[row + 1, col] = 'B';
            }
            if (row - 1 >= 0)
            {
                gameField[row - 1, col] = 'B';
            }
            if (col + 1 < colsSize)
            {
                gameField[row, col + 1] = 'B';
            }
            if (col - 1 >= 0)
            {
                gameField[row, col - 1] = 'B';
            }
        }
        if (currentCol >= colsSize)
        {
            currentCol--;
        }
        else if (currentCol < 0)
        {
            currentCol++;
        }
        if (currentRow >= rowsSize)
        {
            currentRow--;
        }
        else if (currentRow < 0)
        {
            currentRow++;
        }
        for (int row = 0; row < rowsSize; row++)
        {
            for (int col = 0; col < colsSize; col++)
            {
                Console.Write(gameField[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("won: {0} {1}", currentRow, currentCol);
    }
}