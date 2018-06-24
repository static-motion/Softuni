using System;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(?<=\s|[^\-\.])\b[a-z0-9]+[a-z0-9\.\-_]+\@[a-z0-9]+[a-z0-9\.\-]+\.\w+";
        Regex match = new Regex(pattern);
        MatchCollection matches = match.Matches(input);
        foreach(Match matchlol in matches)
        {
            Console.Write("{0} ", matchlol.Groups[0]);
        }
        Console.WriteLine();
    }
}

