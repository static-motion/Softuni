using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _14.MatrixShuffle
{
    class MatrixShuffle
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();           
            char[,] matrix = new char[size, size];
            int row = 0;
            int col = 0;
            string direction = "right";
            #region.MatrixFill
            for (int i = 0; i < size * size; i++)
            {
                if (direction == "right" && (col > size - 1 || matrix[row, col] != '\0'))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if (direction == "down" && (row > size - 1 || matrix[row, col] != '\0'))
                {
                    direction = "left";
                    row--;
                    col--;
                }
                if (direction == "left" && (col < 0 || matrix[row, col] != '\0'))
                {
                    direction = "up";
                    col++;
                    row--;
                }

                if (direction == "up" && row < 0 || matrix[row, col] != '\0')
                {
                    direction = "right";
                    row++;
                    col++;
                }

                matrix[row, col] = input[i];

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }
            #endregion
            StringBuilder whites = new StringBuilder();
            StringBuilder blacks = new StringBuilder();

            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    if (rows % 2 == 0)
                    {
                        if (cols % 2 == 0)
                        {
                            whites.Append(matrix[rows, cols]);
                        }
                        else
                        {
                            blacks.Append(matrix[rows, cols]);
                        }
                    }
                    else
                    {
                        if (cols % 2 == 0)
                        {
                            blacks.Append(matrix[rows, cols]);
                        }
                        else
                        {
                            whites.Append(matrix[rows, cols]);                           
                        }
                    }
                }
            }         
            string whiteAndBlack = whites.ToString() + blacks.ToString();
            string backup = whiteAndBlack;
            whiteAndBlack = Regex.Replace(whiteAndBlack, @"\W+", "");
            bool isPalindrome = whiteAndBlack.ToLower() == new string(whiteAndBlack.Reverse().ToArray()).ToLower();

            if(isPalindrome)
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", backup);
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", backup);
            }
        }
    }
}
