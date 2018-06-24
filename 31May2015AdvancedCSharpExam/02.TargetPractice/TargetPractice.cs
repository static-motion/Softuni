using System;
using System.Collections.Generic;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rowsCount = dimensions[0];
        int colsCount = dimensions[1];
        int cols = dimensions[1];

        string fillerString = Console.ReadLine();
        int stringCounter = 0;

        int[] impactCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int impactRow = impactCoordinates[0];
        int impactCol = impactCoordinates[1];
        int impactRadius = impactCoordinates[2];

        char[,] stairs = new char[rowsCount, colsCount];

        FillTheMatrix(stringCounter, colsCount, rowsCount, stairs, fillerString, dimensions);
        BombardTheMatrix(stairs, impactRow, impactCol, impactRadius, cols, rowsCount);
        MakeElementsFallDown(stairs, cols, rowsCount);
        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(stairs[row, col]);
            }
            Console.WriteLine();
        }
        
    }
    static void BombardTheMatrix(char[,] stairs, int impactRow, int impactCol, int impactRadius, int cols, int rows)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if ((row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol) <= impactRadius * impactRadius)
                {
                    stairs[row, col] = ' ';
                }
            }
        }
    }

    static void MakeElementsFallDown(char[,] stairs, int cols, int rowsCount)
    {
        int counter = 1;
        while(counter != 0)
        {
            counter = 0;
            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(stairs[row + 1, col] == ' ' && stairs[row, col] != ' ')
                    {
                        stairs[row + 1, col] = stairs[row, col];
                        stairs[row, col] = ' ';
                        counter++;
                    }
                }
            }
        }
    }

    static void FillTheMatrix(int stringCounter, int colsCount, int rowsCount, char[,] stairs, string fillerString, int[] dimensions)
    {
        for (int row = rowsCount - 1; row >= 0; row--)
        {
            if (colsCount == 0)
            {
                while (colsCount != dimensions[1])
                {
                    stairs[row, colsCount] = fillerString[stringCounter];
                    stringCounter++;
                    colsCount++;
                    if (stringCounter > fillerString.Length - 1)
                    {
                        stringCounter = 0;
                    }
                }
            }
            else
            {
                while (colsCount != 0)
                {
                    stairs[row, colsCount - 1] = fillerString[stringCounter];
                    stringCounter++;
                    colsCount--;
                    if (stringCounter > fillerString.Length - 1)
                    {
                        stringCounter = 0;
                    }
                }
            }
        }
    }
}

