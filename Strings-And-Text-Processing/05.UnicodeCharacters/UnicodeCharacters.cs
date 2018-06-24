using System;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();
        foreach(var letter in input)
        {
            Console.Write(@"\u" + "{0:X4}", Convert.ToInt32(letter));
        }
        Console.WriteLine();
    }
}

