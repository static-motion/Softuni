using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class TerroristsWin
{
    static void Main()
    {
        string input = Console.ReadLine();
        int length = input.Length;
        string pattern = @"\|(.*?)\|";
        MatchCollection bombs = Regex.Matches(input, pattern);
        List<char> explodedBomb = input.ToList();
        foreach (Match bomb in bombs)
        {
            string bombPattern = bomb.Groups[1].Value;
            int bombPower = CalculateBombPower(bombPattern);
            int explosionStart = Math.Max(0, bomb.Index - bombPower);
            int explosionEnd = Math.Min(explodedBomb.Count, bomb.Index + bomb.Length + bombPower);            
            for (int i = explosionStart; i < explosionEnd; i++)
            {
                explodedBomb[i] = '.';
            }
        }
        Console.WriteLine(string.Join("", explodedBomb));
    }

    private static int CalculateBombPower(string bombPattern)
    {
        int bombPower = 0;
        foreach(char symbol in bombPattern)
        {
            bombPower += symbol;
        }
        bombPower %= 10;
        return bombPower;
    }
}

