using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medenka
{
    class Program
    {
        private static int[] input;
        private static StringBuilder output = new StringBuilder();
        static void Main()
        {
            input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> cuts = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 1)
                {
                    cuts.Add(i);
                }
            }
            if (input.Sum() == 1)
            {
                Console.WriteLine(string.Join("", input));
                return;
            }
            SplitMedenka(1, cuts);
            Console.WriteLine(output.ToString().Trim());
        }

        private static List<int> cutIndices = new List<int>();
        private static void SplitMedenka(int currentPipe, List<int> cuts)
        {
            if (currentPipe == cuts.Count)
            {
                PrintMedenka(cutIndices);
                return;
            }
            int border = cuts[currentPipe];
            for (int i = cuts[currentPipe - 1]; i < border; i++)
            {
                cutIndices.Add(i);
                SplitMedenka(currentPipe + 1, cuts);
                cutIndices.RemoveAt(cutIndices.Count - 1);
            }
        }

        private static void PrintMedenka(List<int> cuts)
        {
            int pipesPlaced = 0;
            int pipeIndex = cuts[pipesPlaced] + 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (i == pipeIndex)
                {
                    output.Append("|");
                    if(pipesPlaced < cuts.Count - 1)
                        pipeIndex = cuts[++pipesPlaced] + 1;
                }
                output.Append(input[i]);
            }
            output.AppendLine();
        }
    }
}
