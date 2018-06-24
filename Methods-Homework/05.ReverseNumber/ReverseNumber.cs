using System;

class ReverseNumber
{
    static void Main()
    {
        string input = Console.ReadLine();
        double reversed = (Reverse(input));
        Console.WriteLine(reversed);
    }
    static double Reverse(string number)
    {
        char[] reverse = number.ToCharArray();
        Array.Reverse(reverse);
        double reversed = double.Parse(String.Join("", reverse));
        return reversed;
    }
}


