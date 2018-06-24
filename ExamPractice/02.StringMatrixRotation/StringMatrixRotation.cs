using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class StringMatrixRotation
{
    static string command = Console.ReadLine();
    static int degrees = int.Parse(Regex.Match(command, @"\d+").ToString());
    static void Main()
    {             
        string word = Console.ReadLine();
        
        List<string> words = new List<string>();

        int currentStringLength = 0, longestStringLength = 0;

        while (word != "END")
        {
            currentStringLength = word.Length;
            if (currentStringLength > longestStringLength)
            {
                longestStringLength = currentStringLength;
            }
            words.Add(word);
            word = Console.ReadLine();
        }
        char[,] matrixToRotate = new char[words.Count, longestStringLength];
        for (int row = 0; row < words.Count; row++)
        {
            for (int col = 0; col < longestStringLength; col++)
            {
                if (col < words[row].Length)
                {
                    matrixToRotate[row, col] = words[row][col];
                }
                else
                {
                    matrixToRotate[row, col] = ' ';
                }
            }
        }
        char[,] rotatedMatrix = (RotateMatrix(matrixToRotate, degrees));
        for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
            {
                Console.Write("{0}", rotatedMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    static char[,] RotateMatrix(char[,] matrixToRotate,int degrees)
    {
        char[,] rotatedMatrix = new char[matrixToRotate.GetLength(1), matrixToRotate.GetLength(0)];
        int newColumn, newRow = 0;
        degrees %= 360;
        degrees /= 90;
        for (int i = 0; i < degrees ; i++)
        {
            rotatedMatrix = new char[matrixToRotate.GetLength(1), matrixToRotate.GetLength(0)];
            for (int oldColumn = 0; oldColumn < matrixToRotate.GetLength(1); oldColumn++)
            {
                newColumn = 0;
                for (int oldRow = matrixToRotate.GetLength(0) - 1; oldRow >= 0; oldRow--)
                {
                    rotatedMatrix[newRow, newColumn] = matrixToRotate[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            newRow = 0;
            newColumn = 0;
            matrixToRotate = rotatedMatrix;
                                 
        }
        return matrixToRotate;
    }
}

