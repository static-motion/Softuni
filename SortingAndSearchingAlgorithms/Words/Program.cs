using System;
using System.Collections.Generic;
using System.Linq;

namespace Words
{
    class Program
    {
        private static HashSet<string> generatedWords = new HashSet<string>();
        private static char[] newWord;
        static void Main()
        {
            string word = Console.ReadLine();
            int wordLength = word.Length;
            newWord = new char[wordLength];
            List<char> letters = word.ToList();
            GenerateWords(letters, wordLength);
        }

        private static void GenerateWords(List<char> letters, int wordLength, int border = 0, char invalidLetter = '1', int index = 0)
        {
            if (index > wordLength - 1)
            {
                Print();
                return;
            }

            for(int i = 0; i < letters.Count; i++)
            {
                if(letters[i] == invalidLetter)
                    continue;

                newWord[index] = letters[i];

                invalidLetter = letters[i];
                letters.RemoveAt(i);
                GenerateWords(letters, wordLength, border, invalidLetter, index + 1);
                if (index - 1 >= 0)
                {
                    invalidLetter = newWord[index - 1];
                }
                else
                {
                    invalidLetter = '1';
                }
            }
        }

        private static void Print()
        {
            string word = string.Join(" ", newWord);
            if (generatedWords.Contains(word))
                return;

            generatedWords.Add(word);
            Console.WriteLine(word);
        }
    }
}
