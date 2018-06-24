using System;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main()
    {
        string[] numbers = Regex.Replace(Console.ReadLine(), @"\D+", " ").Trim().Split(' ');
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = "0x" + int.Parse(numbers[i]).ToString("X").PadLeft(4, '0');
        }
        Console.WriteLine(String.Join("-", numbers));
    }
}

