using System;
using System.Linq;

namespace Rod_Cutting
{
    class Program
    {
        private static int[] prices;
        private static int[] memo;
        private static int[] indexes;
        static void Main()
        {
            prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rodLength = int.Parse(Console.ReadLine());
            memo = new int[prices.Length];
            indexes = new int[prices.Length];
            Console.WriteLine(CutRod(rodLength));
            PrintSolution(rodLength);
        }

        private static void PrintSolution(int length)
        {
            while (length != 0)
            {
                Console.Write($"{indexes[length]} ");
                length -= indexes[length];
            }
            Console.WriteLine();
        }

        private static int CutRod(int length)
        {
            if (memo[length] != 0)
            {
                return memo[length];
            }
            if (length == 0)
            {
                return 0;
            }
            int max = 0;
            int wholePart = length;
            for (int i = 1; i <= length; i++) 
            {
                int current = Math.Max(prices[i], prices[i] + CutRod(length - i));
                if (max < current)
                {
                    wholePart = i;
                    max = current;
                }
            }
            indexes[length] = wholePart;
            memo[length] = max;
            return max;
        }
    }
}
