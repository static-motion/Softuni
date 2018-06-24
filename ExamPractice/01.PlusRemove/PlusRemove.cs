using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlusRemove
{
    static void Main()
    {
        List<string> inputList = new List<string>();
        string addNewStrings = Console.ReadLine();
        while (addNewStrings != "END")
        {
            inputList.Add(addNewStrings);
            addNewStrings = Console.ReadLine();
        }
        char[][] findPlus = new char[inputList.Count][];

        for (int i = 0; i < inputList.Count; i++)
        {
            findPlus[i] = inputList[i].ToCharArray();
        }
        char left, 
            middle, 
            right, 
            top, 
            bottom;
        bool[][] pluses = new bool[inputList.Count][];
        for (int i = 0; i < inputList.Count; i++)
        {
            pluses[i] = new bool[inputList[i].Length];
        }
        for (int row = 1; row < inputList.Count - 1; row++)
        {
            for (int col = 0; col < findPlus[row].Length; col++)
            {
                try
                {
                    left = findPlus[row][col];
                    middle = findPlus[row][col + 1];
                    right = findPlus[row][col + 2];
                    top = findPlus[row + 1][col + 1];
                    bottom = findPlus[row - 1][col + 1];
                    bool ifPlus = CheckForPlus(left, middle, right, top, bottom);
                    if(ifPlus)
                    {
                        pluses[row][col] = true;
                        pluses[row][col + 1] = true;
                        pluses[row][col + 2] = true;
                        pluses[row + 1][col + 1] = true;
                        pluses[row - 1][col + 1] = true;
                    }
                }
                catch(SystemException)
                {
                    left = '\0';
                    middle = '\0';
                    right = '\0';
                    top = '\0';
                    bottom = '\0';
                }
            }
        }
        for (int row = 0; row < findPlus.GetLength(0); row++)
        {
            for (int col = 0; col < findPlus[row].Length; col++)
            {
                if(pluses[row][col])
                {
                    findPlus[row][col] = ' ';
                }
            }
        }

        for (int row = 0; row < findPlus.GetLength(0); row++)
        {
            for (int col = 0; col < findPlus[row].Length; col++)
            {
                if(findPlus[row][col] != ' ')
                Console.Write(findPlus[row][col]);
            }
            Console.WriteLine();
        }

    }

    private static bool CheckForPlus(char left, char middle, char right, char top, char bottom)
    {
        if(left.ToString().ToLower() == middle.ToString().ToLower()
            && left.ToString().ToLower() == right.ToString().ToLower()
            && left.ToString().ToLower() == top.ToString().ToLower()
            && left.ToString().ToLower() == bottom.ToString().ToLower())
        {
            return true;
        }
        return false;
    }
}

