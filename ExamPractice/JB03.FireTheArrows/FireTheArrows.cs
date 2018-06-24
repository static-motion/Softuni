using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FireTheArrows
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        
        List<string> typList = new List<string>();
        for (int i = 0; i < size; i++)
        {
            string input = Console.ReadLine();
            typList.Add(input);
        }
        char[,] gameField = new char[size, typList[0].Length];
        for (int row = 0; row < size; row++)
        {
            
            for (int col = 0; col < typList[0].Length; col++)
            {
                gameField[row, col] = typList[row][col];
            }
        }
        bool moves;
        do
        {
            moves = false;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < typList[0].Length; col++)
                {
                    bool hasMoved = MoveFigures(gameField, row, col, size);
                    if (hasMoved)
                    {
                        moves = true;
                    }
                }
            }
        } while (moves);
        for (int row = 0; row < size; row++)
        {
            for (int i = 0; i < typList[0].Length; i++)
            {
                Console.Write(gameField[row, i]);
            }
            Console.WriteLine();
        }
    }

    private static bool MoveFigures(char[,] gameField, int row, int col, int size)
    {
        switch(gameField[row, col])
        {
            case '<':
                {
                    if (col - 1 >= 0 && gameField[row, col - 1] == 'o')
                    {
                        gameField[row, col - 1] = '<';
                        gameField[row, col] = 'o';
                        return true;
                    }
                }
                break;
            case '>':
                {
                    if (col + 1 < gameField.GetLength(1) && gameField[row, col + 1] == 'o')
                    {
                        gameField[row, col + 1] = '>';
                        gameField[row, col] = 'o';
                        return true;
                    }
                    break;
                }
            case '^':
                {
                    if(row - 1 >= 0 && gameField[row - 1, col] == 'o')
                    {
                        gameField[row - 1, col] = '^';
                        gameField[row, col] = 'o';
                        return true;
                    }
                    break;
                }
            case 'v':
                {
                    if (row + 1 < gameField.GetLength(0) && gameField[row + 1, col] == 'o')
                    {
                        gameField[row + 1, col] = 'v';
                        gameField[row, col] = 'o';
                        return true;
                    }
                    break;
                }
        }
        return false; 
    }
}

