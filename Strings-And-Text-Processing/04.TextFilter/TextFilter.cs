using System;
using System.Text;

class TextFilter
{
    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder text = new StringBuilder(Console.ReadLine());
        for (int i = 0; i < bannedWords.Length; i++)
        {
                text.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
        }
        Console.WriteLine(text);
    }
}

