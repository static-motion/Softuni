using System;
using System.Text.RegularExpressions;

class LettersChangeNumbers
{
    static double firstLetterValue;
    static double lastLetterValue;
    static void Main()
    {
        //string[] input = Console.ReadLine().Trim().Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries );
        string lol = Console.ReadLine().Trim();
        string[] input = Regex.Split(lol, @"\s+");
        double calculatedValue = 0;
        foreach (var lettersAndNumbers in input)
        {
            long number = long.Parse(lettersAndNumbers.Substring(1, lettersAndNumbers.Length - 2));
            calculatedValue += AssignNumberValue(lettersAndNumbers[0], lettersAndNumbers[lettersAndNumbers.Length - 1], number);
        }
        Console.WriteLine("{0:f2}", calculatedValue);
    }

    private static double AssignNumberValue(char firstChar, char lastChar, double number)
    {
        if (firstChar >= 'a')
        {
            firstLetterValue = firstChar - 96;
            number *= firstLetterValue;
        }
        else
        {
            firstLetterValue = firstChar - 64;
            number /= firstLetterValue;
        }
        if(lastChar >= 'a')
        {
            lastLetterValue = lastChar - 96;
            number += lastLetterValue;
        }
        else
        {
            lastLetterValue = lastChar - 64;
            number -= lastLetterValue;
        }
        return number;
    }
}

