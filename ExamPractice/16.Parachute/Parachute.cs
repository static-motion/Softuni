using System;
using System.Collections.Generic;

class parachute
{
    static void Main()
    {
        List<string> inputLines = new List<string>();
        string inputString = Console.ReadLine();
        while (inputString != "END")
        {           
            inputLines.Add(String.Format(@"{0}", inputString));
            inputString = Console.ReadLine();
        }       
        int startRow = 0;
        int startCol = 0;
        char[,] matrix = new char[inputLines.Count, inputLines[0].Length];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = inputLines[row][col];
                if (matrix[row, col] == 'o')
                {
                    startRow = row;
                    startCol = col;
                }
            }
        }
        int currentRow = startRow;
        int currentCol = startCol;
        int movementCounter = 0;
        for (int row = startRow + 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == '>')
                {
                    movementCounter++;
                }
                else if (matrix[row, col] == '<')
                {
                    movementCounter--;
                }
            }
            currentCol += movementCounter;
            movementCounter = 0;
            currentRow++;
            if(matrix[currentRow, currentCol] == '_')
            {
                Console.WriteLine("Landed on the ground like a boss!");
                Console.WriteLine("{0} {1}", currentRow, currentCol);
                break;
            }
            else if(matrix[currentRow, currentCol] == '~')
            {
                Console.WriteLine("Drowned in the water like a cat!");
                Console.WriteLine("{0} {1}", currentRow, currentCol);
                break;
            }
            else if(matrix[currentRow, currentCol] == '/' 
                || matrix[currentRow, currentCol] == '|' 
                || matrix[currentRow, currentCol] == '\\')
            {
                Console.WriteLine("Got smacked on the rock like a dog!");
                Console.WriteLine("{0} {1}", currentRow, currentCol);
                break;
            }
        }
    }
}

