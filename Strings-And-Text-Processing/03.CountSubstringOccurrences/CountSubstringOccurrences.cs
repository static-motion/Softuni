using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        string subString = Console.ReadLine().ToLower();
        int counter = 0;
        int substringPos = -1;
        while (true)
        {
            substringPos = input.IndexOf(subString, substringPos + 1);
            if (substringPos >= 0)
            {
                counter++;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(counter);
    }
}

