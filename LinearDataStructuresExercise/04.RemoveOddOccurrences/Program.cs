using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RemoveOddOccurrences
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
            for (int i = 0; i < numbers.Length; i++)
            {
                if (occurrences[numbers[i]] % 2 == 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
        }
    }
}
