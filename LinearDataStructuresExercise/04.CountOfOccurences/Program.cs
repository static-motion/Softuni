using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CountOfOccurences
{
    class Program
    {
        static void Main()
        {
            string[] sequence = Console.ReadLine().Split(' ').ToArray();
            int[] numbers = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                numbers[i] = int.Parse(sequence[i]);
            }
            numbers = numbers.OrderBy(a => a).ToArray();
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (!occurrences.ContainsKey(number))
                {
                    occurrences[number] = 1;
                    continue;
                }
                occurrences[number]++;
            }
            foreach (var occurrence in occurrences)
            {
                Console.WriteLine($"{occurrence.Key} -> {occurrence.Value} times");
            }
        }
    }
}
