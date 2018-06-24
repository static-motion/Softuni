using System;
using System.Linq;

namespace Sum_To_Thirteen
{
    class Program
    {
        private static bool isPossible;
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Gen(input, 0);
            string output = "No";
            if (isPossible)
            {
                output = "Yes";
            }
            Console.WriteLine(output);
        }

        private static void Gen(int[] input, int next)
        {
            if (next >= input.Length)
            {
                if(!isPossible)
                    isPossible = input.Sum() == 13;
                return;
            }
            Gen(input, next + 1);
            input[next] *= -1;
            Gen(input, next + 1);
            input[next] *= -1;
        }
    }
}
