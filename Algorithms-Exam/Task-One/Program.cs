using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_One
{
    class Program
    {
        private static StringBuilder sb = new StringBuilder();
        static HashSet<string> used = new HashSet<string>();
        static void Main()
        {
            List<int> targets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int targetScore = int.Parse(Console.ReadLine());
            sum_up(targets, targetScore);
            Console.WriteLine(sb.ToString().Trim());
        }
        private static void sum_up(List<int> numbers, int target)
        {
            SumUpRecursive(numbers, target, new List<int>());
        }

        private static void SumUpRecursive(List<int> numbers, int target, List<int> partial)
        {
            int multiplier = 0;
            int sum = partial.Sum(x => x * ++multiplier);

            if (sum == target)
            {
                AppendVector(partial.ToArray());
            }
            sum = partial.Sum(x => x * multiplier--);
            if (sum == target && partial.Count > 1)
            {
                AppendVector(partial.ToArray().Reverse());
            }

            if (sum >= target)
                return;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }
                List<int> partialRec = new List<int>(partial) {n};
                SumUpRecursive(remaining, target, partialRec);
            }
        }
        private static void AppendVector(IEnumerable<int> vector)
        {
            string perm = string.Join(" ", vector);
            if (!used.Contains(perm))
            {
                sb.AppendLine(perm);
                used.Add(perm);
            }
        }
    }
}
