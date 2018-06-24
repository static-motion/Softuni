using System;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] reverse = input.ToCharArray();
        Array.Reverse(reverse);
        Console.WriteLine(String.Join("", reverse));
    }
}

