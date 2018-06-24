using System;
using System.Text;
using ExtentionMethods;
public static class ExtentionMethodsLAb
{
    public static void Main()
    {
        StringBuilder alphabet = new StringBuilder();
        for (int i = 'a'; i <= 'z'; i++)
        {
            alphabet.Append((char)i);
        }

        string firstTenLetters = alphabet.ToString().Substring(0, 10);
        Console.WriteLine(firstTenLetters);
        
    }   
}       
        
