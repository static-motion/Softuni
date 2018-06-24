using System;
using System.Collections.Generic;
using System.Text;

class Palindromes
{
    static void Main()
    {
        string[] inputText = Console.ReadLine().Split(new[] { ',', '.', ' ', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();
        foreach(var word in inputText)
        {
            char[] reverse = word.ToCharArray();
            Array.Reverse(reverse);
            string comparer = String.Join("", reverse);
            if(word == comparer)
            {
                palindromes.Add(word);
            }
        }
        Console.WriteLine(String.Join(", ", palindromes));
    }
}

