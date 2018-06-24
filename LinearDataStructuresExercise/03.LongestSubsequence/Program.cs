using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestSubsequence
{
    class Program
    {
        static void Main()
        {
            var sequence = Console.ReadLine().Split(' ');
            List<int> sequenceList = Array.ConvertAll(sequence, int.Parse).ToList();
            Console.WriteLine(string.Join(" ", FindLongestSubsequence(sequenceList)));
        }

        private static List<int> FindLongestSubsequence(List<int> sequence)
        {

            int longestSequence = 1;
            int currentSequence = 1;
            int currentSequenceNumber;
            int longestSequenceNumber = sequence[0];
            for (int i = 1; i < sequence.Count; i++)
            {
                currentSequenceNumber = sequence[i];
                if (sequence[i - 1] == currentSequenceNumber)
                {
                    currentSequence++;
                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                        longestSequenceNumber = currentSequenceNumber;
                    }
                }
                else
                {
                    currentSequence = 1;
                }
            }
            List<int> longestSequenceList = new List<int>();
            for (int i = 0; i < longestSequence; i++)
            {
                longestSequenceList.Add(longestSequenceNumber);
            }
            return longestSequenceList;
        }
    }
}
