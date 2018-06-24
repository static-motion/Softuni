using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        foreach (var letter in input)
        {
            string pattern = string.Format(@"{0}+", letter);
            Regex regex = new Regex(pattern);
            string replace = string.Format(@"{0}", letter);
            input = regex.Replace(input, replace);
        }
        Console.WriteLine(input);
    }
}

