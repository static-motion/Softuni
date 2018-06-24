using System;
using System.Text;

namespace Blocks
{
    class Program
    {
        private static char[] charSet;
        private static char[] vector;
        private static bool[] used;
        private static int numberOfBlocks;
        private static StringBuilder result = new StringBuilder();
        static void Main()
        {
            int lettersCount = int.Parse(Console.ReadLine());
            charSet = new char[lettersCount];
            vector = new char[4];
            used = new bool[lettersCount];
            int index = 0;
            for (char i = 'A'; i < 'A' + lettersCount; i++, index ++)
            {
                charSet[index] = i;
            }
            for (int i = 0; i < lettersCount - 3; i++)
            {
                vector[0] = (char)('A' + i);
                used[i] = true;
                GenerateVariations(1);
            }
            Console.Write($"Number of blocks: {numberOfBlocks}\n{result}");

        }


        private static void GenerateVariations(int current)
        {
            if (current == 4)
            {
                numberOfBlocks++;
                AppendLetterCombination();
                return;
            }

            for (int index = 1; index < charSet.Length; index++)
            {
                if (used[index])
                {
                    continue;
                }
                vector[current] = charSet[index];
                used[index] = true;
                GenerateVariations(current + 1);
                used[index] = false;
            }
        }

        private static void AppendLetterCombination()
        {
            result.AppendLine(string.Join("", vector));
        }
    }
}
