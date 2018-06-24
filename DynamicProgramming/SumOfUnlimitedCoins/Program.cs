using System;
using System.Linq;

namespace SumOfUnlimitedCoins
{
    class Program
    {
        static void Main()
        {
            int[] coinSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());
            int[] ways = new int[target + 1];
            ways[0] = 1;

            foreach (int coin in coinSizes)
            {
                for (int j = coin; j <= target; j++)
                {
                    ways[j] += ways[j - coin];
                }
            }
            Console.WriteLine(ways[target]);
        }
    }
}
