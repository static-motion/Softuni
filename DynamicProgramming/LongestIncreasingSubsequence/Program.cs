using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        private static int[] numbers;
        private static int[] memo;
        static int[] next;
        static void Main()
        {
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            memo = new int[numbers.Length];
            next = new int[numbers.Length];
            List<int> sequenceLength = new List<int>();
            int max = 0;
            int index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sequenceLength.Add(LIS(i));
                if (sequenceLength[i] > max)
                {
                    max = sequenceLength[i];
                    index = i;
                }
            }
            string longest = PrintLis(index);
            Console.WriteLine(longest);
        }

        private static string PrintLis(int i)
        {
            StringBuilder sb = new StringBuilder();
            while (next[i] != i)
            {
                sb.Append(numbers[i] + " ");
                i = next[i];
            }
            sb.Append(numbers[i]);
            return sb.ToString();
        }

        private static int LIS(int index)
        {
            if (memo[index] != 0)
            {
                return memo[index];
            }
            
            int maxLength = 1;
            next[index] = index;
            for (int i = index + 1; i < numbers.Length; i++)
            {
                if (numbers[index] < numbers[i])
                {
                    int length = LIS(i);
                    if (length >= maxLength)
                    {
                        maxLength = length + 1;
                        next[index] = i;
                    }
                }
            }
            memo[index] = maxLength;
            return maxLength;
        }
    }
}
